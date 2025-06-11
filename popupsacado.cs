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
   public class popupsacado : GXDataArea
   {
      public popupsacado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public popupsacado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_InOutClienteId ,
                           ref string aP1_InOutClienteRazaoSocial )
      {
         this.AV7InOutClienteId = aP0_InOutClienteId;
         this.AV8InOutClienteRazaoSocial = aP1_InOutClienteRazaoSocial;
         ExecuteImpl();
         aP0_InOutClienteId=this.AV7InOutClienteId;
         aP1_InOutClienteRazaoSocial=this.AV8InOutClienteRazaoSocial;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutClienteId");
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
               gxfirstwebparm = GetFirstPar( "InOutClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutClienteId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV7InOutClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InOutClienteId", StringUtil.LTrimStr( (decimal)(AV7InOutClienteId), 9, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8InOutClienteRazaoSocial = GetPar( "InOutClienteRazaoSocial");
                  AssignAttri("", false, "AV8InOutClienteRazaoSocial", AV8InOutClienteRazaoSocial);
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
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
         AV14FilterFullText = GetPar( "FilterFullText");
         AV27Pgmname = GetPar( "Pgmname");
         AV15TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV16TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         AV17TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV18TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV19TFClienteNomeFantasia = GetPar( "TFClienteNomeFantasia");
         AV20TFClienteNomeFantasia_Sel = GetPar( "TFClienteNomeFantasia_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA9Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9Z2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("popupsacado", new object[] {UrlEncode(StringUtil.LTrimStr(AV7InOutClienteId,9,0)),UrlEncode(StringUtil.RTrim(AV8InOutClienteRazaoSocial))}, new string[] {"InOutClienteId","InOutClienteRazaoSocial"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV25GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV15TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV16TFClienteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV17TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV18TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTENOMEFANTASIA", AV19TFClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTENOMEFANTASIA_SEL", AV20TFClienteNomeFantasia_Sel);
         GxWebStd.gx_hidden_field( context, "vINOUTCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InOutClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINOUTCLIENTERAZAOSOCIAL", AV8InOutClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RELACIONAMENTOSACADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031RelacionamentoSacado), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CLIENTESACADO", A1030ClienteSacado);
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9Z2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("popupsacado", new object[] {UrlEncode(StringUtil.LTrimStr(AV7InOutClienteId,9,0)),UrlEncode(StringUtil.RTrim(AV8InOutClienteRazaoSocial))}, new string[] {"InOutClienteId","InOutClienteRazaoSocial"})  ;
      }

      public override string GetPgmname( )
      {
         return "PopUpSacado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Consulta de Cliente" ;
      }

      protected void WB9Z0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainPrompt", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
            wb_table1_14_9Z2( true) ;
         }
         else
         {
            wb_table1_14_9Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_9Z2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninserir_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Inserir", bttBtninserir_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PopUpSacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLeft15 CellMarginBottom15 GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV23GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV24GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV25GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 31 )
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

      protected void START9Z2( )
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
         Form.Meta.addItem("description", "Consulta de Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9Z0( ) ;
      }

      protected void WS9Z2( )
      {
         START9Z2( ) ;
         EVT9Z2( ) ;
      }

      protected void EVT9Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E119Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E129Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E139Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E149Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInserir' */
                              E159Z2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              AV26Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV26Select);
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
                              n171ClienteNomeFantasia = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E169Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E179Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E189Z2 ();
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
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E199Z2 ();
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

      protected void WE9Z2( )
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

      protected void PA9Z2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       string AV27Pgmname ,
                                       string AV15TFClienteDocumento ,
                                       string AV16TFClienteDocumento_Sel ,
                                       string AV17TFClienteRazaoSocial ,
                                       string AV18TFClienteRazaoSocial_Sel ,
                                       string AV19TFClienteNomeFantasia ,
                                       string AV20TFClienteNomeFantasia_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, "CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
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
         RF9Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "PopUpSacado";
         edtavSelect_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14FilterFullText ,
                                              AV16TFClienteDocumento_Sel ,
                                              AV15TFClienteDocumento ,
                                              AV18TFClienteRazaoSocial_Sel ,
                                              AV17TFClienteRazaoSocial ,
                                              AV20TFClienteNomeFantasia_Sel ,
                                              AV19TFClienteNomeFantasia ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A1030ClienteSacado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV15TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV15TFClienteDocumento), "%", "");
         lV17TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV17TFClienteRazaoSocial), "%", "");
         lV19TFClienteNomeFantasia = StringUtil.Concat( StringUtil.RTrim( AV19TFClienteNomeFantasia), "%", "");
         /* Using cursor H009Z3 */
         pr_default.execute(0, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV15TFClienteDocumento, AV16TFClienteDocumento_Sel, lV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, lV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A171ClienteNomeFantasia = H009Z3_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H009Z3_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = H009Z3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H009Z3_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = H009Z3_A169ClienteDocumento[0];
            n169ClienteDocumento = H009Z3_n169ClienteDocumento[0];
            A168ClienteId = H009Z3_A168ClienteId[0];
            n168ClienteId = H009Z3_n168ClienteId[0];
            A1031RelacionamentoSacado = H009Z3_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = H009Z3_n1031RelacionamentoSacado[0];
            A1031RelacionamentoSacado = H009Z3_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = H009Z3_n1031RelacionamentoSacado[0];
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
            if ( A1030ClienteSacado )
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

      protected void RF9Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 31;
         /* Execute user event: Refresh */
         E179Z2 ();
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
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
            SubsflControlProps_312( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV14FilterFullText ,
                                                 AV16TFClienteDocumento_Sel ,
                                                 AV15TFClienteDocumento ,
                                                 AV18TFClienteRazaoSocial_Sel ,
                                                 AV17TFClienteRazaoSocial ,
                                                 AV20TFClienteNomeFantasia_Sel ,
                                                 AV19TFClienteNomeFantasia ,
                                                 A169ClienteDocumento ,
                                                 A170ClienteRazaoSocial ,
                                                 A171ClienteNomeFantasia ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A1030ClienteSacado } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV15TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV15TFClienteDocumento), "%", "");
            lV17TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV17TFClienteRazaoSocial), "%", "");
            lV19TFClienteNomeFantasia = StringUtil.Concat( StringUtil.RTrim( AV19TFClienteNomeFantasia), "%", "");
            /* Using cursor H009Z5 */
            pr_default.execute(1, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV15TFClienteDocumento, AV16TFClienteDocumento_Sel, lV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, lV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel});
            nGXsfl_31_idx = 1;
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A171ClienteNomeFantasia = H009Z5_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H009Z5_n171ClienteNomeFantasia[0];
               A170ClienteRazaoSocial = H009Z5_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H009Z5_n170ClienteRazaoSocial[0];
               A169ClienteDocumento = H009Z5_A169ClienteDocumento[0];
               n169ClienteDocumento = H009Z5_n169ClienteDocumento[0];
               A168ClienteId = H009Z5_A168ClienteId[0];
               n168ClienteId = H009Z5_n168ClienteId[0];
               A1031RelacionamentoSacado = H009Z5_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = H009Z5_n1031RelacionamentoSacado[0];
               A1031RelacionamentoSacado = H009Z5_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = H009Z5_n1031RelacionamentoSacado[0];
               A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
               AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
               if ( A1030ClienteSacado )
               {
                  /* Execute user event: Grid.Load */
                  E189Z2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 31;
            WB9Z0( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_31_idx, GetSecureSignedToken( sGXsfl_31_idx, context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTERAZAOSOCIAL"+"_"+sGXsfl_31_idx, GetSecureSignedToken( sGXsfl_31_idx, StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV27Pgmname, AV15TFClienteDocumento, AV16TFClienteDocumento_Sel, AV17TFClienteRazaoSocial, AV18TFClienteRazaoSocial_Sel, AV19TFClienteNomeFantasia, AV20TFClienteNomeFantasia_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "PopUpSacado";
         edtavSelect_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E169Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ",", "."), 18, MidpointRounding.ToEven));
            AV23GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV24GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV25GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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
         E169Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E169Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Consulta de Cliente";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E179Z2( )
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
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV23GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV23GridCurrentPage), 10, 0));
         AV24GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV24GridPageCount", StringUtil.LTrimStr( (decimal)(AV24GridPageCount), 10, 0));
         GXt_char2 = AV25GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV27Pgmname, out  GXt_char2) ;
         AV25GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV25GridAppliedFilters", AV25GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E119Z2( )
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
            AV22PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV22PageToGo) ;
         }
      }

      protected void E129Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E139Z2( )
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
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV15TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV15TFClienteDocumento", AV15TFClienteDocumento);
               AV16TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV16TFClienteDocumento_Sel", AV16TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV17TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV17TFClienteRazaoSocial", AV17TFClienteRazaoSocial);
               AV18TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV18TFClienteRazaoSocial_Sel", AV18TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteNomeFantasia") == 0 )
            {
               AV19TFClienteNomeFantasia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV19TFClienteNomeFantasia", AV19TFClienteNomeFantasia);
               AV20TFClienteNomeFantasia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV20TFClienteNomeFantasia_Sel", AV20TFClienteNomeFantasia_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E189Z2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV26Select = "<i class=\"fas fa-check\"></i>";
            AssignAttri("", false, edtavSelect_Internalname, AV26Select);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 31;
            }
            sendrow_312( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
         {
            DoAjaxLoad(31, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E199Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199Z2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV7InOutClienteId = A168ClienteId;
         AssignAttri("", false, "AV7InOutClienteId", StringUtil.LTrimStr( (decimal)(AV7InOutClienteId), 9, 0));
         AV8InOutClienteRazaoSocial = A170ClienteRazaoSocial;
         AssignAttri("", false, "AV8InOutClienteRazaoSocial", AV8InOutClienteRazaoSocial);
         context.setWebReturnParms(new Object[] {(int)AV7InOutClienteId,(string)AV8InOutClienteRazaoSocial});
         context.setWebReturnParmsMetadata(new Object[] {"AV7InOutClienteId","AV8InOutClienteRazaoSocial"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E149Z2( )
      {
         /* 'DoCleanFilters' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E159Z2( )
      {
         /* 'DoInserir' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "sacado"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("sacado") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV15TFClienteDocumento = "";
         AssignAttri("", false, "AV15TFClienteDocumento", AV15TFClienteDocumento);
         AV16TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV16TFClienteDocumento_Sel", AV16TFClienteDocumento_Sel);
         AV17TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV17TFClienteRazaoSocial", AV17TFClienteRazaoSocial);
         AV18TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV18TFClienteRazaoSocial_Sel", AV18TFClienteRazaoSocial_Sel);
         AV19TFClienteNomeFantasia = "";
         AssignAttri("", false, "AV19TFClienteNomeFantasia", AV19TFClienteNomeFantasia);
         AV20TFClienteNomeFantasia_Sel = "";
         AssignAttri("", false, "AV20TFClienteNomeFantasia_Sel", AV20TFClienteNomeFantasia_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTEDOCUMENTO",  "CNPJ",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteDocumento)),  0,  AV15TFClienteDocumento,  AV15TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFClienteDocumento_Sel)),  AV16TFClienteDocumento_Sel,  AV16TFClienteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFClienteRazaoSocial)),  0,  AV17TFClienteRazaoSocial,  AV17TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFClienteRazaoSocial_Sel)),  AV18TFClienteRazaoSocial_Sel,  AV18TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTENOMEFANTASIA",  "Nome fantasia",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFClienteNomeFantasia)),  0,  AV19TFClienteNomeFantasia,  AV19TFClienteNomeFantasia,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteNomeFantasia_Sel)),  AV20TFClienteNomeFantasia_Sel,  AV20TFClienteNomeFantasia_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV27Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table1_14_9Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "TableFilters", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, "<i class=\"CleanFiltersIcon fas fa-filter\"></i>", "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, "Limpar filtros", 1, 1, 0, 1, "HLP_PopUpSacado.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PopUpSacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_9Z2e( true) ;
         }
         else
         {
            wb_table1_14_9Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7InOutClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7InOutClienteId", StringUtil.LTrimStr( (decimal)(AV7InOutClienteId), 9, 0));
         AV8InOutClienteRazaoSocial = (string)getParm(obj,1);
         AssignAttri("", false, "AV8InOutClienteRazaoSocial", AV8InOutClienteRazaoSocial);
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
         PA9Z2( ) ;
         WS9Z2( ) ;
         WE9Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101929127", true, true);
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
         context.AddJavascriptSource("popupsacado.js", "?20256101929127", false, true);
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

      protected void SubsflControlProps_312( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_31_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_31_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_31_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_31_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_31_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_31_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_31_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_31_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         WB9Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_31_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_31_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV26Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"","'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_31_idx+"'",(string)"",(string)"",(string)"Selecionar",(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         /* End function sendrow_312 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"31\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CNPJ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Razão social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV26Select)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A169ClienteDocumento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A171ClienteNomeFantasia));
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
         lblCleanfilters_Internalname = "CLEANFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         bttBtninserir_Internalname = "BTNINSERIR";
         edtavSelect_Internalname = "vSELECT";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
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
         edtClienteNomeFantasia_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "PopUpSacadoGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3";
         Ddo_grid_Columnids = "2:ClienteDocumento|3:ClienteRazaoSocial|4:ClienteNomeFantasia";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Consulta de Cliente";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E119Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E129Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E139Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E189Z2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV26Select","fld":"vSELECT","type":"char"}]}""");
         setEventMetadata("ENTER","""{"handler":"E199Z2","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7InOutClienteId","fld":"vINOUTCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV8InOutClienteRazaoSocial","fld":"vINOUTCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("'DOCLEANFILTERS'","""{"handler":"E149Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("'DOCLEANFILTERS'",""","oparms":[{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("'DOINSERIR'","""{"handler":"E159Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV16TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV17TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV20TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERIR'",""","oparms":[{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Clientenomefantasia","iparms":[]}""");
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
         wcpOAV8InOutClienteRazaoSocial = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14FilterFullText = "";
         AV27Pgmname = "";
         AV15TFClienteDocumento = "";
         AV16TFClienteDocumento_Sel = "";
         AV17TFClienteRazaoSocial = "";
         AV18TFClienteRazaoSocial_Sel = "";
         AV19TFClienteNomeFantasia = "";
         AV20TFClienteNomeFantasia_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV25GridAppliedFilters = "";
         AV21DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninserir_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26Select = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         lV14FilterFullText = "";
         lV15TFClienteDocumento = "";
         lV17TFClienteRazaoSocial = "";
         lV19TFClienteNomeFantasia = "";
         H009Z3_A171ClienteNomeFantasia = new string[] {""} ;
         H009Z3_n171ClienteNomeFantasia = new bool[] {false} ;
         H009Z3_A170ClienteRazaoSocial = new string[] {""} ;
         H009Z3_n170ClienteRazaoSocial = new bool[] {false} ;
         H009Z3_A169ClienteDocumento = new string[] {""} ;
         H009Z3_n169ClienteDocumento = new bool[] {false} ;
         H009Z3_A168ClienteId = new int[1] ;
         H009Z3_n168ClienteId = new bool[] {false} ;
         H009Z3_A1031RelacionamentoSacado = new short[1] ;
         H009Z3_n1031RelacionamentoSacado = new bool[] {false} ;
         H009Z5_A171ClienteNomeFantasia = new string[] {""} ;
         H009Z5_n171ClienteNomeFantasia = new bool[] {false} ;
         H009Z5_A170ClienteRazaoSocial = new string[] {""} ;
         H009Z5_n170ClienteRazaoSocial = new bool[] {false} ;
         H009Z5_A169ClienteDocumento = new string[] {""} ;
         H009Z5_n169ClienteDocumento = new bool[] {false} ;
         H009Z5_A168ClienteId = new int[1] ;
         H009Z5_n168ClienteId = new bool[] {false} ;
         H009Z5_A1031RelacionamentoSacado = new short[1] ;
         H009Z5_n1031RelacionamentoSacado = new bool[] {false} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         lblCleanfilters_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.popupsacado__default(),
            new Object[][] {
                new Object[] {
               H009Z3_A171ClienteNomeFantasia, H009Z3_n171ClienteNomeFantasia, H009Z3_A170ClienteRazaoSocial, H009Z3_n170ClienteRazaoSocial, H009Z3_A169ClienteDocumento, H009Z3_n169ClienteDocumento, H009Z3_A168ClienteId, H009Z3_A1031RelacionamentoSacado, H009Z3_n1031RelacionamentoSacado
               }
               , new Object[] {
               H009Z5_A171ClienteNomeFantasia, H009Z5_n171ClienteNomeFantasia, H009Z5_A170ClienteRazaoSocial, H009Z5_n170ClienteRazaoSocial, H009Z5_A169ClienteDocumento, H009Z5_n169ClienteDocumento, H009Z5_A168ClienteId, H009Z5_A1031RelacionamentoSacado, H009Z5_n1031RelacionamentoSacado
               }
            }
         );
         AV27Pgmname = "PopUpSacado";
         /* GeneXus formulas. */
         AV27Pgmname = "PopUpSacado";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short gxajaxcallmode ;
      private short A1031RelacionamentoSacado ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7InOutClienteId ;
      private int wcpOAV7InOutClienteId ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_31 ;
      private int subGrid_Rows ;
      private int nGXsfl_31_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int edtavSelect_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int AV22PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV23GridCurrentPage ;
      private long AV24GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string AV27Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninserir_Internalname ;
      private string bttBtninserir_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV26Select ;
      private string edtavSelect_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteNomeFantasia_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string GXt_char2 ;
      private string GXEncryptionTmp ;
      private string tblTablefilters_Internalname ;
      private string lblCleanfilters_Internalname ;
      private string lblCleanfilters_Jsonclick ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSelect_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool A1030ClienteSacado ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n168ClienteId ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n1031RelacionamentoSacado ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV8InOutClienteRazaoSocial ;
      private string wcpOAV8InOutClienteRazaoSocial ;
      private string AV14FilterFullText ;
      private string AV15TFClienteDocumento ;
      private string AV16TFClienteDocumento_Sel ;
      private string AV17TFClienteRazaoSocial ;
      private string AV18TFClienteRazaoSocial_Sel ;
      private string AV19TFClienteNomeFantasia ;
      private string AV20TFClienteNomeFantasia_Sel ;
      private string AV25GridAppliedFilters ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string lV14FilterFullText ;
      private string lV15TFClienteDocumento ;
      private string lV17TFClienteRazaoSocial ;
      private string lV19TFClienteNomeFantasia ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private int aP0_InOutClienteId ;
      private string aP1_InOutClienteRazaoSocial ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H009Z3_A171ClienteNomeFantasia ;
      private bool[] H009Z3_n171ClienteNomeFantasia ;
      private string[] H009Z3_A170ClienteRazaoSocial ;
      private bool[] H009Z3_n170ClienteRazaoSocial ;
      private string[] H009Z3_A169ClienteDocumento ;
      private bool[] H009Z3_n169ClienteDocumento ;
      private int[] H009Z3_A168ClienteId ;
      private bool[] H009Z3_n168ClienteId ;
      private short[] H009Z3_A1031RelacionamentoSacado ;
      private bool[] H009Z3_n1031RelacionamentoSacado ;
      private string[] H009Z5_A171ClienteNomeFantasia ;
      private bool[] H009Z5_n171ClienteNomeFantasia ;
      private string[] H009Z5_A170ClienteRazaoSocial ;
      private bool[] H009Z5_n170ClienteRazaoSocial ;
      private string[] H009Z5_A169ClienteDocumento ;
      private bool[] H009Z5_n169ClienteDocumento ;
      private int[] H009Z5_A168ClienteId ;
      private bool[] H009Z5_n168ClienteId ;
      private short[] H009Z5_A1031RelacionamentoSacado ;
      private bool[] H009Z5_n1031RelacionamentoSacado ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class popupsacado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009Z3( IGxContext context ,
                                             string AV14FilterFullText ,
                                             string AV16TFClienteDocumento_Sel ,
                                             string AV15TFClienteDocumento ,
                                             string AV18TFClienteRazaoSocial_Sel ,
                                             string AV17TFClienteRazaoSocial ,
                                             string AV20TFClienteNomeFantasia_Sel ,
                                             string AV19TFClienteNomeFantasia ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A1030ClienteSacado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ClienteId, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.ClienteDocumento like '%' || :lV14FilterFullText) or ( T1.ClienteRazaoSocial like '%' || :lV14FilterFullText) or ( T1.ClienteNomeFantasia like '%' || :lV14FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV15TFClienteDocumento)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV16TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV16TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV17TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV18TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV18TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteNomeFantasia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFClienteNomeFantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV19TFClienteNomeFantasia)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteNomeFantasia_Sel)) && ! ( StringUtil.StrCmp(AV20TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV20TFClienteNomeFantasia_Sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteNomeFantasia, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteNomeFantasia DESC, T1.ClienteId";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H009Z5( IGxContext context ,
                                             string AV14FilterFullText ,
                                             string AV16TFClienteDocumento_Sel ,
                                             string AV15TFClienteDocumento ,
                                             string AV18TFClienteRazaoSocial_Sel ,
                                             string AV17TFClienteRazaoSocial ,
                                             string AV20TFClienteNomeFantasia_Sel ,
                                             string AV19TFClienteNomeFantasia ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A1030ClienteSacado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ClienteId, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.ClienteDocumento like '%' || :lV14FilterFullText) or ( T1.ClienteRazaoSocial like '%' || :lV14FilterFullText) or ( T1.ClienteNomeFantasia like '%' || :lV14FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV15TFClienteDocumento)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV16TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV16TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV17TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV18TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV18TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteNomeFantasia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFClienteNomeFantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV19TFClienteNomeFantasia)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteNomeFantasia_Sel)) && ! ( StringUtil.StrCmp(AV20TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV20TFClienteNomeFantasia_Sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteNomeFantasia, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteNomeFantasia DESC, T1.ClienteId";
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
                     return conditional_H009Z3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] );
               case 1 :
                     return conditional_H009Z5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] );
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
          Object[] prmH009Z3;
          prmH009Z3 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV15TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV16TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV17TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV18TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV19TFClienteNomeFantasia",GXType.VarChar,150,0) ,
          new ParDef("AV20TFClienteNomeFantasia_Sel",GXType.VarChar,150,0)
          };
          Object[] prmH009Z5;
          prmH009Z5 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV15TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV16TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV17TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV18TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV19TFClienteNomeFantasia",GXType.VarChar,150,0) ,
          new ParDef("AV20TFClienteNomeFantasia_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Z3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009Z5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Z5,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
