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
   public class wclistaassinantes : GXWebComponent
   {
      public wclistaassinantes( )
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

      public wclistaassinantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId )
      {
         this.AV63AssinaturaId = aP0_AssinaturaId;
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
         cmbavAssinaturaparticipantestatus1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavAssinaturaparticipantestatus2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavAssinaturaparticipantestatus3 = new GXCombobox();
         cmbAssinaturaParticipanteTipo = new GXCombobox();
         cmbAssinaturaParticipanteStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
                  AV63AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV63AssinaturaId", StringUtil.LTrimStr( (decimal)(AV63AssinaturaId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV63AssinaturaId});
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
                  gxfirstwebparm = GetFirstPar( "AssinaturaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
         nRC_GXsfl_114 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_114"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_114_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_114_idx = GetPar( "sGXsfl_114_idx");
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
         cmbavAssinaturaparticipantestatus1.FromJSonString( GetNextPar( ));
         AV18AssinaturaParticipanteStatus1 = GetPar( "AssinaturaParticipanteStatus1");
         AV19ParticipanteDocumento1 = GetPar( "ParticipanteDocumento1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavAssinaturaparticipantestatus2.FromJSonString( GetNextPar( ));
         AV23AssinaturaParticipanteStatus2 = GetPar( "AssinaturaParticipanteStatus2");
         AV24ParticipanteDocumento2 = GetPar( "ParticipanteDocumento2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         cmbavAssinaturaparticipantestatus3.FromJSonString( GetNextPar( ));
         AV28AssinaturaParticipanteStatus3 = GetPar( "AssinaturaParticipanteStatus3");
         AV29ParticipanteDocumento3 = GetPar( "ParticipanteDocumento3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV66Pgmname = GetPar( "Pgmname");
         AV63AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV38TFParticipanteNome = GetPar( "TFParticipanteNome");
         AV39TFParticipanteNome_Sel = GetPar( "TFParticipanteNome_Sel");
         AV40TFParticipanteEmail = GetPar( "TFParticipanteEmail");
         AV41TFParticipanteEmail_Sel = GetPar( "TFParticipanteEmail_Sel");
         AV42TFParticipanteDocumento = GetPar( "TFParticipanteDocumento");
         AV43TFParticipanteDocumento_Sel = GetPar( "TFParticipanteDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV65TFAssinaturaParticipanteTipo_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV45TFAssinaturaParticipanteStatus_Sels);
         AV46TFAssinaturaParticipanteDataVisualizacao = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataVisualizacao"));
         AV47TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataVisualizacao_To"));
         AV51TFAssinaturaParticipanteDataConclusao = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataConclusao"));
         AV52TFAssinaturaParticipanteDataConclusao_To = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataConclusao_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
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
            PA5D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV66Pgmname = "WcListaAssinantes";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_114_Refreshing);
               WS5D2( ) ;
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
            context.SendWebValue( " Assinatura Participante") ;
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
            GXEncryptionTmp = "wclistaassinantes"+UrlEncode(StringUtil.LTrimStr(AV63AssinaturaId,10,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wclistaassinantes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS1", AV18AssinaturaParticipanteStatus1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vPARTICIPANTEDOCUMENTO1", AV19ParticipanteDocumento1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS2", AV23AssinaturaParticipanteStatus2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vPARTICIPANTEDOCUMENTO2", AV24ParticipanteDocumento2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS3", AV28AssinaturaParticipanteStatus3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vPARTICIPANTEDOCUMENTO3", AV29ParticipanteDocumento3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV60GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE", context.localUtil.DToC( AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO", context.localUtil.DToC( AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE", context.localUtil.DToC( AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO", context.localUtil.DToC( AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV63AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV63AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME", AV38TFParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME_SEL", AV39TFParticipanteNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEEMAIL", AV40TFParticipanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEEMAIL_SEL", AV41TFParticipanteEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEDOCUMENTO", AV42TFParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEDOCUMENTO_SEL", AV43TFParticipanteDocumento_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFASSINATURAPARTICIPANTETIPO_SELS", AV65TFAssinaturaParticipanteTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFASSINATURAPARTICIPANTETIPO_SELS", AV65TFAssinaturaParticipanteTipo_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFASSINATURAPARTICIPANTESTATUS_SELS", AV45TFAssinaturaParticipanteStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFASSINATURAPARTICIPANTESTATUS_SELS", AV45TFAssinaturaParticipanteStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO", context.localUtil.TToC( AV46TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO", context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATACONCLUSAO", context.localUtil.TToC( AV51TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO", context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTETIPO_SELSJSON", AV64TFAssinaturaParticipanteTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTESTATUS_SELSJSON", AV44TFAssinaturaParticipanteStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm5D2( )
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
         return "WcListaAssinantes" ;
      }

      public override string GetPgmdesc( )
      {
         return " Assinatura Participante" ;
      }

      protected void WB5D0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wclistaassinantes");
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
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcListaAssinantes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WcListaAssinantes.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_5D2( true) ;
         }
         else
         {
            wb_table1_43_5D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_5D2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_5D2( true) ;
         }
         else
         {
            wb_table2_68_5D2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_5D2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_5D2( true) ;
         }
         else
         {
            wb_table3_93_5D2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_5D2e( bool wbgen )
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
            StartGridControl114( ) ;
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            nRC_GXsfl_114 = (int)(nGXsfl_114_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV58GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV59GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV60GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WcListaAssinantes.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV56DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_assinaturaparticipantedatavisualizacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname, AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcListaAssinantes.htm");
            /* User Defined Control */
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.SetProperty("Start Date", AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate);
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.SetProperty("End Date", AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo);
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.Render(context, "wwp.daterangepicker", Tfassinaturaparticipantedatavisualizacao_rangepicker_Internalname, sPrefix+"TFASSINATURAPARTICIPANTEDATAVISUALIZACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_assinaturaparticipantedataconclusaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname, AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcListaAssinantes.htm");
            /* User Defined Control */
            ucTfassinaturaparticipantedataconclusao_rangepicker.SetProperty("Start Date", AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate);
            ucTfassinaturaparticipantedataconclusao_rangepicker.SetProperty("End Date", AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo);
            ucTfassinaturaparticipantedataconclusao_rangepicker.Render(context, "wwp.daterangepicker", Tfassinaturaparticipantedataconclusao_rangepicker_Internalname, sPrefix+"TFASSINATURAPARTICIPANTEDATACONCLUSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 114 )
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

      protected void START5D2( )
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
            Form.Meta.addItem("description", " Assinatura Participante", 0) ;
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
               STRUP5D0( ) ;
            }
         }
      }

      protected void WS5D2( )
      {
         START5D2( ) ;
         EVT5D2( ) ;
      }

      protected void EVT5D2( )
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
                                 STRUP5D0( ) ;
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
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E115D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E125D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E135D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E145D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E155D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E165D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E175D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E185D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E195D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E205D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E215D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E225D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E235D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDisplay_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5D0( ) ;
                              }
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV61Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV61Display);
                              A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n238AssinaturaId = false;
                              A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n233ParticipanteId = false;
                              A248ParticipanteNome = cgiGet( edtParticipanteNome_Internalname);
                              n248ParticipanteNome = false;
                              A235ParticipanteEmail = cgiGet( edtParticipanteEmail_Internalname);
                              n235ParticipanteEmail = false;
                              A234ParticipanteDocumento = cgiGet( edtParticipanteDocumento_Internalname);
                              n234ParticipanteDocumento = false;
                              cmbAssinaturaParticipanteTipo.Name = cmbAssinaturaParticipanteTipo_Internalname;
                              cmbAssinaturaParticipanteTipo.CurrentValue = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
                              A247AssinaturaParticipanteTipo = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
                              n247AssinaturaParticipanteTipo = false;
                              cmbAssinaturaParticipanteStatus.Name = cmbAssinaturaParticipanteStatus_Internalname;
                              cmbAssinaturaParticipanteStatus.CurrentValue = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
                              A353AssinaturaParticipanteStatus = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
                              n353AssinaturaParticipanteStatus = false;
                              A244AssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataVisualizacao_Internalname), 0);
                              n244AssinaturaParticipanteDataVisualizacao = false;
                              A245AssinaturaParticipanteDataConclusao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataConclusao_Internalname), 0);
                              n245AssinaturaParticipanteDataConclusao = false;
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E245D2 ();
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E255D2 ();
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E265D2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDISPLAY.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E275D2 ();
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
                                             /* Set Refresh If Assinaturaparticipantestatus1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS1"), AV18AssinaturaParticipanteStatus1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Participantedocumento1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO1"), AV19ParticipanteDocumento1) != 0 )
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
                                             /* Set Refresh If Assinaturaparticipantestatus2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS2"), AV23AssinaturaParticipanteStatus2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Participantedocumento2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO2"), AV24ParticipanteDocumento2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Assinaturaparticipantestatus3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS3"), AV28AssinaturaParticipanteStatus3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Participantedocumento3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO3"), AV29ParticipanteDocumento3) != 0 )
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
                                       STRUP5D0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
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

      protected void WE5D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5D2( ) ;
            }
         }
      }

      protected void PA5D2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wclistaassinantes")), "wclistaassinantes") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wclistaassinantes")))) ;
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
                     gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
         SubsflControlProps_1142( ) ;
         while ( nGXsfl_114_idx <= nRC_GXsfl_114 )
         {
            sendrow_1142( ) ;
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
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
                                       string AV18AssinaturaParticipanteStatus1 ,
                                       string AV19ParticipanteDocumento1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23AssinaturaParticipanteStatus2 ,
                                       string AV24ParticipanteDocumento2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28AssinaturaParticipanteStatus3 ,
                                       string AV29ParticipanteDocumento3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       string AV66Pgmname ,
                                       long AV63AssinaturaId ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV38TFParticipanteNome ,
                                       string AV39TFParticipanteNome_Sel ,
                                       string AV40TFParticipanteEmail ,
                                       string AV41TFParticipanteEmail_Sel ,
                                       string AV42TFParticipanteDocumento ,
                                       string AV43TFParticipanteDocumento_Sel ,
                                       GxSimpleCollection<string> AV65TFAssinaturaParticipanteTipo_Sels ,
                                       GxSimpleCollection<string> AV45TFAssinaturaParticipanteStatus_Sels ,
                                       DateTime AV46TFAssinaturaParticipanteDataVisualizacao ,
                                       DateTime AV47TFAssinaturaParticipanteDataVisualizacao_To ,
                                       DateTime AV51TFAssinaturaParticipanteDataConclusao ,
                                       DateTime AV52TFAssinaturaParticipanteDataConclusao_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ASSINATURAPARTICIPANTEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", "")));
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
         if ( cmbavAssinaturaparticipantestatus1.ItemCount > 0 )
         {
            AV18AssinaturaParticipanteStatus1 = cmbavAssinaturaparticipantestatus1.getValidValue(AV18AssinaturaParticipanteStatus1);
            AssignAttri(sPrefix, false, "AV18AssinaturaParticipanteStatus1", AV18AssinaturaParticipanteStatus1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", cmbavAssinaturaparticipantestatus1.ToJavascriptSource(), true);
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
         if ( cmbavAssinaturaparticipantestatus2.ItemCount > 0 )
         {
            AV23AssinaturaParticipanteStatus2 = cmbavAssinaturaparticipantestatus2.getValidValue(AV23AssinaturaParticipanteStatus2);
            AssignAttri(sPrefix, false, "AV23AssinaturaParticipanteStatus2", AV23AssinaturaParticipanteStatus2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", cmbavAssinaturaparticipantestatus2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturaparticipantestatus3.ItemCount > 0 )
         {
            AV28AssinaturaParticipanteStatus3 = cmbavAssinaturaparticipantestatus3.getValidValue(AV28AssinaturaParticipanteStatus3);
            AssignAttri(sPrefix, false, "AV28AssinaturaParticipanteStatus3", AV28AssinaturaParticipanteStatus3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", cmbavAssinaturaparticipantestatus3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV66Pgmname = "WcListaAssinantes";
         edtavDisplay_Enabled = 0;
      }

      protected void RF5D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E255D2 ();
         nGXsfl_114_idx = 1;
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         bGXsfl_114_Refreshing = true;
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
            SubsflControlProps_1142( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A247AssinaturaParticipanteTipo ,
                                                 AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                                 A353AssinaturaParticipanteStatus ,
                                                 AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                                 AV68Wclistaassinantesds_2_filterfulltext ,
                                                 AV69Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                                 AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                                 AV70Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                                 AV72Wclistaassinantesds_6_participantedocumento1 ,
                                                 AV73Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                                 AV74Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                                 AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                                 AV75Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                                 AV77Wclistaassinantesds_11_participantedocumento2 ,
                                                 AV78Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                                 AV79Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                                 AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                                 AV80Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                                 AV82Wclistaassinantesds_16_participantedocumento3 ,
                                                 AV84Wclistaassinantesds_18_tfparticipantenome_sel ,
                                                 AV83Wclistaassinantesds_17_tfparticipantenome ,
                                                 AV86Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                                 AV85Wclistaassinantesds_19_tfparticipanteemail ,
                                                 AV88Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                                 AV87Wclistaassinantesds_21_tfparticipantedocumento ,
                                                 AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                                 AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                                 AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                                 AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                                 AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                                 AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                                 A248ParticipanteNome ,
                                                 A235ParticipanteEmail ,
                                                 A234ParticipanteDocumento ,
                                                 A244AssinaturaParticipanteDataVisualizacao ,
                                                 A245AssinaturaParticipanteDataConclusao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A238AssinaturaId ,
                                                 AV67Wclistaassinantesds_1_assinaturaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
            lV72Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1), "%", "");
            lV72Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1), "%", "");
            lV77Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2), "%", "");
            lV77Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2), "%", "");
            lV82Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3), "%", "");
            lV82Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3), "%", "");
            lV83Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV83Wclistaassinantesds_17_tfparticipantenome), "%", "");
            lV85Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV85Wclistaassinantesds_19_tfparticipanteemail), "%", "");
            lV87Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV87Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
            /* Using cursor H005D2 */
            pr_default.execute(0, new Object[] {AV67Wclistaassinantesds_1_assinaturaid, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, AV71Wclistaassinantesds_5_assinaturaparticipantestatus1, lV72Wclistaassinantesds_6_participantedocumento1, lV72Wclistaassinantesds_6_participantedocumento1, AV76Wclistaassinantesds_10_assinaturaparticipantestatus2, lV77Wclistaassinantesds_11_participantedocumento2, lV77Wclistaassinantesds_11_participantedocumento2, AV81Wclistaassinantesds_15_assinaturaparticipantestatus3, lV82Wclistaassinantesds_16_participantedocumento3, lV82Wclistaassinantesds_16_participantedocumento3, lV83Wclistaassinantesds_17_tfparticipantenome, AV84Wclistaassinantesds_18_tfparticipantenome_sel, lV85Wclistaassinantesds_19_tfparticipanteemail, AV86Wclistaassinantesds_20_tfparticipanteemail_sel, lV87Wclistaassinantesds_21_tfparticipantedocumento, AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A245AssinaturaParticipanteDataConclusao = H005D2_A245AssinaturaParticipanteDataConclusao[0];
               n245AssinaturaParticipanteDataConclusao = H005D2_n245AssinaturaParticipanteDataConclusao[0];
               A244AssinaturaParticipanteDataVisualizacao = H005D2_A244AssinaturaParticipanteDataVisualizacao[0];
               n244AssinaturaParticipanteDataVisualizacao = H005D2_n244AssinaturaParticipanteDataVisualizacao[0];
               A353AssinaturaParticipanteStatus = H005D2_A353AssinaturaParticipanteStatus[0];
               n353AssinaturaParticipanteStatus = H005D2_n353AssinaturaParticipanteStatus[0];
               A247AssinaturaParticipanteTipo = H005D2_A247AssinaturaParticipanteTipo[0];
               n247AssinaturaParticipanteTipo = H005D2_n247AssinaturaParticipanteTipo[0];
               A234ParticipanteDocumento = H005D2_A234ParticipanteDocumento[0];
               n234ParticipanteDocumento = H005D2_n234ParticipanteDocumento[0];
               A235ParticipanteEmail = H005D2_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H005D2_n235ParticipanteEmail[0];
               A248ParticipanteNome = H005D2_A248ParticipanteNome[0];
               n248ParticipanteNome = H005D2_n248ParticipanteNome[0];
               A233ParticipanteId = H005D2_A233ParticipanteId[0];
               n233ParticipanteId = H005D2_n233ParticipanteId[0];
               A238AssinaturaId = H005D2_A238AssinaturaId[0];
               n238AssinaturaId = H005D2_n238AssinaturaId[0];
               A242AssinaturaParticipanteId = H005D2_A242AssinaturaParticipanteId[0];
               A234ParticipanteDocumento = H005D2_A234ParticipanteDocumento[0];
               n234ParticipanteDocumento = H005D2_n234ParticipanteDocumento[0];
               A235ParticipanteEmail = H005D2_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H005D2_n235ParticipanteEmail[0];
               A248ParticipanteNome = H005D2_A248ParticipanteNome[0];
               n248ParticipanteNome = H005D2_n248ParticipanteNome[0];
               /* Execute user event: Grid.Load */
               E265D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 114;
            WB5D0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5D2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ASSINATURAPARTICIPANTEID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sPrefix+sGXsfl_114_idx, context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
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
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A247AssinaturaParticipanteTipo ,
                                              AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                              AV68Wclistaassinantesds_2_filterfulltext ,
                                              AV69Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                              AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                              AV70Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                              AV72Wclistaassinantesds_6_participantedocumento1 ,
                                              AV73Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                              AV74Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                              AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                              AV75Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                              AV77Wclistaassinantesds_11_participantedocumento2 ,
                                              AV78Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                              AV79Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                              AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                              AV80Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                              AV82Wclistaassinantesds_16_participantedocumento3 ,
                                              AV84Wclistaassinantesds_18_tfparticipantenome_sel ,
                                              AV83Wclistaassinantesds_17_tfparticipantenome ,
                                              AV86Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                              AV85Wclistaassinantesds_19_tfparticipanteemail ,
                                              AV88Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                              AV87Wclistaassinantesds_21_tfparticipantedocumento ,
                                              AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                              AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                              AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A238AssinaturaId ,
                                              AV67Wclistaassinantesds_1_assinaturaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV68Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext), "%", "");
         lV72Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV72Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV77Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV77Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV82Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV82Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV83Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV83Wclistaassinantesds_17_tfparticipantenome), "%", "");
         lV85Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV85Wclistaassinantesds_19_tfparticipanteemail), "%", "");
         lV87Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV87Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
         /* Using cursor H005D3 */
         pr_default.execute(1, new Object[] {AV67Wclistaassinantesds_1_assinaturaid, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, lV68Wclistaassinantesds_2_filterfulltext, AV71Wclistaassinantesds_5_assinaturaparticipantestatus1, lV72Wclistaassinantesds_6_participantedocumento1, lV72Wclistaassinantesds_6_participantedocumento1, AV76Wclistaassinantesds_10_assinaturaparticipantestatus2, lV77Wclistaassinantesds_11_participantedocumento2, lV77Wclistaassinantesds_11_participantedocumento2, AV81Wclistaassinantesds_15_assinaturaparticipantestatus3, lV82Wclistaassinantesds_16_participantedocumento3, lV82Wclistaassinantesds_16_participantedocumento3, lV83Wclistaassinantesds_17_tfparticipantenome, AV84Wclistaassinantesds_18_tfparticipantenome_sel, lV85Wclistaassinantesds_19_tfparticipanteemail, AV86Wclistaassinantesds_20_tfparticipanteemail_sel, lV87Wclistaassinantesds_21_tfparticipantedocumento, AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to});
         GRID_nRecordCount = H005D3_AGRID_nRecordCount[0];
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
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV66Pgmname = "WcListaAssinantes";
         edtavDisplay_Enabled = 0;
         edtAssinaturaParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         edtParticipanteEmail_Enabled = 0;
         edtParticipanteDocumento_Enabled = 0;
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E245D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV56DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV59GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV60GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate", context.localUtil.Format(AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, "99/99/9999"));
            AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo", context.localUtil.Format(AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, "99/99/9999"));
            AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate", context.localUtil.Format(AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate, "99/99/9999"));
            AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo", context.localUtil.Format(AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, "99/99/9999"));
            wcpOAV63AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV63AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
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
            cmbavAssinaturaparticipantestatus1.Name = cmbavAssinaturaparticipantestatus1_Internalname;
            cmbavAssinaturaparticipantestatus1.CurrentValue = cgiGet( cmbavAssinaturaparticipantestatus1_Internalname);
            AV18AssinaturaParticipanteStatus1 = cgiGet( cmbavAssinaturaparticipantestatus1_Internalname);
            AssignAttri(sPrefix, false, "AV18AssinaturaParticipanteStatus1", AV18AssinaturaParticipanteStatus1);
            AV19ParticipanteDocumento1 = cgiGet( edtavParticipantedocumento1_Internalname);
            AssignAttri(sPrefix, false, "AV19ParticipanteDocumento1", AV19ParticipanteDocumento1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            cmbavAssinaturaparticipantestatus2.Name = cmbavAssinaturaparticipantestatus2_Internalname;
            cmbavAssinaturaparticipantestatus2.CurrentValue = cgiGet( cmbavAssinaturaparticipantestatus2_Internalname);
            AV23AssinaturaParticipanteStatus2 = cgiGet( cmbavAssinaturaparticipantestatus2_Internalname);
            AssignAttri(sPrefix, false, "AV23AssinaturaParticipanteStatus2", AV23AssinaturaParticipanteStatus2);
            AV24ParticipanteDocumento2 = cgiGet( edtavParticipantedocumento2_Internalname);
            AssignAttri(sPrefix, false, "AV24ParticipanteDocumento2", AV24ParticipanteDocumento2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            cmbavAssinaturaparticipantestatus3.Name = cmbavAssinaturaparticipantestatus3_Internalname;
            cmbavAssinaturaparticipantestatus3.CurrentValue = cgiGet( cmbavAssinaturaparticipantestatus3_Internalname);
            AV28AssinaturaParticipanteStatus3 = cgiGet( cmbavAssinaturaparticipantestatus3_Internalname);
            AssignAttri(sPrefix, false, "AV28AssinaturaParticipanteStatus3", AV28AssinaturaParticipanteStatus3);
            AV29ParticipanteDocumento3 = cgiGet( edtavParticipantedocumento3_Internalname);
            AssignAttri(sPrefix, false, "AV29ParticipanteDocumento3", AV29ParticipanteDocumento3);
            AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText = cgiGet( edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText", AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText);
            AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText = cgiGet( edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText", AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS1"), AV18AssinaturaParticipanteStatus1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO1"), AV19ParticipanteDocumento1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS2"), AV23AssinaturaParticipanteStatus2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO2"), AV24ParticipanteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vASSINATURAPARTICIPANTESTATUS3"), AV28AssinaturaParticipanteStatus3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPARTICIPANTEDOCUMENTO3"), AV29ParticipanteDocumento3) != 0 )
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
         E245D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E245D2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFASSINATURAPARTICIPANTEDATACONCLUSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname});
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
         AV18AssinaturaParticipanteStatus1 = "";
         AssignAttri(sPrefix, false, "AV18AssinaturaParticipanteStatus1", AV18AssinaturaParticipanteStatus1);
         AV16DynamicFiltersSelector1 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23AssinaturaParticipanteStatus2 = "";
         AssignAttri(sPrefix, false, "AV23AssinaturaParticipanteStatus2", AV23AssinaturaParticipanteStatus2);
         AV21DynamicFiltersSelector2 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28AssinaturaParticipanteStatus3 = "";
         AssignAttri(sPrefix, false, "AV28AssinaturaParticipanteStatus3", AV28AssinaturaParticipanteStatus3);
         AV26DynamicFiltersSelector3 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV56DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV56DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E255D2( )
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
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
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
         AV58GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV58GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV58GridCurrentPage), 10, 0));
         AV59GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV59GridPageCount", StringUtil.LTrimStr( (decimal)(AV59GridPageCount), 10, 0));
         GXt_char2 = AV60GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV66Pgmname, out  GXt_char2) ;
         AV60GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV60GridAppliedFilters", AV60GridAppliedFilters);
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Columnheaderclass", cmbAssinaturaParticipanteStatus_Columnheaderclass, !bGXsfl_114_Refreshing);
         AV67Wclistaassinantesds_1_assinaturaid = AV63AssinaturaId;
         AV68Wclistaassinantesds_2_filterfulltext = AV15FilterFullText;
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV70Wclistaassinantesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV18AssinaturaParticipanteStatus1;
         AV72Wclistaassinantesds_6_participantedocumento1 = AV19ParticipanteDocumento1;
         AV73Wclistaassinantesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV75Wclistaassinantesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV23AssinaturaParticipanteStatus2;
         AV77Wclistaassinantesds_11_participantedocumento2 = AV24ParticipanteDocumento2;
         AV78Wclistaassinantesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Wclistaassinantesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV28AssinaturaParticipanteStatus3;
         AV82Wclistaassinantesds_16_participantedocumento3 = AV29ParticipanteDocumento3;
         AV83Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV85Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV87Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV65TFAssinaturaParticipanteTipo_Sels;
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV45TFAssinaturaParticipanteStatus_Sels;
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV46TFAssinaturaParticipanteDataVisualizacao;
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV47TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV51TFAssinaturaParticipanteDataConclusao;
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV52TFAssinaturaParticipanteDataConclusao_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E125D2( )
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
            AV57PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV57PageToGo) ;
         }
      }

      protected void E135D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E145D2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteNome") == 0 )
            {
               AV38TFParticipanteNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV38TFParticipanteNome", AV38TFParticipanteNome);
               AV39TFParticipanteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV39TFParticipanteNome_Sel", AV39TFParticipanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteEmail") == 0 )
            {
               AV40TFParticipanteEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV40TFParticipanteEmail", AV40TFParticipanteEmail);
               AV41TFParticipanteEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV41TFParticipanteEmail_Sel", AV41TFParticipanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteDocumento") == 0 )
            {
               AV42TFParticipanteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV42TFParticipanteDocumento", AV42TFParticipanteDocumento);
               AV43TFParticipanteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV43TFParticipanteDocumento_Sel", AV43TFParticipanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteTipo") == 0 )
            {
               AV64TFAssinaturaParticipanteTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV64TFAssinaturaParticipanteTipo_SelsJson", AV64TFAssinaturaParticipanteTipo_SelsJson);
               AV65TFAssinaturaParticipanteTipo_Sels.FromJSonString(AV64TFAssinaturaParticipanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteStatus") == 0 )
            {
               AV44TFAssinaturaParticipanteStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV44TFAssinaturaParticipanteStatus_SelsJson", AV44TFAssinaturaParticipanteStatus_SelsJson);
               AV45TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV44TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteDataVisualizacao") == 0 )
            {
               AV46TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV46TFAssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( AV46TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
               AV47TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV47TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV47TFAssinaturaParticipanteDataVisualizacao_To) )
               {
                  AV47TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV47TFAssinaturaParticipanteDataVisualizacao_To)), (short)(DateTimeUtil.Month( AV47TFAssinaturaParticipanteDataVisualizacao_To)), (short)(DateTimeUtil.Day( AV47TFAssinaturaParticipanteDataVisualizacao_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV47TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteDataConclusao") == 0 )
            {
               AV51TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV51TFAssinaturaParticipanteDataConclusao", context.localUtil.TToC( AV51TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
               AV52TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV52TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV52TFAssinaturaParticipanteDataConclusao_To) )
               {
                  AV52TFAssinaturaParticipanteDataConclusao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV52TFAssinaturaParticipanteDataConclusao_To)), (short)(DateTimeUtil.Month( AV52TFAssinaturaParticipanteDataConclusao_To)), (short)(DateTimeUtil.Day( AV52TFAssinaturaParticipanteDataConclusao_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV52TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV45TFAssinaturaParticipanteStatus_Sels", AV45TFAssinaturaParticipanteStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV65TFAssinaturaParticipanteTipo_Sels", AV65TFAssinaturaParticipanteTipo_Sels);
      }

      private void E265D2( )
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
         GXEncryptionTmp = "participante"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A233ParticipanteId,8,0));
         edtParticipanteDocumento_Link = formatLink("participante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 114;
         }
         sendrow_1142( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_114_Refreshing )
         {
            DoAjaxLoad(114, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E195D2( )
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

      protected void E155D2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", cmbavAssinaturaparticipantestatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", cmbavAssinaturaparticipantestatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", cmbavAssinaturaparticipantestatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E205D2( )
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

      protected void E215D2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E165D2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", cmbavAssinaturaparticipantestatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", cmbavAssinaturaparticipantestatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", cmbavAssinaturaparticipantestatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E225D2( )
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

      protected void E175D2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaParticipanteStatus1, AV19ParticipanteDocumento1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaParticipanteStatus2, AV24ParticipanteDocumento2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaParticipanteStatus3, AV29ParticipanteDocumento3, AV37ManageFiltersExecutionStep, AV66Pgmname, AV63AssinaturaId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFParticipanteNome, AV39TFParticipanteNome_Sel, AV40TFParticipanteEmail, AV41TFParticipanteEmail_Sel, AV42TFParticipanteDocumento, AV43TFParticipanteDocumento_Sel, AV65TFAssinaturaParticipanteTipo_Sels, AV45TFAssinaturaParticipanteStatus_Sels, AV46TFAssinaturaParticipanteDataVisualizacao, AV47TFAssinaturaParticipanteDataVisualizacao_To, AV51TFAssinaturaParticipanteDataConclusao, AV52TFAssinaturaParticipanteDataConclusao_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", cmbavAssinaturaparticipantestatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", cmbavAssinaturaparticipantestatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", cmbavAssinaturaparticipantestatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E235D2( )
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

      protected void E115D2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WcListaAssinantesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV66Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WcListaAssinantesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WcListaAssinantesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV65TFAssinaturaParticipanteTipo_Sels", AV65TFAssinaturaParticipanteTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV45TFAssinaturaParticipanteStatus_Sels", AV45TFAssinaturaParticipanteStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", cmbavAssinaturaparticipantestatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", cmbavAssinaturaparticipantestatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", cmbavAssinaturaparticipantestatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E275D2( )
      {
         /* Display_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "consultaassinantecontrato"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A242AssinaturaParticipanteId,9,0));
         context.PopUp(formatLink("consultaassinantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E185D2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new wclistaassinantesexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavAssinaturaparticipantestatus1.Visible = 0;
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus1.Visible), 5, 0), true);
         edtavParticipantedocumento1_Visible = 0;
         AssignProp(sPrefix, false, edtavParticipantedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURAPARTICIPANTESTATUS") == 0 )
         {
            cmbavAssinaturaparticipantestatus1.Visible = 1;
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
         {
            edtavParticipantedocumento1_Visible = 1;
            AssignProp(sPrefix, false, edtavParticipantedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavAssinaturaparticipantestatus2.Visible = 0;
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus2.Visible), 5, 0), true);
         edtavParticipantedocumento2_Visible = 0;
         AssignProp(sPrefix, false, edtavParticipantedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURAPARTICIPANTESTATUS") == 0 )
         {
            cmbavAssinaturaparticipantestatus2.Visible = 1;
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
         {
            edtavParticipantedocumento2_Visible = 1;
            AssignProp(sPrefix, false, edtavParticipantedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavAssinaturaparticipantestatus3.Visible = 0;
         AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus3.Visible), 5, 0), true);
         edtavParticipantedocumento3_Visible = 0;
         AssignProp(sPrefix, false, edtavParticipantedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURAPARTICIPANTESTATUS") == 0 )
         {
            cmbavAssinaturaparticipantestatus3.Visible = 1;
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipantestatus3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
         {
            edtavParticipantedocumento3_Visible = 1;
            AssignProp(sPrefix, false, edtavParticipantedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipantedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV23AssinaturaParticipanteStatus2 = "";
         AssignAttri(sPrefix, false, "AV23AssinaturaParticipanteStatus2", AV23AssinaturaParticipanteStatus2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV28AssinaturaParticipanteStatus3 = "";
         AssignAttri(sPrefix, false, "AV28AssinaturaParticipanteStatus3", AV28AssinaturaParticipanteStatus3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WcListaAssinantesFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFParticipanteNome = "";
         AssignAttri(sPrefix, false, "AV38TFParticipanteNome", AV38TFParticipanteNome);
         AV39TFParticipanteNome_Sel = "";
         AssignAttri(sPrefix, false, "AV39TFParticipanteNome_Sel", AV39TFParticipanteNome_Sel);
         AV40TFParticipanteEmail = "";
         AssignAttri(sPrefix, false, "AV40TFParticipanteEmail", AV40TFParticipanteEmail);
         AV41TFParticipanteEmail_Sel = "";
         AssignAttri(sPrefix, false, "AV41TFParticipanteEmail_Sel", AV41TFParticipanteEmail_Sel);
         AV42TFParticipanteDocumento = "";
         AssignAttri(sPrefix, false, "AV42TFParticipanteDocumento", AV42TFParticipanteDocumento);
         AV43TFParticipanteDocumento_Sel = "";
         AssignAttri(sPrefix, false, "AV43TFParticipanteDocumento_Sel", AV43TFParticipanteDocumento_Sel);
         AV65TFAssinaturaParticipanteTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45TFAssinaturaParticipanteStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV46TFAssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( AV46TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
         AV47TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV47TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
         AV51TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV51TFAssinaturaParticipanteDataConclusao", context.localUtil.TToC( AV51TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
         AV52TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV52TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "ASSINATURAPARTICIPANTESTATUS";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV18AssinaturaParticipanteStatus1 = "";
         AssignAttri(sPrefix, false, "AV18AssinaturaParticipanteStatus1", AV18AssinaturaParticipanteStatus1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV66Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV66Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV66Pgmname+"GridState"), null, "", "");
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
         AV95GXV1 = 1;
         while ( AV95GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV95GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV38TFParticipanteNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFParticipanteNome", AV38TFParticipanteNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV39TFParticipanteNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFParticipanteNome_Sel", AV39TFParticipanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV40TFParticipanteEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFParticipanteEmail", AV40TFParticipanteEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV41TFParticipanteEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFParticipanteEmail_Sel", AV41TFParticipanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV42TFParticipanteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42TFParticipanteDocumento", AV42TFParticipanteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV43TFParticipanteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43TFParticipanteDocumento_Sel", AV43TFParticipanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTETIPO_SEL") == 0 )
            {
               AV64TFAssinaturaParticipanteTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV64TFAssinaturaParticipanteTipo_SelsJson", AV64TFAssinaturaParticipanteTipo_SelsJson);
               AV65TFAssinaturaParticipanteTipo_Sels.FromJSonString(AV64TFAssinaturaParticipanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTESTATUS_SEL") == 0 )
            {
               AV44TFAssinaturaParticipanteStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV44TFAssinaturaParticipanteStatus_SelsJson", AV44TFAssinaturaParticipanteStatus_SelsJson);
               AV45TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV44TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO") == 0 )
            {
               AV46TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV46TFAssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( AV46TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
               AV47TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV47TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = DateTimeUtil.ResetTime(AV46TFAssinaturaParticipanteDataVisualizacao);
               AssignAttri(sPrefix, false, "AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate", context.localUtil.Format(AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, "99/99/9999"));
               AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = DateTimeUtil.ResetTime(AV47TFAssinaturaParticipanteDataVisualizacao_To);
               AssignAttri(sPrefix, false, "AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo", context.localUtil.Format(AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATACONCLUSAO") == 0 )
            {
               AV51TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV51TFAssinaturaParticipanteDataConclusao", context.localUtil.TToC( AV51TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
               AV52TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV52TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate = DateTimeUtil.ResetTime(AV51TFAssinaturaParticipanteDataConclusao);
               AssignAttri(sPrefix, false, "AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate", context.localUtil.Format(AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate, "99/99/9999"));
               AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = DateTimeUtil.ResetTime(AV52TFAssinaturaParticipanteDataConclusao_To);
               AssignAttri(sPrefix, false, "AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo", context.localUtil.Format(AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, "99/99/9999"));
            }
            AV95GXV1 = (int)(AV95GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome_Sel)),  AV39TFParticipanteNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParticipanteEmail_Sel)),  AV41TFParticipanteEmail_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParticipanteDocumento_Sel)),  AV43TFParticipanteDocumento_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV65TFAssinaturaParticipanteTipo_Sels.Count==0),  AV64TFAssinaturaParticipanteTipo_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV45TFAssinaturaParticipanteStatus_Sels.Count==0),  AV44TFAssinaturaParticipanteStatus_SelsJson, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFParticipanteNome)),  AV38TFParticipanteNome, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParticipanteEmail)),  AV40TFParticipanteEmail, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParticipanteDocumento)),  AV42TFParticipanteDocumento, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|||"+((DateTime.MinValue==AV46TFAssinaturaParticipanteDataVisualizacao) ? "" : context.localUtil.DToC( AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV51TFAssinaturaParticipanteDataConclusao) ? "" : context.localUtil.DToC( AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||"+((DateTime.MinValue==AV47TFAssinaturaParticipanteDataVisualizacao_To) ? "" : context.localUtil.DToC( AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV52TFAssinaturaParticipanteDataConclusao_To) ? "" : context.localUtil.DToC( AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, 4, "/"));
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
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURAPARTICIPANTESTATUS") == 0 )
            {
               AV18AssinaturaParticipanteStatus1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18AssinaturaParticipanteStatus1", AV18AssinaturaParticipanteStatus1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ParticipanteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19ParticipanteDocumento1", AV19ParticipanteDocumento1);
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURAPARTICIPANTESTATUS") == 0 )
               {
                  AV23AssinaturaParticipanteStatus2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV23AssinaturaParticipanteStatus2", AV23AssinaturaParticipanteStatus2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24ParticipanteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV24ParticipanteDocumento2", AV24ParticipanteDocumento2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURAPARTICIPANTESTATUS") == 0 )
                  {
                     AV28AssinaturaParticipanteStatus3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV28AssinaturaParticipanteStatus3", AV28AssinaturaParticipanteStatus3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29ParticipanteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV29ParticipanteDocumento3", AV29ParticipanteDocumento3);
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
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV66Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTENOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFParticipanteNome)),  0,  AV38TFParticipanteNome,  AV38TFParticipanteNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome_Sel)),  AV39TFParticipanteNome_Sel,  AV39TFParticipanteNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParticipanteEmail)),  0,  AV40TFParticipanteEmail,  AV40TFParticipanteEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParticipanteEmail_Sel)),  AV41TFParticipanteEmail_Sel,  AV41TFParticipanteEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEDOCUMENTO",  "Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParticipanteDocumento)),  0,  AV42TFParticipanteDocumento,  AV42TFParticipanteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParticipanteDocumento_Sel)),  AV43TFParticipanteDocumento_Sel,  AV43TFParticipanteDocumento_Sel) ;
         AV62AuxText = ((AV65TFAssinaturaParticipanteTipo_Sels.Count==1) ? "["+((string)AV65TFAssinaturaParticipanteTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTETIPO_SEL",  "Tipo do participante",  !(AV65TFAssinaturaParticipanteTipo_Sels.Count==0),  0,  AV65TFAssinaturaParticipanteTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV62AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV62AuxText, "[Contratado]", "Contratada"), "[Contratante]", "Contratante"), "[Testemunha]", "Testemunha"), "[Sacado]", "Sacado")),  false,  "",  "") ;
         AV62AuxText = ((AV45TFAssinaturaParticipanteStatus_Sels.Count==1) ? "["+((string)AV45TFAssinaturaParticipanteStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTESTATUS_SEL",  "Status",  !(AV45TFAssinaturaParticipanteStatus_Sels.Count==0),  0,  AV45TFAssinaturaParticipanteStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV62AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV62AuxText, "[Pendente]", "Pendente"), "[Assinado]", "Assinado"), "[Recusado]", "Recusado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO",  "Visualizado",  !((DateTime.MinValue==AV46TFAssinaturaParticipanteDataVisualizacao)&&(DateTime.MinValue==AV47TFAssinaturaParticipanteDataVisualizacao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV46TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV46TFAssinaturaParticipanteDataVisualizacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFAssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV47TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV47TFAssinaturaParticipanteDataVisualizacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFAssinaturaParticipanteDataVisualizacao_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTEDATACONCLUSAO",  "Assinatura",  !((DateTime.MinValue==AV51TFAssinaturaParticipanteDataConclusao)&&(DateTime.MinValue==AV52TFAssinaturaParticipanteDataConclusao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV51TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV51TFAssinaturaParticipanteDataConclusao) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFAssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV52TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV52TFAssinaturaParticipanteDataConclusao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV52TFAssinaturaParticipanteDataConclusao_To, "99/99/9999 99:99:99")))) ;
         if ( ! (0==AV63AssinaturaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&ASSINATURAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV63AssinaturaId), 10, 0);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18AssinaturaParticipanteStatus1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Status",  0,  AV18AssinaturaParticipanteStatus1,  StringUtil.Trim( gxdomaindmassinaturaparticipantestatus.getDescription(context,AV18AssinaturaParticipanteStatus1)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ParticipanteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Documento",  AV17DynamicFiltersOperator1,  AV19ParticipanteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ParticipanteDocumento1, "Contém"+" "+AV19ParticipanteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23AssinaturaParticipanteStatus2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Status",  0,  AV23AssinaturaParticipanteStatus2,  StringUtil.Trim( gxdomaindmassinaturaparticipantestatus.getDescription(context,AV23AssinaturaParticipanteStatus2)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ParticipanteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Documento",  AV22DynamicFiltersOperator2,  AV24ParticipanteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24ParticipanteDocumento2, "Contém"+" "+AV24ParticipanteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28AssinaturaParticipanteStatus3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Status",  0,  AV28AssinaturaParticipanteStatus3,  StringUtil.Trim( gxdomaindmassinaturaparticipantestatus.getDescription(context,AV28AssinaturaParticipanteStatus3)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ParticipanteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Participante Documento",  AV27DynamicFiltersOperator3,  AV29ParticipanteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29ParticipanteDocumento3, "Contém"+" "+AV29ParticipanteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV66Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "AssinaturaParticipante";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "AssinaturaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV63AssinaturaId), 10, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_93_5D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturaparticipantestatus3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipantestatus3_Internalname, "Assinatura Participante Status3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipantestatus3, cmbavAssinaturaparticipantestatus3_Internalname, StringUtil.RTrim( AV28AssinaturaParticipanteStatus3), 1, cmbavAssinaturaparticipantestatus3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturaparticipantestatus3.Visible, cmbavAssinaturaparticipantestatus3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavAssinaturaparticipantestatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaParticipanteStatus3);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus3_Internalname, "Values", (string)(cmbavAssinaturaparticipantestatus3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_participantedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipantedocumento3_Internalname, "Participante Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipantedocumento3_Internalname, AV29ParticipanteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV29ParticipanteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipantedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavParticipantedocumento3_Visible, edtavParticipantedocumento3_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcListaAssinantes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_5D2e( true) ;
         }
         else
         {
            wb_table3_93_5D2e( false) ;
         }
      }

      protected void wb_table2_68_5D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturaparticipantestatus2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipantestatus2_Internalname, "Assinatura Participante Status2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipantestatus2, cmbavAssinaturaparticipantestatus2_Internalname, StringUtil.RTrim( AV23AssinaturaParticipanteStatus2), 1, cmbavAssinaturaparticipantestatus2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturaparticipantestatus2.Visible, cmbavAssinaturaparticipantestatus2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavAssinaturaparticipantestatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaParticipanteStatus2);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus2_Internalname, "Values", (string)(cmbavAssinaturaparticipantestatus2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_participantedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipantedocumento2_Internalname, "Participante Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipantedocumento2_Internalname, AV24ParticipanteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV24ParticipanteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipantedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavParticipantedocumento2_Visible, edtavParticipantedocumento2_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcListaAssinantes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcListaAssinantes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_5D2e( true) ;
         }
         else
         {
            wb_table2_68_5D2e( false) ;
         }
      }

      protected void wb_table1_43_5D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturaparticipantestatus1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipantestatus1_Internalname, "Assinatura Participante Status1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipantestatus1, cmbavAssinaturaparticipantestatus1_Internalname, StringUtil.RTrim( AV18AssinaturaParticipanteStatus1), 1, cmbavAssinaturaparticipantestatus1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturaparticipantestatus1.Visible, cmbavAssinaturaparticipantestatus1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_WcListaAssinantes.htm");
            cmbavAssinaturaparticipantestatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaParticipanteStatus1);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantestatus1_Internalname, "Values", (string)(cmbavAssinaturaparticipantestatus1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_participantedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipantedocumento1_Internalname, "Participante Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipantedocumento1_Internalname, AV19ParticipanteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV19ParticipanteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipantedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavParticipantedocumento1_Visible, edtavParticipantedocumento1_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcListaAssinantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcListaAssinantes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcListaAssinantes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_5D2e( true) ;
         }
         else
         {
            wb_table1_43_5D2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV63AssinaturaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV63AssinaturaId", StringUtil.LTrimStr( (decimal)(AV63AssinaturaId), 10, 0));
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
         PA5D2( ) ;
         WS5D2( ) ;
         WE5D2( ) ;
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
         sCtrlAV63AssinaturaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wclistaassinantes", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV63AssinaturaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV63AssinaturaId", StringUtil.LTrimStr( (decimal)(AV63AssinaturaId), 10, 0));
         }
         wcpOAV63AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV63AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV63AssinaturaId != wcpOAV63AssinaturaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV63AssinaturaId = AV63AssinaturaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV63AssinaturaId = cgiGet( sPrefix+"AV63AssinaturaId_CTRL");
         if ( StringUtil.Len( sCtrlAV63AssinaturaId) > 0 )
         {
            AV63AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV63AssinaturaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV63AssinaturaId", StringUtil.LTrimStr( (decimal)(AV63AssinaturaId), 10, 0));
         }
         else
         {
            AV63AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV63AssinaturaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA5D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5D2( ) ;
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
         WS5D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV63AssinaturaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63AssinaturaId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV63AssinaturaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV63AssinaturaId_CTRL", StringUtil.RTrim( sCtrlAV63AssinaturaId));
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
         WE5D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019143841", true, true);
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
         context.AddJavascriptSource("wclistaassinantes.js", "?202561019143841", false, true);
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

      protected void SubsflControlProps_1142( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_114_idx;
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_114_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_114_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_114_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_114_idx;
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL_"+sGXsfl_114_idx;
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO_"+sGXsfl_114_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_114_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_114_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_114_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_114_fel_idx;
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_114_fel_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_114_fel_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_114_fel_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_114_fel_idx;
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL_"+sGXsfl_114_fel_idx;
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO_"+sGXsfl_114_fel_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_114_fel_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_114_fel_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_114_fel_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB5D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_114_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_114_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_114_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'" + sGXsfl_114_idx + "',114)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV61Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDISPLAY.CLICK."+sGXsfl_114_idx+"'",(string)"",(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteNome_Internalname,(string)A248ParticipanteNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteEmail_Internalname,(string)A235ParticipanteEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A235ParticipanteEmail,(string)"",(string)"",(string)"",(string)edtParticipanteEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteDocumento_Internalname,(string)A234ParticipanteDocumento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtParticipanteDocumento_Link,(string)"",(string)"",(string)"",(string)edtParticipanteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_114_idx;
               cmbAssinaturaParticipanteTipo.Name = GXCCtl;
               cmbAssinaturaParticipanteTipo.WebTags = "";
               cmbAssinaturaParticipanteTipo.addItem("Contratado", "Contratada", 0);
               cmbAssinaturaParticipanteTipo.addItem("Contratante", "Contratante", 0);
               cmbAssinaturaParticipanteTipo.addItem("Testemunha", "Testemunha", 0);
               cmbAssinaturaParticipanteTipo.addItem("Sacado", "Sacado", 0);
               if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
               {
                  A247AssinaturaParticipanteTipo = cmbAssinaturaParticipanteTipo.getValidValue(A247AssinaturaParticipanteTipo);
                  n247AssinaturaParticipanteTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAssinaturaParticipanteTipo,(string)cmbAssinaturaParticipanteTipo_Internalname,StringUtil.RTrim( A247AssinaturaParticipanteTipo),(short)1,(string)cmbAssinaturaParticipanteTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteTipo_Internalname, "Values", (string)(cmbAssinaturaParticipanteTipo.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_114_idx;
               cmbAssinaturaParticipanteStatus.Name = GXCCtl;
               cmbAssinaturaParticipanteStatus.WebTags = "";
               cmbAssinaturaParticipanteStatus.addItem("Pendente", "Pendente", 0);
               cmbAssinaturaParticipanteStatus.addItem("Assinado", "Assinado", 0);
               cmbAssinaturaParticipanteStatus.addItem("Recusado", "Recusado", 0);
               if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
               {
                  A353AssinaturaParticipanteStatus = cmbAssinaturaParticipanteStatus.getValidValue(A353AssinaturaParticipanteStatus);
                  n353AssinaturaParticipanteStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAssinaturaParticipanteStatus,(string)cmbAssinaturaParticipanteStatus_Internalname,StringUtil.RTrim( A353AssinaturaParticipanteStatus),(short)1,(string)cmbAssinaturaParticipanteStatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbAssinaturaParticipanteStatus_Columnclass,(string)cmbAssinaturaParticipanteStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbAssinaturaParticipanteStatus.CurrentValue = StringUtil.RTrim( A353AssinaturaParticipanteStatus);
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Values", (string)(cmbAssinaturaParticipanteStatus.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataVisualizacao_Internalname,context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A244AssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataVisualizacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataConclusao_Internalname,context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A245AssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataConclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         /* End function sendrow_1142 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("ASSINATURAPARTICIPANTESTATUS", "Participante Status", 0);
         cmbavDynamicfiltersselector1.addItem("PARTICIPANTEDOCUMENTO", "Participante Documento", 0);
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
         cmbavAssinaturaparticipantestatus1.Name = "vASSINATURAPARTICIPANTESTATUS1";
         cmbavAssinaturaparticipantestatus1.WebTags = "";
         cmbavAssinaturaparticipantestatus1.addItem("", "Todos", 0);
         cmbavAssinaturaparticipantestatus1.addItem("Pendente", "Pendente", 0);
         cmbavAssinaturaparticipantestatus1.addItem("Assinado", "Assinado", 0);
         cmbavAssinaturaparticipantestatus1.addItem("Recusado", "Recusado", 0);
         if ( cmbavAssinaturaparticipantestatus1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("ASSINATURAPARTICIPANTESTATUS", "Participante Status", 0);
         cmbavDynamicfiltersselector2.addItem("PARTICIPANTEDOCUMENTO", "Participante Documento", 0);
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
         cmbavAssinaturaparticipantestatus2.Name = "vASSINATURAPARTICIPANTESTATUS2";
         cmbavAssinaturaparticipantestatus2.WebTags = "";
         cmbavAssinaturaparticipantestatus2.addItem("", "Todos", 0);
         cmbavAssinaturaparticipantestatus2.addItem("Pendente", "Pendente", 0);
         cmbavAssinaturaparticipantestatus2.addItem("Assinado", "Assinado", 0);
         cmbavAssinaturaparticipantestatus2.addItem("Recusado", "Recusado", 0);
         if ( cmbavAssinaturaparticipantestatus2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("ASSINATURAPARTICIPANTESTATUS", "Participante Status", 0);
         cmbavDynamicfiltersselector3.addItem("PARTICIPANTEDOCUMENTO", "Participante Documento", 0);
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
         cmbavAssinaturaparticipantestatus3.Name = "vASSINATURAPARTICIPANTESTATUS3";
         cmbavAssinaturaparticipantestatus3.WebTags = "";
         cmbavAssinaturaparticipantestatus3.addItem("", "Todos", 0);
         cmbavAssinaturaparticipantestatus3.addItem("Pendente", "Pendente", 0);
         cmbavAssinaturaparticipantestatus3.addItem("Assinado", "Assinado", 0);
         cmbavAssinaturaparticipantestatus3.addItem("Recusado", "Recusado", 0);
         if ( cmbavAssinaturaparticipantestatus3.ItemCount > 0 )
         {
         }
         GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_114_idx;
         cmbAssinaturaParticipanteTipo.Name = GXCCtl;
         cmbAssinaturaParticipanteTipo.WebTags = "";
         cmbAssinaturaParticipanteTipo.addItem("Contratado", "Contratada", 0);
         cmbAssinaturaParticipanteTipo.addItem("Contratante", "Contratante", 0);
         cmbAssinaturaParticipanteTipo.addItem("Testemunha", "Testemunha", 0);
         cmbAssinaturaParticipanteTipo.addItem("Sacado", "Sacado", 0);
         if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_114_idx;
         cmbAssinaturaParticipanteStatus.Name = GXCCtl;
         cmbAssinaturaParticipanteStatus.WebTags = "";
         cmbAssinaturaParticipanteStatus.addItem("Pendente", "Pendente", 0);
         cmbAssinaturaParticipanteStatus.addItem("Assinado", "Assinado", 0);
         cmbAssinaturaParticipanteStatus.addItem("Recusado", "Recusado", 0);
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl114( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"114\">") ;
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
            context.SendWebValue( "Participante Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Assinatura Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo do participante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Visualizado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Assinatura") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV61Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A248ParticipanteNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A235ParticipanteEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A234ParticipanteDocumento));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtParticipanteDocumento_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A247AssinaturaParticipanteTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A353AssinaturaParticipanteStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbAssinaturaParticipanteStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbAssinaturaParticipanteStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " ")));
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
         cmbavAssinaturaparticipantestatus1_Internalname = sPrefix+"vASSINATURAPARTICIPANTESTATUS1";
         cellFilter_assinaturaparticipantestatus1_cell_Internalname = sPrefix+"FILTER_ASSINATURAPARTICIPANTESTATUS1_CELL";
         edtavParticipantedocumento1_Internalname = sPrefix+"vPARTICIPANTEDOCUMENTO1";
         cellFilter_participantedocumento1_cell_Internalname = sPrefix+"FILTER_PARTICIPANTEDOCUMENTO1_CELL";
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
         cmbavAssinaturaparticipantestatus2_Internalname = sPrefix+"vASSINATURAPARTICIPANTESTATUS2";
         cellFilter_assinaturaparticipantestatus2_cell_Internalname = sPrefix+"FILTER_ASSINATURAPARTICIPANTESTATUS2_CELL";
         edtavParticipantedocumento2_Internalname = sPrefix+"vPARTICIPANTEDOCUMENTO2";
         cellFilter_participantedocumento2_cell_Internalname = sPrefix+"FILTER_PARTICIPANTEDOCUMENTO2_CELL";
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
         cmbavAssinaturaparticipantestatus3_Internalname = sPrefix+"vASSINATURAPARTICIPANTESTATUS3";
         cellFilter_assinaturaparticipantestatus3_cell_Internalname = sPrefix+"FILTER_ASSINATURAPARTICIPANTESTATUS3_CELL";
         edtavParticipantedocumento3_Internalname = sPrefix+"vPARTICIPANTEDOCUMENTO3";
         cellFilter_participantedocumento3_cell_Internalname = sPrefix+"FILTER_PARTICIPANTEDOCUMENTO3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID";
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID";
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID";
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME";
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL";
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO";
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO";
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS";
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO";
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname = sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETEXT";
         Tfassinaturaparticipantedatavisualizacao_rangepicker_Internalname = sPrefix+"TFASSINATURAPARTICIPANTEDATAVISUALIZACAO_RANGEPICKER";
         divDdo_assinaturaparticipantedatavisualizacaoauxdates_Internalname = sPrefix+"DDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATES";
         edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname = sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETEXT";
         Tfassinaturaparticipantedataconclusao_rangepicker_Internalname = sPrefix+"TFASSINATURAPARTICIPANTEDATACONCLUSAO_RANGEPICKER";
         divDdo_assinaturaparticipantedataconclusaoauxdates_Internalname = sPrefix+"DDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATES";
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
         edtAssinaturaParticipanteDataConclusao_Jsonclick = "";
         edtAssinaturaParticipanteDataVisualizacao_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn";
         cmbAssinaturaParticipanteTipo_Jsonclick = "";
         edtParticipanteDocumento_Jsonclick = "";
         edtParticipanteDocumento_Link = "";
         edtParticipanteEmail_Jsonclick = "";
         edtParticipanteNome_Jsonclick = "";
         edtParticipanteId_Jsonclick = "";
         edtAssinaturaId_Jsonclick = "";
         edtAssinaturaParticipanteId_Jsonclick = "";
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavParticipantedocumento1_Jsonclick = "";
         edtavParticipantedocumento1_Enabled = 1;
         cmbavAssinaturaparticipantestatus1_Jsonclick = "";
         cmbavAssinaturaparticipantestatus1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavParticipantedocumento2_Jsonclick = "";
         edtavParticipantedocumento2_Enabled = 1;
         cmbavAssinaturaparticipantestatus2_Jsonclick = "";
         cmbavAssinaturaparticipantestatus2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavParticipantedocumento3_Jsonclick = "";
         edtavParticipantedocumento3_Enabled = 1;
         cmbavAssinaturaparticipantestatus3_Jsonclick = "";
         cmbavAssinaturaparticipantestatus3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavParticipantedocumento3_Visible = 1;
         cmbavAssinaturaparticipantestatus3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavParticipantedocumento2_Visible = 1;
         cmbavAssinaturaparticipantestatus2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavParticipantedocumento1_Visible = 1;
         cmbavAssinaturaparticipantestatus1.Visible = 1;
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "";
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         edtParticipanteDocumento_Enabled = 0;
         edtParticipanteEmail_Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtAssinaturaParticipanteId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Jsonclick = "";
         edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Jsonclick = "";
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
         Ddo_grid_Datalistproc = "WcListaAssinantesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||Contratado:Contratada,Contratante:Contratante,Testemunha:Testemunha,Sacado:Sacado|Pendente:Pendente,Assinado:Assinado,Recusado:Recusado||";
         Ddo_grid_Allowmultipleselection = "|||T|T||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues|FixedValues||";
         Ddo_grid_Includedatalist = "T|T|T|T|T||";
         Ddo_grid_Filterisrange = "|||||P|P";
         Ddo_grid_Filtertype = "Character|Character|Character|||Date|Date";
         Ddo_grid_Includefilter = "T|T|T|||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|1|6|7";
         Ddo_grid_Columnids = "4:ParticipanteNome|5:ParticipanteEmail|6:ParticipanteDocumento|7:AssinaturaParticipanteTipo|8:AssinaturaParticipanteStatus|9:AssinaturaParticipanteDataVisualizacao|10:AssinaturaParticipanteDataConclusao";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E145D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFAssinaturaParticipanteStatus_SelsJson","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELSJSON","type":"vchar"},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV64TFAssinaturaParticipanteTipo_SelsJson","fld":"vTFASSINATURAPARTICIPANTETIPO_SELSJSON","type":"vchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E265D2","iparms":[{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV61Display","fld":"vDISPLAY","type":"char"},{"av":"edtParticipanteDocumento_Link","ctrl":"PARTICIPANTEDOCUMENTO","prop":"Link"},{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E195D2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E155D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"edtavParticipantedocumento2_Visible","ctrl":"vPARTICIPANTEDOCUMENTO2","prop":"Visible"},{"av":"edtavParticipantedocumento3_Visible","ctrl":"vPARTICIPANTEDOCUMENTO3","prop":"Visible"},{"av":"edtavParticipantedocumento1_Visible","ctrl":"vPARTICIPANTEDOCUMENTO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E205D2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"edtavParticipantedocumento1_Visible","ctrl":"vPARTICIPANTEDOCUMENTO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E215D2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E165D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"edtavParticipantedocumento2_Visible","ctrl":"vPARTICIPANTEDOCUMENTO2","prop":"Visible"},{"av":"edtavParticipantedocumento3_Visible","ctrl":"vPARTICIPANTEDOCUMENTO3","prop":"Visible"},{"av":"edtavParticipantedocumento1_Visible","ctrl":"vPARTICIPANTEDOCUMENTO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E225D2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"edtavParticipantedocumento2_Visible","ctrl":"vPARTICIPANTEDOCUMENTO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E175D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"edtavParticipantedocumento2_Visible","ctrl":"vPARTICIPANTEDOCUMENTO2","prop":"Visible"},{"av":"edtavParticipantedocumento3_Visible","ctrl":"vPARTICIPANTEDOCUMENTO3","prop":"Visible"},{"av":"edtavParticipantedocumento1_Visible","ctrl":"vPARTICIPANTEDOCUMENTO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E235D2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"edtavParticipantedocumento3_Visible","ctrl":"vPARTICIPANTEDOCUMENTO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV64TFAssinaturaParticipanteTipo_SelsJson","fld":"vTFASSINATURAPARTICIPANTETIPO_SELSJSON","type":"vchar"},{"av":"AV44TFAssinaturaParticipanteStatus_SelsJson","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELSJSON","type":"vchar"},{"av":"AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate","fld":"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE","type":"date"},{"av":"AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate","fld":"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE","type":"date"},{"av":"AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo","fld":"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO","type":"date"},{"av":"AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo","fld":"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate","fld":"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE","type":"date"},{"av":"AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo","fld":"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO","type":"date"},{"av":"AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate","fld":"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE","type":"date"},{"av":"AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo","fld":"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO","type":"date"},{"av":"AV44TFAssinaturaParticipanteStatus_SelsJson","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELSJSON","type":"vchar"},{"av":"AV64TFAssinaturaParticipanteTipo_SelsJson","fld":"vTFASSINATURAPARTICIPANTETIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"edtavParticipantedocumento1_Visible","ctrl":"vPARTICIPANTEDOCUMENTO1","prop":"Visible"},{"av":"edtavParticipantedocumento2_Visible","ctrl":"vPARTICIPANTEDOCUMENTO2","prop":"Visible"},{"av":"edtavParticipantedocumento3_Visible","ctrl":"vPARTICIPANTEDOCUMENTO3","prop":"Visible"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDISPLAY.CLICK","""{"handler":"E275D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus1"},{"av":"AV18AssinaturaParticipanteStatus1","fld":"vASSINATURAPARTICIPANTESTATUS1","type":"svchar"},{"av":"AV19ParticipanteDocumento1","fld":"vPARTICIPANTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus2"},{"av":"AV23AssinaturaParticipanteStatus2","fld":"vASSINATURAPARTICIPANTESTATUS2","type":"svchar"},{"av":"AV24ParticipanteDocumento2","fld":"vPARTICIPANTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantestatus3"},{"av":"AV28AssinaturaParticipanteStatus3","fld":"vASSINATURAPARTICIPANTESTATUS3","type":"svchar"},{"av":"AV29ParticipanteDocumento3","fld":"vPARTICIPANTEDOCUMENTO3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV63AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV39TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV40TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV41TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV42TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV43TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV65TFAssinaturaParticipanteTipo_Sels","fld":"vTFASSINATURAPARTICIPANTETIPO_SELS","type":""},{"av":"AV45TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV46TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV52TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDISPLAY.CLICK",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E185D2","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTESTATUS1","""{"handler":"Validv_Assinaturaparticipantestatus1","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTESTATUS2","""{"handler":"Validv_Assinaturaparticipantestatus2","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTESTATUS3","""{"handler":"Validv_Assinaturaparticipantestatus3","iparms":[]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Assinaturaparticipantedataconclusao","iparms":[]}""");
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
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18AssinaturaParticipanteStatus1 = "";
         AV19ParticipanteDocumento1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23AssinaturaParticipanteStatus2 = "";
         AV24ParticipanteDocumento2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28AssinaturaParticipanteStatus3 = "";
         AV29ParticipanteDocumento3 = "";
         AV66Pgmname = "";
         AV38TFParticipanteNome = "";
         AV39TFParticipanteNome_Sel = "";
         AV40TFParticipanteEmail = "";
         AV41TFParticipanteEmail_Sel = "";
         AV42TFParticipanteDocumento = "";
         AV43TFParticipanteDocumento_Sel = "";
         AV65TFAssinaturaParticipanteTipo_Sels = new GxSimpleCollection<string>();
         AV45TFAssinaturaParticipanteStatus_Sels = new GxSimpleCollection<string>();
         AV46TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AV47TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AV51TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AV52TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60GridAppliedFilters = "";
         AV56DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = DateTime.MinValue;
         AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = DateTime.MinValue;
         AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate = DateTime.MinValue;
         AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = DateTime.MinValue;
         AV64TFAssinaturaParticipanteTipo_SelsJson = "";
         AV44TFAssinaturaParticipanteStatus_SelsJson = "";
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
         AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText = "";
         ucTfassinaturaparticipantedatavisualizacao_rangepicker = new GXUserControl();
         AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText = "";
         ucTfassinaturaparticipantedataconclusao_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV61Display = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A247AssinaturaParticipanteTipo = "";
         A353AssinaturaParticipanteStatus = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = new GxSimpleCollection<string>();
         AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = new GxSimpleCollection<string>();
         lV68Wclistaassinantesds_2_filterfulltext = "";
         lV72Wclistaassinantesds_6_participantedocumento1 = "";
         lV77Wclistaassinantesds_11_participantedocumento2 = "";
         lV82Wclistaassinantesds_16_participantedocumento3 = "";
         lV83Wclistaassinantesds_17_tfparticipantenome = "";
         lV85Wclistaassinantesds_19_tfparticipanteemail = "";
         lV87Wclistaassinantesds_21_tfparticipantedocumento = "";
         AV68Wclistaassinantesds_2_filterfulltext = "";
         AV69Wclistaassinantesds_3_dynamicfiltersselector1 = "";
         AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 = "";
         AV72Wclistaassinantesds_6_participantedocumento1 = "";
         AV74Wclistaassinantesds_8_dynamicfiltersselector2 = "";
         AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 = "";
         AV77Wclistaassinantesds_11_participantedocumento2 = "";
         AV79Wclistaassinantesds_13_dynamicfiltersselector3 = "";
         AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 = "";
         AV82Wclistaassinantesds_16_participantedocumento3 = "";
         AV84Wclistaassinantesds_18_tfparticipantenome_sel = "";
         AV83Wclistaassinantesds_17_tfparticipantenome = "";
         AV86Wclistaassinantesds_20_tfparticipanteemail_sel = "";
         AV85Wclistaassinantesds_19_tfparticipanteemail = "";
         AV88Wclistaassinantesds_22_tfparticipantedocumento_sel = "";
         AV87Wclistaassinantesds_21_tfparticipantedocumento = "";
         AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = (DateTime)(DateTime.MinValue);
         AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = (DateTime)(DateTime.MinValue);
         H005D2_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         H005D2_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         H005D2_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         H005D2_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         H005D2_A353AssinaturaParticipanteStatus = new string[] {""} ;
         H005D2_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         H005D2_A247AssinaturaParticipanteTipo = new string[] {""} ;
         H005D2_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         H005D2_A234ParticipanteDocumento = new string[] {""} ;
         H005D2_n234ParticipanteDocumento = new bool[] {false} ;
         H005D2_A235ParticipanteEmail = new string[] {""} ;
         H005D2_n235ParticipanteEmail = new bool[] {false} ;
         H005D2_A248ParticipanteNome = new string[] {""} ;
         H005D2_n248ParticipanteNome = new bool[] {false} ;
         H005D2_A233ParticipanteId = new int[1] ;
         H005D2_n233ParticipanteId = new bool[] {false} ;
         H005D2_A238AssinaturaId = new long[1] ;
         H005D2_n238AssinaturaId = new bool[] {false} ;
         H005D2_A242AssinaturaParticipanteId = new int[1] ;
         H005D3_AGRID_nRecordCount = new long[1] ;
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
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV62AuxText = "";
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
         sCtrlAV63AssinaturaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wclistaassinantes__default(),
            new Object[][] {
                new Object[] {
               H005D2_A245AssinaturaParticipanteDataConclusao, H005D2_n245AssinaturaParticipanteDataConclusao, H005D2_A244AssinaturaParticipanteDataVisualizacao, H005D2_n244AssinaturaParticipanteDataVisualizacao, H005D2_A353AssinaturaParticipanteStatus, H005D2_n353AssinaturaParticipanteStatus, H005D2_A247AssinaturaParticipanteTipo, H005D2_n247AssinaturaParticipanteTipo, H005D2_A234ParticipanteDocumento, H005D2_n234ParticipanteDocumento,
               H005D2_A235ParticipanteEmail, H005D2_n235ParticipanteEmail, H005D2_A248ParticipanteNome, H005D2_n248ParticipanteNome, H005D2_A233ParticipanteId, H005D2_n233ParticipanteId, H005D2_A238AssinaturaId, H005D2_n238AssinaturaId, H005D2_A242AssinaturaParticipanteId
               }
               , new Object[] {
               H005D3_AGRID_nRecordCount
               }
            }
         );
         AV66Pgmname = "WcListaAssinantes";
         /* GeneXus formulas. */
         AV66Pgmname = "WcListaAssinantes";
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV70Wclistaassinantesds_4_dynamicfiltersoperator1 ;
      private short AV75Wclistaassinantesds_9_dynamicfiltersoperator2 ;
      private short AV80Wclistaassinantesds_14_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_114 ;
      private int nGXsfl_114_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A242AssinaturaParticipanteId ;
      private int A233ParticipanteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ;
      private int AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtAssinaturaId_Enabled ;
      private int edtParticipanteId_Enabled ;
      private int edtParticipanteNome_Enabled ;
      private int edtParticipanteEmail_Enabled ;
      private int edtParticipanteDocumento_Enabled ;
      private int edtAssinaturaParticipanteDataVisualizacao_Enabled ;
      private int edtAssinaturaParticipanteDataConclusao_Enabled ;
      private int AV57PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavParticipantedocumento1_Visible ;
      private int edtavParticipantedocumento2_Visible ;
      private int edtavParticipantedocumento3_Visible ;
      private int AV95GXV1 ;
      private int edtavParticipantedocumento3_Enabled ;
      private int edtavParticipantedocumento2_Enabled ;
      private int edtavParticipantedocumento1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV63AssinaturaId ;
      private long wcpOAV63AssinaturaId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long A238AssinaturaId ;
      private long GRID_nCurrentRecord ;
      private long AV67Wclistaassinantesds_1_assinaturaid ;
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
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_114_idx="0001" ;
      private string AV66Pgmname ;
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
      private string divDdo_assinaturaparticipantedatavisualizacaoauxdates_Internalname ;
      private string edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname ;
      private string edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Jsonclick ;
      private string Tfassinaturaparticipantedatavisualizacao_rangepicker_Internalname ;
      private string divDdo_assinaturaparticipantedataconclusaoauxdates_Internalname ;
      private string edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname ;
      private string edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Jsonclick ;
      private string Tfassinaturaparticipantedataconclusao_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV61Display ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string edtAssinaturaId_Internalname ;
      private string edtParticipanteId_Internalname ;
      private string edtParticipanteNome_Internalname ;
      private string edtParticipanteEmail_Internalname ;
      private string edtParticipanteDocumento_Internalname ;
      private string cmbAssinaturaParticipanteTipo_Internalname ;
      private string cmbAssinaturaParticipanteStatus_Internalname ;
      private string edtAssinaturaParticipanteDataVisualizacao_Internalname ;
      private string edtAssinaturaParticipanteDataConclusao_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavAssinaturaparticipantestatus1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavAssinaturaparticipantestatus2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavAssinaturaparticipantestatus3_Internalname ;
      private string edtavParticipantedocumento1_Internalname ;
      private string edtavParticipantedocumento2_Internalname ;
      private string edtavParticipantedocumento3_Internalname ;
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
      private string cmbAssinaturaParticipanteStatus_Columnheaderclass ;
      private string edtParticipanteDocumento_Link ;
      private string cmbAssinaturaParticipanteStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_assinaturaparticipantestatus3_cell_Internalname ;
      private string cmbavAssinaturaparticipantestatus3_Jsonclick ;
      private string cellFilter_participantedocumento3_cell_Internalname ;
      private string edtavParticipantedocumento3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_assinaturaparticipantestatus2_cell_Internalname ;
      private string cmbavAssinaturaparticipantestatus2_Jsonclick ;
      private string cellFilter_participantedocumento2_cell_Internalname ;
      private string edtavParticipantedocumento2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_assinaturaparticipantestatus1_cell_Internalname ;
      private string cmbavAssinaturaparticipantestatus1_Jsonclick ;
      private string cellFilter_participantedocumento1_cell_Internalname ;
      private string edtavParticipantedocumento1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV63AssinaturaId ;
      private string sGXsfl_114_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtAssinaturaId_Jsonclick ;
      private string edtParticipanteId_Jsonclick ;
      private string edtParticipanteNome_Jsonclick ;
      private string edtParticipanteEmail_Jsonclick ;
      private string edtParticipanteDocumento_Jsonclick ;
      private string GXCCtl ;
      private string cmbAssinaturaParticipanteTipo_Jsonclick ;
      private string cmbAssinaturaParticipanteStatus_Jsonclick ;
      private string edtAssinaturaParticipanteDataVisualizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDataConclusao_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV46TFAssinaturaParticipanteDataVisualizacao ;
      private DateTime AV47TFAssinaturaParticipanteDataVisualizacao_To ;
      private DateTime AV51TFAssinaturaParticipanteDataConclusao ;
      private DateTime AV52TFAssinaturaParticipanteDataConclusao_To ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ;
      private DateTime AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ;
      private DateTime AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ;
      private DateTime AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ;
      private DateTime AV48DDO_AssinaturaParticipanteDataVisualizacaoAuxDate ;
      private DateTime AV49DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo ;
      private DateTime AV53DDO_AssinaturaParticipanteDataConclusaoAuxDate ;
      private DateTime AV54DDO_AssinaturaParticipanteDataConclusaoAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
      private bool bGXsfl_114_Refreshing=false ;
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
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV73Wclistaassinantesds_7_dynamicfiltersenabled2 ;
      private bool AV78Wclistaassinantesds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV64TFAssinaturaParticipanteTipo_SelsJson ;
      private string AV44TFAssinaturaParticipanteStatus_SelsJson ;
      private string AV36ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18AssinaturaParticipanteStatus1 ;
      private string AV19ParticipanteDocumento1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23AssinaturaParticipanteStatus2 ;
      private string AV24ParticipanteDocumento2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28AssinaturaParticipanteStatus3 ;
      private string AV29ParticipanteDocumento3 ;
      private string AV38TFParticipanteNome ;
      private string AV39TFParticipanteNome_Sel ;
      private string AV40TFParticipanteEmail ;
      private string AV41TFParticipanteEmail_Sel ;
      private string AV42TFParticipanteDocumento ;
      private string AV43TFParticipanteDocumento_Sel ;
      private string AV60GridAppliedFilters ;
      private string AV50DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText ;
      private string AV55DDO_AssinaturaParticipanteDataConclusaoAuxDateText ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string A247AssinaturaParticipanteTipo ;
      private string A353AssinaturaParticipanteStatus ;
      private string lV68Wclistaassinantesds_2_filterfulltext ;
      private string lV72Wclistaassinantesds_6_participantedocumento1 ;
      private string lV77Wclistaassinantesds_11_participantedocumento2 ;
      private string lV82Wclistaassinantesds_16_participantedocumento3 ;
      private string lV83Wclistaassinantesds_17_tfparticipantenome ;
      private string lV85Wclistaassinantesds_19_tfparticipanteemail ;
      private string lV87Wclistaassinantesds_21_tfparticipantedocumento ;
      private string AV68Wclistaassinantesds_2_filterfulltext ;
      private string AV69Wclistaassinantesds_3_dynamicfiltersselector1 ;
      private string AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 ;
      private string AV72Wclistaassinantesds_6_participantedocumento1 ;
      private string AV74Wclistaassinantesds_8_dynamicfiltersselector2 ;
      private string AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 ;
      private string AV77Wclistaassinantesds_11_participantedocumento2 ;
      private string AV79Wclistaassinantesds_13_dynamicfiltersselector3 ;
      private string AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 ;
      private string AV82Wclistaassinantesds_16_participantedocumento3 ;
      private string AV84Wclistaassinantesds_18_tfparticipantenome_sel ;
      private string AV83Wclistaassinantesds_17_tfparticipantenome ;
      private string AV86Wclistaassinantesds_20_tfparticipanteemail_sel ;
      private string AV85Wclistaassinantesds_19_tfparticipanteemail ;
      private string AV88Wclistaassinantesds_22_tfparticipantedocumento_sel ;
      private string AV87Wclistaassinantesds_21_tfparticipantedocumento ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV62AuxText ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfassinaturaparticipantedatavisualizacao_rangepicker ;
      private GXUserControl ucTfassinaturaparticipantedataconclusao_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavAssinaturaparticipantestatus1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavAssinaturaparticipantestatus2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavAssinaturaparticipantestatus3 ;
      private GXCombobox cmbAssinaturaParticipanteTipo ;
      private GXCombobox cmbAssinaturaParticipanteStatus ;
      private GxSimpleCollection<string> AV65TFAssinaturaParticipanteTipo_Sels ;
      private GxSimpleCollection<string> AV45TFAssinaturaParticipanteStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV56DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ;
      private GxSimpleCollection<string> AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H005D2_A245AssinaturaParticipanteDataConclusao ;
      private bool[] H005D2_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] H005D2_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] H005D2_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] H005D2_A353AssinaturaParticipanteStatus ;
      private bool[] H005D2_n353AssinaturaParticipanteStatus ;
      private string[] H005D2_A247AssinaturaParticipanteTipo ;
      private bool[] H005D2_n247AssinaturaParticipanteTipo ;
      private string[] H005D2_A234ParticipanteDocumento ;
      private bool[] H005D2_n234ParticipanteDocumento ;
      private string[] H005D2_A235ParticipanteEmail ;
      private bool[] H005D2_n235ParticipanteEmail ;
      private string[] H005D2_A248ParticipanteNome ;
      private bool[] H005D2_n248ParticipanteNome ;
      private int[] H005D2_A233ParticipanteId ;
      private bool[] H005D2_n233ParticipanteId ;
      private long[] H005D2_A238AssinaturaId ;
      private bool[] H005D2_n238AssinaturaId ;
      private int[] H005D2_A242AssinaturaParticipanteId ;
      private long[] H005D3_AGRID_nRecordCount ;
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

   public class wclistaassinantes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005D2( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV68Wclistaassinantesds_2_filterfulltext ,
                                             string AV69Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV70Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV72Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV73Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV74Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV75Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV77Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV78Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV79Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV80Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV82Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV84Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV83Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV86Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV85Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV88Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV87Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV67Wclistaassinantesds_1_assinaturaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[33];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteTipo, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.ParticipanteId, T1.AssinaturaId, T1.AssinaturaParticipanteId";
         sFromString = " FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV67Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
         }
         else
         {
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
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV71Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV70Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV72Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV70Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV72Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV76Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV75Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV77Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV75Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV77Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV81Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV80Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV80Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV82Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV83Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV84Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV84Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV85Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV86Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV86Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV87Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV88Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteStatus DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteNome DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteEmail, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteEmail DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteDocumento, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteDocumento DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteTipo, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteTipo DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataVisualizacao DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataConclusao DESC, T1.AssinaturaParticipanteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AssinaturaParticipanteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H005D3( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV68Wclistaassinantesds_2_filterfulltext ,
                                             string AV69Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV71Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV70Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV72Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV73Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV74Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV76Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV75Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV77Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV78Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV79Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV81Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV80Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV82Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV84Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV83Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV86Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV85Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV88Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV87Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV67Wclistaassinantesds_1_assinaturaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[30];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV67Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV68Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV68Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
         }
         else
         {
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
         }
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV71Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV70Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV72Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV70Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV72Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV76Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV75Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV77Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV73Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV75Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV77Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV81Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV80Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV78Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV80Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV82Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV83Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV84Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV84Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV85Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV86Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV86Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV87Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV88Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV89Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int10[29] = 1;
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
                     return conditional_H005D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] );
               case 1 :
                     return conditional_H005D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] );
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
          Object[] prmH005D2;
          prmH005D2 = new Object[] {
          new ParDef("AV67Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV71Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV72Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV72Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV76Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV77Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV77Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV81Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV82Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV82Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV83Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV84Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV85Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV86Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV88Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005D3;
          prmH005D3 = new Object[] {
          new ParDef("AV67Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV71Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV72Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV72Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV76Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV77Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV77Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV81Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV82Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV82Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV83Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV84Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV85Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV86Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV88Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV92Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV93Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV94Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("H005D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((long[]) buf[16])[0] = rslt.getLong(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
