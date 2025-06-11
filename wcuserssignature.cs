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
   public class wcuserssignature : GXWebComponent
   {
      public wcuserssignature( )
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

      public wcuserssignature( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId ,
                           int aP1_AssinaturaParticipanteId )
      {
         this.AV37AssinaturaId = aP0_AssinaturaId;
         this.AV38AssinaturaParticipanteId = aP1_AssinaturaParticipanteId;
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
                  AV37AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV37AssinaturaId", StringUtil.LTrimStr( (decimal)(AV37AssinaturaId), 10, 0));
                  AV38AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV38AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV38AssinaturaParticipanteId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV37AssinaturaId,(int)AV38AssinaturaParticipanteId});
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
         nRC_GXsfl_19 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_19"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_19_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_19_idx = GetPar( "sGXsfl_19_idx");
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
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV38AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
         AV37AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
         AV39TFParticipanteNome = GetPar( "TFParticipanteNome");
         AV40TFParticipanteNome_Sel = GetPar( "TFParticipanteNome_Sel");
         AV69Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
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
            PA5A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV69Pgmname = "WcUsersSignature";
               WS5A2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wcuserssignature"+UrlEncode(StringUtil.LTrimStr(AV37AssinaturaId,10,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV38AssinaturaParticipanteId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcuserssignature") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_19", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_19), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV37AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV38AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV38AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME", AV39TFParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPARTICIPANTENOME_SEL", AV40TFParticipanteNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm5A2( )
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
         return "WcUsersSignature" ;
      }

      public override string GetPgmdesc( )
      {
         return " Assinatura Participante" ;
      }

      protected void WB5A0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcuserssignature");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "<h2>Participantes</h2>", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcUsersSignature.htm");
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
            StartGridControl19( ) ;
         }
         if ( wbEnd == 19 )
         {
            wbEnd = 0;
            nRC_GXsfl_19 = (int)(nGXsfl_19_idx-1);
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 19 )
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

      protected void START5A2( )
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
               STRUP5A0( ) ;
            }
         }
      }

      protected void WS5A2( )
      {
         START5A2( ) ;
         EVT5A2( ) ;
      }

      protected void EVT5A2( )
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
                                 STRUP5A0( ) ;
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
                                 STRUP5A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E115A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5A0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5A0( ) ;
                              }
                              AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
                              AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
                              AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
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
                                 STRUP5A0( ) ;
                              }
                              nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
                              SubsflControlProps_192( ) ;
                              A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n238AssinaturaId = false;
                              A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n233ParticipanteId = false;
                              A248ParticipanteNome = cgiGet( edtParticipanteNome_Internalname);
                              n248ParticipanteNome = false;
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
                                          /* Execute user event: Start */
                                          E125A2 ();
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
                                          /* Execute user event: Refresh */
                                          E135A2 ();
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
                                          /* Execute user event: Grid.Load */
                                          E145A2 ();
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
                                       STRUP5A0( ) ;
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

      protected void WE5A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5A2( ) ;
            }
         }
      }

      protected void PA5A2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcuserssignature")), "wcuserssignature") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcuserssignature")))) ;
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
         SubsflControlProps_192( ) ;
         while ( nGXsfl_19_idx <= nRC_GXsfl_19 )
         {
            sendrow_192( ) ;
            nGXsfl_19_idx = ((subGrid_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       bool AV13OrderedDsc ,
                                       int AV38AssinaturaParticipanteId ,
                                       long AV37AssinaturaId ,
                                       string AV39TFParticipanteNome ,
                                       string AV40TFParticipanteNome_Sel ,
                                       string AV69Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5A2( ) ;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "WcUsersSignature";
      }

      protected void RF5A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 19;
         /* Execute user event: Refresh */
         E135A2 ();
         nGXsfl_19_idx = 1;
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         bGXsfl_19_Refreshing = true;
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
            SubsflControlProps_192( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV68Wcuserssignatureds_3_tfparticipantenome_sel ,
                                                 AV67Wcuserssignatureds_2_tfparticipantenome ,
                                                 A248ParticipanteNome ,
                                                 AV13OrderedDsc ,
                                                 A238AssinaturaId ,
                                                 AV66Wcuserssignatureds_1_assinaturaid ,
                                                 A242AssinaturaParticipanteId ,
                                                 AV38AssinaturaParticipanteId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV67Wcuserssignatureds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV67Wcuserssignatureds_2_tfparticipantenome), "%", "");
            /* Using cursor H005A2 */
            pr_default.execute(0, new Object[] {AV66Wcuserssignatureds_1_assinaturaid, AV38AssinaturaParticipanteId, lV67Wcuserssignatureds_2_tfparticipantenome, AV68Wcuserssignatureds_3_tfparticipantenome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_19_idx = 1;
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A247AssinaturaParticipanteTipo = H005A2_A247AssinaturaParticipanteTipo[0];
               n247AssinaturaParticipanteTipo = H005A2_n247AssinaturaParticipanteTipo[0];
               A246AssinaturaParticipanteKey = H005A2_A246AssinaturaParticipanteKey[0];
               n246AssinaturaParticipanteKey = H005A2_n246AssinaturaParticipanteKey[0];
               A245AssinaturaParticipanteDataConclusao = H005A2_A245AssinaturaParticipanteDataConclusao[0];
               n245AssinaturaParticipanteDataConclusao = H005A2_n245AssinaturaParticipanteDataConclusao[0];
               A244AssinaturaParticipanteDataVisualizacao = H005A2_A244AssinaturaParticipanteDataVisualizacao[0];
               n244AssinaturaParticipanteDataVisualizacao = H005A2_n244AssinaturaParticipanteDataVisualizacao[0];
               A353AssinaturaParticipanteStatus = H005A2_A353AssinaturaParticipanteStatus[0];
               n353AssinaturaParticipanteStatus = H005A2_n353AssinaturaParticipanteStatus[0];
               A248ParticipanteNome = H005A2_A248ParticipanteNome[0];
               n248ParticipanteNome = H005A2_n248ParticipanteNome[0];
               A233ParticipanteId = H005A2_A233ParticipanteId[0];
               n233ParticipanteId = H005A2_n233ParticipanteId[0];
               A238AssinaturaId = H005A2_A238AssinaturaId[0];
               n238AssinaturaId = H005A2_n238AssinaturaId[0];
               A242AssinaturaParticipanteId = H005A2_A242AssinaturaParticipanteId[0];
               A248ParticipanteNome = H005A2_A248ParticipanteNome[0];
               n248ParticipanteNome = H005A2_n248ParticipanteNome[0];
               /* Execute user event: Grid.Load */
               E145A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 19;
            WB5A0( ) ;
         }
         bGXsfl_19_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5A2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
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
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68Wcuserssignatureds_3_tfparticipantenome_sel ,
                                              AV67Wcuserssignatureds_2_tfparticipantenome ,
                                              A248ParticipanteNome ,
                                              AV13OrderedDsc ,
                                              A238AssinaturaId ,
                                              AV66Wcuserssignatureds_1_assinaturaid ,
                                              A242AssinaturaParticipanteId ,
                                              AV38AssinaturaParticipanteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV67Wcuserssignatureds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV67Wcuserssignatureds_2_tfparticipantenome), "%", "");
         /* Using cursor H005A3 */
         pr_default.execute(1, new Object[] {AV66Wcuserssignatureds_1_assinaturaid, AV38AssinaturaParticipanteId, lV67Wcuserssignatureds_2_tfparticipantenome, AV68Wcuserssignatureds_3_tfparticipantenome_sel});
         GRID_nRecordCount = H005A3_AGRID_nRecordCount[0];
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
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV38AssinaturaParticipanteId, AV37AssinaturaId, AV39TFParticipanteNome, AV40TFParticipanteNome_Sel, AV69Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "WcUsersSignature";
         edtAssinaturaParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         edtAssinaturaParticipanteKey_Enabled = 0;
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E125A2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV35DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_19 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_19"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV37AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV37AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV38AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38AssinaturaParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
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
         E125A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E125A2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV35DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV35DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E135A2( )
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
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Columnheaderclass", cmbAssinaturaParticipanteStatus_Columnheaderclass, !bGXsfl_19_Refreshing);
         AV66Wcuserssignatureds_1_assinaturaid = AV37AssinaturaId;
         AV67Wcuserssignatureds_2_tfparticipantenome = AV39TFParticipanteNome;
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = AV40TFParticipanteNome_Sel;
         /*  Sending Event outputs  */
      }

      protected void E115A2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
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
               AV39TFParticipanteNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFParticipanteNome", AV39TFParticipanteNome);
               AV40TFParticipanteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFParticipanteNome_Sel", AV40TFParticipanteNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E145A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnGray WWColumnGraySingleCell";
         }
         else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 )
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else
         {
            cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 19;
         }
         sendrow_192( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_19_Refreshing )
         {
            DoAjaxLoad(19, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = "-1:"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV39TFParticipanteNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFParticipanteNome", AV39TFParticipanteNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV40TFParticipanteNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFParticipanteNome_Sel", AV40TFParticipanteNome_Sel);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParticipanteNome_Sel)),  AV40TFParticipanteNome_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome)),  AV39TFParticipanteNome, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPARTICIPANTENOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome)),  0,  AV39TFParticipanteNome,  AV39TFParticipanteNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParticipanteNome_Sel)),  AV40TFParticipanteNome_Sel,  AV40TFParticipanteNome_Sel) ;
         if ( ! (0==AV37AssinaturaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&ASSINATURAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV37AssinaturaId), 10, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! (0==AV38AssinaturaParticipanteId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&ASSINATURAPARTICIPANTEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV38AssinaturaParticipanteId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "AssinaturaParticipante";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "AssinaturaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV37AssinaturaId), 10, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV37AssinaturaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV37AssinaturaId", StringUtil.LTrimStr( (decimal)(AV37AssinaturaId), 10, 0));
         AV38AssinaturaParticipanteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV38AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV38AssinaturaParticipanteId), 9, 0));
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
         PA5A2( ) ;
         WS5A2( ) ;
         WE5A2( ) ;
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
         sCtrlAV37AssinaturaId = (string)((string)getParm(obj,0));
         sCtrlAV38AssinaturaParticipanteId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5A2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcuserssignature", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5A2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV37AssinaturaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV37AssinaturaId", StringUtil.LTrimStr( (decimal)(AV37AssinaturaId), 10, 0));
            AV38AssinaturaParticipanteId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV38AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV38AssinaturaParticipanteId), 9, 0));
         }
         wcpOAV37AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV37AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV38AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38AssinaturaParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV37AssinaturaId != wcpOAV37AssinaturaId ) || ( AV38AssinaturaParticipanteId != wcpOAV38AssinaturaParticipanteId ) ) )
         {
            setjustcreated();
         }
         wcpOAV37AssinaturaId = AV37AssinaturaId;
         wcpOAV38AssinaturaParticipanteId = AV38AssinaturaParticipanteId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV37AssinaturaId = cgiGet( sPrefix+"AV37AssinaturaId_CTRL");
         if ( StringUtil.Len( sCtrlAV37AssinaturaId) > 0 )
         {
            AV37AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV37AssinaturaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV37AssinaturaId", StringUtil.LTrimStr( (decimal)(AV37AssinaturaId), 10, 0));
         }
         else
         {
            AV37AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV37AssinaturaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV38AssinaturaParticipanteId = cgiGet( sPrefix+"AV38AssinaturaParticipanteId_CTRL");
         if ( StringUtil.Len( sCtrlAV38AssinaturaParticipanteId) > 0 )
         {
            AV38AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV38AssinaturaParticipanteId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV38AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV38AssinaturaParticipanteId), 9, 0));
         }
         else
         {
            AV38AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV38AssinaturaParticipanteId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA5A2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5A2( ) ;
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
         WS5A2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37AssinaturaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37AssinaturaId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37AssinaturaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37AssinaturaId_CTRL", StringUtil.RTrim( sCtrlAV37AssinaturaId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV38AssinaturaParticipanteId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38AssinaturaParticipanteId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV38AssinaturaParticipanteId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV38AssinaturaParticipanteId_CTRL", StringUtil.RTrim( sCtrlAV38AssinaturaParticipanteId));
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
         WE5A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019141123", true, true);
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
         context.AddJavascriptSource("wcuserssignature.js", "?202561019141124", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_192( )
      {
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_19_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_19_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_19_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_19_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_19_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_19_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_19_idx;
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY_"+sGXsfl_19_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_19_idx;
      }

      protected void SubsflControlProps_fel_192( )
      {
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID_"+sGXsfl_19_fel_idx;
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID_"+sGXsfl_19_fel_idx;
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID_"+sGXsfl_19_fel_idx;
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME_"+sGXsfl_19_fel_idx;
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS_"+sGXsfl_19_fel_idx;
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO_"+sGXsfl_19_fel_idx;
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO_"+sGXsfl_19_fel_idx;
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY_"+sGXsfl_19_fel_idx;
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO_"+sGXsfl_19_fel_idx;
      }

      protected void sendrow_192( )
      {
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         WB5A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_19_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_19_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_19_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParticipanteNome_Internalname,(string)A248ParticipanteNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParticipanteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_19_idx;
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
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteStatus_Internalname, "Values", (string)(cmbAssinaturaParticipanteStatus.ToJavascriptSource()), !bGXsfl_19_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataVisualizacao_Internalname,context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A244AssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataVisualizacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteDataConclusao_Internalname,context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A245AssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteDataConclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipanteKey_Internalname,A246AssinaturaParticipanteKey.ToString(),A246AssinaturaParticipanteKey.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipanteKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)19,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbAssinaturaParticipanteTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_19_idx;
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
            AssignProp(sPrefix, false, cmbAssinaturaParticipanteTipo_Internalname, "Values", (string)(cmbAssinaturaParticipanteTipo.ToJavascriptSource()), !bGXsfl_19_Refreshing);
            send_integrity_lvl_hashes5A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_19_idx = ((subGrid_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         /* End function sendrow_192 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ASSINATURAPARTICIPANTESTATUS_" + sGXsfl_19_idx;
         cmbAssinaturaParticipanteStatus.Name = GXCCtl;
         cmbAssinaturaParticipanteStatus.WebTags = "";
         cmbAssinaturaParticipanteStatus.addItem("Pendente", "Pendente", 0);
         cmbAssinaturaParticipanteStatus.addItem("Assinado", "Assinado", 0);
         cmbAssinaturaParticipanteStatus.addItem("Recusado", "Recusado", 0);
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
         }
         GXCCtl = "ASSINATURAPARTICIPANTETIPO_" + sGXsfl_19_idx;
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

      protected void StartGridControl19( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"19\">") ;
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
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Data visualiazação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Data da conclusão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Participante Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo do participante") ;
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
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtAssinaturaParticipanteId_Internalname = sPrefix+"ASSINATURAPARTICIPANTEID";
         edtAssinaturaId_Internalname = sPrefix+"ASSINATURAID";
         edtParticipanteId_Internalname = sPrefix+"PARTICIPANTEID";
         edtParticipanteNome_Internalname = sPrefix+"PARTICIPANTENOME";
         cmbAssinaturaParticipanteStatus_Internalname = sPrefix+"ASSINATURAPARTICIPANTESTATUS";
         edtAssinaturaParticipanteDataVisualizacao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATAVISUALIZACAO";
         edtAssinaturaParticipanteDataConclusao_Internalname = sPrefix+"ASSINATURAPARTICIPANTEDATACONCLUSAO";
         edtAssinaturaParticipanteKey_Internalname = sPrefix+"ASSINATURAPARTICIPANTEKEY";
         cmbAssinaturaParticipanteTipo_Internalname = sPrefix+"ASSINATURAPARTICIPANTETIPO";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
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
         cmbAssinaturaParticipanteTipo_Jsonclick = "";
         edtAssinaturaParticipanteKey_Jsonclick = "";
         edtAssinaturaParticipanteDataConclusao_Jsonclick = "";
         edtAssinaturaParticipanteDataVisualizacao_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Jsonclick = "";
         cmbAssinaturaParticipanteStatus_Columnclass = "WWColumn";
         edtParticipanteNome_Jsonclick = "";
         edtParticipanteId_Jsonclick = "";
         edtAssinaturaId_Jsonclick = "";
         edtAssinaturaParticipanteId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbAssinaturaParticipanteStatus_Columnheaderclass = "";
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         edtAssinaturaParticipanteKey_Enabled = 0;
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         edtParticipanteNome_Enabled = 0;
         edtParticipanteId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtAssinaturaParticipanteId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WcUsersSignatureGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "-1";
         Ddo_grid_Columnids = "3:ParticipanteNome";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E115A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E145A2","iparms":[{"av":"cmbAssinaturaParticipanteStatus"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39TFParticipanteNome","fld":"vTFPARTICIPANTENOME","type":"svchar"},{"av":"AV40TFParticipanteNome_Sel","fld":"vTFPARTICIPANTENOME_SEL","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"cmbAssinaturaParticipanteStatus"}]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Assinaturaparticipantetipo","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV39TFParticipanteNome = "";
         AV40TFParticipanteNome_Sel = "";
         AV69Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV67Wcuserssignatureds_2_tfparticipantenome = "";
         AV68Wcuserssignatureds_3_tfparticipantenome_sel = "";
         A248ParticipanteNome = "";
         A353AssinaturaParticipanteStatus = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A246AssinaturaParticipanteKey = Guid.Empty;
         A247AssinaturaParticipanteTipo = "";
         GXDecQS = "";
         lV67Wcuserssignatureds_2_tfparticipantenome = "";
         H005A2_A247AssinaturaParticipanteTipo = new string[] {""} ;
         H005A2_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         H005A2_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         H005A2_n246AssinaturaParticipanteKey = new bool[] {false} ;
         H005A2_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         H005A2_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         H005A2_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         H005A2_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         H005A2_A353AssinaturaParticipanteStatus = new string[] {""} ;
         H005A2_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         H005A2_A248ParticipanteNome = new string[] {""} ;
         H005A2_n248ParticipanteNome = new bool[] {false} ;
         H005A2_A233ParticipanteId = new int[1] ;
         H005A2_n233ParticipanteId = new bool[] {false} ;
         H005A2_A238AssinaturaId = new long[1] ;
         H005A2_n238AssinaturaId = new bool[] {false} ;
         H005A2_A242AssinaturaParticipanteId = new int[1] ;
         H005A3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV37AssinaturaId = "";
         sCtrlAV38AssinaturaParticipanteId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcuserssignature__default(),
            new Object[][] {
                new Object[] {
               H005A2_A247AssinaturaParticipanteTipo, H005A2_n247AssinaturaParticipanteTipo, H005A2_A246AssinaturaParticipanteKey, H005A2_n246AssinaturaParticipanteKey, H005A2_A245AssinaturaParticipanteDataConclusao, H005A2_n245AssinaturaParticipanteDataConclusao, H005A2_A244AssinaturaParticipanteDataVisualizacao, H005A2_n244AssinaturaParticipanteDataVisualizacao, H005A2_A353AssinaturaParticipanteStatus, H005A2_n353AssinaturaParticipanteStatus,
               H005A2_A248ParticipanteNome, H005A2_n248ParticipanteNome, H005A2_A233ParticipanteId, H005A2_n233ParticipanteId, H005A2_A238AssinaturaId, H005A2_n238AssinaturaId, H005A2_A242AssinaturaParticipanteId
               }
               , new Object[] {
               H005A3_AGRID_nRecordCount
               }
            }
         );
         AV69Pgmname = "WcUsersSignature";
         /* GeneXus formulas. */
         AV69Pgmname = "WcUsersSignature";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV38AssinaturaParticipanteId ;
      private int wcpOAV38AssinaturaParticipanteId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_19 ;
      private int nGXsfl_19_idx=1 ;
      private int A242AssinaturaParticipanteId ;
      private int A233ParticipanteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtAssinaturaId_Enabled ;
      private int edtParticipanteId_Enabled ;
      private int edtParticipanteNome_Enabled ;
      private int edtAssinaturaParticipanteDataVisualizacao_Enabled ;
      private int edtAssinaturaParticipanteDataConclusao_Enabled ;
      private int edtAssinaturaParticipanteKey_Enabled ;
      private int AV70GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV37AssinaturaId ;
      private long wcpOAV37AssinaturaId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV66Wcuserssignatureds_1_assinaturaid ;
      private long A238AssinaturaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_19_idx="0001" ;
      private string AV69Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string edtAssinaturaId_Internalname ;
      private string edtParticipanteId_Internalname ;
      private string edtParticipanteNome_Internalname ;
      private string cmbAssinaturaParticipanteStatus_Internalname ;
      private string edtAssinaturaParticipanteDataVisualizacao_Internalname ;
      private string edtAssinaturaParticipanteDataConclusao_Internalname ;
      private string edtAssinaturaParticipanteKey_Internalname ;
      private string cmbAssinaturaParticipanteTipo_Internalname ;
      private string GXDecQS ;
      private string cmbAssinaturaParticipanteStatus_Columnheaderclass ;
      private string cmbAssinaturaParticipanteStatus_Columnclass ;
      private string GXt_char2 ;
      private string sCtrlAV37AssinaturaId ;
      private string sCtrlAV38AssinaturaParticipanteId ;
      private string sGXsfl_19_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtAssinaturaId_Jsonclick ;
      private string edtParticipanteId_Jsonclick ;
      private string edtParticipanteNome_Jsonclick ;
      private string GXCCtl ;
      private string cmbAssinaturaParticipanteStatus_Jsonclick ;
      private string edtAssinaturaParticipanteDataVisualizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDataConclusao_Jsonclick ;
      private string edtAssinaturaParticipanteKey_Jsonclick ;
      private string cmbAssinaturaParticipanteTipo_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
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
      private bool n238AssinaturaId ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool bGXsfl_19_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV39TFParticipanteNome ;
      private string AV40TFParticipanteNome_Sel ;
      private string AV67Wcuserssignatureds_2_tfparticipantenome ;
      private string AV68Wcuserssignatureds_3_tfparticipantenome_sel ;
      private string A248ParticipanteNome ;
      private string A353AssinaturaParticipanteStatus ;
      private string A247AssinaturaParticipanteTipo ;
      private string lV67Wcuserssignatureds_2_tfparticipantenome ;
      private Guid A246AssinaturaParticipanteKey ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAssinaturaParticipanteStatus ;
      private GXCombobox cmbAssinaturaParticipanteTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV35DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H005A2_A247AssinaturaParticipanteTipo ;
      private bool[] H005A2_n247AssinaturaParticipanteTipo ;
      private Guid[] H005A2_A246AssinaturaParticipanteKey ;
      private bool[] H005A2_n246AssinaturaParticipanteKey ;
      private DateTime[] H005A2_A245AssinaturaParticipanteDataConclusao ;
      private bool[] H005A2_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] H005A2_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] H005A2_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] H005A2_A353AssinaturaParticipanteStatus ;
      private bool[] H005A2_n353AssinaturaParticipanteStatus ;
      private string[] H005A2_A248ParticipanteNome ;
      private bool[] H005A2_n248ParticipanteNome ;
      private int[] H005A2_A233ParticipanteId ;
      private bool[] H005A2_n233ParticipanteId ;
      private long[] H005A2_A238AssinaturaId ;
      private bool[] H005A2_n238AssinaturaId ;
      private int[] H005A2_A242AssinaturaParticipanteId ;
      private long[] H005A3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcuserssignature__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005A2( IGxContext context ,
                                             string AV68Wcuserssignatureds_3_tfparticipantenome_sel ,
                                             string AV67Wcuserssignatureds_2_tfparticipantenome ,
                                             string A248ParticipanteNome ,
                                             bool AV13OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV66Wcuserssignatureds_1_assinaturaid ,
                                             int A242AssinaturaParticipanteId ,
                                             int AV38AssinaturaParticipanteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.AssinaturaParticipanteTipo, T1.AssinaturaParticipanteKey, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteNome, T1.ParticipanteId, T1.AssinaturaId, T1.AssinaturaParticipanteId";
         sFromString = " FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV66Wcuserssignatureds_1_assinaturaid)");
         AddWhere(sWhereString, "(T1.AssinaturaParticipanteId <> :AV38AssinaturaParticipanteId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wcuserssignatureds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wcuserssignatureds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV67Wcuserssignatureds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wcuserssignatureds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV68Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV68Wcuserssignatureds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteId";
         }
         else if ( AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteNome DESC, T1.AssinaturaParticipanteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AssinaturaParticipanteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H005A3( IGxContext context ,
                                             string AV68Wcuserssignatureds_3_tfparticipantenome_sel ,
                                             string AV67Wcuserssignatureds_2_tfparticipantenome ,
                                             string A248ParticipanteNome ,
                                             bool AV13OrderedDsc ,
                                             long A238AssinaturaId ,
                                             long AV66Wcuserssignatureds_1_assinaturaid ,
                                             int A242AssinaturaParticipanteId ,
                                             int AV38AssinaturaParticipanteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV66Wcuserssignatureds_1_assinaturaid)");
         AddWhere(sWhereString, "(T1.AssinaturaParticipanteId <> :AV38AssinaturaParticipanteId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wcuserssignatureds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wcuserssignatureds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV67Wcuserssignatureds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wcuserssignatureds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV68Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV68Wcuserssignatureds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 1 :
                     return conditional_H005A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmH005A2;
          prmH005A2 = new Object[] {
          new ParDef("AV66Wcuserssignatureds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("AV38AssinaturaParticipanteId",GXType.Int32,9,0) ,
          new ParDef("lV67Wcuserssignatureds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV68Wcuserssignatureds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005A3;
          prmH005A3 = new Object[] {
          new ParDef("AV66Wcuserssignatureds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("AV38AssinaturaParticipanteId",GXType.Int32,9,0) ,
          new ParDef("lV67Wcuserssignatureds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV68Wcuserssignatureds_3_tfparticipantenome_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A3,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((long[]) buf[14])[0] = rslt.getLong(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
