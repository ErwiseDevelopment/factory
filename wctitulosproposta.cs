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
   public class wctitulosproposta : GXWebComponent
   {
      public wctitulosproposta( )
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

      public wctitulosproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_TituloPropostaId ,
                           bool aP1_IsUnique )
      {
         this.AV7TituloPropostaId = aP0_TituloPropostaId;
         this.AV63IsUnique = aP1_IsUnique;
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
         cmbTituloPropostaTipo = new GXCombobox();
         chkTituloDeleted = new GXCheckbox();
         cmbTituloTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "TituloPropostaId");
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
                  AV7TituloPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloPropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV7TituloPropostaId), 9, 0));
                  AV63IsUnique = StringUtil.StrToBool( GetPar( "IsUnique"));
                  AssignAttri(sPrefix, false, "AV63IsUnique", AV63IsUnique);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV7TituloPropostaId,(bool)AV63IsUnique});
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
                  gxfirstwebparm = GetFirstPar( "TituloPropostaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TituloPropostaId");
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
         nRC_GXsfl_96 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_96"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_96_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_96_idx = GetPar( "sGXsfl_96_idx");
         sPrefix = GetPar( "sPrefix");
         edtClienteRazaoSocial_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtClienteRazaoSocial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Visible), 5, 0), !bGXsfl_96_Refreshing);
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
         AV19TituloValor1 = NumberUtil.Val( GetPar( "TituloValor1"), ".");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23TituloValor2 = NumberUtil.Val( GetPar( "TituloValor2"), ".");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV27TituloValor3 = NumberUtil.Val( GetPar( "TituloValor3"), ".");
         AV33ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV7TituloPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloPropostaId"), "."), 18, MidpointRounding.ToEven));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV36TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV37TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV65TFTituloPropostaTipo_Sels);
         AV38TFTituloValor = NumberUtil.Val( GetPar( "TFTituloValor"), ".");
         AV39TFTituloValor_To = NumberUtil.Val( GetPar( "TFTituloValor_To"), ".");
         AV40TFTituloDesconto = NumberUtil.Val( GetPar( "TFTituloDesconto"), ".");
         AV41TFTituloDesconto_To = NumberUtil.Val( GetPar( "TFTituloDesconto_To"), ".");
         AV42TFTituloCompetencia_F = GetPar( "TFTituloCompetencia_F");
         AV43TFTituloCompetencia_F_Sel = GetPar( "TFTituloCompetencia_F_Sel");
         AV44TFTituloProrrogacao = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao"));
         AV45TFTituloProrrogacao_To = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV50TFTituloTipo_Sels);
         AV51TFTituloSaldo_F = NumberUtil.Val( GetPar( "TFTituloSaldo_F"), ".");
         AV52TFTituloSaldo_F_To = NumberUtil.Val( GetPar( "TFTituloSaldo_F_To"), ".");
         AV58TFTituloStatus_F = GetPar( "TFTituloStatus_F");
         AV59TFTituloStatus_F_Sel = GetPar( "TFTituloStatus_F_Sel");
         AV96Pgmname = GetPar( "Pgmname");
         AV63IsUnique = StringUtil.StrToBool( GetPar( "IsUnique"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV29DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV28DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         edtClienteRazaoSocial_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtClienteRazaoSocial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Visible), 5, 0), !bGXsfl_96_Refreshing);
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
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
            PA7O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV96Pgmname = "WCTitulosProposta";
               Gx_date = DateTimeUtil.Today( context);
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_96_Refreshing);
               WS7O2( ) ;
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
            context.SendWebValue( " Titulo") ;
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
            GXEncryptionTmp = "wctitulosproposta"+UrlEncode(StringUtil.LTrimStr(AV7TituloPropostaId,9,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV63IsUnique));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wctitulosproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOVALOR1", StringUtil.LTrim( StringUtil.NToC( AV19TituloValor1, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOVALOR2", StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOVALOR3", StringUtil.LTrim( StringUtil.NToC( AV27TituloValor3, 18, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_96", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_96), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOPRORROGACAOAUXDATE", context.localUtil.DToC( AV46DDO_TituloProrrogacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOPRORROGACAOAUXDATETO", context.localUtil.DToC( AV47DDO_TituloProrrogacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7TituloPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV63IsUnique", wcpOAV63IsUnique);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCLIENTERAZAOSOCIAL", AV36TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCLIENTERAZAOSOCIAL_SEL", AV37TFClienteRazaoSocial_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFTITULOPROPOSTATIPO_SELS", AV65TFTituloPropostaTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFTITULOPROPOSTATIPO_SELS", AV65TFTituloPropostaTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOVALOR", StringUtil.LTrim( StringUtil.NToC( AV38TFTituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV39TFTituloValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULODESCONTO", StringUtil.LTrim( StringUtil.NToC( AV40TFTituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULODESCONTO_TO", StringUtil.LTrim( StringUtil.NToC( AV41TFTituloDesconto_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOCOMPETENCIA_F", AV42TFTituloCompetencia_F);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOCOMPETENCIA_F_SEL", AV43TFTituloCompetencia_F_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOPRORROGACAO", context.localUtil.DToC( AV44TFTituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOPRORROGACAO_TO", context.localUtil.DToC( AV45TFTituloProrrogacao_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFTITULOTIPO_SELS", AV50TFTituloTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFTITULOTIPO_SELS", AV50TFTituloTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOSALDO_F", StringUtil.LTrim( StringUtil.NToC( AV51TFTituloSaldo_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOSALDO_F_TO", StringUtil.LTrim( StringUtil.NToC( AV52TFTituloSaldo_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOSTATUS_F", AV58TFTituloStatus_F);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOSTATUS_F_SEL", AV59TFTituloStatus_F_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISUNIQUE", AV63IsUnique);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV29DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV28DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOPROPOSTATIPO_SELSJSON", AV64TFTituloPropostaTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOTIPO_SELSJSON", AV49TFTituloTipo_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTERAZAOSOCIAL_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteRazaoSocial_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm7O2( )
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
         return "WCTitulosProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return " Titulo" ;
      }

      protected void WB7O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wctitulosproposta");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WCTitulosProposta.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV17DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_37_7O2( true) ;
         }
         else
         {
            wb_table1_37_7O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_37_7O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_59_7O2( true) ;
         }
         else
         {
            wb_table2_59_7O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_59_7O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_81_7O2( true) ;
         }
         else
         {
            wb_table3_81_7O2( false) ;
         }
         return  ;
      }

      protected void wb_table3_81_7O2e( bool wbgen )
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
            StartGridControl96( ) ;
         }
         if ( wbEnd == 96 )
         {
            wbEnd = 0;
            nRC_GXsfl_96 = (int)(nGXsfl_96_idx-1);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WCTitulosProposta.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV60DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTituloPropostaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloPropostaId_Visible, 0, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WCTitulosProposta.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_tituloprorrogacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tituloprorrogacaoauxdatetext_Internalname, AV48DDO_TituloProrrogacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV48DDO_TituloProrrogacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WCTitulosProposta.htm");
            /* User Defined Control */
            ucTftituloprorrogacao_rangepicker.SetProperty("Start Date", AV46DDO_TituloProrrogacaoAuxDate);
            ucTftituloprorrogacao_rangepicker.SetProperty("End Date", AV47DDO_TituloProrrogacaoAuxDateTo);
            ucTftituloprorrogacao_rangepicker.Render(context, "wwp.daterangepicker", Tftituloprorrogacao_rangepicker_Internalname, sPrefix+"TFTITULOPRORROGACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 96 )
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

      protected void START7O2( )
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
            Form.Meta.addItem("description", " Titulo", 0) ;
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
               STRUP7O0( ) ;
            }
         }
      }

      protected void WS7O2( )
      {
         START7O2( ) ;
         EVT7O2( ) ;
      }

      protected void EVT7O2( )
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
                                 STRUP7O0( ) ;
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
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E117O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E127O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E137O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E147O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E157O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E167O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E177O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E187O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E197O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E207O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
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
                                 STRUP7O0( ) ;
                              }
                              AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
                              AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
                              AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
                              AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
                              AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
                              AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
                              AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
                              AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
                              AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
                              AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
                              AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
                              AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
                              AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
                              AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
                              AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
                              AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
                              AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
                              AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
                              AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
                              AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
                              AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
                              AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
                              AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
                              AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
                              AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
                              AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
                              AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
                              AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
                              AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
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
                                 STRUP7O0( ) ;
                              }
                              nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
                              SubsflControlProps_962( ) ;
                              AV61Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV61Display);
                              A428CategoriaTituloDescricao = cgiGet( edtCategoriaTituloDescricao_Internalname);
                              n428CategoriaTituloDescricao = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              cmbTituloPropostaTipo.Name = cmbTituloPropostaTipo_Internalname;
                              cmbTituloPropostaTipo.CurrentValue = cgiGet( cmbTituloPropostaTipo_Internalname);
                              A648TituloPropostaTipo = cgiGet( cmbTituloPropostaTipo_Internalname);
                              n648TituloPropostaTipo = false;
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
                              n262TituloValor = false;
                              A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
                              n276TituloDesconto = false;
                              A284TituloDeleted = StringUtil.StrToBool( cgiGet( chkTituloDeleted_Internalname));
                              n284TituloDeleted = false;
                              A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n286TituloCompetenciaAno = false;
                              A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n287TituloCompetenciaMes = false;
                              A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
                              A264TituloProrrogacao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloProrrogacao_Internalname), 0));
                              n264TituloProrrogacao = false;
                              cmbTituloTipo.Name = cmbTituloTipo_Internalname;
                              cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
                              A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
                              n283TituloTipo = false;
                              A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
                              n273TituloTotalMovimento_F = false;
                              A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
                              n275TituloSaldo_F = false;
                              A516TituloDataCredito_F = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloDataCredito_F_Internalname), 0));
                              n516TituloDataCredito_F = false;
                              A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
                              n282TituloStatus_F = false;
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
                                          E217O2 ();
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
                                          E227O2 ();
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
                                          E237O2 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulovalor1 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR1"), ",", ".") != AV19TituloValor1 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulovalor2 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR2"), ",", ".") != AV23TituloValor2 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulovalor3 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR3"), ",", ".") != AV27TituloValor3 )
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
                                       STRUP7O0( ) ;
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

      protected void WE7O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7O2( ) ;
            }
         }
      }

      protected void PA7O2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wctitulosproposta")), "wctitulosproposta") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wctitulosproposta")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TituloPropostaId");
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
         SubsflControlProps_962( ) ;
         while ( nGXsfl_96_idx <= nRC_GXsfl_96 )
         {
            sendrow_962( ) ;
            nGXsfl_96_idx = ((subGrid_Islastpage==1)&&(nGXsfl_96_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       decimal AV19TituloValor1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       decimal AV23TituloValor2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       decimal AV27TituloValor3 ,
                                       short AV33ManageFiltersExecutionStep ,
                                       int AV7TituloPropostaId ,
                                       string AV16FilterFullText ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV36TFClienteRazaoSocial ,
                                       string AV37TFClienteRazaoSocial_Sel ,
                                       GxSimpleCollection<string> AV65TFTituloPropostaTipo_Sels ,
                                       decimal AV38TFTituloValor ,
                                       decimal AV39TFTituloValor_To ,
                                       decimal AV40TFTituloDesconto ,
                                       decimal AV41TFTituloDesconto_To ,
                                       string AV42TFTituloCompetencia_F ,
                                       string AV43TFTituloCompetencia_F_Sel ,
                                       DateTime AV44TFTituloProrrogacao ,
                                       DateTime AV45TFTituloProrrogacao_To ,
                                       GxSimpleCollection<string> AV50TFTituloTipo_Sels ,
                                       decimal AV51TFTituloSaldo_F ,
                                       decimal AV52TFTituloSaldo_F_To ,
                                       string AV58TFTituloStatus_F ,
                                       string AV59TFTituloStatus_F_Sel ,
                                       string AV96Pgmname ,
                                       bool AV63IsUnique ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV29DynamicFiltersIgnoreFirst ,
                                       bool AV28DynamicFiltersRemoving ,
                                       DateTime Gx_date ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7O2( ) ;
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
            AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV96Pgmname = "WCTitulosProposta";
         Gx_date = DateTimeUtil.Today( context);
         edtavDisplay_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV81Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              A283TituloTipo ,
                                              AV90Wctitulospropostads_25_tftitulotipo_sels ,
                                              AV68Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              AV69Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              AV70Wctitulospropostads_5_titulovalor1 ,
                                              AV71Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              AV72Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              AV73Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              AV74Wctitulospropostads_9_titulovalor2 ,
                                              AV75Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              AV76Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              AV77Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              AV78Wctitulospropostads_13_titulovalor3 ,
                                              AV80Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              AV79Wctitulospropostads_14_tfclienterazaosocial ,
                                              AV81Wctitulospropostads_16_tftitulopropostatipo_sels.Count ,
                                              AV82Wctitulospropostads_17_tftitulovalor ,
                                              AV83Wctitulospropostads_18_tftitulovalor_to ,
                                              AV84Wctitulospropostads_19_tftitulodesconto ,
                                              AV85Wctitulospropostads_20_tftitulodesconto_to ,
                                              AV88Wctitulospropostads_23_tftituloprorrogacao ,
                                              AV89Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              AV90Wctitulospropostads_25_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV67Wctitulospropostads_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV87Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              AV86Wctitulospropostads_21_tftitulocompetencia_f ,
                                              AV91Wctitulospropostads_26_tftitulosaldo_f ,
                                              AV92Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              AV94Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              AV93Wctitulospropostads_28_tftitulostatus_f ,
                                              A419TituloPropostaId ,
                                              AV66Wctitulospropostads_1_titulopropostaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV93Wctitulospropostads_28_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV93Wctitulospropostads_28_tftitulostatus_f), "%", "");
         lV79Wctitulospropostads_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV79Wctitulospropostads_14_tfclienterazaosocial), "%", "");
         /* Using cursor H007O9 */
         pr_default.execute(0, new Object[] {AV91Wctitulospropostads_26_tftitulosaldo_f, AV91Wctitulospropostads_26_tftitulosaldo_f, AV92Wctitulospropostads_27_tftitulosaldo_f_to, AV92Wctitulospropostads_27_tftitulosaldo_f_to, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV93Wctitulospropostads_28_tftitulostatus_f, lV93Wctitulospropostads_28_tftitulostatus_f, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV66Wctitulospropostads_1_titulopropostaid, AV70Wctitulospropostads_5_titulovalor1, AV70Wctitulospropostads_5_titulovalor1, AV70Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_9_titulovalor2, AV74Wctitulospropostads_9_titulovalor2, AV74Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_13_titulovalor3, AV78Wctitulospropostads_13_titulovalor3, AV78Wctitulospropostads_13_titulovalor3, lV79Wctitulospropostads_14_tfclienterazaosocial, AV80Wctitulospropostads_15_tfclienterazaosocial_sel, AV82Wctitulospropostads_17_tftitulovalor, AV83Wctitulospropostads_18_tftitulovalor_to, AV84Wctitulospropostads_19_tftitulodesconto, AV85Wctitulospropostads_20_tftitulodesconto_to, AV88Wctitulospropostads_23_tftituloprorrogacao, AV89Wctitulospropostads_24_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A426CategoriaTituloId = H007O9_A426CategoriaTituloId[0];
            n426CategoriaTituloId = H007O9_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = H007O9_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H007O9_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = H007O9_A794NotaFiscalId[0];
            n794NotaFiscalId = H007O9_n794NotaFiscalId[0];
            A168ClienteId = H007O9_A168ClienteId[0];
            n168ClienteId = H007O9_n168ClienteId[0];
            A419TituloPropostaId = H007O9_A419TituloPropostaId[0];
            n419TituloPropostaId = H007O9_n419TituloPropostaId[0];
            AssignAttri(sPrefix, false, "A419TituloPropostaId", StringUtil.LTrimStr( (decimal)(A419TituloPropostaId), 9, 0));
            A283TituloTipo = H007O9_A283TituloTipo[0];
            n283TituloTipo = H007O9_n283TituloTipo[0];
            A264TituloProrrogacao = H007O9_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H007O9_n264TituloProrrogacao[0];
            A284TituloDeleted = H007O9_A284TituloDeleted[0];
            n284TituloDeleted = H007O9_n284TituloDeleted[0];
            A276TituloDesconto = H007O9_A276TituloDesconto[0];
            n276TituloDesconto = H007O9_n276TituloDesconto[0];
            A262TituloValor = H007O9_A262TituloValor[0];
            n262TituloValor = H007O9_n262TituloValor[0];
            A261TituloId = H007O9_A261TituloId[0];
            n261TituloId = H007O9_n261TituloId[0];
            A648TituloPropostaTipo = H007O9_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = H007O9_n648TituloPropostaTipo[0];
            A170ClienteRazaoSocial = H007O9_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H007O9_n170ClienteRazaoSocial[0];
            A428CategoriaTituloDescricao = H007O9_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = H007O9_n428CategoriaTituloDescricao[0];
            A282TituloStatus_F = H007O9_A282TituloStatus_F[0];
            n282TituloStatus_F = H007O9_n282TituloStatus_F[0];
            A516TituloDataCredito_F = H007O9_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H007O9_n516TituloDataCredito_F[0];
            A275TituloSaldo_F = H007O9_A275TituloSaldo_F[0];
            n275TituloSaldo_F = H007O9_n275TituloSaldo_F[0];
            A273TituloTotalMovimento_F = H007O9_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H007O9_n273TituloTotalMovimento_F[0];
            A286TituloCompetenciaAno = H007O9_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = H007O9_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = H007O9_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = H007O9_n287TituloCompetenciaMes[0];
            A428CategoriaTituloDescricao = H007O9_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = H007O9_n428CategoriaTituloDescricao[0];
            A794NotaFiscalId = H007O9_A794NotaFiscalId[0];
            n794NotaFiscalId = H007O9_n794NotaFiscalId[0];
            A168ClienteId = H007O9_A168ClienteId[0];
            n168ClienteId = H007O9_n168ClienteId[0];
            A170ClienteRazaoSocial = H007O9_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H007O9_n170ClienteRazaoSocial[0];
            A282TituloStatus_F = H007O9_A282TituloStatus_F[0];
            n282TituloStatus_F = H007O9_n282TituloStatus_F[0];
            A516TituloDataCredito_F = H007O9_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H007O9_n516TituloDataCredito_F[0];
            A275TituloSaldo_F = H007O9_A275TituloSaldo_F[0];
            n275TituloSaldo_F = H007O9_n275TituloSaldo_F[0];
            A273TituloTotalMovimento_F = H007O9_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H007O9_n273TituloTotalMovimento_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wctitulospropostads_2_filterfulltext)) || ( ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wctitulospropostads_21_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV86Wctitulospropostads_21_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV87Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV87Wctitulospropostads_22_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV87Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF7O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 96;
         /* Execute user event: Refresh */
         E227O2 ();
         nGXsfl_96_idx = 1;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_962( ) ;
         bGXsfl_96_Refreshing = true;
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
            SubsflControlProps_962( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A648TituloPropostaTipo ,
                                                 AV81Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                                 A283TituloTipo ,
                                                 AV90Wctitulospropostads_25_tftitulotipo_sels ,
                                                 AV68Wctitulospropostads_3_dynamicfiltersselector1 ,
                                                 AV69Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                                 AV70Wctitulospropostads_5_titulovalor1 ,
                                                 AV71Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                                 AV72Wctitulospropostads_7_dynamicfiltersselector2 ,
                                                 AV73Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                                 AV74Wctitulospropostads_9_titulovalor2 ,
                                                 AV75Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                                 AV76Wctitulospropostads_11_dynamicfiltersselector3 ,
                                                 AV77Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                                 AV78Wctitulospropostads_13_titulovalor3 ,
                                                 AV80Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                                 AV79Wctitulospropostads_14_tfclienterazaosocial ,
                                                 AV81Wctitulospropostads_16_tftitulopropostatipo_sels.Count ,
                                                 AV82Wctitulospropostads_17_tftitulovalor ,
                                                 AV83Wctitulospropostads_18_tftitulovalor_to ,
                                                 AV84Wctitulospropostads_19_tftitulodesconto ,
                                                 AV85Wctitulospropostads_20_tftitulodesconto_to ,
                                                 AV88Wctitulospropostads_23_tftituloprorrogacao ,
                                                 AV89Wctitulospropostads_24_tftituloprorrogacao_to ,
                                                 AV90Wctitulospropostads_25_tftitulotipo_sels.Count ,
                                                 A262TituloValor ,
                                                 A170ClienteRazaoSocial ,
                                                 A276TituloDesconto ,
                                                 A264TituloProrrogacao ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV67Wctitulospropostads_2_filterfulltext ,
                                                 A295TituloCompetencia_F ,
                                                 A275TituloSaldo_F ,
                                                 A282TituloStatus_F ,
                                                 AV87Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                                 AV86Wctitulospropostads_21_tftitulocompetencia_f ,
                                                 AV91Wctitulospropostads_26_tftitulosaldo_f ,
                                                 AV92Wctitulospropostads_27_tftitulosaldo_f_to ,
                                                 AV94Wctitulospropostads_29_tftitulostatus_f_sel ,
                                                 AV93Wctitulospropostads_28_tftitulostatus_f ,
                                                 A419TituloPropostaId ,
                                                 AV66Wctitulospropostads_1_titulopropostaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL,
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV93Wctitulospropostads_28_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV93Wctitulospropostads_28_tftitulostatus_f), "%", "");
            lV79Wctitulospropostads_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV79Wctitulospropostads_14_tfclienterazaosocial), "%", "");
            /* Using cursor H007O17 */
            pr_default.execute(1, new Object[] {AV91Wctitulospropostads_26_tftitulosaldo_f, AV91Wctitulospropostads_26_tftitulosaldo_f, AV92Wctitulospropostads_27_tftitulosaldo_f_to, AV92Wctitulospropostads_27_tftitulosaldo_f_to, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV93Wctitulospropostads_28_tftitulostatus_f, lV93Wctitulospropostads_28_tftitulostatus_f, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV94Wctitulospropostads_29_tftitulostatus_f_sel, AV66Wctitulospropostads_1_titulopropostaid, AV70Wctitulospropostads_5_titulovalor1, AV70Wctitulospropostads_5_titulovalor1, AV70Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_9_titulovalor2, AV74Wctitulospropostads_9_titulovalor2, AV74Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_13_titulovalor3, AV78Wctitulospropostads_13_titulovalor3, AV78Wctitulospropostads_13_titulovalor3, lV79Wctitulospropostads_14_tfclienterazaosocial, AV80Wctitulospropostads_15_tfclienterazaosocial_sel, AV82Wctitulospropostads_17_tftitulovalor, AV83Wctitulospropostads_18_tftitulovalor_to, AV84Wctitulospropostads_19_tftitulodesconto, AV85Wctitulospropostads_20_tftitulodesconto_to, AV88Wctitulospropostads_23_tftituloprorrogacao, AV89Wctitulospropostads_24_tftituloprorrogacao_to});
            nGXsfl_96_idx = 1;
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A426CategoriaTituloId = H007O17_A426CategoriaTituloId[0];
               n426CategoriaTituloId = H007O17_n426CategoriaTituloId[0];
               A890NotaFiscalParcelamentoID = H007O17_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H007O17_n890NotaFiscalParcelamentoID[0];
               A794NotaFiscalId = H007O17_A794NotaFiscalId[0];
               n794NotaFiscalId = H007O17_n794NotaFiscalId[0];
               A168ClienteId = H007O17_A168ClienteId[0];
               n168ClienteId = H007O17_n168ClienteId[0];
               A419TituloPropostaId = H007O17_A419TituloPropostaId[0];
               n419TituloPropostaId = H007O17_n419TituloPropostaId[0];
               AssignAttri(sPrefix, false, "A419TituloPropostaId", StringUtil.LTrimStr( (decimal)(A419TituloPropostaId), 9, 0));
               A283TituloTipo = H007O17_A283TituloTipo[0];
               n283TituloTipo = H007O17_n283TituloTipo[0];
               A264TituloProrrogacao = H007O17_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H007O17_n264TituloProrrogacao[0];
               A284TituloDeleted = H007O17_A284TituloDeleted[0];
               n284TituloDeleted = H007O17_n284TituloDeleted[0];
               A276TituloDesconto = H007O17_A276TituloDesconto[0];
               n276TituloDesconto = H007O17_n276TituloDesconto[0];
               A262TituloValor = H007O17_A262TituloValor[0];
               n262TituloValor = H007O17_n262TituloValor[0];
               A261TituloId = H007O17_A261TituloId[0];
               n261TituloId = H007O17_n261TituloId[0];
               A648TituloPropostaTipo = H007O17_A648TituloPropostaTipo[0];
               n648TituloPropostaTipo = H007O17_n648TituloPropostaTipo[0];
               A170ClienteRazaoSocial = H007O17_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007O17_n170ClienteRazaoSocial[0];
               A428CategoriaTituloDescricao = H007O17_A428CategoriaTituloDescricao[0];
               n428CategoriaTituloDescricao = H007O17_n428CategoriaTituloDescricao[0];
               A282TituloStatus_F = H007O17_A282TituloStatus_F[0];
               n282TituloStatus_F = H007O17_n282TituloStatus_F[0];
               A516TituloDataCredito_F = H007O17_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H007O17_n516TituloDataCredito_F[0];
               A275TituloSaldo_F = H007O17_A275TituloSaldo_F[0];
               n275TituloSaldo_F = H007O17_n275TituloSaldo_F[0];
               A273TituloTotalMovimento_F = H007O17_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = H007O17_n273TituloTotalMovimento_F[0];
               A286TituloCompetenciaAno = H007O17_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H007O17_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H007O17_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H007O17_n287TituloCompetenciaMes[0];
               A428CategoriaTituloDescricao = H007O17_A428CategoriaTituloDescricao[0];
               n428CategoriaTituloDescricao = H007O17_n428CategoriaTituloDescricao[0];
               A794NotaFiscalId = H007O17_A794NotaFiscalId[0];
               n794NotaFiscalId = H007O17_n794NotaFiscalId[0];
               A168ClienteId = H007O17_A168ClienteId[0];
               n168ClienteId = H007O17_n168ClienteId[0];
               A170ClienteRazaoSocial = H007O17_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007O17_n170ClienteRazaoSocial[0];
               A282TituloStatus_F = H007O17_A282TituloStatus_F[0];
               n282TituloStatus_F = H007O17_n282TituloStatus_F[0];
               A516TituloDataCredito_F = H007O17_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H007O17_n516TituloDataCredito_F[0];
               A275TituloSaldo_F = H007O17_A275TituloSaldo_F[0];
               n275TituloSaldo_F = H007O17_n275TituloSaldo_F[0];
               A273TituloTotalMovimento_F = H007O17_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = H007O17_n273TituloTotalMovimento_F[0];
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wctitulospropostads_2_filterfulltext)) || ( ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV67Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV67Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wctitulospropostads_21_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV86Wctitulospropostads_21_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV87Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV87Wctitulospropostads_22_tftitulocompetencia_f_sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV87Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E237O2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 96;
            WB7O0( ) ;
         }
         bGXsfl_96_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7O2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV96Pgmname = "WCTitulosProposta";
         Gx_date = DateTimeUtil.Today( context);
         edtavDisplay_Enabled = 0;
         edtCategoriaTituloDescricao_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtTituloId_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtTituloPropostaId_Enabled = 0;
         AssignProp(sPrefix, false, edtTituloPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloPropostaId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E217O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV31ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV60DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_96 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_96"), ",", "."), 18, MidpointRounding.ToEven));
            AV46DDO_TituloProrrogacaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOPRORROGACAOAUXDATE"), 0);
            AV47DDO_TituloProrrogacaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOPRORROGACAOAUXDATETO"), 0);
            wcpOAV7TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV63IsUnique = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV63IsUnique"));
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
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV17DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR1");
               GX_FocusControl = edtavTitulovalor1_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19TituloValor1 = 0;
               AssignAttri(sPrefix, false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
            }
            else
            {
               AV19TituloValor1 = context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
            }
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR2");
               GX_FocusControl = edtavTitulovalor2_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23TituloValor2 = 0;
               AssignAttri(sPrefix, false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
            }
            else
            {
               AV23TituloValor2 = context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR3");
               GX_FocusControl = edtavTitulovalor3_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27TituloValor3 = 0;
               AssignAttri(sPrefix, false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
            }
            else
            {
               AV27TituloValor3 = context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
            }
            A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n419TituloPropostaId = false;
            AssignAttri(sPrefix, false, "A419TituloPropostaId", StringUtil.LTrimStr( (decimal)(A419TituloPropostaId), 9, 0));
            AV48DDO_TituloProrrogacaoAuxDateText = cgiGet( edtavDdo_tituloprorrogacaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV48DDO_TituloProrrogacaoAuxDateText", AV48DDO_TituloProrrogacaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR1"), ",", ".") != AV19TituloValor1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR2"), ",", ".") != AV23TituloValor2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOVALOR3"), ",", ".") != AV27TituloValor3 )
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
         E217O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E217O2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFTITULOPRORROGACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_tituloprorrogacaoauxdatetext_Internalname});
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV17DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
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
         edtTituloPropostaId_Visible = 0;
         AssignProp(sPrefix, false, edtTituloPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloPropostaId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV60DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV60DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E227O2( )
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
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV33ManageFiltersExecutionStep == 2 )
         {
            AV33ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtTituloProrrogacao_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtTituloProrrogacao_Internalname, "Columnheaderclass", edtTituloProrrogacao_Columnheaderclass, !bGXsfl_96_Refreshing);
         cmbTituloTipo_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbTituloTipo_Internalname, "Columnheaderclass", cmbTituloTipo_Columnheaderclass, !bGXsfl_96_Refreshing);
         edtTituloStatus_F_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtTituloStatus_F_Internalname, "Columnheaderclass", edtTituloStatus_F_Columnheaderclass, !bGXsfl_96_Refreshing);
         AV66Wctitulospropostads_1_titulopropostaid = AV7TituloPropostaId;
         AV67Wctitulospropostads_2_filterfulltext = AV16FilterFullText;
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV69Wctitulospropostads_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV70Wctitulospropostads_5_titulovalor1 = AV19TituloValor1;
         AV71Wctitulospropostads_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV73Wctitulospropostads_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV74Wctitulospropostads_9_titulovalor2 = AV23TituloValor2;
         AV75Wctitulospropostads_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV77Wctitulospropostads_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV78Wctitulospropostads_13_titulovalor3 = AV27TituloValor3;
         AV79Wctitulospropostads_14_tfclienterazaosocial = AV36TFClienteRazaoSocial;
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = AV37TFClienteRazaoSocial_Sel;
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = AV65TFTituloPropostaTipo_Sels;
         AV82Wctitulospropostads_17_tftitulovalor = AV38TFTituloValor;
         AV83Wctitulospropostads_18_tftitulovalor_to = AV39TFTituloValor_To;
         AV84Wctitulospropostads_19_tftitulodesconto = AV40TFTituloDesconto;
         AV85Wctitulospropostads_20_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV86Wctitulospropostads_21_tftitulocompetencia_f = AV42TFTituloCompetencia_F;
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = AV43TFTituloCompetencia_F_Sel;
         AV88Wctitulospropostads_23_tftituloprorrogacao = AV44TFTituloProrrogacao;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = AV45TFTituloProrrogacao_To;
         AV90Wctitulospropostads_25_tftitulotipo_sels = AV50TFTituloTipo_Sels;
         AV91Wctitulospropostads_26_tftitulosaldo_f = AV51TFTituloSaldo_F;
         AV92Wctitulospropostads_27_tftitulosaldo_f_to = AV52TFTituloSaldo_F_To;
         AV93Wctitulospropostads_28_tftitulostatus_f = AV58TFTituloStatus_F;
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = AV59TFTituloStatus_F_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E127O2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S182 ();
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
               AV36TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV36TFClienteRazaoSocial", AV36TFClienteRazaoSocial);
               AV37TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV37TFClienteRazaoSocial_Sel", AV37TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloPropostaTipo") == 0 )
            {
               AV64TFTituloPropostaTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV64TFTituloPropostaTipo_SelsJson", AV64TFTituloPropostaTipo_SelsJson);
               AV65TFTituloPropostaTipo_Sels.FromJSonString(AV64TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloValor") == 0 )
            {
               AV38TFTituloValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
               AV39TFTituloValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloDesconto") == 0 )
            {
               AV40TFTituloDesconto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
               AV41TFTituloDesconto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloCompetencia_F") == 0 )
            {
               AV42TFTituloCompetencia_F = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV42TFTituloCompetencia_F", AV42TFTituloCompetencia_F);
               AV43TFTituloCompetencia_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV43TFTituloCompetencia_F_Sel", AV43TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloProrrogacao") == 0 )
            {
               AV44TFTituloProrrogacao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV44TFTituloProrrogacao", context.localUtil.Format(AV44TFTituloProrrogacao, "99/99/9999"));
               AV45TFTituloProrrogacao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV45TFTituloProrrogacao_To", context.localUtil.Format(AV45TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloTipo") == 0 )
            {
               AV49TFTituloTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV49TFTituloTipo_SelsJson", AV49TFTituloTipo_SelsJson);
               AV50TFTituloTipo_Sels.FromJSonString(AV49TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloSaldo_F") == 0 )
            {
               AV51TFTituloSaldo_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV51TFTituloSaldo_F", StringUtil.LTrimStr( AV51TFTituloSaldo_F, 18, 2));
               AV52TFTituloSaldo_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV52TFTituloSaldo_F_To", StringUtil.LTrimStr( AV52TFTituloSaldo_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloStatus_F") == 0 )
            {
               AV58TFTituloStatus_F = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV58TFTituloStatus_F", AV58TFTituloStatus_F);
               AV59TFTituloStatus_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV59TFTituloStatus_F_Sel", AV59TFTituloStatus_F_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50TFTituloTipo_Sels", AV50TFTituloTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV65TFTituloPropostaTipo_Sels", AV65TFTituloPropostaTipo_Sels);
      }

      private void E237O2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV61Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV61Display);
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A261TituloId,9,0));
            edtavDisplay_Link = formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) < DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) == DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) > DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else
            {
               edtTituloProrrogacao_Columnclass = "WWColumn";
            }
            if ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 )
            {
               cmbTituloTipo_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 )
            {
               cmbTituloTipo_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else
            {
               cmbTituloTipo_Columnclass = "WWColumn";
            }
            if ( StringUtil.StrCmp(A282TituloStatus_F, "Liquidado") == 0 )
            {
               edtTituloStatus_F_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(A282TituloStatus_F, "Aberto") == 0 )
            {
               edtTituloStatus_F_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
            }
            else if ( StringUtil.StrCmp(A282TituloStatus_F, "Baixado parcialmente") == 0 )
            {
               edtTituloStatus_F_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
            }
            else
            {
               edtTituloStatus_F_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 96;
            }
            sendrow_962( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_96_Refreshing )
         {
            DoAjaxLoad(96, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E167O2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E137O2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV29DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV29DynamicFiltersIgnoreFirst", AV29DynamicFiltersIgnoreFirst);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV29DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV29DynamicFiltersIgnoreFirst", AV29DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E177O2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E187O2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E147O2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E197O2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E157O2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV33ManageFiltersExecutionStep, AV7TituloPropostaId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV36TFClienteRazaoSocial, AV37TFClienteRazaoSocial_Sel, AV65TFTituloPropostaTipo_Sels, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV42TFTituloCompetencia_F, AV43TFTituloCompetencia_F_Sel, AV44TFTituloProrrogacao, AV45TFTituloProrrogacao_To, AV50TFTituloTipo_Sels, AV51TFTituloSaldo_F, AV52TFTituloSaldo_F_To, AV58TFTituloStatus_F, AV59TFTituloStatus_F_Sel, AV96Pgmname, AV63IsUnique, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E207O2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E117O2( )
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WCTitulosPropostaFilters")) + "," + UrlEncode(StringUtil.RTrim(AV96Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WCTitulosPropostaFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV32ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WCTitulosPropostaFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV32ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV32ManageFiltersXml) ;
               AV11GridState.FromXml(AV32ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S182 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV65TFTituloPropostaTipo_Sels", AV65TFTituloPropostaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50TFTituloTipo_Sels", AV50TFTituloTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void S182( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavTitulovalor1_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor1_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTitulovalor2_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor2_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTitulovalor3_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor3_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23TituloValor2 = 0;
         AssignAttri(sPrefix, false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV27TituloValor3 = 0;
         AssignAttri(sPrefix, false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV31ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WCTitulosPropostaFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV31ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV36TFClienteRazaoSocial = "";
         AssignAttri(sPrefix, false, "AV36TFClienteRazaoSocial", AV36TFClienteRazaoSocial);
         AV37TFClienteRazaoSocial_Sel = "";
         AssignAttri(sPrefix, false, "AV37TFClienteRazaoSocial_Sel", AV37TFClienteRazaoSocial_Sel);
         AV65TFTituloPropostaTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38TFTituloValor = 0;
         AssignAttri(sPrefix, false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
         AV39TFTituloValor_To = 0;
         AssignAttri(sPrefix, false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
         AV40TFTituloDesconto = 0;
         AssignAttri(sPrefix, false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
         AV41TFTituloDesconto_To = 0;
         AssignAttri(sPrefix, false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
         AV42TFTituloCompetencia_F = "";
         AssignAttri(sPrefix, false, "AV42TFTituloCompetencia_F", AV42TFTituloCompetencia_F);
         AV43TFTituloCompetencia_F_Sel = "";
         AssignAttri(sPrefix, false, "AV43TFTituloCompetencia_F_Sel", AV43TFTituloCompetencia_F_Sel);
         AV44TFTituloProrrogacao = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV44TFTituloProrrogacao", context.localUtil.Format(AV44TFTituloProrrogacao, "99/99/9999"));
         AV45TFTituloProrrogacao_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV45TFTituloProrrogacao_To", context.localUtil.Format(AV45TFTituloProrrogacao_To, "99/99/9999"));
         AV50TFTituloTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV51TFTituloSaldo_F = 0;
         AssignAttri(sPrefix, false, "AV51TFTituloSaldo_F", StringUtil.LTrimStr( AV51TFTituloSaldo_F, 18, 2));
         AV52TFTituloSaldo_F_To = 0;
         AssignAttri(sPrefix, false, "AV52TFTituloSaldo_F_To", StringUtil.LTrimStr( AV52TFTituloSaldo_F_To, 18, 2));
         AV58TFTituloStatus_F = "";
         AssignAttri(sPrefix, false, "AV58TFTituloStatus_F", AV58TFTituloStatus_F);
         AV59TFTituloStatus_F_Sel = "";
         AssignAttri(sPrefix, false, "AV59TFTituloStatus_F_Sel", AV59TFTituloStatus_F_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV17DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19TituloValor1 = 0;
         AssignAttri(sPrefix, false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
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

      protected void S172( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV96Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV96Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV30Session.Get(AV96Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S182 ();
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV36TFClienteRazaoSocial = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFClienteRazaoSocial", AV36TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV37TFClienteRazaoSocial_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFClienteRazaoSocial_Sel", AV37TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTATIPO_SEL") == 0 )
            {
               AV64TFTituloPropostaTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV64TFTituloPropostaTipo_SelsJson", AV64TFTituloPropostaTipo_SelsJson);
               AV65TFTituloPropostaTipo_Sels.FromJSonString(AV64TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV38TFTituloValor = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
               AV39TFTituloValor_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV40TFTituloDesconto = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
               AV41TFTituloDesconto_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV42TFTituloCompetencia_F = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42TFTituloCompetencia_F", AV42TFTituloCompetencia_F);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV43TFTituloCompetencia_F_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43TFTituloCompetencia_F_Sel", AV43TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV44TFTituloProrrogacao = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV44TFTituloProrrogacao", context.localUtil.Format(AV44TFTituloProrrogacao, "99/99/9999"));
               AV45TFTituloProrrogacao_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV45TFTituloProrrogacao_To", context.localUtil.Format(AV45TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV49TFTituloTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV49TFTituloTipo_SelsJson", AV49TFTituloTipo_SelsJson);
               AV50TFTituloTipo_Sels.FromJSonString(AV49TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV51TFTituloSaldo_F = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV51TFTituloSaldo_F", StringUtil.LTrimStr( AV51TFTituloSaldo_F, 18, 2));
               AV52TFTituloSaldo_F_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV52TFTituloSaldo_F_To", StringUtil.LTrimStr( AV52TFTituloSaldo_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV58TFTituloStatus_F = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV58TFTituloStatus_F", AV58TFTituloStatus_F);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV59TFTituloStatus_F_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV59TFTituloStatus_F_Sel", AV59TFTituloStatus_F_Sel);
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClienteRazaoSocial_Sel)),  AV37TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV65TFTituloPropostaTipo_Sels.Count==0),  AV64TFTituloPropostaTipo_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTituloCompetencia_F_Sel)),  AV43TFTituloCompetencia_F_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV50TFTituloTipo_Sels.Count==0),  AV49TFTituloTipo_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTituloStatus_F_Sel)),  AV59TFTituloStatus_F_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|||"+GXt_char5+"||"+GXt_char6+"||"+GXt_char7;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFClienteRazaoSocial)),  AV36TFClienteRazaoSocial, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTituloCompetencia_F)),  AV42TFTituloCompetencia_F, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTituloStatus_F)),  AV58TFTituloStatus_F, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"||"+((Convert.ToDecimal(0)==AV38TFTituloValor) ? "" : StringUtil.Str( AV38TFTituloValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV40TFTituloDesconto) ? "" : StringUtil.Str( AV40TFTituloDesconto, 18, 2))+"|"+GXt_char6+"|"+((DateTime.MinValue==AV44TFTituloProrrogacao) ? "" : context.localUtil.DToC( AV44TFTituloProrrogacao, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV51TFTituloSaldo_F) ? "" : StringUtil.Str( AV51TFTituloSaldo_F, 18, 2))+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((Convert.ToDecimal(0)==AV39TFTituloValor_To) ? "" : StringUtil.Str( AV39TFTituloValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV41TFTituloDesconto_To) ? "" : StringUtil.Str( AV41TFTituloDesconto_To, 18, 2))+"||"+((DateTime.MinValue==AV45TFTituloProrrogacao_To) ? "" : context.localUtil.DToC( AV45TFTituloProrrogacao_To, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV52TFTituloSaldo_F_To) ? "" : StringUtil.Str( AV52TFTituloSaldo_F_To, 18, 2))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
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
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19TituloValor1 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23TituloValor2 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri(sPrefix, false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV24DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27TituloValor3 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri(sPrefix, false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S152 ();
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
         if ( AV28DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV30Session.Get(AV96Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCLIENTERAZAOSOCIAL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFClienteRazaoSocial)),  0,  AV36TFClienteRazaoSocial,  AV36TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClienteRazaoSocial_Sel)),  AV37TFClienteRazaoSocial_Sel,  AV37TFClienteRazaoSocial_Sel) ;
         AV62AuxText = ((AV65TFTituloPropostaTipo_Sels.Count==1) ? "["+((string)AV65TFTituloPropostaTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOPROPOSTATIPO_SEL",  "",  !(AV65TFTituloPropostaTipo_Sels.Count==0),  0,  AV65TFTituloPropostaTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV62AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV62AuxText, "[IOF]", "IOF"), "[TAXA]", "TAXA"), "[REEMBOLSO]", "REEMBOLSO")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOVALOR",  "",  !((Convert.ToDecimal(0)==AV38TFTituloValor)&&(Convert.ToDecimal(0)==AV39TFTituloValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV38TFTituloValor, 18, 2)),  ((Convert.ToDecimal(0)==AV38TFTituloValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFTituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV39TFTituloValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV39TFTituloValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFTituloValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULODESCONTO",  "",  !((Convert.ToDecimal(0)==AV40TFTituloDesconto)&&(Convert.ToDecimal(0)==AV41TFTituloDesconto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV40TFTituloDesconto, 18, 2)),  ((Convert.ToDecimal(0)==AV40TFTituloDesconto) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFTituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV41TFTituloDesconto_To, 18, 2)),  ((Convert.ToDecimal(0)==AV41TFTituloDesconto_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFTituloDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTITULOCOMPETENCIA_F",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTituloCompetencia_F)),  0,  AV42TFTituloCompetencia_F,  AV42TFTituloCompetencia_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTituloCompetencia_F_Sel)),  AV43TFTituloCompetencia_F_Sel,  AV43TFTituloCompetencia_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOPRORROGACAO",  "",  !((DateTime.MinValue==AV44TFTituloProrrogacao)&&(DateTime.MinValue==AV45TFTituloProrrogacao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV44TFTituloProrrogacao, 4, "/")),  ((DateTime.MinValue==AV44TFTituloProrrogacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFTituloProrrogacao, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV45TFTituloProrrogacao_To, 4, "/")),  ((DateTime.MinValue==AV45TFTituloProrrogacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFTituloProrrogacao_To, "99/99/9999")))) ;
         AV62AuxText = ((AV50TFTituloTipo_Sels.Count==1) ? "["+((string)AV50TFTituloTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOTIPO_SEL",  "",  !(AV50TFTituloTipo_Sels.Count==0),  0,  AV50TFTituloTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV62AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV62AuxText, "[DEBITO]", "Débito"), "[CREDITO]", "Crédito")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOSALDO_F",  "",  !((Convert.ToDecimal(0)==AV51TFTituloSaldo_F)&&(Convert.ToDecimal(0)==AV52TFTituloSaldo_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV51TFTituloSaldo_F, 18, 2)),  ((Convert.ToDecimal(0)==AV51TFTituloSaldo_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFTituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV52TFTituloSaldo_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV52TFTituloSaldo_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV52TFTituloSaldo_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTITULOSTATUS_F",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTituloStatus_F)),  0,  AV58TFTituloStatus_F,  AV58TFTituloStatus_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTituloStatus_F_Sel)),  AV59TFTituloStatus_F_Sel,  AV59TFTituloStatus_F_Sel) ;
         if ( ! (0==AV7TituloPropostaId) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&TITULOPROPOSTAID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7TituloPropostaId), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         if ( ! (false==AV63IsUnique) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&ISUNIQUE";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV63IsUnique);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV29DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV17DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV19TituloValor1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV18DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV19TituloValor1, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV23TituloValor2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV22DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV23TituloValor2, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV24DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV27TituloValor3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV26DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV27TituloValor3, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S162( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV96Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Titulo";
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "TituloPropostaId";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7TituloPropostaId), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV30Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV96Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV96Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV30Session.Get(AV96Pgmname+"GridState"), null, "", "");
         }
         if ( ! ( AV63IsUnique ) )
         {
            edtClienteRazaoSocial_Visible = 0;
            AssignProp(sPrefix, false, edtClienteRazaoSocial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Visible), 5, 0), !bGXsfl_96_Refreshing);
            if ( new GeneXus.Programs.wwpbaseobjects.wwp_deletefilter(context).executeUdp( ref  AV11GridState,  "TFCLIENTERAZAOSOCIAL",  false) )
            {
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
            }
         }
      }

      protected void wb_table3_81_7O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor3_Internalname, "Titulo Valor3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV27TituloValor3, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor3_Enabled!=0) ? context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,88);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor3_Visible, edtavTitulovalor3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WCTitulosProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_81_7O2e( true) ;
         }
         else
         {
            wb_table3_81_7O2e( false) ;
         }
      }

      protected void wb_table2_59_7O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor2_Internalname, "Titulo Valor2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor2_Enabled!=0) ? context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor2_Visible, edtavTitulovalor2_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WCTitulosProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WCTitulosProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_59_7O2e( true) ;
         }
         else
         {
            wb_table2_59_7O2e( false) ;
         }
      }

      protected void wb_table1_37_7O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_WCTitulosProposta.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor1_Internalname, "Titulo Valor1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV19TituloValor1, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor1_Enabled!=0) ? context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor1_Visible, edtavTitulovalor1_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCTitulosProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WCTitulosProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WCTitulosProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_37_7O2e( true) ;
         }
         else
         {
            wb_table1_37_7O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7TituloPropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV7TituloPropostaId), 9, 0));
         AV63IsUnique = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV63IsUnique", AV63IsUnique);
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
         PA7O2( ) ;
         WS7O2( ) ;
         WE7O2( ) ;
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
         sCtrlAV7TituloPropostaId = (string)((string)getParm(obj,0));
         sCtrlAV63IsUnique = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wctitulosproposta", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7TituloPropostaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV7TituloPropostaId), 9, 0));
            AV63IsUnique = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV63IsUnique", AV63IsUnique);
         }
         wcpOAV7TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV63IsUnique = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV63IsUnique"));
         if ( ! GetJustCreated( ) && ( ( AV7TituloPropostaId != wcpOAV7TituloPropostaId ) || ( AV63IsUnique != wcpOAV63IsUnique ) ) )
         {
            setjustcreated();
         }
         wcpOAV7TituloPropostaId = AV7TituloPropostaId;
         wcpOAV63IsUnique = AV63IsUnique;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7TituloPropostaId = cgiGet( sPrefix+"AV7TituloPropostaId_CTRL");
         if ( StringUtil.Len( sCtrlAV7TituloPropostaId) > 0 )
         {
            AV7TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7TituloPropostaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV7TituloPropostaId), 9, 0));
         }
         else
         {
            AV7TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7TituloPropostaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV63IsUnique = cgiGet( sPrefix+"AV63IsUnique_CTRL");
         if ( StringUtil.Len( sCtrlAV63IsUnique) > 0 )
         {
            AV63IsUnique = StringUtil.StrToBool( cgiGet( sCtrlAV63IsUnique));
            AssignAttri(sPrefix, false, "AV63IsUnique", AV63IsUnique);
         }
         else
         {
            AV63IsUnique = StringUtil.StrToBool( cgiGet( sPrefix+"AV63IsUnique_PARM"));
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
         PA7O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7O2( ) ;
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
         WS7O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7TituloPropostaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TituloPropostaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7TituloPropostaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7TituloPropostaId_CTRL", StringUtil.RTrim( sCtrlAV7TituloPropostaId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV63IsUnique_PARM", StringUtil.BoolToStr( AV63IsUnique));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV63IsUnique)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV63IsUnique_CTRL", StringUtil.RTrim( sCtrlAV63IsUnique));
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
         WE7O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019151485", true, true);
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
         context.AddJavascriptSource("wctitulosproposta.js", "?202561019151485", false, true);
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

      protected void SubsflControlProps_962( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_96_idx;
         edtCategoriaTituloDescricao_Internalname = sPrefix+"CATEGORIATITULODESCRICAO_"+sGXsfl_96_idx;
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL_"+sGXsfl_96_idx;
         cmbTituloPropostaTipo_Internalname = sPrefix+"TITULOPROPOSTATIPO_"+sGXsfl_96_idx;
         edtTituloId_Internalname = sPrefix+"TITULOID_"+sGXsfl_96_idx;
         edtTituloValor_Internalname = sPrefix+"TITULOVALOR_"+sGXsfl_96_idx;
         edtTituloDesconto_Internalname = sPrefix+"TITULODESCONTO_"+sGXsfl_96_idx;
         chkTituloDeleted_Internalname = sPrefix+"TITULODELETED_"+sGXsfl_96_idx;
         edtTituloCompetenciaAno_Internalname = sPrefix+"TITULOCOMPETENCIAANO_"+sGXsfl_96_idx;
         edtTituloCompetenciaMes_Internalname = sPrefix+"TITULOCOMPETENCIAMES_"+sGXsfl_96_idx;
         edtTituloCompetencia_F_Internalname = sPrefix+"TITULOCOMPETENCIA_F_"+sGXsfl_96_idx;
         edtTituloProrrogacao_Internalname = sPrefix+"TITULOPRORROGACAO_"+sGXsfl_96_idx;
         cmbTituloTipo_Internalname = sPrefix+"TITULOTIPO_"+sGXsfl_96_idx;
         edtTituloTotalMovimento_F_Internalname = sPrefix+"TITULOTOTALMOVIMENTO_F_"+sGXsfl_96_idx;
         edtTituloSaldo_F_Internalname = sPrefix+"TITULOSALDO_F_"+sGXsfl_96_idx;
         edtTituloDataCredito_F_Internalname = sPrefix+"TITULODATACREDITO_F_"+sGXsfl_96_idx;
         edtTituloStatus_F_Internalname = sPrefix+"TITULOSTATUS_F_"+sGXsfl_96_idx;
      }

      protected void SubsflControlProps_fel_962( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_96_fel_idx;
         edtCategoriaTituloDescricao_Internalname = sPrefix+"CATEGORIATITULODESCRICAO_"+sGXsfl_96_fel_idx;
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL_"+sGXsfl_96_fel_idx;
         cmbTituloPropostaTipo_Internalname = sPrefix+"TITULOPROPOSTATIPO_"+sGXsfl_96_fel_idx;
         edtTituloId_Internalname = sPrefix+"TITULOID_"+sGXsfl_96_fel_idx;
         edtTituloValor_Internalname = sPrefix+"TITULOVALOR_"+sGXsfl_96_fel_idx;
         edtTituloDesconto_Internalname = sPrefix+"TITULODESCONTO_"+sGXsfl_96_fel_idx;
         chkTituloDeleted_Internalname = sPrefix+"TITULODELETED_"+sGXsfl_96_fel_idx;
         edtTituloCompetenciaAno_Internalname = sPrefix+"TITULOCOMPETENCIAANO_"+sGXsfl_96_fel_idx;
         edtTituloCompetenciaMes_Internalname = sPrefix+"TITULOCOMPETENCIAMES_"+sGXsfl_96_fel_idx;
         edtTituloCompetencia_F_Internalname = sPrefix+"TITULOCOMPETENCIA_F_"+sGXsfl_96_fel_idx;
         edtTituloProrrogacao_Internalname = sPrefix+"TITULOPRORROGACAO_"+sGXsfl_96_fel_idx;
         cmbTituloTipo_Internalname = sPrefix+"TITULOTIPO_"+sGXsfl_96_fel_idx;
         edtTituloTotalMovimento_F_Internalname = sPrefix+"TITULOTOTALMOVIMENTO_F_"+sGXsfl_96_fel_idx;
         edtTituloSaldo_F_Internalname = sPrefix+"TITULOSALDO_F_"+sGXsfl_96_fel_idx;
         edtTituloDataCredito_F_Internalname = sPrefix+"TITULODATACREDITO_F_"+sGXsfl_96_fel_idx;
         edtTituloStatus_F_Internalname = sPrefix+"TITULOSTATUS_F_"+sGXsfl_96_fel_idx;
      }

      protected void sendrow_962( )
      {
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_962( ) ;
         WB7O0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_96_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_96_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_96_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'" + sGXsfl_96_idx + "',96)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV61Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaTituloDescricao_Internalname,(string)A428CategoriaTituloDescricao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaTituloDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtClienteRazaoSocial_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtClienteRazaoSocial_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTituloPropostaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_96_idx;
               cmbTituloPropostaTipo.Name = GXCCtl;
               cmbTituloPropostaTipo.WebTags = "";
               cmbTituloPropostaTipo.addItem("IOF", "IOF", 0);
               cmbTituloPropostaTipo.addItem("TAXA", "TAXA", 0);
               cmbTituloPropostaTipo.addItem("REEMBOLSO", "REEMBOLSO", 0);
               cmbTituloPropostaTipo.addItem("COMUM", "COMUM", 0);
               if ( cmbTituloPropostaTipo.ItemCount > 0 )
               {
                  A648TituloPropostaTipo = cmbTituloPropostaTipo.getValidValue(A648TituloPropostaTipo);
                  n648TituloPropostaTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloPropostaTipo,(string)cmbTituloPropostaTipo_Internalname,StringUtil.RTrim( A648TituloPropostaTipo),(short)1,(string)cmbTituloPropostaTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTituloPropostaTipo.CurrentValue = StringUtil.RTrim( A648TituloPropostaTipo);
            AssignProp(sPrefix, false, cmbTituloPropostaTipo_Internalname, "Values", (string)(cmbTituloPropostaTipo.ToJavascriptSource()), !bGXsfl_96_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDesconto_Internalname,StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDesconto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULODELETED_" + sGXsfl_96_idx;
            chkTituloDeleted.Name = GXCCtl;
            chkTituloDeleted.WebTags = "";
            chkTituloDeleted.Caption = "";
            AssignProp(sPrefix, false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_96_Refreshing);
            chkTituloDeleted.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTituloDeleted_Internalname,StringUtil.BoolToStr( A284TituloDeleted),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetencia_F_Internalname,(string)A295TituloCompetencia_F,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetencia_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloProrrogacao_Internalname,context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"),context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloProrrogacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtTituloProrrogacao_Columnclass,(string)edtTituloProrrogacao_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTituloTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOTIPO_" + sGXsfl_96_idx;
               cmbTituloTipo.Name = GXCCtl;
               cmbTituloTipo.WebTags = "";
               cmbTituloTipo.addItem("DEBITO", "Débito", 0);
               cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
               if ( cmbTituloTipo.ItemCount > 0 )
               {
                  A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
                  n283TituloTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloTipo,(string)cmbTituloTipo_Internalname,StringUtil.RTrim( A283TituloTipo),(short)1,(string)cmbTituloTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbTituloTipo_Columnclass,(string)cmbTituloTipo_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
            AssignProp(sPrefix, false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), !bGXsfl_96_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimento_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimento_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldo_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDataCredito_F_Internalname,context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"),context.localUtil.Format( A516TituloDataCredito_F, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDataCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloStatus_F_Internalname,(string)A282TituloStatus_F,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloStatus_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtTituloStatus_F_Columnclass,(string)edtTituloStatus_F_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes7O2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_96_idx = ((subGrid_Islastpage==1)&&(nGXsfl_96_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
         }
         /* End function sendrow_962 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TITULOVALOR", "Valor", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("TITULOVALOR", "Valor", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TITULOVALOR", "Valor", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_96_idx;
         cmbTituloPropostaTipo.Name = GXCCtl;
         cmbTituloPropostaTipo.WebTags = "";
         cmbTituloPropostaTipo.addItem("IOF", "IOF", 0);
         cmbTituloPropostaTipo.addItem("TAXA", "TAXA", 0);
         cmbTituloPropostaTipo.addItem("REEMBOLSO", "REEMBOLSO", 0);
         cmbTituloPropostaTipo.addItem("COMUM", "COMUM", 0);
         if ( cmbTituloPropostaTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "TITULODELETED_" + sGXsfl_96_idx;
         chkTituloDeleted.Name = GXCCtl;
         chkTituloDeleted.WebTags = "";
         chkTituloDeleted.Caption = "";
         AssignProp(sPrefix, false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_96_Refreshing);
         chkTituloDeleted.CheckedValue = "false";
         GXCCtl = "TITULOTIPO_" + sGXsfl_96_idx;
         cmbTituloTipo.Name = GXCCtl;
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl96( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"96\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Categoria") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtClienteRazaoSocial_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Identificador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Titulo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Desconto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Título deletado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Mês") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Competência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Total movimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Saldo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Último movimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV61Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A428CategoriaTituloDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteRazaoSocial_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A648TituloPropostaTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A284TituloDeleted)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A295TituloCompetencia_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A264TituloProrrogacao, "99/99/9999")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtTituloProrrogacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtTituloProrrogacao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A283TituloTipo));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbTituloTipo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbTituloTipo_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A282TituloStatus_F));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtTituloStatus_F_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtTituloStatus_F_Columnheaderclass));
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
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR1";
         edtavTitulovalor1_Internalname = sPrefix+"vTITULOVALOR1";
         cellFilter_titulovalor1_cell_Internalname = sPrefix+"FILTER_TITULOVALOR1_CELL";
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
         edtavTitulovalor2_Internalname = sPrefix+"vTITULOVALOR2";
         cellFilter_titulovalor2_cell_Internalname = sPrefix+"FILTER_TITULOVALOR2_CELL";
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
         edtavTitulovalor3_Internalname = sPrefix+"vTITULOVALOR3";
         cellFilter_titulovalor3_cell_Internalname = sPrefix+"FILTER_TITULOVALOR3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtCategoriaTituloDescricao_Internalname = sPrefix+"CATEGORIATITULODESCRICAO";
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL";
         cmbTituloPropostaTipo_Internalname = sPrefix+"TITULOPROPOSTATIPO";
         edtTituloId_Internalname = sPrefix+"TITULOID";
         edtTituloValor_Internalname = sPrefix+"TITULOVALOR";
         edtTituloDesconto_Internalname = sPrefix+"TITULODESCONTO";
         chkTituloDeleted_Internalname = sPrefix+"TITULODELETED";
         edtTituloCompetenciaAno_Internalname = sPrefix+"TITULOCOMPETENCIAANO";
         edtTituloCompetenciaMes_Internalname = sPrefix+"TITULOCOMPETENCIAMES";
         edtTituloCompetencia_F_Internalname = sPrefix+"TITULOCOMPETENCIA_F";
         edtTituloProrrogacao_Internalname = sPrefix+"TITULOPRORROGACAO";
         cmbTituloTipo_Internalname = sPrefix+"TITULOTIPO";
         edtTituloTotalMovimento_F_Internalname = sPrefix+"TITULOTOTALMOVIMENTO_F";
         edtTituloSaldo_F_Internalname = sPrefix+"TITULOSALDO_F";
         edtTituloDataCredito_F_Internalname = sPrefix+"TITULODATACREDITO_F";
         edtTituloStatus_F_Internalname = sPrefix+"TITULOSTATUS_F";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtTituloPropostaId_Internalname = sPrefix+"TITULOPROPOSTAID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_tituloprorrogacaoauxdatetext_Internalname = sPrefix+"vDDO_TITULOPRORROGACAOAUXDATETEXT";
         Tftituloprorrogacao_rangepicker_Internalname = sPrefix+"TFTITULOPRORROGACAO_RANGEPICKER";
         divDdo_tituloprorrogacaoauxdates_Internalname = sPrefix+"DDO_TITULOPRORROGACAOAUXDATES";
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
         edtTituloStatus_F_Jsonclick = "";
         edtTituloStatus_F_Columnclass = "WWColumn";
         edtTituloDataCredito_F_Jsonclick = "";
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Jsonclick = "";
         cmbTituloTipo_Jsonclick = "";
         cmbTituloTipo_Columnclass = "WWColumn";
         edtTituloProrrogacao_Jsonclick = "";
         edtTituloProrrogacao_Columnclass = "WWColumn";
         edtTituloCompetencia_F_Jsonclick = "";
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloCompetenciaAno_Jsonclick = "";
         chkTituloDeleted.Caption = "";
         edtTituloDesconto_Jsonclick = "";
         edtTituloValor_Jsonclick = "";
         edtTituloId_Jsonclick = "";
         cmbTituloPropostaTipo_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtCategoriaTituloDescricao_Jsonclick = "";
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTitulovalor1_Jsonclick = "";
         edtavTitulovalor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTitulovalor2_Jsonclick = "";
         edtavTitulovalor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTitulovalor3_Jsonclick = "";
         edtavTitulovalor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTitulovalor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTitulovalor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTitulovalor1_Visible = 1;
         edtTituloStatus_F_Columnheaderclass = "";
         cmbTituloTipo_Columnheaderclass = "";
         edtTituloProrrogacao_Columnheaderclass = "";
         edtTituloPropostaId_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloId_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtCategoriaTituloDescricao_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick = "";
         edtTituloPropostaId_Jsonclick = "";
         edtTituloPropostaId_Visible = 1;
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
         Ddo_grid_Format = "||18.2|18.2||||18.2|";
         Ddo_grid_Datalistproc = "WCTitulosPropostaGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|IOF:IOF,TAXA:TAXA,REEMBOLSO:REEMBOLSO|||||DEBITO:Débito,CREDITO:Crédito||";
         Ddo_grid_Allowmultipleselection = "|T|||||T||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|||Dynamic||FixedValues||Dynamic";
         Ddo_grid_Includedatalist = "T|T|||T||T||T";
         Ddo_grid_Filterisrange = "||T|T||P||T|";
         Ddo_grid_Filtertype = "Character||Numeric|Numeric|Character|Date||Numeric|Character";
         Ddo_grid_Includefilter = "T||T|T|T|T||T|T";
         Ddo_grid_Includesortasc = "T|T|T|T||T|T||";
         Ddo_grid_Columnssortvalues = "2|3|1|4||5|6||";
         Ddo_grid_Columnids = "2:ClienteRazaoSocial|3:TituloPropostaTipo|5:TituloValor|6:TituloDesconto|10:TituloCompetencia_F|11:TituloProrrogacao|12:TituloTipo|14:TituloSaldo_F|16:TituloStatus_F";
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
         edtClienteRazaoSocial_Visible = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E127O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV64TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E237O2","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A264TituloProrrogacao","fld":"TITULOPRORROGACAO","type":"date"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"cmbTituloTipo"},{"av":"A283TituloTipo","fld":"TITULOTIPO","type":"svchar"},{"av":"A282TituloStatus_F","fld":"TITULOSTATUS_F","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV61Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"edtTituloProrrogacao_Columnclass","ctrl":"TITULOPRORROGACAO","prop":"Columnclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnclass","ctrl":"TITULOSTATUS_F","prop":"Columnclass"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E167O2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E137O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E177O2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E187O2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E147O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E197O2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E157O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E207O2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV64TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"AV49TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV49TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"},{"av":"AV64TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtClienteRazaoSocial_Visible","ctrl":"CLIENTERAZAOSOCIAL","prop":"Visible"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV7TituloPropostaId","fld":"vTITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV43TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV44TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV45TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV50TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV51TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV58TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV59TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV63IsUnique","fld":"vISUNIQUE","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"edtTituloStatus_F_Columnheaderclass","ctrl":"TITULOSTATUS_F","prop":"Columnheaderclass"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_CLIENTERAZAOSOCIAL","""{"handler":"Valid_Clienterazaosocial","iparms":[]}""");
         setEventMetadata("VALID_TITULOPROPOSTATIPO","""{"handler":"Valid_Titulopropostatipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIA_F","""{"handler":"Valid_Titulocompetencia_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOTIPO","""{"handler":"Valid_Titulotipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOSTATUS_F","""{"handler":"Valid_Titulostatus_f","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17DynamicFiltersSelector1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV16FilterFullText = "";
         AV36TFClienteRazaoSocial = "";
         AV37TFClienteRazaoSocial_Sel = "";
         AV65TFTituloPropostaTipo_Sels = new GxSimpleCollection<string>();
         AV42TFTituloCompetencia_F = "";
         AV43TFTituloCompetencia_F_Sel = "";
         AV44TFTituloProrrogacao = DateTime.MinValue;
         AV45TFTituloProrrogacao_To = DateTime.MinValue;
         AV50TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV58TFTituloStatus_F = "";
         AV59TFTituloStatus_F_Sel = "";
         AV96Pgmname = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV31ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV46DDO_TituloProrrogacaoAuxDate = DateTime.MinValue;
         AV47DDO_TituloProrrogacaoAuxDateTo = DateTime.MinValue;
         AV64TFTituloPropostaTipo_SelsJson = "";
         AV49TFTituloTipo_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV48DDO_TituloProrrogacaoAuxDateText = "";
         ucTftituloprorrogacao_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV67Wctitulospropostads_2_filterfulltext = "";
         AV68Wctitulospropostads_3_dynamicfiltersselector1 = "";
         AV72Wctitulospropostads_7_dynamicfiltersselector2 = "";
         AV76Wctitulospropostads_11_dynamicfiltersselector3 = "";
         AV79Wctitulospropostads_14_tfclienterazaosocial = "";
         AV80Wctitulospropostads_15_tfclienterazaosocial_sel = "";
         AV81Wctitulospropostads_16_tftitulopropostatipo_sels = new GxSimpleCollection<string>();
         AV86Wctitulospropostads_21_tftitulocompetencia_f = "";
         AV87Wctitulospropostads_22_tftitulocompetencia_f_sel = "";
         AV88Wctitulospropostads_23_tftituloprorrogacao = DateTime.MinValue;
         AV89Wctitulospropostads_24_tftituloprorrogacao_to = DateTime.MinValue;
         AV90Wctitulospropostads_25_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV93Wctitulospropostads_28_tftitulostatus_f = "";
         AV94Wctitulospropostads_29_tftitulostatus_f_sel = "";
         AV61Display = "";
         A428CategoriaTituloDescricao = "";
         A170ClienteRazaoSocial = "";
         A648TituloPropostaTipo = "";
         A295TituloCompetencia_F = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A283TituloTipo = "";
         A516TituloDataCredito_F = DateTime.MinValue;
         A282TituloStatus_F = "";
         GXDecQS = "";
         lV67Wctitulospropostads_2_filterfulltext = "";
         lV93Wctitulospropostads_28_tftitulostatus_f = "";
         lV79Wctitulospropostads_14_tfclienterazaosocial = "";
         H007O9_A426CategoriaTituloId = new int[1] ;
         H007O9_n426CategoriaTituloId = new bool[] {false} ;
         H007O9_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H007O9_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H007O9_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H007O9_n794NotaFiscalId = new bool[] {false} ;
         H007O9_A168ClienteId = new int[1] ;
         H007O9_n168ClienteId = new bool[] {false} ;
         H007O9_A419TituloPropostaId = new int[1] ;
         H007O9_n419TituloPropostaId = new bool[] {false} ;
         H007O9_A283TituloTipo = new string[] {""} ;
         H007O9_n283TituloTipo = new bool[] {false} ;
         H007O9_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H007O9_n264TituloProrrogacao = new bool[] {false} ;
         H007O9_A284TituloDeleted = new bool[] {false} ;
         H007O9_n284TituloDeleted = new bool[] {false} ;
         H007O9_A276TituloDesconto = new decimal[1] ;
         H007O9_n276TituloDesconto = new bool[] {false} ;
         H007O9_A262TituloValor = new decimal[1] ;
         H007O9_n262TituloValor = new bool[] {false} ;
         H007O9_A261TituloId = new int[1] ;
         H007O9_n261TituloId = new bool[] {false} ;
         H007O9_A648TituloPropostaTipo = new string[] {""} ;
         H007O9_n648TituloPropostaTipo = new bool[] {false} ;
         H007O9_A170ClienteRazaoSocial = new string[] {""} ;
         H007O9_n170ClienteRazaoSocial = new bool[] {false} ;
         H007O9_A428CategoriaTituloDescricao = new string[] {""} ;
         H007O9_n428CategoriaTituloDescricao = new bool[] {false} ;
         H007O9_A282TituloStatus_F = new string[] {""} ;
         H007O9_n282TituloStatus_F = new bool[] {false} ;
         H007O9_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H007O9_n516TituloDataCredito_F = new bool[] {false} ;
         H007O9_A275TituloSaldo_F = new decimal[1] ;
         H007O9_n275TituloSaldo_F = new bool[] {false} ;
         H007O9_A273TituloTotalMovimento_F = new decimal[1] ;
         H007O9_n273TituloTotalMovimento_F = new bool[] {false} ;
         H007O9_A286TituloCompetenciaAno = new short[1] ;
         H007O9_n286TituloCompetenciaAno = new bool[] {false} ;
         H007O9_A287TituloCompetenciaMes = new short[1] ;
         H007O9_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         H007O17_A426CategoriaTituloId = new int[1] ;
         H007O17_n426CategoriaTituloId = new bool[] {false} ;
         H007O17_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H007O17_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H007O17_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H007O17_n794NotaFiscalId = new bool[] {false} ;
         H007O17_A168ClienteId = new int[1] ;
         H007O17_n168ClienteId = new bool[] {false} ;
         H007O17_A419TituloPropostaId = new int[1] ;
         H007O17_n419TituloPropostaId = new bool[] {false} ;
         H007O17_A283TituloTipo = new string[] {""} ;
         H007O17_n283TituloTipo = new bool[] {false} ;
         H007O17_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H007O17_n264TituloProrrogacao = new bool[] {false} ;
         H007O17_A284TituloDeleted = new bool[] {false} ;
         H007O17_n284TituloDeleted = new bool[] {false} ;
         H007O17_A276TituloDesconto = new decimal[1] ;
         H007O17_n276TituloDesconto = new bool[] {false} ;
         H007O17_A262TituloValor = new decimal[1] ;
         H007O17_n262TituloValor = new bool[] {false} ;
         H007O17_A261TituloId = new int[1] ;
         H007O17_n261TituloId = new bool[] {false} ;
         H007O17_A648TituloPropostaTipo = new string[] {""} ;
         H007O17_n648TituloPropostaTipo = new bool[] {false} ;
         H007O17_A170ClienteRazaoSocial = new string[] {""} ;
         H007O17_n170ClienteRazaoSocial = new bool[] {false} ;
         H007O17_A428CategoriaTituloDescricao = new string[] {""} ;
         H007O17_n428CategoriaTituloDescricao = new bool[] {false} ;
         H007O17_A282TituloStatus_F = new string[] {""} ;
         H007O17_n282TituloStatus_F = new bool[] {false} ;
         H007O17_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H007O17_n516TituloDataCredito_F = new bool[] {false} ;
         H007O17_A275TituloSaldo_F = new decimal[1] ;
         H007O17_n275TituloSaldo_F = new bool[] {false} ;
         H007O17_A273TituloTotalMovimento_F = new decimal[1] ;
         H007O17_n273TituloTotalMovimento_F = new bool[] {false} ;
         H007O17_A286TituloCompetenciaAno = new short[1] ;
         H007O17_n286TituloCompetenciaAno = new bool[] {false} ;
         H007O17_A287TituloCompetenciaMes = new short[1] ;
         H007O17_n287TituloCompetenciaMes = new bool[] {false} ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV32ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV30Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV62AuxText = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7TituloPropostaId = "";
         sCtrlAV63IsUnique = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wctitulosproposta__default(),
            new Object[][] {
                new Object[] {
               H007O9_A426CategoriaTituloId, H007O9_n426CategoriaTituloId, H007O9_A890NotaFiscalParcelamentoID, H007O9_n890NotaFiscalParcelamentoID, H007O9_A794NotaFiscalId, H007O9_n794NotaFiscalId, H007O9_A168ClienteId, H007O9_n168ClienteId, H007O9_A419TituloPropostaId, H007O9_n419TituloPropostaId,
               H007O9_A283TituloTipo, H007O9_n283TituloTipo, H007O9_A264TituloProrrogacao, H007O9_n264TituloProrrogacao, H007O9_A284TituloDeleted, H007O9_n284TituloDeleted, H007O9_A276TituloDesconto, H007O9_n276TituloDesconto, H007O9_A262TituloValor, H007O9_n262TituloValor,
               H007O9_A261TituloId, H007O9_A648TituloPropostaTipo, H007O9_n648TituloPropostaTipo, H007O9_A170ClienteRazaoSocial, H007O9_n170ClienteRazaoSocial, H007O9_A428CategoriaTituloDescricao, H007O9_n428CategoriaTituloDescricao, H007O9_A282TituloStatus_F, H007O9_n282TituloStatus_F, H007O9_A516TituloDataCredito_F,
               H007O9_n516TituloDataCredito_F, H007O9_A275TituloSaldo_F, H007O9_n275TituloSaldo_F, H007O9_A273TituloTotalMovimento_F, H007O9_n273TituloTotalMovimento_F, H007O9_A286TituloCompetenciaAno, H007O9_n286TituloCompetenciaAno, H007O9_A287TituloCompetenciaMes, H007O9_n287TituloCompetenciaMes
               }
               , new Object[] {
               H007O17_A426CategoriaTituloId, H007O17_n426CategoriaTituloId, H007O17_A890NotaFiscalParcelamentoID, H007O17_n890NotaFiscalParcelamentoID, H007O17_A794NotaFiscalId, H007O17_n794NotaFiscalId, H007O17_A168ClienteId, H007O17_n168ClienteId, H007O17_A419TituloPropostaId, H007O17_n419TituloPropostaId,
               H007O17_A283TituloTipo, H007O17_n283TituloTipo, H007O17_A264TituloProrrogacao, H007O17_n264TituloProrrogacao, H007O17_A284TituloDeleted, H007O17_n284TituloDeleted, H007O17_A276TituloDesconto, H007O17_n276TituloDesconto, H007O17_A262TituloValor, H007O17_n262TituloValor,
               H007O17_A261TituloId, H007O17_A648TituloPropostaTipo, H007O17_n648TituloPropostaTipo, H007O17_A170ClienteRazaoSocial, H007O17_n170ClienteRazaoSocial, H007O17_A428CategoriaTituloDescricao, H007O17_n428CategoriaTituloDescricao, H007O17_A282TituloStatus_F, H007O17_n282TituloStatus_F, H007O17_A516TituloDataCredito_F,
               H007O17_n516TituloDataCredito_F, H007O17_A275TituloSaldo_F, H007O17_n275TituloSaldo_F, H007O17_A273TituloTotalMovimento_F, H007O17_n273TituloTotalMovimento_F, H007O17_A286TituloCompetenciaAno, H007O17_n286TituloCompetenciaAno, H007O17_A287TituloCompetenciaMes, H007O17_n287TituloCompetenciaMes
               }
            }
         );
         AV96Pgmname = "WCTitulosProposta";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV96Pgmname = "WCTitulosProposta";
         Gx_date = DateTimeUtil.Today( context);
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV33ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV69Wctitulospropostads_4_dynamicfiltersoperator1 ;
      private short AV73Wctitulospropostads_8_dynamicfiltersoperator2 ;
      private short AV77Wctitulospropostads_12_dynamicfiltersoperator3 ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
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
      private int AV7TituloPropostaId ;
      private int wcpOAV7TituloPropostaId ;
      private int edtClienteRazaoSocial_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_96 ;
      private int nGXsfl_96_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A419TituloPropostaId ;
      private int edtTituloPropostaId_Visible ;
      private int AV66Wctitulospropostads_1_titulopropostaid ;
      private int A261TituloId ;
      private int subGrid_Islastpage ;
      private int AV81Wctitulospropostads_16_tftitulopropostatipo_sels_Count ;
      private int AV90Wctitulospropostads_25_tftitulotipo_sels_Count ;
      private int A426CategoriaTituloId ;
      private int A168ClienteId ;
      private int edtCategoriaTituloDescricao_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtTituloId_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetenciaMes_Enabled ;
      private int edtTituloCompetencia_F_Enabled ;
      private int edtTituloProrrogacao_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloDataCredito_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int edtTituloPropostaId_Enabled ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTitulovalor1_Visible ;
      private int edtavTitulovalor2_Visible ;
      private int edtavTitulovalor3_Visible ;
      private int AV97GXV1 ;
      private int edtavTitulovalor3_Enabled ;
      private int edtavTitulovalor2_Enabled ;
      private int edtavTitulovalor1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV19TituloValor1 ;
      private decimal AV23TituloValor2 ;
      private decimal AV27TituloValor3 ;
      private decimal AV38TFTituloValor ;
      private decimal AV39TFTituloValor_To ;
      private decimal AV40TFTituloDesconto ;
      private decimal AV41TFTituloDesconto_To ;
      private decimal AV51TFTituloSaldo_F ;
      private decimal AV52TFTituloSaldo_F_To ;
      private decimal AV70Wctitulospropostads_5_titulovalor1 ;
      private decimal AV74Wctitulospropostads_9_titulovalor2 ;
      private decimal AV78Wctitulospropostads_13_titulovalor3 ;
      private decimal AV82Wctitulospropostads_17_tftitulovalor ;
      private decimal AV83Wctitulospropostads_18_tftitulovalor_to ;
      private decimal AV84Wctitulospropostads_19_tftitulodesconto ;
      private decimal AV85Wctitulospropostads_20_tftitulodesconto_to ;
      private decimal AV91Wctitulospropostads_26_tftitulosaldo_f ;
      private decimal AV92Wctitulospropostads_27_tftitulosaldo_f_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A275TituloSaldo_F ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_96_idx="0001" ;
      private string edtClienteRazaoSocial_Internalname ;
      private string AV96Pgmname ;
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
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
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
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string edtTituloPropostaId_Internalname ;
      private string edtTituloPropostaId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_tituloprorrogacaoauxdates_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick ;
      private string Tftituloprorrogacao_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV61Display ;
      private string edtCategoriaTituloDescricao_Internalname ;
      private string cmbTituloPropostaTipo_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloValor_Internalname ;
      private string edtTituloDesconto_Internalname ;
      private string chkTituloDeleted_Internalname ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetenciaMes_Internalname ;
      private string edtTituloCompetencia_F_Internalname ;
      private string edtTituloProrrogacao_Internalname ;
      private string cmbTituloTipo_Internalname ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloDataCredito_F_Internalname ;
      private string edtTituloStatus_F_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTitulovalor1_Internalname ;
      private string edtavTitulovalor2_Internalname ;
      private string edtavTitulovalor3_Internalname ;
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
      private string edtTituloProrrogacao_Columnheaderclass ;
      private string cmbTituloTipo_Columnheaderclass ;
      private string edtTituloStatus_F_Columnheaderclass ;
      private string edtavDisplay_Link ;
      private string edtTituloProrrogacao_Columnclass ;
      private string cmbTituloTipo_Columnclass ;
      private string edtTituloStatus_F_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_titulovalor3_cell_Internalname ;
      private string edtavTitulovalor3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_titulovalor2_cell_Internalname ;
      private string edtavTitulovalor2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_titulovalor1_cell_Internalname ;
      private string edtavTitulovalor1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV7TituloPropostaId ;
      private string sCtrlAV63IsUnique ;
      private string sGXsfl_96_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtCategoriaTituloDescricao_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string GXCCtl ;
      private string cmbTituloPropostaTipo_Jsonclick ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Jsonclick ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetenciaMes_Jsonclick ;
      private string edtTituloCompetencia_F_Jsonclick ;
      private string edtTituloProrrogacao_Jsonclick ;
      private string cmbTituloTipo_Jsonclick ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloDataCredito_F_Jsonclick ;
      private string edtTituloStatus_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV44TFTituloProrrogacao ;
      private DateTime AV45TFTituloProrrogacao_To ;
      private DateTime Gx_date ;
      private DateTime AV46DDO_TituloProrrogacaoAuxDate ;
      private DateTime AV47DDO_TituloProrrogacaoAuxDateTo ;
      private DateTime AV88Wctitulospropostads_23_tftituloprorrogacao ;
      private DateTime AV89Wctitulospropostads_24_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A516TituloDataCredito_F ;
      private bool AV63IsUnique ;
      private bool wcpOAV63IsUnique ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_96_Refreshing=false ;
      private bool AV15OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV29DynamicFiltersIgnoreFirst ;
      private bool AV28DynamicFiltersRemoving ;
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
      private bool AV71Wctitulospropostads_6_dynamicfiltersenabled2 ;
      private bool AV75Wctitulospropostads_10_dynamicfiltersenabled3 ;
      private bool n428CategoriaTituloDescricao ;
      private bool n170ClienteRazaoSocial ;
      private bool n648TituloPropostaTipo ;
      private bool n261TituloId ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n284TituloDeleted ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool n264TituloProrrogacao ;
      private bool n283TituloTipo ;
      private bool n273TituloTotalMovimento_F ;
      private bool n275TituloSaldo_F ;
      private bool n516TituloDataCredito_F ;
      private bool n282TituloStatus_F ;
      private bool n426CategoriaTituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n419TituloPropostaId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV64TFTituloPropostaTipo_SelsJson ;
      private string AV49TFTituloTipo_SelsJson ;
      private string AV32ManageFiltersXml ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV16FilterFullText ;
      private string AV36TFClienteRazaoSocial ;
      private string AV37TFClienteRazaoSocial_Sel ;
      private string AV42TFTituloCompetencia_F ;
      private string AV43TFTituloCompetencia_F_Sel ;
      private string AV58TFTituloStatus_F ;
      private string AV59TFTituloStatus_F_Sel ;
      private string AV48DDO_TituloProrrogacaoAuxDateText ;
      private string AV67Wctitulospropostads_2_filterfulltext ;
      private string AV68Wctitulospropostads_3_dynamicfiltersselector1 ;
      private string AV72Wctitulospropostads_7_dynamicfiltersselector2 ;
      private string AV76Wctitulospropostads_11_dynamicfiltersselector3 ;
      private string AV79Wctitulospropostads_14_tfclienterazaosocial ;
      private string AV80Wctitulospropostads_15_tfclienterazaosocial_sel ;
      private string AV86Wctitulospropostads_21_tftitulocompetencia_f ;
      private string AV87Wctitulospropostads_22_tftitulocompetencia_f_sel ;
      private string AV93Wctitulospropostads_28_tftitulostatus_f ;
      private string AV94Wctitulospropostads_29_tftitulostatus_f_sel ;
      private string A428CategoriaTituloDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A648TituloPropostaTipo ;
      private string A295TituloCompetencia_F ;
      private string A283TituloTipo ;
      private string A282TituloStatus_F ;
      private string lV67Wctitulospropostads_2_filterfulltext ;
      private string lV93Wctitulospropostads_28_tftitulostatus_f ;
      private string lV79Wctitulospropostads_14_tfclienterazaosocial ;
      private string AV62AuxText ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV30Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftituloprorrogacao_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbTituloPropostaTipo ;
      private GXCheckbox chkTituloDeleted ;
      private GXCombobox cmbTituloTipo ;
      private GxSimpleCollection<string> AV65TFTituloPropostaTipo_Sels ;
      private GxSimpleCollection<string> AV50TFTituloTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV31ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV60DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV81Wctitulospropostads_16_tftitulopropostatipo_sels ;
      private GxSimpleCollection<string> AV90Wctitulospropostads_25_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H007O9_A426CategoriaTituloId ;
      private bool[] H007O9_n426CategoriaTituloId ;
      private Guid[] H007O9_A890NotaFiscalParcelamentoID ;
      private bool[] H007O9_n890NotaFiscalParcelamentoID ;
      private Guid[] H007O9_A794NotaFiscalId ;
      private bool[] H007O9_n794NotaFiscalId ;
      private int[] H007O9_A168ClienteId ;
      private bool[] H007O9_n168ClienteId ;
      private int[] H007O9_A419TituloPropostaId ;
      private bool[] H007O9_n419TituloPropostaId ;
      private string[] H007O9_A283TituloTipo ;
      private bool[] H007O9_n283TituloTipo ;
      private DateTime[] H007O9_A264TituloProrrogacao ;
      private bool[] H007O9_n264TituloProrrogacao ;
      private bool[] H007O9_A284TituloDeleted ;
      private bool[] H007O9_n284TituloDeleted ;
      private decimal[] H007O9_A276TituloDesconto ;
      private bool[] H007O9_n276TituloDesconto ;
      private decimal[] H007O9_A262TituloValor ;
      private bool[] H007O9_n262TituloValor ;
      private int[] H007O9_A261TituloId ;
      private bool[] H007O9_n261TituloId ;
      private string[] H007O9_A648TituloPropostaTipo ;
      private bool[] H007O9_n648TituloPropostaTipo ;
      private string[] H007O9_A170ClienteRazaoSocial ;
      private bool[] H007O9_n170ClienteRazaoSocial ;
      private string[] H007O9_A428CategoriaTituloDescricao ;
      private bool[] H007O9_n428CategoriaTituloDescricao ;
      private string[] H007O9_A282TituloStatus_F ;
      private bool[] H007O9_n282TituloStatus_F ;
      private DateTime[] H007O9_A516TituloDataCredito_F ;
      private bool[] H007O9_n516TituloDataCredito_F ;
      private decimal[] H007O9_A275TituloSaldo_F ;
      private bool[] H007O9_n275TituloSaldo_F ;
      private decimal[] H007O9_A273TituloTotalMovimento_F ;
      private bool[] H007O9_n273TituloTotalMovimento_F ;
      private short[] H007O9_A286TituloCompetenciaAno ;
      private bool[] H007O9_n286TituloCompetenciaAno ;
      private short[] H007O9_A287TituloCompetenciaMes ;
      private bool[] H007O9_n287TituloCompetenciaMes ;
      private int[] H007O17_A426CategoriaTituloId ;
      private bool[] H007O17_n426CategoriaTituloId ;
      private Guid[] H007O17_A890NotaFiscalParcelamentoID ;
      private bool[] H007O17_n890NotaFiscalParcelamentoID ;
      private Guid[] H007O17_A794NotaFiscalId ;
      private bool[] H007O17_n794NotaFiscalId ;
      private int[] H007O17_A168ClienteId ;
      private bool[] H007O17_n168ClienteId ;
      private int[] H007O17_A419TituloPropostaId ;
      private bool[] H007O17_n419TituloPropostaId ;
      private string[] H007O17_A283TituloTipo ;
      private bool[] H007O17_n283TituloTipo ;
      private DateTime[] H007O17_A264TituloProrrogacao ;
      private bool[] H007O17_n264TituloProrrogacao ;
      private bool[] H007O17_A284TituloDeleted ;
      private bool[] H007O17_n284TituloDeleted ;
      private decimal[] H007O17_A276TituloDesconto ;
      private bool[] H007O17_n276TituloDesconto ;
      private decimal[] H007O17_A262TituloValor ;
      private bool[] H007O17_n262TituloValor ;
      private int[] H007O17_A261TituloId ;
      private bool[] H007O17_n261TituloId ;
      private string[] H007O17_A648TituloPropostaTipo ;
      private bool[] H007O17_n648TituloPropostaTipo ;
      private string[] H007O17_A170ClienteRazaoSocial ;
      private bool[] H007O17_n170ClienteRazaoSocial ;
      private string[] H007O17_A428CategoriaTituloDescricao ;
      private bool[] H007O17_n428CategoriaTituloDescricao ;
      private string[] H007O17_A282TituloStatus_F ;
      private bool[] H007O17_n282TituloStatus_F ;
      private DateTime[] H007O17_A516TituloDataCredito_F ;
      private bool[] H007O17_n516TituloDataCredito_F ;
      private decimal[] H007O17_A275TituloSaldo_F ;
      private bool[] H007O17_n275TituloSaldo_F ;
      private decimal[] H007O17_A273TituloTotalMovimento_F ;
      private bool[] H007O17_n273TituloTotalMovimento_F ;
      private short[] H007O17_A286TituloCompetenciaAno ;
      private bool[] H007O17_n286TituloCompetenciaAno ;
      private short[] H007O17_A287TituloCompetenciaMes ;
      private bool[] H007O17_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wctitulosproposta__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007O9( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV81Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV90Wctitulospropostads_25_tftitulotipo_sels ,
                                             string AV68Wctitulospropostads_3_dynamicfiltersselector1 ,
                                             short AV69Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                             decimal AV70Wctitulospropostads_5_titulovalor1 ,
                                             bool AV71Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                             string AV72Wctitulospropostads_7_dynamicfiltersselector2 ,
                                             short AV73Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                             decimal AV74Wctitulospropostads_9_titulovalor2 ,
                                             bool AV75Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                             string AV76Wctitulospropostads_11_dynamicfiltersselector3 ,
                                             short AV77Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                             decimal AV78Wctitulospropostads_13_titulovalor3 ,
                                             string AV80Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                             string AV79Wctitulospropostads_14_tfclienterazaosocial ,
                                             int AV81Wctitulospropostads_16_tftitulopropostatipo_sels_Count ,
                                             decimal AV82Wctitulospropostads_17_tftitulovalor ,
                                             decimal AV83Wctitulospropostads_18_tftitulovalor_to ,
                                             decimal AV84Wctitulospropostads_19_tftitulodesconto ,
                                             decimal AV85Wctitulospropostads_20_tftitulodesconto_to ,
                                             DateTime AV88Wctitulospropostads_23_tftituloprorrogacao ,
                                             DateTime AV89Wctitulospropostads_24_tftituloprorrogacao_to ,
                                             int AV90Wctitulospropostads_25_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV67Wctitulospropostads_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV87Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                             string AV86Wctitulospropostads_21_tftitulocompetencia_f ,
                                             decimal AV91Wctitulospropostads_26_tftitulosaldo_f ,
                                             decimal AV92Wctitulospropostads_27_tftitulosaldo_f_to ,
                                             string AV94Wctitulospropostads_29_tftitulostatus_f_sel ,
                                             string AV93Wctitulospropostads_28_tftitulostatus_f ,
                                             int A419TituloPropostaId ,
                                             int AV66Wctitulospropostads_1_titulopropostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[29];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloPropostaId, T1.TituloTipo, T1.TituloProrrogacao, T1.TituloDeleted, T1.TituloDesconto, T1.TituloValor, T1.TituloId, T1.TituloPropostaTipo, T5.ClienteRazaoSocial, T2.CategoriaTituloDescricao, COALESCE( T6.TituloStatus_F, '') AS TituloStatus_F, COALESCE( T7.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T8.TituloSaldo_F, 0) AS TituloSaldo_F, COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId) LEFT JOIN (SELECT CASE  WHEN (COALESCE( T11.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T11.TituloSaldo_F, 0) = COALESCE( T10.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T10.TituloId FROM (Titulo T10 INNER JOIN (SELECT ( COALESCE( T12.TituloValor, 0) - COALESCE( T12.TituloDesconto, 0)) - COALESCE( T13.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T12.TituloId FROM (Titulo T12 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T12.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T13 ON T13.TituloId = T12.TituloId) ) T11 ON T11.TituloId = T10.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T7 ON T7.TituloId";
         scmdbuf += " = T1.TituloId) INNER JOIN (SELECT ( COALESCE( T10.TituloValor, 0) - COALESCE( T10.TituloDesconto, 0)) - COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T10.TituloId FROM (Titulo T10 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T10.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T10.TituloId) ) T8 ON T8.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV91Wctitulospropostads_26_tftitulosaldo_f = 0) or ( COALESCE( T8.TituloSaldo_F, 0) >= :AV91Wctitulospropostads_26_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV92Wctitulospropostads_27_tftitulosaldo_f_to = 0) or ( COALESCE( T8.TituloSaldo_F, 0) <= :AV92Wctitulospropostads_27_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV94Wctitulospropostads_29_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV93Wctitulospropostads_28_tftitulostatus_f))=0))) or ( COALESCE( T6.TituloStatus_F, '') like :lV93Wctitulospropostads_28_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV94Wctitulospropostads_29_tftitulostatus_f_sel))=0) and Not :AV94Wctitulospropostads_29_tftitulostatus_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.TituloStatus_F, '') = ( :AV94Wctitulospropostads_29_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV94Wctitulospropostads_29_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.TituloStatus_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV66Wctitulospropostads_1_titulopropostaid)");
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wctitulospropostads_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wctitulospropostads_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV79Wctitulospropostads_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wctitulospropostads_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV80Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV80Wctitulospropostads_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( AV81Wctitulospropostads_16_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV81Wctitulospropostads_16_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_17_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV82Wctitulospropostads_17_tftitulovalor)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Wctitulospropostads_18_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV83Wctitulospropostads_18_tftitulovalor_to)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Wctitulospropostads_19_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV84Wctitulospropostads_19_tftitulodesconto)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Wctitulospropostads_20_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV85Wctitulospropostads_20_tftitulodesconto_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Wctitulospropostads_23_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV88Wctitulospropostads_23_tftituloprorrogacao)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Wctitulospropostads_24_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV89Wctitulospropostads_24_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( AV90Wctitulospropostads_25_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wctitulospropostads_25_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T5.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T5.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloPropostaTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloPropostaTipo DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloTipo DESC, T1.TituloId";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H007O17( IGxContext context ,
                                              string A648TituloPropostaTipo ,
                                              GxSimpleCollection<string> AV81Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              string A283TituloTipo ,
                                              GxSimpleCollection<string> AV90Wctitulospropostads_25_tftitulotipo_sels ,
                                              string AV68Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              short AV69Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              decimal AV70Wctitulospropostads_5_titulovalor1 ,
                                              bool AV71Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              string AV72Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              short AV73Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              decimal AV74Wctitulospropostads_9_titulovalor2 ,
                                              bool AV75Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              string AV76Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              short AV77Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              decimal AV78Wctitulospropostads_13_titulovalor3 ,
                                              string AV80Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              string AV79Wctitulospropostads_14_tfclienterazaosocial ,
                                              int AV81Wctitulospropostads_16_tftitulopropostatipo_sels_Count ,
                                              decimal AV82Wctitulospropostads_17_tftitulovalor ,
                                              decimal AV83Wctitulospropostads_18_tftitulovalor_to ,
                                              decimal AV84Wctitulospropostads_19_tftitulodesconto ,
                                              decimal AV85Wctitulospropostads_20_tftitulodesconto_to ,
                                              DateTime AV88Wctitulospropostads_23_tftituloprorrogacao ,
                                              DateTime AV89Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              int AV90Wctitulospropostads_25_tftitulotipo_sels_Count ,
                                              decimal A262TituloValor ,
                                              string A170ClienteRazaoSocial ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              short AV14OrderedBy ,
                                              bool AV15OrderedDsc ,
                                              string AV67Wctitulospropostads_2_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              decimal A275TituloSaldo_F ,
                                              string A282TituloStatus_F ,
                                              string AV87Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              string AV86Wctitulospropostads_21_tftitulocompetencia_f ,
                                              decimal AV91Wctitulospropostads_26_tftitulosaldo_f ,
                                              decimal AV92Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              string AV94Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              string AV93Wctitulospropostads_28_tftitulostatus_f ,
                                              int A419TituloPropostaId ,
                                              int AV66Wctitulospropostads_1_titulopropostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[29];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloPropostaId, T1.TituloTipo, T1.TituloProrrogacao, T1.TituloDeleted, T1.TituloDesconto, T1.TituloValor, T1.TituloId, T1.TituloPropostaTipo, T5.ClienteRazaoSocial, T2.CategoriaTituloDescricao, COALESCE( T6.TituloStatus_F, '') AS TituloStatus_F, COALESCE( T7.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T8.TituloSaldo_F, 0) AS TituloSaldo_F, COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId) LEFT JOIN (SELECT CASE  WHEN (COALESCE( T11.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T11.TituloSaldo_F, 0) = COALESCE( T10.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T10.TituloId FROM (Titulo T10 INNER JOIN (SELECT ( COALESCE( T12.TituloValor, 0) - COALESCE( T12.TituloDesconto, 0)) - COALESCE( T13.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T12.TituloId FROM (Titulo T12 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T12.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T13 ON T13.TituloId = T12.TituloId) ) T11 ON T11.TituloId = T10.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T7 ON T7.TituloId";
         scmdbuf += " = T1.TituloId) INNER JOIN (SELECT ( COALESCE( T10.TituloValor, 0) - COALESCE( T10.TituloDesconto, 0)) - COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T10.TituloId FROM (Titulo T10 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T10.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T10.TituloId) ) T8 ON T8.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV91Wctitulospropostads_26_tftitulosaldo_f = 0) or ( COALESCE( T8.TituloSaldo_F, 0) >= :AV91Wctitulospropostads_26_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV92Wctitulospropostads_27_tftitulosaldo_f_to = 0) or ( COALESCE( T8.TituloSaldo_F, 0) <= :AV92Wctitulospropostads_27_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV94Wctitulospropostads_29_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV93Wctitulospropostads_28_tftitulostatus_f))=0))) or ( COALESCE( T6.TituloStatus_F, '') like :lV93Wctitulospropostads_28_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV94Wctitulospropostads_29_tftitulostatus_f_sel))=0) and Not :AV94Wctitulospropostads_29_tftitulostatus_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.TituloStatus_F, '') = ( :AV94Wctitulospropostads_29_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV94Wctitulospropostads_29_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.TituloStatus_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV66Wctitulospropostads_1_titulopropostaid)");
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV69Wctitulospropostads_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV70Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV70Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV71Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV74Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV75Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV78Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wctitulospropostads_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wctitulospropostads_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV79Wctitulospropostads_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wctitulospropostads_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV80Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV80Wctitulospropostads_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( AV81Wctitulospropostads_16_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV81Wctitulospropostads_16_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_17_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV82Wctitulospropostads_17_tftitulovalor)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Wctitulospropostads_18_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV83Wctitulospropostads_18_tftitulovalor_to)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Wctitulospropostads_19_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV84Wctitulospropostads_19_tftitulodesconto)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Wctitulospropostads_20_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV85Wctitulospropostads_20_tftitulodesconto_to)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Wctitulospropostads_23_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV88Wctitulospropostads_23_tftituloprorrogacao)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Wctitulospropostads_24_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV89Wctitulospropostads_24_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( AV90Wctitulospropostads_25_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wctitulospropostads_25_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T5.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T5.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloPropostaTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloPropostaTipo DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloTipo DESC, T1.TituloId";
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
                     return conditional_H007O9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (int)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 1 :
                     return conditional_H007O17(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (int)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
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
          Object[] prmH007O9;
          prmH007O9 = new Object[] {
          new ParDef("AV91Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV91Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV93Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV93Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV66Wctitulospropostads_1_titulopropostaid",GXType.Int32,9,0) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("lV79Wctitulospropostads_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV80Wctitulospropostads_15_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV82Wctitulospropostads_17_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV83Wctitulospropostads_18_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV84Wctitulospropostads_19_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV85Wctitulospropostads_20_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV88Wctitulospropostads_23_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV89Wctitulospropostads_24_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          Object[] prmH007O17;
          prmH007O17 = new Object[] {
          new ParDef("AV91Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV91Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV93Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV93Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV94Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV66Wctitulospropostads_1_titulopropostaid",GXType.Int32,9,0) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV70Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("lV79Wctitulospropostads_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV80Wctitulospropostads_15_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV82Wctitulospropostads_17_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV83Wctitulospropostads_18_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV84Wctitulospropostads_19_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV85Wctitulospropostads_20_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV88Wctitulospropostads_23_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV89Wctitulospropostads_24_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007O9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O9,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007O17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O17,11, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((bool[]) buf[14])[0] = rslt.getBool(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[29])[0] = rslt.getGXDate(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((short[]) buf[35])[0] = rslt.getShort(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((bool[]) buf[14])[0] = rslt.getBool(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[29])[0] = rslt.getGXDate(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((short[]) buf[35])[0] = rslt.getShort(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                return;
       }
    }

 }

}
