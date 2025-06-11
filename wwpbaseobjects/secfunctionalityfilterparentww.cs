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
   public class secfunctionalityfilterparentww : GXDataArea
   {
      public secfunctionalityfilterparentww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecParentFunctionalityId )
      {
         this.AV8SecParentFunctionalityId = aP0_SecParentFunctionalityId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavSecfunctionalitytype = new GXCombobox();
         cmbavSecfunctionalitydescriptionoperator = new GXCombobox();
         cmbSecFunctionalityType = new GXCombobox();
         chkSecFunctionalityActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SecParentFunctionalityId");
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
               gxfirstwebparm = GetFirstPar( "SecParentFunctionalityId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecParentFunctionalityId");
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
         nRC_GXsfl_59 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_59"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_59_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_59_idx = GetPar( "sGXsfl_59_idx");
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
         AV26OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV27OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV82FilterFullText = GetPar( "FilterFullText");
         cmbavSecfunctionalitytype.FromJSonString( GetNextPar( ));
         AV14SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityType"), "."), 18, MidpointRounding.ToEven));
         cmbavSecfunctionalitydescriptionoperator.FromJSonString( GetNextPar( ));
         AV28SecFunctionalityDescriptionOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityDescriptionOperator"), "."), 18, MidpointRounding.ToEven));
         AV13SecFunctionalityDescription = GetPar( "SecFunctionalityDescription");
         AV32ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV92Pgmname = GetPar( "Pgmname");
         AV8SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecParentFunctionalityId"), "."), 18, MidpointRounding.ToEven));
         AV39TFSecFunctionalityKey = GetPar( "TFSecFunctionalityKey");
         AV40TFSecFunctionalityKey_Sel = GetPar( "TFSecFunctionalityKey_Sel");
         AV43TFSecFunctionalityDescription = GetPar( "TFSecFunctionalityDescription");
         AV44TFSecFunctionalityDescription_Sel = GetPar( "TFSecFunctionalityDescription_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV78TFSecFunctionalityType_Sels);
         AV50TFSecParentFunctionalityDescription = GetPar( "TFSecParentFunctionalityDescription");
         AV51TFSecParentFunctionalityDescription_Sel = GetPar( "TFSecParentFunctionalityDescription_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
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
         PA2H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2H2( ) ;
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionalityfilterparentww"+UrlEncode(StringUtil.LTrimStr(AV8SecParentFunctionalityId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secfunctionalityfilterparentww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSECPARENTFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecParentFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECPARENTFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV27OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV82FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14SecFunctionalityType), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTIONOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION", AV13SecFunctionalityDescription);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_59", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_59), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV84GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECPARENTFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecParentFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECPARENTFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY", AV39TFSecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY_SEL", AV40TFSecFunctionalityKey_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION", AV43TFSecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION_SEL", AV44TFSecFunctionalityDescription_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSECFUNCTIONALITYTYPE_SELS", AV78TFSecFunctionalityType_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSECFUNCTIONALITYTYPE_SELS", AV78TFSecFunctionalityType_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSECPARENTFUNCTIONALITYDESCRIPTION", AV50TFSecParentFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL", AV51TFSecParentFunctionalityDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV27OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV24GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV24GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYTYPE_SELSJSON", AV77TFSecFunctionalityType_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            WE2H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2H2( ) ;
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionalityfilterparentww"+UrlEncode(StringUtil.LTrimStr(AV8SecParentFunctionalityId,10,0));
         return formatLink("wwpbaseobjects.secfunctionalityfilterparentww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecFunctionalityFilterParentWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Functionality" ;
      }

      protected void WB2H0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV82FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV82FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSecfunctionalitytype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecfunctionalitytype_Internalname, "Type", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecfunctionalitytype, cmbavSecfunctionalitytype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0)), 1, cmbavSecfunctionalitytype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecfunctionalitytype.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbavSecfunctionalitytype_Internalname, "Values", (string)(cmbavSecfunctionalitytype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextsecfunctionalitydescription_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextsecfunctionalitydescription_Internalname, "Description", "", "", lblFiltertextsecfunctionalitydescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_43_2H2( true) ;
         }
         else
         {
            wb_table1_43_2H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_2H2e( bool wbgen )
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
            StartGridControl59( ) ;
         }
         if ( wbEnd == 59 )
         {
            wbEnd = 0;
            nRC_GXsfl_59 = (int)(nGXsfl_59_idx-1);
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
            ucGridpaginationbar.SetProperty("AppliedFilters", AV84GridAppliedFilters);
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 59 )
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

      protected void START2H2( )
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
         Form.Meta.addItem("description", " Functionality", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2H0( ) ;
      }

      protected void WS2H2( )
      {
         START2H2( ) ;
         EVT2H2( ) ;
      }

      protected void EVT2H2( )
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
                              E112H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E142H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E152H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E162H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E172H2 ();
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
                              nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
                              SubsflControlProps_592( ) ;
                              AV29Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV29Display);
                              AV15Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV15Update);
                              AV16Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV16Delete);
                              A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
                              n130SecFunctionalityKey = false;
                              A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              n135SecFunctionalityDescription = false;
                              cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
                              cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
                              A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
                              n136SecFunctionalityType = false;
                              A129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n129SecParentFunctionalityId = false;
                              A138SecParentFunctionalityDescription = cgiGet( edtSecParentFunctionalityDescription_Internalname);
                              n138SecParentFunctionalityDescription = false;
                              A134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( chkSecFunctionalityActive_Internalname));
                              n134SecFunctionalityActive = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E202H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV26OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV82FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitytype Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECFUNCTIONALITYTYPE"), ",", ".") != Convert.ToDecimal( AV14SecFunctionalityType )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescriptionoperator Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTIONOPERATOR"), ",", ".") != Convert.ToDecimal( AV28SecFunctionalityDescriptionOperator )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION"), AV13SecFunctionalityDescription) != 0 )
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

      protected void WE2H2( )
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

      protected void PA2H2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secfunctionalityfilterparentww")), "wwpbaseobjects.secfunctionalityfilterparentww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secfunctionalityfilterparentww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "SecParentFunctionalityId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV8SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV8SecParentFunctionalityId), 10, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECPARENTFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
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
         SubsflControlProps_592( ) ;
         while ( nGXsfl_59_idx <= nRC_GXsfl_59 )
         {
            sendrow_592( ) ;
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV26OrderedBy ,
                                       bool AV27OrderedDsc ,
                                       string AV82FilterFullText ,
                                       short AV14SecFunctionalityType ,
                                       short AV28SecFunctionalityDescriptionOperator ,
                                       string AV13SecFunctionalityDescription ,
                                       short AV32ManageFiltersExecutionStep ,
                                       string AV92Pgmname ,
                                       long AV8SecParentFunctionalityId ,
                                       string AV39TFSecFunctionalityKey ,
                                       string AV40TFSecFunctionalityKey_Sel ,
                                       string AV43TFSecFunctionalityDescription ,
                                       string AV44TFSecFunctionalityDescription_Sel ,
                                       GxSimpleCollection<short> AV78TFSecFunctionalityType_Sels ,
                                       string AV50TFSecParentFunctionalityDescription ,
                                       string AV51TFSecParentFunctionalityDescription_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", "")));
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
            AV14SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbavSecfunctionalitytype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbavSecfunctionalitytype_Internalname, "Values", cmbavSecfunctionalitytype.ToJavascriptSource(), true);
         }
         if ( cmbavSecfunctionalitydescriptionoperator.ItemCount > 0 )
         {
            AV28SecFunctionalityDescriptionOperator = (short)(Math.Round(NumberUtil.Val( cmbavSecfunctionalitydescriptionoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28SecFunctionalityDescriptionOperator", StringUtil.LTrimStr( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecfunctionalitydescriptionoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
            AssignProp("", false, cmbavSecfunctionalitydescriptionoperator_Internalname, "Values", cmbavSecfunctionalitydescriptionoperator.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV92Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF2H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 59;
         /* Execute user event: Refresh */
         E192H2 ();
         nGXsfl_59_idx = 1;
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         bGXsfl_59_Refreshing = true;
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
            SubsflControlProps_592( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A136SecFunctionalityType ,
                                                 AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                                 AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                                 AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                                 AV28SecFunctionalityDescriptionOperator ,
                                                 AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                                 AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                                 AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                                 AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                                 AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                                 AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                                 AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                                 AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                                 A130SecFunctionalityKey ,
                                                 A135SecFunctionalityDescription ,
                                                 A138SecParentFunctionalityDescription ,
                                                 AV26OrderedBy ,
                                                 AV27OrderedDsc ,
                                                 A129SecParentFunctionalityId ,
                                                 AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
            lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
            lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
            lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
            lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
            lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
            /* Using cursor H002H2 */
            pr_default.execute(0, new Object[] {AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_59_idx = 1;
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A134SecFunctionalityActive = H002H2_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = H002H2_n134SecFunctionalityActive[0];
               A138SecParentFunctionalityDescription = H002H2_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H002H2_n138SecParentFunctionalityDescription[0];
               A129SecParentFunctionalityId = H002H2_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H002H2_n129SecParentFunctionalityId[0];
               A136SecFunctionalityType = H002H2_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H002H2_n136SecFunctionalityType[0];
               A135SecFunctionalityDescription = H002H2_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H002H2_n135SecFunctionalityDescription[0];
               A130SecFunctionalityKey = H002H2_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H002H2_n130SecFunctionalityKey[0];
               A128SecFunctionalityId = H002H2_A128SecFunctionalityId[0];
               A138SecParentFunctionalityDescription = H002H2_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H002H2_n138SecParentFunctionalityDescription[0];
               /* Execute user event: Grid.Load */
               E202H2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 59;
            WB2H0( ) ;
         }
         bGXsfl_59_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2H2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
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
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV28SecFunctionalityDescriptionOperator ,
                                              AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV26OrderedBy ,
                                              AV27OrderedDsc ,
                                              A129SecParentFunctionalityId ,
                                              AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor H002H3 */
         pr_default.execute(1, new Object[] {AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         GRID_nRecordCount = H002H3_AGRID_nRecordCount[0];
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
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV82FilterFullText, AV14SecFunctionalityType, AV28SecFunctionalityDescriptionOperator, AV13SecFunctionalityDescription, AV32ManageFiltersExecutionStep, AV92Pgmname, AV8SecParentFunctionalityId, AV39TFSecFunctionalityKey, AV40TFSecFunctionalityKey_Sel, AV43TFSecFunctionalityDescription, AV44TFSecFunctionalityDescription_Sel, AV78TFSecFunctionalityType_Sels, AV50TFSecParentFunctionalityDescription, AV51TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV92Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         chkSecFunctionalityActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV36ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV53DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_59 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), ",", "."), 18, MidpointRounding.ToEven));
            AV80GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV81GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV84GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
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
            /* Read variables values. */
            AV82FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV82FilterFullText", AV82FilterFullText);
            cmbavSecfunctionalitytype.Name = cmbavSecfunctionalitytype_Internalname;
            cmbavSecfunctionalitytype.CurrentValue = cgiGet( cmbavSecfunctionalitytype_Internalname);
            AV14SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecfunctionalitytype_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
            cmbavSecfunctionalitydescriptionoperator.Name = cmbavSecfunctionalitydescriptionoperator_Internalname;
            cmbavSecfunctionalitydescriptionoperator.CurrentValue = cgiGet( cmbavSecfunctionalitydescriptionoperator_Internalname);
            AV28SecFunctionalityDescriptionOperator = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecfunctionalitydescriptionoperator_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28SecFunctionalityDescriptionOperator", StringUtil.LTrimStr( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
            AV13SecFunctionalityDescription = cgiGet( edtavSecfunctionalitydescription_Internalname);
            AssignAttri("", false, "AV13SecFunctionalityDescription", AV13SecFunctionalityDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV26OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV82FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECFUNCTIONALITYTYPE"), ",", ".") != Convert.ToDecimal( AV14SecFunctionalityType )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTIONOPERATOR"), ",", ".") != Convert.ToDecimal( AV28SecFunctionalityDescriptionOperator )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION"), AV13SecFunctionalityDescription) != 0 )
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
         E182H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182H2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV9HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV14SecFunctionalityType = 0;
         AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Functionality";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
         if ( AV26OrderedBy < 1 )
         {
            AV26OrderedBy = 1;
            AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV53DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV53DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Using cursor H002H4 */
         pr_default.execute(2, new Object[] {AV8SecParentFunctionalityId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A129SecParentFunctionalityId = H002H4_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = H002H4_n129SecParentFunctionalityId[0];
            A138SecParentFunctionalityDescription = H002H4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = H002H4_n138SecParentFunctionalityDescription[0];
            A138SecParentFunctionalityDescription = H002H4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = H002H4_n138SecParentFunctionalityDescription[0];
            Form.Caption = StringUtil.Format( "Functionalities of Functionality :: %1", A138SecParentFunctionalityDescription, "", "", "", "", "", "", "", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void E192H2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV76WWPContext) ;
         if ( AV32ManageFiltersExecutionStep == 1 )
         {
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV32ManageFiltersExecutionStep == 2 )
         {
            AV32ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
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
         AV80GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV80GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV80GridCurrentPage), 10, 0));
         AV81GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV81GridPageCount", StringUtil.LTrimStr( (decimal)(AV81GridPageCount), 10, 0));
         GXt_char2 = AV84GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV92Pgmname, out  GXt_char2) ;
         AV84GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV84GridAppliedFilters", AV84GridAppliedFilters);
         AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV8SecParentFunctionalityId;
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV82FilterFullText;
         AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV14SecFunctionalityType;
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV13SecFunctionalityDescription;
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV39TFSecFunctionalityKey;
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV40TFSecFunctionalityKey_Sel;
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV43TFSecFunctionalityDescription;
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV44TFSecFunctionalityDescription_Sel;
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV78TFSecFunctionalityType_Sels;
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV50TFSecParentFunctionalityDescription;
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV51TFSecParentFunctionalityDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24GridState", AV24GridState);
      }

      protected void E122H2( )
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

      protected void E132H2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142H2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV26OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
            AV27OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
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
               AV39TFSecFunctionalityKey = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFSecFunctionalityKey", AV39TFSecFunctionalityKey);
               AV40TFSecFunctionalityKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFSecFunctionalityKey_Sel", AV40TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityDescription") == 0 )
            {
               AV43TFSecFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFSecFunctionalityDescription", AV43TFSecFunctionalityDescription);
               AV44TFSecFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFSecFunctionalityDescription_Sel", AV44TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityType") == 0 )
            {
               AV77TFSecFunctionalityType_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV77TFSecFunctionalityType_SelsJson", AV77TFSecFunctionalityType_SelsJson);
               AV78TFSecFunctionalityType_Sels.FromJSonString(StringUtil.StringReplace( AV77TFSecFunctionalityType_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecParentFunctionalityDescription") == 0 )
            {
               AV50TFSecParentFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFSecParentFunctionalityDescription", AV50TFSecParentFunctionalityDescription);
               AV51TFSecParentFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFSecParentFunctionalityDescription_Sel", AV51TFSecParentFunctionalityDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV78TFSecFunctionalityType_Sels", AV78TFSecFunctionalityType_Sels);
      }

      private void E202H2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV29Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV29Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavDisplay_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV15Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV15Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavUpdate_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV16Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV16Delete);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavDelete_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A129SecParentFunctionalityId,10,0));
         edtSecParentFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 59;
         }
         sendrow_592( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_59_Refreshing )
         {
            DoAjaxLoad(59, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112H2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecFunctionalityFilterParentWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV92Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecFunctionalityFilterParentWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecFunctionalityFilterParentWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV24GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV26OrderedBy = AV24GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
               AV27OrderedDsc = AV24GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24GridState", AV24GridState);
         cmbavSecfunctionalitytype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0));
         AssignProp("", false, cmbavSecfunctionalitytype_Internalname, "Values", cmbavSecfunctionalitytype.ToJavascriptSource(), true);
         cmbavSecfunctionalitydescriptionoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
         AssignProp("", false, cmbavSecfunctionalitydescriptionoperator_Internalname, "Values", cmbavSecfunctionalitydescriptionoperator.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV78TFSecFunctionalityType_Sels", AV78TFSecFunctionalityType_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E152H2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E162H2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwexport(context ).execute( out  AV30ExcelFilename, out  AV31ErrorMessage) ;
         if ( StringUtil.StrCmp(AV30ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV30ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV31ErrorMessage);
         }
      }

      protected void E172H2( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         Innewwindow1_Target = formatLink("wwpbaseobjects.secfunctionalityfilterparentwwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV26OrderedBy), 4, 0))+":"+(AV27OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV36ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecFunctionalityFilterParentWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV36ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV82FilterFullText = "";
         AssignAttri("", false, "AV82FilterFullText", AV82FilterFullText);
         AV14SecFunctionalityType = 0;
         AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
         AV28SecFunctionalityDescriptionOperator = 0;
         AssignAttri("", false, "AV28SecFunctionalityDescriptionOperator", StringUtil.LTrimStr( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
         AV13SecFunctionalityDescription = "";
         AssignAttri("", false, "AV13SecFunctionalityDescription", AV13SecFunctionalityDescription);
         AV39TFSecFunctionalityKey = "";
         AssignAttri("", false, "AV39TFSecFunctionalityKey", AV39TFSecFunctionalityKey);
         AV40TFSecFunctionalityKey_Sel = "";
         AssignAttri("", false, "AV40TFSecFunctionalityKey_Sel", AV40TFSecFunctionalityKey_Sel);
         AV43TFSecFunctionalityDescription = "";
         AssignAttri("", false, "AV43TFSecFunctionalityDescription", AV43TFSecFunctionalityDescription);
         AV44TFSecFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV44TFSecFunctionalityDescription_Sel", AV44TFSecFunctionalityDescription_Sel);
         AV78TFSecFunctionalityType_Sels = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV50TFSecParentFunctionalityDescription = "";
         AssignAttri("", false, "AV50TFSecParentFunctionalityDescription", AV50TFSecParentFunctionalityDescription);
         AV51TFSecParentFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV51TFSecParentFunctionalityDescription_Sel", AV51TFSecParentFunctionalityDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV92Pgmname+"GridState"), "") == 0 )
         {
            AV24GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV92Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV24GridState.FromXml(AV17Session.Get(AV92Pgmname+"GridState"), null, "", "");
         }
         AV26OrderedBy = AV24GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
         AV27OrderedDsc = AV24GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV24GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV24GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV24GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV104GXV1 = 1;
         while ( AV104GXV1 <= AV24GridState.gxTpr_Filtervalues.Count )
         {
            AV25GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV24GridState.gxTpr_Filtervalues.Item(AV104GXV1));
            if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV82FilterFullText = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82FilterFullText", AV82FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV14SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV25GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV13SecFunctionalityDescription = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13SecFunctionalityDescription", AV13SecFunctionalityDescription);
               AV28SecFunctionalityDescriptionOperator = AV25GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV28SecFunctionalityDescriptionOperator", StringUtil.LTrimStr( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV39TFSecFunctionalityKey = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFSecFunctionalityKey", AV39TFSecFunctionalityKey);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV40TFSecFunctionalityKey_Sel = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFSecFunctionalityKey_Sel", AV40TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV43TFSecFunctionalityDescription = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFSecFunctionalityDescription", AV43TFSecFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV44TFSecFunctionalityDescription_Sel = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFSecFunctionalityDescription_Sel", AV44TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV77TFSecFunctionalityType_SelsJson = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFSecFunctionalityType_SelsJson", AV77TFSecFunctionalityType_SelsJson);
               AV78TFSecFunctionalityType_Sels.FromJSonString(AV77TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV50TFSecParentFunctionalityDescription = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFSecParentFunctionalityDescription", AV50TFSecParentFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV51TFSecParentFunctionalityDescription_Sel = AV25GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFSecParentFunctionalityDescription_Sel", AV51TFSecParentFunctionalityDescription_Sel);
            }
            AV104GXV1 = (int)(AV104GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecFunctionalityKey_Sel)),  AV40TFSecFunctionalityKey_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSecFunctionalityDescription_Sel)),  AV44TFSecFunctionalityDescription_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecParentFunctionalityDescription_Sel)),  AV51TFSecParentFunctionalityDescription_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+((AV78TFSecFunctionalityType_Sels.Count==0) ? "" : AV77TFSecFunctionalityType_SelsJson)+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecFunctionalityKey)),  AV39TFSecFunctionalityKey, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecFunctionalityDescription)),  AV43TFSecFunctionalityDescription, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecParentFunctionalityDescription)),  AV50TFSecParentFunctionalityDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"||"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV24GridState.FromXml(AV17Session.Get(AV92Pgmname+"GridState"), null, "", "");
         AV24GridState.gxTpr_Orderedby = AV26OrderedBy;
         AV24GridState.gxTpr_Ordereddsc = AV27OrderedDsc;
         AV24GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV24GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV82FilterFullText)),  0,  AV82FilterFullText,  AV82FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV24GridState,  "SECFUNCTIONALITYTYPE",  "Type",  !(0==AV14SecFunctionalityType),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0)),  StringUtil.Trim( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV14SecFunctionalityType)),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV24GridState,  "SECFUNCTIONALITYDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV13SecFunctionalityDescription)),  AV28SecFunctionalityDescriptionOperator,  AV13SecFunctionalityDescription,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator+1), 10, 0)), "Começa com"+" "+AV13SecFunctionalityDescription, "Contém"+" "+AV13SecFunctionalityDescription, "", "", "", "", "", "", ""),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV24GridState,  "TFSECFUNCTIONALITYKEY",  "Key",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecFunctionalityKey)),  0,  AV39TFSecFunctionalityKey,  AV39TFSecFunctionalityKey,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecFunctionalityKey_Sel)),  AV40TFSecFunctionalityKey_Sel,  AV40TFSecFunctionalityKey_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV24GridState,  "TFSECFUNCTIONALITYDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecFunctionalityDescription)),  0,  AV43TFSecFunctionalityDescription,  AV43TFSecFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSecFunctionalityDescription_Sel)),  AV44TFSecFunctionalityDescription_Sel,  AV44TFSecFunctionalityDescription_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV24GridState,  "TFSECFUNCTIONALITYTYPE_SEL",  "Type",  !(AV78TFSecFunctionalityType_Sels.Count==0),  0,  AV78TFSecFunctionalityType_Sels.ToJSonString(false),  ((AV78TFSecFunctionalityType_Sels.Count==1) ? StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV78TFSecFunctionalityType_Sels.GetNumeric(1)), 10, 0)), "Mode", "Action", "Tab", "Object", "Attribute", "", "", "", "") : "Vários valores"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV24GridState,  "TFSECPARENTFUNCTIONALITYDESCRIPTION",  "Parent Functionality",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecParentFunctionalityDescription)),  0,  AV50TFSecParentFunctionalityDescription,  AV50TFSecParentFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecParentFunctionalityDescription_Sel)),  AV51TFSecParentFunctionalityDescription_Sel,  AV51TFSecParentFunctionalityDescription_Sel) ;
         if ( ! (0==AV8SecParentFunctionalityId) )
         {
            AV25GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV25GridStateFilterValue.gxTpr_Name = "PARM_&SECPARENTFUNCTIONALITYID";
            AV25GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8SecParentFunctionalityId), 10, 0);
            AV24GridState.gxTpr_Filtervalues.Add(AV25GridStateFilterValue, 0);
         }
         AV24GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV24GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV24GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV92Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecFunctionality";
         AV11TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "SecParentFunctionalityId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8SecParentFunctionalityId), 10, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
      }

      protected void S192( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
      }

      protected void wb_table1_43_2H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsecfunctionalitydescription_Internalname, tblTablemergedsecfunctionalitydescription_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecfunctionalitydescriptionoperator_Internalname, "Sec Functionality Description Operator", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecfunctionalitydescriptionoperator, cmbavSecfunctionalitydescriptionoperator_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0)), 1, cmbavSecfunctionalitydescriptionoperator_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecfunctionalitydescriptionoperator.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            cmbavSecfunctionalitydescriptionoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
            AssignProp("", false, cmbavSecfunctionalitydescriptionoperator_Internalname, "Values", (string)(cmbavSecfunctionalitydescriptionoperator.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription_Internalname, "Sec Functionality Description", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription_Internalname, AV13SecFunctionalityDescription, StringUtil.RTrim( context.localUtil.Format( AV13SecFunctionalityDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSecfunctionalitydescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionalityFilterParentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_2H2e( true) ;
         }
         else
         {
            wb_table1_43_2H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8SecParentFunctionalityId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV8SecParentFunctionalityId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECPARENTFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
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
         PA2H2( ) ;
         WS2H2( ) ;
         WE2H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019234274", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secfunctionalityfilterparentww.js", "?202561019234275", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_592( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_59_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_59_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_59_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_59_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_59_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_59_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_59_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_59_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_59_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_59_idx;
      }

      protected void SubsflControlProps_fel_592( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_59_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_59_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_59_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_59_fel_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_59_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_59_fel_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_59_fel_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_59_fel_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_59_fel_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_59_fel_idx;
      }

      protected void sendrow_592( )
      {
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         WB2H0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_59_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_59_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_59_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV29Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV15Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV16Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A130SecFunctionalityKey,StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecFunctionalityType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_59_idx;
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
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecFunctionalityType,(string)cmbSecFunctionalityType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0)),(short)1,(string)cmbSecFunctionalityType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_59_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescription_Internalname,(string)A138SecParentFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecParentFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_59_idx;
            chkSecFunctionalityActive.Name = GXCCtl;
            chkSecFunctionalityActive.WebTags = "";
            chkSecFunctionalityActive.Caption = "";
            AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_59_Refreshing);
            chkSecFunctionalityActive.CheckedValue = "false";
            A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
            n134SecFunctionalityActive = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSecFunctionalityActive_Internalname,StringUtil.BoolToStr( A134SecFunctionalityActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            send_integrity_lvl_hashes2H2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         /* End function sendrow_592 */
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
            AV14SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbavSecfunctionalitytype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14SecFunctionalityType", StringUtil.LTrimStr( (decimal)(AV14SecFunctionalityType), 2, 0));
         }
         cmbavSecfunctionalitydescriptionoperator.Name = "vSECFUNCTIONALITYDESCRIPTIONOPERATOR";
         cmbavSecfunctionalitydescriptionoperator.WebTags = "";
         cmbavSecfunctionalitydescriptionoperator.addItem("0", "Começa com", 0);
         cmbavSecfunctionalitydescriptionoperator.addItem("1", "Contém", 0);
         if ( cmbavSecfunctionalitydescriptionoperator.ItemCount > 0 )
         {
            AV28SecFunctionalityDescriptionOperator = (short)(Math.Round(NumberUtil.Val( cmbavSecfunctionalitydescriptionoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28SecFunctionalityDescriptionOperator", StringUtil.LTrimStr( (decimal)(AV28SecFunctionalityDescriptionOperator), 4, 0));
         }
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_59_idx;
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
         GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_59_idx;
         chkSecFunctionalityActive.Name = GXCCtl;
         chkSecFunctionalityActive.WebTags = "";
         chkSecFunctionalityActive.Caption = "";
         AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_59_Refreshing);
         chkSecFunctionalityActive.CheckedValue = "false";
         A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
         n134SecFunctionalityActive = false;
         /* End function init_web_controls */
      }

      protected void StartGridControl59( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"59\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality Id  ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Is Active?") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV15Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV16Delete)));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A138SecParentFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecParentFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A134SecFunctionalityActive)));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         cmbavSecfunctionalitytype_Internalname = "vSECFUNCTIONALITYTYPE";
         lblFiltertextsecfunctionalitydescription_Internalname = "FILTERTEXTSECFUNCTIONALITYDESCRIPTION";
         cmbavSecfunctionalitydescriptionoperator_Internalname = "vSECFUNCTIONALITYDESCRIPTIONOPERATOR";
         edtavSecfunctionalitydescription_Internalname = "vSECFUNCTIONALITYDESCRIPTION";
         tblTablemergedsecfunctionalitydescription_Internalname = "TABLEMERGEDSECFUNCTIONALITYDESCRIPTION";
         divTablesplittedfiltertextsecfunctionalitydescription_Internalname = "TABLESPLITTEDFILTERTEXTSECFUNCTIONALITYDESCRIPTION";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION";
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
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
         chkSecFunctionalityActive.Caption = "";
         edtSecParentFunctionalityDescription_Jsonclick = "";
         edtSecParentFunctionalityDescription_Link = "";
         edtSecParentFunctionalityId_Jsonclick = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Link = "";
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
         edtavSecfunctionalitydescription_Jsonclick = "";
         edtavSecfunctionalitydescription_Enabled = 1;
         cmbavSecfunctionalitydescriptionoperator_Jsonclick = "";
         cmbavSecfunctionalitydescriptionoperator.Enabled = 1;
         chkSecFunctionalityActive.Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         subGrid_Sortable = 0;
         cmbavSecfunctionalitytype_Jsonclick = "";
         cmbavSecfunctionalitytype.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecFunctionalityFilterParentWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:Mode,2:Action,3:Tab,4:Object,5:Attribute|";
         Ddo_grid_Allowmultipleselection = "||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character||Character";
         Ddo_grid_Includefilter = "T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "4:SecFunctionalityKey|5:SecFunctionalityDescription|6:SecFunctionalityType|8:SecParentFunctionalityDescription";
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
         Form.Caption = " Functionality";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV8SecParentFunctionalityId","fld":"vSECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV24GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E122H2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV8SecParentFunctionalityId","fld":"vSECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E132H2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV8SecParentFunctionalityId","fld":"vSECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E142H2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV8SecParentFunctionalityId","fld":"vSECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV77TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E202H2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A129SecParentFunctionalityId","fld":"SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV29Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV15Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV16Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtSecFunctionalityDescription_Link","ctrl":"SECFUNCTIONALITYDESCRIPTION","prop":"Link"},{"av":"edtSecParentFunctionalityDescription_Link","ctrl":"SECPARENTFUNCTIONALITYDESCRIPTION","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112H2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV8SecParentFunctionalityId","fld":"vSECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV24GridState","fld":"vGRIDSTATE","type":""},{"av":"AV77TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV24GridState","fld":"vGRIDSTATE","type":""},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavSecfunctionalitytype"},{"av":"AV14SecFunctionalityType","fld":"vSECFUNCTIONALITYTYPE","pic":"Z9","type":"int"},{"av":"cmbavSecfunctionalitydescriptionoperator"},{"av":"AV28SecFunctionalityDescriptionOperator","fld":"vSECFUNCTIONALITYDESCRIPTIONOPERATOR","pic":"ZZZ9","type":"int"},{"av":"AV13SecFunctionalityDescription","fld":"vSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV39TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV40TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV44TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV78TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV50TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV51TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV77TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV80GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E152H2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E162H2","iparms":[]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E172H2","iparms":[]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"}]}""");
         setEventMetadata("VALIDV_SECFUNCTIONALITYTYPE","""{"handler":"Validv_Secfunctionalitytype","iparms":[]}""");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","""{"handler":"Valid_Secparentfunctionalityid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secfunctionalityactive","iparms":[]}""");
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
         AV82FilterFullText = "";
         AV13SecFunctionalityDescription = "";
         AV92Pgmname = "";
         AV39TFSecFunctionalityKey = "";
         AV40TFSecFunctionalityKey_Sel = "";
         AV43TFSecFunctionalityDescription = "";
         AV44TFSecFunctionalityDescription_Sel = "";
         AV78TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV50TFSecParentFunctionalityDescription = "";
         AV51TFSecParentFunctionalityDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV36ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV84GridAppliedFilters = "";
         AV53DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV77TFSecFunctionalityType_SelsJson = "";
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
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblFiltertextsecfunctionalitydescription_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29Display = "";
         AV15Update = "";
         AV16Delete = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         GXDecQS = "";
         AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         H002H2_A134SecFunctionalityActive = new bool[] {false} ;
         H002H2_n134SecFunctionalityActive = new bool[] {false} ;
         H002H2_A138SecParentFunctionalityDescription = new string[] {""} ;
         H002H2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H002H2_A129SecParentFunctionalityId = new long[1] ;
         H002H2_n129SecParentFunctionalityId = new bool[] {false} ;
         H002H2_A136SecFunctionalityType = new short[1] ;
         H002H2_n136SecFunctionalityType = new bool[] {false} ;
         H002H2_A135SecFunctionalityDescription = new string[] {""} ;
         H002H2_n135SecFunctionalityDescription = new bool[] {false} ;
         H002H2_A130SecFunctionalityKey = new string[] {""} ;
         H002H2_n130SecFunctionalityKey = new bool[] {false} ;
         H002H2_A128SecFunctionalityId = new long[1] ;
         H002H3_AGRID_nRecordCount = new long[1] ;
         AV9HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H002H4_A128SecFunctionalityId = new long[1] ;
         H002H4_A129SecParentFunctionalityId = new long[1] ;
         H002H4_n129SecParentFunctionalityId = new bool[] {false} ;
         H002H4_A138SecParentFunctionalityDescription = new string[] {""} ;
         H002H4_n138SecParentFunctionalityDescription = new bool[] {false} ;
         AV76WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV30ExcelFilename = "";
         AV31ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV25GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentww__default(),
            new Object[][] {
                new Object[] {
               H002H2_A134SecFunctionalityActive, H002H2_n134SecFunctionalityActive, H002H2_A138SecParentFunctionalityDescription, H002H2_n138SecParentFunctionalityDescription, H002H2_A129SecParentFunctionalityId, H002H2_n129SecParentFunctionalityId, H002H2_A136SecFunctionalityType, H002H2_n136SecFunctionalityType, H002H2_A135SecFunctionalityDescription, H002H2_n135SecFunctionalityDescription,
               H002H2_A130SecFunctionalityKey, H002H2_n130SecFunctionalityKey, H002H2_A128SecFunctionalityId
               }
               , new Object[] {
               H002H3_AGRID_nRecordCount
               }
               , new Object[] {
               H002H4_A128SecFunctionalityId, H002H4_A129SecParentFunctionalityId, H002H4_n129SecParentFunctionalityId, H002H4_A138SecParentFunctionalityDescription, H002H4_n138SecParentFunctionalityDescription
               }
            }
         );
         AV92Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWW";
         /* GeneXus formulas. */
         AV92Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26OrderedBy ;
      private short AV14SecFunctionalityType ;
      private short AV28SecFunctionalityDescriptionOperator ;
      private short AV32ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A136SecFunctionalityType ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
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
      private int nRC_GXsfl_59 ;
      private int nGXsfl_59_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecParentFunctionalityDescription_Enabled ;
      private int AV79PageToGo ;
      private int AV104GXV1 ;
      private int edtavSecfunctionalitydescription_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8SecParentFunctionalityId ;
      private long wcpOAV8SecParentFunctionalityId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV80GridCurrentPage ;
      private long AV81GridPageCount ;
      private long A128SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long GRID_nCurrentRecord ;
      private long AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_59_idx="0001" ;
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
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
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
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string cmbavSecfunctionalitytype_Internalname ;
      private string cmbavSecfunctionalitytype_Jsonclick ;
      private string divTablesplittedfiltertextsecfunctionalitydescription_Internalname ;
      private string lblFiltertextsecfunctionalitydescription_Internalname ;
      private string lblFiltertextsecfunctionalitydescription_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV29Display ;
      private string edtavDisplay_Internalname ;
      private string AV15Update ;
      private string edtavUpdate_Internalname ;
      private string AV16Delete ;
      private string edtavDelete_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityDescription_Internalname ;
      private string chkSecFunctionalityActive_Internalname ;
      private string GXDecQS ;
      private string cmbavSecfunctionalitydescriptionoperator_Internalname ;
      private string edtavSecfunctionalitydescription_Internalname ;
      private string edtavDisplay_Link ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtSecFunctionalityDescription_Link ;
      private string edtSecParentFunctionalityDescription_Link ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergedsecfunctionalitydescription_Internalname ;
      private string cmbavSecfunctionalitydescriptionoperator_Jsonclick ;
      private string edtavSecfunctionalitydescription_Jsonclick ;
      private string sGXsfl_59_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecParentFunctionalityDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV27OrderedDsc ;
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
      private bool n135SecFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n129SecParentFunctionalityId ;
      private bool n138SecParentFunctionalityDescription ;
      private bool A134SecFunctionalityActive ;
      private bool n134SecFunctionalityActive ;
      private bool bGXsfl_59_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV77TFSecFunctionalityType_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV82FilterFullText ;
      private string AV13SecFunctionalityDescription ;
      private string AV39TFSecFunctionalityKey ;
      private string AV40TFSecFunctionalityKey_Sel ;
      private string AV43TFSecFunctionalityDescription ;
      private string AV44TFSecFunctionalityDescription_Sel ;
      private string AV50TFSecParentFunctionalityDescription ;
      private string AV51TFSecParentFunctionalityDescription_Sel ;
      private string AV84GridAppliedFilters ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV30ExcelFilename ;
      private string AV31ErrorMessage ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV9HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSecfunctionalitytype ;
      private GXCombobox cmbavSecfunctionalitydescriptionoperator ;
      private GXCombobox cmbSecFunctionalityType ;
      private GXCheckbox chkSecFunctionalityActive ;
      private GxSimpleCollection<short> AV78TFSecFunctionalityType_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV36ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV53DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV24GridState ;
      private GxSimpleCollection<short> AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] H002H2_A134SecFunctionalityActive ;
      private bool[] H002H2_n134SecFunctionalityActive ;
      private string[] H002H2_A138SecParentFunctionalityDescription ;
      private bool[] H002H2_n138SecParentFunctionalityDescription ;
      private long[] H002H2_A129SecParentFunctionalityId ;
      private bool[] H002H2_n129SecParentFunctionalityId ;
      private short[] H002H2_A136SecFunctionalityType ;
      private bool[] H002H2_n136SecFunctionalityType ;
      private string[] H002H2_A135SecFunctionalityDescription ;
      private bool[] H002H2_n135SecFunctionalityDescription ;
      private string[] H002H2_A130SecFunctionalityKey ;
      private bool[] H002H2_n130SecFunctionalityKey ;
      private long[] H002H2_A128SecFunctionalityId ;
      private long[] H002H3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private long[] H002H4_A128SecFunctionalityId ;
      private long[] H002H4_A129SecParentFunctionalityId ;
      private bool[] H002H4_n129SecParentFunctionalityId ;
      private string[] H002H4_A138SecParentFunctionalityDescription ;
      private bool[] H002H4_n138SecParentFunctionalityDescription ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV76WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV25GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secfunctionalityfilterparentww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002H2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV28SecFunctionalityDescriptionOperator ,
                                             string AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV26OrderedBy ,
                                             bool AV27OrderedDsc ,
                                             long A129SecParentFunctionalityId ,
                                             long AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[21];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId";
         sFromString = " FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( AV28SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ( AV28SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfun))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpa)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpa))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         if ( ( AV26OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityKey";
         }
         else if ( ( AV26OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV26OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityType, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityType DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId, T2.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 4 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecParentFunctionalityId DESC, T2.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H002H3( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV28SecFunctionalityDescriptionOperator ,
                                             string AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV26OrderedBy ,
                                             bool AV27OrderedDsc ,
                                             long A129SecParentFunctionalityId ,
                                             long AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[18];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
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
         }
         if ( ! (0==AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( AV28SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( AV28SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfun))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( StringUtil.StrCmp(AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV101Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpa)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpa))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV26OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 4 ) && ( AV27OrderedDsc ) )
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
                     return conditional_H002H2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
               case 1 :
                     return conditional_H002H3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002H4;
          prmH002H4 = new Object[] {
          new ParDef("AV8SecParentFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmH002H2;
          prmH002H2 = new Object[] {
          new ParDef("AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfun",GXType.VarChar,100,0) ,
          new ParDef("lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpa",GXType.VarChar,100,0) ,
          new ParDef("AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpa",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002H3;
          prmH002H3 = new Object[] {
          new ParDef("AV93Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV94Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV95Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV97Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV98Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV99Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV100Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfun",GXType.VarChar,100,0) ,
          new ParDef("lV102Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpa",GXType.VarChar,100,0) ,
          new ParDef("AV103Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpa",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002H4", "SELECT T1.SecFunctionalityId, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) WHERE T1.SecParentFunctionalityId = :AV8SecParentFunctionalityId ORDER BY T1.SecParentFunctionalityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H4,11, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
