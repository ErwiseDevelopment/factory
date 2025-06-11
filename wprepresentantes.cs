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
   public class wprepresentantes : GXDataArea
   {
      public wprepresentantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wprepresentantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbResponsavelCargo = new GXCombobox();
         cmbClienteTipoPessoa = new GXCombobox();
         cmbClienteSituacao = new GXCombobox();
         cmbClienteStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         nRC_GXsfl_44 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_44"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_44_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_44_idx = GetPar( "sGXsfl_44_idx");
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
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV53Pgmname = GetPar( "Pgmname");
         AV14FilterFullText = GetPar( "FilterFullText");
         AV52TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
         AV21TFResponsavelNome = GetPar( "TFResponsavelNome");
         AV22TFResponsavelNome_Sel = GetPar( "TFResponsavelNome_Sel");
         AV23TFResponsavelCPF = GetPar( "TFResponsavelCPF");
         AV24TFResponsavelCPF_Sel = GetPar( "TFResponsavelCPF_Sel");
         AV25TFResponsavelCelular_F = GetPar( "TFResponsavelCelular_F");
         AV26TFResponsavelCelular_F_Sel = GetPar( "TFResponsavelCelular_F_Sel");
         AV27TFResponsavelEmail = GetPar( "TFResponsavelEmail");
         AV28TFResponsavelEmail_Sel = GetPar( "TFResponsavelEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFResponsavelCargo_Sels);
         AV31TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV32TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         AV33TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV34TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV36TFClienteSituacao_Sels);
         AV37TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
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
         PA952( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START952( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wprepresentantes") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_44", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_44), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV42GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME", AV21TFResponsavelNome);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME_SEL", AV22TFResponsavelNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCPF", AV23TFResponsavelCPF);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCPF_SEL", AV24TFResponsavelCPF_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCELULAR_F", AV25TFResponsavelCelular_F);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCELULAR_F_SEL", AV26TFResponsavelCelular_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL", AV27TFResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL_SEL", AV28TFResponsavelEmail_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRESPONSAVELCARGO_SELS", AV30TFResponsavelCargo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRESPONSAVELCARGO_SELS", AV30TFResponsavelCargo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV31TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV32TFClienteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV33TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV34TFClienteRazaoSocial_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTESITUACAO_SELS", AV36TFClienteSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTESITUACAO_SELS", AV36TFClienteSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFClienteStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCARGO_SELSJSON", AV29TFResponsavelCargo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESITUACAO_SELSJSON", AV35TFClienteSituacao_SelsJson);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ClienteId_Selected), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A454ResponsavelDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A455ResponsavelNumero), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Title", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Result", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUDE_Result", StringUtil.RTrim( Dvelop_confirmpanel_exclude_Result));
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
            WE952( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT952( ) ;
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
         return formatLink("wprepresentantes")  ;
      }

      public override string GetPgmname( )
      {
         return "WpRepresentantes" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cliente" ;
      }

      protected void WB950( )
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncreate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Inserir", bttBtncreate_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCREATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpRepresentantes.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpRepresentantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDefaultfilter_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTipoclienteid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclienteid_Internalname, "Tipo Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TipoClienteId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTipoclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV52TipoClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV52TipoClienteId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclienteid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipoclienteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentantes.htm");
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
            StartGridControl44( ) ;
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            nRC_GXsfl_44 = (int)(nGXsfl_44_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV40GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV41GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV42GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            wb_table1_68_952( true) ;
         }
         else
         {
            wb_table1_68_952( false) ;
         }
         return  ;
      }

      protected void wb_table1_68_952e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_titlescategories.SetProperty("GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, "GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 44 )
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

      protected void START952( )
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
         Form.Meta.addItem("description", " Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP950( ) ;
      }

      protected void WS952( )
      {
         START952( ) ;
         EVT952( ) ;
      }

      protected void EVT952( )
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
                              E11952 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12952 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13952 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14952 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_EXCLUDE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_exclude.Close */
                              E15952 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCREATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCreate' */
                              E16952 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VCONSULT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "VPUT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VCONSULT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "VPUT.CLICK") == 0 ) )
                           {
                              nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
                              SubsflControlProps_442( ) ;
                              AV47Consult = cgiGet( edtavConsult_Internalname);
                              AssignAttri("", false, edtavConsult_Internalname, AV47Consult);
                              AV48Put = cgiGet( edtavPut_Internalname);
                              AssignAttri("", false, edtavPut_Internalname, AV48Put);
                              AV49Exclude = cgiGet( edtavExclude_Internalname);
                              AssignAttri("", false, edtavExclude_Internalname, AV49Exclude);
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A436ResponsavelNome = cgiGet( edtResponsavelNome_Internalname);
                              n436ResponsavelNome = false;
                              A447ResponsavelCPF = cgiGet( edtResponsavelCPF_Internalname);
                              n447ResponsavelCPF = false;
                              A577ResponsavelCelular_F = cgiGet( edtResponsavelCelular_F_Internalname);
                              A456ResponsavelEmail = cgiGet( edtResponsavelEmail_Internalname);
                              n456ResponsavelEmail = false;
                              cmbResponsavelCargo.Name = cmbResponsavelCargo_Internalname;
                              cmbResponsavelCargo.CurrentValue = cgiGet( cmbResponsavelCargo_Internalname);
                              A885ResponsavelCargo = cgiGet( cmbResponsavelCargo_Internalname);
                              n885ResponsavelCargo = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
                              n171ClienteNomeFantasia = false;
                              cmbClienteTipoPessoa.Name = cmbClienteTipoPessoa_Internalname;
                              cmbClienteTipoPessoa.CurrentValue = cgiGet( cmbClienteTipoPessoa_Internalname);
                              A172ClienteTipoPessoa = cgiGet( cmbClienteTipoPessoa_Internalname);
                              n172ClienteTipoPessoa = false;
                              A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
                              n193TipoClienteDescricao = false;
                              cmbClienteSituacao.Name = cmbClienteSituacao_Internalname;
                              cmbClienteSituacao.CurrentValue = cgiGet( cmbClienteSituacao_Internalname);
                              A884ClienteSituacao = cgiGet( cmbClienteSituacao_Internalname);
                              n884ClienteSituacao = false;
                              cmbClienteStatus.Name = cmbClienteStatus_Internalname;
                              cmbClienteStatus.CurrentValue = cgiGet( cmbClienteStatus_Internalname);
                              A174ClienteStatus = StringUtil.StrToBool( cgiGet( cmbClienteStatus_Internalname));
                              n174ClienteStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17952 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18952 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19952 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCONSULT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E20952 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VPUT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21952 ();
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

      protected void WE952( )
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

      protected void PA952( )
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
         SubsflControlProps_442( ) ;
         while ( nGXsfl_44_idx <= nRC_GXsfl_44 )
         {
            sendrow_442( ) ;
            nGXsfl_44_idx = ((subGrid_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV53Pgmname ,
                                       string AV14FilterFullText ,
                                       short AV52TipoClienteId ,
                                       string AV21TFResponsavelNome ,
                                       string AV22TFResponsavelNome_Sel ,
                                       string AV23TFResponsavelCPF ,
                                       string AV24TFResponsavelCPF_Sel ,
                                       string AV25TFResponsavelCelular_F ,
                                       string AV26TFResponsavelCelular_F_Sel ,
                                       string AV27TFResponsavelEmail ,
                                       string AV28TFResponsavelEmail_Sel ,
                                       GxSimpleCollection<string> AV30TFResponsavelCargo_Sels ,
                                       string AV31TFClienteDocumento ,
                                       string AV32TFClienteDocumento_Sel ,
                                       string AV33TFClienteRazaoSocial ,
                                       string AV34TFClienteRazaoSocial_Sel ,
                                       GxSimpleCollection<string> AV36TFClienteSituacao_Sels ,
                                       short AV37TFClienteStatus_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF952( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", "")));
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
         RF952( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "WpRepresentantes";
         edtavConsult_Enabled = 0;
         edtavPut_Enabled = 0;
         edtavExclude_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV64Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV69Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV57Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV56Wprepresentantesds_3_tfresponsavelnome ,
                                              AV59Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV58Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV63Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV62Wprepresentantesds_9_tfresponsavelemail ,
                                              AV64Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV66Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV65Wprepresentantesds_12_tfclientedocumento ,
                                              AV68Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV67Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV69Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV70Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV54Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV60Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV56Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV58Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV58Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV62Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV62Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV65Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV65Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV67Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV67Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor H00952 */
         pr_default.execute(0, new Object[] {lV56Wprepresentantesds_3_tfresponsavelnome, AV57Wprepresentantesds_4_tfresponsavelnome_sel, lV58Wprepresentantesds_5_tfresponsavelcpf, AV59Wprepresentantesds_6_tfresponsavelcpf_sel, lV62Wprepresentantesds_9_tfresponsavelemail, AV63Wprepresentantesds_10_tfresponsavelemail_sel, lV65Wprepresentantesds_12_tfclientedocumento, AV66Wprepresentantesds_13_tfclientedocumento_sel, lV67Wprepresentantesds_14_tfclienterazaosocial, AV68Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A192TipoClienteId = H00952_A192TipoClienteId[0];
            n192TipoClienteId = H00952_n192TipoClienteId[0];
            A174ClienteStatus = H00952_A174ClienteStatus[0];
            n174ClienteStatus = H00952_n174ClienteStatus[0];
            A884ClienteSituacao = H00952_A884ClienteSituacao[0];
            n884ClienteSituacao = H00952_n884ClienteSituacao[0];
            A193TipoClienteDescricao = H00952_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H00952_n193TipoClienteDescricao[0];
            A172ClienteTipoPessoa = H00952_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H00952_n172ClienteTipoPessoa[0];
            A171ClienteNomeFantasia = H00952_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H00952_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = H00952_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00952_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = H00952_A169ClienteDocumento[0];
            n169ClienteDocumento = H00952_n169ClienteDocumento[0];
            A885ResponsavelCargo = H00952_A885ResponsavelCargo[0];
            n885ResponsavelCargo = H00952_n885ResponsavelCargo[0];
            A456ResponsavelEmail = H00952_A456ResponsavelEmail[0];
            n456ResponsavelEmail = H00952_n456ResponsavelEmail[0];
            A447ResponsavelCPF = H00952_A447ResponsavelCPF[0];
            n447ResponsavelCPF = H00952_n447ResponsavelCPF[0];
            A436ResponsavelNome = H00952_A436ResponsavelNome[0];
            n436ResponsavelNome = H00952_n436ResponsavelNome[0];
            A168ClienteId = H00952_A168ClienteId[0];
            A455ResponsavelNumero = H00952_A455ResponsavelNumero[0];
            n455ResponsavelNumero = H00952_n455ResponsavelNumero[0];
            A454ResponsavelDDD = H00952_A454ResponsavelDDD[0];
            n454ResponsavelDDD = H00952_n454ResponsavelDDD[0];
            A193TipoClienteDescricao = H00952_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H00952_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV60Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF952( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 44;
         /* Execute user event: Refresh */
         E18952 ();
         nGXsfl_44_idx = 1;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         bGXsfl_44_Refreshing = true;
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
            SubsflControlProps_442( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A885ResponsavelCargo ,
                                                 AV64Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                                 A884ClienteSituacao ,
                                                 AV69Wprepresentantesds_16_tfclientesituacao_sels ,
                                                 AV57Wprepresentantesds_4_tfresponsavelnome_sel ,
                                                 AV56Wprepresentantesds_3_tfresponsavelnome ,
                                                 AV59Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                                 AV58Wprepresentantesds_5_tfresponsavelcpf ,
                                                 AV63Wprepresentantesds_10_tfresponsavelemail_sel ,
                                                 AV62Wprepresentantesds_9_tfresponsavelemail ,
                                                 AV64Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                                 AV66Wprepresentantesds_13_tfclientedocumento_sel ,
                                                 AV65Wprepresentantesds_12_tfclientedocumento ,
                                                 AV68Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                                 AV67Wprepresentantesds_14_tfclienterazaosocial ,
                                                 AV69Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                                 AV70Wprepresentantesds_17_tfclientestatus_sel ,
                                                 A436ResponsavelNome ,
                                                 A447ResponsavelCPF ,
                                                 A456ResponsavelEmail ,
                                                 A169ClienteDocumento ,
                                                 A170ClienteRazaoSocial ,
                                                 A174ClienteStatus ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV54Wprepresentantesds_1_filterfulltext ,
                                                 A577ResponsavelCelular_F ,
                                                 AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                                 AV60Wprepresentantesds_7_tfresponsavelcelular_f ,
                                                 A192TipoClienteId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV56Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV56Wprepresentantesds_3_tfresponsavelnome), "%", "");
            lV58Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV58Wprepresentantesds_5_tfresponsavelcpf), "%", "");
            lV62Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV62Wprepresentantesds_9_tfresponsavelemail), "%", "");
            lV65Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV65Wprepresentantesds_12_tfclientedocumento), "%", "");
            lV67Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV67Wprepresentantesds_14_tfclienterazaosocial), "%", "");
            /* Using cursor H00953 */
            pr_default.execute(1, new Object[] {lV56Wprepresentantesds_3_tfresponsavelnome, AV57Wprepresentantesds_4_tfresponsavelnome_sel, lV58Wprepresentantesds_5_tfresponsavelcpf, AV59Wprepresentantesds_6_tfresponsavelcpf_sel, lV62Wprepresentantesds_9_tfresponsavelemail, AV63Wprepresentantesds_10_tfresponsavelemail_sel, lV65Wprepresentantesds_12_tfclientedocumento, AV66Wprepresentantesds_13_tfclientedocumento_sel, lV67Wprepresentantesds_14_tfclienterazaosocial, AV68Wprepresentantesds_15_tfclienterazaosocial_sel});
            nGXsfl_44_idx = 1;
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A192TipoClienteId = H00953_A192TipoClienteId[0];
               n192TipoClienteId = H00953_n192TipoClienteId[0];
               A174ClienteStatus = H00953_A174ClienteStatus[0];
               n174ClienteStatus = H00953_n174ClienteStatus[0];
               A884ClienteSituacao = H00953_A884ClienteSituacao[0];
               n884ClienteSituacao = H00953_n884ClienteSituacao[0];
               A193TipoClienteDescricao = H00953_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00953_n193TipoClienteDescricao[0];
               A172ClienteTipoPessoa = H00953_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H00953_n172ClienteTipoPessoa[0];
               A171ClienteNomeFantasia = H00953_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H00953_n171ClienteNomeFantasia[0];
               A170ClienteRazaoSocial = H00953_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H00953_n170ClienteRazaoSocial[0];
               A169ClienteDocumento = H00953_A169ClienteDocumento[0];
               n169ClienteDocumento = H00953_n169ClienteDocumento[0];
               A885ResponsavelCargo = H00953_A885ResponsavelCargo[0];
               n885ResponsavelCargo = H00953_n885ResponsavelCargo[0];
               A456ResponsavelEmail = H00953_A456ResponsavelEmail[0];
               n456ResponsavelEmail = H00953_n456ResponsavelEmail[0];
               A447ResponsavelCPF = H00953_A447ResponsavelCPF[0];
               n447ResponsavelCPF = H00953_n447ResponsavelCPF[0];
               A436ResponsavelNome = H00953_A436ResponsavelNome[0];
               n436ResponsavelNome = H00953_n436ResponsavelNome[0];
               A168ClienteId = H00953_A168ClienteId[0];
               A455ResponsavelNumero = H00953_A455ResponsavelNumero[0];
               n455ResponsavelNumero = H00953_n455ResponsavelNumero[0];
               A454ResponsavelDDD = H00953_A454ResponsavelDDD[0];
               n454ResponsavelDDD = H00953_n454ResponsavelDDD[0];
               A193TipoClienteDescricao = H00953_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00953_n193TipoClienteDescricao[0];
               GXt_char1 = A577ResponsavelCelular_F;
               new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
               A577ResponsavelCelular_F = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
               ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
               ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV54Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
               ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
               ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
               )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV60Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E19952 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 44;
            WB950( ) ;
         }
         bGXsfl_44_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes952( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_44_idx, GetSecureSignedToken( sGXsfl_44_idx, context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
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
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "WpRepresentantes";
         edtavConsult_Enabled = 0;
         edtavPut_Enabled = 0;
         edtavExclude_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtResponsavelNome_Enabled = 0;
         edtResponsavelCPF_Enabled = 0;
         edtResponsavelCelular_F_Enabled = 0;
         edtResponsavelEmail_Enabled = 0;
         cmbResponsavelCargo.Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         cmbClienteSituacao.Enabled = 0;
         cmbClienteStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP950( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17952 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV38DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_44 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_44"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV41GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV42GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV50ClienteId_Selected = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEID_SELECTED"), ",", "."), 18, MidpointRounding.ToEven));
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
            Dvelop_confirmpanel_exclude_Title = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Title");
            Dvelop_confirmpanel_exclude_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Confirmationtext");
            Dvelop_confirmpanel_exclude_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Yesbuttoncaption");
            Dvelop_confirmpanel_exclude_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Nobuttoncaption");
            Dvelop_confirmpanel_exclude_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Cancelbuttoncaption");
            Dvelop_confirmpanel_exclude_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Yesbuttonposition");
            Dvelop_confirmpanel_exclude_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Confirmtype");
            Grid_titlescategories_Gridinternalname = cgiGet( "GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( "GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascategories"));
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_exclude_Result = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUDE_Result");
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOCLIENTEID");
               GX_FocusControl = edtavTipoclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52TipoClienteId = 0;
               AssignAttri("", false, "AV52TipoClienteId", StringUtil.LTrimStr( (decimal)(AV52TipoClienteId), 4, 0));
            }
            else
            {
               AV52TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TipoClienteId", StringUtil.LTrimStr( (decimal)(AV52TipoClienteId), 4, 0));
            }
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
         E17952 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17952( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Cliente";
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
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV38DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV38DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18952( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
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
         AV40GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV40GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV40GridCurrentPage), 10, 0));
         AV41GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV41GridPageCount", StringUtil.LTrimStr( (decimal)(AV41GridPageCount), 10, 0));
         GXt_char1 = AV42GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV53Pgmname, out  GXt_char1) ;
         AV42GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV42GridAppliedFilters", AV42GridAppliedFilters);
         cmbClienteSituacao_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteSituacao_Internalname, "Columnheaderclass", cmbClienteSituacao_Columnheaderclass, !bGXsfl_44_Refreshing);
         cmbClienteStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteStatus_Internalname, "Columnheaderclass", cmbClienteStatus_Columnheaderclass, !bGXsfl_44_Refreshing);
         AV54Wprepresentantesds_1_filterfulltext = AV14FilterFullText;
         AV55Wprepresentantesds_2_tipoclienteid = AV52TipoClienteId;
         AV56Wprepresentantesds_3_tfresponsavelnome = AV21TFResponsavelNome;
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = AV22TFResponsavelNome_Sel;
         AV58Wprepresentantesds_5_tfresponsavelcpf = AV23TFResponsavelCPF;
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = AV24TFResponsavelCPF_Sel;
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = AV25TFResponsavelCelular_F;
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV26TFResponsavelCelular_F_Sel;
         AV62Wprepresentantesds_9_tfresponsavelemail = AV27TFResponsavelEmail;
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = AV28TFResponsavelEmail_Sel;
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = AV30TFResponsavelCargo_Sels;
         AV65Wprepresentantesds_12_tfclientedocumento = AV31TFClienteDocumento;
         AV66Wprepresentantesds_13_tfclientedocumento_sel = AV32TFClienteDocumento_Sel;
         AV67Wprepresentantesds_14_tfclienterazaosocial = AV33TFClienteRazaoSocial;
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = AV34TFClienteRazaoSocial_Sel;
         AV69Wprepresentantesds_16_tfclientesituacao_sels = AV36TFClienteSituacao_Sels;
         AV70Wprepresentantesds_17_tfclientestatus_sel = AV37TFClienteStatus_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12952( )
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
            AV39PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV39PageToGo) ;
         }
      }

      protected void E13952( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14952( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelNome") == 0 )
            {
               AV21TFResponsavelNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV21TFResponsavelNome", AV21TFResponsavelNome);
               AV22TFResponsavelNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV22TFResponsavelNome_Sel", AV22TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCPF") == 0 )
            {
               AV23TFResponsavelCPF = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV23TFResponsavelCPF", AV23TFResponsavelCPF);
               AV24TFResponsavelCPF_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV24TFResponsavelCPF_Sel", AV24TFResponsavelCPF_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCelular_F") == 0 )
            {
               AV25TFResponsavelCelular_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV25TFResponsavelCelular_F", AV25TFResponsavelCelular_F);
               AV26TFResponsavelCelular_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV26TFResponsavelCelular_F_Sel", AV26TFResponsavelCelular_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelEmail") == 0 )
            {
               AV27TFResponsavelEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFResponsavelEmail", AV27TFResponsavelEmail);
               AV28TFResponsavelEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFResponsavelEmail_Sel", AV28TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCargo") == 0 )
            {
               AV29TFResponsavelCargo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFResponsavelCargo_SelsJson", AV29TFResponsavelCargo_SelsJson);
               AV30TFResponsavelCargo_Sels.FromJSonString(AV29TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV31TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFClienteDocumento", AV31TFClienteDocumento);
               AV32TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFClienteDocumento_Sel", AV32TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV33TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFClienteRazaoSocial", AV33TFClienteRazaoSocial);
               AV34TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFClienteRazaoSocial_Sel", AV34TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteSituacao") == 0 )
            {
               AV35TFClienteSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFClienteSituacao_SelsJson", AV35TFClienteSituacao_SelsJson);
               AV36TFClienteSituacao_Sels.FromJSonString(AV35TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteStatus") == 0 )
            {
               AV37TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV37TFClienteStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36TFClienteSituacao_Sels", AV36TFClienteSituacao_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFResponsavelCargo_Sels", AV30TFResponsavelCargo_Sels);
      }

      private void E19952( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV47Consult = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavConsult_Internalname, AV47Consult);
            AV48Put = "<i class=\"fa fa-pencil\"></i>";
            AssignAttri("", false, edtavPut_Internalname, AV48Put);
            AV49Exclude = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavExclude_Internalname, AV49Exclude);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
            edtClienteDocumento_Link = formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 )
            {
               cmbClienteSituacao_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else if ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 )
            {
               cmbClienteSituacao_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else
            {
               cmbClienteSituacao_Columnclass = "WWColumn";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
            {
               cmbClienteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
            {
               cmbClienteStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else
            {
               cmbClienteStatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 44;
            }
            sendrow_442( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_44_Refreshing )
         {
            DoAjaxLoad(44, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11952( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpRepresentantesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV53Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpRepresentantesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpRepresentantesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV19ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV10GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFResponsavelCargo_Sels", AV30TFResponsavelCargo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36TFClienteSituacao_Sels", AV36TFClienteSituacao_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E15952( )
      {
         /* Dvelop_confirmpanel_exclude_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_exclude_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO EXCLUDE' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16952( )
      {
         /* 'DoCreate' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wzcadastrorepresentante"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("wzcadastrorepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpRepresentantesFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV52TipoClienteId = 0;
         AssignAttri("", false, "AV52TipoClienteId", StringUtil.LTrimStr( (decimal)(AV52TipoClienteId), 4, 0));
         AV21TFResponsavelNome = "";
         AssignAttri("", false, "AV21TFResponsavelNome", AV21TFResponsavelNome);
         AV22TFResponsavelNome_Sel = "";
         AssignAttri("", false, "AV22TFResponsavelNome_Sel", AV22TFResponsavelNome_Sel);
         AV23TFResponsavelCPF = "";
         AssignAttri("", false, "AV23TFResponsavelCPF", AV23TFResponsavelCPF);
         AV24TFResponsavelCPF_Sel = "";
         AssignAttri("", false, "AV24TFResponsavelCPF_Sel", AV24TFResponsavelCPF_Sel);
         AV25TFResponsavelCelular_F = "";
         AssignAttri("", false, "AV25TFResponsavelCelular_F", AV25TFResponsavelCelular_F);
         AV26TFResponsavelCelular_F_Sel = "";
         AssignAttri("", false, "AV26TFResponsavelCelular_F_Sel", AV26TFResponsavelCelular_F_Sel);
         AV27TFResponsavelEmail = "";
         AssignAttri("", false, "AV27TFResponsavelEmail", AV27TFResponsavelEmail);
         AV28TFResponsavelEmail_Sel = "";
         AssignAttri("", false, "AV28TFResponsavelEmail_Sel", AV28TFResponsavelEmail_Sel);
         AV30TFResponsavelCargo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31TFClienteDocumento = "";
         AssignAttri("", false, "AV31TFClienteDocumento", AV31TFClienteDocumento);
         AV32TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV32TFClienteDocumento_Sel", AV32TFClienteDocumento_Sel);
         AV33TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV33TFClienteRazaoSocial", AV33TFClienteRazaoSocial);
         AV34TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV34TFClienteRazaoSocial_Sel", AV34TFClienteRazaoSocial_Sel);
         AV36TFClienteSituacao_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37TFClienteStatus_Sel = 0;
         AssignAttri("", false, "AV37TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV37TFClienteStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S182( )
      {
         /* 'DO EXCLUDE' Routine */
         returnInSub = false;
         GXt_SdtSdErro4 = AV51SdErro;
         new prdeletarepresentante(context ).execute(  AV50ClienteId_Selected, out  GXt_SdtSdErro4) ;
         AV51SdErro = GXt_SdtSdErro4;
         if ( AV51SdErro.gxTpr_Status != 204 )
         {
            context.RollbackDataStores("wprepresentantes",pr_default);
            GX_msglist.addItem(StringUtil.Trim( AV51SdErro.gxTpr_Msg));
         }
         else
         {
            context.CommitDataStores("wprepresentantes",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV20ManageFiltersExecutionStep, AV53Pgmname, AV14FilterFullText, AV52TipoClienteId, AV21TFResponsavelNome, AV22TFResponsavelNome_Sel, AV23TFResponsavelCPF, AV24TFResponsavelCPF_Sel, AV25TFResponsavelCelular_F, AV26TFResponsavelCelular_F_Sel, AV27TFResponsavelEmail, AV28TFResponsavelEmail_Sel, AV30TFResponsavelCargo_Sels, AV31TFClienteDocumento, AV32TFClienteDocumento_Sel, AV33TFClienteRazaoSocial, AV34TFClienteRazaoSocial_Sel, AV36TFClienteSituacao_Sels, AV37TFClienteStatus_Sel) ;
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV53Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV53Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV17Session.Get(AV53Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV52TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TipoClienteId", StringUtil.LTrimStr( (decimal)(AV52TipoClienteId), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV21TFResponsavelNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFResponsavelNome", AV21TFResponsavelNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV22TFResponsavelNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFResponsavelNome_Sel", AV22TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV23TFResponsavelCPF = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFResponsavelCPF", AV23TFResponsavelCPF);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV24TFResponsavelCPF_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFResponsavelCPF_Sel", AV24TFResponsavelCPF_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV25TFResponsavelCelular_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25TFResponsavelCelular_F", AV25TFResponsavelCelular_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV26TFResponsavelCelular_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFResponsavelCelular_F_Sel", AV26TFResponsavelCelular_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV27TFResponsavelEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFResponsavelEmail", AV27TFResponsavelEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV28TFResponsavelEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFResponsavelEmail_Sel", AV28TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV29TFResponsavelCargo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFResponsavelCargo_SelsJson", AV29TFResponsavelCargo_SelsJson);
               AV30TFResponsavelCargo_Sels.FromJSonString(AV29TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV31TFClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFClienteDocumento", AV31TFClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV32TFClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFClienteDocumento_Sel", AV32TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV33TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFClienteRazaoSocial", AV33TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV34TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFClienteRazaoSocial_Sel", AV34TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV35TFClienteSituacao_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFClienteSituacao_SelsJson", AV35TFClienteSituacao_SelsJson);
               AV36TFClienteSituacao_Sels.FromJSonString(AV35TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV37TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV37TFClienteStatus_Sel), 1, 0));
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFResponsavelNome_Sel)),  AV22TFResponsavelNome_Sel, out  GXt_char1) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFResponsavelCPF_Sel)),  AV24TFResponsavelCPF_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFResponsavelCelular_F_Sel)),  AV26TFResponsavelCelular_F_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResponsavelEmail_Sel)),  AV28TFResponsavelEmail_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFResponsavelCargo_Sels.Count==0),  AV29TFResponsavelCargo_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFClienteDocumento_Sel)),  AV32TFClienteDocumento_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFClienteRazaoSocial_Sel)),  AV34TFClienteRazaoSocial_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV36TFClienteSituacao_Sels.Count==0),  AV35TFClienteSituacao_SelsJson, out  GXt_char11) ;
         Ddo_grid_Selectedvalue_set = GXt_char1+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+((0==AV37TFClienteStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV37TFClienteStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFResponsavelNome)),  AV21TFResponsavelNome, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFResponsavelCPF)),  AV23TFResponsavelCPF, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFResponsavelCelular_F)),  AV25TFResponsavelCelular_F, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResponsavelEmail)),  AV27TFResponsavelEmail, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFClienteDocumento)),  AV31TFClienteDocumento, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFClienteRazaoSocial)),  AV33TFClienteRazaoSocial, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"||"+GXt_char7+"|"+GXt_char6+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV17Session.Get(AV53Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TIPOCLIENTEID",  "Tipo Cliente Id",  !(0==AV52TipoClienteId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV52TipoClienteId), 4, 0)),  StringUtil.Trim( context.localUtil.Format( (decimal)(AV52TipoClienteId), "ZZZ9")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELNOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFResponsavelNome)),  0,  AV21TFResponsavelNome,  AV21TFResponsavelNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFResponsavelNome_Sel)),  AV22TFResponsavelNome_Sel,  AV22TFResponsavelNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCPF",  "CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFResponsavelCPF)),  0,  AV23TFResponsavelCPF,  AV23TFResponsavelCPF,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFResponsavelCPF_Sel)),  AV24TFResponsavelCPF_Sel,  AV24TFResponsavelCPF_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCELULAR_F",  "Celular",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFResponsavelCelular_F)),  0,  AV25TFResponsavelCelular_F,  AV25TFResponsavelCelular_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFResponsavelCelular_F_Sel)),  AV26TFResponsavelCelular_F_Sel,  AV26TFResponsavelCelular_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResponsavelEmail)),  0,  AV27TFResponsavelEmail,  AV27TFResponsavelEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResponsavelEmail_Sel)),  AV28TFResponsavelEmail_Sel,  AV28TFResponsavelEmail_Sel) ;
         AV46AuxText = ((AV30TFResponsavelCargo_Sels.Count==1) ? "["+((string)AV30TFResponsavelCargo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCARGO_SEL",  "Cargo",  !(AV30TFResponsavelCargo_Sels.Count==0),  0,  AV30TFResponsavelCargo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV46AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV46AuxText, "[DIRETOR]", "DIRETOR"), "[GERENTE]", "GERENTE"), "[COORDENADOR]", "COORDENADOR"), "[SUPERVISOR]", "SUPERVISOR"), "[ANALISTA]", "ANALISTA"), "[ASSISTENTE]", "ASSISTENTE"), "[ESTAGIARIO]", "ESTAGIARIO"), "[OUTRO]", "OUTRO")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTEDOCUMENTO",  "CNPJ",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFClienteDocumento)),  0,  AV31TFClienteDocumento,  AV31TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFClienteDocumento_Sel)),  AV32TFClienteDocumento_Sel,  AV32TFClienteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão Social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFClienteRazaoSocial)),  0,  AV33TFClienteRazaoSocial,  AV33TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFClienteRazaoSocial_Sel)),  AV34TFClienteRazaoSocial_Sel,  AV34TFClienteRazaoSocial_Sel) ;
         AV46AuxText = ((AV36TFClienteSituacao_Sels.Count==1) ? "["+AV36TFClienteSituacao_Sels.GetString(1)+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESITUACAO_SEL",  "Situação",  !(AV36TFClienteSituacao_Sels.Count==0),  0,  AV36TFClienteSituacao_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV46AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV46AuxText, "[P]", "Aguardando Análise"), "[A]", "Aprovado"), "[R]", "Rejeitado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESTATUS_SEL",  "Status",  !(0==AV37TFClienteStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFClienteStatus_Sel), 1, 0)),  ((AV37TFClienteStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV53Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Cliente";
         AV17Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E20952( )
      {
         /* Consult_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpconsultaeditarepresentante"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wpconsultaeditarepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E21952( )
      {
         /* Put_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpconsultaeditarepresentante"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wpconsultaeditarepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void wb_table1_68_952( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_exclude_Internalname, tblTabledvelop_confirmpanel_exclude_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_exclude.SetProperty("Title", Dvelop_confirmpanel_exclude_Title);
            ucDvelop_confirmpanel_exclude.SetProperty("ConfirmationText", Dvelop_confirmpanel_exclude_Confirmationtext);
            ucDvelop_confirmpanel_exclude.SetProperty("YesButtonCaption", Dvelop_confirmpanel_exclude_Yesbuttoncaption);
            ucDvelop_confirmpanel_exclude.SetProperty("NoButtonCaption", Dvelop_confirmpanel_exclude_Nobuttoncaption);
            ucDvelop_confirmpanel_exclude.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_exclude_Cancelbuttoncaption);
            ucDvelop_confirmpanel_exclude.SetProperty("YesButtonPosition", Dvelop_confirmpanel_exclude_Yesbuttonposition);
            ucDvelop_confirmpanel_exclude.SetProperty("ConfirmType", Dvelop_confirmpanel_exclude_Confirmtype);
            ucDvelop_confirmpanel_exclude.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_exclude_Internalname, "DVELOP_CONFIRMPANEL_EXCLUDEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_EXCLUDEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_68_952e( true) ;
         }
         else
         {
            wb_table1_68_952e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA952( ) ;
         WS952( ) ;
         WE952( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019275929", true, true);
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
         context.AddJavascriptSource("wprepresentantes.js", "?202561019275929", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_442( )
      {
         edtavConsult_Internalname = "vCONSULT_"+sGXsfl_44_idx;
         edtavPut_Internalname = "vPUT_"+sGXsfl_44_idx;
         edtavExclude_Internalname = "vEXCLUDE_"+sGXsfl_44_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_44_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_44_idx;
         edtResponsavelCPF_Internalname = "RESPONSAVELCPF_"+sGXsfl_44_idx;
         edtResponsavelCelular_F_Internalname = "RESPONSAVELCELULAR_F_"+sGXsfl_44_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_44_idx;
         cmbResponsavelCargo_Internalname = "RESPONSAVELCARGO_"+sGXsfl_44_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_44_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_44_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_44_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_44_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_44_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_44_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_44_idx;
      }

      protected void SubsflControlProps_fel_442( )
      {
         edtavConsult_Internalname = "vCONSULT_"+sGXsfl_44_fel_idx;
         edtavPut_Internalname = "vPUT_"+sGXsfl_44_fel_idx;
         edtavExclude_Internalname = "vEXCLUDE_"+sGXsfl_44_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_44_fel_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_44_fel_idx;
         edtResponsavelCPF_Internalname = "RESPONSAVELCPF_"+sGXsfl_44_fel_idx;
         edtResponsavelCelular_F_Internalname = "RESPONSAVELCELULAR_F_"+sGXsfl_44_fel_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_44_fel_idx;
         cmbResponsavelCargo_Internalname = "RESPONSAVELCARGO_"+sGXsfl_44_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_44_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_44_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_44_fel_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_44_fel_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_44_fel_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_44_fel_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_44_fel_idx;
      }

      protected void sendrow_442( )
      {
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         WB950( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_44_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_44_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_44_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsult_Internalname,StringUtil.RTrim( AV47Consult),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"","'"+""+"'"+",false,"+"'"+"EVCONSULT.CLICK."+sGXsfl_44_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavConsult_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsult_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPut_Internalname,StringUtil.RTrim( AV48Put),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"","'"+""+"'"+",false,"+"'"+"EVPUT.CLICK."+sGXsfl_44_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPut_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavPut_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExclude_Internalname,StringUtil.RTrim( AV49Exclude),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+"e22952_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExclude_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavExclude_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelNome_Internalname,(string)A436ResponsavelNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelCPF_Internalname,(string)A447ResponsavelCPF,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelCelular_F_Internalname,(string)A577ResponsavelCelular_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelCelular_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelEmail_Internalname,(string)A456ResponsavelEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A456ResponsavelEmail,(string)"",(string)"",(string)"",(string)edtResponsavelEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbResponsavelCargo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESPONSAVELCARGO_" + sGXsfl_44_idx;
               cmbResponsavelCargo.Name = GXCCtl;
               cmbResponsavelCargo.WebTags = "";
               cmbResponsavelCargo.addItem("DIRETOR", "DIRETOR", 0);
               cmbResponsavelCargo.addItem("GERENTE", "GERENTE", 0);
               cmbResponsavelCargo.addItem("COORDENADOR", "COORDENADOR", 0);
               cmbResponsavelCargo.addItem("SUPERVISOR", "SUPERVISOR", 0);
               cmbResponsavelCargo.addItem("ANALISTA", "ANALISTA", 0);
               cmbResponsavelCargo.addItem("ASSISTENTE", "ASSISTENTE", 0);
               cmbResponsavelCargo.addItem("ESTAGIARIO", "ESTAGIARIO", 0);
               cmbResponsavelCargo.addItem("OUTRO", "OUTRO", 0);
               if ( cmbResponsavelCargo.ItemCount > 0 )
               {
                  A885ResponsavelCargo = cmbResponsavelCargo.getValidValue(A885ResponsavelCargo);
                  n885ResponsavelCargo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbResponsavelCargo,(string)cmbResponsavelCargo_Internalname,StringUtil.RTrim( A885ResponsavelCargo),(short)1,(string)cmbResponsavelCargo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbResponsavelCargo.CurrentValue = StringUtil.RTrim( A885ResponsavelCargo);
            AssignProp("", false, cmbResponsavelCargo_Internalname, "Values", (string)(cmbResponsavelCargo.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtClienteDocumento_Link,(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbClienteTipoPessoa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_44_idx;
               cmbClienteTipoPessoa.Name = GXCCtl;
               cmbClienteTipoPessoa.WebTags = "";
               cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
               cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
               if ( cmbClienteTipoPessoa.ItemCount > 0 )
               {
                  A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
                  n172ClienteTipoPessoa = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteTipoPessoa,(string)cmbClienteTipoPessoa_Internalname,StringUtil.RTrim( A172ClienteTipoPessoa),(short)1,(string)cmbClienteTipoPessoa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A172ClienteTipoPessoa);
            AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", (string)(cmbClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteDescricao_Internalname,(string)A193TipoClienteDescricao,StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESITUACAO_" + sGXsfl_44_idx;
               cmbClienteSituacao.Name = GXCCtl;
               cmbClienteSituacao.WebTags = "";
               cmbClienteSituacao.addItem("P", "Aguardando Análise", 0);
               cmbClienteSituacao.addItem("A", "Aprovado", 0);
               cmbClienteSituacao.addItem("R", "Rejeitado", 0);
               if ( cmbClienteSituacao.ItemCount > 0 )
               {
                  A884ClienteSituacao = cmbClienteSituacao.getValidValue(A884ClienteSituacao);
                  n884ClienteSituacao = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteSituacao,(string)cmbClienteSituacao_Internalname,StringUtil.RTrim( A884ClienteSituacao),(short)1,(string)cmbClienteSituacao_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbClienteSituacao_Columnclass,(string)cmbClienteSituacao_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbClienteSituacao.CurrentValue = StringUtil.RTrim( A884ClienteSituacao);
            AssignProp("", false, cmbClienteSituacao_Internalname, "Values", (string)(cmbClienteSituacao.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESTATUS_" + sGXsfl_44_idx;
               cmbClienteStatus.Name = GXCCtl;
               cmbClienteStatus.WebTags = "";
               cmbClienteStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
               cmbClienteStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
               if ( cmbClienteStatus.ItemCount > 0 )
               {
                  A174ClienteStatus = StringUtil.StrToBool( cmbClienteStatus.getValidValue(StringUtil.BoolToStr( A174ClienteStatus)));
                  n174ClienteStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteStatus,(string)cmbClienteStatus_Internalname,StringUtil.BoolToStr( A174ClienteStatus),(short)1,(string)cmbClienteStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbClienteStatus_Columnclass,(string)cmbClienteStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbClienteStatus.CurrentValue = StringUtil.BoolToStr( A174ClienteStatus);
            AssignProp("", false, cmbClienteStatus_Internalname, "Values", (string)(cmbClienteStatus.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            send_integrity_lvl_hashes952( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_44_idx = ((subGrid_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         /* End function sendrow_442 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "RESPONSAVELCARGO_" + sGXsfl_44_idx;
         cmbResponsavelCargo.Name = GXCCtl;
         cmbResponsavelCargo.WebTags = "";
         cmbResponsavelCargo.addItem("DIRETOR", "DIRETOR", 0);
         cmbResponsavelCargo.addItem("GERENTE", "GERENTE", 0);
         cmbResponsavelCargo.addItem("COORDENADOR", "COORDENADOR", 0);
         cmbResponsavelCargo.addItem("SUPERVISOR", "SUPERVISOR", 0);
         cmbResponsavelCargo.addItem("ANALISTA", "ANALISTA", 0);
         cmbResponsavelCargo.addItem("ASSISTENTE", "ASSISTENTE", 0);
         cmbResponsavelCargo.addItem("ESTAGIARIO", "ESTAGIARIO", 0);
         cmbResponsavelCargo.addItem("OUTRO", "OUTRO", 0);
         if ( cmbResponsavelCargo.ItemCount > 0 )
         {
            A885ResponsavelCargo = cmbResponsavelCargo.getValidValue(A885ResponsavelCargo);
            n885ResponsavelCargo = false;
         }
         GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_44_idx;
         cmbClienteTipoPessoa.Name = GXCCtl;
         cmbClienteTipoPessoa.WebTags = "";
         cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
         }
         GXCCtl = "CLIENTESITUACAO_" + sGXsfl_44_idx;
         cmbClienteSituacao.Name = GXCCtl;
         cmbClienteSituacao.WebTags = "";
         cmbClienteSituacao.addItem("P", "Aguardando Análise", 0);
         cmbClienteSituacao.addItem("A", "Aprovado", 0);
         cmbClienteSituacao.addItem("R", "Rejeitado", 0);
         if ( cmbClienteSituacao.ItemCount > 0 )
         {
            A884ClienteSituacao = cmbClienteSituacao.getValidValue(A884ClienteSituacao);
            n884ClienteSituacao = false;
         }
         GXCCtl = "CLIENTESTATUS_" + sGXsfl_44_idx;
         cmbClienteStatus.Name = GXCCtl;
         cmbClienteStatus.WebTags = "";
         cmbClienteStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbClienteStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbClienteStatus.ItemCount > 0 )
         {
            A174ClienteStatus = StringUtil.StrToBool( cmbClienteStatus.getValidValue(StringUtil.BoolToStr( A174ClienteStatus)));
            n174ClienteStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl44( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"44\">") ;
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
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Celular") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cargo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CNPJ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Razão Social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo pessoa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV47Consult)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsult_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV48Put)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPut_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV49Exclude)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExclude_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A436ResponsavelNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A447ResponsavelCPF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A577ResponsavelCelular_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A456ResponsavelEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A885ResponsavelCargo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A169ClienteDocumento));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtClienteDocumento_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A171ClienteNomeFantasia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A172ClienteTipoPessoa));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193TipoClienteDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A884ClienteSituacao)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbClienteSituacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbClienteSituacao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A174ClienteStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbClienteStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbClienteStatus_Columnheaderclass));
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
         bttBtncreate_Internalname = "BTNCREATE";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         edtavTipoclienteid_Internalname = "vTIPOCLIENTEID";
         divDefaultfilter_Internalname = "DEFAULTFILTER";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavConsult_Internalname = "vCONSULT";
         edtavPut_Internalname = "vPUT";
         edtavExclude_Internalname = "vEXCLUDE";
         edtClienteId_Internalname = "CLIENTEID";
         edtResponsavelNome_Internalname = "RESPONSAVELNOME";
         edtResponsavelCPF_Internalname = "RESPONSAVELCPF";
         edtResponsavelCelular_F_Internalname = "RESPONSAVELCELULAR_F";
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL";
         cmbResponsavelCargo_Internalname = "RESPONSAVELCARGO";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA";
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO";
         cmbClienteStatus_Internalname = "CLIENTESTATUS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Dvelop_confirmpanel_exclude_Internalname = "DVELOP_CONFIRMPANEL_EXCLUDE";
         tblTabledvelop_confirmpanel_exclude_Internalname = "TABLEDVELOP_CONFIRMPANEL_EXCLUDE";
         Grid_titlescategories_Internalname = "GRID_TITLESCATEGORIES";
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
         cmbClienteStatus_Jsonclick = "";
         cmbClienteStatus_Columnclass = "WWColumn";
         cmbClienteSituacao_Jsonclick = "";
         cmbClienteSituacao_Columnclass = "WWColumn";
         edtTipoClienteDescricao_Jsonclick = "";
         cmbClienteTipoPessoa_Jsonclick = "";
         edtClienteNomeFantasia_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteDocumento_Link = "";
         cmbResponsavelCargo_Jsonclick = "";
         edtResponsavelEmail_Jsonclick = "";
         edtResponsavelCelular_F_Jsonclick = "";
         edtResponsavelCPF_Jsonclick = "";
         edtResponsavelNome_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtavExclude_Jsonclick = "";
         edtavExclude_Enabled = 1;
         edtavPut_Jsonclick = "";
         edtavPut_Enabled = 1;
         edtavConsult_Jsonclick = "";
         edtavConsult_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbClienteStatus_Columnheaderclass = "";
         cmbClienteSituacao_Columnheaderclass = "";
         cmbClienteStatus.Enabled = 0;
         cmbClienteSituacao.Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         cmbResponsavelCargo.Enabled = 0;
         edtResponsavelEmail_Enabled = 0;
         edtResponsavelCelular_F_Enabled = 0;
         edtResponsavelCPF_Enabled = 0;
         edtResponsavelNome_Enabled = 0;
         edtClienteId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavTipoclienteid_Jsonclick = "";
         edtavTipoclienteid_Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = ";;;Representante;Representante;Representante;Representante;Representante;Representante;Empresa;Empresa;;;;Status;Status";
         Dvelop_confirmpanel_exclude_Confirmtype = "1";
         Dvelop_confirmpanel_exclude_Yesbuttonposition = "left";
         Dvelop_confirmpanel_exclude_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_exclude_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_exclude_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_exclude_Confirmationtext = "Deseja excluir o representante selecionado  ?";
         Dvelop_confirmpanel_exclude_Title = "Excluir Representante";
         Ddo_grid_Datalistproc = "WpRepresentantesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||DIRETOR:DIRETOR,GERENTE:GERENTE,COORDENADOR:COORDENADOR,SUPERVISOR:SUPERVISOR,ANALISTA:ANALISTA,ASSISTENTE:ASSISTENTE,ESTAGIARIO:ESTAGIARIO,OUTRO:OUTRO|||P:Aguardando Análise,A:Aprovado,R:Rejeitado|1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Allowmultipleselection = "||||T|||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic|Dynamic|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character||Character|Character||";
         Ddo_grid_Includefilter = "T|T|T|T||T|T||";
         Ddo_grid_Includesortasc = "T|T||T|T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "2|3||4|5|1|6|7|8";
         Ddo_grid_Columnids = "4:ResponsavelNome|5:ResponsavelCPF|6:ResponsavelCelular_F|7:ResponsavelEmail|8:ResponsavelCargo|9:ClienteDocumento|10:ClienteRazaoSocial|14:ClienteSituacao|15:ClienteStatus";
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
         Form.Caption = " Cliente";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12952","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13952","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14952","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV35TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV29TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E19952","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbClienteSituacao"},{"av":"A884ClienteSituacao","fld":"CLIENTESITUACAO","type":"char"},{"av":"cmbClienteStatus"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV47Consult","fld":"vCONSULT","type":"char"},{"av":"AV48Put","fld":"vPUT","type":"char"},{"av":"AV49Exclude","fld":"vEXCLUDE","type":"char"},{"av":"edtClienteDocumento_Link","ctrl":"CLIENTEDOCUMENTO","prop":"Link"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11952","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV35TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV35TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV29TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VEXCLUDE.CLICK","""{"handler":"E22952","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VEXCLUDE.CLICK",""","oparms":[{"av":"AV50ClienteId_Selected","fld":"vCLIENTEID_SELECTED","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUDE.CLOSE","""{"handler":"E15952","iparms":[{"av":"Dvelop_confirmpanel_exclude_Result","ctrl":"DVELOP_CONFIRMPANEL_EXCLUDE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV21TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV22TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV23TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV24TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV25TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV26TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV27TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV28TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV30TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV31TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV32TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV33TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV34TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV36TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV37TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV50ClienteId_Selected","fld":"vCLIENTEID_SELECTED","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUDE.CLOSE",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOCREATE'","""{"handler":"E16952","iparms":[]}""");
         setEventMetadata("VCONSULT.CLICK","""{"handler":"E20952","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VPUT.CLICK","""{"handler":"E21952","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VALID_RESPONSAVELNOME","""{"handler":"Valid_Responsavelnome","iparms":[]}""");
         setEventMetadata("VALID_RESPONSAVELCPF","""{"handler":"Valid_Responsavelcpf","iparms":[]}""");
         setEventMetadata("VALID_RESPONSAVELCELULAR_F","""{"handler":"Valid_Responsavelcelular_f","iparms":[]}""");
         setEventMetadata("VALID_RESPONSAVELEMAIL","""{"handler":"Valid_Responsavelemail","iparms":[]}""");
         setEventMetadata("VALID_RESPONSAVELCARGO","""{"handler":"Valid_Responsavelcargo","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTO","""{"handler":"Valid_Clientedocumento","iparms":[]}""");
         setEventMetadata("VALID_CLIENTERAZAOSOCIAL","""{"handler":"Valid_Clienterazaosocial","iparms":[]}""");
         setEventMetadata("VALID_CLIENTESITUACAO","""{"handler":"Valid_Clientesituacao","iparms":[]}""");
         setEventMetadata("VALID_CLIENTESTATUS","""{"handler":"Valid_Clientestatus","iparms":[]}""");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_exclude_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV53Pgmname = "";
         AV14FilterFullText = "";
         AV21TFResponsavelNome = "";
         AV22TFResponsavelNome_Sel = "";
         AV23TFResponsavelCPF = "";
         AV24TFResponsavelCPF_Sel = "";
         AV25TFResponsavelCelular_F = "";
         AV26TFResponsavelCelular_F_Sel = "";
         AV27TFResponsavelEmail = "";
         AV28TFResponsavelEmail_Sel = "";
         AV30TFResponsavelCargo_Sels = new GxSimpleCollection<string>();
         AV31TFClienteDocumento = "";
         AV32TFClienteDocumento_Sel = "";
         AV33TFClienteRazaoSocial = "";
         AV34TFClienteRazaoSocial_Sel = "";
         AV36TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV42GridAppliedFilters = "";
         AV38DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29TFResponsavelCargo_SelsJson = "";
         AV35TFClienteSituacao_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncreate_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV47Consult = "";
         AV48Put = "";
         AV49Exclude = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A577ResponsavelCelular_F = "";
         A456ResponsavelEmail = "";
         A885ResponsavelCargo = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         A172ClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         A884ClienteSituacao = "";
         AV54Wprepresentantesds_1_filterfulltext = "";
         AV56Wprepresentantesds_3_tfresponsavelnome = "";
         AV57Wprepresentantesds_4_tfresponsavelnome_sel = "";
         AV58Wprepresentantesds_5_tfresponsavelcpf = "";
         AV59Wprepresentantesds_6_tfresponsavelcpf_sel = "";
         AV60Wprepresentantesds_7_tfresponsavelcelular_f = "";
         AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel = "";
         AV62Wprepresentantesds_9_tfresponsavelemail = "";
         AV63Wprepresentantesds_10_tfresponsavelemail_sel = "";
         AV64Wprepresentantesds_11_tfresponsavelcargo_sels = new GxSimpleCollection<string>();
         AV65Wprepresentantesds_12_tfclientedocumento = "";
         AV66Wprepresentantesds_13_tfclientedocumento_sel = "";
         AV67Wprepresentantesds_14_tfclienterazaosocial = "";
         AV68Wprepresentantesds_15_tfclienterazaosocial_sel = "";
         AV69Wprepresentantesds_16_tfclientesituacao_sels = new GxSimpleCollection<string>();
         lV54Wprepresentantesds_1_filterfulltext = "";
         lV56Wprepresentantesds_3_tfresponsavelnome = "";
         lV58Wprepresentantesds_5_tfresponsavelcpf = "";
         lV62Wprepresentantesds_9_tfresponsavelemail = "";
         lV65Wprepresentantesds_12_tfclientedocumento = "";
         lV67Wprepresentantesds_14_tfclienterazaosocial = "";
         H00952_A192TipoClienteId = new short[1] ;
         H00952_n192TipoClienteId = new bool[] {false} ;
         H00952_A174ClienteStatus = new bool[] {false} ;
         H00952_n174ClienteStatus = new bool[] {false} ;
         H00952_A884ClienteSituacao = new string[] {""} ;
         H00952_n884ClienteSituacao = new bool[] {false} ;
         H00952_A193TipoClienteDescricao = new string[] {""} ;
         H00952_n193TipoClienteDescricao = new bool[] {false} ;
         H00952_A172ClienteTipoPessoa = new string[] {""} ;
         H00952_n172ClienteTipoPessoa = new bool[] {false} ;
         H00952_A171ClienteNomeFantasia = new string[] {""} ;
         H00952_n171ClienteNomeFantasia = new bool[] {false} ;
         H00952_A170ClienteRazaoSocial = new string[] {""} ;
         H00952_n170ClienteRazaoSocial = new bool[] {false} ;
         H00952_A169ClienteDocumento = new string[] {""} ;
         H00952_n169ClienteDocumento = new bool[] {false} ;
         H00952_A885ResponsavelCargo = new string[] {""} ;
         H00952_n885ResponsavelCargo = new bool[] {false} ;
         H00952_A456ResponsavelEmail = new string[] {""} ;
         H00952_n456ResponsavelEmail = new bool[] {false} ;
         H00952_A447ResponsavelCPF = new string[] {""} ;
         H00952_n447ResponsavelCPF = new bool[] {false} ;
         H00952_A436ResponsavelNome = new string[] {""} ;
         H00952_n436ResponsavelNome = new bool[] {false} ;
         H00952_A168ClienteId = new int[1] ;
         H00952_A455ResponsavelNumero = new int[1] ;
         H00952_n455ResponsavelNumero = new bool[] {false} ;
         H00952_A454ResponsavelDDD = new short[1] ;
         H00952_n454ResponsavelDDD = new bool[] {false} ;
         H00953_A192TipoClienteId = new short[1] ;
         H00953_n192TipoClienteId = new bool[] {false} ;
         H00953_A174ClienteStatus = new bool[] {false} ;
         H00953_n174ClienteStatus = new bool[] {false} ;
         H00953_A884ClienteSituacao = new string[] {""} ;
         H00953_n884ClienteSituacao = new bool[] {false} ;
         H00953_A193TipoClienteDescricao = new string[] {""} ;
         H00953_n193TipoClienteDescricao = new bool[] {false} ;
         H00953_A172ClienteTipoPessoa = new string[] {""} ;
         H00953_n172ClienteTipoPessoa = new bool[] {false} ;
         H00953_A171ClienteNomeFantasia = new string[] {""} ;
         H00953_n171ClienteNomeFantasia = new bool[] {false} ;
         H00953_A170ClienteRazaoSocial = new string[] {""} ;
         H00953_n170ClienteRazaoSocial = new bool[] {false} ;
         H00953_A169ClienteDocumento = new string[] {""} ;
         H00953_n169ClienteDocumento = new bool[] {false} ;
         H00953_A885ResponsavelCargo = new string[] {""} ;
         H00953_n885ResponsavelCargo = new bool[] {false} ;
         H00953_A456ResponsavelEmail = new string[] {""} ;
         H00953_n456ResponsavelEmail = new bool[] {false} ;
         H00953_A447ResponsavelCPF = new string[] {""} ;
         H00953_n447ResponsavelCPF = new bool[] {false} ;
         H00953_A436ResponsavelNome = new string[] {""} ;
         H00953_n436ResponsavelNome = new bool[] {false} ;
         H00953_A168ClienteId = new int[1] ;
         H00953_A455ResponsavelNumero = new int[1] ;
         H00953_n455ResponsavelNumero = new bool[] {false} ;
         H00953_A454ResponsavelDDD = new short[1] ;
         H00953_n454ResponsavelDDD = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51SdErro = new SdtSdErro(context);
         GXt_SdtSdErro4 = new SdtSdErro(context);
         AV17Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char1 = "";
         GXt_char5 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV46AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         ucDvelop_confirmpanel_exclude = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wprepresentantes__default(),
            new Object[][] {
                new Object[] {
               H00952_A192TipoClienteId, H00952_n192TipoClienteId, H00952_A174ClienteStatus, H00952_n174ClienteStatus, H00952_A884ClienteSituacao, H00952_n884ClienteSituacao, H00952_A193TipoClienteDescricao, H00952_n193TipoClienteDescricao, H00952_A172ClienteTipoPessoa, H00952_n172ClienteTipoPessoa,
               H00952_A171ClienteNomeFantasia, H00952_n171ClienteNomeFantasia, H00952_A170ClienteRazaoSocial, H00952_n170ClienteRazaoSocial, H00952_A169ClienteDocumento, H00952_n169ClienteDocumento, H00952_A885ResponsavelCargo, H00952_n885ResponsavelCargo, H00952_A456ResponsavelEmail, H00952_n456ResponsavelEmail,
               H00952_A447ResponsavelCPF, H00952_n447ResponsavelCPF, H00952_A436ResponsavelNome, H00952_n436ResponsavelNome, H00952_A168ClienteId, H00952_A455ResponsavelNumero, H00952_n455ResponsavelNumero, H00952_A454ResponsavelDDD, H00952_n454ResponsavelDDD
               }
               , new Object[] {
               H00953_A192TipoClienteId, H00953_n192TipoClienteId, H00953_A174ClienteStatus, H00953_n174ClienteStatus, H00953_A884ClienteSituacao, H00953_n884ClienteSituacao, H00953_A193TipoClienteDescricao, H00953_n193TipoClienteDescricao, H00953_A172ClienteTipoPessoa, H00953_n172ClienteTipoPessoa,
               H00953_A171ClienteNomeFantasia, H00953_n171ClienteNomeFantasia, H00953_A170ClienteRazaoSocial, H00953_n170ClienteRazaoSocial, H00953_A169ClienteDocumento, H00953_n169ClienteDocumento, H00953_A885ResponsavelCargo, H00953_n885ResponsavelCargo, H00953_A456ResponsavelEmail, H00953_n456ResponsavelEmail,
               H00953_A447ResponsavelCPF, H00953_n447ResponsavelCPF, H00953_A436ResponsavelNome, H00953_n436ResponsavelNome, H00953_A168ClienteId, H00953_A455ResponsavelNumero, H00953_n455ResponsavelNumero, H00953_A454ResponsavelDDD, H00953_n454ResponsavelDDD
               }
            }
         );
         AV53Pgmname = "WpRepresentantes";
         /* GeneXus formulas. */
         AV53Pgmname = "WpRepresentantes";
         edtavConsult_Enabled = 0;
         edtavPut_Enabled = 0;
         edtavExclude_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short AV52TipoClienteId ;
      private short AV37TFClienteStatus_Sel ;
      private short gxajaxcallmode ;
      private short A454ResponsavelDDD ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV55Wprepresentantesds_2_tipoclienteid ;
      private short AV70Wprepresentantesds_17_tfclientestatus_sel ;
      private short A192TipoClienteId ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_44 ;
      private int nGXsfl_44_idx=1 ;
      private int AV50ClienteId_Selected ;
      private int A455ResponsavelNumero ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int edtavTipoclienteid_Enabled ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int edtavConsult_Enabled ;
      private int edtavPut_Enabled ;
      private int edtavExclude_Enabled ;
      private int AV64Wprepresentantesds_11_tfresponsavelcargo_sels_Count ;
      private int AV69Wprepresentantesds_16_tfclientesituacao_sels_Count ;
      private int edtClienteId_Enabled ;
      private int edtResponsavelNome_Enabled ;
      private int edtResponsavelCPF_Enabled ;
      private int edtResponsavelCelular_F_Enabled ;
      private int edtResponsavelEmail_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int AV39PageToGo ;
      private int AV71GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV40GridCurrentPage ;
      private long AV41GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_exclude_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_44_idx="0001" ;
      private string AV53Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Dvelop_confirmpanel_exclude_Title ;
      private string Dvelop_confirmpanel_exclude_Confirmationtext ;
      private string Dvelop_confirmpanel_exclude_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_exclude_Nobuttoncaption ;
      private string Dvelop_confirmpanel_exclude_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_exclude_Yesbuttonposition ;
      private string Dvelop_confirmpanel_exclude_Confirmtype ;
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
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
      private string bttBtncreate_Internalname ;
      private string bttBtncreate_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divDefaultfilter_Internalname ;
      private string edtavTipoclienteid_Internalname ;
      private string edtavTipoclienteid_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV47Consult ;
      private string edtavConsult_Internalname ;
      private string AV48Put ;
      private string edtavPut_Internalname ;
      private string AV49Exclude ;
      private string edtavExclude_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtResponsavelNome_Internalname ;
      private string edtResponsavelCPF_Internalname ;
      private string edtResponsavelCelular_F_Internalname ;
      private string edtResponsavelEmail_Internalname ;
      private string cmbResponsavelCargo_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteNomeFantasia_Internalname ;
      private string cmbClienteTipoPessoa_Internalname ;
      private string edtTipoClienteDescricao_Internalname ;
      private string cmbClienteSituacao_Internalname ;
      private string A884ClienteSituacao ;
      private string cmbClienteStatus_Internalname ;
      private string cmbClienteSituacao_Columnheaderclass ;
      private string cmbClienteStatus_Columnheaderclass ;
      private string edtClienteDocumento_Link ;
      private string GXEncryptionTmp ;
      private string cmbClienteSituacao_Columnclass ;
      private string cmbClienteStatus_Columnclass ;
      private string GXt_char1 ;
      private string GXt_char5 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTabledvelop_confirmpanel_exclude_Internalname ;
      private string Dvelop_confirmpanel_exclude_Internalname ;
      private string sGXsfl_44_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavConsult_Jsonclick ;
      private string edtavPut_Jsonclick ;
      private string edtavExclude_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtResponsavelNome_Jsonclick ;
      private string edtResponsavelCPF_Jsonclick ;
      private string edtResponsavelCelular_F_Jsonclick ;
      private string edtResponsavelEmail_Jsonclick ;
      private string GXCCtl ;
      private string cmbResponsavelCargo_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string cmbClienteTipoPessoa_Jsonclick ;
      private string edtTipoClienteDescricao_Jsonclick ;
      private string cmbClienteSituacao_Jsonclick ;
      private string cmbClienteStatus_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
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
      private bool Grid_empowerer_Hascategories ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n436ResponsavelNome ;
      private bool n447ResponsavelCPF ;
      private bool n456ResponsavelEmail ;
      private bool n885ResponsavelCargo ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n172ClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private bool n884ClienteSituacao ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool n192TipoClienteId ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private bool bGXsfl_44_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV29TFResponsavelCargo_SelsJson ;
      private string AV35TFClienteSituacao_SelsJson ;
      private string AV19ManageFiltersXml ;
      private string AV14FilterFullText ;
      private string AV21TFResponsavelNome ;
      private string AV22TFResponsavelNome_Sel ;
      private string AV23TFResponsavelCPF ;
      private string AV24TFResponsavelCPF_Sel ;
      private string AV25TFResponsavelCelular_F ;
      private string AV26TFResponsavelCelular_F_Sel ;
      private string AV27TFResponsavelEmail ;
      private string AV28TFResponsavelEmail_Sel ;
      private string AV31TFClienteDocumento ;
      private string AV32TFClienteDocumento_Sel ;
      private string AV33TFClienteRazaoSocial ;
      private string AV34TFClienteRazaoSocial_Sel ;
      private string AV42GridAppliedFilters ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A577ResponsavelCelular_F ;
      private string A456ResponsavelEmail ;
      private string A885ResponsavelCargo ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A172ClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string AV54Wprepresentantesds_1_filterfulltext ;
      private string AV56Wprepresentantesds_3_tfresponsavelnome ;
      private string AV57Wprepresentantesds_4_tfresponsavelnome_sel ;
      private string AV58Wprepresentantesds_5_tfresponsavelcpf ;
      private string AV59Wprepresentantesds_6_tfresponsavelcpf_sel ;
      private string AV60Wprepresentantesds_7_tfresponsavelcelular_f ;
      private string AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel ;
      private string AV62Wprepresentantesds_9_tfresponsavelemail ;
      private string AV63Wprepresentantesds_10_tfresponsavelemail_sel ;
      private string AV65Wprepresentantesds_12_tfclientedocumento ;
      private string AV66Wprepresentantesds_13_tfclientedocumento_sel ;
      private string AV67Wprepresentantesds_14_tfclienterazaosocial ;
      private string AV68Wprepresentantesds_15_tfclienterazaosocial_sel ;
      private string lV54Wprepresentantesds_1_filterfulltext ;
      private string lV56Wprepresentantesds_3_tfresponsavelnome ;
      private string lV58Wprepresentantesds_5_tfresponsavelcpf ;
      private string lV62Wprepresentantesds_9_tfresponsavelemail ;
      private string lV65Wprepresentantesds_12_tfclientedocumento ;
      private string lV67Wprepresentantesds_14_tfclienterazaosocial ;
      private string AV46AuxText ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_exclude ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResponsavelCargo ;
      private GXCombobox cmbClienteTipoPessoa ;
      private GXCombobox cmbClienteSituacao ;
      private GXCombobox cmbClienteStatus ;
      private GxSimpleCollection<string> AV30TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV36TFClienteSituacao_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV38DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<string> AV64Wprepresentantesds_11_tfresponsavelcargo_sels ;
      private GxSimpleCollection<string> AV69Wprepresentantesds_16_tfclientesituacao_sels ;
      private IDataStoreProvider pr_default ;
      private short[] H00952_A192TipoClienteId ;
      private bool[] H00952_n192TipoClienteId ;
      private bool[] H00952_A174ClienteStatus ;
      private bool[] H00952_n174ClienteStatus ;
      private string[] H00952_A884ClienteSituacao ;
      private bool[] H00952_n884ClienteSituacao ;
      private string[] H00952_A193TipoClienteDescricao ;
      private bool[] H00952_n193TipoClienteDescricao ;
      private string[] H00952_A172ClienteTipoPessoa ;
      private bool[] H00952_n172ClienteTipoPessoa ;
      private string[] H00952_A171ClienteNomeFantasia ;
      private bool[] H00952_n171ClienteNomeFantasia ;
      private string[] H00952_A170ClienteRazaoSocial ;
      private bool[] H00952_n170ClienteRazaoSocial ;
      private string[] H00952_A169ClienteDocumento ;
      private bool[] H00952_n169ClienteDocumento ;
      private string[] H00952_A885ResponsavelCargo ;
      private bool[] H00952_n885ResponsavelCargo ;
      private string[] H00952_A456ResponsavelEmail ;
      private bool[] H00952_n456ResponsavelEmail ;
      private string[] H00952_A447ResponsavelCPF ;
      private bool[] H00952_n447ResponsavelCPF ;
      private string[] H00952_A436ResponsavelNome ;
      private bool[] H00952_n436ResponsavelNome ;
      private int[] H00952_A168ClienteId ;
      private int[] H00952_A455ResponsavelNumero ;
      private bool[] H00952_n455ResponsavelNumero ;
      private short[] H00952_A454ResponsavelDDD ;
      private bool[] H00952_n454ResponsavelDDD ;
      private short[] H00953_A192TipoClienteId ;
      private bool[] H00953_n192TipoClienteId ;
      private bool[] H00953_A174ClienteStatus ;
      private bool[] H00953_n174ClienteStatus ;
      private string[] H00953_A884ClienteSituacao ;
      private bool[] H00953_n884ClienteSituacao ;
      private string[] H00953_A193TipoClienteDescricao ;
      private bool[] H00953_n193TipoClienteDescricao ;
      private string[] H00953_A172ClienteTipoPessoa ;
      private bool[] H00953_n172ClienteTipoPessoa ;
      private string[] H00953_A171ClienteNomeFantasia ;
      private bool[] H00953_n171ClienteNomeFantasia ;
      private string[] H00953_A170ClienteRazaoSocial ;
      private bool[] H00953_n170ClienteRazaoSocial ;
      private string[] H00953_A169ClienteDocumento ;
      private bool[] H00953_n169ClienteDocumento ;
      private string[] H00953_A885ResponsavelCargo ;
      private bool[] H00953_n885ResponsavelCargo ;
      private string[] H00953_A456ResponsavelEmail ;
      private bool[] H00953_n456ResponsavelEmail ;
      private string[] H00953_A447ResponsavelCPF ;
      private bool[] H00953_n447ResponsavelCPF ;
      private string[] H00953_A436ResponsavelNome ;
      private bool[] H00953_n436ResponsavelNome ;
      private int[] H00953_A168ClienteId ;
      private int[] H00953_A455ResponsavelNumero ;
      private bool[] H00953_n455ResponsavelNumero ;
      private short[] H00953_A454ResponsavelDDD ;
      private bool[] H00953_n454ResponsavelDDD ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtSdErro AV51SdErro ;
      private SdtSdErro GXt_SdtSdErro4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wprepresentantes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00952( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV64Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV69Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV57Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV56Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV59Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV58Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV63Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV62Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV64Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV66Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV65Wprepresentantesds_12_tfclientedocumento ,
                                             string AV68Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV67Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV69Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV70Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV54Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV60Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[10];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T2.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ClienteId, T1.ResponsavelNumero, T1.ResponsavelDDD FROM (Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV56Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV57Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV57Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV58Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV59Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV59Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV62Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV63Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV63Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV64Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV64Wprepresentantesds_11_tfresponsavelcargo_sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV65Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV66Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV66Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV67Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV68Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV68Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV69Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Wprepresentantesds_16_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV70Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV70Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus DESC, T1.ClienteId";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H00953( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV64Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV69Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV57Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV56Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV59Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV58Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV63Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV62Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV64Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV66Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV65Wprepresentantesds_12_tfclientedocumento ,
                                             string AV68Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV67Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV69Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV70Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV54Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV61Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV60Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[10];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T2.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ClienteId, T1.ResponsavelNumero, T1.ResponsavelDDD FROM (Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV56Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV57Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV57Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV58Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV59Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV59Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV62Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV63Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV63Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV64Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV64Wprepresentantesds_11_tfresponsavelcargo_sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV65Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV66Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV66Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV67Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV68Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV68Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV69Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Wprepresentantesds_16_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV70Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV70Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus DESC, T1.ClienteId";
         }
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00952(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] );
               case 1 :
                     return conditional_H00953(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] );
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
          Object[] prmH00952;
          prmH00952 = new Object[] {
          new ParDef("lV56Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV57Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV58Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV59Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV62Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV66Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV67Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV68Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmH00953;
          prmH00953 = new Object[] {
          new ParDef("lV56Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV57Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV58Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV59Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV62Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV66Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV67Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV68Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00952", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00952,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00953", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00953,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
