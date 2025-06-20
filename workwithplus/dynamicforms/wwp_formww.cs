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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formww : GXDataArea
   {
      public wwp_formww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations )
      {
         this.AV47WWPFormType = aP0_WWPFormType;
         this.AV48WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridactiongroup1 = new GXCombobox();
         cmbWWPFormType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormType");
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
               gxfirstwebparm = GetFirstPar( "WWPFormType");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormType");
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
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         edtWWPFormTitle_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtavFilledoutforms_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavFilledoutforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilledoutforms_Visible), 5, 0), !bGXsfl_43_Refreshing);
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
         AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV18OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         AV47WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         AV48WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV49Pgmname = GetPar( "Pgmname");
         AV35TFWWPFormReferenceName = GetPar( "TFWWPFormReferenceName");
         AV36TFWWPFormReferenceName_Sel = GetPar( "TFWWPFormReferenceName_Sel");
         AV37TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV38TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         edtWWPFormTitle_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtavFilledoutforms_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavFilledoutforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilledoutforms_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV41FilledOutForms = (short)(Math.Round(NumberUtil.Val( GetPar( "FilledOutForms"), "."), 18, MidpointRounding.ToEven));
         AV40WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.FromJSonString( GetNextPar( ));
         A290WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
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
         PA0Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Y2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_formww"+UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV48WWPFormIsForDynamicValidations));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_formww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV48WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV48WWPFormIsForDynamicValidations, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A290WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_formww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV18OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV34GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV18OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME", AV35TFWWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME_SEL", AV36TFWWPFormReferenceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE", AV37TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE_SEL", AV38TFWWPFormTitle_Sel);
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV48WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV48WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV15GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV15GridState);
         }
         GxWebStd.gx_hidden_field( context, "vRESULTMSG", AV11ResultMsg);
         GxWebStd.gx_hidden_field( context, "vWWPFORMID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WWPFormId_Selected), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107WWPFormLatestVersionNumber), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Width", StringUtil.RTrim( Importform_modal_Width));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Title", StringUtil.RTrim( Importform_modal_Title));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Confirmtype", StringUtil.RTrim( Importform_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Bodytype", StringUtil.RTrim( Importform_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vFILLEDOUTFORMS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Y2( ) ;
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_formww"+UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV48WWPFormIsForDynamicValidations));
         return formatLink("workwithplus.dynamicforms.wwp_formww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_FormWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Formul�rios din�micos" ;
      }

      protected void WB0Y0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnimportform_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Formul�rio de importa��o", bttBtnimportform_Jsonclick, 7, "Formul�rio de importa��o", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110y1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV27ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
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
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV32GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV33GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV34GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A290WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            wb_table1_59_0Y2( true) ;
         }
         else
         {
            wb_table1_59_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_59_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_64_0Y2( true) ;
         }
         else
         {
            wb_table2_64_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0071"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0071"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_43_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0071"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 43 )
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

      protected void START0Y2( )
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
         Form.Meta.addItem("description", "Formul�rios din�micos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Y0( ) ;
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                              E120Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E130Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E140Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E150Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_udelete.Close */
                              E160Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Close */
                              E170Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Onloadcomponent */
                              E180Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E190Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E200Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E210Y2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
                              A94WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A95WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A96WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A97WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILLEDOUTFORMS");
                                 GX_FocusControl = edtavFilledoutforms_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV41FilledOutForms = 0;
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
                              }
                              else
                              {
                                 AV41FilledOutForms = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E220Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E230Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E240Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E250Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV17OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 71 )
                        {
                           OldWwpaux_wc = cgiGet( "W0071");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0071", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Y2( )
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

      protected void PA0Y2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_formww")), "workwithplus.dynamicforms.wwp_formww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_formww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV47WWPFormType = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV47WWPFormType", StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV48WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                        AssignAttri("", false, "AV48WWPFormIsForDynamicValidations", AV48WWPFormIsForDynamicValidations);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV48WWPFormIsForDynamicValidations, context));
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
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV17OrderedBy ,
                                       bool AV18OrderedDsc ,
                                       string AV19FilterFullText ,
                                       short AV47WWPFormType ,
                                       bool AV48WWPFormIsForDynamicValidations ,
                                       short AV29ManageFiltersExecutionStep ,
                                       string AV49Pgmname ,
                                       string AV35TFWWPFormReferenceName ,
                                       string AV36TFWWPFormReferenceName_Sel ,
                                       string AV37TFWWPFormTitle ,
                                       string AV38TFWWPFormTitle_Sel ,
                                       short AV41FilledOutForms ,
                                       short AV40WWPFormId ,
                                       short A290WWPFormType )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A290WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_formww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFILLEDOUTFORMS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A94WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A97WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE", A97WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A95WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A96WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMREFERENCENAME", A96WWPFormReferenceName);
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
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A290WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A290WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19FilterFullText ,
                                              AV36TFWWPFormReferenceName_Sel ,
                                              AV35TFWWPFormReferenceName ,
                                              AV38TFWWPFormTitle_Sel ,
                                              AV37TFWWPFormTitle ,
                                              AV47WWPFormType ,
                                              AV48WWPFormIsForDynamicValidations ,
                                              A96WWPFormReferenceName ,
                                              A97WWPFormTitle ,
                                              A292WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A290WWPFormType ,
                                              A95WWPFormVersionNumber ,
                                              A107WWPFormLatestVersionNumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV35TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV35TFWWPFormReferenceName), "%", "");
         lV37TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV37TFWWPFormTitle), "%", "");
         /* Using cursor H000Y3 */
         pr_default.execute(0, new Object[] {AV47WWPFormType, lV19FilterFullText, lV19FilterFullText, lV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, lV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A292WWPFormIsForDynamicValidations = H000Y3_A292WWPFormIsForDynamicValidations[0];
            A290WWPFormType = H000Y3_A290WWPFormType[0];
            AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
            A97WWPFormTitle = H000Y3_A97WWPFormTitle[0];
            A96WWPFormReferenceName = H000Y3_A96WWPFormReferenceName[0];
            A95WWPFormVersionNumber = H000Y3_A95WWPFormVersionNumber[0];
            A40000GXC1 = H000Y3_A40000GXC1[0];
            n40000GXC1 = H000Y3_n40000GXC1[0];
            A94WWPFormId = H000Y3_A94WWPFormId[0];
            A40000GXC1 = H000Y3_A40000GXC1[0];
            n40000GXC1 = H000Y3_n40000GXC1[0];
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri("", false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
            if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E230Y2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV19FilterFullText ,
                                                 AV36TFWWPFormReferenceName_Sel ,
                                                 AV35TFWWPFormReferenceName ,
                                                 AV38TFWWPFormTitle_Sel ,
                                                 AV37TFWWPFormTitle ,
                                                 AV47WWPFormType ,
                                                 AV48WWPFormIsForDynamicValidations ,
                                                 A96WWPFormReferenceName ,
                                                 A97WWPFormTitle ,
                                                 A292WWPFormIsForDynamicValidations ,
                                                 A40000GXC1 ,
                                                 AV17OrderedBy ,
                                                 AV18OrderedDsc ,
                                                 A290WWPFormType ,
                                                 A95WWPFormVersionNumber ,
                                                 A107WWPFormLatestVersionNumber } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
            lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
            lV35TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV35TFWWPFormReferenceName), "%", "");
            lV37TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV37TFWWPFormTitle), "%", "");
            /* Using cursor H000Y5 */
            pr_default.execute(1, new Object[] {AV47WWPFormType, lV19FilterFullText, lV19FilterFullText, lV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, lV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A292WWPFormIsForDynamicValidations = H000Y5_A292WWPFormIsForDynamicValidations[0];
               A290WWPFormType = H000Y5_A290WWPFormType[0];
               AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
               A97WWPFormTitle = H000Y5_A97WWPFormTitle[0];
               A96WWPFormReferenceName = H000Y5_A96WWPFormReferenceName[0];
               A95WWPFormVersionNumber = H000Y5_A95WWPFormVersionNumber[0];
               A40000GXC1 = H000Y5_A40000GXC1[0];
               n40000GXC1 = H000Y5_n40000GXC1[0];
               A94WWPFormId = H000Y5_A94WWPFormId[0];
               A40000GXC1 = H000Y5_A40000GXC1[0];
               n40000GXC1 = H000Y5_n40000GXC1[0];
               GXt_int1 = A107WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
               A107WWPFormLatestVersionNumber = GXt_int1;
               AssignAttri("", false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
               if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
               {
                  /* Execute user event: Grid.Load */
                  E240Y2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 43;
            WB0Y0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A94WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, StringUtil.RTrim( context.localUtil.Format( A97WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A95WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, StringUtil.RTrim( context.localUtil.Format( A96WWPFormReferenceName, "")), context));
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E220Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV27ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV30DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."), 18, MidpointRounding.ToEven));
            AV32GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV33GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV34GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Dvelop_confirmpanel_udelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Title");
            Dvelop_confirmpanel_udelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext");
            Dvelop_confirmpanel_udelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_udelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_udelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_udelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_udelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype");
            Importform_modal_Width = cgiGet( "IMPORTFORM_MODAL_Width");
            Importform_modal_Title = cgiGet( "IMPORTFORM_MODAL_Title");
            Importform_modal_Confirmtype = cgiGet( "IMPORTFORM_MODAL_Confirmtype");
            Importform_modal_Bodytype = cgiGet( "IMPORTFORM_MODAL_Bodytype");
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
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_udelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Result");
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A290WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
            A290WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
            forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A290WWPFormType), "9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_formww:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV17OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
         E220Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E220Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV13HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Formul�rios din�micos";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         cmbWWPFormType.Visible = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV17OrderedBy < 1 )
         {
            AV17OrderedBy = 1;
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV30DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV30DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( AV47WWPFormType == 1 )
         {
            if ( AV48WWPFormIsForDynamicValidations )
            {
               Form.Caption = "Valida��es din�micas";
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
            else
            {
               Form.Caption = "Dynamic Sections";
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
         }
      }

      protected void E230Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV29ManageFiltersExecutionStep == 1 )
         {
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV29ManageFiltersExecutionStep == 2 )
         {
            AV29ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV32GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridCurrentPage), 10, 0));
         AV33GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV33GridPageCount", StringUtil.LTrimStr( (decimal)(AV33GridPageCount), 10, 0));
         GXt_char3 = AV34GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char3) ;
         AV34GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV34GridAppliedFilters", AV34GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E130Y2( )
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
            AV31PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV31PageToGo) ;
         }
      }

      protected void E140Y2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E150Y2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            AV18OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormReferenceName") == 0 )
            {
               AV35TFWWPFormReferenceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
               AV36TFWWPFormReferenceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV37TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
               AV38TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E240Y2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( AV47WWPFormType == 0 )
            {
               AV40WWPFormId = A94WWPFormId;
               AssignAttri("", false, "AV40WWPFormId", StringUtil.LTrimStr( (decimal)(AV40WWPFormId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
               /* Execute user subroutine: 'COUNTFILLEDOUTFORMS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
            if ( ( AV41FilledOutForms == 0 ) && ( AV47WWPFormType == 0 ) )
            {
               cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", "Mostrar", "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", "Formul�rio de exporta��o", "fas fa-file-export", "", "", "", "", "", "", ""), 0);
            if ( AV47WWPFormType == 0 )
            {
               cmbavGridactiongroup1.addItem("5", StringUtil.Format( "%1;%2", "Preencha um formul�rio", "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
            }
            if ( ( AV47WWPFormType == 0 ) && ( AV41FilledOutForms > 0 ) )
            {
               cmbavGridactiongroup1.addItem("6", StringUtil.Format( "%1;%2", "Visualiza��o completa dos formul�rios", "fab fa-wpforms", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactiongroup1.addItem("7", StringUtil.Format( "%1;%2", "Copiar formul�rio", "far fa-clone", "", "", "", "", "", "", ""), 0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_form"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A95WWPFormVersionNumber,4,0));
            edtWWPFormReferenceName_Link = formatLink("workwithplus.dynamicforms.wwp_form") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            sendrow_432( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
      }

      protected void E120Y2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
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
            S172 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV49Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV28ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV28ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV28ManageFiltersXml) ;
               AV15GridState.FromXml(AV28ManageFiltersXml, null, "", "");
               AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
               AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
      }

      protected void E250Y2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV39GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO EXPORTFORM' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 5 )
         {
            /* Execute user subroutine: 'DO FILLOUTAFORM' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 6 )
         {
            /* Execute user subroutine: 'DO FILLEDOUTFORMS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 7 )
         {
            /* Execute user subroutine: 'DO COPY' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV39GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E160Y2( )
      {
         /* Dvelop_confirmpanel_udelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E190Y2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E180Y2( )
      {
         /* Importform_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_SelectImportFile")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_selectimportfile", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_SelectImportFile";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_SelectImportFile";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0071",(string)"","WorkWithPlus.DynamicForms.WWP_FormWW",(string)"JSON",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0071"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E170Y2( )
      {
         /* Importform_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E200Y2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwexport(context ).execute( out  AV20ExcelFilename, out  AV21ErrorMessage) ;
         if ( StringUtil.StrCmp(AV20ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV20ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV21ErrorMessage);
         }
      }

      protected void E210Y2( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         Innewwindow1_Target = formatLink("workwithplus.dynamicforms.wwp_formwwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV17OrderedBy), 4, 0))+":"+(AV18OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV47WWPFormType == 0 ) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV27ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV27ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV35TFWWPFormReferenceName = "";
         AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
         AV36TFWWPFormReferenceName_Sel = "";
         AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
         AV37TFWWPFormTitle = "";
         AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
         AV38TFWWPFormTitle_Sel = "";
         AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV48WWPFormIsForDynamicValidations )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicvalidations"+UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicvalidations") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform"+UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A290WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S222( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_udelete_Confirmationtext = StringUtil.Format( "Tem certeza de que deseja eliminar o formul�rio?", A97WWPFormTitle, "", "", "", "", "", "", "", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
         AV42WWPFormId_Selected = A94WWPFormId;
         AssignAttri("", false, "AV42WWPFormId_Selected", StringUtil.LTrimStr( (decimal)(AV42WWPFormId_Selected), 4, 0));
         AV43WWPFormVersionNumber_Selected = A95WWPFormVersionNumber;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S282( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV42WWPFormId_Selected) ;
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
      }

      protected void S232( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform"+UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S242( )
      {
         /* 'DO EXPORTFORM' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_export"+UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_df_export") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 2;
      }

      protected void S252( )
      {
         /* 'DO FILLOUTAFORM' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dynamicform"+UrlEncode(StringUtil.RTrim(A96WWPFormReferenceName)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS"));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_dynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO FILLEDOUTFORMS' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstanceww"+UrlEncode(StringUtil.LTrimStr(A94WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A97WWPFormTitle));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_forminstanceww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO COPY' Routine */
         returnInSub = false;
         AV5WWPForm.Load(A94WWPFormId, A95WWPFormVersionNumber);
         AV7CopyNumber = 1;
         AV8WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A96WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV8WWPFormReferenceName) )
         {
            AV7CopyNumber = (short)(AV7CopyNumber+1);
            AV8WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A96WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV9NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         /* Using cursor H000Y7 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A95WWPFormVersionNumber = H000Y7_A95WWPFormVersionNumber[0];
            A94WWPFormId = H000Y7_A94WWPFormId[0];
            A40000GXC1 = H000Y7_A40000GXC1[0];
            n40000GXC1 = H000Y7_n40000GXC1[0];
            A40000GXC1 = H000Y7_A40000GXC1[0];
            n40000GXC1 = H000Y7_n40000GXC1[0];
            AV9NewWWPForm.gxTpr_Wwpformid = A94WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV9NewWWPForm.gxTpr_Wwpformid = (short)(AV9NewWWPForm.gxTpr_Wwpformid+1);
         AV9NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV9NewWWPForm.gxTpr_Wwpformreferencename = AV8WWPFormReferenceName;
         AV9NewWWPForm.gxTpr_Wwpformtitle = AV5WWPForm.gxTpr_Wwpformtitle;
         AV9NewWWPForm.gxTpr_Wwpformiswizard = AV5WWPForm.gxTpr_Wwpformiswizard;
         AV9NewWWPForm.gxTpr_Wwpformvalidations = AV5WWPForm.gxTpr_Wwpformvalidations;
         AV9NewWWPForm.gxTpr_Wwpformresume = AV5WWPForm.gxTpr_Wwpformresume;
         AV9NewWWPForm.gxTpr_Wwpformresumemessage = AV5WWPForm.gxTpr_Wwpformresumemessage;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV5WWPForm.gxTpr_Element.Count )
         {
            AV6Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV5WWPForm.gxTpr_Element.Item(AV51GXV1));
            if ( AV6Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV9NewWWPForm.gxTpr_Element.Add(AV6Element, 0);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV9NewWWPForm.Insert() )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_formww",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Clonar formul�rio",  "O formul�rio foi clonado com sucesso.",  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV47WWPFormType, AV48WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV49Pgmname, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV41FilledOutForms, AV40WWPFormId, A290WWPFormType) ;
         }
         else
         {
            AV53GXV3 = 1;
            AV52GXV2 = AV9NewWWPForm.GetMessages();
            while ( AV53GXV3 <= AV52GXV2.Count )
            {
               AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV52GXV2.Item(AV53GXV3));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ResultMsg)) )
               {
                  AV11ResultMsg += StringUtil.NewLine( );
                  AssignAttri("", false, "AV11ResultMsg", AV11ResultMsg);
               }
               AV11ResultMsg += AV10Message.gxTpr_Description;
               AssignAttri("", false, "AV11ResultMsg", AV11ResultMsg);
               AV53GXV3 = (int)(AV53GXV3+1);
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Formul�rio de fechamento de erro",  AV11ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV26Session.Get(AV49Pgmname+"GridState"), null, "", "");
         }
         AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
         AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV54GXV4 = 1;
         while ( AV54GXV4 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV54GXV4));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV35TFWWPFormReferenceName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV36TFWWPFormReferenceName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV37TFWWPFormTitle = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV38TFWWPFormTitle_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
            }
            AV54GXV4 = (int)(AV54GXV4+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)),  AV36TFWWPFormReferenceName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)),  AV38TFWWPFormTitle_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)),  AV35TFWWPFormReferenceName, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)),  AV37TFWWPFormTitle, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV26Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Orderedby = AV17OrderedBy;
         AV15GridState.gxTpr_Ordereddsc = AV18OrderedDsc;
         AV15GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWWPFORMREFERENCENAME",  "Nome de referencia",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)),  0,  AV35TFWWPFormReferenceName,  AV35TFWWPFormReferenceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)),  AV36TFWWPFormReferenceName_Sel,  AV36TFWWPFormReferenceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWWPFORMTITLE",  "Qualifica��o",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)),  0,  AV37TFWWPFormTitle,  AV37TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)),  AV38TFWWPFormTitle_Sel,  AV38TFWWPFormTitle_Sel) ;
         if ( ! (0==AV47WWPFormType) )
         {
            AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV16GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV16GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0);
            AV15GridState.gxTpr_Filtervalues.Add(AV16GridStateFilterValue, 0);
         }
         if ( ! (false==AV48WWPFormIsForDynamicValidations) )
         {
            AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV16GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV16GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV48WWPFormIsForDynamicValidations);
            AV15GridState.gxTpr_Filtervalues.Add(AV16GridStateFilterValue, 0);
         }
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV14TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV14TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV14TrnContext.gxTpr_Callerondelete = true;
         AV14TrnContext.gxTpr_Callerurl = AV13HTTPRequest.ScriptName+"?"+AV13HTTPRequest.QueryString;
         AV14TrnContext.gxTpr_Transactionname = "WorkWithPlus.DynamicForms.WWP_Form";
         AV45TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV45TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV45TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0);
         AV14TrnContext.gxTpr_Attributes.Add(AV45TrnContextAtt, 0);
         AV26Session.Set("TrnContext", AV14TrnContext.ToXml(false, true, "", ""));
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV26Session.Get(AV49Pgmname+"GridState"), null, "", "");
         }
         if ( ! ( ( AV47WWPFormType == 0 ) ) )
         {
            edtWWPFormTitle_Visible = 0;
            AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_43_Refreshing);
            if ( new GeneXus.Programs.wwpbaseobjects.wwp_deletefilter(context).executeUdp( ref  AV15GridState,  "TFWWPFORMTITLE",  false) )
            {
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
            }
         }
         if ( ! ( ( AV47WWPFormType == 0 ) ) )
         {
            edtavFilledoutforms_Visible = 0;
            AssignProp("", false, edtavFilledoutforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilledoutforms_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
      }

      protected void S182( )
      {
         /* 'COUNTFILLEDOUTFORMS' Routine */
         returnInSub = false;
         AV41FilledOutForms = 0;
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         /* Optimized group. */
         /* Using cursor H000Y8 */
         pr_default.execute(3, new Object[] {AV40WWPFormId});
         cV41FilledOutForms = H000Y8_AV41FilledOutForms[0];
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(cV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(cV41FilledOutForms), "ZZZ9"), context));
         pr_default.close(3);
         AV41FilledOutForms = (short)(AV41FilledOutForms+cV41FilledOutForms*1);
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         /* End optimized group. */
      }

      protected void wb_table2_64_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableimportform_modal_Internalname, tblTableimportform_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucImportform_modal.SetProperty("Width", Importform_modal_Width);
            ucImportform_modal.SetProperty("Title", Importform_modal_Title);
            ucImportform_modal.SetProperty("ConfirmType", Importform_modal_Confirmtype);
            ucImportform_modal.SetProperty("BodyType", Importform_modal_Bodytype);
            ucImportform_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Importform_modal_Internalname, "IMPORTFORM_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"IMPORTFORM_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_0Y2e( true) ;
         }
         else
         {
            wb_table2_64_0Y2e( false) ;
         }
      }

      protected void wb_table1_59_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_udelete_Internalname, tblTabledvelop_confirmpanel_udelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_udelete.SetProperty("Title", Dvelop_confirmpanel_udelete_Title);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_udelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_udelete_Nobuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_udelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_udelete_Yesbuttonposition);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmType", Dvelop_confirmpanel_udelete_Confirmtype);
            ucDvelop_confirmpanel_udelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_udelete_Internalname, "DVELOP_CONFIRMPANEL_UDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_59_0Y2e( true) ;
         }
         else
         {
            wb_table1_59_0Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV47WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV47WWPFormType", StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         AV48WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri("", false, "AV48WWPFormIsForDynamicValidations", AV48WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV48WWPFormIsForDynamicValidations, context));
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019231720", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_formww.js", "?202561019231721", false, true);
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_43_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_43_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_43_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_43_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_43_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_43_fel_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_43_fel_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_43_fel_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_43_fel_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_43_fel_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WB0Y0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_43_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_43_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A94WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A96WWPFormReferenceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPFormReferenceName_Link,(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A97WWPFormTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormTitle_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavFilledoutforms_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFilledoutforms_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, ",", "")),StringUtil.LTrim( ((edtavFilledoutforms_Enabled!=0) ? context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9") : context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFilledoutforms_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavFilledoutforms_Visible,(int)edtavFilledoutforms_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0Y2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_43_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
         }
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", "Forma din�mica", 0);
         cmbWWPFormType.addItem("1", "Se��o din�mica", 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A290WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A290WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290WWPFormType), "9"), context));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.SendWebValue( "EU IA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Formul�rio # vers�o #") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome de referencia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Qualifica��o") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavFilledoutforms_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "# Formul�rios conclu�dos") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A96WWPFormReferenceName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWWPFormReferenceName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A97WWPFormTitle));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Visible), 5, 0, ".", "")));
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
         bttBtnexportreport_Internalname = "BTNEXPORTREPORT";
         bttBtnimportform_Internalname = "BTNIMPORTFORM";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
         Importform_modal_Internalname = "IMPORTFORM_MODAL";
         tblTableimportform_modal_Internalname = "TABLEIMPORTFORM_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         edtavFilledoutforms_Jsonclick = "";
         edtavFilledoutforms_Enabled = 1;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormReferenceName_Link = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         subGrid_Sortable = 0;
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Importform_modal_Bodytype = "WebComponent";
         Importform_modal_Confirmtype = "";
         Importform_modal_Title = "Select file to import";
         Importform_modal_Width = "400";
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "WWP_DF_DeleteFormMessage";
         Dvelop_confirmpanel_udelete_Title = "Eliminar a forma din�mica";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "WorkWithPlus.DynamicForms.WWP_FormWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2";
         Ddo_grid_Columnids = "3:WWPFormReferenceName|4:WWPFormTitle";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P�gina <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Dvpanel_tableheader_Title = "Op��es";
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
         Form.Caption = "Formul�rios din�micos";
         edtavFilledoutforms_Visible = -1;
         edtWWPFormTitle_Visible = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E130Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E140Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E150Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E240Y2","iparms":[{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"edtWWPFormReferenceName_Link","ctrl":"WWPFORMREFERENCENAME","prop":"Link"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E120Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E250Y2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"A97WWPFormTitle","fld":"WWPFORMTITLE","hsh":true,"type":"svchar"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"A96WWPFormReferenceName","fld":"WWPFORMREFERENCENAME","hsh":true,"type":"svchar"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV11ResultMsg","fld":"vRESULTMSG","type":"svchar"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"Dvelop_confirmpanel_udelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"ConfirmationText"},{"av":"AV42WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9","type":"int"},{"av":"AV11ResultMsg","fld":"vRESULTMSG","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE","""{"handler":"E160Y2","iparms":[{"av":"Dvelop_confirmpanel_udelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV42WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E190Y2","iparms":[{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOIMPORTFORM'","""{"handler":"E110Y1","iparms":[]}""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT","""{"handler":"E180Y2","iparms":[]""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE","""{"handler":"E170Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV48WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true,"type":"boolean"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME","type":"svchar"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL","type":"svchar"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE","type":"svchar"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL","type":"svchar"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbWWPFormType"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true,"type":"int"}]""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV15GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E200Y2","iparms":[]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E210Y2","iparms":[]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Filledoutforms","iparms":[]}""");
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
         Dvelop_confirmpanel_udelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV19FilterFullText = "";
         AV49Pgmname = "";
         AV35TFWWPFormReferenceName = "";
         AV36TFWWPFormReferenceName_Sel = "";
         AV37TFWWPFormTitle = "";
         AV38TFWWPFormTitle_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV27ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34GridAppliedFilters = "";
         AV30DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11ResultMsg = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         bttBtnexportreport_Jsonclick = "";
         bttBtnimportform_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         GXDecQS = "";
         lV19FilterFullText = "";
         lV35TFWWPFormReferenceName = "";
         lV37TFWWPFormTitle = "";
         H000Y3_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         H000Y3_A290WWPFormType = new short[1] ;
         H000Y3_A97WWPFormTitle = new string[] {""} ;
         H000Y3_A96WWPFormReferenceName = new string[] {""} ;
         H000Y3_A95WWPFormVersionNumber = new short[1] ;
         H000Y3_A40000GXC1 = new int[1] ;
         H000Y3_n40000GXC1 = new bool[] {false} ;
         H000Y3_A94WWPFormId = new short[1] ;
         H000Y5_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         H000Y5_A290WWPFormType = new short[1] ;
         H000Y5_A97WWPFormTitle = new string[] {""} ;
         H000Y5_A96WWPFormReferenceName = new string[] {""} ;
         H000Y5_A95WWPFormVersionNumber = new short[1] ;
         H000Y5_A40000GXC1 = new int[1] ;
         H000Y5_n40000GXC1 = new bool[] {false} ;
         H000Y5_A94WWPFormId = new short[1] ;
         hsh = "";
         AV13HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV28ManageFiltersXml = "";
         AV20ExcelFilename = "";
         AV21ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         AV5WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV8WWPFormReferenceName = "";
         AV9NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         H000Y7_A95WWPFormVersionNumber = new short[1] ;
         H000Y7_A94WWPFormId = new short[1] ;
         H000Y7_A40000GXC1 = new int[1] ;
         H000Y7_n40000GXC1 = new bool[] {false} ;
         AV6Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV52GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV26Session = context.GetSession();
         AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char3 = "";
         AV14TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV45TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         H000Y8_AV41FilledOutForms = new short[1] ;
         ucImportform_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formww__default(),
            new Object[][] {
                new Object[] {
               H000Y3_A292WWPFormIsForDynamicValidations, H000Y3_A290WWPFormType, H000Y3_A97WWPFormTitle, H000Y3_A96WWPFormReferenceName, H000Y3_A95WWPFormVersionNumber, H000Y3_A40000GXC1, H000Y3_n40000GXC1, H000Y3_A94WWPFormId
               }
               , new Object[] {
               H000Y5_A292WWPFormIsForDynamicValidations, H000Y5_A290WWPFormType, H000Y5_A97WWPFormTitle, H000Y5_A96WWPFormReferenceName, H000Y5_A95WWPFormVersionNumber, H000Y5_A40000GXC1, H000Y5_n40000GXC1, H000Y5_A94WWPFormId
               }
               , new Object[] {
               H000Y7_A95WWPFormVersionNumber, H000Y7_A94WWPFormId, H000Y7_A40000GXC1, H000Y7_n40000GXC1
               }
               , new Object[] {
               H000Y8_AV41FilledOutForms
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV49Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         /* GeneXus formulas. */
         AV49Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      private short AV47WWPFormType ;
      private short wcpOAV47WWPFormType ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
      private short AV41FilledOutForms ;
      private short AV40WWPFormId ;
      private short A290WWPFormType ;
      private short gxajaxcallmode ;
      private short AV42WWPFormId_Selected ;
      private short A107WWPFormLatestVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short AV39GridActionGroup1 ;
      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int1 ;
      private short gxcookieaux ;
      private short AV43WWPFormVersionNumber_Selected ;
      private short AV7CopyNumber ;
      private short cV41FilledOutForms ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtWWPFormTitle_Visible ;
      private int edtavFilledoutforms_Visible ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavFilledoutforms_Enabled ;
      private int A40000GXC1 ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int AV31PageToGo ;
      private int AV51GXV1 ;
      private int AV53GXV3 ;
      private int AV54GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV32GridCurrentPage ;
      private long AV33GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string edtWWPFormTitle_Internalname ;
      private string edtavFilledoutforms_Internalname ;
      private string AV49Pgmname ;
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
      private string Ddo_grid_Datalistproc ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Dvelop_confirmpanel_udelete_Title ;
      private string Dvelop_confirmpanel_udelete_Confirmationtext ;
      private string Dvelop_confirmpanel_udelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_udelete_Confirmtype ;
      private string Importform_modal_Width ;
      private string Importform_modal_Title ;
      private string Importform_modal_Confirmtype ;
      private string Importform_modal_Bodytype ;
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
      private string bttBtnexportreport_Internalname ;
      private string bttBtnexportreport_Jsonclick ;
      private string bttBtnimportform_Internalname ;
      private string bttBtnimportform_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string cmbWWPFormType_Jsonclick ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string GXDecQS ;
      private string hsh ;
      private string edtWWPFormReferenceName_Link ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTableimportform_modal_Internalname ;
      private string Importform_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtavFilledoutforms_Jsonclick ;
      private string subGrid_Header ;
      private bool AV48WWPFormIsForDynamicValidations ;
      private bool wcpOAV48WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool AV18OrderedDsc ;
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
      private bool A292WWPFormIsForDynamicValidations ;
      private bool n40000GXC1 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV28ManageFiltersXml ;
      private string AV19FilterFullText ;
      private string AV35TFWWPFormReferenceName ;
      private string AV36TFWWPFormReferenceName_Sel ;
      private string AV37TFWWPFormTitle ;
      private string AV38TFWWPFormTitle_Sel ;
      private string AV34GridAppliedFilters ;
      private string AV11ResultMsg ;
      private string A96WWPFormReferenceName ;
      private string A97WWPFormTitle ;
      private string lV19FilterFullText ;
      private string lV35TFWWPFormReferenceName ;
      private string lV37TFWWPFormTitle ;
      private string AV20ExcelFilename ;
      private string AV21ErrorMessage ;
      private string AV8WWPFormReferenceName ;
      private IGxSession AV26Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GXUserControl ucImportform_modal ;
      private GxHttpRequest AV13HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbWWPFormType ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV27ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV30DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV15GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H000Y3_A292WWPFormIsForDynamicValidations ;
      private short[] H000Y3_A290WWPFormType ;
      private string[] H000Y3_A97WWPFormTitle ;
      private string[] H000Y3_A96WWPFormReferenceName ;
      private short[] H000Y3_A95WWPFormVersionNumber ;
      private int[] H000Y3_A40000GXC1 ;
      private bool[] H000Y3_n40000GXC1 ;
      private short[] H000Y3_A94WWPFormId ;
      private bool[] H000Y5_A292WWPFormIsForDynamicValidations ;
      private short[] H000Y5_A290WWPFormType ;
      private string[] H000Y5_A97WWPFormTitle ;
      private string[] H000Y5_A96WWPFormReferenceName ;
      private short[] H000Y5_A95WWPFormVersionNumber ;
      private int[] H000Y5_A40000GXC1 ;
      private bool[] H000Y5_n40000GXC1 ;
      private short[] H000Y5_A94WWPFormId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV5WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV9NewWWPForm ;
      private short[] H000Y7_A95WWPFormVersionNumber ;
      private short[] H000Y7_A94WWPFormId ;
      private int[] H000Y7_A40000GXC1 ;
      private bool[] H000Y7_n40000GXC1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV6Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV52GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV14TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV45TrnContextAtt ;
      private short[] H000Y8_AV41FilledOutForms ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_formww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000Y3( IGxContext context ,
                                             string AV19FilterFullText ,
                                             string AV36TFWWPFormReferenceName_Sel ,
                                             string AV35TFWWPFormReferenceName ,
                                             string AV38TFWWPFormTitle_Sel ,
                                             string AV37TFWWPFormTitle ,
                                             short AV47WWPFormType ,
                                             bool AV48WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             short A290WWPFormType ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormIsForDynamicValidations, T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormReferenceName, T1.WWPFormVersionNumber, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV47WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV19FilterFullText) or ( T1.WWPFormTitle like '%' || :lV19FilterFullText))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV35TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV36TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV37TFWWPFormTitle)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV38TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV47WWPFormType == 1 ) && AV48WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV47WWPFormType == 1 ) && ! AV48WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormReferenceName DESC, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormTitle DESC, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H000Y5( IGxContext context ,
                                             string AV19FilterFullText ,
                                             string AV36TFWWPFormReferenceName_Sel ,
                                             string AV35TFWWPFormReferenceName ,
                                             string AV38TFWWPFormTitle_Sel ,
                                             string AV37TFWWPFormTitle ,
                                             short AV47WWPFormType ,
                                             bool AV48WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             short A290WWPFormType ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[7];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormIsForDynamicValidations, T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormReferenceName, T1.WWPFormVersionNumber, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV47WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV19FilterFullText) or ( T1.WWPFormTitle like '%' || :lV19FilterFullText))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV35TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV36TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV37TFWWPFormTitle)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV38TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV47WWPFormType == 1 ) && AV48WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV47WWPFormType == 1 ) && ! AV48WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormReferenceName DESC, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormId, T1.WWPFormVersionNumber";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormTitle DESC, T1.WWPFormId, T1.WWPFormVersionNumber";
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
                     return conditional_H000Y3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
               case 1 :
                     return conditional_H000Y5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Y7;
          prmH000Y7 = new Object[] {
          };
          Object[] prmH000Y8;
          prmH000Y8 = new Object[] {
          new ParDef("AV40WWPFormId",GXType.Int16,4,0)
          };
          Object[] prmH000Y3;
          prmH000Y3 = new Object[] {
          new ParDef("AV47WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV35TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV36TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV37TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV38TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          Object[] prmH000Y5;
          prmH000Y5 = new Object[] {
          new ParDef("AV47WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV35TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV36TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV37TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV38TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y7", "SELECT T1.WWPFormVersionNumber, T1.WWPFormId, COALESCE( T2.GXC1, 0) AS GXC1 FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) ORDER BY T1.WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000Y8", "SELECT COUNT(*) FROM WWP_FormInstance WHERE WWPFormId = :AV40WWPFormId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y8,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
