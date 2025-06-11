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
   public class wcassinantes : GXWebComponent
   {
      public wcassinantes( )
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

      public wcassinantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId )
      {
         this.AV62AssinaturaId = aP0_AssinaturaId;
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
         cmbAssinaturaParticipanteStatus = new GXCombobox();
         cmbAssinaturaParticipanteTipo = new GXCombobox();
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
                  AV62AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV62AssinaturaId", StringUtil.LTrimStr( (decimal)(AV62AssinaturaId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV62AssinaturaId});
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
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV62AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
         AV23TFParticipanteNome = GetPar( "TFParticipanteNome");
         AV24TFParticipanteNome_Sel = GetPar( "TFParticipanteNome_Sel");
         AV25TFParticipanteEmail = GetPar( "TFParticipanteEmail");
         AV26TFParticipanteEmail_Sel = GetPar( "TFParticipanteEmail_Sel");
         AV27TFParticipanteDocumento = GetPar( "TFParticipanteDocumento");
         AV28TFParticipanteDocumento_Sel = GetPar( "TFParticipanteDocumento_Sel");
         AV71TFParticipanteRepresentanteNome = GetPar( "TFParticipanteRepresentanteNome");
         AV72TFParticipanteRepresentanteNome_Sel = GetPar( "TFParticipanteRepresentanteNome_Sel");
         AV73TFParticipanteRepresentanteEmail = GetPar( "TFParticipanteRepresentanteEmail");
         AV74TFParticipanteRepresentanteEmail_Sel = GetPar( "TFParticipanteRepresentanteEmail_Sel");
         AV75TFParticipanteRepresentanteDocumento = GetPar( "TFParticipanteRepresentanteDocumento");
         AV76TFParticipanteRepresentanteDocumento_Sel = GetPar( "TFParticipanteRepresentanteDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFAssinaturaParticipanteStatus_Sels);
         AV31TFAssinaturaParticipanteDataVisualizacao = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataVisualizacao"));
         AV32TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataVisualizacao_To"));
         AV36TFAssinaturaParticipanteDataConclusao = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataConclusao"));
         AV37TFAssinaturaParticipanteDataConclusao_To = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaParticipanteDataConclusao_To"));
         AV96Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
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
            PA6D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV96Pgmname = "WcAssinantes";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               edtavReenviaremail_Enabled = 0;
               AssignProp(sPrefix, false, edtavReenviaremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReenviaremail_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               edtavCopylink_Enabled = 0;
               AssignProp(sPrefix, false, edtavCopylink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCopylink_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               edtavEditar_Enabled = 0;
               AssignProp(sPrefix, false, edtavEditar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEditar_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               WS6D2( ) ;
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
         context.AddJavascriptSource("UserControls/UcCopyRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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
            GXEncryptionTmp = "wcassinantes"+UrlEncode(StringUtil.LTrimStr(AV62AssinaturaId,10,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcassinantes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE", context.localUtil.DToC( AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO", context.localUtil.DToC( AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE", context.localUtil.DToC( AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO", context.localUtil.DToC( AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV62AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV62AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME", AV23TFParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME_SEL", AV24TFParticipanteNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEEMAIL", AV25TFParticipanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEEMAIL_SEL", AV26TFParticipanteEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEDOCUMENTO", AV27TFParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEDOCUMENTO_SEL", AV28TFParticipanteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTENOME", AV71TFParticipanteRepresentanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTENOME_SEL", AV72TFParticipanteRepresentanteNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTEEMAIL", AV73TFParticipanteRepresentanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL", AV74TFParticipanteRepresentanteEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO", AV75TFParticipanteRepresentanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL", AV76TFParticipanteRepresentanteDocumento_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFASSINATURAPARTICIPANTESTATUS_SELS", AV30TFAssinaturaParticipanteStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFASSINATURAPARTICIPANTESTATUS_SELS", AV30TFAssinaturaParticipanteStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO", context.localUtil.TToC( AV31TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO", context.localUtil.TToC( AV32TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATACONCLUSAO", context.localUtil.TToC( AV36TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO", context.localUtil.TToC( AV37TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV7HTTPRequest.BaseURL));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseForm6D2( )
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
         return "WcAssinantes" ;
      }

      public override string GetPgmdesc( )
      {
         return " Assinatura Participante" ;
      }

      protected void WB6D0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcassinantes");
               context.AddJavascriptSource("UserControls/UcCopyRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCopy.Render(context, "uccopy", Copy_Internalname, sPrefix+"COPYContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV60DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_titlescategories.SetProperty("GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, sPrefix+"GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_assinaturaparticipantedatavisualizacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname, AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcAssinantes.htm");
            /* User Defined Control */
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.SetProperty("Start Date", AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate);
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.SetProperty("End Date", AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo);
            ucTfassinaturaparticipantedatavisualizacao_rangepicker.Render(context, "wwp.daterangepicker", Tfassinaturaparticipantedatavisualizacao_rangepicker_Internalname, sPrefix+"TFASSINATURAPARTICIPANTEDATAVISUALIZACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_assinaturaparticipantedataconclusaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname, AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcAssinantes.htm");
            /* User Defined Control */
            ucTfassinaturaparticipantedataconclusao_rangepicker.SetProperty("Start Date", AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate);
            ucTfassinaturaparticipantedataconclusao_rangepicker.SetProperty("End Date", AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo);
            ucTfassinaturaparticipantedataconclusao_rangepicker.Render(context, "wwp.daterangepicker", Tfassinaturaparticipantedataconclusao_rangepicker_Internalname, sPrefix+"TFASSINATURAPARTICIPANTEDATACONCLUSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
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

      protected void START6D2( )
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
               STRUP6D0( ) ;
            }
         }
      }

      protected void WS6D2( )
      {
         START6D2( ) ;
         EVT6D2( ) ;
      }

      protected void EVT6D2( )
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
                                 STRUP6D0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E116D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6D0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6D0( ) ;
                              }
                              AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
                              AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
                              AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
                              AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
                              AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
                              AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
                              AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
                              AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
                              AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
                              AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
                              AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
                              AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
                              AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
                              AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
                              AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
                              AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
                              AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
                              AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEDITAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREENVIAREMAIL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREENVIAREMAIL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEDITAR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6D0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV66Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV66Display);
                              AV63ReenviarEmail = cgiGet( edtavReenviaremail_Internalname);
                              AssignAttri(sPrefix, false, edtavReenviaremail_Internalname, AV63ReenviarEmail);
                              AV65CopyLink = cgiGet( edtavCopylink_Internalname);
                              AssignAttri(sPrefix, false, edtavCopylink_Internalname, AV65CopyLink);
                              AV77Editar = cgiGet( edtavEditar_Internalname);
                              AssignAttri(sPrefix, false, edtavEditar_Internalname, AV77Editar);
                              A248ParticipanteNome = cgiGet( edtParticipanteNome_Internalname);
                              n248ParticipanteNome = false;
                              A235ParticipanteEmail = cgiGet( edtParticipanteEmail_Internalname);
                              n235ParticipanteEmail = false;
                              A234ParticipanteDocumento = cgiGet( edtParticipanteDocumento_Internalname);
                              n234ParticipanteDocumento = false;
                              A1002ParticipanteRepresentanteNome = cgiGet( edtParticipanteRepresentanteNome_Internalname);
                              n1002ParticipanteRepresentanteNome = false;
                              A1003ParticipanteRepresentanteEmail = cgiGet( edtParticipanteRepresentanteEmail_Internalname);
                              n1003ParticipanteRepresentanteEmail = false;
                              A1004ParticipanteRepresentanteDocumento = cgiGet( edtParticipanteRepresentanteDocumento_Internalname);
                              n1004ParticipanteRepresentanteDocumento = false;
                              cmbAssinaturaParticipanteStatus.Name = cmbAssinaturaParticipanteStatus_Internalname;
                              cmbAssinaturaParticipanteStatus.CurrentValue = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
                              A353AssinaturaParticipanteStatus = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
                              n353AssinaturaParticipanteStatus = false;
                              A244AssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataVisualizacao_Internalname), 0);
                              n244AssinaturaParticipanteDataVisualizacao = false;
                              A245AssinaturaParticipanteDataConclusao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataConclusao_Internalname), 0);
                              n245AssinaturaParticipanteDataConclusao = false;
                              A246AssinaturaParticipanteKey = StringUtil.StrToGuid( cgiGet( edtAssinaturaParticipanteKey_Internalname));
                              n246AssinaturaParticipanteKey = false;
                              cmbAssinaturaParticipanteTipo.Name = cmbAssinaturaParticipanteTipo_Internalname;
                              cmbAssinaturaParticipanteTipo.CurrentValue = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
                              A247AssinaturaParticipanteTipo = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
                              n247AssinaturaParticipanteTipo = false;
                              A346AssinaturaParticipanteRemoteAddres = cgiGet( edtAssinaturaParticipanteRemoteAddres_Internalname);
                              n346AssinaturaParticipanteRemoteAddres = false;
                              A347AssinaturaParticipanteGeolocalizacao = cgiGet( edtAssinaturaParticipanteGeolocalizacao_Internalname);
                              n347AssinaturaParticipanteGeolocalizacao = false;
                              A348AssinaturaParticipanteDispositivo = cgiGet( edtAssinaturaParticipanteDispositivo_Internalname);
                              n348AssinaturaParticipanteDispositivo = false;
                              A350AssinaturaParticipanteCPF = cgiGet( edtAssinaturaParticipanteCPF_Internalname);
                              n350AssinaturaParticipanteCPF = false;
                              A351AssinaturaParticipanteEmail = cgiGet( edtAssinaturaParticipanteEmail_Internalname);
                              n351AssinaturaParticipanteEmail = false;
                              A352AssinaturaParticipanteNascimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteNascimento_Internalname), 0));
                              n352AssinaturaParticipanteNascimento = false;
                              A354AssinaturaParticipanteLink = cgiGet( edtAssinaturaParticipanteLink_Internalname);
                              n354AssinaturaParticipanteLink = false;
                              A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n233ParticipanteId = false;
                              A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n238AssinaturaId = false;
                              A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
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
                                          E126D2 ();
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
                                          E136D2 ();
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
                                          E146D2 ();
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
                                          E156D2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEDITAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E166D2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VREENVIAREMAIL.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E176D2 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
                                       STRUP6D0( ) ;
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

      protected void WE6D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6D2( ) ;
            }
         }
      }

      protected void PA6D2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcassinantes")), "wcassinantes") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcassinantes")))) ;
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
               GX_FocusControl = edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname;
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
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       long AV62AssinaturaId ,
                                       string AV23TFParticipanteNome ,
                                       string AV24TFParticipanteNome_Sel ,
                                       string AV25TFParticipanteEmail ,
                                       string AV26TFParticipanteEmail_Sel ,
                                       string AV27TFParticipanteDocumento ,
                                       string AV28TFParticipanteDocumento_Sel ,
                                       string AV71TFParticipanteRepresentanteNome ,
                                       string AV72TFParticipanteRepresentanteNome_Sel ,
                                       string AV73TFParticipanteRepresentanteEmail ,
                                       string AV74TFParticipanteRepresentanteEmail_Sel ,
                                       string AV75TFParticipanteRepresentanteDocumento ,
                                       string AV76TFParticipanteRepresentanteDocumento_Sel ,
                                       GxSimpleCollection<string> AV30TFAssinaturaParticipanteStatus_Sels ,
                                       DateTime AV31TFAssinaturaParticipanteDataVisualizacao ,
                                       DateTime AV32TFAssinaturaParticipanteDataVisualizacao_To ,
                                       DateTime AV36TFAssinaturaParticipanteDataConclusao ,
                                       DateTime AV37TFAssinaturaParticipanteDataConclusao_To ,
                                       string AV96Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PARTICIPANTEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ASSINATURAPARTICIPANTELINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A354AssinaturaParticipanteLink, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ASSINATURAPARTICIPANTELINK", A354AssinaturaParticipanteLink);
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
         RF6D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV96Pgmname = "WcAssinantes";
         edtavDisplay_Enabled = 0;
         edtavReenviaremail_Enabled = 0;
         edtavCopylink_Enabled = 0;
         edtavEditar_Enabled = 0;
      }

      protected void RF6D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E136D2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
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
            SubsflControlProps_92( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A353AssinaturaParticipanteStatus ,
                                                 AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                                 AV80Wcassinantesds_3_tfparticipantenome_sel ,
                                                 AV79Wcassinantesds_2_tfparticipantenome ,
                                                 AV82Wcassinantesds_5_tfparticipanteemail_sel ,
                                                 AV81Wcassinantesds_4_tfparticipanteemail ,
                                                 AV84Wcassinantesds_7_tfparticipantedocumento_sel ,
                                                 AV83Wcassinantesds_6_tfparticipantedocumento ,
                                                 AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                                 AV85Wcassinantesds_8_tfparticipanterepresentantenome ,
                                                 AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                                 AV87Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                                 AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                                 AV89Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                                 AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                                 AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                                 AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                                 AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                                 AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                                 A248ParticipanteNome ,
                                                 A235ParticipanteEmail ,
                                                 A234ParticipanteDocumento ,
                                                 A1002ParticipanteRepresentanteNome ,
                                                 A1003ParticipanteRepresentanteEmail ,
                                                 A1004ParticipanteRepresentanteDocumento ,
                                                 A244AssinaturaParticipanteDataVisualizacao ,
                                                 A245AssinaturaParticipanteDataConclusao ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A238AssinaturaId ,
                                                 AV78Wcassinantesds_1_assinaturaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                 TypeConstants.LONG
                                                 }
            });
            lV79Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV79Wcassinantesds_2_tfparticipantenome), "%", "");
            lV81Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV81Wcassinantesds_4_tfparticipanteemail), "%", "");
            lV83Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV83Wcassinantesds_6_tfparticipantedocumento), "%", "");
            lV85Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV85Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
            lV87Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV87Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
            lV89Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV89Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
            /* Using cursor H006D2 */
            pr_default.execute(0, new Object[] {AV78Wcassinantesds_1_assinaturaid, lV79Wcassinantesds_2_tfparticipantenome, AV80Wcassinantesds_3_tfparticipantenome_sel, lV81Wcassinantesds_4_tfparticipanteemail, AV82Wcassinantesds_5_tfparticipanteemail_sel, lV83Wcassinantesds_6_tfparticipantedocumento, AV84Wcassinantesds_7_tfparticipantedocumento_sel, lV85Wcassinantesds_8_tfparticipanterepresentantenome, AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV87Wcassinantesds_10_tfparticipanterepresentanteemail, AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV89Wcassinantesds_12_tfparticipanterepresentantedocumento, AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_9_idx = 1;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A168ClienteId = H006D2_A168ClienteId[0];
               n168ClienteId = H006D2_n168ClienteId[0];
               A242AssinaturaParticipanteId = H006D2_A242AssinaturaParticipanteId[0];
               A238AssinaturaId = H006D2_A238AssinaturaId[0];
               n238AssinaturaId = H006D2_n238AssinaturaId[0];
               A233ParticipanteId = H006D2_A233ParticipanteId[0];
               n233ParticipanteId = H006D2_n233ParticipanteId[0];
               A354AssinaturaParticipanteLink = H006D2_A354AssinaturaParticipanteLink[0];
               n354AssinaturaParticipanteLink = H006D2_n354AssinaturaParticipanteLink[0];
               A352AssinaturaParticipanteNascimento = H006D2_A352AssinaturaParticipanteNascimento[0];
               n352AssinaturaParticipanteNascimento = H006D2_n352AssinaturaParticipanteNascimento[0];
               A351AssinaturaParticipanteEmail = H006D2_A351AssinaturaParticipanteEmail[0];
               n351AssinaturaParticipanteEmail = H006D2_n351AssinaturaParticipanteEmail[0];
               A350AssinaturaParticipanteCPF = H006D2_A350AssinaturaParticipanteCPF[0];
               n350AssinaturaParticipanteCPF = H006D2_n350AssinaturaParticipanteCPF[0];
               A348AssinaturaParticipanteDispositivo = H006D2_A348AssinaturaParticipanteDispositivo[0];
               n348AssinaturaParticipanteDispositivo = H006D2_n348AssinaturaParticipanteDispositivo[0];
               A347AssinaturaParticipanteGeolocalizacao = H006D2_A347AssinaturaParticipanteGeolocalizacao[0];
               n347AssinaturaParticipanteGeolocalizacao = H006D2_n347AssinaturaParticipanteGeolocalizacao[0];
               A346AssinaturaParticipanteRemoteAddres = H006D2_A346AssinaturaParticipanteRemoteAddres[0];
               n346AssinaturaParticipanteRemoteAddres = H006D2_n346AssinaturaParticipanteRemoteAddres[0];
               A247AssinaturaParticipanteTipo = H006D2_A247AssinaturaParticipanteTipo[0];
               n247AssinaturaParticipanteTipo = H006D2_n247AssinaturaParticipanteTipo[0];
               A246AssinaturaParticipanteKey = H006D2_A246AssinaturaParticipanteKey[0];
               n246AssinaturaParticipanteKey = H006D2_n246AssinaturaParticipanteKey[0];
               A245AssinaturaParticipanteDataConclusao = H006D2_A245AssinaturaParticipanteDataConclusao[0];
               n245AssinaturaParticipanteDataConclusao = H006D2_n245AssinaturaParticipanteDataConclusao[0];
               A244AssinaturaParticipanteDataVisualizacao = H006D2_A244AssinaturaParticipanteDataVisualizacao[0];
               n244AssinaturaParticipanteDataVisualizacao = H006D2_n244AssinaturaParticipanteDataVisualizacao[0];
               A353AssinaturaParticipanteStatus = H006D2_A353AssinaturaParticipanteStatus[0];
               n353AssinaturaParticipanteStatus = H006D2_n353AssinaturaParticipanteStatus[0];
               A1004ParticipanteRepresentanteDocumento = H006D2_A1004ParticipanteRepresentanteDocumento[0];
               n1004ParticipanteRepresentanteDocumento = H006D2_n1004ParticipanteRepresentanteDocumento[0];
               A1003ParticipanteRepresentanteEmail = H006D2_A1003ParticipanteRepresentanteEmail[0];
               n1003ParticipanteRepresentanteEmail = H006D2_n1003ParticipanteRepresentanteEmail[0];
               A1002ParticipanteRepresentanteNome = H006D2_A1002ParticipanteRepresentanteNome[0];
               n1002ParticipanteRepresentanteNome = H006D2_n1002ParticipanteRepresentanteNome[0];
               A234ParticipanteDocumento = H006D2_A234ParticipanteDocumento[0];
               n234ParticipanteDocumento = H006D2_n234ParticipanteDocumento[0];
               A235ParticipanteEmail = H006D2_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H006D2_n235ParticipanteEmail[0];
               A248ParticipanteNome = H006D2_A248ParticipanteNome[0];
               n248ParticipanteNome = H006D2_n248ParticipanteNome[0];
               A1004ParticipanteRepresentanteDocumento = H006D2_A1004ParticipanteRepresentanteDocumento[0];
               n1004ParticipanteRepresentanteDocumento = H006D2_n1004ParticipanteRepresentanteDocumento[0];
               A1003ParticipanteRepresentanteEmail = H006D2_A1003ParticipanteRepresentanteEmail[0];
               n1003ParticipanteRepresentanteEmail = H006D2_n1003ParticipanteRepresentanteEmail[0];
               A1002ParticipanteRepresentanteNome = H006D2_A1002ParticipanteRepresentanteNome[0];
               n1002ParticipanteRepresentanteNome = H006D2_n1002ParticipanteRepresentanteNome[0];
               A234ParticipanteDocumento = H006D2_A234ParticipanteDocumento[0];
               n234ParticipanteDocumento = H006D2_n234ParticipanteDocumento[0];
               A235ParticipanteEmail = H006D2_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H006D2_n235ParticipanteEmail[0];
               A248ParticipanteNome = H006D2_A248ParticipanteNome[0];
               n248ParticipanteNome = H006D2_n248ParticipanteNome[0];
               /* Execute user event: Grid.Load */
               E146D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 9;
            WB6D0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6D2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PARTICIPANTEID"+"_"+sGXsfl_9_idx, GetSecureSignedToken( sPrefix+sGXsfl_9_idx, context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ASSINATURAPARTICIPANTELINK"+"_"+sGXsfl_9_idx, GetSecureSignedToken( sPrefix+sGXsfl_9_idx, StringUtil.RTrim( context.localUtil.Format( A354AssinaturaParticipanteLink, "")), context));
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
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV80Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV79Wcassinantesds_2_tfparticipantenome ,
                                              AV82Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV81Wcassinantesds_4_tfparticipanteemail ,
                                              AV84Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV83Wcassinantesds_6_tfparticipantedocumento ,
                                              AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV85Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV87Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV89Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A238AssinaturaId ,
                                              AV78Wcassinantesds_1_assinaturaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG
                                              }
         });
         lV79Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV79Wcassinantesds_2_tfparticipantenome), "%", "");
         lV81Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV81Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV83Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV83Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV85Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV85Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV87Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV87Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV89Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV89Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor H006D3 */
         pr_default.execute(1, new Object[] {AV78Wcassinantesds_1_assinaturaid, lV79Wcassinantesds_2_tfparticipantenome, AV80Wcassinantesds_3_tfparticipantenome_sel, lV81Wcassinantesds_4_tfparticipanteemail, AV82Wcassinantesds_5_tfparticipanteemail_sel, lV83Wcassinantesds_6_tfparticipantedocumento, AV84Wcassinantesds_7_tfparticipantedocumento_sel, lV85Wcassinantesds_8_tfparticipanterepresentantenome, AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV87Wcassinantesds_10_tfparticipanterepresentanteemail, AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV89Wcassinantesds_12_tfparticipanterepresentantedocumento, AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         GRID_nRecordCount = H006D3_AGRID_nRecordCount[0];
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
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV62AssinaturaId, AV23TFParticipanteNome, AV24TFParticipanteNome_Sel, AV25TFParticipanteEmail, AV26TFParticipanteEmail_Sel, AV27TFParticipanteDocumento, AV28TFParticipanteDocumento_Sel, AV71TFParticipanteRepresentanteNome, AV72TFParticipanteRepresentanteNome_Sel, AV73TFParticipanteRepresentanteEmail, AV74TFParticipanteRepresentanteEmail_Sel, AV75TFParticipanteRepresentanteDocumento, AV76TFParticipanteRepresentanteDocumento_Sel, AV30TFAssinaturaParticipanteStatus_Sels, AV31TFAssinaturaParticipanteDataVisualizacao, AV32TFAssinaturaParticipanteDataVisualizacao_To, AV36TFAssinaturaParticipanteDataConclusao, AV37TFAssinaturaParticipanteDataConclusao_To, AV96Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV96Pgmname = "WcAssinantes";
         edtavDisplay_Enabled = 0;
         edtavReenviaremail_Enabled = 0;
         edtavCopylink_Enabled = 0;
         edtavEditar_Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         edtParticipanteEmail_Enabled = 0;
         edtParticipanteDocumento_Enabled = 0;
         edtParticipanteRepresentanteNome_Enabled = 0;
         edtParticipanteRepresentanteEmail_Enabled = 0;
         edtParticipanteRepresentanteDocumento_Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         edtAssinaturaParticipanteKey_Enabled = 0;
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         edtAssinaturaParticipanteRemoteAddres_Enabled = 0;
         edtAssinaturaParticipanteGeolocalizacao_Enabled = 0;
         edtAssinaturaParticipanteDispositivo_Enabled = 0;
         edtAssinaturaParticipanteCPF_Enabled = 0;
         edtAssinaturaParticipanteEmail_Enabled = 0;
         edtAssinaturaParticipanteNascimento_Enabled = 0;
         edtAssinaturaParticipanteLink_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtAssinaturaParticipanteId_Enabled = 0;
         edtClienteId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E126D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV60DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."), 18, MidpointRounding.ToEven));
            AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate", context.localUtil.Format(AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, "99/99/9999"));
            AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATAVISUALIZACAOAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo", context.localUtil.Format(AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, "99/99/9999"));
            AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate", context.localUtil.Format(AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate, "99/99/9999"));
            AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_ASSINATURAPARTICIPANTEDATACONCLUSAOAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo", context.localUtil.Format(AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, "99/99/9999"));
            wcpOAV62AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV62AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Grid_titlescategories_Gridinternalname = cgiGet( sPrefix+"GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( sPrefix+"GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascategories"));
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText = cgiGet( edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText", AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText);
            AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText = cgiGet( edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText", AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
         E126D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E126D2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFASSINATURAPARTICIPANTEDATACONCLUSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, sPrefix, false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
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

      protected void E136D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Columnheaderclass", cmbAssinaturaParticipanteStatus_Columnheaderclass, !bGXsfl_9_Refreshing);
         AV78Wcassinantesds_1_assinaturaid = AV62AssinaturaId;
         AV79Wcassinantesds_2_tfparticipantenome = AV23TFParticipanteNome;
         AV80Wcassinantesds_3_tfparticipantenome_sel = AV24TFParticipanteNome_Sel;
         AV81Wcassinantesds_4_tfparticipanteemail = AV25TFParticipanteEmail;
         AV82Wcassinantesds_5_tfparticipanteemail_sel = AV26TFParticipanteEmail_Sel;
         AV83Wcassinantesds_6_tfparticipantedocumento = AV27TFParticipanteDocumento;
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = AV28TFParticipanteDocumento_Sel;
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = AV71TFParticipanteRepresentanteNome;
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV72TFParticipanteRepresentanteNome_Sel;
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = AV73TFParticipanteRepresentanteEmail;
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV74TFParticipanteRepresentanteEmail_Sel;
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = AV75TFParticipanteRepresentanteDocumento;
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV76TFParticipanteRepresentanteDocumento_Sel;
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV30TFAssinaturaParticipanteStatus_Sels;
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV31TFAssinaturaParticipanteDataVisualizacao;
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV32TFAssinaturaParticipanteDataVisualizacao_To;
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV36TFAssinaturaParticipanteDataConclusao;
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV37TFAssinaturaParticipanteDataConclusao_To;
         /*  Sending Event outputs  */
      }

      protected void E116D2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
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
               AV23TFParticipanteNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFParticipanteNome", AV23TFParticipanteNome);
               AV24TFParticipanteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFParticipanteNome_Sel", AV24TFParticipanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteEmail") == 0 )
            {
               AV25TFParticipanteEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFParticipanteEmail", AV25TFParticipanteEmail);
               AV26TFParticipanteEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFParticipanteEmail_Sel", AV26TFParticipanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteDocumento") == 0 )
            {
               AV27TFParticipanteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFParticipanteDocumento", AV27TFParticipanteDocumento);
               AV28TFParticipanteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFParticipanteDocumento_Sel", AV28TFParticipanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteRepresentanteNome") == 0 )
            {
               AV71TFParticipanteRepresentanteNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV71TFParticipanteRepresentanteNome", AV71TFParticipanteRepresentanteNome);
               AV72TFParticipanteRepresentanteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV72TFParticipanteRepresentanteNome_Sel", AV72TFParticipanteRepresentanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteRepresentanteEmail") == 0 )
            {
               AV73TFParticipanteRepresentanteEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV73TFParticipanteRepresentanteEmail", AV73TFParticipanteRepresentanteEmail);
               AV74TFParticipanteRepresentanteEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV74TFParticipanteRepresentanteEmail_Sel", AV74TFParticipanteRepresentanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParticipanteRepresentanteDocumento") == 0 )
            {
               AV75TFParticipanteRepresentanteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV75TFParticipanteRepresentanteDocumento", AV75TFParticipanteRepresentanteDocumento);
               AV76TFParticipanteRepresentanteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV76TFParticipanteRepresentanteDocumento_Sel", AV76TFParticipanteRepresentanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteStatus") == 0 )
            {
               AV29TFAssinaturaParticipanteStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV29TFAssinaturaParticipanteStatus_SelsJson", AV29TFAssinaturaParticipanteStatus_SelsJson);
               AV30TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV29TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteDataVisualizacao") == 0 )
            {
               AV31TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV31TFAssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( AV31TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
               AV32TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV32TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV32TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV32TFAssinaturaParticipanteDataVisualizacao_To) )
               {
                  AV32TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV32TFAssinaturaParticipanteDataVisualizacao_To)), (short)(DateTimeUtil.Month( AV32TFAssinaturaParticipanteDataVisualizacao_To)), (short)(DateTimeUtil.Day( AV32TFAssinaturaParticipanteDataVisualizacao_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV32TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV32TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipanteDataConclusao") == 0 )
            {
               AV36TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV36TFAssinaturaParticipanteDataConclusao", context.localUtil.TToC( AV36TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
               AV37TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV37TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV37TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV37TFAssinaturaParticipanteDataConclusao_To) )
               {
                  AV37TFAssinaturaParticipanteDataConclusao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV37TFAssinaturaParticipanteDataConclusao_To)), (short)(DateTimeUtil.Month( AV37TFAssinaturaParticipanteDataConclusao_To)), (short)(DateTimeUtil.Day( AV37TFAssinaturaParticipanteDataConclusao_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV37TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV37TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30TFAssinaturaParticipanteStatus_Sels", AV30TFAssinaturaParticipanteStatus_Sels);
      }

      private void E146D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV66Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV66Display);
         AV63ReenviarEmail = "<i class=\"fas fa-envelope-open-text\"></i>";
         AssignAttri(sPrefix, false, edtavReenviaremail_Internalname, AV63ReenviarEmail);
         AV65CopyLink = "<i class=\"fas fa-copy\"></i>";
         AssignAttri(sPrefix, false, edtavCopylink_Internalname, AV65CopyLink);
         AV77Editar = "<i class=\"fas fa-pencil\"></i>";
         AssignAttri(sPrefix, false, edtavEditar_Internalname, AV77Editar);
         if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 )
         {
            edtavEditar_Class = "Attribute";
         }
         else
         {
            edtavEditar_Class = "Invisible";
         }
         if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
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
            wbStart = 9;
         }
         sendrow_92( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E156D2( )
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
      }

      protected void E166D2( )
      {
         /* Editar_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpparticipantecontrato"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A233ParticipanteId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV62AssinaturaId,10,0));
         context.PopUp(formatLink("wpparticipantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV96Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV96Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV96Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV23TFParticipanteNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFParticipanteNome", AV23TFParticipanteNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV24TFParticipanteNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFParticipanteNome_Sel", AV24TFParticipanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV25TFParticipanteEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFParticipanteEmail", AV25TFParticipanteEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV26TFParticipanteEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFParticipanteEmail_Sel", AV26TFParticipanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV27TFParticipanteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFParticipanteDocumento", AV27TFParticipanteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV28TFParticipanteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFParticipanteDocumento_Sel", AV28TFParticipanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTENOME") == 0 )
            {
               AV71TFParticipanteRepresentanteNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV71TFParticipanteRepresentanteNome", AV71TFParticipanteRepresentanteNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTENOME_SEL") == 0 )
            {
               AV72TFParticipanteRepresentanteNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV72TFParticipanteRepresentanteNome_Sel", AV72TFParticipanteRepresentanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEEMAIL") == 0 )
            {
               AV73TFParticipanteRepresentanteEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV73TFParticipanteRepresentanteEmail", AV73TFParticipanteRepresentanteEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEEMAIL_SEL") == 0 )
            {
               AV74TFParticipanteRepresentanteEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV74TFParticipanteRepresentanteEmail_Sel", AV74TFParticipanteRepresentanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEDOCUMENTO") == 0 )
            {
               AV75TFParticipanteRepresentanteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV75TFParticipanteRepresentanteDocumento", AV75TFParticipanteRepresentanteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL") == 0 )
            {
               AV76TFParticipanteRepresentanteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV76TFParticipanteRepresentanteDocumento_Sel", AV76TFParticipanteRepresentanteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTESTATUS_SEL") == 0 )
            {
               AV29TFAssinaturaParticipanteStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFAssinaturaParticipanteStatus_SelsJson", AV29TFAssinaturaParticipanteStatus_SelsJson);
               AV30TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV29TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO") == 0 )
            {
               AV31TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV31TFAssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( AV31TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
               AV32TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV32TFAssinaturaParticipanteDataVisualizacao_To", context.localUtil.TToC( AV32TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " "));
               AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = DateTimeUtil.ResetTime(AV31TFAssinaturaParticipanteDataVisualizacao);
               AssignAttri(sPrefix, false, "AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate", context.localUtil.Format(AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, "99/99/9999"));
               AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = DateTimeUtil.ResetTime(AV32TFAssinaturaParticipanteDataVisualizacao_To);
               AssignAttri(sPrefix, false, "AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo", context.localUtil.Format(AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATACONCLUSAO") == 0 )
            {
               AV36TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV36TFAssinaturaParticipanteDataConclusao", context.localUtil.TToC( AV36TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
               AV37TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV37TFAssinaturaParticipanteDataConclusao_To", context.localUtil.TToC( AV37TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " "));
               AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate = DateTimeUtil.ResetTime(AV36TFAssinaturaParticipanteDataConclusao);
               AssignAttri(sPrefix, false, "AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate", context.localUtil.Format(AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate, "99/99/9999"));
               AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = DateTimeUtil.ResetTime(AV37TFAssinaturaParticipanteDataConclusao_To);
               AssignAttri(sPrefix, false, "AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo", context.localUtil.Format(AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, "99/99/9999"));
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFParticipanteNome_Sel)),  AV24TFParticipanteNome_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFParticipanteEmail_Sel)),  AV26TFParticipanteEmail_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFParticipanteDocumento_Sel)),  AV28TFParticipanteDocumento_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFParticipanteRepresentanteNome_Sel)),  AV72TFParticipanteRepresentanteNome_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFParticipanteRepresentanteEmail_Sel)),  AV74TFParticipanteRepresentanteEmail_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFParticipanteRepresentanteDocumento_Sel)),  AV76TFParticipanteRepresentanteDocumento_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFAssinaturaParticipanteStatus_Sels.Count==0),  AV29TFAssinaturaParticipanteStatus_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFParticipanteNome)),  AV23TFParticipanteNome, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFParticipanteEmail)),  AV25TFParticipanteEmail, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFParticipanteDocumento)),  AV27TFParticipanteDocumento, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFParticipanteRepresentanteNome)),  AV71TFParticipanteRepresentanteNome, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFParticipanteRepresentanteEmail)),  AV73TFParticipanteRepresentanteEmail, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFParticipanteRepresentanteDocumento)),  AV75TFParticipanteRepresentanteDocumento, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"||"+((DateTime.MinValue==AV31TFAssinaturaParticipanteDataVisualizacao) ? "" : context.localUtil.DToC( AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV36TFAssinaturaParticipanteDataConclusao) ? "" : context.localUtil.DToC( AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||||"+((DateTime.MinValue==AV32TFAssinaturaParticipanteDataVisualizacao_To) ? "" : context.localUtil.DToC( AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV37TFAssinaturaParticipanteDataConclusao_To) ? "" : context.localUtil.DToC( AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV96Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTENOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFParticipanteNome)),  0,  AV23TFParticipanteNome,  AV23TFParticipanteNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFParticipanteNome_Sel)),  AV24TFParticipanteNome_Sel,  AV24TFParticipanteNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEEMAIL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFParticipanteEmail)),  0,  AV25TFParticipanteEmail,  AV25TFParticipanteEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFParticipanteEmail_Sel)),  AV26TFParticipanteEmail_Sel,  AV26TFParticipanteEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEDOCUMENTO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFParticipanteDocumento)),  0,  AV27TFParticipanteDocumento,  AV27TFParticipanteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFParticipanteDocumento_Sel)),  AV28TFParticipanteDocumento_Sel,  AV28TFParticipanteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEREPRESENTANTENOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFParticipanteRepresentanteNome)),  0,  AV71TFParticipanteRepresentanteNome,  AV71TFParticipanteRepresentanteNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFParticipanteRepresentanteNome_Sel)),  AV72TFParticipanteRepresentanteNome_Sel,  AV72TFParticipanteRepresentanteNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEREPRESENTANTEEMAIL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFParticipanteRepresentanteEmail)),  0,  AV73TFParticipanteRepresentanteEmail,  AV73TFParticipanteRepresentanteEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFParticipanteRepresentanteEmail_Sel)),  AV74TFParticipanteRepresentanteEmail_Sel,  AV74TFParticipanteRepresentanteEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTEREPRESENTANTEDOCUMENTO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFParticipanteRepresentanteDocumento)),  0,  AV75TFParticipanteRepresentanteDocumento,  AV75TFParticipanteRepresentanteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFParticipanteRepresentanteDocumento_Sel)),  AV76TFParticipanteRepresentanteDocumento_Sel,  AV76TFParticipanteRepresentanteDocumento_Sel) ;
         AV61AuxText = ((AV30TFAssinaturaParticipanteStatus_Sels.Count==1) ? "["+((string)AV30TFAssinaturaParticipanteStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTESTATUS_SEL",  "",  !(AV30TFAssinaturaParticipanteStatus_Sels.Count==0),  0,  AV30TFAssinaturaParticipanteStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV61AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV61AuxText, "[Pendente]", "Pendente"), "[Assinado]", "Assinado"), "[Recusado]", "Recusado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO",  "",  !((DateTime.MinValue==AV31TFAssinaturaParticipanteDataVisualizacao)&&(DateTime.MinValue==AV32TFAssinaturaParticipanteDataVisualizacao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV31TFAssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV31TFAssinaturaParticipanteDataVisualizacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV31TFAssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV32TFAssinaturaParticipanteDataVisualizacao_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV32TFAssinaturaParticipanteDataVisualizacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV32TFAssinaturaParticipanteDataVisualizacao_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTEDATACONCLUSAO",  "",  !((DateTime.MinValue==AV36TFAssinaturaParticipanteDataConclusao)&&(DateTime.MinValue==AV37TFAssinaturaParticipanteDataConclusao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV36TFAssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV36TFAssinaturaParticipanteDataConclusao) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFAssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV37TFAssinaturaParticipanteDataConclusao_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV37TFAssinaturaParticipanteDataConclusao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFAssinaturaParticipanteDataConclusao_To, "99/99/9999 99:99:99")))) ;
         if ( ! (0==AV62AssinaturaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&ASSINATURAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV62AssinaturaId), 10, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV96Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "AssinaturaParticipante";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "AssinaturaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV62AssinaturaId), 10, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E176D2( )
      {
         /* Reenviaremail_Click Routine */
         returnInSub = false;
         AV64BaseUrl = AV7HTTPRequest.BaseURL;
         new prenviacomunicadocontratoparticipante(context).executeSubmit(  A242AssinaturaParticipanteId,  AV64BaseUrl) ;
         GXt_char8 = "E-mail reenviado";
         new message(context ).gxep_sucesso( ref  GXt_char8) ;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV62AssinaturaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV62AssinaturaId", StringUtil.LTrimStr( (decimal)(AV62AssinaturaId), 10, 0));
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
         PA6D2( ) ;
         WS6D2( ) ;
         WE6D2( ) ;
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
         sCtrlAV62AssinaturaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcassinantes", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV62AssinaturaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV62AssinaturaId", StringUtil.LTrimStr( (decimal)(AV62AssinaturaId), 10, 0));
         }
         wcpOAV62AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV62AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV62AssinaturaId != wcpOAV62AssinaturaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV62AssinaturaId = AV62AssinaturaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV62AssinaturaId = cgiGet( sPrefix+"AV62AssinaturaId_CTRL");
         if ( StringUtil.Len( sCtrlAV62AssinaturaId) > 0 )
         {
            AV62AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV62AssinaturaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV62AssinaturaId", StringUtil.LTrimStr( (decimal)(AV62AssinaturaId), 10, 0));
         }
         else
         {
            AV62AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV62AssinaturaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA6D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6D2( ) ;
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
         WS6D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV62AssinaturaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62AssinaturaId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV62AssinaturaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV62AssinaturaId_CTRL", StringUtil.RTrim( sCtrlAV62AssinaturaId));
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
         WE6D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019141876", true, true);
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
         context.AddJavascriptSource("wcassinantes.js", "?202561019141876", false, true);
         context.AddJavascriptSource("UserControls/UcCopyRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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

      protected void SubsflControlProps_92( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_9_idx;
         edtavReenviaremail_Internalname = sPrefix+"vREENVIAREMAIL_"+sGXsfl_9_idx;
         edtavCopylink_Internalname = sPrefix+"vCOPYLINK_"+sGXsfl_9_idx;
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_9_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_9_idx;
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL_"+sGXsfl_9_idx;
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO_"+sGXsfl_9_idx;
         edtParticipanteRepresentanteNome_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTENOME_"+sGXsfl_9_idx;
         edtParticipanteRepresentanteEmail_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEEMAIL_"+sGXsfl_9_idx;
         edtParticipanteRepresentanteDocumento_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEDOCUMENTO_"+sGXsfl_9_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY_"+sGXsfl_9_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteRemoteAddres_Internalname = sPrefix+"ASSINATURAPARTICIPANTEREMOTEADDRES_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteGeolocalizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEGEOLOCALIZACAO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteDispositivo_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDISPOSITIVO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteCPF_Internalname = sPrefix+"ASSINATURAPARTICIPANTECPF_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteEmail_Internalname = sPrefix+"ASSINATURAPARTICIPANTEEMAIL_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteNascimento_Internalname = sPrefix+"ASSINATURAPARTICIPANTENASCIMENTO_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteLink_Internalname = sPrefix+"ASSINATURAPARTICIPANTELINK_"+sGXsfl_9_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_9_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_9_idx;
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_9_idx;
         edtClienteId_Internalname = sPrefix+"CLIENTEID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_9_fel_idx;
         edtavReenviaremail_Internalname = sPrefix+"vREENVIAREMAIL_"+sGXsfl_9_fel_idx;
         edtavCopylink_Internalname = sPrefix+"vCOPYLINK_"+sGXsfl_9_fel_idx;
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_9_fel_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_9_fel_idx;
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL_"+sGXsfl_9_fel_idx;
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO_"+sGXsfl_9_fel_idx;
         edtParticipanteRepresentanteNome_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTENOME_"+sGXsfl_9_fel_idx;
         edtParticipanteRepresentanteEmail_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEEMAIL_"+sGXsfl_9_fel_idx;
         edtParticipanteRepresentanteDocumento_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEDOCUMENTO_"+sGXsfl_9_fel_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY_"+sGXsfl_9_fel_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteRemoteAddres_Internalname = sPrefix+"ASSINATURAPARTICIPANTEREMOTEADDRES_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteGeolocalizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEGEOLOCALIZACAO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteDispositivo_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDISPOSITIVO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteCPF_Internalname = sPrefix+"ASSINATURAPARTICIPANTECPF_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteEmail_Internalname = sPrefix+"ASSINATURAPARTICIPANTEEMAIL_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteNascimento_Internalname = sPrefix+"ASSINATURAPARTICIPANTENASCIMENTO_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteLink_Internalname = sPrefix+"ASSINATURAPARTICIPANTELINK_"+sGXsfl_9_fel_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_9_fel_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_9_fel_idx;
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_9_fel_idx;
         edtClienteId_Internalname = sPrefix+"CLIENTEID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB6D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_9_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV66Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,10);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDISPLAY.CLICK."+sGXsfl_9_idx+"'",(string)"",(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReenviaremail_Internalname,StringUtil.RTrim( AV63ReenviarEmail),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVREENVIAREMAIL.CLICK."+sGXsfl_9_idx+"'",(string)"",(string)"",(string)"Reenviar e-mail",(string)"",(string)edtavReenviaremail_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavReenviaremail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCopylink_Internalname,StringUtil.RTrim( AV65CopyLink),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,12);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+"e186d2_client"+"'",(string)"",(string)"",(string)"Copiar",(string)"",(string)edtavCopylink_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavCopylink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = edtavEditar_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEditar_Internalname,StringUtil.RTrim( AV77Editar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVEDITAR.CLICK."+sGXsfl_9_idx+"'",(string)"",(string)"",(string)"Editar",(string)"",(string)edtavEditar_Jsonclick,(short)5,(string)edtavEditar_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavEditar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteNome_Internalname,(string)A248ParticipanteNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteEmail_Internalname,(string)A235ParticipanteEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A235ParticipanteEmail,(string)"",(string)"",(string)"",(string)edtParticipanteEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteDocumento_Internalname,(string)A234ParticipanteDocumento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteRepresentanteNome_Internalname,(string)A1002ParticipanteRepresentanteNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteRepresentanteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteRepresentanteEmail_Internalname,(string)A1003ParticipanteRepresentanteEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A1003ParticipanteRepresentanteEmail,(string)"",(string)"",(string)"",(string)edtParticipanteRepresentanteEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteRepresentanteDocumento_Internalname,(string)A1004ParticipanteRepresentanteDocumento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteRepresentanteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_9_idx;
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
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Values", (string)(cmbAssinaturaParticipanteStatus.ToJavascriptSource()), !bGXsfl_9_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataVisualizacao_Internalname,context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A244AssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataVisualizacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataConclusao_Internalname,context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A245AssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataConclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteKey_Internalname,A246AssinaturaParticipanteKey.ToString(),A246AssinaturaParticipanteKey.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)9,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_9_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAssinaturaParticipanteTipo,(string)cmbAssinaturaParticipanteTipo_Internalname,StringUtil.RTrim( A247AssinaturaParticipanteTipo),(short)1,(string)cmbAssinaturaParticipanteTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteTipo_Internalname, "Values", (string)(cmbAssinaturaParticipanteTipo.ToJavascriptSource()), !bGXsfl_9_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteRemoteAddres_Internalname,(string)A346AssinaturaParticipanteRemoteAddres,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteRemoteAddres_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteGeolocalizacao_Internalname,(string)A347AssinaturaParticipanteGeolocalizacao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteGeolocalizacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDispositivo_Internalname,(string)A348AssinaturaParticipanteDispositivo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDispositivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteCPF_Internalname,(string)A350AssinaturaParticipanteCPF,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteEmail_Internalname,(string)A351AssinaturaParticipanteEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A351AssinaturaParticipanteEmail,(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteNascimento_Internalname,context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"),context.localUtil.Format( A352AssinaturaParticipanteNascimento, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteNascimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteLink_Internalname,(string)A354AssinaturaParticipanteLink,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteLink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)256,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes6D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_9_idx;
         cmbAssinaturaParticipanteStatus.Name = GXCCtl;
         cmbAssinaturaParticipanteStatus.WebTags = "";
         cmbAssinaturaParticipanteStatus.addItem("Pendente", "Pendente", 0);
         cmbAssinaturaParticipanteStatus.addItem("Assinado", "Assinado", 0);
         cmbAssinaturaParticipanteStatus.addItem("Recusado", "Recusado", 0);
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
         }
         GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_9_idx;
         cmbAssinaturaParticipanteTipo.Name = GXCCtl;
         cmbAssinaturaParticipanteTipo.WebTags = "";
         cmbAssinaturaParticipanteTipo.addItem("Contratado", "Contratada", 0);
         cmbAssinaturaParticipanteTipo.addItem("Contratante", "Contratante", 0);
         cmbAssinaturaParticipanteTipo.addItem("Testemunha", "Testemunha", 0);
         cmbAssinaturaParticipanteTipo.addItem("Sacado", "Sacado", 0);
         if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavEditar_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Visualização") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Conclusão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo do participante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Remote Addres") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Geolocalizacao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Dispositivo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Nascimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Link") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Assinatura Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV66Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV63ReenviarEmail)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReenviaremail_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV65CopyLink)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCopylink_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV77Editar)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavEditar_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEditar_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A248ParticipanteNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A235ParticipanteEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A234ParticipanteDocumento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1002ParticipanteRepresentanteNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1003ParticipanteRepresentanteEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1004ParticipanteRepresentanteDocumento));
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
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A246AssinaturaParticipanteKey.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A247AssinaturaParticipanteTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A346AssinaturaParticipanteRemoteAddres));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A347AssinaturaParticipanteGeolocalizacao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A348AssinaturaParticipanteDispositivo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A350AssinaturaParticipanteCPF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A351AssinaturaParticipanteEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A354AssinaturaParticipanteLink));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
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
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtavReenviaremail_Internalname = sPrefix+"vREENVIAREMAIL";
         edtavCopylink_Internalname = sPrefix+"vCOPYLINK";
         edtavEditar_Internalname = sPrefix+"vEDITAR";
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME";
         edtParticipanteEmail_Internalname = sPrefix+"PARTICIPANTEEMAIL";
         edtParticipanteDocumento_Internalname = sPrefix+"PARTICIPANTEDOCUMENTO";
         edtParticipanteRepresentanteNome_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTENOME";
         edtParticipanteRepresentanteEmail_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEEMAIL";
         edtParticipanteRepresentanteDocumento_Internalname = sPrefix+"PARTICIPANTEREPRESENTANTEDOCUMENTO";
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS";
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO";
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO";
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY";
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO";
         edtAssinaturaParticipanteRemoteAddres_Internalname = sPrefix+"ASSINATURAPARTICIPANTEREMOTEADDRES";
         edtAssinaturaParticipanteGeolocalizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEGEOLOCALIZACAO";
         edtAssinaturaParticipanteDispositivo_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDISPOSITIVO";
         edtAssinaturaParticipanteCPF_Internalname = sPrefix+"ASSINATURAPARTICIPANTECPF";
         edtAssinaturaParticipanteEmail_Internalname = sPrefix+"ASSINATURAPARTICIPANTEEMAIL";
         edtAssinaturaParticipanteNascimento_Internalname = sPrefix+"ASSINATURAPARTICIPANTENASCIMENTO";
         edtAssinaturaParticipanteLink_Internalname = sPrefix+"ASSINATURAPARTICIPANTELINK";
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID";
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID";
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         Copy_Internalname = sPrefix+"COPY";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_titlescategories_Internalname = sPrefix+"GRID_TITLESCATEGORIES";
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
         edtClienteId_Jsonclick = "";
         edtAssinaturaParticipanteId_Jsonclick = "";
         edtAssinaturaId_Jsonclick = "";
         edtParticipanteId_Jsonclick = "";
         edtAssinaturaParticipanteLink_Jsonclick = "";
         edtAssinaturaParticipanteNascimento_Jsonclick = "";
         edtAssinaturaParticipanteEmail_Jsonclick = "";
         edtAssinaturaParticipanteCPF_Jsonclick = "";
         edtAssinaturaParticipanteDispositivo_Jsonclick = "";
         edtAssinaturaParticipanteGeolocalizacao_Jsonclick = "";
         edtAssinaturaParticipanteRemoteAddres_Jsonclick = "";
         cmbAssinaturaParticipanteTipo_Jsonclick = "";
         edtAssinaturaParticipanteKey_Jsonclick = "";
         edtAssinaturaParticipanteDataConclusao_Jsonclick = "";
         edtAssinaturaParticipanteDataVisualizacao_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn";
         edtParticipanteRepresentanteDocumento_Jsonclick = "";
         edtParticipanteRepresentanteEmail_Jsonclick = "";
         edtParticipanteRepresentanteNome_Jsonclick = "";
         edtParticipanteDocumento_Jsonclick = "";
         edtParticipanteEmail_Jsonclick = "";
         edtParticipanteNome_Jsonclick = "";
         edtavEditar_Jsonclick = "";
         edtavEditar_Class = "Attribute";
         edtavEditar_Enabled = 1;
         edtavCopylink_Jsonclick = "";
         edtavCopylink_Enabled = 1;
         edtavReenviaremail_Jsonclick = "";
         edtavReenviaremail_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Enabled = 1;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "";
         edtClienteId_Enabled = 0;
         edtAssinaturaParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtAssinaturaParticipanteLink_Enabled = 0;
         edtAssinaturaParticipanteNascimento_Enabled = 0;
         edtAssinaturaParticipanteEmail_Enabled = 0;
         edtAssinaturaParticipanteCPF_Enabled = 0;
         edtAssinaturaParticipanteDispositivo_Enabled = 0;
         edtAssinaturaParticipanteGeolocalizacao_Enabled = 0;
         edtAssinaturaParticipanteRemoteAddres_Enabled = 0;
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         edtAssinaturaParticipanteKey_Enabled = 0;
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         edtParticipanteRepresentanteDocumento_Enabled = 0;
         edtParticipanteRepresentanteEmail_Enabled = 0;
         edtParticipanteRepresentanteNome_Enabled = 0;
         edtParticipanteDocumento_Enabled = 0;
         edtParticipanteEmail_Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_assinaturaparticipantedataconclusaoauxdatetext_Jsonclick = "";
         edtavDdo_assinaturaparticipantedatavisualizacaoauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = ";;;;Participante;Participante;Participante;Representante;Representante;Representante;;;;;;;;;;;;;;;;";
         Ddo_grid_Datalistproc = "WcAssinantesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||Pendente:Pendente,Assinado:Assinado,Recusado:Recusado||";
         Ddo_grid_Allowmultipleselection = "||||||T||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues||";
         Ddo_grid_Includedatalist = "T|T|T|T|T|T|T||";
         Ddo_grid_Filterisrange = "|||||||P|P";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character||Date|Date";
         Ddo_grid_Includefilter = "T|T|T|T|T|T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "4:ParticipanteNome|5:ParticipanteEmail|6:ParticipanteDocumento|7:ParticipanteRepresentanteNome|8:ParticipanteRepresentanteEmail|9:ParticipanteRepresentanteDocumento|10:AssinaturaParticipanteStatus|11:AssinaturaParticipanteDataVisualizacao|12:AssinaturaParticipanteDataConclusao";
         Ddo_grid_Gridinternalname = "";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E116D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV29TFAssinaturaParticipanteStatus_SelsJson","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELSJSON","type":"vchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E146D2","iparms":[{"av":"cmbAssinaturaParticipanteStatus"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV66Display","fld":"vDISPLAY","type":"char"},{"av":"AV63ReenviarEmail","fld":"vREENVIAREMAIL","type":"char"},{"av":"AV65CopyLink","fld":"vCOPYLINK","type":"char"},{"av":"AV77Editar","fld":"vEDITAR","type":"char"},{"av":"edtavEditar_Class","ctrl":"vEDITAR","prop":"Class"},{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("VDISPLAY.CLICK","""{"handler":"E156D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VDISPLAY.CLICK",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("VEDITAR.CLICK","""{"handler":"E166D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VEDITAR.CLICK",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("VREENVIAREMAIL.CLICK","""{"handler":"E176D2","iparms":[{"av":"AV7HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VREENVIAREMAIL.CLICK",""","oparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VCOPYLINK.CLICK","""{"handler":"E186D2","iparms":[{"av":"A354AssinaturaParticipanteLink","fld":"ASSINATURAPARTICIPANTELINK","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV62AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV23TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV24TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV25TFParticipanteEmail","fld":"vTFPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV26TFParticipanteEmail_Sel","fld":"vTFPARTICIPANTEEMAIL_SEL","type":"svchar"},{"av":"AV27TFParticipanteDocumento","fld":"vTFPARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"AV28TFParticipanteDocumento_Sel","fld":"vTFPARTICIPANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV71TFParticipanteRepresentanteNome","fld":"vTFPARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"AV72TFParticipanteRepresentanteNome_Sel","fld":"vTFPARTICIPANTEREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV73TFParticipanteRepresentanteEmail","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV74TFParticipanteRepresentanteEmail_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV75TFParticipanteRepresentanteDocumento","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"},{"av":"AV76TFParticipanteRepresentanteDocumento_Sel","fld":"vTFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV30TFAssinaturaParticipanteStatus_Sels","fld":"vTFASSINATURAPARTICIPANTESTATUS_SELS","type":""},{"av":"AV31TFAssinaturaParticipanteDataVisualizacao","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV32TFAssinaturaParticipanteDataVisualizacao_To","fld":"vTFASSINATURAPARTICIPANTEDATAVISUALIZACAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV36TFAssinaturaParticipanteDataConclusao","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFAssinaturaParticipanteDataConclusao_To","fld":"vTFASSINATURAPARTICIPANTEDATACONCLUSAO_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Clienteid","iparms":[]}""");
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
         AV7HTTPRequest = new GxHttpRequest( context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV23TFParticipanteNome = "";
         AV24TFParticipanteNome_Sel = "";
         AV25TFParticipanteEmail = "";
         AV26TFParticipanteEmail_Sel = "";
         AV27TFParticipanteDocumento = "";
         AV28TFParticipanteDocumento_Sel = "";
         AV71TFParticipanteRepresentanteNome = "";
         AV72TFParticipanteRepresentanteNome_Sel = "";
         AV73TFParticipanteRepresentanteEmail = "";
         AV74TFParticipanteRepresentanteEmail_Sel = "";
         AV75TFParticipanteRepresentanteDocumento = "";
         AV76TFParticipanteRepresentanteDocumento_Sel = "";
         AV30TFAssinaturaParticipanteStatus_Sels = new GxSimpleCollection<string>();
         AV31TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AV32TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AV36TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AV37TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AV96Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV60DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate = DateTime.MinValue;
         AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo = DateTime.MinValue;
         AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate = DateTime.MinValue;
         AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucCopy = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText = "";
         ucTfassinaturaparticipantedatavisualizacao_rangepicker = new GXUserControl();
         AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText = "";
         ucTfassinaturaparticipantedataconclusao_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV79Wcassinantesds_2_tfparticipantenome = "";
         AV80Wcassinantesds_3_tfparticipantenome_sel = "";
         AV81Wcassinantesds_4_tfparticipanteemail = "";
         AV82Wcassinantesds_5_tfparticipanteemail_sel = "";
         AV83Wcassinantesds_6_tfparticipantedocumento = "";
         AV84Wcassinantesds_7_tfparticipantedocumento_sel = "";
         AV85Wcassinantesds_8_tfparticipanterepresentantenome = "";
         AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel = "";
         AV87Wcassinantesds_10_tfparticipanterepresentanteemail = "";
         AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel = "";
         AV89Wcassinantesds_12_tfparticipanterepresentantedocumento = "";
         AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = "";
         AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels = new GxSimpleCollection<string>();
         AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = (DateTime)(DateTime.MinValue);
         AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = (DateTime)(DateTime.MinValue);
         AV66Display = "";
         AV63ReenviarEmail = "";
         AV65CopyLink = "";
         AV77Editar = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A1002ParticipanteRepresentanteNome = "";
         A1003ParticipanteRepresentanteEmail = "";
         A1004ParticipanteRepresentanteDocumento = "";
         A353AssinaturaParticipanteStatus = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A246AssinaturaParticipanteKey = Guid.Empty;
         A247AssinaturaParticipanteTipo = "";
         A346AssinaturaParticipanteRemoteAddres = "";
         A347AssinaturaParticipanteGeolocalizacao = "";
         A348AssinaturaParticipanteDispositivo = "";
         A350AssinaturaParticipanteCPF = "";
         A351AssinaturaParticipanteEmail = "";
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         A354AssinaturaParticipanteLink = "";
         GXDecQS = "";
         lV79Wcassinantesds_2_tfparticipantenome = "";
         lV81Wcassinantesds_4_tfparticipanteemail = "";
         lV83Wcassinantesds_6_tfparticipantedocumento = "";
         lV85Wcassinantesds_8_tfparticipanterepresentantenome = "";
         lV87Wcassinantesds_10_tfparticipanterepresentanteemail = "";
         lV89Wcassinantesds_12_tfparticipanterepresentantedocumento = "";
         H006D2_A168ClienteId = new int[1] ;
         H006D2_n168ClienteId = new bool[] {false} ;
         H006D2_A242AssinaturaParticipanteId = new int[1] ;
         H006D2_A238AssinaturaId = new long[1] ;
         H006D2_n238AssinaturaId = new bool[] {false} ;
         H006D2_A233ParticipanteId = new int[1] ;
         H006D2_n233ParticipanteId = new bool[] {false} ;
         H006D2_A354AssinaturaParticipanteLink = new string[] {""} ;
         H006D2_n354AssinaturaParticipanteLink = new bool[] {false} ;
         H006D2_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         H006D2_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         H006D2_A351AssinaturaParticipanteEmail = new string[] {""} ;
         H006D2_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         H006D2_A350AssinaturaParticipanteCPF = new string[] {""} ;
         H006D2_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         H006D2_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         H006D2_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         H006D2_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         H006D2_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         H006D2_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         H006D2_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         H006D2_A247AssinaturaParticipanteTipo = new string[] {""} ;
         H006D2_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         H006D2_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         H006D2_n246AssinaturaParticipanteKey = new bool[] {false} ;
         H006D2_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         H006D2_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         H006D2_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         H006D2_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         H006D2_A353AssinaturaParticipanteStatus = new string[] {""} ;
         H006D2_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         H006D2_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         H006D2_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         H006D2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         H006D2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         H006D2_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         H006D2_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         H006D2_A234ParticipanteDocumento = new string[] {""} ;
         H006D2_n234ParticipanteDocumento = new bool[] {false} ;
         H006D2_A235ParticipanteEmail = new string[] {""} ;
         H006D2_n235ParticipanteEmail = new bool[] {false} ;
         H006D2_A248ParticipanteNome = new string[] {""} ;
         H006D2_n248ParticipanteNome = new bool[] {false} ;
         H006D3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29TFAssinaturaParticipanteStatus_SelsJson = "";
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         AV61AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV64BaseUrl = "";
         GXt_char8 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV62AssinaturaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcassinantes__default(),
            new Object[][] {
                new Object[] {
               H006D2_A168ClienteId, H006D2_n168ClienteId, H006D2_A242AssinaturaParticipanteId, H006D2_A238AssinaturaId, H006D2_n238AssinaturaId, H006D2_A233ParticipanteId, H006D2_n233ParticipanteId, H006D2_A354AssinaturaParticipanteLink, H006D2_n354AssinaturaParticipanteLink, H006D2_A352AssinaturaParticipanteNascimento,
               H006D2_n352AssinaturaParticipanteNascimento, H006D2_A351AssinaturaParticipanteEmail, H006D2_n351AssinaturaParticipanteEmail, H006D2_A350AssinaturaParticipanteCPF, H006D2_n350AssinaturaParticipanteCPF, H006D2_A348AssinaturaParticipanteDispositivo, H006D2_n348AssinaturaParticipanteDispositivo, H006D2_A347AssinaturaParticipanteGeolocalizacao, H006D2_n347AssinaturaParticipanteGeolocalizacao, H006D2_A346AssinaturaParticipanteRemoteAddres,
               H006D2_n346AssinaturaParticipanteRemoteAddres, H006D2_A247AssinaturaParticipanteTipo, H006D2_n247AssinaturaParticipanteTipo, H006D2_A246AssinaturaParticipanteKey, H006D2_n246AssinaturaParticipanteKey, H006D2_A245AssinaturaParticipanteDataConclusao, H006D2_n245AssinaturaParticipanteDataConclusao, H006D2_A244AssinaturaParticipanteDataVisualizacao, H006D2_n244AssinaturaParticipanteDataVisualizacao, H006D2_A353AssinaturaParticipanteStatus,
               H006D2_n353AssinaturaParticipanteStatus, H006D2_A1004ParticipanteRepresentanteDocumento, H006D2_n1004ParticipanteRepresentanteDocumento, H006D2_A1003ParticipanteRepresentanteEmail, H006D2_n1003ParticipanteRepresentanteEmail, H006D2_A1002ParticipanteRepresentanteNome, H006D2_n1002ParticipanteRepresentanteNome, H006D2_A234ParticipanteDocumento, H006D2_n234ParticipanteDocumento, H006D2_A235ParticipanteEmail,
               H006D2_n235ParticipanteEmail, H006D2_A248ParticipanteNome, H006D2_n248ParticipanteNome
               }
               , new Object[] {
               H006D3_AGRID_nRecordCount
               }
            }
         );
         AV96Pgmname = "WcAssinantes";
         /* GeneXus formulas. */
         AV96Pgmname = "WcAssinantes";
         edtavDisplay_Enabled = 0;
         edtavReenviaremail_Enabled = 0;
         edtavCopylink_Enabled = 0;
         edtavEditar_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int edtavReenviaremail_Enabled ;
      private int edtavCopylink_Enabled ;
      private int edtavEditar_Enabled ;
      private int A233ParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ;
      private int edtParticipanteNome_Enabled ;
      private int edtParticipanteEmail_Enabled ;
      private int edtParticipanteDocumento_Enabled ;
      private int edtParticipanteRepresentanteNome_Enabled ;
      private int edtParticipanteRepresentanteEmail_Enabled ;
      private int edtParticipanteRepresentanteDocumento_Enabled ;
      private int edtAssinaturaParticipanteDataVisualizacao_Enabled ;
      private int edtAssinaturaParticipanteDataConclusao_Enabled ;
      private int edtAssinaturaParticipanteKey_Enabled ;
      private int edtAssinaturaParticipanteRemoteAddres_Enabled ;
      private int edtAssinaturaParticipanteGeolocalizacao_Enabled ;
      private int edtAssinaturaParticipanteDispositivo_Enabled ;
      private int edtAssinaturaParticipanteCPF_Enabled ;
      private int edtAssinaturaParticipanteEmail_Enabled ;
      private int edtAssinaturaParticipanteNascimento_Enabled ;
      private int edtAssinaturaParticipanteLink_Enabled ;
      private int edtParticipanteId_Enabled ;
      private int edtAssinaturaId_Enabled ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtClienteId_Enabled ;
      private int AV97GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV62AssinaturaId ;
      private long wcpOAV62AssinaturaId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV78Wcassinantesds_1_assinaturaid ;
      private long A238AssinaturaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string AV96Pgmname ;
      private string edtavDisplay_Internalname ;
      private string edtavReenviaremail_Internalname ;
      private string edtavCopylink_Internalname ;
      private string edtavEditar_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Copy_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_assinaturaparticipantedatavisualizacaoauxdates_Internalname ;
      private string TempTags ;
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
      private string AV66Display ;
      private string AV63ReenviarEmail ;
      private string AV65CopyLink ;
      private string AV77Editar ;
      private string edtParticipanteNome_Internalname ;
      private string edtParticipanteEmail_Internalname ;
      private string edtParticipanteDocumento_Internalname ;
      private string edtParticipanteRepresentanteNome_Internalname ;
      private string edtParticipanteRepresentanteEmail_Internalname ;
      private string edtParticipanteRepresentanteDocumento_Internalname ;
      private string cmbAssinaturaParticipanteStatus_Internalname ;
      private string edtAssinaturaParticipanteDataVisualizacao_Internalname ;
      private string edtAssinaturaParticipanteDataConclusao_Internalname ;
      private string edtAssinaturaParticipanteKey_Internalname ;
      private string cmbAssinaturaParticipanteTipo_Internalname ;
      private string edtAssinaturaParticipanteRemoteAddres_Internalname ;
      private string edtAssinaturaParticipanteGeolocalizacao_Internalname ;
      private string edtAssinaturaParticipanteDispositivo_Internalname ;
      private string edtAssinaturaParticipanteCPF_Internalname ;
      private string edtAssinaturaParticipanteEmail_Internalname ;
      private string edtAssinaturaParticipanteNascimento_Internalname ;
      private string edtAssinaturaParticipanteLink_Internalname ;
      private string edtParticipanteId_Internalname ;
      private string edtAssinaturaId_Internalname ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string edtClienteId_Internalname ;
      private string GXDecQS ;
      private string cmbAssinaturaParticipanteStatus_Columnheaderclass ;
      private string edtavEditar_Class ;
      private string cmbAssinaturaParticipanteStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char8 ;
      private string sCtrlAV62AssinaturaId ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavReenviaremail_Jsonclick ;
      private string edtavCopylink_Jsonclick ;
      private string edtavEditar_Jsonclick ;
      private string edtParticipanteNome_Jsonclick ;
      private string edtParticipanteEmail_Jsonclick ;
      private string edtParticipanteDocumento_Jsonclick ;
      private string edtParticipanteRepresentanteNome_Jsonclick ;
      private string edtParticipanteRepresentanteEmail_Jsonclick ;
      private string edtParticipanteRepresentanteDocumento_Jsonclick ;
      private string GXCCtl ;
      private string cmbAssinaturaParticipanteStatus_Jsonclick ;
      private string edtAssinaturaParticipanteDataVisualizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDataConclusao_Jsonclick ;
      private string edtAssinaturaParticipanteKey_Jsonclick ;
      private string cmbAssinaturaParticipanteTipo_Jsonclick ;
      private string edtAssinaturaParticipanteRemoteAddres_Jsonclick ;
      private string edtAssinaturaParticipanteGeolocalizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDispositivo_Jsonclick ;
      private string edtAssinaturaParticipanteCPF_Jsonclick ;
      private string edtAssinaturaParticipanteEmail_Jsonclick ;
      private string edtAssinaturaParticipanteNascimento_Jsonclick ;
      private string edtAssinaturaParticipanteLink_Jsonclick ;
      private string edtParticipanteId_Jsonclick ;
      private string edtAssinaturaId_Jsonclick ;
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV31TFAssinaturaParticipanteDataVisualizacao ;
      private DateTime AV32TFAssinaturaParticipanteDataVisualizacao_To ;
      private DateTime AV36TFAssinaturaParticipanteDataConclusao ;
      private DateTime AV37TFAssinaturaParticipanteDataConclusao_To ;
      private DateTime AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ;
      private DateTime AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ;
      private DateTime AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao ;
      private DateTime AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime AV33DDO_AssinaturaParticipanteDataVisualizacaoAuxDate ;
      private DateTime AV34DDO_AssinaturaParticipanteDataVisualizacaoAuxDateTo ;
      private DateTime AV38DDO_AssinaturaParticipanteDataConclusaoAuxDate ;
      private DateTime AV39DDO_AssinaturaParticipanteDataConclusaoAuxDateTo ;
      private DateTime A352AssinaturaParticipanteNascimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool Grid_empowerer_Hascategories ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private bool n1002ParticipanteRepresentanteNome ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n346AssinaturaParticipanteRemoteAddres ;
      private bool n347AssinaturaParticipanteGeolocalizacao ;
      private bool n348AssinaturaParticipanteDispositivo ;
      private bool n350AssinaturaParticipanteCPF ;
      private bool n351AssinaturaParticipanteEmail ;
      private bool n352AssinaturaParticipanteNascimento ;
      private bool n354AssinaturaParticipanteLink ;
      private bool n233ParticipanteId ;
      private bool n238AssinaturaId ;
      private bool n168ClienteId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV29TFAssinaturaParticipanteStatus_SelsJson ;
      private string AV23TFParticipanteNome ;
      private string AV24TFParticipanteNome_Sel ;
      private string AV25TFParticipanteEmail ;
      private string AV26TFParticipanteEmail_Sel ;
      private string AV27TFParticipanteDocumento ;
      private string AV28TFParticipanteDocumento_Sel ;
      private string AV71TFParticipanteRepresentanteNome ;
      private string AV72TFParticipanteRepresentanteNome_Sel ;
      private string AV73TFParticipanteRepresentanteEmail ;
      private string AV74TFParticipanteRepresentanteEmail_Sel ;
      private string AV75TFParticipanteRepresentanteDocumento ;
      private string AV76TFParticipanteRepresentanteDocumento_Sel ;
      private string AV35DDO_AssinaturaParticipanteDataVisualizacaoAuxDateText ;
      private string AV40DDO_AssinaturaParticipanteDataConclusaoAuxDateText ;
      private string AV79Wcassinantesds_2_tfparticipantenome ;
      private string AV80Wcassinantesds_3_tfparticipantenome_sel ;
      private string AV81Wcassinantesds_4_tfparticipanteemail ;
      private string AV82Wcassinantesds_5_tfparticipanteemail_sel ;
      private string AV83Wcassinantesds_6_tfparticipantedocumento ;
      private string AV84Wcassinantesds_7_tfparticipantedocumento_sel ;
      private string AV85Wcassinantesds_8_tfparticipanterepresentantenome ;
      private string AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel ;
      private string AV87Wcassinantesds_10_tfparticipanterepresentanteemail ;
      private string AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel ;
      private string AV89Wcassinantesds_12_tfparticipanterepresentantedocumento ;
      private string AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string A1002ParticipanteRepresentanteNome ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string A353AssinaturaParticipanteStatus ;
      private string A247AssinaturaParticipanteTipo ;
      private string A346AssinaturaParticipanteRemoteAddres ;
      private string A347AssinaturaParticipanteGeolocalizacao ;
      private string A348AssinaturaParticipanteDispositivo ;
      private string A350AssinaturaParticipanteCPF ;
      private string A351AssinaturaParticipanteEmail ;
      private string A354AssinaturaParticipanteLink ;
      private string lV79Wcassinantesds_2_tfparticipantenome ;
      private string lV81Wcassinantesds_4_tfparticipanteemail ;
      private string lV83Wcassinantesds_6_tfparticipantedocumento ;
      private string lV85Wcassinantesds_8_tfparticipanterepresentantenome ;
      private string lV87Wcassinantesds_10_tfparticipanterepresentanteemail ;
      private string lV89Wcassinantesds_12_tfparticipanterepresentantedocumento ;
      private string AV61AuxText ;
      private string AV64BaseUrl ;
      private Guid A246AssinaturaParticipanteKey ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCopy ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfassinaturaparticipantedatavisualizacao_rangepicker ;
      private GXUserControl ucTfassinaturaparticipantedataconclusao_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAssinaturaParticipanteStatus ;
      private GXCombobox cmbAssinaturaParticipanteTipo ;
      private GxSimpleCollection<string> AV30TFAssinaturaParticipanteStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV60DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H006D2_A168ClienteId ;
      private bool[] H006D2_n168ClienteId ;
      private int[] H006D2_A242AssinaturaParticipanteId ;
      private long[] H006D2_A238AssinaturaId ;
      private bool[] H006D2_n238AssinaturaId ;
      private int[] H006D2_A233ParticipanteId ;
      private bool[] H006D2_n233ParticipanteId ;
      private string[] H006D2_A354AssinaturaParticipanteLink ;
      private bool[] H006D2_n354AssinaturaParticipanteLink ;
      private DateTime[] H006D2_A352AssinaturaParticipanteNascimento ;
      private bool[] H006D2_n352AssinaturaParticipanteNascimento ;
      private string[] H006D2_A351AssinaturaParticipanteEmail ;
      private bool[] H006D2_n351AssinaturaParticipanteEmail ;
      private string[] H006D2_A350AssinaturaParticipanteCPF ;
      private bool[] H006D2_n350AssinaturaParticipanteCPF ;
      private string[] H006D2_A348AssinaturaParticipanteDispositivo ;
      private bool[] H006D2_n348AssinaturaParticipanteDispositivo ;
      private string[] H006D2_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] H006D2_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] H006D2_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] H006D2_n346AssinaturaParticipanteRemoteAddres ;
      private string[] H006D2_A247AssinaturaParticipanteTipo ;
      private bool[] H006D2_n247AssinaturaParticipanteTipo ;
      private Guid[] H006D2_A246AssinaturaParticipanteKey ;
      private bool[] H006D2_n246AssinaturaParticipanteKey ;
      private DateTime[] H006D2_A245AssinaturaParticipanteDataConclusao ;
      private bool[] H006D2_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] H006D2_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] H006D2_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] H006D2_A353AssinaturaParticipanteStatus ;
      private bool[] H006D2_n353AssinaturaParticipanteStatus ;
      private string[] H006D2_A1004ParticipanteRepresentanteDocumento ;
      private bool[] H006D2_n1004ParticipanteRepresentanteDocumento ;
      private string[] H006D2_A1003ParticipanteRepresentanteEmail ;
      private bool[] H006D2_n1003ParticipanteRepresentanteEmail ;
      private string[] H006D2_A1002ParticipanteRepresentanteNome ;
      private bool[] H006D2_n1002ParticipanteRepresentanteNome ;
      private string[] H006D2_A234ParticipanteDocumento ;
      private bool[] H006D2_n234ParticipanteDocumento ;
      private string[] H006D2_A235ParticipanteEmail ;
      private bool[] H006D2_n235ParticipanteEmail ;
      private string[] H006D2_A248ParticipanteNome ;
      private bool[] H006D2_n248ParticipanteNome ;
      private long[] H006D3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcassinantes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006D2( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV80Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV79Wcassinantesds_2_tfparticipantenome ,
                                             string AV82Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV81Wcassinantesds_4_tfparticipanteemail ,
                                             string AV84Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV83Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV85Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV87Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV89Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV78Wcassinantesds_1_assinaturaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[20];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ClienteId, T1.AssinaturaParticipanteId, T1.AssinaturaId, T1.ParticipanteId, T1.AssinaturaParticipanteLink, T1.AssinaturaParticipanteNascimento, T1.AssinaturaParticipanteEmail, T1.AssinaturaParticipanteCPF, T1.AssinaturaParticipanteDispositivo, T1.AssinaturaParticipanteGeolocalizacao, T1.AssinaturaParticipanteRemoteAddres, T1.AssinaturaParticipanteTipo, T1.AssinaturaParticipanteKey, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome";
         sFromString = " FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV78Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV79Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV80Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV80Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV81Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV82Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV82Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV83Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV84Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV84Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV85Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV87Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV89Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteNome DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteEmail, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteEmail DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteDocumento, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteDocumento DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteNome, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteRepresentanteNome DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteEmail, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteRepresentanteEmail DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteDocumento, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteRepresentanteDocumento DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteStatus DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataVisualizacao DESC, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataConclusao DESC, T1.AssinaturaParticipanteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AssinaturaParticipanteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H006D3( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV80Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV79Wcassinantesds_2_tfparticipantenome ,
                                             string AV82Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV81Wcassinantesds_4_tfparticipanteemail ,
                                             string AV84Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV83Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV85Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV87Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV89Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV78Wcassinantesds_1_assinaturaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[17];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV78Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV79Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV80Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV80Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV81Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV82Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV82Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV83Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV84Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV84Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV85Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV87Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV89Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV91Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H006D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
               case 1 :
                     return conditional_H006D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
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
          Object[] prmH006D2;
          prmH006D2 = new Object[] {
          new ParDef("AV78Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV79Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV80Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV81Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV82Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV83Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV84Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV85Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006D3;
          prmH006D3 = new Object[] {
          new ParDef("AV78Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV79Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV80Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV81Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV82Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV83Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV84Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV85Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV86Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV88Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV90Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV92Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV95Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("H006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((Guid[]) buf[23])[0] = rslt.getGuid(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
