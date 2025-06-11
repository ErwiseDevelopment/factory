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
   public class contabancariaww : GXDataArea
   {
      public contabancariaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contabancariaww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_AgenciaId )
      {
         this.AV7AgenciaId = aP0_AgenciaId;
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
         cmbavGridactiongroup1 = new GXCombobox();
         cmbContaBancariaStatus = new GXCombobox();
         cmbContaBancariaRegistraBoletos = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AgenciaId");
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
               gxfirstwebparm = GetFirstPar( "AgenciaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AgenciaId");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV16FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero1"), "."), 18, MidpointRounding.ToEven));
         AV20AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero1"), "."), 18, MidpointRounding.ToEven));
         AV21ContaBancariaCreatedByName1 = GetPar( "ContaBancariaCreatedByName1");
         AV22ContaBancariaUpdatedByName1 = GetPar( "ContaBancariaUpdatedByName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV26ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero2"), "."), 18, MidpointRounding.ToEven));
         AV27AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero2"), "."), 18, MidpointRounding.ToEven));
         AV28ContaBancariaCreatedByName2 = GetPar( "ContaBancariaCreatedByName2");
         AV29ContaBancariaUpdatedByName2 = GetPar( "ContaBancariaUpdatedByName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV31DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV32DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV33ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero3"), "."), 18, MidpointRounding.ToEven));
         AV34AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero3"), "."), 18, MidpointRounding.ToEven));
         AV35ContaBancariaCreatedByName3 = GetPar( "ContaBancariaCreatedByName3");
         AV36ContaBancariaUpdatedByName3 = GetPar( "ContaBancariaUpdatedByName3");
         AV7AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
         AV44ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV23DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV30DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV82Pgmname = GetPar( "Pgmname");
         AV76TFAgenciaBancoNome = GetPar( "TFAgenciaBancoNome");
         AV77TFAgenciaBancoNome_Sel = GetPar( "TFAgenciaBancoNome_Sel");
         AV47TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero"), "."), 18, MidpointRounding.ToEven));
         AV48TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero_To"), "."), 18, MidpointRounding.ToEven));
         AV49TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaNumero"), "."), 18, MidpointRounding.ToEven));
         AV50TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaNumero_To"), "."), 18, MidpointRounding.ToEven));
         AV80TFContaBancariaDigito = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaDigito"), "."), 18, MidpointRounding.ToEven));
         AV81TFContaBancariaDigito_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaDigito_To"), "."), 18, MidpointRounding.ToEven));
         AV51TFContaBancariaCarteira = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaCarteira"), "."), 18, MidpointRounding.ToEven));
         AV52TFContaBancariaCarteira_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaCarteira_To"), "."), 18, MidpointRounding.ToEven));
         AV53TFContaBancariaStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV54TFContaBancariaCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFContaBancariaCreatedAt"));
         AV55TFContaBancariaCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFContaBancariaCreatedAt_To"));
         AV59TFContaBancariaCreatedByName = GetPar( "TFContaBancariaCreatedByName");
         AV60TFContaBancariaCreatedByName_Sel = GetPar( "TFContaBancariaCreatedByName_Sel");
         AV61TFContaBancariaUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFContaBancariaUpdatedAt"));
         AV62TFContaBancariaUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFContaBancariaUpdatedAt_To"));
         AV66TFContaBancariaUpdatedByName = GetPar( "TFContaBancariaUpdatedByName");
         AV67TFContaBancariaUpdatedByName_Sel = GetPar( "TFContaBancariaUpdatedByName_Sel");
         AV79TFContaBancariaRegistraBoletos_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContaBancariaRegistraBoletos_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV38DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV37DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV124Bancoid = (int)(Math.Round(NumberUtil.Val( GetPar( "Bancoid"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
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
         PA9K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9K2( ) ;
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
         GXEncryptionTmp = "contabancariaww"+UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabancariaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV124Bancoid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV124Bancoid), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20AgenciaNumero1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIACREATEDBYNAME1", AV21ContaBancariaCreatedByName1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIAUPDATEDBYNAME1", AV22ContaBancariaUpdatedByName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV24DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ContaBancariaNumero2), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27AgenciaNumero2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIACREATEDBYNAME2", AV28ContaBancariaCreatedByName2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIAUPDATEDBYNAME2", AV29ContaBancariaUpdatedByName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV31DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ContaBancariaNumero3), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34AgenciaNumero3), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIACREATEDBYNAME3", AV35ContaBancariaCreatedByName3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIAUPDATEDBYNAME3", AV36ContaBancariaUpdatedByName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_137", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_137), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV42ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV42ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV72GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CONTABANCARIACREATEDATAUXDATE", context.localUtil.DToC( AV56DDO_ContaBancariaCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTABANCARIACREATEDATAUXDATETO", context.localUtil.DToC( AV57DDO_ContaBancariaCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTABANCARIAUPDATEDATAUXDATE", context.localUtil.DToC( AV63DDO_ContaBancariaUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTABANCARIAUPDATEDATAUXDATETO", context.localUtil.DToC( AV64DDO_ContaBancariaUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV23DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV30DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME", AV76TFAgenciaBancoNome);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME_SEL", AV77TFAgenciaBancoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFAgenciaNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFAgenciaNumero_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFContaBancariaNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIANUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFContaBancariaNumero_To), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIADIGITO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80TFContaBancariaDigito), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIADIGITO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81TFContaBancariaDigito_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACARTEIRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFContaBancariaCarteira), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACARTEIRA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIASTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACREATEDAT", context.localUtil.TToC( AV54TFContaBancariaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACREATEDAT_TO", context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACREATEDBYNAME", AV59TFContaBancariaCreatedByName);
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIACREATEDBYNAME_SEL", AV60TFContaBancariaCreatedByName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIAUPDATEDAT", context.localUtil.TToC( AV61TFContaBancariaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIAUPDATEDAT_TO", context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIAUPDATEDBYNAME", AV66TFContaBancariaUpdatedByName);
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIAUPDATEDBYNAME_SEL", AV67TFContaBancariaUpdatedByName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCONTABANCARIAREGISTRABOLETOS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV38DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV37DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV124Bancoid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV124Bancoid), "ZZZZZZZZ9"), context));
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
            WE9K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9K2( ) ;
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
         GXEncryptionTmp = "contabancariaww"+UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0));
         return formatLink("contabancariaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ContaBancariaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Conta Bancaria" ;
      }

      protected void WB9K0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancariaWW.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancariaWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV42ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ContaBancariaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV17DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_48_9K2( true) ;
         }
         else
         {
            wb_table1_48_9K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_9K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_79_9K2( true) ;
         }
         else
         {
            wb_table2_79_9K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_79_9K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV31DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_110_9K2( true) ;
         }
         else
         {
            wb_table3_110_9K2( false) ;
         }
         return  ;
      }

      protected void wb_table3_110_9K2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV70GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV71GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV72GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ContaBancariaWW.htm");
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_contabancariacreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_contabancariacreatedatauxdatetext_Internalname, AV58DDO_ContaBancariaCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV58DDO_ContaBancariaCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_contabancariacreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            /* User Defined Control */
            ucTfcontabancariacreatedat_rangepicker.SetProperty("Start Date", AV56DDO_ContaBancariaCreatedAtAuxDate);
            ucTfcontabancariacreatedat_rangepicker.SetProperty("End Date", AV57DDO_ContaBancariaCreatedAtAuxDateTo);
            ucTfcontabancariacreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfcontabancariacreatedat_rangepicker_Internalname, "TFCONTABANCARIACREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_contabancariaupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_contabancariaupdatedatauxdatetext_Internalname, AV65DDO_ContaBancariaUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV65DDO_ContaBancariaUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_contabancariaupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            /* User Defined Control */
            ucTfcontabancariaupdatedat_rangepicker.SetProperty("Start Date", AV63DDO_ContaBancariaUpdatedAtAuxDate);
            ucTfcontabancariaupdatedat_rangepicker.SetProperty("End Date", AV64DDO_ContaBancariaUpdatedAtAuxDateTo);
            ucTfcontabancariaupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfcontabancariaupdatedat_rangepicker_Internalname, "TFCONTABANCARIAUPDATEDAT_RANGEPICKERContainer");
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

      protected void START9K2( )
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
         Form.Meta.addItem("description", " Conta Bancaria", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9K0( ) ;
      }

      protected void WS9K2( )
      {
         START9K2( ) ;
         EVT9K2( ) ;
      }

      protected void EVT9K2( )
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
                              E119K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E209K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E229K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249K2 ();
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
                              AV78GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV78GridActionGroup1), 4, 0));
                              A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n938AgenciaId = false;
                              A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
                              n969AgenciaBancoNome = false;
                              A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n939AgenciaNumero = false;
                              A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n952ContaBancariaNumero = false;
                              A975ContaBancariaDigito = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaDigito_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n975ContaBancariaDigito = false;
                              A953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n953ContaBancariaCarteira = false;
                              cmbContaBancariaStatus.Name = cmbContaBancariaStatus_Internalname;
                              cmbContaBancariaStatus.CurrentValue = cgiGet( cmbContaBancariaStatus_Internalname);
                              A956ContaBancariaStatus = StringUtil.StrToBool( cgiGet( cmbContaBancariaStatus_Internalname));
                              n956ContaBancariaStatus = false;
                              A954ContaBancariaCreatedAt = context.localUtil.CToT( cgiGet( edtContaBancariaCreatedAt_Internalname), 0);
                              n954ContaBancariaCreatedAt = false;
                              A947ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n947ContaBancariaCreatedBy = false;
                              A948ContaBancariaCreatedByName = StringUtil.Upper( cgiGet( edtContaBancariaCreatedByName_Internalname));
                              n948ContaBancariaCreatedByName = false;
                              A955ContaBancariaUpdatedAt = context.localUtil.CToT( cgiGet( edtContaBancariaUpdatedAt_Internalname), 0);
                              n955ContaBancariaUpdatedAt = false;
                              A949ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaUpdatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n949ContaBancariaUpdatedBy = false;
                              A950ContaBancariaUpdatedByName = StringUtil.Upper( cgiGet( edtContaBancariaUpdatedByName_Internalname));
                              n950ContaBancariaUpdatedByName = false;
                              cmbContaBancariaRegistraBoletos.Name = cmbContaBancariaRegistraBoletos_Internalname;
                              cmbContaBancariaRegistraBoletos.CurrentValue = cgiGet( cmbContaBancariaRegistraBoletos_Internalname);
                              A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cgiGet( cmbContaBancariaRegistraBoletos_Internalname));
                              n973ContaBancariaRegistraBoletos = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E259K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E269K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E279K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E289K2 ();
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
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
                                       /* Set Refresh If Contabancarianumero1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Agencianumero1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO1"), ",", ".") != Convert.ToDecimal( AV20AgenciaNumero1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariacreatedbyname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME1"), AV21ContaBancariaCreatedByName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariaupdatedbyname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME1"), AV22ContaBancariaUpdatedByName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV26ContaBancariaNumero2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Agencianumero2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO2"), ",", ".") != Convert.ToDecimal( AV27AgenciaNumero2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariacreatedbyname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME2"), AV28ContaBancariaCreatedByName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariaupdatedbyname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME2"), AV29ContaBancariaUpdatedByName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV31DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV32DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV33ContaBancariaNumero3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Agencianumero3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO3"), ",", ".") != Convert.ToDecimal( AV34AgenciaNumero3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariacreatedbyname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME3"), AV35ContaBancariaCreatedByName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancariaupdatedbyname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME3"), AV36ContaBancariaUpdatedByName3) != 0 )
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

      protected void WE9K2( )
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

      protected void PA9K2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabancariaww")), "contabancariaww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabancariaww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "AgenciaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7AgenciaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7AgenciaId", StringUtil.LTrimStr( (decimal)(AV7AgenciaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
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
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       long AV19ContaBancariaNumero1 ,
                                       int AV20AgenciaNumero1 ,
                                       string AV21ContaBancariaCreatedByName1 ,
                                       string AV22ContaBancariaUpdatedByName1 ,
                                       string AV24DynamicFiltersSelector2 ,
                                       short AV25DynamicFiltersOperator2 ,
                                       long AV26ContaBancariaNumero2 ,
                                       int AV27AgenciaNumero2 ,
                                       string AV28ContaBancariaCreatedByName2 ,
                                       string AV29ContaBancariaUpdatedByName2 ,
                                       string AV31DynamicFiltersSelector3 ,
                                       short AV32DynamicFiltersOperator3 ,
                                       long AV33ContaBancariaNumero3 ,
                                       int AV34AgenciaNumero3 ,
                                       string AV35ContaBancariaCreatedByName3 ,
                                       string AV36ContaBancariaUpdatedByName3 ,
                                       int AV7AgenciaId ,
                                       short AV44ManageFiltersExecutionStep ,
                                       bool AV23DynamicFiltersEnabled2 ,
                                       bool AV30DynamicFiltersEnabled3 ,
                                       string AV82Pgmname ,
                                       string AV76TFAgenciaBancoNome ,
                                       string AV77TFAgenciaBancoNome_Sel ,
                                       int AV47TFAgenciaNumero ,
                                       int AV48TFAgenciaNumero_To ,
                                       long AV49TFContaBancariaNumero ,
                                       long AV50TFContaBancariaNumero_To ,
                                       short AV80TFContaBancariaDigito ,
                                       short AV81TFContaBancariaDigito_To ,
                                       long AV51TFContaBancariaCarteira ,
                                       long AV52TFContaBancariaCarteira_To ,
                                       short AV53TFContaBancariaStatus_Sel ,
                                       DateTime AV54TFContaBancariaCreatedAt ,
                                       DateTime AV55TFContaBancariaCreatedAt_To ,
                                       string AV59TFContaBancariaCreatedByName ,
                                       string AV60TFContaBancariaCreatedByName_Sel ,
                                       DateTime AV61TFContaBancariaUpdatedAt ,
                                       DateTime AV62TFContaBancariaUpdatedAt_To ,
                                       string AV66TFContaBancariaUpdatedByName ,
                                       string AV67TFContaBancariaUpdatedByName_Sel ,
                                       short AV79TFContaBancariaRegistraBoletos_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV38DynamicFiltersIgnoreFirst ,
                                       bool AV37DynamicFiltersRemoving ,
                                       int AV124Bancoid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV31DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV31DynamicFiltersSelector3);
            AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV32DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV82Pgmname = "ContaBancariaWW";
      }

      protected void RF9K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 137;
         /* Execute user event: Refresh */
         E269K2 ();
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
                                                 AV83Contabancariawwds_1_filterfulltext ,
                                                 AV84Contabancariawwds_2_dynamicfiltersselector1 ,
                                                 AV85Contabancariawwds_3_dynamicfiltersoperator1 ,
                                                 AV86Contabancariawwds_4_contabancarianumero1 ,
                                                 AV87Contabancariawwds_5_agencianumero1 ,
                                                 AV88Contabancariawwds_6_contabancariacreatedbyname1 ,
                                                 AV89Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                                 AV90Contabancariawwds_8_dynamicfiltersenabled2 ,
                                                 AV91Contabancariawwds_9_dynamicfiltersselector2 ,
                                                 AV92Contabancariawwds_10_dynamicfiltersoperator2 ,
                                                 AV93Contabancariawwds_11_contabancarianumero2 ,
                                                 AV94Contabancariawwds_12_agencianumero2 ,
                                                 AV95Contabancariawwds_13_contabancariacreatedbyname2 ,
                                                 AV96Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                                 AV97Contabancariawwds_15_dynamicfiltersenabled3 ,
                                                 AV98Contabancariawwds_16_dynamicfiltersselector3 ,
                                                 AV99Contabancariawwds_17_dynamicfiltersoperator3 ,
                                                 AV100Contabancariawwds_18_contabancarianumero3 ,
                                                 AV101Contabancariawwds_19_agencianumero3 ,
                                                 AV102Contabancariawwds_20_contabancariacreatedbyname3 ,
                                                 AV103Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                                 AV105Contabancariawwds_23_tfagenciabanconome_sel ,
                                                 AV104Contabancariawwds_22_tfagenciabanconome ,
                                                 AV106Contabancariawwds_24_tfagencianumero ,
                                                 AV107Contabancariawwds_25_tfagencianumero_to ,
                                                 AV108Contabancariawwds_26_tfcontabancarianumero ,
                                                 AV109Contabancariawwds_27_tfcontabancarianumero_to ,
                                                 AV110Contabancariawwds_28_tfcontabancariadigito ,
                                                 AV111Contabancariawwds_29_tfcontabancariadigito_to ,
                                                 AV112Contabancariawwds_30_tfcontabancariacarteira ,
                                                 AV113Contabancariawwds_31_tfcontabancariacarteira_to ,
                                                 AV114Contabancariawwds_32_tfcontabancariastatus_sel ,
                                                 AV115Contabancariawwds_33_tfcontabancariacreatedat ,
                                                 AV116Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                                 AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                                 AV117Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                                 AV119Contabancariawwds_37_tfcontabancariaupdatedat ,
                                                 AV120Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                                 AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                                 AV121Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                                 AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                                 AV7AgenciaId ,
                                                 A969AgenciaBancoNome ,
                                                 A939AgenciaNumero ,
                                                 A952ContaBancariaNumero ,
                                                 A975ContaBancariaDigito ,
                                                 A953ContaBancariaCarteira ,
                                                 A956ContaBancariaStatus ,
                                                 A948ContaBancariaCreatedByName ,
                                                 A950ContaBancariaUpdatedByName ,
                                                 A973ContaBancariaRegistraBoletos ,
                                                 A954ContaBancariaCreatedAt ,
                                                 A955ContaBancariaUpdatedAt ,
                                                 A938AgenciaId ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
            lV88Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
            lV88Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
            lV89Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
            lV89Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
            lV95Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
            lV95Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
            lV96Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
            lV96Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
            lV102Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
            lV102Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
            lV103Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
            lV103Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
            lV104Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV104Contabancariawwds_22_tfagenciabanconome), "%", "");
            lV117Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV117Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
            lV121Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV121Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
            /* Using cursor H009K2 */
            pr_default.execute(0, new Object[] {lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, AV86Contabancariawwds_4_contabancarianumero1, AV86Contabancariawwds_4_contabancarianumero1, AV86Contabancariawwds_4_contabancarianumero1, AV87Contabancariawwds_5_agencianumero1, AV87Contabancariawwds_5_agencianumero1, AV87Contabancariawwds_5_agencianumero1, lV88Contabancariawwds_6_contabancariacreatedbyname1, lV88Contabancariawwds_6_contabancariacreatedbyname1, lV89Contabancariawwds_7_contabancariaupdatedbyname1, lV89Contabancariawwds_7_contabancariaupdatedbyname1, AV93Contabancariawwds_11_contabancarianumero2, AV93Contabancariawwds_11_contabancarianumero2, AV93Contabancariawwds_11_contabancarianumero2, AV94Contabancariawwds_12_agencianumero2, AV94Contabancariawwds_12_agencianumero2, AV94Contabancariawwds_12_agencianumero2, lV95Contabancariawwds_13_contabancariacreatedbyname2, lV95Contabancariawwds_13_contabancariacreatedbyname2, lV96Contabancariawwds_14_contabancariaupdatedbyname2, lV96Contabancariawwds_14_contabancariaupdatedbyname2, AV100Contabancariawwds_18_contabancarianumero3, AV100Contabancariawwds_18_contabancarianumero3, AV100Contabancariawwds_18_contabancarianumero3, AV101Contabancariawwds_19_agencianumero3, AV101Contabancariawwds_19_agencianumero3, AV101Contabancariawwds_19_agencianumero3, lV102Contabancariawwds_20_contabancariacreatedbyname3, lV102Contabancariawwds_20_contabancariacreatedbyname3, lV103Contabancariawwds_21_contabancariaupdatedbyname3, lV103Contabancariawwds_21_contabancariaupdatedbyname3, lV104Contabancariawwds_22_tfagenciabanconome, AV105Contabancariawwds_23_tfagenciabanconome_sel, AV106Contabancariawwds_24_tfagencianumero, AV107Contabancariawwds_25_tfagencianumero_to, AV108Contabancariawwds_26_tfcontabancarianumero, AV109Contabancariawwds_27_tfcontabancarianumero_to, AV110Contabancariawwds_28_tfcontabancariadigito, AV111Contabancariawwds_29_tfcontabancariadigito_to, AV112Contabancariawwds_30_tfcontabancariacarteira, AV113Contabancariawwds_31_tfcontabancariacarteira_to, AV115Contabancariawwds_33_tfcontabancariacreatedat, AV116Contabancariawwds_34_tfcontabancariacreatedat_to, lV117Contabancariawwds_35_tfcontabancariacreatedbyname, AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV119Contabancariawwds_37_tfcontabancariaupdatedat, AV120Contabancariawwds_38_tfcontabancariaupdatedat_to, lV121Contabancariawwds_39_tfcontabancariaupdatedbyname, AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV7AgenciaId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_137_idx = 1;
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A968AgenciaBancoId = H009K2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H009K2_n968AgenciaBancoId[0];
               A973ContaBancariaRegistraBoletos = H009K2_A973ContaBancariaRegistraBoletos[0];
               n973ContaBancariaRegistraBoletos = H009K2_n973ContaBancariaRegistraBoletos[0];
               A950ContaBancariaUpdatedByName = H009K2_A950ContaBancariaUpdatedByName[0];
               n950ContaBancariaUpdatedByName = H009K2_n950ContaBancariaUpdatedByName[0];
               A949ContaBancariaUpdatedBy = H009K2_A949ContaBancariaUpdatedBy[0];
               n949ContaBancariaUpdatedBy = H009K2_n949ContaBancariaUpdatedBy[0];
               A955ContaBancariaUpdatedAt = H009K2_A955ContaBancariaUpdatedAt[0];
               n955ContaBancariaUpdatedAt = H009K2_n955ContaBancariaUpdatedAt[0];
               A948ContaBancariaCreatedByName = H009K2_A948ContaBancariaCreatedByName[0];
               n948ContaBancariaCreatedByName = H009K2_n948ContaBancariaCreatedByName[0];
               A947ContaBancariaCreatedBy = H009K2_A947ContaBancariaCreatedBy[0];
               n947ContaBancariaCreatedBy = H009K2_n947ContaBancariaCreatedBy[0];
               A954ContaBancariaCreatedAt = H009K2_A954ContaBancariaCreatedAt[0];
               n954ContaBancariaCreatedAt = H009K2_n954ContaBancariaCreatedAt[0];
               A956ContaBancariaStatus = H009K2_A956ContaBancariaStatus[0];
               n956ContaBancariaStatus = H009K2_n956ContaBancariaStatus[0];
               A953ContaBancariaCarteira = H009K2_A953ContaBancariaCarteira[0];
               n953ContaBancariaCarteira = H009K2_n953ContaBancariaCarteira[0];
               A975ContaBancariaDigito = H009K2_A975ContaBancariaDigito[0];
               n975ContaBancariaDigito = H009K2_n975ContaBancariaDigito[0];
               A952ContaBancariaNumero = H009K2_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H009K2_n952ContaBancariaNumero[0];
               A939AgenciaNumero = H009K2_A939AgenciaNumero[0];
               n939AgenciaNumero = H009K2_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H009K2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009K2_n969AgenciaBancoNome[0];
               A938AgenciaId = H009K2_A938AgenciaId[0];
               n938AgenciaId = H009K2_n938AgenciaId[0];
               A951ContaBancariaId = H009K2_A951ContaBancariaId[0];
               A950ContaBancariaUpdatedByName = H009K2_A950ContaBancariaUpdatedByName[0];
               n950ContaBancariaUpdatedByName = H009K2_n950ContaBancariaUpdatedByName[0];
               A948ContaBancariaCreatedByName = H009K2_A948ContaBancariaCreatedByName[0];
               n948ContaBancariaCreatedByName = H009K2_n948ContaBancariaCreatedByName[0];
               A968AgenciaBancoId = H009K2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H009K2_n968AgenciaBancoId[0];
               A939AgenciaNumero = H009K2_A939AgenciaNumero[0];
               n939AgenciaNumero = H009K2_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H009K2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009K2_n969AgenciaBancoNome[0];
               /* Execute user event: Grid.Load */
               E279K2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 137;
            WB9K0( ) ;
         }
         bGXsfl_137_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9K2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV124Bancoid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV124Bancoid), "ZZZZZZZZ9"), context));
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
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV83Contabancariawwds_1_filterfulltext ,
                                              AV84Contabancariawwds_2_dynamicfiltersselector1 ,
                                              AV85Contabancariawwds_3_dynamicfiltersoperator1 ,
                                              AV86Contabancariawwds_4_contabancarianumero1 ,
                                              AV87Contabancariawwds_5_agencianumero1 ,
                                              AV88Contabancariawwds_6_contabancariacreatedbyname1 ,
                                              AV89Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                              AV90Contabancariawwds_8_dynamicfiltersenabled2 ,
                                              AV91Contabancariawwds_9_dynamicfiltersselector2 ,
                                              AV92Contabancariawwds_10_dynamicfiltersoperator2 ,
                                              AV93Contabancariawwds_11_contabancarianumero2 ,
                                              AV94Contabancariawwds_12_agencianumero2 ,
                                              AV95Contabancariawwds_13_contabancariacreatedbyname2 ,
                                              AV96Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                              AV97Contabancariawwds_15_dynamicfiltersenabled3 ,
                                              AV98Contabancariawwds_16_dynamicfiltersselector3 ,
                                              AV99Contabancariawwds_17_dynamicfiltersoperator3 ,
                                              AV100Contabancariawwds_18_contabancarianumero3 ,
                                              AV101Contabancariawwds_19_agencianumero3 ,
                                              AV102Contabancariawwds_20_contabancariacreatedbyname3 ,
                                              AV103Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                              AV105Contabancariawwds_23_tfagenciabanconome_sel ,
                                              AV104Contabancariawwds_22_tfagenciabanconome ,
                                              AV106Contabancariawwds_24_tfagencianumero ,
                                              AV107Contabancariawwds_25_tfagencianumero_to ,
                                              AV108Contabancariawwds_26_tfcontabancarianumero ,
                                              AV109Contabancariawwds_27_tfcontabancarianumero_to ,
                                              AV110Contabancariawwds_28_tfcontabancariadigito ,
                                              AV111Contabancariawwds_29_tfcontabancariadigito_to ,
                                              AV112Contabancariawwds_30_tfcontabancariacarteira ,
                                              AV113Contabancariawwds_31_tfcontabancariacarteira_to ,
                                              AV114Contabancariawwds_32_tfcontabancariastatus_sel ,
                                              AV115Contabancariawwds_33_tfcontabancariacreatedat ,
                                              AV116Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                              AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                              AV117Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                              AV119Contabancariawwds_37_tfcontabancariaupdatedat ,
                                              AV120Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                              AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                              AV121Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                              AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                              AV7AgenciaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A975ContaBancariaDigito ,
                                              A953ContaBancariaCarteira ,
                                              A956ContaBancariaStatus ,
                                              A948ContaBancariaCreatedByName ,
                                              A950ContaBancariaUpdatedByName ,
                                              A973ContaBancariaRegistraBoletos ,
                                              A954ContaBancariaCreatedAt ,
                                              A955ContaBancariaUpdatedAt ,
                                              A938AgenciaId ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext), "%", "");
         lV88Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV88Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV89Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV89Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV95Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV95Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV96Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV96Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV102Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV102Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV103Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV103Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV104Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV104Contabancariawwds_22_tfagenciabanconome), "%", "");
         lV117Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV117Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
         lV121Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV121Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
         /* Using cursor H009K3 */
         pr_default.execute(1, new Object[] {lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, lV83Contabancariawwds_1_filterfulltext, AV86Contabancariawwds_4_contabancarianumero1, AV86Contabancariawwds_4_contabancarianumero1, AV86Contabancariawwds_4_contabancarianumero1, AV87Contabancariawwds_5_agencianumero1, AV87Contabancariawwds_5_agencianumero1, AV87Contabancariawwds_5_agencianumero1, lV88Contabancariawwds_6_contabancariacreatedbyname1, lV88Contabancariawwds_6_contabancariacreatedbyname1, lV89Contabancariawwds_7_contabancariaupdatedbyname1, lV89Contabancariawwds_7_contabancariaupdatedbyname1, AV93Contabancariawwds_11_contabancarianumero2, AV93Contabancariawwds_11_contabancarianumero2, AV93Contabancariawwds_11_contabancarianumero2, AV94Contabancariawwds_12_agencianumero2, AV94Contabancariawwds_12_agencianumero2, AV94Contabancariawwds_12_agencianumero2, lV95Contabancariawwds_13_contabancariacreatedbyname2, lV95Contabancariawwds_13_contabancariacreatedbyname2, lV96Contabancariawwds_14_contabancariaupdatedbyname2, lV96Contabancariawwds_14_contabancariaupdatedbyname2, AV100Contabancariawwds_18_contabancarianumero3, AV100Contabancariawwds_18_contabancarianumero3, AV100Contabancariawwds_18_contabancarianumero3, AV101Contabancariawwds_19_agencianumero3, AV101Contabancariawwds_19_agencianumero3, AV101Contabancariawwds_19_agencianumero3, lV102Contabancariawwds_20_contabancariacreatedbyname3, lV102Contabancariawwds_20_contabancariacreatedbyname3, lV103Contabancariawwds_21_contabancariaupdatedbyname3, lV103Contabancariawwds_21_contabancariaupdatedbyname3, lV104Contabancariawwds_22_tfagenciabanconome, AV105Contabancariawwds_23_tfagenciabanconome_sel, AV106Contabancariawwds_24_tfagencianumero, AV107Contabancariawwds_25_tfagencianumero_to, AV108Contabancariawwds_26_tfcontabancarianumero, AV109Contabancariawwds_27_tfcontabancarianumero_to, AV110Contabancariawwds_28_tfcontabancariadigito, AV111Contabancariawwds_29_tfcontabancariadigito_to, AV112Contabancariawwds_30_tfcontabancariacarteira, AV113Contabancariawwds_31_tfcontabancariacarteira_to, AV115Contabancariawwds_33_tfcontabancariacreatedat, AV116Contabancariawwds_34_tfcontabancariacreatedat_to, lV117Contabancariawwds_35_tfcontabancariacreatedbyname, AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV119Contabancariawwds_37_tfcontabancariaupdatedat, AV120Contabancariawwds_38_tfcontabancariaupdatedat_to, lV121Contabancariawwds_39_tfcontabancariaupdatedbyname, AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV7AgenciaId});
         GRID_nRecordCount = H009K3_AGRID_nRecordCount[0];
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
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV82Pgmname = "ContaBancariaWW";
         edtContaBancariaId_Enabled = 0;
         edtAgenciaId_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtContaBancariaDigito_Enabled = 0;
         edtContaBancariaCarteira_Enabled = 0;
         cmbContaBancariaStatus.Enabled = 0;
         edtContaBancariaCreatedAt_Enabled = 0;
         edtContaBancariaCreatedBy_Enabled = 0;
         edtContaBancariaCreatedByName_Enabled = 0;
         edtContaBancariaUpdatedAt_Enabled = 0;
         edtContaBancariaUpdatedBy_Enabled = 0;
         edtContaBancariaUpdatedByName_Enabled = 0;
         cmbContaBancariaRegistraBoletos.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E259K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV42ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV68DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_137 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_137"), ",", "."), 18, MidpointRounding.ToEven));
            AV70GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV71GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV72GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV56DDO_ContaBancariaCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CONTABANCARIACREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV56DDO_ContaBancariaCreatedAtAuxDate", context.localUtil.Format(AV56DDO_ContaBancariaCreatedAtAuxDate, "99/99/99"));
            AV57DDO_ContaBancariaCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CONTABANCARIACREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV57DDO_ContaBancariaCreatedAtAuxDateTo", context.localUtil.Format(AV57DDO_ContaBancariaCreatedAtAuxDateTo, "99/99/99"));
            AV63DDO_ContaBancariaUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CONTABANCARIAUPDATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV63DDO_ContaBancariaUpdatedAtAuxDate", context.localUtil.Format(AV63DDO_ContaBancariaUpdatedAtAuxDate, "99/99/99"));
            AV64DDO_ContaBancariaUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CONTABANCARIAUPDATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV64DDO_ContaBancariaUpdatedAtAuxDateTo", context.localUtil.Format(AV64DDO_ContaBancariaUpdatedAtAuxDateTo, "99/99/99"));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO1");
               GX_FocusControl = edtavAgencianumero1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20AgenciaNumero1 = 0;
               AssignAttri("", false, "AV20AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV20AgenciaNumero1), 9, 0));
            }
            else
            {
               AV20AgenciaNumero1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV20AgenciaNumero1), 9, 0));
            }
            AV21ContaBancariaCreatedByName1 = StringUtil.Upper( cgiGet( edtavContabancariacreatedbyname1_Internalname));
            AssignAttri("", false, "AV21ContaBancariaCreatedByName1", AV21ContaBancariaCreatedByName1);
            AV22ContaBancariaUpdatedByName1 = StringUtil.Upper( cgiGet( edtavContabancariaupdatedbyname1_Internalname));
            AssignAttri("", false, "AV22ContaBancariaUpdatedByName1", AV22ContaBancariaUpdatedByName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV24DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO2");
               GX_FocusControl = edtavAgencianumero2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27AgenciaNumero2 = 0;
               AssignAttri("", false, "AV27AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV27AgenciaNumero2), 9, 0));
            }
            else
            {
               AV27AgenciaNumero2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV27AgenciaNumero2), 9, 0));
            }
            AV28ContaBancariaCreatedByName2 = StringUtil.Upper( cgiGet( edtavContabancariacreatedbyname2_Internalname));
            AssignAttri("", false, "AV28ContaBancariaCreatedByName2", AV28ContaBancariaCreatedByName2);
            AV29ContaBancariaUpdatedByName2 = StringUtil.Upper( cgiGet( edtavContabancariaupdatedbyname2_Internalname));
            AssignAttri("", false, "AV29ContaBancariaUpdatedByName2", AV29ContaBancariaUpdatedByName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV31DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV32DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO3");
               GX_FocusControl = edtavAgencianumero3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34AgenciaNumero3 = 0;
               AssignAttri("", false, "AV34AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV34AgenciaNumero3), 9, 0));
            }
            else
            {
               AV34AgenciaNumero3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV34AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV34AgenciaNumero3), 9, 0));
            }
            AV35ContaBancariaCreatedByName3 = StringUtil.Upper( cgiGet( edtavContabancariacreatedbyname3_Internalname));
            AssignAttri("", false, "AV35ContaBancariaCreatedByName3", AV35ContaBancariaCreatedByName3);
            AV36ContaBancariaUpdatedByName3 = StringUtil.Upper( cgiGet( edtavContabancariaupdatedbyname3_Internalname));
            AssignAttri("", false, "AV36ContaBancariaUpdatedByName3", AV36ContaBancariaUpdatedByName3);
            AV58DDO_ContaBancariaCreatedAtAuxDateText = cgiGet( edtavDdo_contabancariacreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV58DDO_ContaBancariaCreatedAtAuxDateText", AV58DDO_ContaBancariaCreatedAtAuxDateText);
            AV65DDO_ContaBancariaUpdatedAtAuxDateText = cgiGet( edtavDdo_contabancariaupdatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV65DDO_ContaBancariaUpdatedAtAuxDateText", AV65DDO_ContaBancariaUpdatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO1"), ",", ".") != Convert.ToDecimal( AV20AgenciaNumero1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME1"), AV21ContaBancariaCreatedByName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME1"), AV22ContaBancariaUpdatedByName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV26ContaBancariaNumero2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO2"), ",", ".") != Convert.ToDecimal( AV27AgenciaNumero2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME2"), AV28ContaBancariaCreatedByName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME2"), AV29ContaBancariaUpdatedByName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV31DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV32DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV33ContaBancariaNumero3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO3"), ",", ".") != Convert.ToDecimal( AV34AgenciaNumero3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIACREATEDBYNAME3"), AV35ContaBancariaCreatedByName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTABANCARIAUPDATEDBYNAME3"), AV36ContaBancariaUpdatedByName3) != 0 )
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
         E259K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E259K2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCONTABANCARIAUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_contabancariaupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCONTABANCARIACREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_contabancariacreatedatauxdatetext_Internalname});
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
         AV17DynamicFiltersSelector1 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector2 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV31DynamicFiltersSelector3 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
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
         Form.Caption = " Conta Bancaria";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV68DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV68DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E269K2( )
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
         if ( AV44ManageFiltersExecutionStep == 1 )
         {
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV44ManageFiltersExecutionStep == 2 )
         {
            AV44ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV30DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 )
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
         AV70GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV70GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV70GridCurrentPage), 10, 0));
         AV71GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV71GridPageCount", StringUtil.LTrimStr( (decimal)(AV71GridPageCount), 10, 0));
         GXt_char2 = AV72GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV82Pgmname, out  GXt_char2) ;
         AV72GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV72GridAppliedFilters", AV72GridAppliedFilters);
         cmbContaBancariaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbContaBancariaStatus_Internalname, "Columnheaderclass", cmbContaBancariaStatus_Columnheaderclass, !bGXsfl_137_Refreshing);
         cmbContaBancariaRegistraBoletos_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbContaBancariaRegistraBoletos_Internalname, "Columnheaderclass", cmbContaBancariaRegistraBoletos_Columnheaderclass, !bGXsfl_137_Refreshing);
         AV83Contabancariawwds_1_filterfulltext = AV16FilterFullText;
         AV84Contabancariawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV85Contabancariawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV86Contabancariawwds_4_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV87Contabancariawwds_5_agencianumero1 = AV20AgenciaNumero1;
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = AV21ContaBancariaCreatedByName1;
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = AV22ContaBancariaUpdatedByName1;
         AV90Contabancariawwds_8_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV91Contabancariawwds_9_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV92Contabancariawwds_10_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV93Contabancariawwds_11_contabancarianumero2 = AV26ContaBancariaNumero2;
         AV94Contabancariawwds_12_agencianumero2 = AV27AgenciaNumero2;
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = AV28ContaBancariaCreatedByName2;
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = AV29ContaBancariaUpdatedByName2;
         AV97Contabancariawwds_15_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV98Contabancariawwds_16_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV99Contabancariawwds_17_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV100Contabancariawwds_18_contabancarianumero3 = AV33ContaBancariaNumero3;
         AV101Contabancariawwds_19_agencianumero3 = AV34AgenciaNumero3;
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = AV35ContaBancariaCreatedByName3;
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = AV36ContaBancariaUpdatedByName3;
         AV104Contabancariawwds_22_tfagenciabanconome = AV76TFAgenciaBancoNome;
         AV105Contabancariawwds_23_tfagenciabanconome_sel = AV77TFAgenciaBancoNome_Sel;
         AV106Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV107Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV108Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV109Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV110Contabancariawwds_28_tfcontabancariadigito = AV80TFContaBancariaDigito;
         AV111Contabancariawwds_29_tfcontabancariadigito_to = AV81TFContaBancariaDigito_To;
         AV112Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV113Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV114Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV115Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = AV59TFContaBancariaCreatedByName;
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV60TFContaBancariaCreatedByName_Sel;
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = AV61TFContaBancariaUpdatedAt;
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = AV62TFContaBancariaUpdatedAt_To;
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = AV66TFContaBancariaUpdatedByName;
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV67TFContaBancariaUpdatedByName_Sel;
         AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV79TFContaBancariaRegistraBoletos_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E129K2( )
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
            AV69PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV69PageToGo) ;
         }
      }

      protected void E139K2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149K2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaBancoNome") == 0 )
            {
               AV76TFAgenciaBancoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV76TFAgenciaBancoNome", AV76TFAgenciaBancoNome);
               AV77TFAgenciaBancoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV77TFAgenciaBancoNome_Sel", AV77TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaNumero") == 0 )
            {
               AV47TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaNumero), 9, 0));
               AV48TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV48TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaNumero") == 0 )
            {
               AV49TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV49TFContaBancariaNumero), 18, 0));
               AV50TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV50TFContaBancariaNumero_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaDigito") == 0 )
            {
               AV80TFContaBancariaDigito = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV80TFContaBancariaDigito", StringUtil.LTrimStr( (decimal)(AV80TFContaBancariaDigito), 4, 0));
               AV81TFContaBancariaDigito_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFContaBancariaDigito_To", StringUtil.LTrimStr( (decimal)(AV81TFContaBancariaDigito_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaCarteira") == 0 )
            {
               AV51TFContaBancariaCarteira = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFContaBancariaCarteira", StringUtil.LTrimStr( (decimal)(AV51TFContaBancariaCarteira), 10, 0));
               AV52TFContaBancariaCarteira_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFContaBancariaCarteira_To", StringUtil.LTrimStr( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaStatus") == 0 )
            {
               AV53TFContaBancariaStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV53TFContaBancariaStatus_Sel", StringUtil.Str( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaCreatedAt") == 0 )
            {
               AV54TFContaBancariaCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV54TFContaBancariaCreatedAt", context.localUtil.TToC( AV54TFContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV55TFContaBancariaCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV55TFContaBancariaCreatedAt_To", context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV55TFContaBancariaCreatedAt_To) )
               {
                  AV55TFContaBancariaCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV55TFContaBancariaCreatedAt_To)), (short)(DateTimeUtil.Month( AV55TFContaBancariaCreatedAt_To)), (short)(DateTimeUtil.Day( AV55TFContaBancariaCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV55TFContaBancariaCreatedAt_To", context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaCreatedByName") == 0 )
            {
               AV59TFContaBancariaCreatedByName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV59TFContaBancariaCreatedByName", AV59TFContaBancariaCreatedByName);
               AV60TFContaBancariaCreatedByName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFContaBancariaCreatedByName_Sel", AV60TFContaBancariaCreatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaUpdatedAt") == 0 )
            {
               AV61TFContaBancariaUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV61TFContaBancariaUpdatedAt", context.localUtil.TToC( AV61TFContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV62TFContaBancariaUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV62TFContaBancariaUpdatedAt_To", context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV62TFContaBancariaUpdatedAt_To) )
               {
                  AV62TFContaBancariaUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV62TFContaBancariaUpdatedAt_To)), (short)(DateTimeUtil.Month( AV62TFContaBancariaUpdatedAt_To)), (short)(DateTimeUtil.Day( AV62TFContaBancariaUpdatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV62TFContaBancariaUpdatedAt_To", context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaUpdatedByName") == 0 )
            {
               AV66TFContaBancariaUpdatedByName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFContaBancariaUpdatedByName", AV66TFContaBancariaUpdatedByName);
               AV67TFContaBancariaUpdatedByName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFContaBancariaUpdatedByName_Sel", AV67TFContaBancariaUpdatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContaBancariaRegistraBoletos") == 0 )
            {
               AV79TFContaBancariaRegistraBoletos_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV79TFContaBancariaRegistraBoletos_Sel", StringUtil.Str( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E279K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Chaves PIX", "fas fa-key", "", "", "", "", "", "", ""), 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A938AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV124Bancoid,9,0));
         edtAgenciaNumero_Link = formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A951ContaBancariaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0));
         edtContaBancariaNumero_Link = formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A947ContaBancariaCreatedBy,4,0));
         edtContaBancariaCreatedByName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A949ContaBancariaUpdatedBy,4,0));
         edtContaBancariaUpdatedByName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "true") == 0 )
         {
            cmbContaBancariaStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "false") == 0 )
         {
            cmbContaBancariaStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else
         {
            cmbContaBancariaStatus_Columnclass = "WWColumn";
         }
         cmbContaBancariaRegistraBoletos_Columnclass = ((StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)), "true")==0) ? "WWColumn WWColumnSuccess WWColumnSuccessSingleCell" : "WWColumn");
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
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0));
      }

      protected void E209K2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E159K2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV37DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         AV38DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV38DynamicFiltersIgnoreFirst", AV38DynamicFiltersIgnoreFirst);
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
         AV37DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         AV38DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV38DynamicFiltersIgnoreFirst", AV38DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E219K2( )
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

      protected void E229K2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV30DynamicFiltersEnabled3", AV30DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E169K2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV37DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
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
         AV37DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E239K2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179K2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV37DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         AV30DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV30DynamicFiltersEnabled3", AV30DynamicFiltersEnabled3);
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
         AV37DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV37DynamicFiltersRemoving", AV37DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContaBancariaNumero1, AV20AgenciaNumero1, AV21ContaBancariaCreatedByName1, AV22ContaBancariaUpdatedByName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26ContaBancariaNumero2, AV27AgenciaNumero2, AV28ContaBancariaCreatedByName2, AV29ContaBancariaUpdatedByName2, AV31DynamicFiltersSelector3, AV32DynamicFiltersOperator3, AV33ContaBancariaNumero3, AV34AgenciaNumero3, AV35ContaBancariaCreatedByName3, AV36ContaBancariaUpdatedByName3, AV7AgenciaId, AV44ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV30DynamicFiltersEnabled3, AV82Pgmname, AV76TFAgenciaBancoNome, AV77TFAgenciaBancoNome_Sel, AV47TFAgenciaNumero, AV48TFAgenciaNumero_To, AV49TFContaBancariaNumero, AV50TFContaBancariaNumero_To, AV80TFContaBancariaDigito, AV81TFContaBancariaDigito_To, AV51TFContaBancariaCarteira, AV52TFContaBancariaCarteira_To, AV53TFContaBancariaStatus_Sel, AV54TFContaBancariaCreatedAt, AV55TFContaBancariaCreatedAt_To, AV59TFContaBancariaCreatedByName, AV60TFContaBancariaCreatedByName_Sel, AV61TFContaBancariaUpdatedAt, AV62TFContaBancariaUpdatedAt_To, AV66TFContaBancariaUpdatedByName, AV67TFContaBancariaUpdatedByName_Sel, AV79TFContaBancariaRegistraBoletos_Sel, AV11GridState, AV38DynamicFiltersIgnoreFirst, AV37DynamicFiltersRemoving, AV124Bancoid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E249K2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV32DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119K2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ContaBancariaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV82Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ContaBancariaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV43ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ContaBancariaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV43ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV43ManageFiltersXml) ;
               AV11GridState.FromXml(AV43ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV31DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E289K2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV78GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV78GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO USERACTION1' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV78GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV78GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E189K2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0));
         context.PopUp(formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E199K2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new contabancariawwexport(context ).execute( out  AV39ExcelFilename, out  AV40ErrorMessage) ;
         if ( StringUtil.StrCmp(AV39ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV39ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV40ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! (0==AV7AgenciaId) ) )
         {
            bttBtn_cancel_Visible = 0;
            AssignProp("", false, bttBtn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_cancel_Visible), 5, 0), true);
         }
         if ( ! ( ! (0==AV7AgenciaId) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavContabancarianumero1_Visible = 0;
         AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
         edtavAgencianumero1_Visible = 0;
         AssignProp("", false, edtavAgencianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero1_Visible), 5, 0), true);
         edtavContabancariacreatedbyname1_Visible = 0;
         AssignProp("", false, edtavContabancariacreatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname1_Visible), 5, 0), true);
         edtavContabancariaupdatedbyname1_Visible = 0;
         AssignProp("", false, edtavContabancariaupdatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero1_Visible = 1;
            AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero1_Visible = 1;
            AssignProp("", false, edtavAgencianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 )
         {
            edtavContabancariacreatedbyname1_Visible = 1;
            AssignProp("", false, edtavContabancariacreatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 )
         {
            edtavContabancariaupdatedbyname1_Visible = 1;
            AssignProp("", false, edtavContabancariaupdatedbyname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavContabancarianumero2_Visible = 0;
         AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
         edtavAgencianumero2_Visible = 0;
         AssignProp("", false, edtavAgencianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero2_Visible), 5, 0), true);
         edtavContabancariacreatedbyname2_Visible = 0;
         AssignProp("", false, edtavContabancariacreatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname2_Visible), 5, 0), true);
         edtavContabancariaupdatedbyname2_Visible = 0;
         AssignProp("", false, edtavContabancariaupdatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero2_Visible = 1;
            AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero2_Visible = 1;
            AssignProp("", false, edtavAgencianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 )
         {
            edtavContabancariacreatedbyname2_Visible = 1;
            AssignProp("", false, edtavContabancariacreatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 )
         {
            edtavContabancariaupdatedbyname2_Visible = 1;
            AssignProp("", false, edtavContabancariaupdatedbyname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavContabancarianumero3_Visible = 0;
         AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
         edtavAgencianumero3_Visible = 0;
         AssignProp("", false, edtavAgencianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero3_Visible), 5, 0), true);
         edtavContabancariacreatedbyname3_Visible = 0;
         AssignProp("", false, edtavContabancariacreatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname3_Visible), 5, 0), true);
         edtavContabancariaupdatedbyname3_Visible = 0;
         AssignProp("", false, edtavContabancariaupdatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero3_Visible = 1;
            AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero3_Visible = 1;
            AssignProp("", false, edtavAgencianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 )
         {
            edtavContabancariacreatedbyname3_Visible = 1;
            AssignProp("", false, edtavContabancariacreatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariacreatedbyname3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 )
         {
            edtavContabancariaupdatedbyname3_Visible = 1;
            AssignProp("", false, edtavContabancariaupdatedbyname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancariaupdatedbyname3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         AV24DynamicFiltersSelector2 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AV26ContaBancariaNumero2 = 0;
         AssignAttri("", false, "AV26ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV26ContaBancariaNumero2), 18, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV30DynamicFiltersEnabled3", AV30DynamicFiltersEnabled3);
         AV31DynamicFiltersSelector3 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
         AV32DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         AV33ContaBancariaNumero3 = 0;
         AssignAttri("", false, "AV33ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV33ContaBancariaNumero3), 18, 0));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV42ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ContaBancariaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV42ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV76TFAgenciaBancoNome = "";
         AssignAttri("", false, "AV76TFAgenciaBancoNome", AV76TFAgenciaBancoNome);
         AV77TFAgenciaBancoNome_Sel = "";
         AssignAttri("", false, "AV77TFAgenciaBancoNome_Sel", AV77TFAgenciaBancoNome_Sel);
         AV47TFAgenciaNumero = 0;
         AssignAttri("", false, "AV47TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaNumero), 9, 0));
         AV48TFAgenciaNumero_To = 0;
         AssignAttri("", false, "AV48TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV48TFAgenciaNumero_To), 9, 0));
         AV49TFContaBancariaNumero = 0;
         AssignAttri("", false, "AV49TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV49TFContaBancariaNumero), 18, 0));
         AV50TFContaBancariaNumero_To = 0;
         AssignAttri("", false, "AV50TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV50TFContaBancariaNumero_To), 18, 0));
         AV80TFContaBancariaDigito = 0;
         AssignAttri("", false, "AV80TFContaBancariaDigito", StringUtil.LTrimStr( (decimal)(AV80TFContaBancariaDigito), 4, 0));
         AV81TFContaBancariaDigito_To = 0;
         AssignAttri("", false, "AV81TFContaBancariaDigito_To", StringUtil.LTrimStr( (decimal)(AV81TFContaBancariaDigito_To), 4, 0));
         AV51TFContaBancariaCarteira = 0;
         AssignAttri("", false, "AV51TFContaBancariaCarteira", StringUtil.LTrimStr( (decimal)(AV51TFContaBancariaCarteira), 10, 0));
         AV52TFContaBancariaCarteira_To = 0;
         AssignAttri("", false, "AV52TFContaBancariaCarteira_To", StringUtil.LTrimStr( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0));
         AV53TFContaBancariaStatus_Sel = 0;
         AssignAttri("", false, "AV53TFContaBancariaStatus_Sel", StringUtil.Str( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0));
         AV54TFContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV54TFContaBancariaCreatedAt", context.localUtil.TToC( AV54TFContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV55TFContaBancariaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV55TFContaBancariaCreatedAt_To", context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV59TFContaBancariaCreatedByName = "";
         AssignAttri("", false, "AV59TFContaBancariaCreatedByName", AV59TFContaBancariaCreatedByName);
         AV60TFContaBancariaCreatedByName_Sel = "";
         AssignAttri("", false, "AV60TFContaBancariaCreatedByName_Sel", AV60TFContaBancariaCreatedByName_Sel);
         AV61TFContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV61TFContaBancariaUpdatedAt", context.localUtil.TToC( AV61TFContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV62TFContaBancariaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV62TFContaBancariaUpdatedAt_To", context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV66TFContaBancariaUpdatedByName = "";
         AssignAttri("", false, "AV66TFContaBancariaUpdatedByName", AV66TFContaBancariaUpdatedByName);
         AV67TFContaBancariaUpdatedByName_Sel = "";
         AssignAttri("", false, "AV67TFContaBancariaUpdatedByName_Sel", AV67TFContaBancariaUpdatedByName_Sel);
         AV79TFContaBancariaRegistraBoletos_Sel = 0;
         AssignAttri("", false, "AV79TFContaBancariaRegistraBoletos_Sel", StringUtil.Str( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV17DynamicFiltersSelector1 = "CONTABANCARIANUMERO";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19ContaBancariaNumero1 = 0;
         AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
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
         AV11GridState.gxTpr_Dynamicfilters.Clear();
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
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A951ContaBancariaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0));
         context.PopUp(formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S262( )
      {
         /* 'DO USERACTION1' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "chavepixww"+UrlEncode(StringUtil.LTrimStr(A951ContaBancariaId,9,0));
         CallWebObject(formatLink("chavepixww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get(AV82Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV82Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV41Session.Get(AV82Pgmname+"GridState"), null, "", "");
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV125GXV1 = 1;
         while ( AV125GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV125GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV76TFAgenciaBancoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFAgenciaBancoNome", AV76TFAgenciaBancoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV77TFAgenciaBancoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFAgenciaBancoNome_Sel", AV77TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV47TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaNumero), 9, 0));
               AV48TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV48TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV49TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFContaBancariaNumero", StringUtil.LTrimStr( (decimal)(AV49TFContaBancariaNumero), 18, 0));
               AV50TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFContaBancariaNumero_To", StringUtil.LTrimStr( (decimal)(AV50TFContaBancariaNumero_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIADIGITO") == 0 )
            {
               AV80TFContaBancariaDigito = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV80TFContaBancariaDigito", StringUtil.LTrimStr( (decimal)(AV80TFContaBancariaDigito), 4, 0));
               AV81TFContaBancariaDigito_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFContaBancariaDigito_To", StringUtil.LTrimStr( (decimal)(AV81TFContaBancariaDigito_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACARTEIRA") == 0 )
            {
               AV51TFContaBancariaCarteira = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFContaBancariaCarteira", StringUtil.LTrimStr( (decimal)(AV51TFContaBancariaCarteira), 10, 0));
               AV52TFContaBancariaCarteira_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFContaBancariaCarteira_To", StringUtil.LTrimStr( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIASTATUS_SEL") == 0 )
            {
               AV53TFContaBancariaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV53TFContaBancariaStatus_Sel", StringUtil.Str( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDAT") == 0 )
            {
               AV54TFContaBancariaCreatedAt = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV54TFContaBancariaCreatedAt", context.localUtil.TToC( AV54TFContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV55TFContaBancariaCreatedAt_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV55TFContaBancariaCreatedAt_To", context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV56DDO_ContaBancariaCreatedAtAuxDate = DateTimeUtil.ResetTime(AV54TFContaBancariaCreatedAt);
               AssignAttri("", false, "AV56DDO_ContaBancariaCreatedAtAuxDate", context.localUtil.Format(AV56DDO_ContaBancariaCreatedAtAuxDate, "99/99/99"));
               AV57DDO_ContaBancariaCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV55TFContaBancariaCreatedAt_To);
               AssignAttri("", false, "AV57DDO_ContaBancariaCreatedAtAuxDateTo", context.localUtil.Format(AV57DDO_ContaBancariaCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV59TFContaBancariaCreatedByName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFContaBancariaCreatedByName", AV59TFContaBancariaCreatedByName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME_SEL") == 0 )
            {
               AV60TFContaBancariaCreatedByName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFContaBancariaCreatedByName_Sel", AV60TFContaBancariaCreatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDAT") == 0 )
            {
               AV61TFContaBancariaUpdatedAt = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV61TFContaBancariaUpdatedAt", context.localUtil.TToC( AV61TFContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV62TFContaBancariaUpdatedAt_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV62TFContaBancariaUpdatedAt_To", context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV63DDO_ContaBancariaUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV61TFContaBancariaUpdatedAt);
               AssignAttri("", false, "AV63DDO_ContaBancariaUpdatedAtAuxDate", context.localUtil.Format(AV63DDO_ContaBancariaUpdatedAtAuxDate, "99/99/99"));
               AV64DDO_ContaBancariaUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV62TFContaBancariaUpdatedAt_To);
               AssignAttri("", false, "AV64DDO_ContaBancariaUpdatedAtAuxDateTo", context.localUtil.Format(AV64DDO_ContaBancariaUpdatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV66TFContaBancariaUpdatedByName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFContaBancariaUpdatedByName", AV66TFContaBancariaUpdatedByName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME_SEL") == 0 )
            {
               AV67TFContaBancariaUpdatedByName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFContaBancariaUpdatedByName_Sel", AV67TFContaBancariaUpdatedByName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAREGISTRABOLETOS_SEL") == 0 )
            {
               AV79TFContaBancariaRegistraBoletos_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV79TFContaBancariaRegistraBoletos_Sel", StringUtil.Str( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0));
            }
            AV125GXV1 = (int)(AV125GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFAgenciaBancoNome_Sel)),  AV77TFAgenciaBancoNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFContaBancariaCreatedByName_Sel)),  AV60TFContaBancariaCreatedByName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFContaBancariaUpdatedByName_Sel)),  AV67TFContaBancariaUpdatedByName_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||||"+((0==AV53TFContaBancariaStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0))+"||"+GXt_char4+"||"+GXt_char5+"|"+((0==AV79TFContaBancariaRegistraBoletos_Sel) ? "" : StringUtil.Str( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFAgenciaBancoNome)),  AV76TFAgenciaBancoNome, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFContaBancariaCreatedByName)),  AV59TFContaBancariaCreatedByName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFContaBancariaUpdatedByName)),  AV66TFContaBancariaUpdatedByName, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+((0==AV47TFAgenciaNumero) ? "" : StringUtil.Str( (decimal)(AV47TFAgenciaNumero), 9, 0))+"|"+((0==AV49TFContaBancariaNumero) ? "" : StringUtil.Str( (decimal)(AV49TFContaBancariaNumero), 18, 0))+"|"+((0==AV80TFContaBancariaDigito) ? "" : StringUtil.Str( (decimal)(AV80TFContaBancariaDigito), 4, 0))+"|"+((0==AV51TFContaBancariaCarteira) ? "" : StringUtil.Str( (decimal)(AV51TFContaBancariaCarteira), 10, 0))+"||"+((DateTime.MinValue==AV54TFContaBancariaCreatedAt) ? "" : context.localUtil.DToC( AV56DDO_ContaBancariaCreatedAtAuxDate, 4, "/"))+"|"+GXt_char4+"|"+((DateTime.MinValue==AV61TFContaBancariaUpdatedAt) ? "" : context.localUtil.DToC( AV63DDO_ContaBancariaUpdatedAtAuxDate, 4, "/"))+"|"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV48TFAgenciaNumero_To) ? "" : StringUtil.Str( (decimal)(AV48TFAgenciaNumero_To), 9, 0))+"|"+((0==AV50TFContaBancariaNumero_To) ? "" : StringUtil.Str( (decimal)(AV50TFContaBancariaNumero_To), 18, 0))+"|"+((0==AV81TFContaBancariaDigito_To) ? "" : StringUtil.Str( (decimal)(AV81TFContaBancariaDigito_To), 4, 0))+"|"+((0==AV52TFContaBancariaCarteira_To) ? "" : StringUtil.Str( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0))+"||"+((DateTime.MinValue==AV55TFContaBancariaCreatedAt_To) ? "" : context.localUtil.DToC( AV57DDO_ContaBancariaCreatedAtAuxDateTo, 4, "/"))+"||"+((DateTime.MinValue==AV62TFContaBancariaUpdatedAt_To) ? "" : context.localUtil.DToC( AV64DDO_ContaBancariaUpdatedAtAuxDateTo, 4, "/"))+"||";
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
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV20AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV20AgenciaNumero1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV21ContaBancariaCreatedByName1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ContaBancariaCreatedByName1", AV21ContaBancariaCreatedByName1);
            }
            else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV22ContaBancariaUpdatedByName1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV22ContaBancariaUpdatedByName1", AV22ContaBancariaUpdatedByName1);
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
               AV23DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV26ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV26ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV26ContaBancariaNumero2), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV27AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV27AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV27AgenciaNumero2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV28ContaBancariaCreatedByName2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28ContaBancariaCreatedByName2", AV28ContaBancariaCreatedByName2);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV29ContaBancariaUpdatedByName2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV29ContaBancariaUpdatedByName2", AV29ContaBancariaUpdatedByName2);
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
                  AV30DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV30DynamicFiltersEnabled3", AV30DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
                     AV33ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV33ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV33ContaBancariaNumero3), 18, 0));
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
                     AV34AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV34AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV34AgenciaNumero3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
                     AV35ContaBancariaCreatedByName3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35ContaBancariaCreatedByName3", AV35ContaBancariaCreatedByName3);
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
                     AV36ContaBancariaUpdatedByName3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV36ContaBancariaUpdatedByName3", AV36ContaBancariaUpdatedByName3);
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
         if ( AV37DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV41Session.Get(AV82Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAGENCIABANCONOME",  "Banco",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFAgenciaBancoNome)),  0,  AV76TFAgenciaBancoNome,  AV76TFAgenciaBancoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFAgenciaBancoNome_Sel)),  AV77TFAgenciaBancoNome_Sel,  AV77TFAgenciaBancoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIANUMERO",  "Agência",  !((0==AV47TFAgenciaNumero)&&(0==AV48TFAgenciaNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFAgenciaNumero), 9, 0)),  ((0==AV47TFAgenciaNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV47TFAgenciaNumero), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFAgenciaNumero_To), 9, 0)),  ((0==AV48TFAgenciaNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV48TFAgenciaNumero_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIANUMERO",  "Conta",  !((0==AV49TFContaBancariaNumero)&&(0==AV50TFContaBancariaNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFContaBancariaNumero), 18, 0)),  ((0==AV49TFContaBancariaNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV49TFContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFContaBancariaNumero_To), 18, 0)),  ((0==AV50TFContaBancariaNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV50TFContaBancariaNumero_To), "ZZZZZZZZZZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIADIGITO",  "Dígito",  !((0==AV80TFContaBancariaDigito)&&(0==AV81TFContaBancariaDigito_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV80TFContaBancariaDigito), 4, 0)),  ((0==AV80TFContaBancariaDigito) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV80TFContaBancariaDigito), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV81TFContaBancariaDigito_To), 4, 0)),  ((0==AV81TFContaBancariaDigito_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV81TFContaBancariaDigito_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIACARTEIRA",  "Carteira",  !((0==AV51TFContaBancariaCarteira)&&(0==AV52TFContaBancariaCarteira_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFContaBancariaCarteira), 10, 0)),  ((0==AV51TFContaBancariaCarteira) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV51TFContaBancariaCarteira), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV52TFContaBancariaCarteira_To), 10, 0)),  ((0==AV52TFContaBancariaCarteira_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV52TFContaBancariaCarteira_To), "ZZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIASTATUS_SEL",  "Status",  !(0==AV53TFContaBancariaStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV53TFContaBancariaStatus_Sel), 1, 0)),  ((AV53TFContaBancariaStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIACREATEDAT",  "Criado em",  !((DateTime.MinValue==AV54TFContaBancariaCreatedAt)&&(DateTime.MinValue==AV55TFContaBancariaCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV54TFContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV54TFContaBancariaCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV54TFContaBancariaCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV55TFContaBancariaCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV55TFContaBancariaCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV55TFContaBancariaCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCONTABANCARIACREATEDBYNAME",  "Criado por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFContaBancariaCreatedByName)),  0,  AV59TFContaBancariaCreatedByName,  AV59TFContaBancariaCreatedByName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFContaBancariaCreatedByName_Sel)),  AV60TFContaBancariaCreatedByName_Sel,  AV60TFContaBancariaCreatedByName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIAUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV61TFContaBancariaUpdatedAt)&&(DateTime.MinValue==AV62TFContaBancariaUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV61TFContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV61TFContaBancariaUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFContaBancariaUpdatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV62TFContaBancariaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV62TFContaBancariaUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFContaBancariaUpdatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCONTABANCARIAUPDATEDBYNAME",  "Atualizado por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFContaBancariaUpdatedByName)),  0,  AV66TFContaBancariaUpdatedByName,  AV66TFContaBancariaUpdatedByName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFContaBancariaUpdatedByName_Sel)),  AV67TFContaBancariaUpdatedByName_Sel,  AV67TFContaBancariaUpdatedByName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTABANCARIAREGISTRABOLETOS_SEL",  "Usa para registro de boletos?",  !(0==AV79TFContaBancariaRegistraBoletos_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV79TFContaBancariaRegistraBoletos_Sel), 1, 0)),  ((AV79TFContaBancariaRegistraBoletos_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         if ( ! (0==AV7AgenciaId) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&AGENCIAID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7AgenciaId), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV38DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV17DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV19ContaBancariaNumero1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Número",  AV18DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19ContaBancariaNumero1), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 ) && ! (0==AV20AgenciaNumero1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV18DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV20AgenciaNumero1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV20AgenciaNumero1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV20AgenciaNumero1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV20AgenciaNumero1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ContaBancariaCreatedByName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Criado por",  AV18DynamicFiltersOperator1,  AV21ContaBancariaCreatedByName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21ContaBancariaCreatedByName1, "Contém"+" "+AV21ContaBancariaCreatedByName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ContaBancariaUpdatedByName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "By Name",  AV18DynamicFiltersOperator1,  AV22ContaBancariaUpdatedByName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV22ContaBancariaUpdatedByName1, "Contém"+" "+AV22ContaBancariaUpdatedByName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV37DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV26ContaBancariaNumero2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Número",  AV25DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26ContaBancariaNumero2), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "AGENCIANUMERO") == 0 ) && ! (0==AV27AgenciaNumero2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV25DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27AgenciaNumero2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV27AgenciaNumero2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV27AgenciaNumero2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV27AgenciaNumero2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ContaBancariaCreatedByName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Criado por",  AV25DynamicFiltersOperator2,  AV28ContaBancariaCreatedByName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV28ContaBancariaCreatedByName2, "Contém"+" "+AV28ContaBancariaCreatedByName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ContaBancariaUpdatedByName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "By Name",  AV25DynamicFiltersOperator2,  AV29ContaBancariaUpdatedByName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV29ContaBancariaUpdatedByName2, "Contém"+" "+AV29ContaBancariaUpdatedByName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV37DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV30DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV31DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV33ContaBancariaNumero3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Número",  AV32DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33ContaBancariaNumero3), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "AGENCIANUMERO") == 0 ) && ! (0==AV34AgenciaNumero3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV32DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV34AgenciaNumero3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV34AgenciaNumero3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV34AgenciaNumero3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV34AgenciaNumero3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ContaBancariaCreatedByName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Criado por",  AV32DynamicFiltersOperator3,  AV35ContaBancariaCreatedByName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV35ContaBancariaCreatedByName3, "Contém"+" "+AV35ContaBancariaCreatedByName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ContaBancariaUpdatedByName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "By Name",  AV32DynamicFiltersOperator3,  AV36ContaBancariaUpdatedByName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV36ContaBancariaUpdatedByName3, "Contém"+" "+AV36ContaBancariaUpdatedByName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV37DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV82Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ContaBancaria";
         AV41Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_110_9K2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero3_Internalname, "Conta Bancaria Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ContaBancariaNumero3), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV33ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero3_Visible, edtavContabancarianumero3_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero3_Internalname, "Agencia Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34AgenciaNumero3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV34AgenciaNumero3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV34AgenciaNumero3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero3_Visible, edtavAgencianumero3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariacreatedbyname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariacreatedbyname3_Internalname, "Conta Bancaria Created By Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariacreatedbyname3_Internalname, AV35ContaBancariaCreatedByName3, StringUtil.RTrim( context.localUtil.Format( AV35ContaBancariaCreatedByName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariacreatedbyname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariacreatedbyname3_Visible, edtavContabancariacreatedbyname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariaupdatedbyname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariaupdatedbyname3_Internalname, "Conta Bancaria Updated By Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariaupdatedbyname3_Internalname, AV36ContaBancariaUpdatedByName3, StringUtil.RTrim( context.localUtil.Format( AV36ContaBancariaUpdatedByName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariaupdatedbyname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariaupdatedbyname3_Visible, edtavContabancariaupdatedbyname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContaBancariaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_110_9K2e( true) ;
         }
         else
         {
            wb_table3_110_9K2e( false) ;
         }
      }

      protected void wb_table2_79_9K2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero2_Internalname, "Conta Bancaria Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ContaBancariaNumero2), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV26ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero2_Visible, edtavContabancarianumero2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero2_Internalname, "Agencia Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27AgenciaNumero2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27AgenciaNumero2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27AgenciaNumero2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero2_Visible, edtavAgencianumero2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariacreatedbyname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariacreatedbyname2_Internalname, "Conta Bancaria Created By Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariacreatedbyname2_Internalname, AV28ContaBancariaCreatedByName2, StringUtil.RTrim( context.localUtil.Format( AV28ContaBancariaCreatedByName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariacreatedbyname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariacreatedbyname2_Visible, edtavContabancariacreatedbyname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariaupdatedbyname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariaupdatedbyname2_Internalname, "Conta Bancaria Updated By Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariaupdatedbyname2_Internalname, AV29ContaBancariaUpdatedByName2, StringUtil.RTrim( context.localUtil.Format( AV29ContaBancariaUpdatedByName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariaupdatedbyname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariaupdatedbyname2_Visible, edtavContabancariaupdatedbyname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContaBancariaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContaBancariaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_79_9K2e( true) ;
         }
         else
         {
            wb_table2_79_9K2e( false) ;
         }
      }

      protected void wb_table1_48_9K2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_ContaBancariaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero1_Internalname, "Conta Bancaria Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero1_Visible, edtavContabancarianumero1_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero1_Internalname, "Agencia Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20AgenciaNumero1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20AgenciaNumero1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20AgenciaNumero1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero1_Visible, edtavAgencianumero1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariacreatedbyname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariacreatedbyname1_Internalname, "Conta Bancaria Created By Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariacreatedbyname1_Internalname, AV21ContaBancariaCreatedByName1, StringUtil.RTrim( context.localUtil.Format( AV21ContaBancariaCreatedByName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariacreatedbyname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariacreatedbyname1_Visible, edtavContabancariacreatedbyname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancariaupdatedbyname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancariaupdatedbyname1_Internalname, "Conta Bancaria Updated By Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancariaupdatedbyname1_Internalname, AV22ContaBancariaUpdatedByName1, StringUtil.RTrim( context.localUtil.Format( AV22ContaBancariaUpdatedByName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancariaupdatedbyname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancariaupdatedbyname1_Visible, edtavContabancariaupdatedbyname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancariaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContaBancariaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContaBancariaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_9K2e( true) ;
         }
         else
         {
            wb_table1_48_9K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7AgenciaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7AgenciaId", StringUtil.LTrimStr( (decimal)(AV7AgenciaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
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
         PA9K2( ) ;
         WS9K2( ) ;
         WE9K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019282515", true, true);
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
         context.AddJavascriptSource("contabancariaww.js", "?202561019282515", false, true);
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
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_137_idx;
         edtAgenciaId_Internalname = "AGENCIAID_"+sGXsfl_137_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_137_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_137_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_137_idx;
         edtContaBancariaDigito_Internalname = "CONTABANCARIADIGITO_"+sGXsfl_137_idx;
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA_"+sGXsfl_137_idx;
         cmbContaBancariaStatus_Internalname = "CONTABANCARIASTATUS_"+sGXsfl_137_idx;
         edtContaBancariaCreatedAt_Internalname = "CONTABANCARIACREATEDAT_"+sGXsfl_137_idx;
         edtContaBancariaCreatedBy_Internalname = "CONTABANCARIACREATEDBY_"+sGXsfl_137_idx;
         edtContaBancariaCreatedByName_Internalname = "CONTABANCARIACREATEDBYNAME_"+sGXsfl_137_idx;
         edtContaBancariaUpdatedAt_Internalname = "CONTABANCARIAUPDATEDAT_"+sGXsfl_137_idx;
         edtContaBancariaUpdatedBy_Internalname = "CONTABANCARIAUPDATEDBY_"+sGXsfl_137_idx;
         edtContaBancariaUpdatedByName_Internalname = "CONTABANCARIAUPDATEDBYNAME_"+sGXsfl_137_idx;
         cmbContaBancariaRegistraBoletos_Internalname = "CONTABANCARIAREGISTRABOLETOS_"+sGXsfl_137_idx;
      }

      protected void SubsflControlProps_fel_1372( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_137_fel_idx;
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_137_fel_idx;
         edtAgenciaId_Internalname = "AGENCIAID_"+sGXsfl_137_fel_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_137_fel_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_137_fel_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_137_fel_idx;
         edtContaBancariaDigito_Internalname = "CONTABANCARIADIGITO_"+sGXsfl_137_fel_idx;
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA_"+sGXsfl_137_fel_idx;
         cmbContaBancariaStatus_Internalname = "CONTABANCARIASTATUS_"+sGXsfl_137_fel_idx;
         edtContaBancariaCreatedAt_Internalname = "CONTABANCARIACREATEDAT_"+sGXsfl_137_fel_idx;
         edtContaBancariaCreatedBy_Internalname = "CONTABANCARIACREATEDBY_"+sGXsfl_137_fel_idx;
         edtContaBancariaCreatedByName_Internalname = "CONTABANCARIACREATEDBYNAME_"+sGXsfl_137_fel_idx;
         edtContaBancariaUpdatedAt_Internalname = "CONTABANCARIAUPDATEDAT_"+sGXsfl_137_fel_idx;
         edtContaBancariaUpdatedBy_Internalname = "CONTABANCARIAUPDATEDBY_"+sGXsfl_137_fel_idx;
         edtContaBancariaUpdatedByName_Internalname = "CONTABANCARIAUPDATEDBYNAME_"+sGXsfl_137_fel_idx;
         cmbContaBancariaRegistraBoletos_Internalname = "CONTABANCARIAREGISTRABOLETOS_"+sGXsfl_137_fel_idx;
      }

      protected void sendrow_1372( )
      {
         sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
         SubsflControlProps_1372( ) ;
         WB9K0( ) ;
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
                  AV78GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV78GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_137_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_137_Refreshing);
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaDigito_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A975ContaBancariaDigito), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaDigito_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaCarteira_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A953ContaBancariaCarteira), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaCarteira_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbContaBancariaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONTABANCARIASTATUS_" + sGXsfl_137_idx;
               cmbContaBancariaStatus.Name = GXCCtl;
               cmbContaBancariaStatus.WebTags = "";
               cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbContaBancariaStatus.ItemCount > 0 )
               {
                  A956ContaBancariaStatus = StringUtil.StrToBool( cmbContaBancariaStatus.getValidValue(StringUtil.BoolToStr( A956ContaBancariaStatus)));
                  n956ContaBancariaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbContaBancariaStatus,(string)cmbContaBancariaStatus_Internalname,StringUtil.BoolToStr( A956ContaBancariaStatus),(short)1,(string)cmbContaBancariaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbContaBancariaStatus_Columnclass,(string)cmbContaBancariaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbContaBancariaStatus.CurrentValue = StringUtil.BoolToStr( A956ContaBancariaStatus);
            AssignProp("", false, cmbContaBancariaStatus_Internalname, "Values", (string)(cmbContaBancariaStatus.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaCreatedAt_Internalname,context.localUtil.TToC( A954ContaBancariaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A954ContaBancariaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaCreatedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A947ContaBancariaCreatedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaCreatedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaCreatedByName_Internalname,(string)A948ContaBancariaCreatedByName,StringUtil.RTrim( context.localUtil.Format( A948ContaBancariaCreatedByName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtContaBancariaCreatedByName_Link,(string)"",(string)"",(string)"",(string)edtContaBancariaCreatedByName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaUpdatedAt_Internalname,context.localUtil.TToC( A955ContaBancariaUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A955ContaBancariaUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaUpdatedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A949ContaBancariaUpdatedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaUpdatedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaUpdatedByName_Internalname,(string)A950ContaBancariaUpdatedByName,StringUtil.RTrim( context.localUtil.Format( A950ContaBancariaUpdatedByName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtContaBancariaUpdatedByName_Link,(string)"",(string)"",(string)"",(string)edtContaBancariaUpdatedByName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbContaBancariaRegistraBoletos.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONTABANCARIAREGISTRABOLETOS_" + sGXsfl_137_idx;
               cmbContaBancariaRegistraBoletos.Name = GXCCtl;
               cmbContaBancariaRegistraBoletos.WebTags = "";
               cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( false), "Não", 0);
               cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               if ( cmbContaBancariaRegistraBoletos.ItemCount > 0 )
               {
                  A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cmbContaBancariaRegistraBoletos.getValidValue(StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)));
                  n973ContaBancariaRegistraBoletos = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbContaBancariaRegistraBoletos,(string)cmbContaBancariaRegistraBoletos_Internalname,StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos),(short)1,(string)cmbContaBancariaRegistraBoletos_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbContaBancariaRegistraBoletos_Columnclass,(string)cmbContaBancariaRegistraBoletos_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbContaBancariaRegistraBoletos.CurrentValue = StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos);
            AssignProp("", false, cmbContaBancariaRegistraBoletos_Internalname, "Values", (string)(cmbContaBancariaRegistraBoletos.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            send_integrity_lvl_hashes9K2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector1.addItem("AGENCIANUMERO", "Agência", 0);
         cmbavDynamicfiltersselector1.addItem("CONTABANCARIACREATEDBYNAME", "Criado por", 0);
         cmbavDynamicfiltersselector1.addItem("CONTABANCARIAUPDATEDBYNAME", "By Name", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV17DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV17DynamicFiltersSelector1);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector2.addItem("AGENCIANUMERO", "Agência", 0);
         cmbavDynamicfiltersselector2.addItem("CONTABANCARIACREATEDBYNAME", "Criado por", 0);
         cmbavDynamicfiltersselector2.addItem("CONTABANCARIAUPDATEDBYNAME", "By Name", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CONTABANCARIANUMERO", "Número", 0);
         cmbavDynamicfiltersselector3.addItem("AGENCIANUMERO", "Agência", 0);
         cmbavDynamicfiltersselector3.addItem("CONTABANCARIACREATEDBYNAME", "Criado por", 0);
         cmbavDynamicfiltersselector3.addItem("CONTABANCARIAUPDATEDBYNAME", "By Name", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV31DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV31DynamicFiltersSelector3);
            AssignAttri("", false, "AV31DynamicFiltersSelector3", AV31DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV32DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV32DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV32DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV32DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_137_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV78GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV78GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV78GridActionGroup1), 4, 0));
         }
         GXCCtl = "CONTABANCARIASTATUS_" + sGXsfl_137_idx;
         cmbContaBancariaStatus.Name = GXCCtl;
         cmbContaBancariaStatus.WebTags = "";
         cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbContaBancariaStatus.ItemCount > 0 )
         {
            A956ContaBancariaStatus = StringUtil.StrToBool( cmbContaBancariaStatus.getValidValue(StringUtil.BoolToStr( A956ContaBancariaStatus)));
            n956ContaBancariaStatus = false;
         }
         GXCCtl = "CONTABANCARIAREGISTRABOLETOS_" + sGXsfl_137_idx;
         cmbContaBancariaRegistraBoletos.Name = GXCCtl;
         cmbContaBancariaRegistraBoletos.WebTags = "";
         cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( false), "Não", 0);
         cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         if ( cmbContaBancariaRegistraBoletos.ItemCount > 0 )
         {
            A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cmbContaBancariaRegistraBoletos.getValidValue(StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)));
            n973ContaBancariaRegistraBoletos = false;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Bancaria Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Dígito") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Carteira") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Atualizado por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Usa para registro de boletos?") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A956ContaBancariaStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbContaBancariaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbContaBancariaStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A954ContaBancariaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A948ContaBancariaCreatedByName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtContaBancariaCreatedByName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A955ContaBancariaUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A950ContaBancariaUpdatedByName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtContaBancariaUpdatedByName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbContaBancariaRegistraBoletos_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbContaBancariaRegistraBoletos_Columnheaderclass));
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
         edtavContabancarianumero1_Internalname = "vCONTABANCARIANUMERO1";
         cellFilter_contabancarianumero1_cell_Internalname = "FILTER_CONTABANCARIANUMERO1_CELL";
         edtavAgencianumero1_Internalname = "vAGENCIANUMERO1";
         cellFilter_agencianumero1_cell_Internalname = "FILTER_AGENCIANUMERO1_CELL";
         edtavContabancariacreatedbyname1_Internalname = "vCONTABANCARIACREATEDBYNAME1";
         cellFilter_contabancariacreatedbyname1_cell_Internalname = "FILTER_CONTABANCARIACREATEDBYNAME1_CELL";
         edtavContabancariaupdatedbyname1_Internalname = "vCONTABANCARIAUPDATEDBYNAME1";
         cellFilter_contabancariaupdatedbyname1_cell_Internalname = "FILTER_CONTABANCARIAUPDATEDBYNAME1_CELL";
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
         edtavContabancarianumero2_Internalname = "vCONTABANCARIANUMERO2";
         cellFilter_contabancarianumero2_cell_Internalname = "FILTER_CONTABANCARIANUMERO2_CELL";
         edtavAgencianumero2_Internalname = "vAGENCIANUMERO2";
         cellFilter_agencianumero2_cell_Internalname = "FILTER_AGENCIANUMERO2_CELL";
         edtavContabancariacreatedbyname2_Internalname = "vCONTABANCARIACREATEDBYNAME2";
         cellFilter_contabancariacreatedbyname2_cell_Internalname = "FILTER_CONTABANCARIACREATEDBYNAME2_CELL";
         edtavContabancariaupdatedbyname2_Internalname = "vCONTABANCARIAUPDATEDBYNAME2";
         cellFilter_contabancariaupdatedbyname2_cell_Internalname = "FILTER_CONTABANCARIAUPDATEDBYNAME2_CELL";
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
         edtavContabancarianumero3_Internalname = "vCONTABANCARIANUMERO3";
         cellFilter_contabancarianumero3_cell_Internalname = "FILTER_CONTABANCARIANUMERO3_CELL";
         edtavAgencianumero3_Internalname = "vAGENCIANUMERO3";
         cellFilter_agencianumero3_cell_Internalname = "FILTER_AGENCIANUMERO3_CELL";
         edtavContabancariacreatedbyname3_Internalname = "vCONTABANCARIACREATEDBYNAME3";
         cellFilter_contabancariacreatedbyname3_cell_Internalname = "FILTER_CONTABANCARIACREATEDBYNAME3_CELL";
         edtavContabancariaupdatedbyname3_Internalname = "vCONTABANCARIAUPDATEDBYNAME3";
         cellFilter_contabancariaupdatedbyname3_cell_Internalname = "FILTER_CONTABANCARIAUPDATEDBYNAME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtContaBancariaId_Internalname = "CONTABANCARIAID";
         edtAgenciaId_Internalname = "AGENCIAID";
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO";
         edtContaBancariaDigito_Internalname = "CONTABANCARIADIGITO";
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA";
         cmbContaBancariaStatus_Internalname = "CONTABANCARIASTATUS";
         edtContaBancariaCreatedAt_Internalname = "CONTABANCARIACREATEDAT";
         edtContaBancariaCreatedBy_Internalname = "CONTABANCARIACREATEDBY";
         edtContaBancariaCreatedByName_Internalname = "CONTABANCARIACREATEDBYNAME";
         edtContaBancariaUpdatedAt_Internalname = "CONTABANCARIAUPDATEDAT";
         edtContaBancariaUpdatedBy_Internalname = "CONTABANCARIAUPDATEDBY";
         edtContaBancariaUpdatedByName_Internalname = "CONTABANCARIAUPDATEDBYNAME";
         cmbContaBancariaRegistraBoletos_Internalname = "CONTABANCARIAREGISTRABOLETOS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_contabancariacreatedatauxdatetext_Internalname = "vDDO_CONTABANCARIACREATEDATAUXDATETEXT";
         Tfcontabancariacreatedat_rangepicker_Internalname = "TFCONTABANCARIACREATEDAT_RANGEPICKER";
         divDdo_contabancariacreatedatauxdates_Internalname = "DDO_CONTABANCARIACREATEDATAUXDATES";
         edtavDdo_contabancariaupdatedatauxdatetext_Internalname = "vDDO_CONTABANCARIAUPDATEDATAUXDATETEXT";
         Tfcontabancariaupdatedat_rangepicker_Internalname = "TFCONTABANCARIAUPDATEDAT_RANGEPICKER";
         divDdo_contabancariaupdatedatauxdates_Internalname = "DDO_CONTABANCARIAUPDATEDATAUXDATES";
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
         cmbContaBancariaRegistraBoletos_Jsonclick = "";
         cmbContaBancariaRegistraBoletos_Columnclass = "WWColumn";
         edtContaBancariaUpdatedByName_Jsonclick = "";
         edtContaBancariaUpdatedByName_Link = "";
         edtContaBancariaUpdatedBy_Jsonclick = "";
         edtContaBancariaUpdatedAt_Jsonclick = "";
         edtContaBancariaCreatedByName_Jsonclick = "";
         edtContaBancariaCreatedByName_Link = "";
         edtContaBancariaCreatedBy_Jsonclick = "";
         edtContaBancariaCreatedAt_Jsonclick = "";
         cmbContaBancariaStatus_Jsonclick = "";
         cmbContaBancariaStatus_Columnclass = "WWColumn";
         edtContaBancariaCarteira_Jsonclick = "";
         edtContaBancariaDigito_Jsonclick = "";
         edtContaBancariaNumero_Jsonclick = "";
         edtContaBancariaNumero_Link = "";
         edtAgenciaNumero_Jsonclick = "";
         edtAgenciaNumero_Link = "";
         edtAgenciaBancoNome_Jsonclick = "";
         edtAgenciaId_Jsonclick = "";
         edtContaBancariaId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavContabancariaupdatedbyname1_Jsonclick = "";
         edtavContabancariaupdatedbyname1_Enabled = 1;
         edtavContabancariacreatedbyname1_Jsonclick = "";
         edtavContabancariacreatedbyname1_Enabled = 1;
         edtavAgencianumero1_Jsonclick = "";
         edtavAgencianumero1_Enabled = 1;
         edtavContabancarianumero1_Jsonclick = "";
         edtavContabancarianumero1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavContabancariaupdatedbyname2_Jsonclick = "";
         edtavContabancariaupdatedbyname2_Enabled = 1;
         edtavContabancariacreatedbyname2_Jsonclick = "";
         edtavContabancariacreatedbyname2_Enabled = 1;
         edtavAgencianumero2_Jsonclick = "";
         edtavAgencianumero2_Enabled = 1;
         edtavContabancarianumero2_Jsonclick = "";
         edtavContabancarianumero2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavContabancariaupdatedbyname3_Jsonclick = "";
         edtavContabancariaupdatedbyname3_Enabled = 1;
         edtavContabancariacreatedbyname3_Jsonclick = "";
         edtavContabancariacreatedbyname3_Enabled = 1;
         edtavAgencianumero3_Jsonclick = "";
         edtavAgencianumero3_Enabled = 1;
         edtavContabancarianumero3_Jsonclick = "";
         edtavContabancarianumero3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavContabancariaupdatedbyname3_Visible = 1;
         edtavContabancariacreatedbyname3_Visible = 1;
         edtavAgencianumero3_Visible = 1;
         edtavContabancarianumero3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavContabancariaupdatedbyname2_Visible = 1;
         edtavContabancariacreatedbyname2_Visible = 1;
         edtavAgencianumero2_Visible = 1;
         edtavContabancarianumero2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavContabancariaupdatedbyname1_Visible = 1;
         edtavContabancariacreatedbyname1_Visible = 1;
         edtavAgencianumero1_Visible = 1;
         edtavContabancarianumero1_Visible = 1;
         cmbContaBancariaRegistraBoletos_Columnheaderclass = "";
         cmbContaBancariaStatus_Columnheaderclass = "";
         cmbContaBancariaRegistraBoletos.Enabled = 0;
         edtContaBancariaUpdatedByName_Enabled = 0;
         edtContaBancariaUpdatedBy_Enabled = 0;
         edtContaBancariaUpdatedAt_Enabled = 0;
         edtContaBancariaCreatedByName_Enabled = 0;
         edtContaBancariaCreatedBy_Enabled = 0;
         edtContaBancariaCreatedAt_Enabled = 0;
         cmbContaBancariaStatus.Enabled = 0;
         edtContaBancariaCarteira_Enabled = 0;
         edtContaBancariaDigito_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtAgenciaId_Enabled = 0;
         edtContaBancariaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_contabancariaupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_contabancariacreatedatauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "|9.0|18.0|4.0|10.0||||||";
         Ddo_grid_Datalistproc = "ContaBancariaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||1:WWP_TSChecked,2:WWP_TSUnChecked|||||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|||||FixedValues||Dynamic||Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T|||||T||T||T|T";
         Ddo_grid_Filterisrange = "|T|T|T|T||P||P||";
         Ddo_grid_Filtertype = "Character|Numeric|Numeric|Numeric|Numeric||Date|Character|Date|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "3:AgenciaBancoNome|4:AgenciaNumero|5:ContaBancariaNumero|6:ContaBancariaDigito|7:ContaBancariaCarteira|8:ContaBancariaStatus|9:ContaBancariaCreatedAt|11:ContaBancariaCreatedByName|12:ContaBancariaUpdatedAt|14:ContaBancariaUpdatedByName|15:ContaBancariaRegistraBoletos";
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
         Form.Caption = " Conta Bancaria";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E279K2","iparms":[{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A947ContaBancariaCreatedBy","fld":"CONTABANCARIACREATEDBY","pic":"ZZZ9","type":"int"},{"av":"A949ContaBancariaUpdatedBy","fld":"CONTABANCARIAUPDATEDBY","pic":"ZZZ9","type":"int"},{"av":"cmbContaBancariaStatus"},{"av":"A956ContaBancariaStatus","fld":"CONTABANCARIASTATUS","type":"boolean"},{"av":"cmbContaBancariaRegistraBoletos"},{"av":"A973ContaBancariaRegistraBoletos","fld":"CONTABANCARIAREGISTRABOLETOS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV78GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"edtAgenciaNumero_Link","ctrl":"AGENCIANUMERO","prop":"Link"},{"av":"edtContaBancariaNumero_Link","ctrl":"CONTABANCARIANUMERO","prop":"Link"},{"av":"edtContaBancariaCreatedByName_Link","ctrl":"CONTABANCARIACREATEDBYNAME","prop":"Link"},{"av":"edtContaBancariaUpdatedByName_Link","ctrl":"CONTABANCARIAUPDATEDBYNAME","prop":"Link"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E209K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavContabancariacreatedbyname2_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname2_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavContabancariacreatedbyname3_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname3_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavContabancariacreatedbyname1_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname1_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME1","prop":"Visible"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219K2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavContabancariacreatedbyname1_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname1_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E229K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavContabancariacreatedbyname2_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname2_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavContabancariacreatedbyname3_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname3_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavContabancariacreatedbyname1_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname1_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME1","prop":"Visible"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E239K2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavContabancariacreatedbyname2_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname2_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavContabancariacreatedbyname2_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname2_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavContabancariacreatedbyname3_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname3_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavContabancariacreatedbyname1_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname1_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME1","prop":"Visible"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E249K2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavContabancariacreatedbyname3_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname3_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV56DDO_ContaBancariaCreatedAtAuxDate","fld":"vDDO_CONTABANCARIACREATEDATAUXDATE","type":"date"},{"av":"AV63DDO_ContaBancariaUpdatedAtAuxDate","fld":"vDDO_CONTABANCARIAUPDATEDATAUXDATE","type":"date"},{"av":"AV57DDO_ContaBancariaCreatedAtAuxDateTo","fld":"vDDO_CONTABANCARIACREATEDATAUXDATETO","type":"date"},{"av":"AV64DDO_ContaBancariaUpdatedAtAuxDateTo","fld":"vDDO_CONTABANCARIAUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV63DDO_ContaBancariaUpdatedAtAuxDate","fld":"vDDO_CONTABANCARIAUPDATEDATAUXDATE","type":"date"},{"av":"AV64DDO_ContaBancariaUpdatedAtAuxDateTo","fld":"vDDO_CONTABANCARIAUPDATEDATAUXDATETO","type":"date"},{"av":"AV56DDO_ContaBancariaCreatedAtAuxDate","fld":"vDDO_CONTABANCARIACREATEDATAUXDATE","type":"date"},{"av":"AV57DDO_ContaBancariaCreatedAtAuxDateTo","fld":"vDDO_CONTABANCARIACREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavContabancariacreatedbyname1_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname1_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME1","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavContabancariacreatedbyname2_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname2_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME2","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavContabancariacreatedbyname3_Visible","ctrl":"vCONTABANCARIACREATEDBYNAME3","prop":"Visible"},{"av":"edtavContabancariaupdatedbyname3_Visible","ctrl":"vCONTABANCARIAUPDATEDBYNAME3","prop":"Visible"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E289K2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV78GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV78GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189K2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV20AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ContaBancariaCreatedByName1","fld":"vCONTABANCARIACREATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"AV22ContaBancariaUpdatedByName1","fld":"vCONTABANCARIAUPDATEDBYNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ContaBancariaCreatedByName2","fld":"vCONTABANCARIACREATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaUpdatedByName2","fld":"vCONTABANCARIAUPDATEDBYNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV31DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV33ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV34AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35ContaBancariaCreatedByName3","fld":"vCONTABANCARIACREATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV36ContaBancariaUpdatedByName3","fld":"vCONTABANCARIAUPDATEDBYNAME3","pic":"@!","type":"svchar"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV30DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV76TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV77TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV47TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49TFContaBancariaNumero","fld":"vTFCONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV50TFContaBancariaNumero_To","fld":"vTFCONTABANCARIANUMERO_TO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV80TFContaBancariaDigito","fld":"vTFCONTABANCARIADIGITO","pic":"ZZZ9","type":"int"},{"av":"AV81TFContaBancariaDigito_To","fld":"vTFCONTABANCARIADIGITO_TO","pic":"ZZZ9","type":"int"},{"av":"AV51TFContaBancariaCarteira","fld":"vTFCONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52TFContaBancariaCarteira_To","fld":"vTFCONTABANCARIACARTEIRA_TO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53TFContaBancariaStatus_Sel","fld":"vTFCONTABANCARIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV54TFContaBancariaCreatedAt","fld":"vTFCONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFContaBancariaCreatedAt_To","fld":"vTFCONTABANCARIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFContaBancariaCreatedByName","fld":"vTFCONTABANCARIACREATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV60TFContaBancariaCreatedByName_Sel","fld":"vTFCONTABANCARIACREATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFContaBancariaUpdatedAt","fld":"vTFCONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContaBancariaUpdatedAt_To","fld":"vTFCONTABANCARIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFContaBancariaUpdatedByName","fld":"vTFCONTABANCARIAUPDATEDBYNAME","pic":"@!","type":"svchar"},{"av":"AV67TFContaBancariaUpdatedByName_Sel","fld":"vTFCONTABANCARIAUPDATEDBYNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFContaBancariaRegistraBoletos_Sel","fld":"vTFCONTABANCARIAREGISTRABOLETOS_SEL","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV37DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV124Bancoid","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV44ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV32DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContaBancariaStatus"},{"av":"cmbContaBancariaRegistraBoletos"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV42ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199K2","iparms":[]}""");
         setEventMetadata("VALID_AGENCIAID","""{"handler":"Valid_Agenciaid","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIACREATEDBY","""{"handler":"Valid_Contabancariacreatedby","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIAUPDATEDBY","""{"handler":"Valid_Contabancariaupdatedby","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Contabancariaregistraboletos","iparms":[]}""");
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
         AV16FilterFullText = "";
         AV17DynamicFiltersSelector1 = "";
         AV21ContaBancariaCreatedByName1 = "";
         AV22ContaBancariaUpdatedByName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV28ContaBancariaCreatedByName2 = "";
         AV29ContaBancariaUpdatedByName2 = "";
         AV31DynamicFiltersSelector3 = "";
         AV35ContaBancariaCreatedByName3 = "";
         AV36ContaBancariaUpdatedByName3 = "";
         AV82Pgmname = "";
         AV76TFAgenciaBancoNome = "";
         AV77TFAgenciaBancoNome_Sel = "";
         AV54TFContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         AV55TFContaBancariaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV59TFContaBancariaCreatedByName = "";
         AV60TFContaBancariaCreatedByName_Sel = "";
         AV61TFContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV62TFContaBancariaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV66TFContaBancariaUpdatedByName = "";
         AV67TFContaBancariaUpdatedByName_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV42ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV72GridAppliedFilters = "";
         AV68DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV56DDO_ContaBancariaCreatedAtAuxDate = DateTime.MinValue;
         AV57DDO_ContaBancariaCreatedAtAuxDateTo = DateTime.MinValue;
         AV63DDO_ContaBancariaUpdatedAtAuxDate = DateTime.MinValue;
         AV64DDO_ContaBancariaUpdatedAtAuxDateTo = DateTime.MinValue;
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
         AV58DDO_ContaBancariaCreatedAtAuxDateText = "";
         ucTfcontabancariacreatedat_rangepicker = new GXUserControl();
         AV65DDO_ContaBancariaUpdatedAtAuxDateText = "";
         ucTfcontabancariaupdatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A969AgenciaBancoNome = "";
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         A948ContaBancariaCreatedByName = "";
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         A950ContaBancariaUpdatedByName = "";
         GXDecQS = "";
         lV83Contabancariawwds_1_filterfulltext = "";
         lV88Contabancariawwds_6_contabancariacreatedbyname1 = "";
         lV89Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         lV95Contabancariawwds_13_contabancariacreatedbyname2 = "";
         lV96Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         lV102Contabancariawwds_20_contabancariacreatedbyname3 = "";
         lV103Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         lV104Contabancariawwds_22_tfagenciabanconome = "";
         lV117Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         lV121Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         AV83Contabancariawwds_1_filterfulltext = "";
         AV84Contabancariawwds_2_dynamicfiltersselector1 = "";
         AV88Contabancariawwds_6_contabancariacreatedbyname1 = "";
         AV89Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         AV91Contabancariawwds_9_dynamicfiltersselector2 = "";
         AV95Contabancariawwds_13_contabancariacreatedbyname2 = "";
         AV96Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         AV98Contabancariawwds_16_dynamicfiltersselector3 = "";
         AV102Contabancariawwds_20_contabancariacreatedbyname3 = "";
         AV103Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         AV105Contabancariawwds_23_tfagenciabanconome_sel = "";
         AV104Contabancariawwds_22_tfagenciabanconome = "";
         AV115Contabancariawwds_33_tfcontabancariacreatedat = (DateTime)(DateTime.MinValue);
         AV116Contabancariawwds_34_tfcontabancariacreatedat_to = (DateTime)(DateTime.MinValue);
         AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel = "";
         AV117Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         AV119Contabancariawwds_37_tfcontabancariaupdatedat = (DateTime)(DateTime.MinValue);
         AV120Contabancariawwds_38_tfcontabancariaupdatedat_to = (DateTime)(DateTime.MinValue);
         AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = "";
         AV121Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         H009K2_A968AgenciaBancoId = new int[1] ;
         H009K2_n968AgenciaBancoId = new bool[] {false} ;
         H009K2_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         H009K2_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         H009K2_A950ContaBancariaUpdatedByName = new string[] {""} ;
         H009K2_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         H009K2_A949ContaBancariaUpdatedBy = new short[1] ;
         H009K2_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         H009K2_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H009K2_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         H009K2_A948ContaBancariaCreatedByName = new string[] {""} ;
         H009K2_n948ContaBancariaCreatedByName = new bool[] {false} ;
         H009K2_A947ContaBancariaCreatedBy = new short[1] ;
         H009K2_n947ContaBancariaCreatedBy = new bool[] {false} ;
         H009K2_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009K2_n954ContaBancariaCreatedAt = new bool[] {false} ;
         H009K2_A956ContaBancariaStatus = new bool[] {false} ;
         H009K2_n956ContaBancariaStatus = new bool[] {false} ;
         H009K2_A953ContaBancariaCarteira = new long[1] ;
         H009K2_n953ContaBancariaCarteira = new bool[] {false} ;
         H009K2_A975ContaBancariaDigito = new short[1] ;
         H009K2_n975ContaBancariaDigito = new bool[] {false} ;
         H009K2_A952ContaBancariaNumero = new long[1] ;
         H009K2_n952ContaBancariaNumero = new bool[] {false} ;
         H009K2_A939AgenciaNumero = new int[1] ;
         H009K2_n939AgenciaNumero = new bool[] {false} ;
         H009K2_A969AgenciaBancoNome = new string[] {""} ;
         H009K2_n969AgenciaBancoNome = new bool[] {false} ;
         H009K2_A938AgenciaId = new int[1] ;
         H009K2_n938AgenciaId = new bool[] {false} ;
         H009K2_A951ContaBancariaId = new int[1] ;
         H009K3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV43ManageFiltersXml = "";
         AV39ExcelFilename = "";
         AV40ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabancariaww__default(),
            new Object[][] {
                new Object[] {
               H009K2_A968AgenciaBancoId, H009K2_n968AgenciaBancoId, H009K2_A973ContaBancariaRegistraBoletos, H009K2_n973ContaBancariaRegistraBoletos, H009K2_A950ContaBancariaUpdatedByName, H009K2_n950ContaBancariaUpdatedByName, H009K2_A949ContaBancariaUpdatedBy, H009K2_n949ContaBancariaUpdatedBy, H009K2_A955ContaBancariaUpdatedAt, H009K2_n955ContaBancariaUpdatedAt,
               H009K2_A948ContaBancariaCreatedByName, H009K2_n948ContaBancariaCreatedByName, H009K2_A947ContaBancariaCreatedBy, H009K2_n947ContaBancariaCreatedBy, H009K2_A954ContaBancariaCreatedAt, H009K2_n954ContaBancariaCreatedAt, H009K2_A956ContaBancariaStatus, H009K2_n956ContaBancariaStatus, H009K2_A953ContaBancariaCarteira, H009K2_n953ContaBancariaCarteira,
               H009K2_A975ContaBancariaDigito, H009K2_n975ContaBancariaDigito, H009K2_A952ContaBancariaNumero, H009K2_n952ContaBancariaNumero, H009K2_A939AgenciaNumero, H009K2_n939AgenciaNumero, H009K2_A969AgenciaBancoNome, H009K2_n969AgenciaBancoNome, H009K2_A938AgenciaId, H009K2_n938AgenciaId,
               H009K2_A951ContaBancariaId
               }
               , new Object[] {
               H009K3_AGRID_nRecordCount
               }
            }
         );
         AV82Pgmname = "ContaBancariaWW";
         /* GeneXus formulas. */
         AV82Pgmname = "ContaBancariaWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short AV44ManageFiltersExecutionStep ;
      private short AV80TFContaBancariaDigito ;
      private short AV81TFContaBancariaDigito_To ;
      private short AV53TFContaBancariaStatus_Sel ;
      private short AV79TFContaBancariaRegistraBoletos_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV78GridActionGroup1 ;
      private short A975ContaBancariaDigito ;
      private short A947ContaBancariaCreatedBy ;
      private short A949ContaBancariaUpdatedBy ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV85Contabancariawwds_3_dynamicfiltersoperator1 ;
      private short AV92Contabancariawwds_10_dynamicfiltersoperator2 ;
      private short AV99Contabancariawwds_17_dynamicfiltersoperator3 ;
      private short AV110Contabancariawwds_28_tfcontabancariadigito ;
      private short AV111Contabancariawwds_29_tfcontabancariadigito_to ;
      private short AV114Contabancariawwds_32_tfcontabancariastatus_sel ;
      private short AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7AgenciaId ;
      private int wcpOAV7AgenciaId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_137 ;
      private int nGXsfl_137_idx=1 ;
      private int AV20AgenciaNumero1 ;
      private int AV27AgenciaNumero2 ;
      private int AV34AgenciaNumero3 ;
      private int AV47TFAgenciaNumero ;
      private int AV48TFAgenciaNumero_To ;
      private int AV124Bancoid ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtn_cancel_Visible ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A939AgenciaNumero ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV87Contabancariawwds_5_agencianumero1 ;
      private int AV94Contabancariawwds_12_agencianumero2 ;
      private int AV101Contabancariawwds_19_agencianumero3 ;
      private int AV106Contabancariawwds_24_tfagencianumero ;
      private int AV107Contabancariawwds_25_tfagencianumero_to ;
      private int A968AgenciaBancoId ;
      private int edtContaBancariaId_Enabled ;
      private int edtAgenciaId_Enabled ;
      private int edtAgenciaBancoNome_Enabled ;
      private int edtAgenciaNumero_Enabled ;
      private int edtContaBancariaNumero_Enabled ;
      private int edtContaBancariaDigito_Enabled ;
      private int edtContaBancariaCarteira_Enabled ;
      private int edtContaBancariaCreatedAt_Enabled ;
      private int edtContaBancariaCreatedBy_Enabled ;
      private int edtContaBancariaCreatedByName_Enabled ;
      private int edtContaBancariaUpdatedAt_Enabled ;
      private int edtContaBancariaUpdatedBy_Enabled ;
      private int edtContaBancariaUpdatedByName_Enabled ;
      private int AV69PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavContabancarianumero1_Visible ;
      private int edtavAgencianumero1_Visible ;
      private int edtavContabancariacreatedbyname1_Visible ;
      private int edtavContabancariaupdatedbyname1_Visible ;
      private int edtavContabancarianumero2_Visible ;
      private int edtavAgencianumero2_Visible ;
      private int edtavContabancariacreatedbyname2_Visible ;
      private int edtavContabancariaupdatedbyname2_Visible ;
      private int edtavContabancarianumero3_Visible ;
      private int edtavAgencianumero3_Visible ;
      private int edtavContabancariacreatedbyname3_Visible ;
      private int edtavContabancariaupdatedbyname3_Visible ;
      private int AV125GXV1 ;
      private int edtavContabancarianumero3_Enabled ;
      private int edtavAgencianumero3_Enabled ;
      private int edtavContabancariacreatedbyname3_Enabled ;
      private int edtavContabancariaupdatedbyname3_Enabled ;
      private int edtavContabancarianumero2_Enabled ;
      private int edtavAgencianumero2_Enabled ;
      private int edtavContabancariacreatedbyname2_Enabled ;
      private int edtavContabancariaupdatedbyname2_Enabled ;
      private int edtavContabancarianumero1_Enabled ;
      private int edtavAgencianumero1_Enabled ;
      private int edtavContabancariacreatedbyname1_Enabled ;
      private int edtavContabancariaupdatedbyname1_Enabled ;
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
      private long AV49TFContaBancariaNumero ;
      private long AV50TFContaBancariaNumero_To ;
      private long AV51TFContaBancariaCarteira ;
      private long AV52TFContaBancariaCarteira_To ;
      private long AV70GridCurrentPage ;
      private long AV71GridPageCount ;
      private long A952ContaBancariaNumero ;
      private long A953ContaBancariaCarteira ;
      private long GRID_nCurrentRecord ;
      private long AV86Contabancariawwds_4_contabancarianumero1 ;
      private long AV93Contabancariawwds_11_contabancarianumero2 ;
      private long AV100Contabancariawwds_18_contabancarianumero3 ;
      private long AV108Contabancariawwds_26_tfcontabancarianumero ;
      private long AV109Contabancariawwds_27_tfcontabancarianumero_to ;
      private long AV112Contabancariawwds_30_tfcontabancariacarteira ;
      private long AV113Contabancariawwds_31_tfcontabancariacarteira_to ;
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
      private string AV82Pgmname ;
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
      private string divDdo_contabancariacreatedatauxdates_Internalname ;
      private string edtavDdo_contabancariacreatedatauxdatetext_Internalname ;
      private string edtavDdo_contabancariacreatedatauxdatetext_Jsonclick ;
      private string Tfcontabancariacreatedat_rangepicker_Internalname ;
      private string divDdo_contabancariaupdatedatauxdates_Internalname ;
      private string edtavDdo_contabancariaupdatedatauxdatetext_Internalname ;
      private string edtavDdo_contabancariaupdatedatauxdatetext_Jsonclick ;
      private string Tfcontabancariaupdatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtContaBancariaId_Internalname ;
      private string edtAgenciaId_Internalname ;
      private string edtAgenciaBancoNome_Internalname ;
      private string edtAgenciaNumero_Internalname ;
      private string edtContaBancariaNumero_Internalname ;
      private string edtContaBancariaDigito_Internalname ;
      private string edtContaBancariaCarteira_Internalname ;
      private string cmbContaBancariaStatus_Internalname ;
      private string edtContaBancariaCreatedAt_Internalname ;
      private string edtContaBancariaCreatedBy_Internalname ;
      private string edtContaBancariaCreatedByName_Internalname ;
      private string edtContaBancariaUpdatedAt_Internalname ;
      private string edtContaBancariaUpdatedBy_Internalname ;
      private string edtContaBancariaUpdatedByName_Internalname ;
      private string cmbContaBancariaRegistraBoletos_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavContabancarianumero1_Internalname ;
      private string edtavAgencianumero1_Internalname ;
      private string edtavContabancariacreatedbyname1_Internalname ;
      private string edtavContabancariaupdatedbyname1_Internalname ;
      private string edtavContabancarianumero2_Internalname ;
      private string edtavAgencianumero2_Internalname ;
      private string edtavContabancariacreatedbyname2_Internalname ;
      private string edtavContabancariaupdatedbyname2_Internalname ;
      private string edtavContabancarianumero3_Internalname ;
      private string edtavAgencianumero3_Internalname ;
      private string edtavContabancariacreatedbyname3_Internalname ;
      private string edtavContabancariaupdatedbyname3_Internalname ;
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
      private string cmbContaBancariaStatus_Columnheaderclass ;
      private string cmbContaBancariaRegistraBoletos_Columnheaderclass ;
      private string edtAgenciaNumero_Link ;
      private string edtContaBancariaNumero_Link ;
      private string edtContaBancariaCreatedByName_Link ;
      private string edtContaBancariaUpdatedByName_Link ;
      private string cmbContaBancariaStatus_Columnclass ;
      private string cmbContaBancariaRegistraBoletos_Columnclass ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_contabancarianumero3_cell_Internalname ;
      private string edtavContabancarianumero3_Jsonclick ;
      private string cellFilter_agencianumero3_cell_Internalname ;
      private string edtavAgencianumero3_Jsonclick ;
      private string cellFilter_contabancariacreatedbyname3_cell_Internalname ;
      private string edtavContabancariacreatedbyname3_Jsonclick ;
      private string cellFilter_contabancariaupdatedbyname3_cell_Internalname ;
      private string edtavContabancariaupdatedbyname3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_contabancarianumero2_cell_Internalname ;
      private string edtavContabancarianumero2_Jsonclick ;
      private string cellFilter_agencianumero2_cell_Internalname ;
      private string edtavAgencianumero2_Jsonclick ;
      private string cellFilter_contabancariacreatedbyname2_cell_Internalname ;
      private string edtavContabancariacreatedbyname2_Jsonclick ;
      private string cellFilter_contabancariaupdatedbyname2_cell_Internalname ;
      private string edtavContabancariaupdatedbyname2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_contabancarianumero1_cell_Internalname ;
      private string edtavContabancarianumero1_Jsonclick ;
      private string cellFilter_agencianumero1_cell_Internalname ;
      private string edtavAgencianumero1_Jsonclick ;
      private string cellFilter_contabancariacreatedbyname1_cell_Internalname ;
      private string edtavContabancariacreatedbyname1_Jsonclick ;
      private string cellFilter_contabancariaupdatedbyname1_cell_Internalname ;
      private string edtavContabancariaupdatedbyname1_Jsonclick ;
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
      private string edtContaBancariaId_Jsonclick ;
      private string edtAgenciaId_Jsonclick ;
      private string edtAgenciaBancoNome_Jsonclick ;
      private string edtAgenciaNumero_Jsonclick ;
      private string edtContaBancariaNumero_Jsonclick ;
      private string edtContaBancariaDigito_Jsonclick ;
      private string edtContaBancariaCarteira_Jsonclick ;
      private string cmbContaBancariaStatus_Jsonclick ;
      private string edtContaBancariaCreatedAt_Jsonclick ;
      private string edtContaBancariaCreatedBy_Jsonclick ;
      private string edtContaBancariaCreatedByName_Jsonclick ;
      private string edtContaBancariaUpdatedAt_Jsonclick ;
      private string edtContaBancariaUpdatedBy_Jsonclick ;
      private string edtContaBancariaUpdatedByName_Jsonclick ;
      private string cmbContaBancariaRegistraBoletos_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV54TFContaBancariaCreatedAt ;
      private DateTime AV55TFContaBancariaCreatedAt_To ;
      private DateTime AV61TFContaBancariaUpdatedAt ;
      private DateTime AV62TFContaBancariaUpdatedAt_To ;
      private DateTime A954ContaBancariaCreatedAt ;
      private DateTime A955ContaBancariaUpdatedAt ;
      private DateTime AV115Contabancariawwds_33_tfcontabancariacreatedat ;
      private DateTime AV116Contabancariawwds_34_tfcontabancariacreatedat_to ;
      private DateTime AV119Contabancariawwds_37_tfcontabancariaupdatedat ;
      private DateTime AV120Contabancariawwds_38_tfcontabancariaupdatedat_to ;
      private DateTime AV56DDO_ContaBancariaCreatedAtAuxDate ;
      private DateTime AV57DDO_ContaBancariaCreatedAtAuxDateTo ;
      private DateTime AV63DDO_ContaBancariaUpdatedAtAuxDate ;
      private DateTime AV64DDO_ContaBancariaUpdatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV38DynamicFiltersIgnoreFirst ;
      private bool AV37DynamicFiltersRemoving ;
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
      private bool n938AgenciaId ;
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool n952ContaBancariaNumero ;
      private bool n975ContaBancariaDigito ;
      private bool n953ContaBancariaCarteira ;
      private bool A956ContaBancariaStatus ;
      private bool n956ContaBancariaStatus ;
      private bool n954ContaBancariaCreatedAt ;
      private bool n947ContaBancariaCreatedBy ;
      private bool n948ContaBancariaCreatedByName ;
      private bool n955ContaBancariaUpdatedAt ;
      private bool n949ContaBancariaUpdatedBy ;
      private bool n950ContaBancariaUpdatedByName ;
      private bool A973ContaBancariaRegistraBoletos ;
      private bool n973ContaBancariaRegistraBoletos ;
      private bool bGXsfl_137_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV90Contabancariawwds_8_dynamicfiltersenabled2 ;
      private bool AV97Contabancariawwds_15_dynamicfiltersenabled3 ;
      private bool n968AgenciaBancoId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV43ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV21ContaBancariaCreatedByName1 ;
      private string AV22ContaBancariaUpdatedByName1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28ContaBancariaCreatedByName2 ;
      private string AV29ContaBancariaUpdatedByName2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV35ContaBancariaCreatedByName3 ;
      private string AV36ContaBancariaUpdatedByName3 ;
      private string AV76TFAgenciaBancoNome ;
      private string AV77TFAgenciaBancoNome_Sel ;
      private string AV59TFContaBancariaCreatedByName ;
      private string AV60TFContaBancariaCreatedByName_Sel ;
      private string AV66TFContaBancariaUpdatedByName ;
      private string AV67TFContaBancariaUpdatedByName_Sel ;
      private string AV72GridAppliedFilters ;
      private string AV58DDO_ContaBancariaCreatedAtAuxDateText ;
      private string AV65DDO_ContaBancariaUpdatedAtAuxDateText ;
      private string A969AgenciaBancoNome ;
      private string A948ContaBancariaCreatedByName ;
      private string A950ContaBancariaUpdatedByName ;
      private string lV83Contabancariawwds_1_filterfulltext ;
      private string lV88Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string lV89Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string lV95Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string lV96Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string lV102Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string lV103Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string lV104Contabancariawwds_22_tfagenciabanconome ;
      private string lV117Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string lV121Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string AV83Contabancariawwds_1_filterfulltext ;
      private string AV84Contabancariawwds_2_dynamicfiltersselector1 ;
      private string AV88Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string AV89Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string AV91Contabancariawwds_9_dynamicfiltersselector2 ;
      private string AV95Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string AV96Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string AV98Contabancariawwds_16_dynamicfiltersselector3 ;
      private string AV102Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string AV103Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string AV105Contabancariawwds_23_tfagenciabanconome_sel ;
      private string AV104Contabancariawwds_22_tfagenciabanconome ;
      private string AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel ;
      private string AV117Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ;
      private string AV121Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string AV39ExcelFilename ;
      private string AV40ErrorMessage ;
      private IGxSession AV41Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcontabancariacreatedat_rangepicker ;
      private GXUserControl ucTfcontabancariaupdatedat_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbContaBancariaStatus ;
      private GXCombobox cmbContaBancariaRegistraBoletos ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV42ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV68DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private int[] H009K2_A968AgenciaBancoId ;
      private bool[] H009K2_n968AgenciaBancoId ;
      private bool[] H009K2_A973ContaBancariaRegistraBoletos ;
      private bool[] H009K2_n973ContaBancariaRegistraBoletos ;
      private string[] H009K2_A950ContaBancariaUpdatedByName ;
      private bool[] H009K2_n950ContaBancariaUpdatedByName ;
      private short[] H009K2_A949ContaBancariaUpdatedBy ;
      private bool[] H009K2_n949ContaBancariaUpdatedBy ;
      private DateTime[] H009K2_A955ContaBancariaUpdatedAt ;
      private bool[] H009K2_n955ContaBancariaUpdatedAt ;
      private string[] H009K2_A948ContaBancariaCreatedByName ;
      private bool[] H009K2_n948ContaBancariaCreatedByName ;
      private short[] H009K2_A947ContaBancariaCreatedBy ;
      private bool[] H009K2_n947ContaBancariaCreatedBy ;
      private DateTime[] H009K2_A954ContaBancariaCreatedAt ;
      private bool[] H009K2_n954ContaBancariaCreatedAt ;
      private bool[] H009K2_A956ContaBancariaStatus ;
      private bool[] H009K2_n956ContaBancariaStatus ;
      private long[] H009K2_A953ContaBancariaCarteira ;
      private bool[] H009K2_n953ContaBancariaCarteira ;
      private short[] H009K2_A975ContaBancariaDigito ;
      private bool[] H009K2_n975ContaBancariaDigito ;
      private long[] H009K2_A952ContaBancariaNumero ;
      private bool[] H009K2_n952ContaBancariaNumero ;
      private int[] H009K2_A939AgenciaNumero ;
      private bool[] H009K2_n939AgenciaNumero ;
      private string[] H009K2_A969AgenciaBancoNome ;
      private bool[] H009K2_n969AgenciaBancoNome ;
      private int[] H009K2_A938AgenciaId ;
      private bool[] H009K2_n938AgenciaId ;
      private int[] H009K2_A951ContaBancariaId ;
      private long[] H009K3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class contabancariaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009K2( IGxContext context ,
                                             string AV83Contabancariawwds_1_filterfulltext ,
                                             string AV84Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV85Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV86Contabancariawwds_4_contabancarianumero1 ,
                                             int AV87Contabancariawwds_5_agencianumero1 ,
                                             string AV88Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV89Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV90Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV91Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV92Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV93Contabancariawwds_11_contabancarianumero2 ,
                                             int AV94Contabancariawwds_12_agencianumero2 ,
                                             string AV95Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV96Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV97Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV98Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV99Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV100Contabancariawwds_18_contabancarianumero3 ,
                                             int AV101Contabancariawwds_19_agencianumero3 ,
                                             string AV102Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV103Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV105Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV104Contabancariawwds_22_tfagenciabanconome ,
                                             int AV106Contabancariawwds_24_tfagencianumero ,
                                             int AV107Contabancariawwds_25_tfagencianumero_to ,
                                             long AV108Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV109Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV110Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV111Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV112Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV113Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV114Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV115Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV116Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV117Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV119Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV120Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV121Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV7AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[63];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T4.AgenciaBancoId AS AgenciaBancoId, T1.ContaBancariaRegistraBoletos, T2.SecUserName AS ContaBancariaUpdatedByName, T1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, T1.ContaBancariaUpdatedAt, T3.SecUserName AS ContaBancariaCreatedByName, T1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, T1.ContaBancariaCreatedAt, T1.ContaBancariaStatus, T1.ContaBancariaCarteira, T1.ContaBancariaDigito, T1.ContaBancariaNumero, T4.AgenciaNumero, T5.BancoNome AS AgenciaBancoNome, T1.AgenciaId, T1.ContaBancariaId";
         sFromString = " FROM ((((ContaBancaria T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN Agencia T4 ON T4.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T5 ON T5.BancoId = T4.AgenciaBancoId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T5.BancoNome) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T4.AgenciaNumero,'999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
            GXv_int6[9] = 1;
            GXv_int6[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV88Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV88Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV89Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV89Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV95Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV95Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV96Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV96Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV102Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV102Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV103Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int6[39] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV103Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int6[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome like :lV104Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int6[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV105Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome = ( :AV105Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int6[42] = 1;
         }
         if ( StringUtil.StrCmp(AV105Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.BancoNome IS NULL or (char_length(trim(trailing ' ' from T5.BancoNome))=0))");
         }
         if ( ! (0==AV106Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero >= :AV106Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int6[43] = 1;
         }
         if ( ! (0==AV107Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero <= :AV107Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int6[44] = 1;
         }
         if ( ! (0==AV108Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV108Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int6[45] = 1;
         }
         if ( ! (0==AV109Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV109Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int6[46] = 1;
         }
         if ( ! (0==AV110Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV110Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int6[47] = 1;
         }
         if ( ! (0==AV111Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV111Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int6[48] = 1;
         }
         if ( ! (0==AV112Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV112Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int6[49] = 1;
         }
         if ( ! (0==AV113Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV113Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int6[50] = 1;
         }
         if ( AV114Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV114Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV115Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV115Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int6[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV116Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int6[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV117Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int6[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int6[54] = 1;
         }
         if ( StringUtil.StrCmp(AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV119Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV119Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int6[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV120Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int6[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV121Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int6[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int6[58] = 1;
         }
         if ( StringUtil.StrCmp(AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV7AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV7AgenciaId)");
         }
         else
         {
            GXv_int6[59] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaNumero, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaNumero DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T5.BancoNome, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T5.BancoNome DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T4.AgenciaNumero, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.AgenciaNumero DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaDigito, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaDigito DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaCarteira, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaCarteira DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaStatus, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaStatus DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaCreatedAt, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaCreatedAt DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.SecUserName, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.SecUserName DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaUpdatedAt, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaUpdatedAt DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserName, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserName DESC, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContaBancariaRegistraBoletos, T1.ContaBancariaId";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContaBancariaRegistraBoletos DESC, T1.ContaBancariaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ContaBancariaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H009K3( IGxContext context ,
                                             string AV83Contabancariawwds_1_filterfulltext ,
                                             string AV84Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV85Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV86Contabancariawwds_4_contabancarianumero1 ,
                                             int AV87Contabancariawwds_5_agencianumero1 ,
                                             string AV88Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV89Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV90Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV91Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV92Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV93Contabancariawwds_11_contabancarianumero2 ,
                                             int AV94Contabancariawwds_12_agencianumero2 ,
                                             string AV95Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV96Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV97Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV98Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV99Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV100Contabancariawwds_18_contabancarianumero3 ,
                                             int AV101Contabancariawwds_19_agencianumero3 ,
                                             string AV102Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV103Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV105Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV104Contabancariawwds_22_tfagenciabanconome ,
                                             int AV106Contabancariawwds_24_tfagencianumero ,
                                             int AV107Contabancariawwds_25_tfagencianumero_to ,
                                             long AV108Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV109Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV110Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV111Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV112Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV113Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV114Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV115Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV116Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV117Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV119Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV120Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV121Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV7AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[60];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((((ContaBancaria T1 LEFT JOIN SecUser T5 ON T5.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN Agencia T2 ON T2.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T3 ON T3.BancoId = T2.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.BancoNome) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T2.AgenciaNumero,'999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV83Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T4.SecUserName) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( LOWER(T5.SecUserName) like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV83Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
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
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV86Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV86Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero < :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero = :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV87Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero > :AV87Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like :lV88Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like '%' || :lV88Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV89Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV85Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV89Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV93Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV93Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero < :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero = :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV94Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero > :AV94Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like :lV95Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like '%' || :lV95Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV96Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( AV90Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV91Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV92Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV96Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV100Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV100Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero < :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero = :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV101Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero > :AV101Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like :lV102Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like '%' || :lV102Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV103Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( AV97Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV99Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like '%' || :lV103Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T3.BancoNome like :lV104Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV105Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.BancoNome = ( :AV105Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( StringUtil.StrCmp(AV105Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.BancoNome IS NULL or (char_length(trim(trailing ' ' from T3.BancoNome))=0))");
         }
         if ( ! (0==AV106Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero >= :AV106Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( ! (0==AV107Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T2.AgenciaNumero <= :AV107Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( ! (0==AV108Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV108Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( ! (0==AV109Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV109Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( ! (0==AV110Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV110Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( ! (0==AV111Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV111Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( ! (0==AV112Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV112Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( ! (0==AV113Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV113Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( AV114Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV114Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV115Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV115Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV116Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName like :lV117Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.SecUserName = ( :AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( StringUtil.StrCmp(AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.SecUserName IS NULL or (char_length(trim(trailing ' ' from T4.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV119Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV119Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV120Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName like :lV121Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.SecUserName = ( :AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( StringUtil.StrCmp(AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.SecUserName IS NULL or (char_length(trim(trailing ' ' from T5.SecUserName))=0))");
         }
         if ( AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV123Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV7AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV7AgenciaId)");
         }
         else
         {
            GXv_int8[59] = 1;
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
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
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
                     return conditional_H009K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
               case 1 :
                     return conditional_H009K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
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
          Object[] prmH009K2;
          prmH009K2 = new Object[] {
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV88Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV88Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV95Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV95Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV102Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV102Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV105Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV107Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV108Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV109Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV110Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV111Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV112Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV113Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV115Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV116Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV117Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV119Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV120Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV121Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV7AgenciaId",GXType.Int32,9,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009K3;
          prmH009K3 = new Object[] {
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV86Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV87Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV88Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV88Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV93Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV94Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV95Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV95Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV100Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV101Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV102Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV102Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV105Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV107Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV108Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV109Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV110Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV111Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV112Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV113Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV115Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV116Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV117Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV118Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV119Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV120Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV121Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV122Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV7AgenciaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009K3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
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
                ((bool[]) buf[16])[0] = rslt.getBool(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((long[]) buf[18])[0] = rslt.getLong(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((long[]) buf[22])[0] = rslt.getLong(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
