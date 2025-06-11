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
   public class chavepixww : GXDataArea
   {
      public chavepixww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public chavepixww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContaBancariaId )
      {
         this.AV87ContaBancariaId = aP0_ContaBancariaId;
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
         cmbavChavepixtipo1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavChavepixtipo2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavChavepixtipo3 = new GXCombobox();
         cmbavGridactiongroup1 = new GXCombobox();
         cmbChavePIXTipo = new GXCombobox();
         cmbChavePIXStatus = new GXCombobox();
         cmbChavePIXPrincipal = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ContaBancariaId");
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
               gxfirstwebparm = GetFirstPar( "ContaBancariaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ContaBancariaId");
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
         nRC_GXsfl_137 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_137"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_137_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_137_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_137_idx = GetPar( "sGXsfl_137_idx");
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
         cmbavChavepixtipo1.FromJSonString( GetNextPar( ));
         AV18ChavePIXTipo1 = GetPar( "ChavePIXTipo1");
         AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero1"), "."), 18, MidpointRounding.ToEven));
         AV20ChavePIXCreatedByName1 = GetPar( "ChavePIXCreatedByName1");
         AV21ChavePIXUpdatedByName1 = GetPar( "ChavePIXUpdatedByName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavChavepixtipo2.FromJSonString( GetNextPar( ));
         AV25ChavePIXTipo2 = GetPar( "ChavePIXTipo2");
         AV26ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero2"), "."), 18, MidpointRounding.ToEven));
         AV27ChavePIXCreatedByName2 = GetPar( "ChavePIXCreatedByName2");
         AV28ChavePIXUpdatedByName2 = GetPar( "ChavePIXUpdatedByName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         cmbavChavepixtipo3.FromJSonString( GetNextPar( ));
         AV32ChavePIXTipo3 = GetPar( "ChavePIXTipo3");
         AV33ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero3"), "."), 18, MidpointRounding.ToEven));
         AV34ChavePIXCreatedByName3 = GetPar( "ChavePIXCreatedByName3");
         AV35ChavePIXUpdatedByName3 = GetPar( "ChavePIXUpdatedByName3");
         AV87ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV29DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV92Pgmname = GetPar( "Pgmname");
         AV58TFAgenciaBancoNome = GetPar( "TFAgenciaBancoNome");
         AV59TFAgenciaBancoNome_Sel = GetPar( "TFAgenciaBancoNome_Sel");
         AV56TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero"), "."), 18, MidpointRounding.ToEven));
         AV57TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero_To"), "."), 18, MidpointRounding.ToEven));
         AV54TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaNumero"), "."), 18, MidpointRounding.ToEven));
         AV55TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaNumero_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFChavePIXTipo_Sels);
         AV48TFChavePIXConteudo = GetPar( "TFChavePIXConteudo");
         AV49TFChavePIXConteudo_Sel = GetPar( "TFChavePIXConteudo_Sel");
         AV50TFChavePIXStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFChavePIXStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV51TFChavePIXPrincipal_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFChavePIXPrincipal_Sel"), "."), 18, MidpointRounding.ToEven));
         AV60TFChavePIXCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFChavePIXCreatedAt"));
         AV61TFChavePIXCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFChavePIXCreatedAt_To"));
         AV67TFChavePIXCreatedByName = GetPar( "TFChavePIXCreatedByName");
         AV68TFChavePIXCreatedByName_Sel = GetPar( "TFChavePIXCreatedByName_Sel");
         AV69TFChavePIXUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFChavePIXUpdatedAt"));
         AV70TFChavePIXUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFChavePIXUpdatedAt_To"));
         AV76TFChavePIXUpdatedByName = GetPar( "TFChavePIXUpdatedByName");
         AV77TFChavePIXUpdatedByName_Sel = GetPar( "TFChavePIXUpdatedByName_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV37DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV36DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV90BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
         AV91AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
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
         PA9L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9L2( ) ;
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
         GXEncryptionTmp = "chavepixww"+UrlEncode(StringUtil.LTrimStr(AV87ContaBancariaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("chavepixww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90BancoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91AgenciaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXTIPO1", AV18ChavePIXTipo1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXCREATEDBYNAME1", AV20ChavePIXCreatedByName1);
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXUPDATEDBYNAME1", AV21ChavePIXUpdatedByName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXTIPO2", AV25ChavePIXTipo2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ContaBancariaNumero2), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXCREATEDBYNAME2", AV27ChavePIXCreatedByName2);
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXUPDATEDBYNAME2", AV28ChavePIXUpdatedByName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV30DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXTIPO3", AV32ChavePIXTipo3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ContaBancariaNumero3), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXCREATEDBYNAME3", AV34ChavePIXCreatedByName3);
         GxWebStd.gx_hidden_field( context, "GXH_vCHAVEPIXUPDATEDBYNAME3", AV35ChavePIXUpdatedByName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_137", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_137), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV82GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV78DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV78DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CHAVEPIXCREATEDATAUXDATE", context.localUtil.DToC( AV62DDO_ChavePIXCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CHAVEPIXCREATEDATAUXDATETO", context.localUtil.DToC( AV63DDO_ChavePIXCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CHAVEPIXUPDATEDATAUXDATE", context.localUtil.DToC( AV71DDO_ChavePIXUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CHAVEPIXUPDATEDATAUXDATETO", context.localUtil.DToC( AV72DDO_ChavePIXUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV29DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME", AV58TFAgenciaBancoNome);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME_SEL", AV59TFAgenciaBancoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFAgenciaNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57TFAgenciaNumero_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54TFContaBancariaNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIANUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55TFContaBancariaNumero_To), 18, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCHAVEPIXTIPO_SELS", AV47TFChavePIXTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCHAVEPIXTIPO_SELS", AV47TFChavePIXTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCONTEUDO", AV48TFChavePIXConteudo);
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCONTEUDO_SEL", AV49TFChavePIXConteudo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXPRINCIPAL_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCREATEDAT", context.localUtil.TToC( AV60TFChavePIXCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCREATEDAT_TO", context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCREATEDBYNAME", AV67TFChavePIXCreatedByName);
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXCREATEDBYNAME_SEL", AV68TFChavePIXCreatedByName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXUPDATEDAT", context.localUtil.TToC( AV69TFChavePIXUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXUPDATEDAT_TO", context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXUPDATEDBYNAME", AV76TFChavePIXUpdatedByName);
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXUPDATEDBYNAME_SEL", AV77TFChavePIXUpdatedByName_Sel);
         GxWebStd.gx_hidden_field( context, "vCONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV37DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV36DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "AGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90BancoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFCHAVEPIXTIPO_SELSJSON", AV46TFChavePIXTipo_SelsJson);
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
            WE9L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9L2( ) ;
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
         GXEncryptionTmp = "chavepixww"+UrlEncode(StringUtil.LTrimStr(AV87ContaBancariaId,9,0));
         return formatLink("chavepixww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ChavePIXWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Chave PIX" ;
      }

      protected void WB9L0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIXWW.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIXWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ChavePIXWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_48_9L2( true) ;
         }
         else
         {
            wb_table1_48_9L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_9L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_79_9L2( true) ;
         }
         else
         {
            wb_table2_79_9L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_79_9L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV30DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_110_9L2( true) ;
         }
         else
         {
            wb_table3_110_9L2( false) ;
         }
         return  ;
      }

      protected void wb_table3_110_9L2e( bool wbgen )
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
            StartGridControl137( ) ;
         }
         if ( wbEnd == 137 )
         {
            wbEnd = 0;
            nRC_GXsfl_137 = (int)(nGXsfl_137_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV80GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV81GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV82GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ChavePIXWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV78DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_chavepixcreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_chavepixcreatedatauxdatetext_Internalname, AV64DDO_ChavePIXCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV64DDO_ChavePIXCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_chavepixcreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            /* User Defined Control */
            ucTfchavepixcreatedat_rangepicker.SetProperty("Start Date", AV62DDO_ChavePIXCreatedAtAuxDate);
            ucTfchavepixcreatedat_rangepicker.SetProperty("End Date", AV63DDO_ChavePIXCreatedAtAuxDateTo);
            ucTfchavepixcreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfchavepixcreatedat_rangepicker_Internalname, "TFCHAVEPIXCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_chavepixupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_chavepixupdatedatauxdatetext_Internalname, AV73DDO_ChavePIXUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV73DDO_ChavePIXUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_chavepixupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            /* User Defined Control */
            ucTfchavepixupdatedat_rangepicker.SetProperty("Start Date", AV71DDO_ChavePIXUpdatedAtAuxDate);
            ucTfchavepixupdatedat_rangepicker.SetProperty("End Date", AV72DDO_ChavePIXUpdatedAtAuxDateTo);
            ucTfchavepixupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfchavepixupdatedat_rangepicker_Internalname, "TFCHAVEPIXUPDATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 137 )
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

      protected void START9L2( )
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
         Form.Meta.addItem("description", " Chave PIX", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9L0( ) ;
      }

      protected void WS9L2( )
      {
         START9L2( ) ;
         EVT9L2( ) ;
      }

      protected void EVT9L2( )
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
                              E119L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E209L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E229L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249L2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_137_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
                              SubsflControlProps_1372( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV88GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV88GridActionGroup1), 4, 0));
                              A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
                              n969AgenciaBancoNome = false;
                              A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n939AgenciaNumero = false;
                              A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n952ContaBancariaNumero = false;
                              A961ChavePIXId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtChavePIXId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              cmbChavePIXTipo.Name = cmbChavePIXTipo_Internalname;
                              cmbChavePIXTipo.CurrentValue = cgiGet( cmbChavePIXTipo_Internalname);
                              A962ChavePIXTipo = cgiGet( cmbChavePIXTipo_Internalname);
                              n962ChavePIXTipo = false;
                              A963ChavePIXConteudo = cgiGet( edtChavePIXConteudo_Internalname);
                              n963ChavePIXConteudo = false;
                              cmbChavePIXStatus.Name = cmbChavePIXStatus_Internalname;
                              cmbChavePIXStatus.CurrentValue = cgiGet( cmbChavePIXStatus_Internalname);
                              A964ChavePIXStatus = StringUtil.StrToBool( cgiGet( cmbChavePIXStatus_Internalname));
                              n964ChavePIXStatus = false;
                              cmbChavePIXPrincipal.Name = cmbChavePIXPrincipal_Internalname;
                              cmbChavePIXPrincipal.CurrentValue = cgiGet( cmbChavePIXPrincipal_Internalname);
                              A965ChavePIXPrincipal = StringUtil.StrToBool( cgiGet( cmbChavePIXPrincipal_Internalname));
                              n965ChavePIXPrincipal = false;
                              A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n951ContaBancariaId = false;
                              A966ChavePIXCreatedAt = context.localUtil.CToT( cgiGet( edtChavePIXCreatedAt_Internalname), 0);
                              n966ChavePIXCreatedAt = false;
                              A957ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtChavePIXCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n957ChavePIXCreatedBy = false;
                              A958ChavePIXCreatedByName = StringUtil.Upper( cgiGet( edtChavePIXCreatedByName_Internalname));
                              n958ChavePIXCreatedByName = false;
                              A967ChavePIXUpdatedAt = context.localUtil.CToT( cgiGet( edtChavePIXUpdatedAt_Internalname), 0);
                              n967ChavePIXUpdatedAt = false;
                              A959ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtChavePIXUpdatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n959ChavePIXUpdatedBy = false;
                              A960ChavePIXUpdatedByName = StringUtil.Upper( cgiGet( edtChavePIXUpdatedByName_Internalname));
                              n960ChavePIXUpdatedByName = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E259L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E269L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E279L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E289L2 ();
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
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
                                       /* Set Refresh If Chavepixtipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO1"), AV18ChavePIXTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixcreatedbyname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME1"), AV20ChavePIXCreatedByName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixupdatedbyname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME1"), AV21ChavePIXUpdatedByName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixtipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO2"), AV25ChavePIXTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV26ContaBancariaNumero2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixcreatedbyname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME2"), AV27ChavePIXCreatedByName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixupdatedbyname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME2"), AV28ChavePIXUpdatedByName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixtipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO3"), AV32ChavePIXTipo3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV33ContaBancariaNumero3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixcreatedbyname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME3"), AV34ChavePIXCreatedByName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chavepixupdatedbyname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME3"), AV35ChavePIXUpdatedByName3) != 0 )
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

      protected void WE9L2( )
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

      protected void PA9L2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "chavepixww")), "chavepixww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "chavepixww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ContaBancariaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV87ContaBancariaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV87ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV87ContaBancariaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87ContaBancariaId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_1372( ) ;
         while ( nGXsfl_137_idx <= nRC_GXsfl_137 )
         {
            sendrow_1372( ) ;
            nGXsfl_137_idx = ((subGrid_Islastpage==1)&&(nGXsfl_137_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_137_idx+1);
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
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
                                       string AV18ChavePIXTipo1 ,
                                       long AV19ContaBancariaNumero1 ,
                                       string AV20ChavePIXCreatedByName1 ,
                                       string AV21ChavePIXUpdatedByName1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV25ChavePIXTipo2 ,
                                       long AV26ContaBancariaNumero2 ,
                                       string AV27ChavePIXCreatedByName2 ,
                                       string AV28ChavePIXUpdatedByName2 ,
                                       string AV30DynamicFiltersSelector3 ,
                                       short AV31DynamicFiltersOperator3 ,
                                       string AV32ChavePIXTipo3 ,
                                       long AV33ContaBancariaNumero3 ,
                                       string AV34ChavePIXCreatedByName3 ,
                                       string AV35ChavePIXUpdatedByName3 ,
                                       int AV87ContaBancariaId ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV29DynamicFiltersEnabled3 ,
                                       string AV92Pgmname ,
                                       string AV58TFAgenciaBancoNome ,
                                       string AV59TFAgenciaBancoNome_Sel ,
                                       int AV56TFAgenciaNumero ,
                                       int AV57TFAgenciaNumero_To ,
                                       long AV54TFContaBancariaNumero ,
                                       long AV55TFContaBancariaNumero_To ,
                                       GxSimpleCollection<string> AV47TFChavePIXTipo_Sels ,
                                       string AV48TFChavePIXConteudo ,
                                       string AV49TFChavePIXConteudo_Sel ,
                                       short AV50TFChavePIXStatus_Sel ,
                                       short AV51TFChavePIXPrincipal_Sel ,
                                       DateTime AV60TFChavePIXCreatedAt ,
                                       DateTime AV61TFChavePIXCreatedAt_To ,
                                       string AV67TFChavePIXCreatedByName ,
                                       string AV68TFChavePIXCreatedByName_Sel ,
                                       DateTime AV69TFChavePIXUpdatedAt ,
                                       DateTime AV70TFChavePIXUpdatedAt_To ,
                                       string AV76TFChavePIXUpdatedByName ,
                                       string AV77TFChavePIXUpdatedByName_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV37DynamicFiltersIgnoreFirst ,
                                       bool AV36DynamicFiltersRemoving ,
                                       int AV90BancoId ,
                                       int AV91AgenciaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CHAVEPIXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A961ChavePIXId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", "")));
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
         if ( cmbavChavepixtipo1.ItemCount > 0 )
         {
            AV18ChavePIXTipo1 = cmbavChavepixtipo1.getValidValue(AV18ChavePIXTipo1);
            AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
            AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", cmbavChavepixtipo1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavChavepixtipo2.ItemCount > 0 )
         {
            AV25ChavePIXTipo2 = cmbavChavepixtipo2.getValidValue(AV25ChavePIXTipo2);
            AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
            AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", cmbavChavepixtipo2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         if ( cmbavChavepixtipo3.ItemCount > 0 )
         {
            AV32ChavePIXTipo3 = cmbavChavepixtipo3.getValidValue(AV32ChavePIXTipo3);
            AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
            AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", cmbavChavepixtipo3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV92Pgmname = "ChavePIXWW";
      }

      protected void RF9L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 137;
         /* Execute user event: Refresh */
         E269L2 ();
         nGXsfl_137_idx = 1;
         sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
         SubsflControlProps_1372( ) ;
         bGXsfl_137_Refreshing = true;
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
            SubsflControlProps_1372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A962ChavePIXTipo ,
                                                 AV120Chavepixwwds_28_tfchavepixtipo_sels ,
                                                 AV93Chavepixwwds_1_filterfulltext ,
                                                 AV94Chavepixwwds_2_dynamicfiltersselector1 ,
                                                 AV96Chavepixwwds_4_chavepixtipo1 ,
                                                 AV95Chavepixwwds_3_dynamicfiltersoperator1 ,
                                                 AV97Chavepixwwds_5_contabancarianumero1 ,
                                                 AV98Chavepixwwds_6_chavepixcreatedbyname1 ,
                                                 AV99Chavepixwwds_7_chavepixupdatedbyname1 ,
                                                 AV100Chavepixwwds_8_dynamicfiltersenabled2 ,
                                                 AV101Chavepixwwds_9_dynamicfiltersselector2 ,
                                                 AV103Chavepixwwds_11_chavepixtipo2 ,
                                                 AV102Chavepixwwds_10_dynamicfiltersoperator2 ,
                                                 AV104Chavepixwwds_12_contabancarianumero2 ,
                                                 AV105Chavepixwwds_13_chavepixcreatedbyname2 ,
                                                 AV106Chavepixwwds_14_chavepixupdatedbyname2 ,
                                                 AV107Chavepixwwds_15_dynamicfiltersenabled3 ,
                                                 AV108Chavepixwwds_16_dynamicfiltersselector3 ,
                                                 AV110Chavepixwwds_18_chavepixtipo3 ,
                                                 AV109Chavepixwwds_17_dynamicfiltersoperator3 ,
                                                 AV111Chavepixwwds_19_contabancarianumero3 ,
                                                 AV112Chavepixwwds_20_chavepixcreatedbyname3 ,
                                                 AV113Chavepixwwds_21_chavepixupdatedbyname3 ,
                                                 AV115Chavepixwwds_23_tfagenciabanconome_sel ,
                                                 AV114Chavepixwwds_22_tfagenciabanconome ,
                                                 AV116Chavepixwwds_24_tfagencianumero ,
                                                 AV117Chavepixwwds_25_tfagencianumero_to ,
                                                 AV118Chavepixwwds_26_tfcontabancarianumero ,
                                                 AV119Chavepixwwds_27_tfcontabancarianumero_to ,
                                                 AV120Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                                 AV122Chavepixwwds_30_tfchavepixconteudo_sel ,
                                                 AV121Chavepixwwds_29_tfchavepixconteudo ,
                                                 AV123Chavepixwwds_31_tfchavepixstatus_sel ,
                                                 AV124Chavepixwwds_32_tfchavepixprincipal_sel ,
                                                 AV125Chavepixwwds_33_tfchavepixcreatedat ,
                                                 AV126Chavepixwwds_34_tfchavepixcreatedat_to ,
                                                 AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                                 AV127Chavepixwwds_35_tfchavepixcreatedbyname ,
                                                 AV129Chavepixwwds_37_tfchavepixupdatedat ,
                                                 AV130Chavepixwwds_38_tfchavepixupdatedat_to ,
                                                 AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                                 AV131Chavepixwwds_39_tfchavepixupdatedbyname ,
                                                 AV87ContaBancariaId ,
                                                 A969AgenciaBancoNome ,
                                                 A939AgenciaNumero ,
                                                 A952ContaBancariaNumero ,
                                                 A963ChavePIXConteudo ,
                                                 A964ChavePIXStatus ,
                                                 A965ChavePIXPrincipal ,
                                                 A958ChavePIXCreatedByName ,
                                                 A960ChavePIXUpdatedByName ,
                                                 A966ChavePIXCreatedAt ,
                                                 A967ChavePIXUpdatedAt ,
                                                 A951ContaBancariaId ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
            lV98Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
            lV98Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
            lV99Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
            lV99Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
            lV105Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
            lV105Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
            lV106Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
            lV106Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
            lV112Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
            lV112Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
            lV113Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
            lV113Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
            lV114Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV114Chavepixwwds_22_tfagenciabanconome), "%", "");
            lV121Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV121Chavepixwwds_29_tfchavepixconteudo), "%", "");
            lV127Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV127Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
            lV131Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV131Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
            /* Using cursor H009L2 */
            pr_default.execute(0, new Object[] {lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, AV96Chavepixwwds_4_chavepixtipo1, AV97Chavepixwwds_5_contabancarianumero1, AV97Chavepixwwds_5_contabancarianumero1, AV97Chavepixwwds_5_contabancarianumero1, lV98Chavepixwwds_6_chavepixcreatedbyname1, lV98Chavepixwwds_6_chavepixcreatedbyname1, lV99Chavepixwwds_7_chavepixupdatedbyname1, lV99Chavepixwwds_7_chavepixupdatedbyname1, AV103Chavepixwwds_11_chavepixtipo2, AV104Chavepixwwds_12_contabancarianumero2, AV104Chavepixwwds_12_contabancarianumero2, AV104Chavepixwwds_12_contabancarianumero2, lV105Chavepixwwds_13_chavepixcreatedbyname2, lV105Chavepixwwds_13_chavepixcreatedbyname2, lV106Chavepixwwds_14_chavepixupdatedbyname2, lV106Chavepixwwds_14_chavepixupdatedbyname2, AV110Chavepixwwds_18_chavepixtipo3, AV111Chavepixwwds_19_contabancarianumero3, AV111Chavepixwwds_19_contabancarianumero3, AV111Chavepixwwds_19_contabancarianumero3, lV112Chavepixwwds_20_chavepixcreatedbyname3, lV112Chavepixwwds_20_chavepixcreatedbyname3, lV113Chavepixwwds_21_chavepixupdatedbyname3, lV113Chavepixwwds_21_chavepixupdatedbyname3, lV114Chavepixwwds_22_tfagenciabanconome, AV115Chavepixwwds_23_tfagenciabanconome_sel, AV116Chavepixwwds_24_tfagencianumero, AV117Chavepixwwds_25_tfagencianumero_to, AV118Chavepixwwds_26_tfcontabancarianumero, AV119Chavepixwwds_27_tfcontabancarianumero_to, lV121Chavepixwwds_29_tfchavepixconteudo, AV122Chavepixwwds_30_tfchavepixconteudo_sel, AV125Chavepixwwds_33_tfchavepixcreatedat, AV126Chavepixwwds_34_tfchavepixcreatedat_to, lV127Chavepixwwds_35_tfchavepixcreatedbyname, AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV129Chavepixwwds_37_tfchavepixupdatedat, AV130Chavepixwwds_38_tfchavepixupdatedat_to, lV131Chavepixwwds_39_tfchavepixupdatedbyname, AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV87ContaBancariaId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_137_idx = 1;
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A968AgenciaBancoId = H009L2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H009L2_n968AgenciaBancoId[0];
               A938AgenciaId = H009L2_A938AgenciaId[0];
               n938AgenciaId = H009L2_n938AgenciaId[0];
               A960ChavePIXUpdatedByName = H009L2_A960ChavePIXUpdatedByName[0];
               n960ChavePIXUpdatedByName = H009L2_n960ChavePIXUpdatedByName[0];
               A959ChavePIXUpdatedBy = H009L2_A959ChavePIXUpdatedBy[0];
               n959ChavePIXUpdatedBy = H009L2_n959ChavePIXUpdatedBy[0];
               A967ChavePIXUpdatedAt = H009L2_A967ChavePIXUpdatedAt[0];
               n967ChavePIXUpdatedAt = H009L2_n967ChavePIXUpdatedAt[0];
               A958ChavePIXCreatedByName = H009L2_A958ChavePIXCreatedByName[0];
               n958ChavePIXCreatedByName = H009L2_n958ChavePIXCreatedByName[0];
               A957ChavePIXCreatedBy = H009L2_A957ChavePIXCreatedBy[0];
               n957ChavePIXCreatedBy = H009L2_n957ChavePIXCreatedBy[0];
               A966ChavePIXCreatedAt = H009L2_A966ChavePIXCreatedAt[0];
               n966ChavePIXCreatedAt = H009L2_n966ChavePIXCreatedAt[0];
               A951ContaBancariaId = H009L2_A951ContaBancariaId[0];
               n951ContaBancariaId = H009L2_n951ContaBancariaId[0];
               A965ChavePIXPrincipal = H009L2_A965ChavePIXPrincipal[0];
               n965ChavePIXPrincipal = H009L2_n965ChavePIXPrincipal[0];
               A964ChavePIXStatus = H009L2_A964ChavePIXStatus[0];
               n964ChavePIXStatus = H009L2_n964ChavePIXStatus[0];
               A963ChavePIXConteudo = H009L2_A963ChavePIXConteudo[0];
               n963ChavePIXConteudo = H009L2_n963ChavePIXConteudo[0];
               A962ChavePIXTipo = H009L2_A962ChavePIXTipo[0];
               n962ChavePIXTipo = H009L2_n962ChavePIXTipo[0];
               A961ChavePIXId = H009L2_A961ChavePIXId[0];
               A952ContaBancariaNumero = H009L2_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H009L2_n952ContaBancariaNumero[0];
               A939AgenciaNumero = H009L2_A939AgenciaNumero[0];
               n939AgenciaNumero = H009L2_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H009L2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009L2_n969AgenciaBancoNome[0];
               A960ChavePIXUpdatedByName = H009L2_A960ChavePIXUpdatedByName[0];
               n960ChavePIXUpdatedByName = H009L2_n960ChavePIXUpdatedByName[0];
               A958ChavePIXCreatedByName = H009L2_A958ChavePIXCreatedByName[0];
               n958ChavePIXCreatedByName = H009L2_n958ChavePIXCreatedByName[0];
               A938AgenciaId = H009L2_A938AgenciaId[0];
               n938AgenciaId = H009L2_n938AgenciaId[0];
               A952ContaBancariaNumero = H009L2_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H009L2_n952ContaBancariaNumero[0];
               A968AgenciaBancoId = H009L2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H009L2_n968AgenciaBancoId[0];
               A939AgenciaNumero = H009L2_A939AgenciaNumero[0];
               n939AgenciaNumero = H009L2_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H009L2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009L2_n969AgenciaBancoNome[0];
               /* Execute user event: Grid.Load */
               E279L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 137;
            WB9L0( ) ;
         }
         bGXsfl_137_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9L2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90BancoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CHAVEPIXID"+"_"+sGXsfl_137_idx, GetSecureSignedToken( sGXsfl_137_idx, context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTABANCARIAID"+"_"+sGXsfl_137_idx, GetSecureSignedToken( sGXsfl_137_idx, context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"), context));
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
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV120Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV93Chavepixwwds_1_filterfulltext ,
                                              AV94Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV96Chavepixwwds_4_chavepixtipo1 ,
                                              AV95Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV97Chavepixwwds_5_contabancarianumero1 ,
                                              AV98Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV99Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV100Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV101Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV103Chavepixwwds_11_chavepixtipo2 ,
                                              AV102Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV104Chavepixwwds_12_contabancarianumero2 ,
                                              AV105Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV106Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV107Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV108Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV110Chavepixwwds_18_chavepixtipo3 ,
                                              AV109Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV111Chavepixwwds_19_contabancarianumero3 ,
                                              AV112Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV113Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV115Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV114Chavepixwwds_22_tfagenciabanconome ,
                                              AV116Chavepixwwds_24_tfagencianumero ,
                                              AV117Chavepixwwds_25_tfagencianumero_to ,
                                              AV118Chavepixwwds_26_tfcontabancarianumero ,
                                              AV119Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV120Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV122Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV121Chavepixwwds_29_tfchavepixconteudo ,
                                              AV123Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV124Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV125Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV126Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV127Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV129Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV130Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV131Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV87ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV93Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext), "%", "");
         lV98Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV98Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV99Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV99Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV105Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV105Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV106Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV106Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV112Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV112Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV113Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV113Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV114Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV114Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV121Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV121Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV127Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV127Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV131Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV131Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor H009L3 */
         pr_default.execute(1, new Object[] {lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, lV93Chavepixwwds_1_filterfulltext, AV96Chavepixwwds_4_chavepixtipo1, AV97Chavepixwwds_5_contabancarianumero1, AV97Chavepixwwds_5_contabancarianumero1, AV97Chavepixwwds_5_contabancarianumero1, lV98Chavepixwwds_6_chavepixcreatedbyname1, lV98Chavepixwwds_6_chavepixcreatedbyname1, lV99Chavepixwwds_7_chavepixupdatedbyname1, lV99Chavepixwwds_7_chavepixupdatedbyname1, AV103Chavepixwwds_11_chavepixtipo2, AV104Chavepixwwds_12_contabancarianumero2, AV104Chavepixwwds_12_contabancarianumero2, AV104Chavepixwwds_12_contabancarianumero2, lV105Chavepixwwds_13_chavepixcreatedbyname2, lV105Chavepixwwds_13_chavepixcreatedbyname2, lV106Chavepixwwds_14_chavepixupdatedbyname2, lV106Chavepixwwds_14_chavepixupdatedbyname2, AV110Chavepixwwds_18_chavepixtipo3, AV111Chavepixwwds_19_contabancarianumero3, AV111Chavepixwwds_19_contabancarianumero3, AV111Chavepixwwds_19_contabancarianumero3, lV112Chavepixwwds_20_chavepixcreatedbyname3, lV112Chavepixwwds_20_chavepixcreatedbyname3, lV113Chavepixwwds_21_chavepixupdatedbyname3, lV113Chavepixwwds_21_chavepixupdatedbyname3, lV114Chavepixwwds_22_tfagenciabanconome, AV115Chavepixwwds_23_tfagenciabanconome_sel, AV116Chavepixwwds_24_tfagencianumero, AV117Chavepixwwds_25_tfagencianumero_to, AV118Chavepixwwds_26_tfcontabancarianumero, AV119Chavepixwwds_27_tfcontabancarianumero_to, lV121Chavepixwwds_29_tfchavepixconteudo, AV122Chavepixwwds_30_tfchavepixconteudo_sel, AV125Chavepixwwds_33_tfchavepixcreatedat, AV126Chavepixwwds_34_tfchavepixcreatedat_to, lV127Chavepixwwds_35_tfchavepixcreatedbyname, AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV129Chavepixwwds_37_tfchavepixupdatedat, AV130Chavepixwwds_38_tfchavepixupdatedat_to, lV131Chavepixwwds_39_tfchavepixupdatedbyname, AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV87ContaBancariaId});
         GRID_nRecordCount = H009L3_AGRID_nRecordCount[0];
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
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV92Pgmname = "ChavePIXWW";
         edtAgenciaBancoNome_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtChavePIXId_Enabled = 0;
         cmbChavePIXTipo.Enabled = 0;
         edtChavePIXConteudo_Enabled = 0;
         cmbChavePIXStatus.Enabled = 0;
         cmbChavePIXPrincipal.Enabled = 0;
         edtContaBancariaId_Enabled = 0;
         edtChavePIXCreatedAt_Enabled = 0;
         edtChavePIXCreatedBy_Enabled = 0;
         edtChavePIXCreatedByName_Enabled = 0;
         edtChavePIXUpdatedAt_Enabled = 0;
         edtChavePIXUpdatedBy_Enabled = 0;
         edtChavePIXUpdatedByName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E259L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV78DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_137 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_137"), ",", "."), 18, MidpointRounding.ToEven));
            AV80GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV81GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV82GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV62DDO_ChavePIXCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CHAVEPIXCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV62DDO_ChavePIXCreatedAtAuxDate", context.localUtil.Format(AV62DDO_ChavePIXCreatedAtAuxDate, "99/99/99"));
            AV63DDO_ChavePIXCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CHAVEPIXCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV63DDO_ChavePIXCreatedAtAuxDateTo", context.localUtil.Format(AV63DDO_ChavePIXCreatedAtAuxDateTo, "99/99/99"));
            AV71DDO_ChavePIXUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CHAVEPIXUPDATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV71DDO_ChavePIXUpdatedAtAuxDate", context.localUtil.Format(AV71DDO_ChavePIXUpdatedAtAuxDate, "99/99/99"));
            AV72DDO_ChavePIXUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CHAVEPIXUPDATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV72DDO_ChavePIXUpdatedAtAuxDateTo", context.localUtil.Format(AV72DDO_ChavePIXUpdatedAtAuxDateTo, "99/99/99"));
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
            cmbavChavepixtipo1.Name = cmbavChavepixtipo1_Internalname;
            cmbavChavepixtipo1.CurrentValue = cgiGet( cmbavChavepixtipo1_Internalname);
            AV18ChavePIXTipo1 = cgiGet( cmbavChavepixtipo1_Internalname);
            AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO1");
               GX_FocusControl = edtavContabancarianumero1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ContaBancariaNumero1 = 0;
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
            }
            else
            {
               AV19ContaBancariaNumero1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
            }
            AV20ChavePIXCreatedByName1 = StringUtil.Upper( cgiGet( edtavChavepixcreatedbyname1_Internalname));
            AssignAttri("", false, "AV20ChavePIXCreatedByName1", AV20ChavePIXCreatedByName1);
            AV21ChavePIXUpdatedByName1 = StringUtil.Upper( cgiGet( edtavChavepixupdatedbyname1_Internalname));
            AssignAttri("", false, "AV21ChavePIXUpdatedByName1", AV21ChavePIXUpdatedByName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            cmbavChavepixtipo2.Name = cmbavChavepixtipo2_Internalname;
            cmbavChavepixtipo2.CurrentValue = cgiGet( cmbavChavepixtipo2_Internalname);
            AV25ChavePIXTipo2 = cgiGet( cmbavChavepixtipo2_Internalname);
            AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO2");
               GX_FocusControl = edtavContabancarianumero2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26ContaBancariaNumero2 = 0;
               AssignAttri("", false, "AV26ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV26ContaBancariaNumero2), 18, 0));
            }
            else
            {
               AV26ContaBancariaNumero2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV26ContaBancariaNumero2), 18, 0));
            }
            AV27ChavePIXCreatedByName2 = StringUtil.Upper( cgiGet( edtavChavepixcreatedbyname2_Internalname));
            AssignAttri("", false, "AV27ChavePIXCreatedByName2", AV27ChavePIXCreatedByName2);
            AV28ChavePIXUpdatedByName2 = StringUtil.Upper( cgiGet( edtavChavepixupdatedbyname2_Internalname));
            AssignAttri("", false, "AV28ChavePIXUpdatedByName2", AV28ChavePIXUpdatedByName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV30DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            cmbavChavepixtipo3.Name = cmbavChavepixtipo3_Internalname;
            cmbavChavepixtipo3.CurrentValue = cgiGet( cmbavChavepixtipo3_Internalname);
            AV32ChavePIXTipo3 = cgiGet( cmbavChavepixtipo3_Internalname);
            AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO3");
               GX_FocusControl = edtavContabancarianumero3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33ContaBancariaNumero3 = 0;
               AssignAttri("", false, "AV33ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV33ContaBancariaNumero3), 18, 0));
            }
            else
            {
               AV33ContaBancariaNumero3 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV33ContaBancariaNumero3), 18, 0));
            }
            AV34ChavePIXCreatedByName3 = StringUtil.Upper( cgiGet( edtavChavepixcreatedbyname3_Internalname));
            AssignAttri("", false, "AV34ChavePIXCreatedByName3", AV34ChavePIXCreatedByName3);
            AV35ChavePIXUpdatedByName3 = StringUtil.Upper( cgiGet( edtavChavepixupdatedbyname3_Internalname));
            AssignAttri("", false, "AV35ChavePIXUpdatedByName3", AV35ChavePIXUpdatedByName3);
            AV64DDO_ChavePIXCreatedAtAuxDateText = cgiGet( edtavDdo_chavepixcreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV64DDO_ChavePIXCreatedAtAuxDateText", AV64DDO_ChavePIXCreatedAtAuxDateText);
            AV73DDO_ChavePIXUpdatedAtAuxDateText = cgiGet( edtavDdo_chavepixupdatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV73DDO_ChavePIXUpdatedAtAuxDateText", AV73DDO_ChavePIXUpdatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO1"), AV18ChavePIXTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME1"), AV20ChavePIXCreatedByName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME1"), AV21ChavePIXUpdatedByName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO2"), AV25ChavePIXTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV26ContaBancariaNumero2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME2"), AV27ChavePIXCreatedByName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME2"), AV28ChavePIXUpdatedByName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXTIPO3"), AV32ChavePIXTipo3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV33ContaBancariaNumero3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXCREATEDBYNAME3"), AV34ChavePIXCreatedByName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHAVEPIXUPDATEDBYNAME3"), AV35ChavePIXUpdatedByName3) != 0 )
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
         E259L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E259L2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCHAVEPIXUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_chavepixupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCHAVEPIXCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_chavepixcreatedatauxdatetext_Internalname});
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
         AV18ChavePIXTipo1 = "";
         AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
         AV16DynamicFiltersSelector1 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25ChavePIXTipo2 = "";
         AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
         AV23DynamicFiltersSelector2 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32ChavePIXTipo3 = "";
         AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
         AV30DynamicFiltersSelector3 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
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
         Form.Caption = " Chave PIX";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV78DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV78DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E269L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV29DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV80GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV80GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV80GridCurrentPage), 10, 0));
         AV81GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV81GridPageCount", StringUtil.LTrimStr( (decimal)(AV81GridPageCount), 10, 0));
         GXt_char2 = AV82GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV92Pgmname, out  GXt_char2) ;
         AV82GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV82GridAppliedFilters", AV82GridAppliedFilters);
         cmbChavePIXStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbChavePIXStatus_Internalname, "Columnheaderclass", cmbChavePIXStatus_Columnheaderclass, !bGXsfl_137_Refreshing);
         cmbChavePIXPrincipal_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Columnheaderclass", cmbChavePIXPrincipal_Columnheaderclass, !bGXsfl_137_Refreshing);
         AV93Chavepixwwds_1_filterfulltext = AV15FilterFullText;
         AV94Chavepixwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV95Chavepixwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV96Chavepixwwds_4_chavepixtipo1 = AV18ChavePIXTipo1;
         AV97Chavepixwwds_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = AV20ChavePIXCreatedByName1;
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = AV21ChavePIXUpdatedByName1;
         AV100Chavepixwwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Chavepixwwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Chavepixwwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Chavepixwwds_11_chavepixtipo2 = AV25ChavePIXTipo2;
         AV104Chavepixwwds_12_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = AV27ChavePIXCreatedByName2;
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = AV28ChavePIXUpdatedByName2;
         AV107Chavepixwwds_15_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV108Chavepixwwds_16_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV109Chavepixwwds_17_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV110Chavepixwwds_18_chavepixtipo3 = AV32ChavePIXTipo3;
         AV111Chavepixwwds_19_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = AV34ChavePIXCreatedByName3;
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = AV35ChavePIXUpdatedByName3;
         AV114Chavepixwwds_22_tfagenciabanconome = AV58TFAgenciaBancoNome;
         AV115Chavepixwwds_23_tfagenciabanconome_sel = AV59TFAgenciaBancoNome_Sel;
         AV116Chavepixwwds_24_tfagencianumero = AV56TFAgenciaNumero;
         AV117Chavepixwwds_25_tfagencianumero_to = AV57TFAgenciaNumero_To;
         AV118Chavepixwwds_26_tfcontabancarianumero = AV54TFContaBancariaNumero;
         AV119Chavepixwwds_27_tfcontabancarianumero_to = AV55TFContaBancariaNumero_To;
         AV120Chavepixwwds_28_tfchavepixtipo_sels = AV47TFChavePIXTipo_Sels;
         AV121Chavepixwwds_29_tfchavepixconteudo = AV48TFChavePIXConteudo;
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = AV49TFChavePIXConteudo_Sel;
         AV123Chavepixwwds_31_tfchavepixstatus_sel = AV50TFChavePIXStatus_Sel;
         AV124Chavepixwwds_32_tfchavepixprincipal_sel = AV51TFChavePIXPrincipal_Sel;
         AV125Chavepixwwds_33_tfchavepixcreatedat = AV60TFChavePIXCreatedAt;
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = AV61TFChavePIXCreatedAt_To;
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = AV67TFChavePIXCreatedByName;
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV68TFChavePIXCreatedByName_Sel;
         AV129Chavepixwwds_37_tfchavepixupdatedat = AV69TFChavePIXUpdatedAt;
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = AV70TFChavePIXUpdatedAt_To;
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = AV76TFChavePIXUpdatedByName;
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV77TFChavePIXUpdatedByName_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129L2( )
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
            AV79PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV79PageToGo) ;
         }
      }

      protected void E139L2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149L2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaBancoNome") == 0 )
            {
               AV58TFAgenciaBancoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFAgenciaBancoNome", AV58TFAgenciaBancoNome);
               AV59TFAgenciaBancoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFAgenciaBancoNome_Sel", AV59TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaNumero") == 0 )
            {
               AV56TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV56TFAgenciaNumero), 9, 0));
               AV57TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV57TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaNumero") == 0 )
            {
               AV54TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV54TFContaBancariaNumero), 18, 0));
               AV55TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV55TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV55TFContaBancariaNumero_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXTipo") == 0 )
            {
               AV46TFChavePIXTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFChavePIXTipo_SelsJson", AV46TFChavePIXTipo_SelsJson);
               AV47TFChavePIXTipo_Sels.FromJSonString(AV46TFChavePIXTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXConteudo") == 0 )
            {
               AV48TFChavePIXConteudo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFChavePIXConteudo", AV48TFChavePIXConteudo);
               AV49TFChavePIXConteudo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFChavePIXConteudo_Sel", AV49TFChavePIXConteudo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXStatus") == 0 )
            {
               AV50TFChavePIXStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFChavePIXStatus_Sel", StringUtil.Str( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXPrincipal") == 0 )
            {
               AV51TFChavePIXPrincipal_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFChavePIXPrincipal_Sel", StringUtil.Str( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXCreatedAt") == 0 )
            {
               AV60TFChavePIXCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV60TFChavePIXCreatedAt", context.localUtil.TToC( AV60TFChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV61TFChavePIXCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV61TFChavePIXCreatedAt_To", context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV61TFChavePIXCreatedAt_To) )
               {
                  AV61TFChavePIXCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV61TFChavePIXCreatedAt_To)), (short)(DateTimeUtil.Month( AV61TFChavePIXCreatedAt_To)), (short)(DateTimeUtil.Day( AV61TFChavePIXCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV61TFChavePIXCreatedAt_To", context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXCreatedByName") == 0 )
            {
               AV67TFChavePIXCreatedByName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFChavePIXCreatedByName", AV67TFChavePIXCreatedByName);
               AV68TFChavePIXCreatedByName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFChavePIXCreatedByName_Sel", AV68TFChavePIXCreatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXUpdatedAt") == 0 )
            {
               AV69TFChavePIXUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV69TFChavePIXUpdatedAt", context.localUtil.TToC( AV69TFChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV70TFChavePIXUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV70TFChavePIXUpdatedAt_To", context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV70TFChavePIXUpdatedAt_To) )
               {
                  AV70TFChavePIXUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV70TFChavePIXUpdatedAt_To)), (short)(DateTimeUtil.Month( AV70TFChavePIXUpdatedAt_To)), (short)(DateTimeUtil.Day( AV70TFChavePIXUpdatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV70TFChavePIXUpdatedAt_To", context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ChavePIXUpdatedByName") == 0 )
            {
               AV76TFChavePIXUpdatedByName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV76TFChavePIXUpdatedByName", AV76TFChavePIXUpdatedByName);
               AV77TFChavePIXUpdatedByName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV77TFChavePIXUpdatedByName_Sel", AV77TFChavePIXUpdatedByName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFChavePIXTipo_Sels", AV47TFChavePIXTipo_Sels);
      }

      private void E279L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         if ( ! A965ChavePIXPrincipal )
         {
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Tornar chave principal", "fas fa-star", "", "", "", "", "", "", ""), 0);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A938AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV90BancoId,9,0));
         edtAgenciaNumero_Link = formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A951ContaBancariaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV91AgenciaId,9,0));
         edtContaBancariaNumero_Link = formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A957ChavePIXCreatedBy,4,0));
         edtChavePIXCreatedByName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A959ChavePIXUpdatedBy,4,0));
         edtChavePIXUpdatedByName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "true") == 0 )
         {
            cmbChavePIXStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "false") == 0 )
         {
            cmbChavePIXStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else
         {
            cmbChavePIXStatus_Columnclass = "WWColumn";
         }
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "true") == 0 )
         {
            cmbChavePIXPrincipal_Columnclass = "WWColumn WWColumnInfo WWColumnInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "false") == 0 )
         {
            cmbChavePIXPrincipal_Columnclass = "WWColumn WWColumnGray WWColumnGraySingleCell";
         }
         else
         {
            cmbChavePIXPrincipal_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 137;
         }
         sendrow_1372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_137_Refreshing )
         {
            DoAjaxLoad(137, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0));
      }

      protected void E209L2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E159L2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
         AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", cmbavChavepixtipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
         AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", cmbavChavepixtipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
         AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", cmbavChavepixtipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E219L2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E229L2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E169L2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
         AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", cmbavChavepixtipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
         AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", cmbavChavepixtipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
         AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", cmbavChavepixtipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E239L2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179L2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ChavePIXTipo1, AV19ContaBancariaNumero1, AV20ChavePIXCreatedByName1, AV21ChavePIXUpdatedByName1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ChavePIXTipo2, AV26ContaBancariaNumero2, AV27ChavePIXCreatedByName2, AV28ChavePIXUpdatedByName2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ChavePIXTipo3, AV33ContaBancariaNumero3, AV34ChavePIXCreatedByName3, AV35ChavePIXUpdatedByName3, AV87ContaBancariaId, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV92Pgmname, AV58TFAgenciaBancoNome, AV59TFAgenciaBancoNome_Sel, AV56TFAgenciaNumero, AV57TFAgenciaNumero_To, AV54TFContaBancariaNumero, AV55TFContaBancariaNumero_To, AV47TFChavePIXTipo_Sels, AV48TFChavePIXConteudo, AV49TFChavePIXConteudo_Sel, AV50TFChavePIXStatus_Sel, AV51TFChavePIXPrincipal_Sel, AV60TFChavePIXCreatedAt, AV61TFChavePIXCreatedAt_To, AV67TFChavePIXCreatedByName, AV68TFChavePIXCreatedByName_Sel, AV69TFChavePIXUpdatedAt, AV70TFChavePIXUpdatedAt_To, AV76TFChavePIXUpdatedByName, AV77TFChavePIXUpdatedByName_Sel, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV90BancoId, AV91AgenciaId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
         AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", cmbavChavepixtipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
         AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", cmbavChavepixtipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
         AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", cmbavChavepixtipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E249L2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119L2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S232 ();
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
            S192 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ChavePIXWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV92Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ChavePIXWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ChavePIXWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV10GridState.FromXml(AV42ManageFiltersXml, null, "", "");
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
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S222 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFChavePIXTipo_Sels", AV47TFChavePIXTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
         AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", cmbavChavepixtipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
         AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", cmbavChavepixtipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
         AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", cmbavChavepixtipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E289L2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV88GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV88GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO TORNARCHAVEPRINCIPAL' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV88GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV88GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E189L2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "chavepix"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV87ContaBancariaId,9,0));
         CallWebObject(formatLink("chavepix") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E199L2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new chavepixwwexport(context ).execute( out  AV38ExcelFilename, out  AV39ErrorMessage) ;
         if ( StringUtil.StrCmp(AV38ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV38ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV39ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! (0==AV87ContaBancariaId) ) )
         {
            bttBtn_cancel_Visible = 0;
            AssignProp("", false, bttBtn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_cancel_Visible), 5, 0), true);
         }
         if ( ! ( ! (0==AV87ContaBancariaId) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavChavepixtipo1.Visible = 0;
         AssignProp("", false, cmbavChavepixtipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo1.Visible), 5, 0), true);
         edtavContabancarianumero1_Visible = 0;
         AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
         edtavChavepixcreatedbyname1_Visible = 0;
         AssignProp("", false, edtavChavepixcreatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname1_Visible), 5, 0), true);
         edtavChavepixupdatedbyname1_Visible = 0;
         AssignProp("", false, edtavChavepixupdatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXTIPO") == 0 )
         {
            cmbavChavepixtipo1.Visible = 1;
            AssignProp("", false, cmbavChavepixtipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero1_Visible = 1;
            AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 )
         {
            edtavChavepixcreatedbyname1_Visible = 1;
            AssignProp("", false, edtavChavepixcreatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 )
         {
            edtavChavepixupdatedbyname1_Visible = 1;
            AssignProp("", false, edtavChavepixupdatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavChavepixtipo2.Visible = 0;
         AssignProp("", false, cmbavChavepixtipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo2.Visible), 5, 0), true);
         edtavContabancarianumero2_Visible = 0;
         AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
         edtavChavepixcreatedbyname2_Visible = 0;
         AssignProp("", false, edtavChavepixcreatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname2_Visible), 5, 0), true);
         edtavChavepixupdatedbyname2_Visible = 0;
         AssignProp("", false, edtavChavepixupdatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXTIPO") == 0 )
         {
            cmbavChavepixtipo2.Visible = 1;
            AssignProp("", false, cmbavChavepixtipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero2_Visible = 1;
            AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 )
         {
            edtavChavepixcreatedbyname2_Visible = 1;
            AssignProp("", false, edtavChavepixcreatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 )
         {
            edtavChavepixupdatedbyname2_Visible = 1;
            AssignProp("", false, edtavChavepixupdatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavChavepixtipo3.Visible = 0;
         AssignProp("", false, cmbavChavepixtipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo3.Visible), 5, 0), true);
         edtavContabancarianumero3_Visible = 0;
         AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
         edtavChavepixcreatedbyname3_Visible = 0;
         AssignProp("", false, edtavChavepixcreatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname3_Visible), 5, 0), true);
         edtavChavepixupdatedbyname3_Visible = 0;
         AssignProp("", false, edtavChavepixupdatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXTIPO") == 0 )
         {
            cmbavChavepixtipo3.Visible = 1;
            AssignProp("", false, cmbavChavepixtipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavChavepixtipo3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero3_Visible = 1;
            AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 )
         {
            edtavChavepixcreatedbyname3_Visible = 1;
            AssignProp("", false, edtavChavepixcreatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixcreatedbyname3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 )
         {
            edtavChavepixupdatedbyname3_Visible = 1;
            AssignProp("", false, edtavChavepixupdatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavChavepixupdatedbyname3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV25ChavePIXTipo2 = "";
         AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         AV30DynamicFiltersSelector3 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         AV32ChavePIXTipo3 = "";
         AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ChavePIXWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV58TFAgenciaBancoNome = "";
         AssignAttri("", false, "AV58TFAgenciaBancoNome", AV58TFAgenciaBancoNome);
         AV59TFAgenciaBancoNome_Sel = "";
         AssignAttri("", false, "AV59TFAgenciaBancoNome_Sel", AV59TFAgenciaBancoNome_Sel);
         AV56TFAgenciaNumero = 0;
         AssignAttri("", false, "AV56TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV56TFAgenciaNumero), 9, 0));
         AV57TFAgenciaNumero_To = 0;
         AssignAttri("", false, "AV57TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV57TFAgenciaNumero_To), 9, 0));
         AV54TFContaBancariaNumero = 0;
         AssignAttri("", false, "AV54TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV54TFContaBancariaNumero), 18, 0));
         AV55TFContaBancariaNumero_To = 0;
         AssignAttri("", false, "AV55TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV55TFContaBancariaNumero_To), 18, 0));
         AV47TFChavePIXTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48TFChavePIXConteudo = "";
         AssignAttri("", false, "AV48TFChavePIXConteudo", AV48TFChavePIXConteudo);
         AV49TFChavePIXConteudo_Sel = "";
         AssignAttri("", false, "AV49TFChavePIXConteudo_Sel", AV49TFChavePIXConteudo_Sel);
         AV50TFChavePIXStatus_Sel = 0;
         AssignAttri("", false, "AV50TFChavePIXStatus_Sel", StringUtil.Str( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0));
         AV51TFChavePIXPrincipal_Sel = 0;
         AssignAttri("", false, "AV51TFChavePIXPrincipal_Sel", StringUtil.Str( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0));
         AV60TFChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV60TFChavePIXCreatedAt", context.localUtil.TToC( AV60TFChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV61TFChavePIXCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV61TFChavePIXCreatedAt_To", context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV67TFChavePIXCreatedByName = "";
         AssignAttri("", false, "AV67TFChavePIXCreatedByName", AV67TFChavePIXCreatedByName);
         AV68TFChavePIXCreatedByName_Sel = "";
         AssignAttri("", false, "AV68TFChavePIXCreatedByName_Sel", AV68TFChavePIXCreatedByName_Sel);
         AV69TFChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV69TFChavePIXUpdatedAt", context.localUtil.TToC( AV69TFChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV70TFChavePIXUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV70TFChavePIXUpdatedAt_To", context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV76TFChavePIXUpdatedByName = "";
         AssignAttri("", false, "AV76TFChavePIXUpdatedByName", AV76TFChavePIXUpdatedByName);
         AV77TFChavePIXUpdatedByName_Sel = "";
         AssignAttri("", false, "AV77TFChavePIXUpdatedByName_Sel", AV77TFChavePIXUpdatedByName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "CHAVEPIXTIPO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV18ChavePIXTipo1 = "";
         AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S252( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "chavepix"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A961ChavePIXId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV87ContaBancariaId,9,0));
         CallWebObject(formatLink("chavepix") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO TORNARCHAVEPRINCIPAL' Routine */
         returnInSub = false;
         new prtornachavepixprincipal(context ).execute(  A951ContaBancariaId,  A961ChavePIXId, out  AV89SdErro) ;
         if ( (0==AV89SdErro.gxTpr_Internalcode) )
         {
            context.CommitDataStores("chavepixww",pr_default);
            GXt_char2 = "Chave principal alterada";
            new message(context ).gxep_sucesso( ref  GXt_char2) ;
            context.DoAjaxRefresh();
         }
         else
         {
            context.RollbackDataStores("chavepixww",pr_default);
            GXt_char4 = AV89SdErro.gxTpr_Msg;
            new message(context ).gxep_erro( ref  GXt_char4) ;
            AV89SdErro.gxTpr_Msg = GXt_char4;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV92Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV92Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV40Session.Get(AV92Pgmname+"GridState"), null, "", "");
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
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
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

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV133GXV1 = 1;
         while ( AV133GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV133GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV58TFAgenciaBancoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFAgenciaBancoNome", AV58TFAgenciaBancoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV59TFAgenciaBancoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFAgenciaBancoNome_Sel", AV59TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV56TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV56TFAgenciaNumero), 9, 0));
               AV57TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV57TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV54TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV54TFContaBancariaNumero), 18, 0));
               AV55TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV55TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV55TFContaBancariaNumero_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXTIPO_SEL") == 0 )
            {
               AV46TFChavePIXTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFChavePIXTipo_SelsJson", AV46TFChavePIXTipo_SelsJson);
               AV47TFChavePIXTipo_Sels.FromJSonString(AV46TFChavePIXTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO") == 0 )
            {
               AV48TFChavePIXConteudo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFChavePIXConteudo", AV48TFChavePIXConteudo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO_SEL") == 0 )
            {
               AV49TFChavePIXConteudo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFChavePIXConteudo_Sel", AV49TFChavePIXConteudo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXSTATUS_SEL") == 0 )
            {
               AV50TFChavePIXStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFChavePIXStatus_Sel", StringUtil.Str( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXPRINCIPAL_SEL") == 0 )
            {
               AV51TFChavePIXPrincipal_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFChavePIXPrincipal_Sel", StringUtil.Str( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDAT") == 0 )
            {
               AV60TFChavePIXCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV60TFChavePIXCreatedAt", context.localUtil.TToC( AV60TFChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV61TFChavePIXCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV61TFChavePIXCreatedAt_To", context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV62DDO_ChavePIXCreatedAtAuxDate = DateTimeUtil.ResetTime(AV60TFChavePIXCreatedAt);
               AssignAttri("", false, "AV62DDO_ChavePIXCreatedAtAuxDate", context.localUtil.Format(AV62DDO_ChavePIXCreatedAtAuxDate, "99/99/99"));
               AV63DDO_ChavePIXCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV61TFChavePIXCreatedAt_To);
               AssignAttri("", false, "AV63DDO_ChavePIXCreatedAtAuxDateTo", context.localUtil.Format(AV63DDO_ChavePIXCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV67TFChavePIXCreatedByName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFChavePIXCreatedByName", AV67TFChavePIXCreatedByName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME_SEL") == 0 )
            {
               AV68TFChavePIXCreatedByName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFChavePIXCreatedByName_Sel", AV68TFChavePIXCreatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDAT") == 0 )
            {
               AV69TFChavePIXUpdatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV69TFChavePIXUpdatedAt", context.localUtil.TToC( AV69TFChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV70TFChavePIXUpdatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV70TFChavePIXUpdatedAt_To", context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV71DDO_ChavePIXUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV69TFChavePIXUpdatedAt);
               AssignAttri("", false, "AV71DDO_ChavePIXUpdatedAtAuxDate", context.localUtil.Format(AV71DDO_ChavePIXUpdatedAtAuxDate, "99/99/99"));
               AV72DDO_ChavePIXUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV70TFChavePIXUpdatedAt_To);
               AssignAttri("", false, "AV72DDO_ChavePIXUpdatedAtAuxDateTo", context.localUtil.Format(AV72DDO_ChavePIXUpdatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV76TFChavePIXUpdatedByName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFChavePIXUpdatedByName", AV76TFChavePIXUpdatedByName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME_SEL") == 0 )
            {
               AV77TFChavePIXUpdatedByName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFChavePIXUpdatedByName_Sel", AV77TFChavePIXUpdatedByName_Sel);
            }
            AV133GXV1 = (int)(AV133GXV1+1);
         }
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAgenciaBancoNome_Sel)),  AV59TFAgenciaBancoNome_Sel, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFChavePIXTipo_Sels.Count==0),  AV46TFChavePIXTipo_SelsJson, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFChavePIXConteudo_Sel)),  AV49TFChavePIXConteudo_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFChavePIXCreatedByName_Sel)),  AV68TFChavePIXCreatedByName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFChavePIXUpdatedByName_Sel)),  AV77TFChavePIXUpdatedByName_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|||"+GXt_char2+"|"+GXt_char5+"|"+((0==AV50TFChavePIXStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0))+"|"+((0==AV51TFChavePIXPrincipal_Sel) ? "" : StringUtil.Str( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0))+"||"+GXt_char6+"||"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAgenciaBancoNome)),  AV58TFAgenciaBancoNome, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFChavePIXConteudo)),  AV48TFChavePIXConteudo, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFChavePIXCreatedByName)),  AV67TFChavePIXCreatedByName, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFChavePIXUpdatedByName)),  AV76TFChavePIXUpdatedByName, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+((0==AV56TFAgenciaNumero) ? "" : StringUtil.Str( (decimal)(AV56TFAgenciaNumero), 9, 0))+"|"+((0==AV54TFContaBancariaNumero) ? "" : StringUtil.Str( (decimal)(AV54TFContaBancariaNumero), 18, 0))+"||"+GXt_char6+"|||"+((DateTime.MinValue==AV60TFChavePIXCreatedAt) ? "" : context.localUtil.DToC( AV62DDO_ChavePIXCreatedAtAuxDate, 4, "/"))+"|"+GXt_char5+"|"+((DateTime.MinValue==AV69TFChavePIXUpdatedAt) ? "" : context.localUtil.DToC( AV71DDO_ChavePIXUpdatedAtAuxDate, 4, "/"))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV57TFAgenciaNumero_To) ? "" : StringUtil.Str( (decimal)(AV57TFAgenciaNumero_To), 9, 0))+"|"+((0==AV55TFContaBancariaNumero_To) ? "" : StringUtil.Str( (decimal)(AV55TFContaBancariaNumero_To), 18, 0))+"|||||"+((DateTime.MinValue==AV61TFChavePIXCreatedAt_To) ? "" : context.localUtil.DToC( AV63DDO_ChavePIXCreatedAtAuxDateTo, 4, "/"))+"||"+((DateTime.MinValue==AV70TFChavePIXUpdatedAt_To) ? "" : context.localUtil.DToC( AV72DDO_ChavePIXUpdatedAtAuxDateTo, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXTIPO") == 0 )
            {
               AV18ChavePIXTipo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20ChavePIXCreatedByName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ChavePIXCreatedByName1", AV20ChavePIXCreatedByName1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV21ChavePIXUpdatedByName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ChavePIXUpdatedByName1", AV21ChavePIXUpdatedByName1);
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
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXTIPO") == 0 )
               {
                  AV25ChavePIXTipo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV26ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV26ContaBancariaNumero2), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV27ChavePIXCreatedByName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27ChavePIXCreatedByName2", AV27ChavePIXCreatedByName2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV28ChavePIXUpdatedByName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28ChavePIXUpdatedByName2", AV28ChavePIXUpdatedByName2);
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
                  AV29DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXTIPO") == 0 )
                  {
                     AV32ChavePIXTipo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV33ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV33ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV33ContaBancariaNumero3), 18, 0));
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV34ChavePIXCreatedByName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34ChavePIXCreatedByName3", AV34ChavePIXCreatedByName3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV35ChavePIXUpdatedByName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35ChavePIXUpdatedByName3", AV35ChavePIXUpdatedByName3);
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
         if ( AV36DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV40Session.Get(AV92Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAGENCIABANCONOME",  "Banco",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAgenciaBancoNome)),  0,  AV58TFAgenciaBancoNome,  AV58TFAgenciaBancoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAgenciaBancoNome_Sel)),  AV59TFAgenciaBancoNome_Sel,  AV59TFAgenciaBancoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAGENCIANUMERO",  "Agência",  !((0==AV56TFAgenciaNumero)&&(0==AV57TFAgenciaNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFAgenciaNumero), 9, 0)),  ((0==AV56TFAgenciaNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV56TFAgenciaNumero), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV57TFAgenciaNumero_To), 9, 0)),  ((0==AV57TFAgenciaNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV57TFAgenciaNumero_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONTABANCARIANUMERO",  "Conta",  !((0==AV54TFContaBancariaNumero)&&(0==AV55TFContaBancariaNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV54TFContaBancariaNumero), 18, 0)),  ((0==AV54TFContaBancariaNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV54TFContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV55TFContaBancariaNumero_To), 18, 0)),  ((0==AV55TFContaBancariaNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV55TFContaBancariaNumero_To), "ZZZZZZZZZZZZZZZZZ9")))) ;
         AV86AuxText = ((AV47TFChavePIXTipo_Sels.Count==1) ? "["+((string)AV47TFChavePIXTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCHAVEPIXTIPO_SEL",  "Tipo",  !(AV47TFChavePIXTipo_Sels.Count==0),  0,  AV47TFChavePIXTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV86AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV86AuxText, "[CPF]", "CPF"), "[CNPJ]", "CNPJ"), "[Telefone]", "Telefone"), "[Email]", "E-mail"), "[ChaveAleatoria]", "Chave aleatória")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCHAVEPIXCONTEUDO",  "Chave",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFChavePIXConteudo)),  0,  AV48TFChavePIXConteudo,  AV48TFChavePIXConteudo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFChavePIXConteudo_Sel)),  AV49TFChavePIXConteudo_Sel,  AV49TFChavePIXConteudo_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCHAVEPIXSTATUS_SEL",  "Status",  !(0==AV50TFChavePIXStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFChavePIXStatus_Sel), 1, 0)),  ((AV50TFChavePIXStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCHAVEPIXPRINCIPAL_SEL",  "Principal",  !(0==AV51TFChavePIXPrincipal_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFChavePIXPrincipal_Sel), 1, 0)),  ((AV51TFChavePIXPrincipal_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCHAVEPIXCREATEDAT",  "Criado em",  !((DateTime.MinValue==AV60TFChavePIXCreatedAt)&&(DateTime.MinValue==AV61TFChavePIXCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV60TFChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV60TFChavePIXCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV60TFChavePIXCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV61TFChavePIXCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV61TFChavePIXCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFChavePIXCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCHAVEPIXCREATEDBYNAME",  "Criado por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFChavePIXCreatedByName)),  0,  AV67TFChavePIXCreatedByName,  AV67TFChavePIXCreatedByName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFChavePIXCreatedByName_Sel)),  AV68TFChavePIXCreatedByName_Sel,  AV68TFChavePIXCreatedByName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCHAVEPIXUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV69TFChavePIXUpdatedAt)&&(DateTime.MinValue==AV70TFChavePIXUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV69TFChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV69TFChavePIXUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV69TFChavePIXUpdatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV70TFChavePIXUpdatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV70TFChavePIXUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV70TFChavePIXUpdatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCHAVEPIXUPDATEDBYNAME",  "Atualizado por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFChavePIXUpdatedByName)),  0,  AV76TFChavePIXUpdatedByName,  AV76TFChavePIXUpdatedByName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFChavePIXUpdatedByName_Sel)),  AV77TFChavePIXUpdatedByName_Sel,  AV77TFChavePIXUpdatedByName_Sel) ;
         if ( ! (0==AV87ContaBancariaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CONTABANCARIAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV87ContaBancariaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV37DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ChavePIXTipo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV18ChavePIXTipo1,  StringUtil.Trim( gxdomaindmpixtipo.getDescription(context,AV18ChavePIXTipo1)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV19ContaBancariaNumero1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19ContaBancariaNumero1), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ChavePIXCreatedByName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV17DynamicFiltersOperator1,  AV20ChavePIXCreatedByName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20ChavePIXCreatedByName1, "Contém"+" "+AV20ChavePIXCreatedByName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ChavePIXUpdatedByName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV17DynamicFiltersOperator1,  AV21ChavePIXUpdatedByName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21ChavePIXUpdatedByName1, "Contém"+" "+AV21ChavePIXUpdatedByName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ChavePIXTipo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV25ChavePIXTipo2,  StringUtil.Trim( gxdomaindmpixtipo.getDescription(context,AV25ChavePIXTipo2)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV26ContaBancariaNumero2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV24DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26ContaBancariaNumero2), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ChavePIXCreatedByName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV24DynamicFiltersOperator2,  AV27ChavePIXCreatedByName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV27ChavePIXCreatedByName2, "Contém"+" "+AV27ChavePIXCreatedByName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ChavePIXUpdatedByName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV24DynamicFiltersOperator2,  AV28ChavePIXUpdatedByName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV28ChavePIXUpdatedByName2, "Contém"+" "+AV28ChavePIXUpdatedByName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV29DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV30DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ChavePIXTipo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV32ChavePIXTipo3,  StringUtil.Trim( gxdomaindmpixtipo.getDescription(context,AV32ChavePIXTipo3)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV33ContaBancariaNumero3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV31DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33ContaBancariaNumero3), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ChavePIXCreatedByName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV31DynamicFiltersOperator3,  AV34ChavePIXCreatedByName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV34ChavePIXCreatedByName3, "Contém"+" "+AV34ChavePIXCreatedByName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ChavePIXUpdatedByName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "por",  AV31DynamicFiltersOperator3,  AV35ChavePIXUpdatedByName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV35ChavePIXUpdatedByName3, "Contém"+" "+AV35ChavePIXUpdatedByName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV92Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ChavePIX";
         AV40Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_110_9L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixtipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavChavepixtipo3_Internalname, "Chave PIXTipo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavChavepixtipo3, cmbavChavepixtipo3_Internalname, StringUtil.RTrim( AV32ChavePIXTipo3), 1, cmbavChavepixtipo3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavChavepixtipo3.Visible, cmbavChavepixtipo3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavChavepixtipo3.CurrentValue = StringUtil.RTrim( AV32ChavePIXTipo3);
            AssignProp("", false, cmbavChavepixtipo3_Internalname, "Values", (string)(cmbavChavepixtipo3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero3_Internalname, "Conta Bancaria Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ContaBancariaNumero3), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero3_Visible, edtavContabancarianumero3_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixcreatedbyname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixcreatedbyname3_Internalname, "Chave PIXCreated By Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixcreatedbyname3_Internalname, AV34ChavePIXCreatedByName3, StringUtil.RTrim( context.localUtil.Format( AV34ChavePIXCreatedByName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixcreatedbyname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixcreatedbyname3_Visible, edtavChavepixcreatedbyname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixupdatedbyname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixupdatedbyname3_Internalname, "Chave PIXUpdated By Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixupdatedbyname3_Internalname, AV35ChavePIXUpdatedByName3, StringUtil.RTrim( context.localUtil.Format( AV35ChavePIXUpdatedByName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixupdatedbyname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixupdatedbyname3_Visible, edtavChavepixupdatedbyname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ChavePIXWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_110_9L2e( true) ;
         }
         else
         {
            wb_table3_110_9L2e( false) ;
         }
      }

      protected void wb_table2_79_9L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixtipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavChavepixtipo2_Internalname, "Chave PIXTipo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavChavepixtipo2, cmbavChavepixtipo2_Internalname, StringUtil.RTrim( AV25ChavePIXTipo2), 1, cmbavChavepixtipo2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavChavepixtipo2.Visible, cmbavChavepixtipo2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavChavepixtipo2.CurrentValue = StringUtil.RTrim( AV25ChavePIXTipo2);
            AssignProp("", false, cmbavChavepixtipo2_Internalname, "Values", (string)(cmbavChavepixtipo2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero2_Internalname, "Conta Bancaria Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ContaBancariaNumero2), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero2_Visible, edtavContabancarianumero2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixcreatedbyname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixcreatedbyname2_Internalname, "Chave PIXCreated By Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixcreatedbyname2_Internalname, AV27ChavePIXCreatedByName2, StringUtil.RTrim( context.localUtil.Format( AV27ChavePIXCreatedByName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixcreatedbyname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixcreatedbyname2_Visible, edtavChavepixcreatedbyname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixupdatedbyname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixupdatedbyname2_Internalname, "Chave PIXUpdated By Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixupdatedbyname2_Internalname, AV28ChavePIXUpdatedByName2, StringUtil.RTrim( context.localUtil.Format( AV28ChavePIXUpdatedByName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixupdatedbyname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixupdatedbyname2_Visible, edtavChavepixupdatedbyname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ChavePIXWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ChavePIXWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_79_9L2e( true) ;
         }
         else
         {
            wb_table2_79_9L2e( false) ;
         }
      }

      protected void wb_table1_48_9L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixtipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavChavepixtipo1_Internalname, "Chave PIXTipo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavChavepixtipo1, cmbavChavepixtipo1_Internalname, StringUtil.RTrim( AV18ChavePIXTipo1), 1, cmbavChavepixtipo1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavChavepixtipo1.Visible, cmbavChavepixtipo1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_ChavePIXWW.htm");
            cmbavChavepixtipo1.CurrentValue = StringUtil.RTrim( AV18ChavePIXTipo1);
            AssignProp("", false, cmbavChavepixtipo1_Internalname, "Values", (string)(cmbavChavepixtipo1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero1_Internalname, "Conta Bancaria Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero1_Visible, edtavContabancarianumero1_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixcreatedbyname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixcreatedbyname1_Internalname, "Chave PIXCreated By Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixcreatedbyname1_Internalname, AV20ChavePIXCreatedByName1, StringUtil.RTrim( context.localUtil.Format( AV20ChavePIXCreatedByName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixcreatedbyname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixcreatedbyname1_Visible, edtavChavepixcreatedbyname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_chavepixupdatedbyname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChavepixupdatedbyname1_Internalname, "Chave PIXUpdated By Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChavepixupdatedbyname1_Internalname, AV21ChavePIXUpdatedByName1, StringUtil.RTrim( context.localUtil.Format( AV21ChavePIXUpdatedByName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChavepixupdatedbyname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavChavepixupdatedbyname1_Visible, edtavChavepixupdatedbyname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIXWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ChavePIXWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ChavePIXWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_9L2e( true) ;
         }
         else
         {
            wb_table1_48_9L2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV87ContaBancariaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV87ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV87ContaBancariaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87ContaBancariaId), "ZZZZZZZZ9"), context));
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
         PA9L2( ) ;
         WS9L2( ) ;
         WE9L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019285325", true, true);
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
         context.AddJavascriptSource("chavepixww.js", "?202561019285326", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1372( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_137_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_137_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_137_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_137_idx;
         edtChavePIXId_Internalname = "CHAVEPIXID_"+sGXsfl_137_idx;
         cmbChavePIXTipo_Internalname = "CHAVEPIXTIPO_"+sGXsfl_137_idx;
         edtChavePIXConteudo_Internalname = "CHAVEPIXCONTEUDO_"+sGXsfl_137_idx;
         cmbChavePIXStatus_Internalname = "CHAVEPIXSTATUS_"+sGXsfl_137_idx;
         cmbChavePIXPrincipal_Internalname = "CHAVEPIXPRINCIPAL_"+sGXsfl_137_idx;
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_137_idx;
         edtChavePIXCreatedAt_Internalname = "CHAVEPIXCREATEDAT_"+sGXsfl_137_idx;
         edtChavePIXCreatedBy_Internalname = "CHAVEPIXCREATEDBY_"+sGXsfl_137_idx;
         edtChavePIXCreatedByName_Internalname = "CHAVEPIXCREATEDBYNAME_"+sGXsfl_137_idx;
         edtChavePIXUpdatedAt_Internalname = "CHAVEPIXUPDATEDAT_"+sGXsfl_137_idx;
         edtChavePIXUpdatedBy_Internalname = "CHAVEPIXUPDATEDBY_"+sGXsfl_137_idx;
         edtChavePIXUpdatedByName_Internalname = "CHAVEPIXUPDATEDBYNAME_"+sGXsfl_137_idx;
      }

      protected void SubsflControlProps_fel_1372( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_137_fel_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_137_fel_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_137_fel_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_137_fel_idx;
         edtChavePIXId_Internalname = "CHAVEPIXID_"+sGXsfl_137_fel_idx;
         cmbChavePIXTipo_Internalname = "CHAVEPIXTIPO_"+sGXsfl_137_fel_idx;
         edtChavePIXConteudo_Internalname = "CHAVEPIXCONTEUDO_"+sGXsfl_137_fel_idx;
         cmbChavePIXStatus_Internalname = "CHAVEPIXSTATUS_"+sGXsfl_137_fel_idx;
         cmbChavePIXPrincipal_Internalname = "CHAVEPIXPRINCIPAL_"+sGXsfl_137_fel_idx;
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_137_fel_idx;
         edtChavePIXCreatedAt_Internalname = "CHAVEPIXCREATEDAT_"+sGXsfl_137_fel_idx;
         edtChavePIXCreatedBy_Internalname = "CHAVEPIXCREATEDBY_"+sGXsfl_137_fel_idx;
         edtChavePIXCreatedByName_Internalname = "CHAVEPIXCREATEDBYNAME_"+sGXsfl_137_fel_idx;
         edtChavePIXUpdatedAt_Internalname = "CHAVEPIXUPDATEDAT_"+sGXsfl_137_fel_idx;
         edtChavePIXUpdatedBy_Internalname = "CHAVEPIXUPDATEDBY_"+sGXsfl_137_fel_idx;
         edtChavePIXUpdatedByName_Internalname = "CHAVEPIXUPDATEDBYNAME_"+sGXsfl_137_fel_idx;
      }

      protected void sendrow_1372( )
      {
         sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
         SubsflControlProps_1372( ) ;
         WB9L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_137_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_137_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_137_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_137_idx + "',137)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_137_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV88GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV88GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_137_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaBancoNome_Internalname,(string)A969AgenciaBancoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaBancoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAgenciaNumero_Link,(string)"",(string)"",(string)"",(string)edtAgenciaNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtContaBancariaNumero_Link,(string)"",(string)"",(string)"",(string)edtContaBancariaNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A961ChavePIXId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbChavePIXTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CHAVEPIXTIPO_" + sGXsfl_137_idx;
               cmbChavePIXTipo.Name = GXCCtl;
               cmbChavePIXTipo.WebTags = "";
               cmbChavePIXTipo.addItem("CPF", "CPF", 0);
               cmbChavePIXTipo.addItem("CNPJ", "CNPJ", 0);
               cmbChavePIXTipo.addItem("Telefone", "Telefone", 0);
               cmbChavePIXTipo.addItem("Email", "E-mail", 0);
               cmbChavePIXTipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
               if ( cmbChavePIXTipo.ItemCount > 0 )
               {
                  A962ChavePIXTipo = cmbChavePIXTipo.getValidValue(A962ChavePIXTipo);
                  n962ChavePIXTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbChavePIXTipo,(string)cmbChavePIXTipo_Internalname,StringUtil.RTrim( A962ChavePIXTipo),(short)1,(string)cmbChavePIXTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbChavePIXTipo.CurrentValue = StringUtil.RTrim( A962ChavePIXTipo);
            AssignProp("", false, cmbChavePIXTipo_Internalname, "Values", (string)(cmbChavePIXTipo.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXConteudo_Internalname,(string)A963ChavePIXConteudo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXConteudo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbChavePIXStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CHAVEPIXSTATUS_" + sGXsfl_137_idx;
               cmbChavePIXStatus.Name = GXCCtl;
               cmbChavePIXStatus.WebTags = "";
               cmbChavePIXStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbChavePIXStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbChavePIXStatus.ItemCount > 0 )
               {
                  A964ChavePIXStatus = StringUtil.StrToBool( cmbChavePIXStatus.getValidValue(StringUtil.BoolToStr( A964ChavePIXStatus)));
                  n964ChavePIXStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbChavePIXStatus,(string)cmbChavePIXStatus_Internalname,StringUtil.BoolToStr( A964ChavePIXStatus),(short)1,(string)cmbChavePIXStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbChavePIXStatus_Columnclass,(string)cmbChavePIXStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbChavePIXStatus.CurrentValue = StringUtil.BoolToStr( A964ChavePIXStatus);
            AssignProp("", false, cmbChavePIXStatus_Internalname, "Values", (string)(cmbChavePIXStatus.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbChavePIXPrincipal.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CHAVEPIXPRINCIPAL_" + sGXsfl_137_idx;
               cmbChavePIXPrincipal.Name = GXCCtl;
               cmbChavePIXPrincipal.WebTags = "";
               cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbChavePIXPrincipal.ItemCount > 0 )
               {
                  A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.getValidValue(StringUtil.BoolToStr( A965ChavePIXPrincipal)));
                  n965ChavePIXPrincipal = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbChavePIXPrincipal,(string)cmbChavePIXPrincipal_Internalname,StringUtil.BoolToStr( A965ChavePIXPrincipal),(short)1,(string)cmbChavePIXPrincipal_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbChavePIXPrincipal_Columnclass,(string)cmbChavePIXPrincipal_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
            AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Values", (string)(cmbChavePIXPrincipal.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXCreatedAt_Internalname,context.localUtil.TToC( A966ChavePIXCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A966ChavePIXCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXCreatedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A957ChavePIXCreatedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXCreatedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXCreatedByName_Internalname,(string)A958ChavePIXCreatedByName,StringUtil.RTrim( context.localUtil.Format( A958ChavePIXCreatedByName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtChavePIXCreatedByName_Link,(string)"",(string)"",(string)"",(string)edtChavePIXCreatedByName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXUpdatedAt_Internalname,context.localUtil.TToC( A967ChavePIXUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A967ChavePIXUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXUpdatedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A959ChavePIXUpdatedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChavePIXUpdatedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChavePIXUpdatedByName_Internalname,(string)A960ChavePIXUpdatedByName,StringUtil.RTrim( context.localUtil.Format( A960ChavePIXUpdatedByName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtChavePIXUpdatedByName_Link,(string)"",(string)"",(string)"",(string)edtChavePIXUpdatedByName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_137_idx = ((subGrid_Islastpage==1)&&(nGXsfl_137_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_137_idx+1);
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
         }
         /* End function sendrow_1372 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CHAVEPIXTIPO", "Tipo", 0);
         cmbavDynamicfiltersselector1.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector1.addItem("CHAVEPIXCREATEDBYNAME", "por", 0);
         cmbavDynamicfiltersselector1.addItem("CHAVEPIXUPDATEDBYNAME", "por", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavChavepixtipo1.Name = "vCHAVEPIXTIPO1";
         cmbavChavepixtipo1.WebTags = "";
         cmbavChavepixtipo1.addItem("", "Todos", 0);
         cmbavChavepixtipo1.addItem("CPF", "CPF", 0);
         cmbavChavepixtipo1.addItem("CNPJ", "CNPJ", 0);
         cmbavChavepixtipo1.addItem("Telefone", "Telefone", 0);
         cmbavChavepixtipo1.addItem("Email", "E-mail", 0);
         cmbavChavepixtipo1.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavChavepixtipo1.ItemCount > 0 )
         {
            AV18ChavePIXTipo1 = cmbavChavepixtipo1.getValidValue(AV18ChavePIXTipo1);
            AssignAttri("", false, "AV18ChavePIXTipo1", AV18ChavePIXTipo1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CHAVEPIXTIPO", "Tipo", 0);
         cmbavDynamicfiltersselector2.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector2.addItem("CHAVEPIXCREATEDBYNAME", "por", 0);
         cmbavDynamicfiltersselector2.addItem("CHAVEPIXUPDATEDBYNAME", "por", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavChavepixtipo2.Name = "vCHAVEPIXTIPO2";
         cmbavChavepixtipo2.WebTags = "";
         cmbavChavepixtipo2.addItem("", "Todos", 0);
         cmbavChavepixtipo2.addItem("CPF", "CPF", 0);
         cmbavChavepixtipo2.addItem("CNPJ", "CNPJ", 0);
         cmbavChavepixtipo2.addItem("Telefone", "Telefone", 0);
         cmbavChavepixtipo2.addItem("Email", "E-mail", 0);
         cmbavChavepixtipo2.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavChavepixtipo2.ItemCount > 0 )
         {
            AV25ChavePIXTipo2 = cmbavChavepixtipo2.getValidValue(AV25ChavePIXTipo2);
            AssignAttri("", false, "AV25ChavePIXTipo2", AV25ChavePIXTipo2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CHAVEPIXTIPO", "Tipo", 0);
         cmbavDynamicfiltersselector3.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector3.addItem("CHAVEPIXCREATEDBYNAME", "por", 0);
         cmbavDynamicfiltersselector3.addItem("CHAVEPIXUPDATEDBYNAME", "por", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         cmbavChavepixtipo3.Name = "vCHAVEPIXTIPO3";
         cmbavChavepixtipo3.WebTags = "";
         cmbavChavepixtipo3.addItem("", "Todos", 0);
         cmbavChavepixtipo3.addItem("CPF", "CPF", 0);
         cmbavChavepixtipo3.addItem("CNPJ", "CNPJ", 0);
         cmbavChavepixtipo3.addItem("Telefone", "Telefone", 0);
         cmbavChavepixtipo3.addItem("Email", "E-mail", 0);
         cmbavChavepixtipo3.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavChavepixtipo3.ItemCount > 0 )
         {
            AV32ChavePIXTipo3 = cmbavChavepixtipo3.getValidValue(AV32ChavePIXTipo3);
            AssignAttri("", false, "AV32ChavePIXTipo3", AV32ChavePIXTipo3);
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_137_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV88GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV88GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV88GridActionGroup1), 4, 0));
         }
         GXCCtl = "CHAVEPIXTIPO_" + sGXsfl_137_idx;
         cmbChavePIXTipo.Name = GXCCtl;
         cmbChavePIXTipo.WebTags = "";
         cmbChavePIXTipo.addItem("CPF", "CPF", 0);
         cmbChavePIXTipo.addItem("CNPJ", "CNPJ", 0);
         cmbChavePIXTipo.addItem("Telefone", "Telefone", 0);
         cmbChavePIXTipo.addItem("Email", "E-mail", 0);
         cmbChavePIXTipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbChavePIXTipo.ItemCount > 0 )
         {
            A962ChavePIXTipo = cmbChavePIXTipo.getValidValue(A962ChavePIXTipo);
            n962ChavePIXTipo = false;
         }
         GXCCtl = "CHAVEPIXSTATUS_" + sGXsfl_137_idx;
         cmbChavePIXStatus.Name = GXCCtl;
         cmbChavePIXStatus.WebTags = "";
         cmbChavePIXStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbChavePIXStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbChavePIXStatus.ItemCount > 0 )
         {
            A964ChavePIXStatus = StringUtil.StrToBool( cmbChavePIXStatus.getValidValue(StringUtil.BoolToStr( A964ChavePIXStatus)));
            n964ChavePIXStatus = false;
         }
         GXCCtl = "CHAVEPIXPRINCIPAL_" + sGXsfl_137_idx;
         cmbChavePIXPrincipal.Name = GXCCtl;
         cmbChavePIXPrincipal.WebTags = "";
         cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbChavePIXPrincipal.ItemCount > 0 )
         {
            A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.getValidValue(StringUtil.BoolToStr( A965ChavePIXPrincipal)));
            n965ChavePIXPrincipal = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl137( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"137\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Banco") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Agência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Conta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "PIXId") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Chave") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Principal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Bancaria Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "PIXCreated By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado por") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV88GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A969AgenciaBancoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAgenciaNumero_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtContaBancariaNumero_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A961ChavePIXId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A962ChavePIXTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A963ChavePIXConteudo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A964ChavePIXStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbChavePIXStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbChavePIXStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A965ChavePIXPrincipal)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbChavePIXPrincipal_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbChavePIXPrincipal_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A966ChavePIXCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A958ChavePIXCreatedByName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtChavePIXCreatedByName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A967ChavePIXUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A960ChavePIXUpdatedByName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtChavePIXUpdatedByName_Link));
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
         cmbavChavepixtipo1_Internalname = "vCHAVEPIXTIPO1";
         cellFilter_chavepixtipo1_cell_Internalname = "FILTER_CHAVEPIXTIPO1_CELL";
         edtavContabancarianumero1_Internalname = "vCONTABANCARIANUMERO1";
         cellFilter_contabancarianumero1_cell_Internalname = "FILTER_CONTABANCARIANUMERO1_CELL";
         edtavChavepixcreatedbyname1_Internalname = "vCHAVEPIXCREATEDBYNAME1";
         cellFilter_chavepixcreatedbyname1_cell_Internalname = "FILTER_CHAVEPIXCREATEDBYNAME1_CELL";
         edtavChavepixupdatedbyname1_Internalname = "vCHAVEPIXUPDATEDBYNAME1";
         cellFilter_chavepixupdatedbyname1_cell_Internalname = "FILTER_CHAVEPIXUPDATEDBYNAME1_CELL";
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
         cmbavChavepixtipo2_Internalname = "vCHAVEPIXTIPO2";
         cellFilter_chavepixtipo2_cell_Internalname = "FILTER_CHAVEPIXTIPO2_CELL";
         edtavContabancarianumero2_Internalname = "vCONTABANCARIANUMERO2";
         cellFilter_contabancarianumero2_cell_Internalname = "FILTER_CONTABANCARIANUMERO2_CELL";
         edtavChavepixcreatedbyname2_Internalname = "vCHAVEPIXCREATEDBYNAME2";
         cellFilter_chavepixcreatedbyname2_cell_Internalname = "FILTER_CHAVEPIXCREATEDBYNAME2_CELL";
         edtavChavepixupdatedbyname2_Internalname = "vCHAVEPIXUPDATEDBYNAME2";
         cellFilter_chavepixupdatedbyname2_cell_Internalname = "FILTER_CHAVEPIXUPDATEDBYNAME2_CELL";
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
         cmbavChavepixtipo3_Internalname = "vCHAVEPIXTIPO3";
         cellFilter_chavepixtipo3_cell_Internalname = "FILTER_CHAVEPIXTIPO3_CELL";
         edtavContabancarianumero3_Internalname = "vCONTABANCARIANUMERO3";
         cellFilter_contabancarianumero3_cell_Internalname = "FILTER_CONTABANCARIANUMERO3_CELL";
         edtavChavepixcreatedbyname3_Internalname = "vCHAVEPIXCREATEDBYNAME3";
         cellFilter_chavepixcreatedbyname3_cell_Internalname = "FILTER_CHAVEPIXCREATEDBYNAME3_CELL";
         edtavChavepixupdatedbyname3_Internalname = "vCHAVEPIXUPDATEDBYNAME3";
         cellFilter_chavepixupdatedbyname3_cell_Internalname = "FILTER_CHAVEPIXUPDATEDBYNAME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO";
         edtChavePIXId_Internalname = "CHAVEPIXID";
         cmbChavePIXTipo_Internalname = "CHAVEPIXTIPO";
         edtChavePIXConteudo_Internalname = "CHAVEPIXCONTEUDO";
         cmbChavePIXStatus_Internalname = "CHAVEPIXSTATUS";
         cmbChavePIXPrincipal_Internalname = "CHAVEPIXPRINCIPAL";
         edtContaBancariaId_Internalname = "CONTABANCARIAID";
         edtChavePIXCreatedAt_Internalname = "CHAVEPIXCREATEDAT";
         edtChavePIXCreatedBy_Internalname = "CHAVEPIXCREATEDBY";
         edtChavePIXCreatedByName_Internalname = "CHAVEPIXCREATEDBYNAME";
         edtChavePIXUpdatedAt_Internalname = "CHAVEPIXUPDATEDAT";
         edtChavePIXUpdatedBy_Internalname = "CHAVEPIXUPDATEDBY";
         edtChavePIXUpdatedByName_Internalname = "CHAVEPIXUPDATEDBYNAME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_chavepixcreatedatauxdatetext_Internalname = "vDDO_CHAVEPIXCREATEDATAUXDATETEXT";
         Tfchavepixcreatedat_rangepicker_Internalname = "TFCHAVEPIXCREATEDAT_RANGEPICKER";
         divDdo_chavepixcreatedatauxdates_Internalname = "DDO_CHAVEPIXCREATEDATAUXDATES";
         edtavDdo_chavepixupdatedatauxdatetext_Internalname = "vDDO_CHAVEPIXUPDATEDATAUXDATETEXT";
         Tfchavepixupdatedat_rangepicker_Internalname = "TFCHAVEPIXUPDATEDAT_RANGEPICKER";
         divDdo_chavepixupdatedatauxdates_Internalname = "DDO_CHAVEPIXUPDATEDATAUXDATES";
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
         edtChavePIXUpdatedByName_Jsonclick = "";
         edtChavePIXUpdatedByName_Link = "";
         edtChavePIXUpdatedBy_Jsonclick = "";
         edtChavePIXUpdatedAt_Jsonclick = "";
         edtChavePIXCreatedByName_Jsonclick = "";
         edtChavePIXCreatedByName_Link = "";
         edtChavePIXCreatedBy_Jsonclick = "";
         edtChavePIXCreatedAt_Jsonclick = "";
         edtContaBancariaId_Jsonclick = "";
         cmbChavePIXPrincipal_Jsonclick = "";
         cmbChavePIXPrincipal_Columnclass = "WWColumn";
         cmbChavePIXStatus_Jsonclick = "";
         cmbChavePIXStatus_Columnclass = "WWColumn";
         edtChavePIXConteudo_Jsonclick = "";
         cmbChavePIXTipo_Jsonclick = "";
         edtChavePIXId_Jsonclick = "";
         edtContaBancariaNumero_Jsonclick = "";
         edtContaBancariaNumero_Link = "";
         edtAgenciaNumero_Jsonclick = "";
         edtAgenciaNumero_Link = "";
         edtAgenciaBancoNome_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavChavepixupdatedbyname1_Jsonclick = "";
         edtavChavepixupdatedbyname1_Enabled = 1;
         edtavChavepixcreatedbyname1_Jsonclick = "";
         edtavChavepixcreatedbyname1_Enabled = 1;
         edtavContabancarianumero1_Jsonclick = "";
         edtavContabancarianumero1_Enabled = 1;
         cmbavChavepixtipo1_Jsonclick = "";
         cmbavChavepixtipo1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavChavepixupdatedbyname2_Jsonclick = "";
         edtavChavepixupdatedbyname2_Enabled = 1;
         edtavChavepixcreatedbyname2_Jsonclick = "";
         edtavChavepixcreatedbyname2_Enabled = 1;
         edtavContabancarianumero2_Jsonclick = "";
         edtavContabancarianumero2_Enabled = 1;
         cmbavChavepixtipo2_Jsonclick = "";
         cmbavChavepixtipo2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavChavepixupdatedbyname3_Jsonclick = "";
         edtavChavepixupdatedbyname3_Enabled = 1;
         edtavChavepixcreatedbyname3_Jsonclick = "";
         edtavChavepixcreatedbyname3_Enabled = 1;
         edtavContabancarianumero3_Jsonclick = "";
         edtavContabancarianumero3_Enabled = 1;
         cmbavChavepixtipo3_Jsonclick = "";
         cmbavChavepixtipo3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavChavepixupdatedbyname3_Visible = 1;
         edtavChavepixcreatedbyname3_Visible = 1;
         edtavContabancarianumero3_Visible = 1;
         cmbavChavepixtipo3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavChavepixupdatedbyname2_Visible = 1;
         edtavChavepixcreatedbyname2_Visible = 1;
         edtavContabancarianumero2_Visible = 1;
         cmbavChavepixtipo2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavChavepixupdatedbyname1_Visible = 1;
         edtavChavepixcreatedbyname1_Visible = 1;
         edtavContabancarianumero1_Visible = 1;
         cmbavChavepixtipo1.Visible = 1;
         cmbChavePIXPrincipal_Columnheaderclass = "";
         cmbChavePIXStatus_Columnheaderclass = "";
         edtChavePIXUpdatedByName_Enabled = 0;
         edtChavePIXUpdatedBy_Enabled = 0;
         edtChavePIXUpdatedAt_Enabled = 0;
         edtChavePIXCreatedByName_Enabled = 0;
         edtChavePIXCreatedBy_Enabled = 0;
         edtChavePIXCreatedAt_Enabled = 0;
         edtContaBancariaId_Enabled = 0;
         cmbChavePIXPrincipal.Enabled = 0;
         cmbChavePIXStatus.Enabled = 0;
         edtChavePIXConteudo_Enabled = 0;
         cmbChavePIXTipo.Enabled = 0;
         edtChavePIXId_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_chavepixupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_chavepixcreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         bttBtn_cancel_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|9.0|18.0||||||||";
         Ddo_grid_Datalistproc = "ChavePIXWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||CPF:CPF,CNPJ:CNPJ,Telefone:Telefone,Email:E-mail,ChaveAleatoria:Chave aleatória||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked||||";
         Ddo_grid_Allowmultipleselection = "|||T|||||||";
         Ddo_grid_Datalisttype = "Dynamic|||FixedValues|Dynamic|FixedValues|FixedValues||Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "T|||T|T|T|T||T||T";
         Ddo_grid_Filterisrange = "|T|T|||||P||P|";
         Ddo_grid_Filtertype = "Character|Numeric|Numeric||Character|||Date|Character|Date|Character";
         Ddo_grid_Includefilter = "T|T|T||T|||T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "1:AgenciaBancoNome|2:AgenciaNumero|3:ContaBancariaNumero|5:ChavePIXTipo|6:ChavePIXConteudo|7:ChavePIXStatus|8:ChavePIXPrincipal|10:ChavePIXCreatedAt|12:ChavePIXCreatedByName|13:ChavePIXUpdatedAt|15:ChavePIXUpdatedByName";
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
         Form.Caption = " Chave PIX";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV46TFChavePIXTipo_SelsJson","fld":"vTFCHAVEPIXTIPO_SELSJSON","type":"vchar"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E279L2","iparms":[{"av":"cmbChavePIXPrincipal"},{"av":"A965ChavePIXPrincipal","fld":"CHAVEPIXPRINCIPAL","type":"boolean"},{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A957ChavePIXCreatedBy","fld":"CHAVEPIXCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"A959ChavePIXUpdatedBy","fld":"CHAVEPIXUPDATEDBY","pic":"ZZZ9","type":"int"},{"av":"cmbChavePIXStatus"},{"av":"A964ChavePIXStatus","fld":"CHAVEPIXSTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV88GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"edtAgenciaNumero_Link","ctrl":"AGENCIANUMERO","prop":"Link"},{"av":"edtContaBancariaNumero_Link","ctrl":"CONTABANCARIANUMERO","prop":"Link"},{"av":"edtChavePIXCreatedByName_Link","ctrl":"CHAVEPIXCREATEDBYNAME","prop":"Link"},{"av":"edtChavePIXUpdatedByName_Link","ctrl":"CHAVEPIXUPDATEDBYNAME","prop":"Link"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E209L2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavChavepixcreatedbyname2_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME2","prop":"Visible"},{"av":"edtavChavepixupdatedbyname2_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavChavepixcreatedbyname3_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME3","prop":"Visible"},{"av":"edtavChavepixupdatedbyname3_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavChavepixcreatedbyname1_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME1","prop":"Visible"},{"av":"edtavChavepixupdatedbyname1_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219L2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavChavepixcreatedbyname1_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME1","prop":"Visible"},{"av":"edtavChavepixupdatedbyname1_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E229L2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavChavepixcreatedbyname2_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME2","prop":"Visible"},{"av":"edtavChavepixupdatedbyname2_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavChavepixcreatedbyname3_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME3","prop":"Visible"},{"av":"edtavChavepixupdatedbyname3_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavChavepixcreatedbyname1_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME1","prop":"Visible"},{"av":"edtavChavepixupdatedbyname1_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E239L2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavChavepixcreatedbyname2_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME2","prop":"Visible"},{"av":"edtavChavepixupdatedbyname2_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavChavepixcreatedbyname2_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME2","prop":"Visible"},{"av":"edtavChavepixupdatedbyname2_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavChavepixcreatedbyname3_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME3","prop":"Visible"},{"av":"edtavChavepixupdatedbyname3_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavChavepixcreatedbyname1_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME1","prop":"Visible"},{"av":"edtavChavepixupdatedbyname1_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E249L2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavChavepixcreatedbyname3_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME3","prop":"Visible"},{"av":"edtavChavepixupdatedbyname3_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV46TFChavePIXTipo_SelsJson","fld":"vTFCHAVEPIXTIPO_SELSJSON","type":"vchar"},{"av":"AV62DDO_ChavePIXCreatedAtAuxDate","fld":"vDDO_CHAVEPIXCREATEDATAUXDATE","type":"date"},{"av":"AV71DDO_ChavePIXUpdatedAtAuxDate","fld":"vDDO_CHAVEPIXUPDATEDATAUXDATE","type":"date"},{"av":"AV63DDO_ChavePIXCreatedAtAuxDateTo","fld":"vDDO_CHAVEPIXCREATEDATAUXDATETO","type":"date"},{"av":"AV72DDO_ChavePIXUpdatedAtAuxDateTo","fld":"vDDO_CHAVEPIXUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV71DDO_ChavePIXUpdatedAtAuxDate","fld":"vDDO_CHAVEPIXUPDATEDATAUXDATE","type":"date"},{"av":"AV72DDO_ChavePIXUpdatedAtAuxDateTo","fld":"vDDO_CHAVEPIXUPDATEDATAUXDATETO","type":"date"},{"av":"AV62DDO_ChavePIXCreatedAtAuxDate","fld":"vDDO_CHAVEPIXCREATEDATAUXDATE","type":"date"},{"av":"AV63DDO_ChavePIXCreatedAtAuxDateTo","fld":"vDDO_CHAVEPIXCREATEDATAUXDATETO","type":"date"},{"av":"AV46TFChavePIXTipo_SelsJson","fld":"vTFCHAVEPIXTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavChavepixcreatedbyname1_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME1","prop":"Visible"},{"av":"edtavChavepixupdatedbyname1_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavChavepixcreatedbyname2_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME2","prop":"Visible"},{"av":"edtavChavepixupdatedbyname2_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavChavepixcreatedbyname3_Visible","ctrl":"vCHAVEPIXCREATEDBYNAME3","prop":"Visible"},{"av":"edtavChavepixupdatedbyname3_Visible","ctrl":"vCHAVEPIXUPDATEDBYNAME3","prop":"Visible"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E289L2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV88GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"A961ChavePIXId","fld":"CHAVEPIXID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo1"},{"av":"AV18ChavePIXTipo1","fld":"vCHAVEPIXTIPO1","type":"svchar"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20ChavePIXCreatedByName1","fld":"vCHAVEPIXCREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV21ChavePIXUpdatedByName1","fld":"vCHAVEPIXUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo2"},{"av":"AV25ChavePIXTipo2","fld":"vCHAVEPIXTIPO2","type":"svchar"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ChavePIXCreatedByName2","fld":"vCHAVEPIXCREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV28ChavePIXUpdatedByName2","fld":"vCHAVEPIXUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavChavepixtipo3"},{"av":"AV32ChavePIXTipo3","fld":"vCHAVEPIXTIPO3","type":"svchar"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34ChavePIXCreatedByName3","fld":"vCHAVEPIXCREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV35ChavePIXUpdatedByName3","fld":"vCHAVEPIXUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV58TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV59TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV56TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV57TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV54TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV55TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFChavePIXTipo_Sels","fld":"vTFCHAVEPIXTIPO_SELS","type":""},{"av":"AV48TFChavePIXConteudo","fld":"vTFCHAVEPIXCONTEUDO","type":"svchar"},{"av":"AV49TFChavePIXConteudo_Sel","fld":"vTFCHAVEPIXCONTEUDO_SEL","type":"svchar"},{"av":"AV50TFChavePIXStatus_Sel","fld":"vTFCHAVEPIXSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFChavePIXPrincipal_Sel","fld":"vTFCHAVEPIXPRINCIPAL_SEL","pic":"9","type":"int"},{"av":"AV60TFChavePIXCreatedAt","fld":"vTFCHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFChavePIXCreatedAt_To","fld":"vTFCHAVEPIXCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV67TFChavePIXCreatedByName","fld":"vTFCHAVEPIXCREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV68TFChavePIXCreatedByName_Sel","fld":"vTFCHAVEPIXCREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV69TFChavePIXUpdatedAt","fld":"vTFCHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70TFChavePIXUpdatedAt_To","fld":"vTFCHAVEPIXUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV76TFChavePIXUpdatedByName","fld":"vTFCHAVEPIXUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV77TFChavePIXUpdatedByName_Sel","fld":"vTFCHAVEPIXUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV90BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV88GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbChavePIXStatus"},{"av":"cmbChavePIXPrincipal"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189L2","iparms":[{"av":"A961ChavePIXId","fld":"CHAVEPIXID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV87ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199L2","iparms":[]}""");
         setEventMetadata("VALIDV_CHAVEPIXTIPO1","""{"handler":"Validv_Chavepixtipo1","iparms":[]}""");
         setEventMetadata("VALIDV_CHAVEPIXTIPO2","""{"handler":"Validv_Chavepixtipo2","iparms":[]}""");
         setEventMetadata("VALIDV_CHAVEPIXTIPO3","""{"handler":"Validv_Chavepixtipo3","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIAID","""{"handler":"Valid_Contabancariaid","iparms":[]}""");
         setEventMetadata("VALID_CHAVEPIXCREATEDBY","""{"handler":"Valid_Chavepixcreatedby","iparms":[]}""");
         setEventMetadata("VALID_CHAVEPIXUPDATEDBY","""{"handler":"Valid_Chavepixupdatedby","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Chavepixupdatedbyname","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18ChavePIXTipo1 = "";
         AV20ChavePIXCreatedByName1 = "";
         AV21ChavePIXUpdatedByName1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ChavePIXTipo2 = "";
         AV27ChavePIXCreatedByName2 = "";
         AV28ChavePIXUpdatedByName2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32ChavePIXTipo3 = "";
         AV34ChavePIXCreatedByName3 = "";
         AV35ChavePIXUpdatedByName3 = "";
         AV92Pgmname = "";
         AV58TFAgenciaBancoNome = "";
         AV59TFAgenciaBancoNome_Sel = "";
         AV47TFChavePIXTipo_Sels = new GxSimpleCollection<string>();
         AV48TFChavePIXConteudo = "";
         AV49TFChavePIXConteudo_Sel = "";
         AV60TFChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         AV61TFChavePIXCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV67TFChavePIXCreatedByName = "";
         AV68TFChavePIXCreatedByName_Sel = "";
         AV69TFChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         AV70TFChavePIXUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV76TFChavePIXUpdatedByName = "";
         AV77TFChavePIXUpdatedByName_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV82GridAppliedFilters = "";
         AV78DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV62DDO_ChavePIXCreatedAtAuxDate = DateTime.MinValue;
         AV63DDO_ChavePIXCreatedAtAuxDateTo = DateTime.MinValue;
         AV71DDO_ChavePIXUpdatedAtAuxDate = DateTime.MinValue;
         AV72DDO_ChavePIXUpdatedAtAuxDateTo = DateTime.MinValue;
         AV46TFChavePIXTipo_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         AV64DDO_ChavePIXCreatedAtAuxDateText = "";
         ucTfchavepixcreatedat_rangepicker = new GXUserControl();
         AV73DDO_ChavePIXUpdatedAtAuxDateText = "";
         ucTfchavepixupdatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A969AgenciaBancoNome = "";
         A962ChavePIXTipo = "";
         A963ChavePIXConteudo = "";
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         A958ChavePIXCreatedByName = "";
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         A960ChavePIXUpdatedByName = "";
         GXDecQS = "";
         AV120Chavepixwwds_28_tfchavepixtipo_sels = new GxSimpleCollection<string>();
         lV93Chavepixwwds_1_filterfulltext = "";
         lV98Chavepixwwds_6_chavepixcreatedbyname1 = "";
         lV99Chavepixwwds_7_chavepixupdatedbyname1 = "";
         lV105Chavepixwwds_13_chavepixcreatedbyname2 = "";
         lV106Chavepixwwds_14_chavepixupdatedbyname2 = "";
         lV112Chavepixwwds_20_chavepixcreatedbyname3 = "";
         lV113Chavepixwwds_21_chavepixupdatedbyname3 = "";
         lV114Chavepixwwds_22_tfagenciabanconome = "";
         lV121Chavepixwwds_29_tfchavepixconteudo = "";
         lV127Chavepixwwds_35_tfchavepixcreatedbyname = "";
         lV131Chavepixwwds_39_tfchavepixupdatedbyname = "";
         AV93Chavepixwwds_1_filterfulltext = "";
         AV94Chavepixwwds_2_dynamicfiltersselector1 = "";
         AV96Chavepixwwds_4_chavepixtipo1 = "";
         AV98Chavepixwwds_6_chavepixcreatedbyname1 = "";
         AV99Chavepixwwds_7_chavepixupdatedbyname1 = "";
         AV101Chavepixwwds_9_dynamicfiltersselector2 = "";
         AV103Chavepixwwds_11_chavepixtipo2 = "";
         AV105Chavepixwwds_13_chavepixcreatedbyname2 = "";
         AV106Chavepixwwds_14_chavepixupdatedbyname2 = "";
         AV108Chavepixwwds_16_dynamicfiltersselector3 = "";
         AV110Chavepixwwds_18_chavepixtipo3 = "";
         AV112Chavepixwwds_20_chavepixcreatedbyname3 = "";
         AV113Chavepixwwds_21_chavepixupdatedbyname3 = "";
         AV115Chavepixwwds_23_tfagenciabanconome_sel = "";
         AV114Chavepixwwds_22_tfagenciabanconome = "";
         AV122Chavepixwwds_30_tfchavepixconteudo_sel = "";
         AV121Chavepixwwds_29_tfchavepixconteudo = "";
         AV125Chavepixwwds_33_tfchavepixcreatedat = (DateTime)(DateTime.MinValue);
         AV126Chavepixwwds_34_tfchavepixcreatedat_to = (DateTime)(DateTime.MinValue);
         AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel = "";
         AV127Chavepixwwds_35_tfchavepixcreatedbyname = "";
         AV129Chavepixwwds_37_tfchavepixupdatedat = (DateTime)(DateTime.MinValue);
         AV130Chavepixwwds_38_tfchavepixupdatedat_to = (DateTime)(DateTime.MinValue);
         AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel = "";
         AV131Chavepixwwds_39_tfchavepixupdatedbyname = "";
         H009L2_A968AgenciaBancoId = new int[1] ;
         H009L2_n968AgenciaBancoId = new bool[] {false} ;
         H009L2_A938AgenciaId = new int[1] ;
         H009L2_n938AgenciaId = new bool[] {false} ;
         H009L2_A960ChavePIXUpdatedByName = new string[] {""} ;
         H009L2_n960ChavePIXUpdatedByName = new bool[] {false} ;
         H009L2_A959ChavePIXUpdatedBy = new short[1] ;
         H009L2_n959ChavePIXUpdatedBy = new bool[] {false} ;
         H009L2_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H009L2_n967ChavePIXUpdatedAt = new bool[] {false} ;
         H009L2_A958ChavePIXCreatedByName = new string[] {""} ;
         H009L2_n958ChavePIXCreatedByName = new bool[] {false} ;
         H009L2_A957ChavePIXCreatedBy = new short[1] ;
         H009L2_n957ChavePIXCreatedBy = new bool[] {false} ;
         H009L2_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009L2_n966ChavePIXCreatedAt = new bool[] {false} ;
         H009L2_A951ContaBancariaId = new int[1] ;
         H009L2_n951ContaBancariaId = new bool[] {false} ;
         H009L2_A965ChavePIXPrincipal = new bool[] {false} ;
         H009L2_n965ChavePIXPrincipal = new bool[] {false} ;
         H009L2_A964ChavePIXStatus = new bool[] {false} ;
         H009L2_n964ChavePIXStatus = new bool[] {false} ;
         H009L2_A963ChavePIXConteudo = new string[] {""} ;
         H009L2_n963ChavePIXConteudo = new bool[] {false} ;
         H009L2_A962ChavePIXTipo = new string[] {""} ;
         H009L2_n962ChavePIXTipo = new bool[] {false} ;
         H009L2_A961ChavePIXId = new int[1] ;
         H009L2_A952ContaBancariaNumero = new long[1] ;
         H009L2_n952ContaBancariaNumero = new bool[] {false} ;
         H009L2_A939AgenciaNumero = new int[1] ;
         H009L2_n939AgenciaNumero = new bool[] {false} ;
         H009L2_A969AgenciaBancoNome = new string[] {""} ;
         H009L2_n969AgenciaBancoNome = new bool[] {false} ;
         H009L3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV38ExcelFilename = "";
         AV39ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV89SdErro = new SdtSdErro(context);
         AV40Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV86AuxText = "";
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chavepixww__default(),
            new Object[][] {
                new Object[] {
               H009L2_A968AgenciaBancoId, H009L2_n968AgenciaBancoId, H009L2_A938AgenciaId, H009L2_n938AgenciaId, H009L2_A960ChavePIXUpdatedByName, H009L2_n960ChavePIXUpdatedByName, H009L2_A959ChavePIXUpdatedBy, H009L2_n959ChavePIXUpdatedBy, H009L2_A967ChavePIXUpdatedAt, H009L2_n967ChavePIXUpdatedAt,
               H009L2_A958ChavePIXCreatedByName, H009L2_n958ChavePIXCreatedByName, H009L2_A957ChavePIXCreatedBy, H009L2_n957ChavePIXCreatedBy, H009L2_A966ChavePIXCreatedAt, H009L2_n966ChavePIXCreatedAt, H009L2_A951ContaBancariaId, H009L2_n951ContaBancariaId, H009L2_A965ChavePIXPrincipal, H009L2_n965ChavePIXPrincipal,
               H009L2_A964ChavePIXStatus, H009L2_n964ChavePIXStatus, H009L2_A963ChavePIXConteudo, H009L2_n963ChavePIXConteudo, H009L2_A962ChavePIXTipo, H009L2_n962ChavePIXTipo, H009L2_A961ChavePIXId, H009L2_A952ContaBancariaNumero, H009L2_n952ContaBancariaNumero, H009L2_A939AgenciaNumero,
               H009L2_n939AgenciaNumero, H009L2_A969AgenciaBancoNome, H009L2_n969AgenciaBancoNome
               }
               , new Object[] {
               H009L3_AGRID_nRecordCount
               }
            }
         );
         AV92Pgmname = "ChavePIXWW";
         /* GeneXus formulas. */
         AV92Pgmname = "ChavePIXWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short AV50TFChavePIXStatus_Sel ;
      private short AV51TFChavePIXPrincipal_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV88GridActionGroup1 ;
      private short A957ChavePIXCreatedBy ;
      private short A959ChavePIXUpdatedBy ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV95Chavepixwwds_3_dynamicfiltersoperator1 ;
      private short AV102Chavepixwwds_10_dynamicfiltersoperator2 ;
      private short AV109Chavepixwwds_17_dynamicfiltersoperator3 ;
      private short AV123Chavepixwwds_31_tfchavepixstatus_sel ;
      private short AV124Chavepixwwds_32_tfchavepixprincipal_sel ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV87ContaBancariaId ;
      private int wcpOAV87ContaBancariaId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_137 ;
      private int nGXsfl_137_idx=1 ;
      private int AV56TFAgenciaNumero ;
      private int AV57TFAgenciaNumero_To ;
      private int AV90BancoId ;
      private int AV91AgenciaId ;
      private int A938AgenciaId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtn_cancel_Visible ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A939AgenciaNumero ;
      private int A961ChavePIXId ;
      private int A951ContaBancariaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV120Chavepixwwds_28_tfchavepixtipo_sels_Count ;
      private int AV116Chavepixwwds_24_tfagencianumero ;
      private int AV117Chavepixwwds_25_tfagencianumero_to ;
      private int A968AgenciaBancoId ;
      private int edtAgenciaBancoNome_Enabled ;
      private int edtAgenciaNumero_Enabled ;
      private int edtContaBancariaNumero_Enabled ;
      private int edtChavePIXId_Enabled ;
      private int edtChavePIXConteudo_Enabled ;
      private int edtContaBancariaId_Enabled ;
      private int edtChavePIXCreatedAt_Enabled ;
      private int edtChavePIXCreatedBy_Enabled ;
      private int edtChavePIXCreatedByName_Enabled ;
      private int edtChavePIXUpdatedAt_Enabled ;
      private int edtChavePIXUpdatedBy_Enabled ;
      private int edtChavePIXUpdatedByName_Enabled ;
      private int AV79PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavContabancarianumero1_Visible ;
      private int edtavChavepixcreatedbyname1_Visible ;
      private int edtavChavepixupdatedbyname1_Visible ;
      private int edtavContabancarianumero2_Visible ;
      private int edtavChavepixcreatedbyname2_Visible ;
      private int edtavChavepixupdatedbyname2_Visible ;
      private int edtavContabancarianumero3_Visible ;
      private int edtavChavepixcreatedbyname3_Visible ;
      private int edtavChavepixupdatedbyname3_Visible ;
      private int AV133GXV1 ;
      private int edtavContabancarianumero3_Enabled ;
      private int edtavChavepixcreatedbyname3_Enabled ;
      private int edtavChavepixupdatedbyname3_Enabled ;
      private int edtavContabancarianumero2_Enabled ;
      private int edtavChavepixcreatedbyname2_Enabled ;
      private int edtavChavepixupdatedbyname2_Enabled ;
      private int edtavContabancarianumero1_Enabled ;
      private int edtavChavepixcreatedbyname1_Enabled ;
      private int edtavChavepixupdatedbyname1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV19ContaBancariaNumero1 ;
      private long AV26ContaBancariaNumero2 ;
      private long AV33ContaBancariaNumero3 ;
      private long AV54TFContaBancariaNumero ;
      private long AV55TFContaBancariaNumero_To ;
      private long AV80GridCurrentPage ;
      private long AV81GridPageCount ;
      private long A952ContaBancariaNumero ;
      private long GRID_nCurrentRecord ;
      private long AV97Chavepixwwds_5_contabancarianumero1 ;
      private long AV104Chavepixwwds_12_contabancarianumero2 ;
      private long AV111Chavepixwwds_19_contabancarianumero3 ;
      private long AV118Chavepixwwds_26_tfcontabancarianumero ;
      private long AV119Chavepixwwds_27_tfcontabancarianumero_to ;
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
      private string sGXsfl_137_idx="0001" ;
      private string AV92Pgmname ;
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
      private string Grid_empowerer_Internalname ;
      private string divDdo_chavepixcreatedatauxdates_Internalname ;
      private string edtavDdo_chavepixcreatedatauxdatetext_Internalname ;
      private string edtavDdo_chavepixcreatedatauxdatetext_Jsonclick ;
      private string Tfchavepixcreatedat_rangepicker_Internalname ;
      private string divDdo_chavepixupdatedatauxdates_Internalname ;
      private string edtavDdo_chavepixupdatedatauxdatetext_Internalname ;
      private string edtavDdo_chavepixupdatedatauxdatetext_Jsonclick ;
      private string Tfchavepixupdatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtAgenciaBancoNome_Internalname ;
      private string edtAgenciaNumero_Internalname ;
      private string edtContaBancariaNumero_Internalname ;
      private string edtChavePIXId_Internalname ;
      private string cmbChavePIXTipo_Internalname ;
      private string edtChavePIXConteudo_Internalname ;
      private string cmbChavePIXStatus_Internalname ;
      private string cmbChavePIXPrincipal_Internalname ;
      private string edtContaBancariaId_Internalname ;
      private string edtChavePIXCreatedAt_Internalname ;
      private string edtChavePIXCreatedBy_Internalname ;
      private string edtChavePIXCreatedByName_Internalname ;
      private string edtChavePIXUpdatedAt_Internalname ;
      private string edtChavePIXUpdatedBy_Internalname ;
      private string edtChavePIXUpdatedByName_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavChavepixtipo1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavChavepixtipo2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavChavepixtipo3_Internalname ;
      private string edtavContabancarianumero1_Internalname ;
      private string edtavChavepixcreatedbyname1_Internalname ;
      private string edtavChavepixupdatedbyname1_Internalname ;
      private string edtavContabancarianumero2_Internalname ;
      private string edtavChavepixcreatedbyname2_Internalname ;
      private string edtavChavepixupdatedbyname2_Internalname ;
      private string edtavContabancarianumero3_Internalname ;
      private string edtavChavepixcreatedbyname3_Internalname ;
      private string edtavChavepixupdatedbyname3_Internalname ;
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
      private string cmbChavePIXStatus_Columnheaderclass ;
      private string cmbChavePIXPrincipal_Columnheaderclass ;
      private string edtAgenciaNumero_Link ;
      private string edtContaBancariaNumero_Link ;
      private string edtChavePIXCreatedByName_Link ;
      private string edtChavePIXUpdatedByName_Link ;
      private string cmbChavePIXStatus_Columnclass ;
      private string cmbChavePIXPrincipal_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_chavepixtipo3_cell_Internalname ;
      private string cmbavChavepixtipo3_Jsonclick ;
      private string cellFilter_contabancarianumero3_cell_Internalname ;
      private string edtavContabancarianumero3_Jsonclick ;
      private string cellFilter_chavepixcreatedbyname3_cell_Internalname ;
      private string edtavChavepixcreatedbyname3_Jsonclick ;
      private string cellFilter_chavepixupdatedbyname3_cell_Internalname ;
      private string edtavChavepixupdatedbyname3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_chavepixtipo2_cell_Internalname ;
      private string cmbavChavepixtipo2_Jsonclick ;
      private string cellFilter_contabancarianumero2_cell_Internalname ;
      private string edtavContabancarianumero2_Jsonclick ;
      private string cellFilter_chavepixcreatedbyname2_cell_Internalname ;
      private string edtavChavepixcreatedbyname2_Jsonclick ;
      private string cellFilter_chavepixupdatedbyname2_cell_Internalname ;
      private string edtavChavepixupdatedbyname2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_chavepixtipo1_cell_Internalname ;
      private string cmbavChavepixtipo1_Jsonclick ;
      private string cellFilter_contabancarianumero1_cell_Internalname ;
      private string edtavContabancarianumero1_Jsonclick ;
      private string cellFilter_chavepixcreatedbyname1_cell_Internalname ;
      private string edtavChavepixcreatedbyname1_Jsonclick ;
      private string cellFilter_chavepixupdatedbyname1_cell_Internalname ;
      private string edtavChavepixupdatedbyname1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_137_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtAgenciaBancoNome_Jsonclick ;
      private string edtAgenciaNumero_Jsonclick ;
      private string edtContaBancariaNumero_Jsonclick ;
      private string edtChavePIXId_Jsonclick ;
      private string cmbChavePIXTipo_Jsonclick ;
      private string edtChavePIXConteudo_Jsonclick ;
      private string cmbChavePIXStatus_Jsonclick ;
      private string cmbChavePIXPrincipal_Jsonclick ;
      private string edtContaBancariaId_Jsonclick ;
      private string edtChavePIXCreatedAt_Jsonclick ;
      private string edtChavePIXCreatedBy_Jsonclick ;
      private string edtChavePIXCreatedByName_Jsonclick ;
      private string edtChavePIXUpdatedAt_Jsonclick ;
      private string edtChavePIXUpdatedBy_Jsonclick ;
      private string edtChavePIXUpdatedByName_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV60TFChavePIXCreatedAt ;
      private DateTime AV61TFChavePIXCreatedAt_To ;
      private DateTime AV69TFChavePIXUpdatedAt ;
      private DateTime AV70TFChavePIXUpdatedAt_To ;
      private DateTime A966ChavePIXCreatedAt ;
      private DateTime A967ChavePIXUpdatedAt ;
      private DateTime AV125Chavepixwwds_33_tfchavepixcreatedat ;
      private DateTime AV126Chavepixwwds_34_tfchavepixcreatedat_to ;
      private DateTime AV129Chavepixwwds_37_tfchavepixupdatedat ;
      private DateTime AV130Chavepixwwds_38_tfchavepixupdatedat_to ;
      private DateTime AV62DDO_ChavePIXCreatedAtAuxDate ;
      private DateTime AV63DDO_ChavePIXCreatedAtAuxDateTo ;
      private DateTime AV71DDO_ChavePIXUpdatedAtAuxDate ;
      private DateTime AV72DDO_ChavePIXUpdatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV37DynamicFiltersIgnoreFirst ;
      private bool AV36DynamicFiltersRemoving ;
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
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool n952ContaBancariaNumero ;
      private bool n962ChavePIXTipo ;
      private bool n963ChavePIXConteudo ;
      private bool A964ChavePIXStatus ;
      private bool n964ChavePIXStatus ;
      private bool A965ChavePIXPrincipal ;
      private bool n965ChavePIXPrincipal ;
      private bool n951ContaBancariaId ;
      private bool n966ChavePIXCreatedAt ;
      private bool n957ChavePIXCreatedBy ;
      private bool n958ChavePIXCreatedByName ;
      private bool n967ChavePIXUpdatedAt ;
      private bool n959ChavePIXUpdatedBy ;
      private bool n960ChavePIXUpdatedByName ;
      private bool bGXsfl_137_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV100Chavepixwwds_8_dynamicfiltersenabled2 ;
      private bool AV107Chavepixwwds_15_dynamicfiltersenabled3 ;
      private bool n968AgenciaBancoId ;
      private bool n938AgenciaId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV46TFChavePIXTipo_SelsJson ;
      private string AV42ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ChavePIXTipo1 ;
      private string AV20ChavePIXCreatedByName1 ;
      private string AV21ChavePIXUpdatedByName1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ChavePIXTipo2 ;
      private string AV27ChavePIXCreatedByName2 ;
      private string AV28ChavePIXUpdatedByName2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32ChavePIXTipo3 ;
      private string AV34ChavePIXCreatedByName3 ;
      private string AV35ChavePIXUpdatedByName3 ;
      private string AV58TFAgenciaBancoNome ;
      private string AV59TFAgenciaBancoNome_Sel ;
      private string AV48TFChavePIXConteudo ;
      private string AV49TFChavePIXConteudo_Sel ;
      private string AV67TFChavePIXCreatedByName ;
      private string AV68TFChavePIXCreatedByName_Sel ;
      private string AV76TFChavePIXUpdatedByName ;
      private string AV77TFChavePIXUpdatedByName_Sel ;
      private string AV82GridAppliedFilters ;
      private string AV64DDO_ChavePIXCreatedAtAuxDateText ;
      private string AV73DDO_ChavePIXUpdatedAtAuxDateText ;
      private string A969AgenciaBancoNome ;
      private string A962ChavePIXTipo ;
      private string A963ChavePIXConteudo ;
      private string A958ChavePIXCreatedByName ;
      private string A960ChavePIXUpdatedByName ;
      private string lV93Chavepixwwds_1_filterfulltext ;
      private string lV98Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string lV99Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string lV105Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string lV106Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string lV112Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string lV113Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string lV114Chavepixwwds_22_tfagenciabanconome ;
      private string lV121Chavepixwwds_29_tfchavepixconteudo ;
      private string lV127Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string lV131Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string AV93Chavepixwwds_1_filterfulltext ;
      private string AV94Chavepixwwds_2_dynamicfiltersselector1 ;
      private string AV96Chavepixwwds_4_chavepixtipo1 ;
      private string AV98Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string AV99Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string AV101Chavepixwwds_9_dynamicfiltersselector2 ;
      private string AV103Chavepixwwds_11_chavepixtipo2 ;
      private string AV105Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string AV106Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string AV108Chavepixwwds_16_dynamicfiltersselector3 ;
      private string AV110Chavepixwwds_18_chavepixtipo3 ;
      private string AV112Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string AV113Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string AV115Chavepixwwds_23_tfagenciabanconome_sel ;
      private string AV114Chavepixwwds_22_tfagenciabanconome ;
      private string AV122Chavepixwwds_30_tfchavepixconteudo_sel ;
      private string AV121Chavepixwwds_29_tfchavepixconteudo ;
      private string AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel ;
      private string AV127Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel ;
      private string AV131Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string AV38ExcelFilename ;
      private string AV39ErrorMessage ;
      private string AV86AuxText ;
      private IGxSession AV40Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfchavepixcreatedat_rangepicker ;
      private GXUserControl ucTfchavepixupdatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavChavepixtipo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavChavepixtipo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavChavepixtipo3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbChavePIXTipo ;
      private GXCombobox cmbChavePIXStatus ;
      private GXCombobox cmbChavePIXPrincipal ;
      private GxSimpleCollection<string> AV47TFChavePIXTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV78DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV120Chavepixwwds_28_tfchavepixtipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H009L2_A968AgenciaBancoId ;
      private bool[] H009L2_n968AgenciaBancoId ;
      private int[] H009L2_A938AgenciaId ;
      private bool[] H009L2_n938AgenciaId ;
      private string[] H009L2_A960ChavePIXUpdatedByName ;
      private bool[] H009L2_n960ChavePIXUpdatedByName ;
      private short[] H009L2_A959ChavePIXUpdatedBy ;
      private bool[] H009L2_n959ChavePIXUpdatedBy ;
      private DateTime[] H009L2_A967ChavePIXUpdatedAt ;
      private bool[] H009L2_n967ChavePIXUpdatedAt ;
      private string[] H009L2_A958ChavePIXCreatedByName ;
      private bool[] H009L2_n958ChavePIXCreatedByName ;
      private short[] H009L2_A957ChavePIXCreatedBy ;
      private bool[] H009L2_n957ChavePIXCreatedBy ;
      private DateTime[] H009L2_A966ChavePIXCreatedAt ;
      private bool[] H009L2_n966ChavePIXCreatedAt ;
      private int[] H009L2_A951ContaBancariaId ;
      private bool[] H009L2_n951ContaBancariaId ;
      private bool[] H009L2_A965ChavePIXPrincipal ;
      private bool[] H009L2_n965ChavePIXPrincipal ;
      private bool[] H009L2_A964ChavePIXStatus ;
      private bool[] H009L2_n964ChavePIXStatus ;
      private string[] H009L2_A963ChavePIXConteudo ;
      private bool[] H009L2_n963ChavePIXConteudo ;
      private string[] H009L2_A962ChavePIXTipo ;
      private bool[] H009L2_n962ChavePIXTipo ;
      private int[] H009L2_A961ChavePIXId ;
      private long[] H009L2_A952ContaBancariaNumero ;
      private bool[] H009L2_n952ContaBancariaNumero ;
      private int[] H009L2_A939AgenciaNumero ;
      private bool[] H009L2_n939AgenciaNumero ;
      private string[] H009L2_A969AgenciaBancoNome ;
      private bool[] H009L2_n969AgenciaBancoNome ;
      private long[] H009L3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtSdErro AV89SdErro ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class chavepixww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009L2( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV120Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV93Chavepixwwds_1_filterfulltext ,
                                             string AV94Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV96Chavepixwwds_4_chavepixtipo1 ,
                                             short AV95Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV97Chavepixwwds_5_contabancarianumero1 ,
                                             string AV98Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV99Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV100Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV101Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV103Chavepixwwds_11_chavepixtipo2 ,
                                             short AV102Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV104Chavepixwwds_12_contabancarianumero2 ,
                                             string AV105Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV106Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV107Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV108Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV110Chavepixwwds_18_chavepixtipo3 ,
                                             short AV109Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV111Chavepixwwds_19_contabancarianumero3 ,
                                             string AV112Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV113Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV115Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV114Chavepixwwds_22_tfagenciabanconome ,
                                             int AV116Chavepixwwds_24_tfagencianumero ,
                                             int AV117Chavepixwwds_25_tfagencianumero_to ,
                                             long AV118Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV119Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV120Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV122Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV121Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV123Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV124Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV125Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV126Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV127Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV129Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV130Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV131Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV87ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[59];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T5.AgenciaBancoId AS AgenciaBancoId, T4.AgenciaId, T2.SecUserName AS ChavePIXUpdatedByName, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T1.ChavePIXUpdatedAt, T3.SecUserName AS ChavePIXCreatedByName, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ChavePIXCreatedAt, T1.ContaBancariaId, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXConteudo, T1.ChavePIXTipo, T1.ChavePIXId, T4.ContaBancariaNumero, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome";
         sFromString = " FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV93Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV93Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
            GXv_int8[8] = 1;
            GXv_int8[9] = 1;
            GXv_int8[10] = 1;
            GXv_int8[11] = 1;
            GXv_int8[12] = 1;
            GXv_int8[13] = 1;
            GXv_int8[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV96Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV98Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV98Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV99Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV99Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV103Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV105Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV105Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV106Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV106Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV110Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV112Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV112Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV113Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV113Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV114Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV115Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV115Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( StringUtil.StrCmp(AV115Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV116Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV116Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( ! (0==AV117Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV117Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( ! (0==AV118Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV118Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( ! (0==AV119Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV119Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( AV120Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV120Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV121Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV122Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV122Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( StringUtil.StrCmp(AV122Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV123Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV123Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV124Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV124Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV125Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV125Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV126Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV127Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( StringUtil.StrCmp(AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV129Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV129Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV130Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV131Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( StringUtil.StrCmp(AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (0==AV87ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV87ContaBancariaId)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXTipo, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXTipo DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T6.BancoNome, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T6.BancoNome DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T5.AgenciaNumero, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T5.AgenciaNumero DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ContaBancariaNumero, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ContaBancariaNumero DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXConteudo, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXConteudo DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXStatus, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXStatus DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXPrincipal, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXPrincipal DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXCreatedAt, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXCreatedAt DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.SecUserName, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.SecUserName DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ChavePIXUpdatedAt, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ChavePIXUpdatedAt DESC, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserName, T1.ChavePIXId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserName DESC, T1.ChavePIXId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ChavePIXId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H009L3( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV120Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV93Chavepixwwds_1_filterfulltext ,
                                             string AV94Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV96Chavepixwwds_4_chavepixtipo1 ,
                                             short AV95Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV97Chavepixwwds_5_contabancarianumero1 ,
                                             string AV98Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV99Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV100Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV101Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV103Chavepixwwds_11_chavepixtipo2 ,
                                             short AV102Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV104Chavepixwwds_12_contabancarianumero2 ,
                                             string AV105Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV106Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV107Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV108Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV110Chavepixwwds_18_chavepixtipo3 ,
                                             short AV109Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV111Chavepixwwds_19_contabancarianumero3 ,
                                             string AV112Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV113Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV115Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV114Chavepixwwds_22_tfagenciabanconome ,
                                             int AV116Chavepixwwds_24_tfagencianumero ,
                                             int AV117Chavepixwwds_25_tfagencianumero_to ,
                                             long AV118Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV119Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV120Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV122Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV121Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV123Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV124Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV125Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV126Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV127Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV129Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV130Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV131Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV87ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[56];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((ChavePIX T1 LEFT JOIN SecUser T6 ON T6.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN SecUser T5 ON T5.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = T2.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T4.BancoNome) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T3.AgenciaNumero,'999999999'), 2) like '%' || :lV93Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV93Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T5.SecUserName) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)) or ( LOWER(T6.SecUserName) like '%' || LOWER(:lV93Chavepixwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
            GXv_int10[7] = 1;
            GXv_int10[8] = 1;
            GXv_int10[9] = 1;
            GXv_int10[10] = 1;
            GXv_int10[11] = 1;
            GXv_int10[12] = 1;
            GXv_int10[13] = 1;
            GXv_int10[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV96Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV97Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV97Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV98Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV98Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV99Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV95Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV99Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV103Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV104Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV104Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV105Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV105Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV106Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( AV100Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV102Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV106Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV110Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV111Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV111Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV112Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV112Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV113Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( AV107Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV109Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV113Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T4.BancoNome like :lV114Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV115Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.BancoNome = ( :AV115Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( StringUtil.StrCmp(AV115Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.BancoNome IS NULL or (char_length(trim(trailing ' ' from T4.BancoNome))=0))");
         }
         if ( ! (0==AV116Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T3.AgenciaNumero >= :AV116Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( ! (0==AV117Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T3.AgenciaNumero <= :AV117Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( ! (0==AV118Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero >= :AV118Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( ! (0==AV119Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero <= :AV119Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( AV120Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV120Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV121Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV122Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV122Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( StringUtil.StrCmp(AV122Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV123Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV123Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV124Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV124Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV125Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV125Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV126Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV127Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName = ( :AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( StringUtil.StrCmp(AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.SecUserName IS NULL or (char_length(trim(trailing ' ' from T5.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV129Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV129Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV130Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV131Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName = ( :AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( StringUtil.StrCmp(AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.SecUserName IS NULL or (char_length(trim(trailing ' ' from T6.SecUserName))=0))");
         }
         if ( ! (0==AV87ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV87ContaBancariaId)");
         }
         else
         {
            GXv_int10[55] = 1;
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009L2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
               case 1 :
                     return conditional_H009L3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
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
          Object[] prmH009L2;
          prmH009L2 = new Object[] {
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV96Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV98Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV98Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV99Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV99Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV103Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV105Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV106Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV106Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV110Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV112Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV113Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV113Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV114Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV115Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV116Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV117Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV118Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV119Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV121Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV122Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV125Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV126Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV127Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV129Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV130Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV131Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV87ContaBancariaId",GXType.Int32,9,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009L3;
          prmH009L3 = new Object[] {
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV96Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV97Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV98Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV98Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV99Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV99Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV103Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV104Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV105Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV106Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV106Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV110Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV111Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV112Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV113Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV113Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV114Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV115Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV116Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV117Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV118Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV119Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV121Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV122Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV125Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV126Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV127Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV128Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV129Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV130Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV131Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV132Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV87ContaBancariaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009L3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((bool[]) buf[18])[0] = rslt.getBool(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((bool[]) buf[20])[0] = rslt.getBool(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((long[]) buf[27])[0] = rslt.getLong(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
