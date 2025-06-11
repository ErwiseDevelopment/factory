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
   public class aprovacaoww : GXDataArea
   {
      public aprovacaoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovacaoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV26PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAprovacaoStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PropostaId");
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
               gxfirstwebparm = GetFirstPar( "PropostaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PropostaId");
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
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
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
         AV26PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         AV27TFSecUserName = GetPar( "TFSecUserName");
         AV28TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV15TFAprovacaoEm = context.localUtil.ParseDTimeParm( GetPar( "TFAprovacaoEm"));
         AV16TFAprovacaoEm_To = context.localUtil.ParseDTimeParm( GetPar( "TFAprovacaoEm_To"));
         AV20TFAprovacaoDecisao = GetPar( "TFAprovacaoDecisao");
         AV21TFAprovacaoDecisao_Sel = GetPar( "TFAprovacaoDecisao_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV23TFAprovacaoStatus_Sels);
         AV37Pgmname = GetPar( "Pgmname");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
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
         PA612( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START612( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXEncryptionTmp = "aprovacaoww"+UrlEncode(StringUtil.LTrimStr(AV26PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aprovacaoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_APROVACAOEMAUXDATE", context.localUtil.DToC( AV17DDO_AprovacaoEmAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_APROVACAOEMAUXDATETO", context.localUtil.DToC( AV18DDO_AprovacaoEmAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME", AV27TFSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME_SEL", AV28TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAPROVACAOEM", context.localUtil.TToC( AV15TFAprovacaoEm, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAPROVACAOEM_TO", context.localUtil.TToC( AV16TFAprovacaoEm_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAPROVACAODECISAO", AV20TFAprovacaoDecisao);
         GxWebStd.gx_hidden_field( context, "vTFAPROVACAODECISAO_SEL", AV21TFAprovacaoDecisao_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFAPROVACAOSTATUS_SELS", AV23TFAprovacaoStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFAPROVACAOSTATUS_SELS", AV23TFAprovacaoStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE612( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT612( ) ;
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
         GXEncryptionTmp = "aprovacaoww"+UrlEncode(StringUtil.LTrimStr(AV26PropostaId,9,0));
         return formatLink("aprovacaoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AprovacaoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Aprovacao" ;
      }

      protected void WB610( )
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV24DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_aprovacaoemauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_aprovacaoemauxdatetext_Internalname, AV19DDO_AprovacaoEmAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV19DDO_AprovacaoEmAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_aprovacaoemauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AprovacaoWW.htm");
            /* User Defined Control */
            ucTfaprovacaoem_rangepicker.SetProperty("Start Date", AV17DDO_AprovacaoEmAuxDate);
            ucTfaprovacaoem_rangepicker.SetProperty("End Date", AV18DDO_AprovacaoEmAuxDateTo);
            ucTfaprovacaoem_rangepicker.Render(context, "wwp.daterangepicker", Tfaprovacaoem_rangepicker_Internalname, "TFAPROVACAOEM_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
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

      protected void START612( )
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
         Form.Meta.addItem("description", " Aprovacao", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP610( ) ;
      }

      protected void WS612( )
      {
         START612( ) ;
         EVT612( ) ;
      }

      protected void EVT612( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E11612 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
                              AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
                              AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
                              AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
                              AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
                              AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
                              AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
                              AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
                              sEvt = cgiGet( "GRIDPAGING");
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
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A336AprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n375AprovadoresId = false;
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
                              n141SecUserName = false;
                              A337AprovacaoEm = context.localUtil.CToT( cgiGet( edtAprovacaoEm_Internalname), 0);
                              n337AprovacaoEm = false;
                              A338AprovacaoDecisao = cgiGet( edtAprovacaoDecisao_Internalname);
                              n338AprovacaoDecisao = false;
                              cmbAprovacaoStatus.Name = cmbAprovacaoStatus_Internalname;
                              cmbAprovacaoStatus.CurrentValue = cgiGet( cmbAprovacaoStatus_Internalname);
                              A340AprovacaoStatus = cgiGet( cmbAprovacaoStatus_Internalname);
                              n340AprovacaoStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12612 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E13612 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E14612 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
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

      protected void WE612( )
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

      protected void PA612( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "aprovacaoww")), "aprovacaoww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "aprovacaoww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "PropostaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV26PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV26PropostaId", StringUtil.LTrimStr( (decimal)(AV26PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavDdo_aprovacaoemauxdatetext_Internalname;
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
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV26PropostaId ,
                                       string AV27TFSecUserName ,
                                       string AV28TFSecUserName_Sel ,
                                       DateTime AV15TFAprovacaoEm ,
                                       DateTime AV16TFAprovacaoEm_To ,
                                       string AV20TFAprovacaoDecisao ,
                                       string AV21TFAprovacaoDecisao_Sel ,
                                       GxSimpleCollection<string> AV23TFAprovacaoStatus_Sels ,
                                       string AV37Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF612( ) ;
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
         RF612( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV37Pgmname = "AprovacaoWW";
      }

      protected void RF612( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13612 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A340AprovacaoStatus ,
                                                 AV36Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                                 AV31Aprovacaowwds_3_tfsecusername_sel ,
                                                 AV30Aprovacaowwds_2_tfsecusername ,
                                                 AV32Aprovacaowwds_4_tfaprovacaoem ,
                                                 AV33Aprovacaowwds_5_tfaprovacaoem_to ,
                                                 AV35Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                                 AV34Aprovacaowwds_6_tfaprovacaodecisao ,
                                                 AV36Aprovacaowwds_8_tfaprovacaostatus_sels.Count ,
                                                 A141SecUserName ,
                                                 A337AprovacaoEm ,
                                                 A338AprovacaoDecisao ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A323PropostaId ,
                                                 AV29Aprovacaowwds_1_propostaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV30Aprovacaowwds_2_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV30Aprovacaowwds_2_tfsecusername), "%", "");
            lV34Aprovacaowwds_6_tfaprovacaodecisao = StringUtil.Concat( StringUtil.RTrim( AV34Aprovacaowwds_6_tfaprovacaodecisao), "%", "");
            /* Using cursor H00612 */
            pr_default.execute(0, new Object[] {AV29Aprovacaowwds_1_propostaid, lV30Aprovacaowwds_2_tfsecusername, AV31Aprovacaowwds_3_tfsecusername_sel, AV32Aprovacaowwds_4_tfaprovacaoem, AV33Aprovacaowwds_5_tfaprovacaoem_to, lV34Aprovacaowwds_6_tfaprovacaodecisao, AV35Aprovacaowwds_7_tfaprovacaodecisao_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A328PropostaCratedBy = H00612_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H00612_n328PropostaCratedBy[0];
               A133SecUserId = H00612_A133SecUserId[0];
               n133SecUserId = H00612_n133SecUserId[0];
               A340AprovacaoStatus = H00612_A340AprovacaoStatus[0];
               n340AprovacaoStatus = H00612_n340AprovacaoStatus[0];
               A338AprovacaoDecisao = H00612_A338AprovacaoDecisao[0];
               n338AprovacaoDecisao = H00612_n338AprovacaoDecisao[0];
               A337AprovacaoEm = H00612_A337AprovacaoEm[0];
               n337AprovacaoEm = H00612_n337AprovacaoEm[0];
               A141SecUserName = H00612_A141SecUserName[0];
               n141SecUserName = H00612_n141SecUserName[0];
               A323PropostaId = H00612_A323PropostaId[0];
               n323PropostaId = H00612_n323PropostaId[0];
               A375AprovadoresId = H00612_A375AprovadoresId[0];
               n375AprovadoresId = H00612_n375AprovadoresId[0];
               A336AprovacaoId = H00612_A336AprovacaoId[0];
               A328PropostaCratedBy = H00612_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H00612_n328PropostaCratedBy[0];
               A141SecUserName = H00612_A141SecUserName[0];
               n141SecUserName = H00612_n141SecUserName[0];
               A133SecUserId = H00612_A133SecUserId[0];
               n133SecUserId = H00612_n133SecUserId[0];
               /* Execute user event: Grid.Load */
               E14612 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB610( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes612( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
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
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A340AprovacaoStatus ,
                                              AV36Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                              AV31Aprovacaowwds_3_tfsecusername_sel ,
                                              AV30Aprovacaowwds_2_tfsecusername ,
                                              AV32Aprovacaowwds_4_tfaprovacaoem ,
                                              AV33Aprovacaowwds_5_tfaprovacaoem_to ,
                                              AV35Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                              AV34Aprovacaowwds_6_tfaprovacaodecisao ,
                                              AV36Aprovacaowwds_8_tfaprovacaostatus_sels.Count ,
                                              A141SecUserName ,
                                              A337AprovacaoEm ,
                                              A338AprovacaoDecisao ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A323PropostaId ,
                                              AV29Aprovacaowwds_1_propostaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV30Aprovacaowwds_2_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV30Aprovacaowwds_2_tfsecusername), "%", "");
         lV34Aprovacaowwds_6_tfaprovacaodecisao = StringUtil.Concat( StringUtil.RTrim( AV34Aprovacaowwds_6_tfaprovacaodecisao), "%", "");
         /* Using cursor H00613 */
         pr_default.execute(1, new Object[] {AV29Aprovacaowwds_1_propostaid, lV30Aprovacaowwds_2_tfsecusername, AV31Aprovacaowwds_3_tfsecusername_sel, AV32Aprovacaowwds_4_tfaprovacaoem, AV33Aprovacaowwds_5_tfaprovacaoem_to, lV34Aprovacaowwds_6_tfaprovacaodecisao, AV35Aprovacaowwds_7_tfaprovacaodecisao_sel});
         GRID_nRecordCount = H00613_AGRID_nRecordCount[0];
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
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV26PropostaId, AV27TFSecUserName, AV28TFSecUserName_Sel, AV15TFAprovacaoEm, AV16TFAprovacaoEm_To, AV20TFAprovacaoDecisao, AV21TFAprovacaoDecisao_Sel, AV23TFAprovacaoStatus_Sels, AV37Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV37Pgmname = "AprovacaoWW";
         edtAprovacaoId_Enabled = 0;
         edtAprovadoresId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtAprovacaoEm_Enabled = 0;
         edtAprovacaoDecisao_Enabled = 0;
         cmbAprovacaoStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP610( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12612 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV24DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            AV17DDO_AprovacaoEmAuxDate = context.localUtil.CToD( cgiGet( "vDDO_APROVACAOEMAUXDATE"), 0);
            AssignAttri("", false, "AV17DDO_AprovacaoEmAuxDate", context.localUtil.Format(AV17DDO_AprovacaoEmAuxDate, "99/99/9999"));
            AV18DDO_AprovacaoEmAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_APROVACAOEMAUXDATETO"), 0);
            AssignAttri("", false, "AV18DDO_AprovacaoEmAuxDateTo", context.localUtil.Format(AV18DDO_AprovacaoEmAuxDateTo, "99/99/9999"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
            AV19DDO_AprovacaoEmAuxDateText = cgiGet( edtavDdo_aprovacaoemauxdatetext_Internalname);
            AssignAttri("", false, "AV19DDO_AprovacaoEmAuxDateText", AV19DDO_AprovacaoEmAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
         E12612 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12612( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFAPROVACAOEM_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_aprovacaoemauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Aprovacao";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV24DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV24DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13612( )
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
         cmbAprovacaoStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbAprovacaoStatus_Internalname, "Columnheaderclass", cmbAprovacaoStatus_Columnheaderclass, !bGXsfl_12_Refreshing);
         AV29Aprovacaowwds_1_propostaid = AV26PropostaId;
         AV30Aprovacaowwds_2_tfsecusername = AV27TFSecUserName;
         AV31Aprovacaowwds_3_tfsecusername_sel = AV28TFSecUserName_Sel;
         AV32Aprovacaowwds_4_tfaprovacaoem = AV15TFAprovacaoEm;
         AV33Aprovacaowwds_5_tfaprovacaoem_to = AV16TFAprovacaoEm_To;
         AV34Aprovacaowwds_6_tfaprovacaodecisao = AV20TFAprovacaoDecisao;
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = AV21TFAprovacaoDecisao_Sel;
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = AV23TFAprovacaoStatus_Sels;
         /*  Sending Event outputs  */
      }

      protected void E11612( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserName") == 0 )
            {
               AV27TFSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFSecUserName", AV27TFSecUserName);
               AV28TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFSecUserName_Sel", AV28TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AprovacaoEm") == 0 )
            {
               AV15TFAprovacaoEm = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV15TFAprovacaoEm", context.localUtil.TToC( AV15TFAprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
               AV16TFAprovacaoEm_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV16TFAprovacaoEm_To", context.localUtil.TToC( AV16TFAprovacaoEm_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV16TFAprovacaoEm_To) )
               {
                  AV16TFAprovacaoEm_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV16TFAprovacaoEm_To)), (short)(DateTimeUtil.Month( AV16TFAprovacaoEm_To)), (short)(DateTimeUtil.Day( AV16TFAprovacaoEm_To)), 23, 59, 59);
                  AssignAttri("", false, "AV16TFAprovacaoEm_To", context.localUtil.TToC( AV16TFAprovacaoEm_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AprovacaoDecisao") == 0 )
            {
               AV20TFAprovacaoDecisao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFAprovacaoDecisao", AV20TFAprovacaoDecisao);
               AV21TFAprovacaoDecisao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFAprovacaoDecisao_Sel", AV21TFAprovacaoDecisao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AprovacaoStatus") == 0 )
            {
               AV22TFAprovacaoStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV22TFAprovacaoStatus_SelsJson", AV22TFAprovacaoStatus_SelsJson);
               AV23TFAprovacaoStatus_Sels.FromJSonString(AV22TFAprovacaoStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23TFAprovacaoStatus_Sels", AV23TFAprovacaoStatus_Sels);
      }

      private void E14612( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A340AprovacaoStatus, "APROVADO") == 0 )
         {
            cmbAprovacaoStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A340AprovacaoStatus, "REPROVADO") == 0 )
         {
            cmbAprovacaoStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbAprovacaoStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV37Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV37Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV37Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV27TFSecUserName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFSecUserName", AV27TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV28TFSecUserName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFSecUserName_Sel", AV28TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAPROVACAOEM") == 0 )
            {
               AV15TFAprovacaoEm = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV15TFAprovacaoEm", context.localUtil.TToC( AV15TFAprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
               AV16TFAprovacaoEm_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV16TFAprovacaoEm_To", context.localUtil.TToC( AV16TFAprovacaoEm_To, 10, 8, 0, 3, "/", ":", " "));
               AV17DDO_AprovacaoEmAuxDate = DateTimeUtil.ResetTime(AV15TFAprovacaoEm);
               AssignAttri("", false, "AV17DDO_AprovacaoEmAuxDate", context.localUtil.Format(AV17DDO_AprovacaoEmAuxDate, "99/99/9999"));
               AV18DDO_AprovacaoEmAuxDateTo = DateTimeUtil.ResetTime(AV16TFAprovacaoEm_To);
               AssignAttri("", false, "AV18DDO_AprovacaoEmAuxDateTo", context.localUtil.Format(AV18DDO_AprovacaoEmAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAPROVACAODECISAO") == 0 )
            {
               AV20TFAprovacaoDecisao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFAprovacaoDecisao", AV20TFAprovacaoDecisao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAPROVACAODECISAO_SEL") == 0 )
            {
               AV21TFAprovacaoDecisao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFAprovacaoDecisao_Sel", AV21TFAprovacaoDecisao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAPROVACAOSTATUS_SEL") == 0 )
            {
               AV22TFAprovacaoStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFAprovacaoStatus_SelsJson", AV22TFAprovacaoStatus_SelsJson);
               AV23TFAprovacaoStatus_Sels.FromJSonString(AV22TFAprovacaoStatus_SelsJson, null);
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecUserName_Sel)),  AV28TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFAprovacaoDecisao_Sel)),  AV21TFAprovacaoDecisao_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV23TFAprovacaoStatus_Sels.Count==0),  AV22TFAprovacaoStatus_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char3+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecUserName)),  AV27TFSecUserName, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFAprovacaoDecisao)),  AV20TFAprovacaoDecisao, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+((DateTime.MinValue==AV15TFAprovacaoEm) ? "" : context.localUtil.DToC( AV17DDO_AprovacaoEmAuxDate, 4, "/"))+"|"+GXt_char3+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV16TFAprovacaoEm_To) ? "" : context.localUtil.DToC( AV18DDO_AprovacaoEmAuxDateTo, 4, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV37Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSERNAME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecUserName)),  0,  AV27TFSecUserName,  AV27TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecUserName_Sel)),  AV28TFSecUserName_Sel,  AV28TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAPROVACAOEM",  "",  !((DateTime.MinValue==AV15TFAprovacaoEm)&&(DateTime.MinValue==AV16TFAprovacaoEm_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV15TFAprovacaoEm, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV15TFAprovacaoEm) ? "" : StringUtil.Trim( context.localUtil.Format( AV15TFAprovacaoEm, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV16TFAprovacaoEm_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV16TFAprovacaoEm_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV16TFAprovacaoEm_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAPROVACAODECISAO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFAprovacaoDecisao)),  0,  AV20TFAprovacaoDecisao,  AV20TFAprovacaoDecisao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFAprovacaoDecisao_Sel)),  AV21TFAprovacaoDecisao_Sel,  AV21TFAprovacaoDecisao_Sel) ;
         AV25AuxText = ((AV23TFAprovacaoStatus_Sels.Count==1) ? "["+((string)AV23TFAprovacaoStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAPROVACAOSTATUS_SEL",  "",  !(AV23TFAprovacaoStatus_Sels.Count==0),  0,  AV23TFAprovacaoStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV25AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV25AuxText, "[APROVADO]", "Aprovado"), "[REPROVADO]", "Reprovado")),  false,  "",  "") ;
         if ( ! (0==AV26PropostaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&PROPOSTAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV26PropostaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV37Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV37Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Aprovacao";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "PropostaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV26PropostaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV26PropostaId", StringUtil.LTrimStr( (decimal)(AV26PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26PropostaId), "ZZZZZZZZ9"), context));
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
         PA612( ) ;
         WS612( ) ;
         WE612( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101925554", true, true);
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
         context.AddJavascriptSource("aprovacaoww.js", "?20256101925554", false, true);
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

      protected void SubsflControlProps_122( )
      {
         edtAprovacaoId_Internalname = "APROVACAOID_"+sGXsfl_12_idx;
         edtAprovadoresId_Internalname = "APROVADORESID_"+sGXsfl_12_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_12_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_12_idx;
         edtAprovacaoEm_Internalname = "APROVACAOEM_"+sGXsfl_12_idx;
         edtAprovacaoDecisao_Internalname = "APROVACAODECISAO_"+sGXsfl_12_idx;
         cmbAprovacaoStatus_Internalname = "APROVACAOSTATUS_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtAprovacaoId_Internalname = "APROVACAOID_"+sGXsfl_12_fel_idx;
         edtAprovadoresId_Internalname = "APROVADORESID_"+sGXsfl_12_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_12_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_12_fel_idx;
         edtAprovacaoEm_Internalname = "APROVACAOEM_"+sGXsfl_12_fel_idx;
         edtAprovacaoDecisao_Internalname = "APROVACAODECISAO_"+sGXsfl_12_fel_idx;
         cmbAprovacaoStatus_Internalname = "APROVACAOSTATUS_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB610( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAprovacaoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A336AprovacaoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A336AprovacaoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAprovacaoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAprovadoresId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAprovadoresId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAprovacaoEm_Internalname,context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A337AprovacaoEm, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAprovacaoEm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAprovacaoDecisao_Internalname,(string)A338AprovacaoDecisao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAprovacaoDecisao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAprovacaoStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "APROVACAOSTATUS_" + sGXsfl_12_idx;
               cmbAprovacaoStatus.Name = GXCCtl;
               cmbAprovacaoStatus.WebTags = "";
               cmbAprovacaoStatus.addItem("APROVADO", "Aprovado", 0);
               cmbAprovacaoStatus.addItem("REPROVADO", "Reprovado", 0);
               if ( cmbAprovacaoStatus.ItemCount > 0 )
               {
                  A340AprovacaoStatus = cmbAprovacaoStatus.getValidValue(A340AprovacaoStatus);
                  n340AprovacaoStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAprovacaoStatus,(string)cmbAprovacaoStatus_Internalname,StringUtil.RTrim( A340AprovacaoStatus),(short)1,(string)cmbAprovacaoStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbAprovacaoStatus_Columnclass,(string)cmbAprovacaoStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbAprovacaoStatus.CurrentValue = StringUtil.RTrim( A340AprovacaoStatus);
            AssignProp("", false, cmbAprovacaoStatus_Internalname, "Values", (string)(cmbAprovacaoStatus.ToJavascriptSource()), !bGXsfl_12_Refreshing);
            send_integrity_lvl_hashes612( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "APROVACAOSTATUS_" + sGXsfl_12_idx;
         cmbAprovacaoStatus.Name = GXCCtl;
         cmbAprovacaoStatus.WebTags = "";
         cmbAprovacaoStatus.addItem("APROVADO", "Aprovado", 0);
         cmbAprovacaoStatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbAprovacaoStatus.ItemCount > 0 )
         {
            A340AprovacaoStatus = cmbAprovacaoStatus.getValidValue(A340AprovacaoStatus);
            n340AprovacaoStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Aprovador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Aprovado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
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
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A336AprovacaoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A141SecUserName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A338AprovacaoDecisao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A340AprovacaoStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbAprovacaoStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbAprovacaoStatus_Columnheaderclass));
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
         edtAprovacaoId_Internalname = "APROVACAOID";
         edtAprovadoresId_Internalname = "APROVADORESID";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtAprovacaoEm_Internalname = "APROVACAOEM";
         edtAprovacaoDecisao_Internalname = "APROVACAODECISAO";
         cmbAprovacaoStatus_Internalname = "APROVACAOSTATUS";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_aprovacaoemauxdatetext_Internalname = "vDDO_APROVACAOEMAUXDATETEXT";
         Tfaprovacaoem_rangepicker_Internalname = "TFAPROVACAOEM_RANGEPICKER";
         divDdo_aprovacaoemauxdates_Internalname = "DDO_APROVACAOEMAUXDATES";
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
         cmbAprovacaoStatus_Jsonclick = "";
         cmbAprovacaoStatus_Columnclass = "WWColumn";
         edtAprovacaoDecisao_Jsonclick = "";
         edtAprovacaoEm_Jsonclick = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtPropostaId_Jsonclick = "";
         edtAprovadoresId_Jsonclick = "";
         edtAprovacaoId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbAprovacaoStatus_Columnheaderclass = "";
         cmbAprovacaoStatus.Enabled = 0;
         edtAprovacaoDecisao_Enabled = 0;
         edtAprovacaoEm_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtAprovadoresId_Enabled = 0;
         edtAprovacaoId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_aprovacaoemauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "AprovacaoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||APROVADO:Aprovado,REPROVADO:Reprovado";
         Ddo_grid_Allowmultipleselection = "|||T";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T||T|T";
         Ddo_grid_Filterisrange = "|P||";
         Ddo_grid_Filtertype = "Character|Date|Character|";
         Ddo_grid_Includefilter = "T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "3:SecUserName|4:AprovacaoEm|5:AprovacaoDecisao|6:AprovacaoStatus";
         Ddo_grid_Gridinternalname = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Aprovacao";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11612","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV22TFAprovacaoStatus_SelsJson","fld":"vTFAPROVACAOSTATUS_SELSJSON","type":"vchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14612","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"cmbAprovacaoStatus"},{"av":"A340AprovacaoStatus","fld":"APROVACAOSTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSecUserName_Link","ctrl":"SECUSERNAME","prop":"Link"},{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV26PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV27TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV28TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV15TFAprovacaoEm","fld":"vTFAPROVACAOEM","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV16TFAprovacaoEm_To","fld":"vTFAPROVACAOEM_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20TFAprovacaoDecisao","fld":"vTFAPROVACAODECISAO","type":"svchar"},{"av":"AV21TFAprovacaoDecisao_Sel","fld":"vTFAPROVACAODECISAO_SEL","type":"svchar"},{"av":"AV23TFAprovacaoStatus_Sels","fld":"vTFAPROVACAOSTATUS_SELS","type":""},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"cmbAprovacaoStatus"}]}""");
         setEventMetadata("VALID_APROVADORESID","""{"handler":"Valid_Aprovadoresid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Aprovacaostatus","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV27TFSecUserName = "";
         AV28TFSecUserName_Sel = "";
         AV15TFAprovacaoEm = (DateTime)(DateTime.MinValue);
         AV16TFAprovacaoEm_To = (DateTime)(DateTime.MinValue);
         AV20TFAprovacaoDecisao = "";
         AV21TFAprovacaoDecisao_Sel = "";
         AV23TFAprovacaoStatus_Sels = new GxSimpleCollection<string>();
         AV37Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV24DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17DDO_AprovacaoEmAuxDate = DateTime.MinValue;
         AV18DDO_AprovacaoEmAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV19DDO_AprovacaoEmAuxDateText = "";
         ucTfaprovacaoem_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30Aprovacaowwds_2_tfsecusername = "";
         AV31Aprovacaowwds_3_tfsecusername_sel = "";
         AV32Aprovacaowwds_4_tfaprovacaoem = (DateTime)(DateTime.MinValue);
         AV33Aprovacaowwds_5_tfaprovacaoem_to = (DateTime)(DateTime.MinValue);
         AV34Aprovacaowwds_6_tfaprovacaodecisao = "";
         AV35Aprovacaowwds_7_tfaprovacaodecisao_sel = "";
         AV36Aprovacaowwds_8_tfaprovacaostatus_sels = new GxSimpleCollection<string>();
         A141SecUserName = "";
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         A338AprovacaoDecisao = "";
         A340AprovacaoStatus = "";
         GXDecQS = "";
         lV30Aprovacaowwds_2_tfsecusername = "";
         lV34Aprovacaowwds_6_tfaprovacaodecisao = "";
         H00612_A328PropostaCratedBy = new short[1] ;
         H00612_n328PropostaCratedBy = new bool[] {false} ;
         H00612_A133SecUserId = new short[1] ;
         H00612_n133SecUserId = new bool[] {false} ;
         H00612_A340AprovacaoStatus = new string[] {""} ;
         H00612_n340AprovacaoStatus = new bool[] {false} ;
         H00612_A338AprovacaoDecisao = new string[] {""} ;
         H00612_n338AprovacaoDecisao = new bool[] {false} ;
         H00612_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         H00612_n337AprovacaoEm = new bool[] {false} ;
         H00612_A141SecUserName = new string[] {""} ;
         H00612_n141SecUserName = new bool[] {false} ;
         H00612_A323PropostaId = new int[1] ;
         H00612_n323PropostaId = new bool[] {false} ;
         H00612_A375AprovadoresId = new int[1] ;
         H00612_n375AprovadoresId = new bool[] {false} ;
         H00612_A336AprovacaoId = new int[1] ;
         H00613_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV22TFAprovacaoStatus_SelsJson = "";
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         AV25AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovacaoww__default(),
            new Object[][] {
                new Object[] {
               H00612_A328PropostaCratedBy, H00612_n328PropostaCratedBy, H00612_A133SecUserId, H00612_n133SecUserId, H00612_A340AprovacaoStatus, H00612_n340AprovacaoStatus, H00612_A338AprovacaoDecisao, H00612_n338AprovacaoDecisao, H00612_A337AprovacaoEm, H00612_n337AprovacaoEm,
               H00612_A141SecUserName, H00612_n141SecUserName, H00612_A323PropostaId, H00612_n323PropostaId, H00612_A375AprovadoresId, H00612_n375AprovadoresId, H00612_A336AprovacaoId
               }
               , new Object[] {
               H00613_AGRID_nRecordCount
               }
            }
         );
         AV37Pgmname = "AprovacaoWW";
         /* GeneXus formulas. */
         AV37Pgmname = "AprovacaoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short gxajaxcallmode ;
      private short A133SecUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short A328PropostaCratedBy ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV26PropostaId ;
      private int wcpOAV26PropostaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV29Aprovacaowwds_1_propostaid ;
      private int A336AprovacaoId ;
      private int A375AprovadoresId ;
      private int A323PropostaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV36Aprovacaowwds_8_tfaprovacaostatus_sels_Count ;
      private int edtAprovacaoId_Enabled ;
      private int edtAprovadoresId_Enabled ;
      private int edtPropostaId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtAprovacaoEm_Enabled ;
      private int edtAprovacaoDecisao_Enabled ;
      private int AV38GXV1 ;
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
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_12_idx="0001" ;
      private string AV37Pgmname ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_aprovacaoemauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_aprovacaoemauxdatetext_Internalname ;
      private string edtavDdo_aprovacaoemauxdatetext_Jsonclick ;
      private string Tfaprovacaoem_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAprovacaoId_Internalname ;
      private string edtAprovadoresId_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtAprovacaoEm_Internalname ;
      private string edtAprovacaoDecisao_Internalname ;
      private string cmbAprovacaoStatus_Internalname ;
      private string GXDecQS ;
      private string cmbAprovacaoStatus_Columnheaderclass ;
      private string edtSecUserName_Link ;
      private string cmbAprovacaoStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtAprovacaoId_Jsonclick ;
      private string edtAprovadoresId_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtAprovacaoEm_Jsonclick ;
      private string edtAprovacaoDecisao_Jsonclick ;
      private string GXCCtl ;
      private string cmbAprovacaoStatus_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV15TFAprovacaoEm ;
      private DateTime AV16TFAprovacaoEm_To ;
      private DateTime AV32Aprovacaowwds_4_tfaprovacaoem ;
      private DateTime AV33Aprovacaowwds_5_tfaprovacaoem_to ;
      private DateTime A337AprovacaoEm ;
      private DateTime AV17DDO_AprovacaoEmAuxDate ;
      private DateTime AV18DDO_AprovacaoEmAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n375AprovadoresId ;
      private bool n323PropostaId ;
      private bool n141SecUserName ;
      private bool n337AprovacaoEm ;
      private bool n338AprovacaoDecisao ;
      private bool n340AprovacaoStatus ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n328PropostaCratedBy ;
      private bool n133SecUserId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV22TFAprovacaoStatus_SelsJson ;
      private string AV27TFSecUserName ;
      private string AV28TFSecUserName_Sel ;
      private string AV20TFAprovacaoDecisao ;
      private string AV21TFAprovacaoDecisao_Sel ;
      private string AV19DDO_AprovacaoEmAuxDateText ;
      private string AV30Aprovacaowwds_2_tfsecusername ;
      private string AV31Aprovacaowwds_3_tfsecusername_sel ;
      private string AV34Aprovacaowwds_6_tfaprovacaodecisao ;
      private string AV35Aprovacaowwds_7_tfaprovacaodecisao_sel ;
      private string A141SecUserName ;
      private string A338AprovacaoDecisao ;
      private string A340AprovacaoStatus ;
      private string lV30Aprovacaowwds_2_tfsecusername ;
      private string lV34Aprovacaowwds_6_tfaprovacaodecisao ;
      private string AV25AuxText ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfaprovacaoem_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAprovacaoStatus ;
      private GxSimpleCollection<string> AV23TFAprovacaoStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV24DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV36Aprovacaowwds_8_tfaprovacaostatus_sels ;
      private IDataStoreProvider pr_default ;
      private short[] H00612_A328PropostaCratedBy ;
      private bool[] H00612_n328PropostaCratedBy ;
      private short[] H00612_A133SecUserId ;
      private bool[] H00612_n133SecUserId ;
      private string[] H00612_A340AprovacaoStatus ;
      private bool[] H00612_n340AprovacaoStatus ;
      private string[] H00612_A338AprovacaoDecisao ;
      private bool[] H00612_n338AprovacaoDecisao ;
      private DateTime[] H00612_A337AprovacaoEm ;
      private bool[] H00612_n337AprovacaoEm ;
      private string[] H00612_A141SecUserName ;
      private bool[] H00612_n141SecUserName ;
      private int[] H00612_A323PropostaId ;
      private bool[] H00612_n323PropostaId ;
      private int[] H00612_A375AprovadoresId ;
      private bool[] H00612_n375AprovadoresId ;
      private int[] H00612_A336AprovacaoId ;
      private long[] H00613_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class aprovacaoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00612( IGxContext context ,
                                             string A340AprovacaoStatus ,
                                             GxSimpleCollection<string> AV36Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                             string AV31Aprovacaowwds_3_tfsecusername_sel ,
                                             string AV30Aprovacaowwds_2_tfsecusername ,
                                             DateTime AV32Aprovacaowwds_4_tfaprovacaoem ,
                                             DateTime AV33Aprovacaowwds_5_tfaprovacaoem_to ,
                                             string AV35Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                             string AV34Aprovacaowwds_6_tfaprovacaodecisao ,
                                             int AV36Aprovacaowwds_8_tfaprovacaostatus_sels_Count ,
                                             string A141SecUserName ,
                                             DateTime A337AprovacaoEm ,
                                             string A338AprovacaoDecisao ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A323PropostaId ,
                                             int AV29Aprovacaowwds_1_propostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.PropostaCratedBy AS PropostaCratedBy, T4.SecUserId, T1.AprovacaoStatus, T1.AprovacaoDecisao, T1.AprovacaoEm, T3.SecUserName, T1.PropostaId, T1.AprovadoresId, T1.AprovacaoId";
         sFromString = " FROM (((Aprovacao T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.PropostaCratedBy) LEFT JOIN Aprovadores T4 ON T4.AprovadoresId = T1.AprovadoresId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.PropostaId = :AV29Aprovacaowwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31Aprovacaowwds_3_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30Aprovacaowwds_2_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV30Aprovacaowwds_2_tfsecusername)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Aprovacaowwds_3_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV31Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV31Aprovacaowwds_3_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV31Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV32Aprovacaowwds_4_tfaprovacaoem) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm >= :AV32Aprovacaowwds_4_tfaprovacaoem)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV33Aprovacaowwds_5_tfaprovacaoem_to) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm <= :AV33Aprovacaowwds_5_tfaprovacaoem_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Aprovacaowwds_6_tfaprovacaodecisao)) ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao like :lV34Aprovacaowwds_6_tfaprovacaodecisao)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ! ( StringUtil.StrCmp(AV35Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao = ( :AV35Aprovacaowwds_7_tfaprovacaodecisao_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV35Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao IS NULL or (char_length(trim(trailing ' ' from T1.AprovacaoDecisao))=0))");
         }
         if ( AV36Aprovacaowwds_8_tfaprovacaostatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV36Aprovacaowwds_8_tfaprovacaostatus_sels, "T1.AprovacaoStatus IN (", ")")+")");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T3.SecUserName, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T3.SecUserName DESC, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.AprovacaoEm, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.AprovacaoEm DESC, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.AprovacaoDecisao, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.AprovacaoDecisao DESC, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.AprovacaoStatus, T1.AprovacaoId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.AprovacaoStatus DESC, T1.AprovacaoId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AprovacaoId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00613( IGxContext context ,
                                             string A340AprovacaoStatus ,
                                             GxSimpleCollection<string> AV36Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                             string AV31Aprovacaowwds_3_tfsecusername_sel ,
                                             string AV30Aprovacaowwds_2_tfsecusername ,
                                             DateTime AV32Aprovacaowwds_4_tfaprovacaoem ,
                                             DateTime AV33Aprovacaowwds_5_tfaprovacaoem_to ,
                                             string AV35Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                             string AV34Aprovacaowwds_6_tfaprovacaodecisao ,
                                             int AV36Aprovacaowwds_8_tfaprovacaostatus_sels_Count ,
                                             string A141SecUserName ,
                                             DateTime A337AprovacaoEm ,
                                             string A338AprovacaoDecisao ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A323PropostaId ,
                                             int AV29Aprovacaowwds_1_propostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((Aprovacao T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.PropostaCratedBy) LEFT JOIN Aprovadores T4 ON T4.AprovadoresId = T1.AprovadoresId)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV29Aprovacaowwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31Aprovacaowwds_3_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30Aprovacaowwds_2_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV30Aprovacaowwds_2_tfsecusername)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Aprovacaowwds_3_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV31Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV31Aprovacaowwds_3_tfsecusername_sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV31Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV32Aprovacaowwds_4_tfaprovacaoem) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm >= :AV32Aprovacaowwds_4_tfaprovacaoem)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV33Aprovacaowwds_5_tfaprovacaoem_to) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm <= :AV33Aprovacaowwds_5_tfaprovacaoem_to)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Aprovacaowwds_6_tfaprovacaodecisao)) ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao like :lV34Aprovacaowwds_6_tfaprovacaodecisao)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ! ( StringUtil.StrCmp(AV35Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao = ( :AV35Aprovacaowwds_7_tfaprovacaodecisao_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV35Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao IS NULL or (char_length(trim(trailing ' ' from T1.AprovacaoDecisao))=0))");
         }
         if ( AV36Aprovacaowwds_8_tfaprovacaostatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV36Aprovacaowwds_8_tfaprovacaostatus_sels, "T1.AprovacaoStatus IN (", ")")+")");
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
                     return conditional_H00612(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
               case 1 :
                     return conditional_H00613(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
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
          Object[] prmH00612;
          prmH00612 = new Object[] {
          new ParDef("AV29Aprovacaowwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV30Aprovacaowwds_2_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV31Aprovacaowwds_3_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("AV32Aprovacaowwds_4_tfaprovacaoem",GXType.DateTime,10,8) ,
          new ParDef("AV33Aprovacaowwds_5_tfaprovacaoem_to",GXType.DateTime,10,8) ,
          new ParDef("lV34Aprovacaowwds_6_tfaprovacaodecisao",GXType.VarChar,255,0) ,
          new ParDef("AV35Aprovacaowwds_7_tfaprovacaodecisao_sel",GXType.VarChar,255,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00613;
          prmH00613 = new Object[] {
          new ParDef("AV29Aprovacaowwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV30Aprovacaowwds_2_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV31Aprovacaowwds_3_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("AV32Aprovacaowwds_4_tfaprovacaoem",GXType.DateTime,10,8) ,
          new ParDef("AV33Aprovacaowwds_5_tfaprovacaoem_to",GXType.DateTime,10,8) ,
          new ParDef("lV34Aprovacaowwds_6_tfaprovacaodecisao",GXType.VarChar,255,0) ,
          new ParDef("AV35Aprovacaowwds_7_tfaprovacaodecisao_sel",GXType.VarChar,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00612", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00612,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00613", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00613,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
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
