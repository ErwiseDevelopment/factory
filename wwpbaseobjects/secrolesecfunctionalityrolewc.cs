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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secrolesecfunctionalityrolewc : GXWebComponent
   {
      public secrolesecfunctionalityrolewc( )
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

      public secrolesecfunctionalityrolewc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV8SecRoleId = aP0_SecRoleId;
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
         cmbavSecfunctionalitytype = new GXCombobox();
         cmbSecFunctionalityType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "SecRoleId");
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
                  AV8SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV8SecRoleId});
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
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
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
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV54FilterFullText = GetPar( "FilterFullText");
         cmbavSecfunctionalitytype.FromJSonString( GetNextPar( ));
         AV17SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityType"), "."), 18, MidpointRounding.ToEven));
         AV8SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV56Pgmname = GetPar( "Pgmname");
         AV35TFSecFunctionalityKey = GetPar( "TFSecFunctionalityKey");
         AV36TFSecFunctionalityKey_Sel = GetPar( "TFSecFunctionalityKey_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38TFSecFunctionalityType_Sels);
         AV39TFSecParentFunctionalityDescription = GetPar( "TFSecParentFunctionalityDescription");
         AV40TFSecParentFunctionalityDescription_Sel = GetPar( "TFSecParentFunctionalityDescription_Sel");
         A131SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
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
            PA342( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV56Pgmname = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               WS342( ) ;
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
            context.SendWebValue( "Sec Role Sec Functionality Role WC") ;
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
            GXEncryptionTmp = "wwpbaseobjects.secrolesecfunctionalityrolewc"+UrlEncode(StringUtil.LTrimStr(AV8SecRoleId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secrolesecfunctionalityrolewc") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"SecRoleSecFunctionalityRoleWC");
         forbiddenHiddens.Add("SecRoleId", context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\secrolesecfunctionalityrolewc:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV16OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV54FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECFUNCTIONALITYTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17SecFunctionalityType), 2, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV16OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECFUNCTIONALITYKEY", AV35TFSecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECFUNCTIONALITYKEY_SEL", AV36TFSecFunctionalityKey_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFSECFUNCTIONALITYTYPE_SELS", AV38TFSecFunctionalityType_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFSECFUNCTIONALITYTYPE_SELS", AV38TFSecFunctionalityType_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECPARENTFUNCTIONALITYDESCRIPTION", AV39TFSecParentFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL", AV40TFSecParentFunctionalityDescription_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecRoleId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECFUNCTIONALITYTYPE_SELSJSON", AV37TFSecFunctionalityType_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm342( )
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
         return "WWPBaseObjects.SecRoleSecFunctionalityRoleWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec Role Sec Functionality Role WC" ;
      }

      protected void WB340( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.secrolesecfunctionalityrolewc");
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV54FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV54FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecRoleSecFunctionalityRoleWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "TableDynamicFilters", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecfunctionalitytype_Internalname, "Sec Functionality Type", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecfunctionalitytype, cmbavSecfunctionalitytype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0)), 1, cmbavSecfunctionalitytype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecfunctionalitytype.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleSecFunctionalityRoleWC.htm");
            cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0));
            AssignProp(sPrefix, false, cmbavSecfunctionalitytype_Internalname, "Values", (string)(cmbavSecfunctionalitytype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV41DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSecRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecRoleId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecRoleSecFunctionalityRoleWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 34 )
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

      protected void START342( )
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
            Form.Meta.addItem("description", "Sec Role Sec Functionality Role WC", 0) ;
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
               STRUP340( ) ;
            }
         }
      }

      protected void WS342( )
      {
         START342( ) ;
         EVT342( ) ;
      }

      protected void EVT342( )
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
                                 STRUP340( ) ;
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
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
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
                                 STRUP340( ) ;
                              }
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              AV55Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV55Display);
                              AV49Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV49Update);
                              AV47Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV47Delete);
                              A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
                              n130SecFunctionalityKey = false;
                              cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
                              cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
                              A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
                              n136SecFunctionalityType = false;
                              A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              n135SecFunctionalityDescription = false;
                              A138SecParentFunctionalityDescription = cgiGet( edtSecParentFunctionalityDescription_Internalname);
                              n138SecParentFunctionalityDescription = false;
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
                                          E15342 ();
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
                                          E16342 ();
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
                                          E17342 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV54FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secfunctionalitytype Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vSECFUNCTIONALITYTYPE"), ",", ".") != Convert.ToDecimal( AV17SecFunctionalityType )) )
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
                                       STRUP340( ) ;
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

      protected void WE342( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm342( ) ;
            }
         }
      }

      protected void PA342( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secrolesecfunctionalityrolewc")), "wwpbaseobjects.secrolesecfunctionalityrolewc") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secrolesecfunctionalityrolewc")))) ;
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
                     gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string AV54FilterFullText ,
                                       short AV17SecFunctionalityType ,
                                       short AV8SecRoleId ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV56Pgmname ,
                                       string AV35TFSecFunctionalityKey ,
                                       string AV36TFSecFunctionalityKey_Sel ,
                                       GxSimpleCollection<short> AV38TFSecFunctionalityType_Sels ,
                                       string AV39TFSecParentFunctionalityDescription ,
                                       string AV40TFSecParentFunctionalityDescription_Sel ,
                                       short A131SecRoleId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF342( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"SecRoleSecFunctionalityRoleWC");
         forbiddenHiddens.Add("SecRoleId", context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\secrolesecfunctionalityrolewc:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         if ( cmbavSecfunctionalitytype.ItemCount > 0 )
         {
            AV17SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbavSecfunctionalitytype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV17SecFunctionalityType), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0));
            AssignProp(sPrefix, false, cmbavSecfunctionalitytype_Internalname, "Values", cmbavSecfunctionalitytype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF342( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF342( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 34;
         /* Execute user event: Refresh */
         E16342 ();
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
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
            SubsflControlProps_342( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A136SecFunctionalityType ,
                                                 AV38TFSecFunctionalityType_Sels ,
                                                 AV54FilterFullText ,
                                                 AV17SecFunctionalityType ,
                                                 AV36TFSecFunctionalityKey_Sel ,
                                                 AV35TFSecFunctionalityKey ,
                                                 AV38TFSecFunctionalityType_Sels.Count ,
                                                 AV40TFSecParentFunctionalityDescription_Sel ,
                                                 AV39TFSecParentFunctionalityDescription ,
                                                 A130SecFunctionalityKey ,
                                                 A135SecFunctionalityDescription ,
                                                 A138SecParentFunctionalityDescription ,
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc ,
                                                 A131SecRoleId ,
                                                 AV8SecRoleId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.SHORT
                                                 }
            });
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
            lV35TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV35TFSecFunctionalityKey), "%", "");
            lV39TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV39TFSecParentFunctionalityDescription), "%", "");
            /* Using cursor H00342 */
            pr_default.execute(0, new Object[] {AV8SecRoleId, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, AV17SecFunctionalityType, lV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, lV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A129SecParentFunctionalityId = H00342_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H00342_n129SecParentFunctionalityId[0];
               A735SecFunctionalityRoleAtivo = H00342_A735SecFunctionalityRoleAtivo[0];
               A131SecRoleId = H00342_A131SecRoleId[0];
               AssignAttri(sPrefix, false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
               A138SecParentFunctionalityDescription = H00342_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H00342_n138SecParentFunctionalityDescription[0];
               A135SecFunctionalityDescription = H00342_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H00342_n135SecFunctionalityDescription[0];
               A136SecFunctionalityType = H00342_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H00342_n136SecFunctionalityType[0];
               A130SecFunctionalityKey = H00342_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H00342_n130SecFunctionalityKey[0];
               A128SecFunctionalityId = H00342_A128SecFunctionalityId[0];
               A129SecParentFunctionalityId = H00342_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H00342_n129SecParentFunctionalityId[0];
               A135SecFunctionalityDescription = H00342_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H00342_n135SecFunctionalityDescription[0];
               A136SecFunctionalityType = H00342_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H00342_n136SecFunctionalityType[0];
               A130SecFunctionalityKey = H00342_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H00342_n130SecFunctionalityKey[0];
               A138SecParentFunctionalityDescription = H00342_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H00342_n138SecParentFunctionalityDescription[0];
               /* Execute user event: Grid.Load */
               E17342 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 34;
            WB340( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes342( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV38TFSecFunctionalityType_Sels ,
                                              AV54FilterFullText ,
                                              AV17SecFunctionalityType ,
                                              AV36TFSecFunctionalityKey_Sel ,
                                              AV35TFSecFunctionalityKey ,
                                              AV38TFSecFunctionalityType_Sels.Count ,
                                              AV40TFSecParentFunctionalityDescription_Sel ,
                                              AV39TFSecParentFunctionalityDescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV15OrderedBy ,
                                              AV16OrderedDsc ,
                                              A131SecRoleId ,
                                              AV8SecRoleId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV35TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV35TFSecFunctionalityKey), "%", "");
         lV39TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV39TFSecParentFunctionalityDescription), "%", "");
         /* Using cursor H00343 */
         pr_default.execute(1, new Object[] {AV8SecRoleId, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, AV17SecFunctionalityType, lV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, lV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel});
         GRID_nRecordCount = H00343_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV54FilterFullText, AV17SecFunctionalityType, AV8SecRoleId, AV34ManageFiltersExecutionStep, AV56Pgmname, AV35TFSecFunctionalityKey, AV36TFSecFunctionalityKey_Sel, AV38TFSecFunctionalityType_Sels, AV39TFSecParentFunctionalityDescription, AV40TFSecParentFunctionalityDescription_Sel, A131SecRoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         edtSecRoleId_Enabled = 0;
         AssignProp(sPrefix, false, edtSecRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP340( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15342 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV41DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_34"), ",", "."), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8SecRoleId"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV54FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV54FilterFullText", AV54FilterFullText);
            cmbavSecfunctionalitytype.Name = cmbavSecfunctionalitytype_Internalname;
            cmbavSecfunctionalitytype.CurrentValue = cgiGet( cmbavSecfunctionalitytype_Internalname);
            AV17SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecfunctionalitytype_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV17SecFunctionalityType), 2, 0));
            A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"SecRoleSecFunctionalityRoleWC");
            A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            forbiddenHiddens.Add("SecRoleId", context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wwpbaseobjects\\secrolesecfunctionalityrolewc:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV54FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vSECFUNCTIONALITYTYPE"), ",", ".") != Convert.ToDecimal( AV17SecFunctionalityType )) )
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
         E15342 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15342( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV17SecFunctionalityType = 0;
         AssignAttri(sPrefix, false, "AV17SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV17SecFunctionalityType), 2, 0));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtSecRoleId_Visible = 0;
         AssignProp(sPrefix, false, edtSecRoleId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecRoleId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV41DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV41DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16342( )
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV44GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char2 = AV46GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E12342( )
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
            AV43PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV43PageToGo) ;
         }
      }

      protected void E13342( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14342( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityKey") == 0 )
            {
               AV35TFSecFunctionalityKey = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFSecFunctionalityKey", AV35TFSecFunctionalityKey);
               AV36TFSecFunctionalityKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFSecFunctionalityKey_Sel", AV36TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityType") == 0 )
            {
               AV37TFSecFunctionalityType_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV37TFSecFunctionalityType_SelsJson", AV37TFSecFunctionalityType_SelsJson);
               AV38TFSecFunctionalityType_Sels.FromJSonString(StringUtil.StringReplace( AV37TFSecFunctionalityType_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecParentFunctionalityDescription") == 0 )
            {
               AV39TFSecParentFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFSecParentFunctionalityDescription", AV39TFSecParentFunctionalityDescription);
               AV40TFSecParentFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFSecParentFunctionalityDescription_Sel", AV40TFSecParentFunctionalityDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38TFSecFunctionalityType_Sels", AV38TFSecFunctionalityType_Sels);
      }

      private void E17342( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV55Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV55Display);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionalityrole"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0)) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavDisplay_Link = formatLink("wwpbaseobjects.secfunctionalityrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV49Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV49Update);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionalityrole"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0)) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavUpdate_Link = formatLink("wwpbaseobjects.secfunctionalityrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV47Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV47Delete);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionalityrole"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0)) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavDelete_Link = formatLink("wwpbaseobjects.secfunctionalityrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecParentFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 34;
         }
         sendrow_342( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
         {
            DoAjaxLoad(34, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11342( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
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
            S152 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleSecFunctionalityRoleWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV56Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleSecFunctionalityRoleWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecRoleSecFunctionalityRoleWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV12GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0));
         AssignProp(sPrefix, false, cmbavSecfunctionalitytype_Internalname, "Values", cmbavSecfunctionalitytype.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38TFSecFunctionalityType_Sels", AV38TFSecFunctionalityType_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecRoleSecFunctionalityRoleWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV54FilterFullText = "";
         AssignAttri(sPrefix, false, "AV54FilterFullText", AV54FilterFullText);
         AV17SecFunctionalityType = 0;
         AssignAttri(sPrefix, false, "AV17SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV17SecFunctionalityType), 2, 0));
         AV35TFSecFunctionalityKey = "";
         AssignAttri(sPrefix, false, "AV35TFSecFunctionalityKey", AV35TFSecFunctionalityKey);
         AV36TFSecFunctionalityKey_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFSecFunctionalityKey_Sel", AV36TFSecFunctionalityKey_Sel);
         AV38TFSecFunctionalityType_Sels = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV39TFSecParentFunctionalityDescription = "";
         AssignAttri(sPrefix, false, "AV39TFSecParentFunctionalityDescription", AV39TFSecParentFunctionalityDescription);
         AV40TFSecParentFunctionalityDescription_Sel = "";
         AssignAttri(sPrefix, false, "AV40TFSecParentFunctionalityDescription_Sel", AV40TFSecParentFunctionalityDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV31Session.Get(AV56Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV54FilterFullText", AV54FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV17SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV17SecFunctionalityType), 2, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV35TFSecFunctionalityKey = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFSecFunctionalityKey", AV35TFSecFunctionalityKey);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV36TFSecFunctionalityKey_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFSecFunctionalityKey_Sel", AV36TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV37TFSecFunctionalityType_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFSecFunctionalityType_SelsJson", AV37TFSecFunctionalityType_SelsJson);
               AV38TFSecFunctionalityType_Sels.FromJSonString(AV37TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV39TFSecParentFunctionalityDescription = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFSecParentFunctionalityDescription", AV39TFSecParentFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV40TFSecParentFunctionalityDescription_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFSecParentFunctionalityDescription_Sel", AV40TFSecParentFunctionalityDescription_Sel);
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)),  AV36TFSecFunctionalityKey_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)),  AV40TFSecParentFunctionalityDescription_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+((AV38TFSecFunctionalityType_Sels.Count==0) ? "" : AV37TFSecFunctionalityType_SelsJson)+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecFunctionalityKey)),  AV35TFSecFunctionalityKey, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecParentFunctionalityDescription)),  AV39TFSecParentFunctionalityDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|||"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV31Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)),  0,  AV54FilterFullText,  AV54FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "SECFUNCTIONALITYTYPE",  "Functionality Type",  !(0==AV17SecFunctionalityType),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17SecFunctionalityType), 2, 0)),  StringUtil.Trim( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV17SecFunctionalityType)),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSECFUNCTIONALITYKEY",  "Functionality Key",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecFunctionalityKey)),  0,  AV35TFSecFunctionalityKey,  AV35TFSecFunctionalityKey,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)),  AV36TFSecFunctionalityKey_Sel,  AV36TFSecFunctionalityKey_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFSECFUNCTIONALITYTYPE_SEL",  "Functionality Type",  !(AV38TFSecFunctionalityType_Sels.Count==0),  0,  AV38TFSecFunctionalityType_Sels.ToJSonString(false),  ((AV38TFSecFunctionalityType_Sels.Count==1) ? StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFSecFunctionalityType_Sels.GetNumeric(1)), 10, 0)), "Mode", "Action", "Tab", "Object", "Attribute", "", "", "", "") : "Vários valores"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSECPARENTFUNCTIONALITYDESCRIPTION",  "Parent Functionality",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecParentFunctionalityDescription)),  0,  AV39TFSecParentFunctionalityDescription,  AV39TFSecParentFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)),  AV40TFSecParentFunctionalityDescription_Sel,  AV40TFSecParentFunctionalityDescription_Sel) ;
         if ( ! (0==AV8SecRoleId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&SECROLEID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8SecRoleId), 4, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV56Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecFunctionalityRole";
         AV11TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "SecRoleId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8SecRoleId), 4, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV31Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
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
         PA342( ) ;
         WS342( ) ;
         WE342( ) ;
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
         sCtrlAV8SecRoleId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA342( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\secrolesecfunctionalityrolewc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA342( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8SecRoleId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
         }
         wcpOAV8SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8SecRoleId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8SecRoleId != wcpOAV8SecRoleId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8SecRoleId = AV8SecRoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8SecRoleId = cgiGet( sPrefix+"AV8SecRoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV8SecRoleId) > 0 )
         {
            AV8SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8SecRoleId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
         }
         else
         {
            AV8SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8SecRoleId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA342( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS342( ) ;
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
         WS342( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8SecRoleId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecRoleId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8SecRoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8SecRoleId_CTRL", StringUtil.RTrim( sCtrlAV8SecRoleId));
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
         WE342( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019125336", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secrolesecfunctionalityrolewc.js", "?202561019125337", false, true);
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

      protected void SubsflControlProps_342( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_34_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_34_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_34_idx;
         edtSecFunctionalityId_Internalname = sPrefix+"SECFUNCTIONALITYID_"+sGXsfl_34_idx;
         edtSecFunctionalityKey_Internalname = sPrefix+"SECFUNCTIONALITYKEY_"+sGXsfl_34_idx;
         cmbSecFunctionalityType_Internalname = sPrefix+"SECFUNCTIONALITYTYPE_"+sGXsfl_34_idx;
         edtSecFunctionalityDescription_Internalname = sPrefix+"SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_34_idx;
         edtSecParentFunctionalityDescription_Internalname = sPrefix+"SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_34_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_34_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_34_fel_idx;
         edtSecFunctionalityId_Internalname = sPrefix+"SECFUNCTIONALITYID_"+sGXsfl_34_fel_idx;
         edtSecFunctionalityKey_Internalname = sPrefix+"SECFUNCTIONALITYKEY_"+sGXsfl_34_fel_idx;
         cmbSecFunctionalityType_Internalname = sPrefix+"SECFUNCTIONALITYTYPE_"+sGXsfl_34_fel_idx;
         edtSecFunctionalityDescription_Internalname = sPrefix+"SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_34_fel_idx;
         edtSecParentFunctionalityDescription_Internalname = sPrefix+"SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         WB340( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV55Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV49Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV47Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A130SecFunctionalityKey,StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_34_idx;
            cmbSecFunctionalityType.Name = GXCCtl;
            cmbSecFunctionalityType.WebTags = "";
            cmbSecFunctionalityType.addItem("1", "Mode", 0);
            cmbSecFunctionalityType.addItem("2", "Action", 0);
            cmbSecFunctionalityType.addItem("3", "Tab", 0);
            cmbSecFunctionalityType.addItem("4", "Object", 0);
            cmbSecFunctionalityType.addItem("5", "Attribute", 0);
            if ( cmbSecFunctionalityType.ItemCount > 0 )
            {
               A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
               n136SecFunctionalityType = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecFunctionalityType,(string)cmbSecFunctionalityType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0)),(short)1,(string)cmbSecFunctionalityType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
            AssignProp(sPrefix, false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_34_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescription_Internalname,(string)A138SecParentFunctionalityDescription,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecParentFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes342( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void init_web_controls( )
      {
         cmbavSecfunctionalitytype.Name = "vSECFUNCTIONALITYTYPE";
         cmbavSecfunctionalitytype.WebTags = "";
         cmbavSecfunctionalitytype.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 2, 0)), "Todos", 0);
         cmbavSecfunctionalitytype.addItem("1", "Mode", 0);
         cmbavSecfunctionalitytype.addItem("2", "Action", 0);
         cmbavSecfunctionalitytype.addItem("3", "Tab", 0);
         cmbavSecfunctionalitytype.addItem("4", "Object", 0);
         cmbavSecfunctionalitytype.addItem("5", "Attribute", 0);
         if ( cmbavSecfunctionalitytype.ItemCount > 0 )
         {
         }
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_34_idx;
         cmbSecFunctionalityType.Name = GXCCtl;
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", "Mode", 0);
         cmbSecFunctionalityType.addItem("2", "Action", 0);
         cmbSecFunctionalityType.addItem("3", "Tab", 0);
         cmbSecFunctionalityType.addItem("4", "Object", 0);
         cmbSecFunctionalityType.addItem("5", "Attribute", 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl34( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"34\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Functionality Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Functionality Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Functionality Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Functionality Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV55Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV49Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV47Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A130SecFunctionalityKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A138SecParentFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecParentFunctionalityDescription_Link));
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
         cmbavSecfunctionalitytype_Internalname = sPrefix+"vSECFUNCTIONALITYTYPE";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtSecFunctionalityId_Internalname = sPrefix+"SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = sPrefix+"SECFUNCTIONALITYKEY";
         cmbSecFunctionalityType_Internalname = sPrefix+"SECFUNCTIONALITYTYPE";
         edtSecFunctionalityDescription_Internalname = sPrefix+"SECFUNCTIONALITYDESCRIPTION";
         edtSecParentFunctionalityDescription_Internalname = sPrefix+"SECPARENTFUNCTIONALITYDESCRIPTION";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtSecRoleId_Internalname = sPrefix+"SECROLEID";
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
         edtSecParentFunctionalityDescription_Jsonclick = "";
         edtSecParentFunctionalityDescription_Link = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Link = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtSecRoleId_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         subGrid_Sortable = 0;
         edtSecRoleId_Jsonclick = "";
         edtSecRoleId_Visible = 1;
         cmbavSecfunctionalitytype_Jsonclick = "";
         cmbavSecfunctionalitytype.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecRoleSecFunctionalityRoleWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|1:Mode,2:Action,3:Tab,4:Object,5:Attribute||";
         Ddo_grid_Allowmultipleselection = "|T||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues||Dynamic";
         Ddo_grid_Includedatalist = "T|T||T";
         Ddo_grid_Filtertype = "Character|||Character";
         Ddo_grid_Includefilter = "T|||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "3|4|2|5";
         Ddo_grid_Columnids = "4:SecFunctionalityKey|5:SecFunctionalityType|6:SecFunctionalityDescription|7:SecParentFunctionalityDescription";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12342","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13342","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14342","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E17342","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV55Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV49Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV47Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtSecFunctionalityDescription_Link","ctrl":"SECFUNCTIONALITYDESCRIPTION","prop":"Link"},{"av":"edtSecParentFunctionalityDescription_Link","ctrl":"SECPARENTFUNCTIONALITYDESCRIPTION","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11342","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV54FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV17SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"AV35TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV36TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV39TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV40TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV37TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VALIDV_SECFUNCTIONALITYTYPE","""{"handler":"Validv_Secfunctionalitytype","iparms":[]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secparentfunctionalitydescription","iparms":[]}""");
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
         sPrefix = "";
         AV54FilterFullText = "";
         AV56Pgmname = "";
         AV35TFSecFunctionalityKey = "";
         AV36TFSecFunctionalityKey_Sel = "";
         AV38TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV39TFSecParentFunctionalityDescription = "";
         AV40TFSecParentFunctionalityDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV41DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37TFSecFunctionalityType_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableheader = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV55Display = "";
         AV49Update = "";
         AV47Delete = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         GXDecQS = "";
         lV54FilterFullText = "";
         lV35TFSecFunctionalityKey = "";
         lV39TFSecParentFunctionalityDescription = "";
         H00342_A129SecParentFunctionalityId = new long[1] ;
         H00342_n129SecParentFunctionalityId = new bool[] {false} ;
         H00342_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         H00342_A131SecRoleId = new short[1] ;
         H00342_A138SecParentFunctionalityDescription = new string[] {""} ;
         H00342_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H00342_A135SecFunctionalityDescription = new string[] {""} ;
         H00342_n135SecFunctionalityDescription = new bool[] {false} ;
         H00342_A136SecFunctionalityType = new short[1] ;
         H00342_n136SecFunctionalityType = new bool[] {false} ;
         H00342_A130SecFunctionalityKey = new string[] {""} ;
         H00342_n130SecFunctionalityKey = new bool[] {false} ;
         H00342_A128SecFunctionalityId = new long[1] ;
         H00343_AGRID_nRecordCount = new long[1] ;
         hsh = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char2 = "";
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8SecRoleId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolesecfunctionalityrolewc__default(),
            new Object[][] {
                new Object[] {
               H00342_A129SecParentFunctionalityId, H00342_n129SecParentFunctionalityId, H00342_A735SecFunctionalityRoleAtivo, H00342_A131SecRoleId, H00342_A138SecParentFunctionalityDescription, H00342_n138SecParentFunctionalityDescription, H00342_A135SecFunctionalityDescription, H00342_n135SecFunctionalityDescription, H00342_A136SecFunctionalityType, H00342_n136SecFunctionalityType,
               H00342_A130SecFunctionalityKey, H00342_n130SecFunctionalityKey, H00342_A128SecFunctionalityId
               }
               , new Object[] {
               H00343_AGRID_nRecordCount
               }
            }
         );
         AV56Pgmname = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
         /* GeneXus formulas. */
         AV56Pgmname = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short AV8SecRoleId ;
      private short wcpOAV8SecRoleId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15OrderedBy ;
      private short AV17SecFunctionalityType ;
      private short AV34ManageFiltersExecutionStep ;
      private short A131SecRoleId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A136SecFunctionalityType ;
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
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_34 ;
      private int nGXsfl_34_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int edtSecRoleId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV38TFSecFunctionalityType_Sels_Count ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecParentFunctionalityDescription_Enabled ;
      private int edtSecRoleId_Enabled ;
      private int AV43PageToGo ;
      private int AV57GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44GridCurrentPage ;
      private long AV45GridPageCount ;
      private long A128SecFunctionalityId ;
      private long GRID_nCurrentRecord ;
      private long A129SecParentFunctionalityId ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_34_idx="0001" ;
      private string AV56Pgmname ;
      private string edtavDisplay_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
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
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
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
      private string cmbavSecfunctionalitytype_Internalname ;
      private string cmbavSecfunctionalitytype_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtSecRoleId_Internalname ;
      private string edtSecRoleId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV55Display ;
      private string AV49Update ;
      private string AV47Delete ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string edtSecParentFunctionalityDescription_Internalname ;
      private string GXDecQS ;
      private string hsh ;
      private string edtavDisplay_Link ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtSecFunctionalityDescription_Link ;
      private string edtSecParentFunctionalityDescription_Link ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sCtrlAV8SecRoleId ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string edtSecParentFunctionalityDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool bGXsfl_34_Refreshing=false ;
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
      private bool n130SecFunctionalityKey ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool n138SecParentFunctionalityDescription ;
      private bool gxdyncontrolsrefreshing ;
      private bool n129SecParentFunctionalityId ;
      private bool A735SecFunctionalityRoleAtivo ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV37TFSecFunctionalityType_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV54FilterFullText ;
      private string AV35TFSecFunctionalityKey ;
      private string AV36TFSecFunctionalityKey_Sel ;
      private string AV39TFSecParentFunctionalityDescription ;
      private string AV40TFSecParentFunctionalityDescription_Sel ;
      private string AV46GridAppliedFilters ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string lV54FilterFullText ;
      private string lV35TFSecFunctionalityKey ;
      private string lV39TFSecParentFunctionalityDescription ;
      private IGxSession AV31Session ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSecfunctionalitytype ;
      private GXCombobox cmbSecFunctionalityType ;
      private GxSimpleCollection<short> AV38TFSecFunctionalityType_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV41DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H00342_A129SecParentFunctionalityId ;
      private bool[] H00342_n129SecParentFunctionalityId ;
      private bool[] H00342_A735SecFunctionalityRoleAtivo ;
      private short[] H00342_A131SecRoleId ;
      private string[] H00342_A138SecParentFunctionalityDescription ;
      private bool[] H00342_n138SecParentFunctionalityDescription ;
      private string[] H00342_A135SecFunctionalityDescription ;
      private bool[] H00342_n135SecFunctionalityDescription ;
      private short[] H00342_A136SecFunctionalityType ;
      private bool[] H00342_n136SecFunctionalityType ;
      private string[] H00342_A130SecFunctionalityKey ;
      private bool[] H00342_n130SecFunctionalityKey ;
      private long[] H00342_A128SecFunctionalityId ;
      private long[] H00343_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secrolesecfunctionalityrolewc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00342( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV38TFSecFunctionalityType_Sels ,
                                             string AV54FilterFullText ,
                                             short AV17SecFunctionalityType ,
                                             string AV36TFSecFunctionalityKey_Sel ,
                                             string AV35TFSecFunctionalityKey ,
                                             int AV38TFSecFunctionalityType_Sels_Count ,
                                             string AV40TFSecParentFunctionalityDescription_Sel ,
                                             string AV39TFSecParentFunctionalityDescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV8SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityRoleAtivo, T1.SecRoleId, T3.SecFunctionalityDescription AS SecParentFunctionalityDescription, T2.SecFunctionalityDescription, T2.SecFunctionalityType, T2.SecFunctionalityKey, T1.SecFunctionalityId";
         sFromString = " FROM ((SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) LEFT JOIN SecFunctionality T3 ON T3.SecFunctionalityId = T2.SecParentFunctionalityId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV8SecRoleId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityKey like '%' || :lV54FilterFullText) or ( 'mode' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV54FilterFullText) or ( T3.SecFunctionalityDescription like '%' || :lV54FilterFullText))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV17SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityType = :AV17SecFunctionalityType)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey like :lV35TFSecFunctionalityKey)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV36TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey = ( :AV36TFSecFunctionalityKey_Sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityKey))=0))");
         }
         if ( AV38TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38TFSecFunctionalityType_Sels, "T2.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription like :lV39TFSecParentFunctionalityDescription)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV40TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription = ( :AV40TFSecParentFunctionalityDescription_Sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecFunctionalityDescription))=0))");
         }
         if ( AV15OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityRoleAtivo, T1.SecFunctionalityId, T1.SecRoleId";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecFunctionalityKey, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecFunctionalityKey DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecFunctionalityType, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecFunctionalityType DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T3.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T3.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId, T1.SecRoleId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00343( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV38TFSecFunctionalityType_Sels ,
                                             string AV54FilterFullText ,
                                             short AV17SecFunctionalityType ,
                                             string AV36TFSecFunctionalityKey_Sel ,
                                             string AV35TFSecFunctionalityKey ,
                                             int AV38TFSecFunctionalityType_Sels_Count ,
                                             string AV40TFSecParentFunctionalityDescription_Sel ,
                                             string AV39TFSecParentFunctionalityDescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV8SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) LEFT JOIN SecFunctionality T3 ON T3.SecFunctionalityId = T2.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV8SecRoleId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityKey like '%' || :lV54FilterFullText) or ( 'mode' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV54FilterFullText) and T2.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV54FilterFullText) or ( T3.SecFunctionalityDescription like '%' || :lV54FilterFullText))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV17SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityType = :AV17SecFunctionalityType)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey like :lV35TFSecFunctionalityKey)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV36TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey = ( :AV36TFSecFunctionalityKey_Sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityKey))=0))");
         }
         if ( AV38TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38TFSecFunctionalityType_Sels, "T2.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription like :lV39TFSecParentFunctionalityDescription)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV40TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription = ( :AV40TFSecParentFunctionalityDescription_Sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
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
                     return conditional_H00342(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
               case 1 :
                     return conditional_H00343(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmH00342;
          prmH00342 = new Object[] {
          new ParDef("AV8SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV17SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("lV35TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("AV36TFSecFunctionalityKey_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV39TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("AV40TFSecParentFunctionalityDescription_Sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00343;
          prmH00343 = new Object[] {
          new ParDef("AV8SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV54FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV17SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("lV35TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("AV36TFSecFunctionalityKey_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV39TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("AV40TFSecParentFunctionalityDescription_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00342", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00342,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00343", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00343,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((long[]) buf[12])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
