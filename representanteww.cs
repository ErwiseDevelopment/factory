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
   public class representanteww : GXDataArea
   {
      public representanteww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representanteww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId )
      {
         this.AV66ClienteId = aP0_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbRepresentanteEstadoCivil = new GXCombobox();
         cmbRepresentanteTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ClienteId");
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
               gxfirstwebparm = GetFirstPar( "ClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ClienteId");
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
         nRC_GXsfl_119 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_119"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_119_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_119_idx = GetPar( "sGXsfl_119_idx");
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
         AV18RepresentanteNome1 = GetPar( "RepresentanteNome1");
         AV19RepresentanteMunicipioNome1 = GetPar( "RepresentanteMunicipioNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23RepresentanteNome2 = GetPar( "RepresentanteNome2");
         AV24RepresentanteMunicipioNome2 = GetPar( "RepresentanteMunicipioNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28RepresentanteNome3 = GetPar( "RepresentanteNome3");
         AV29RepresentanteMunicipioNome3 = GetPar( "RepresentanteMunicipioNome3");
         AV66ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV69Pgmname = GetPar( "Pgmname");
         AV38TFRepresentanteNome = GetPar( "TFRepresentanteNome");
         AV39TFRepresentanteNome_Sel = GetPar( "TFRepresentanteNome_Sel");
         AV40TFRepresentanteRG = GetPar( "TFRepresentanteRG");
         AV41TFRepresentanteRG_Sel = GetPar( "TFRepresentanteRG_Sel");
         AV42TFRepresentanteOrgaoExpedidor = GetPar( "TFRepresentanteOrgaoExpedidor");
         AV43TFRepresentanteOrgaoExpedidor_Sel = GetPar( "TFRepresentanteOrgaoExpedidor_Sel");
         AV44TFRepresentanteRGUF = GetPar( "TFRepresentanteRGUF");
         AV45TFRepresentanteRGUF_Sel = GetPar( "TFRepresentanteRGUF_Sel");
         AV46TFRepresentanteCPF = GetPar( "TFRepresentanteCPF");
         AV47TFRepresentanteCPF_Sel = GetPar( "TFRepresentanteCPF_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49TFRepresentanteEstadoCivil_Sels);
         AV50TFRepresentanteNacionalidade = GetPar( "TFRepresentanteNacionalidade");
         AV51TFRepresentanteNacionalidade_Sel = GetPar( "TFRepresentanteNacionalidade_Sel");
         AV67TFRepresentanteProfissaoDescricao = GetPar( "TFRepresentanteProfissaoDescricao");
         AV68TFRepresentanteProfissaoDescricao_Sel = GetPar( "TFRepresentanteProfissaoDescricao_Sel");
         AV54TFRepresentanteEmail = GetPar( "TFRepresentanteEmail");
         AV55TFRepresentanteEmail_Sel = GetPar( "TFRepresentanteEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV57TFRepresentanteTipo_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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
         PA9P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9P2( ) ;
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
         GXEncryptionTmp = "representanteww"+UrlEncode(StringUtil.LTrimStr(AV66ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("representanteww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTENOME1", AV18RepresentanteNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTEMUNICIPIONOME1", AV19RepresentanteMunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTENOME2", AV23RepresentanteNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTEMUNICIPIONOME2", AV24RepresentanteMunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTENOME3", AV28RepresentanteNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vREPRESENTANTEMUNICIPIONOME3", AV29RepresentanteMunicipioNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV62GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTENOME", AV38TFRepresentanteNome);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTENOME_SEL", AV39TFRepresentanteNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTERG", AV40TFRepresentanteRG);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTERG_SEL", AV41TFRepresentanteRG_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEORGAOEXPEDIDOR", AV42TFRepresentanteOrgaoExpedidor);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEORGAOEXPEDIDOR_SEL", AV43TFRepresentanteOrgaoExpedidor_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTERGUF", AV44TFRepresentanteRGUF);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTERGUF_SEL", AV45TFRepresentanteRGUF_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTECPF", AV46TFRepresentanteCPF);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTECPF_SEL", AV47TFRepresentanteCPF_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFREPRESENTANTEESTADOCIVIL_SELS", AV49TFRepresentanteEstadoCivil_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFREPRESENTANTEESTADOCIVIL_SELS", AV49TFRepresentanteEstadoCivil_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTENACIONALIDADE", AV50TFRepresentanteNacionalidade);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTENACIONALIDADE_SEL", AV51TFRepresentanteNacionalidade_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEPROFISSAODESCRICAO", AV67TFRepresentanteProfissaoDescricao);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEPROFISSAODESCRICAO_SEL", AV68TFRepresentanteProfissaoDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEEMAIL", AV54TFRepresentanteEmail);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEEMAIL_SEL", AV55TFRepresentanteEmail_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFREPRESENTANTETIPO_SELS", AV57TFRepresentanteTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFREPRESENTANTETIPO_SELS", AV57TFRepresentanteTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66ClienteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTEESTADOCIVIL_SELSJSON", AV48TFRepresentanteEstadoCivil_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFREPRESENTANTETIPO_SELSJSON", AV56TFRepresentanteTipo_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE9P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9P2( ) ;
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
         GXEncryptionTmp = "representanteww"+UrlEncode(StringUtil.LTrimStr(AV66ClienteId,9,0));
         return formatLink("representanteww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "RepresentanteWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Representante" ;
      }

      protected void WB9P0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_RepresentanteWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RepresentanteWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_RepresentanteWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_48_9P2( true) ;
         }
         else
         {
            wb_table1_48_9P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_9P2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_73_9P2( true) ;
         }
         else
         {
            wb_table2_73_9P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_73_9P2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_98_9P2( true) ;
         }
         else
         {
            wb_table3_98_9P2( false) ;
         }
         return  ;
      }

      protected void wb_table3_98_9P2e( bool wbgen )
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
            StartGridControl119( ) ;
         }
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            nRC_GXsfl_119 = (int)(nGXsfl_119_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV60GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV61GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV62GridAppliedFilters);
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_RepresentanteWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
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
         if ( wbEnd == 119 )
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

      protected void START9P2( )
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
         Form.Meta.addItem("description", " Representante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9P0( ) ;
      }

      protected void WS9P2( )
      {
         START9P2( ) ;
         EVT9P2( ) ;
      }

      protected void EVT9P2( )
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
                              E119P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E209P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E229P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249P2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
                              SubsflControlProps_1192( ) ;
                              AV63Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV63Display);
                              AV64Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV64Update);
                              A978RepresentanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A979RepresentanteNome = cgiGet( edtRepresentanteNome_Internalname);
                              n979RepresentanteNome = false;
                              A980RepresentanteRG = cgiGet( edtRepresentanteRG_Internalname);
                              n980RepresentanteRG = false;
                              A981RepresentanteOrgaoExpedidor = cgiGet( edtRepresentanteOrgaoExpedidor_Internalname);
                              n981RepresentanteOrgaoExpedidor = false;
                              A982RepresentanteRGUF = cgiGet( edtRepresentanteRGUF_Internalname);
                              n982RepresentanteRGUF = false;
                              A983RepresentanteCPF = cgiGet( edtRepresentanteCPF_Internalname);
                              n983RepresentanteCPF = false;
                              cmbRepresentanteEstadoCivil.Name = cmbRepresentanteEstadoCivil_Internalname;
                              cmbRepresentanteEstadoCivil.CurrentValue = cgiGet( cmbRepresentanteEstadoCivil_Internalname);
                              A984RepresentanteEstadoCivil = cgiGet( cmbRepresentanteEstadoCivil_Internalname);
                              n984RepresentanteEstadoCivil = false;
                              A985RepresentanteNacionalidade = cgiGet( edtRepresentanteNacionalidade_Internalname);
                              n985RepresentanteNacionalidade = false;
                              A999RepresentanteProfissaoDescricao = StringUtil.Upper( cgiGet( edtRepresentanteProfissaoDescricao_Internalname));
                              n999RepresentanteProfissaoDescricao = false;
                              A977RepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteProfissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n977RepresentanteProfissao = false;
                              A986RepresentanteEmail = cgiGet( edtRepresentanteEmail_Internalname);
                              n986RepresentanteEmail = false;
                              cmbRepresentanteTipo.Name = cmbRepresentanteTipo_Internalname;
                              cmbRepresentanteTipo.CurrentValue = cgiGet( cmbRepresentanteTipo_Internalname);
                              A998RepresentanteTipo = cgiGet( cmbRepresentanteTipo_Internalname);
                              n998RepresentanteTipo = false;
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E259P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E269P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E279P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME1"), AV18RepresentanteNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantemunicipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME1"), AV19RepresentanteMunicipioNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME2"), AV23RepresentanteNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantemunicipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME2"), AV24RepresentanteMunicipioNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME3"), AV28RepresentanteNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Representantemunicipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME3"), AV29RepresentanteMunicipioNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE9P2( )
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

      protected void PA9P2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "representanteww")), "representanteww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "representanteww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ClienteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV66ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV66ClienteId", StringUtil.LTrimStr( (decimal)(AV66ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66ClienteId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_1192( ) ;
         while ( nGXsfl_119_idx <= nRC_GXsfl_119 )
         {
            sendrow_1192( ) ;
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
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
                                       string AV18RepresentanteNome1 ,
                                       string AV19RepresentanteMunicipioNome1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23RepresentanteNome2 ,
                                       string AV24RepresentanteMunicipioNome2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28RepresentanteNome3 ,
                                       string AV29RepresentanteMunicipioNome3 ,
                                       int AV66ClienteId ,
                                       short AV37ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV69Pgmname ,
                                       string AV38TFRepresentanteNome ,
                                       string AV39TFRepresentanteNome_Sel ,
                                       string AV40TFRepresentanteRG ,
                                       string AV41TFRepresentanteRG_Sel ,
                                       string AV42TFRepresentanteOrgaoExpedidor ,
                                       string AV43TFRepresentanteOrgaoExpedidor_Sel ,
                                       string AV44TFRepresentanteRGUF ,
                                       string AV45TFRepresentanteRGUF_Sel ,
                                       string AV46TFRepresentanteCPF ,
                                       string AV47TFRepresentanteCPF_Sel ,
                                       GxSimpleCollection<string> AV49TFRepresentanteEstadoCivil_Sels ,
                                       string AV50TFRepresentanteNacionalidade ,
                                       string AV51TFRepresentanteNacionalidade_Sel ,
                                       string AV67TFRepresentanteProfissaoDescricao ,
                                       string AV68TFRepresentanteProfissaoDescricao_Sel ,
                                       string AV54TFRepresentanteEmail ,
                                       string AV55TFRepresentanteEmail_Sel ,
                                       GxSimpleCollection<string> AV57TFRepresentanteTipo_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "REPRESENTANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A978RepresentanteId), 9, 0, ".", "")));
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
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "RepresentanteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RF9P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E269P2 ();
         nGXsfl_119_idx = 1;
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         bGXsfl_119_Refreshing = true;
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
            SubsflControlProps_1192( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A984RepresentanteEstadoCivil ,
                                                 AV95Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                                 A998RepresentanteTipo ,
                                                 AV102Representantewwds_33_tfrepresentantetipo_sels ,
                                                 AV70Representantewwds_1_filterfulltext ,
                                                 AV71Representantewwds_2_dynamicfiltersselector1 ,
                                                 AV72Representantewwds_3_dynamicfiltersoperator1 ,
                                                 AV73Representantewwds_4_representantenome1 ,
                                                 AV74Representantewwds_5_representantemunicipionome1 ,
                                                 AV75Representantewwds_6_dynamicfiltersenabled2 ,
                                                 AV76Representantewwds_7_dynamicfiltersselector2 ,
                                                 AV77Representantewwds_8_dynamicfiltersoperator2 ,
                                                 AV78Representantewwds_9_representantenome2 ,
                                                 AV79Representantewwds_10_representantemunicipionome2 ,
                                                 AV80Representantewwds_11_dynamicfiltersenabled3 ,
                                                 AV81Representantewwds_12_dynamicfiltersselector3 ,
                                                 AV82Representantewwds_13_dynamicfiltersoperator3 ,
                                                 AV83Representantewwds_14_representantenome3 ,
                                                 AV84Representantewwds_15_representantemunicipionome3 ,
                                                 AV86Representantewwds_17_tfrepresentantenome_sel ,
                                                 AV85Representantewwds_16_tfrepresentantenome ,
                                                 AV88Representantewwds_19_tfrepresentanterg_sel ,
                                                 AV87Representantewwds_18_tfrepresentanterg ,
                                                 AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                                 AV89Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                                 AV92Representantewwds_23_tfrepresentanterguf_sel ,
                                                 AV91Representantewwds_22_tfrepresentanterguf ,
                                                 AV94Representantewwds_25_tfrepresentantecpf_sel ,
                                                 AV93Representantewwds_24_tfrepresentantecpf ,
                                                 AV95Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                                 AV97Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                                 AV96Representantewwds_27_tfrepresentantenacionalidade ,
                                                 AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                                 AV98Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                                 AV101Representantewwds_32_tfrepresentanteemail_sel ,
                                                 AV100Representantewwds_31_tfrepresentanteemail ,
                                                 AV102Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                                 A979RepresentanteNome ,
                                                 A980RepresentanteRG ,
                                                 A981RepresentanteOrgaoExpedidor ,
                                                 A982RepresentanteRGUF ,
                                                 A983RepresentanteCPF ,
                                                 A985RepresentanteNacionalidade ,
                                                 A999RepresentanteProfissaoDescricao ,
                                                 A986RepresentanteEmail ,
                                                 A997RepresentanteMunicipioNome ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A168ClienteId ,
                                                 AV66ClienteId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
            lV73Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV73Representantewwds_4_representantenome1), "%", "");
            lV73Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV73Representantewwds_4_representantenome1), "%", "");
            lV74Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1), "%", "");
            lV74Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1), "%", "");
            lV78Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV78Representantewwds_9_representantenome2), "%", "");
            lV78Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV78Representantewwds_9_representantenome2), "%", "");
            lV79Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2), "%", "");
            lV79Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2), "%", "");
            lV83Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV83Representantewwds_14_representantenome3), "%", "");
            lV83Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV83Representantewwds_14_representantenome3), "%", "");
            lV84Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3), "%", "");
            lV84Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3), "%", "");
            lV85Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_16_tfrepresentantenome), "%", "");
            lV87Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_18_tfrepresentanterg), "%", "");
            lV89Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
            lV91Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_22_tfrepresentanterguf), "%", "");
            lV93Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_24_tfrepresentantecpf), "%", "");
            lV96Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV96Representantewwds_27_tfrepresentantenacionalidade), "%", "");
            lV98Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
            lV100Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_31_tfrepresentanteemail), "%", "");
            /* Using cursor H009P2 */
            pr_default.execute(0, new Object[] {AV66ClienteId, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV73Representantewwds_4_representantenome1, lV73Representantewwds_4_representantenome1, lV74Representantewwds_5_representantemunicipionome1, lV74Representantewwds_5_representantemunicipionome1, lV78Representantewwds_9_representantenome2, lV78Representantewwds_9_representantenome2, lV79Representantewwds_10_representantemunicipionome2, lV79Representantewwds_10_representantemunicipionome2, lV83Representantewwds_14_representantenome3, lV83Representantewwds_14_representantenome3, lV84Representantewwds_15_representantemunicipionome3, lV84Representantewwds_15_representantemunicipionome3, lV85Representantewwds_16_tfrepresentantenome, AV86Representantewwds_17_tfrepresentantenome_sel, lV87Representantewwds_18_tfrepresentanterg, AV88Representantewwds_19_tfrepresentanterg_sel, lV89Representantewwds_20_tfrepresentanteorgaoexpedidor, AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV91Representantewwds_22_tfrepresentanterguf, AV92Representantewwds_23_tfrepresentanterguf_sel, lV93Representantewwds_24_tfrepresentantecpf, AV94Representantewwds_25_tfrepresentantecpf_sel, lV96Representantewwds_27_tfrepresentantenacionalidade, AV97Representantewwds_28_tfrepresentantenacionalidade_sel, lV98Representantewwds_29_tfrepresentanteprofissaodescricao, AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV100Representantewwds_31_tfrepresentanteemail, AV101Representantewwds_32_tfrepresentanteemail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A991RepresentanteMunicipio = H009P2_A991RepresentanteMunicipio[0];
               n991RepresentanteMunicipio = H009P2_n991RepresentanteMunicipio[0];
               A997RepresentanteMunicipioNome = H009P2_A997RepresentanteMunicipioNome[0];
               n997RepresentanteMunicipioNome = H009P2_n997RepresentanteMunicipioNome[0];
               A168ClienteId = H009P2_A168ClienteId[0];
               n168ClienteId = H009P2_n168ClienteId[0];
               A998RepresentanteTipo = H009P2_A998RepresentanteTipo[0];
               n998RepresentanteTipo = H009P2_n998RepresentanteTipo[0];
               A986RepresentanteEmail = H009P2_A986RepresentanteEmail[0];
               n986RepresentanteEmail = H009P2_n986RepresentanteEmail[0];
               A977RepresentanteProfissao = H009P2_A977RepresentanteProfissao[0];
               n977RepresentanteProfissao = H009P2_n977RepresentanteProfissao[0];
               A999RepresentanteProfissaoDescricao = H009P2_A999RepresentanteProfissaoDescricao[0];
               n999RepresentanteProfissaoDescricao = H009P2_n999RepresentanteProfissaoDescricao[0];
               A985RepresentanteNacionalidade = H009P2_A985RepresentanteNacionalidade[0];
               n985RepresentanteNacionalidade = H009P2_n985RepresentanteNacionalidade[0];
               A984RepresentanteEstadoCivil = H009P2_A984RepresentanteEstadoCivil[0];
               n984RepresentanteEstadoCivil = H009P2_n984RepresentanteEstadoCivil[0];
               A983RepresentanteCPF = H009P2_A983RepresentanteCPF[0];
               n983RepresentanteCPF = H009P2_n983RepresentanteCPF[0];
               A982RepresentanteRGUF = H009P2_A982RepresentanteRGUF[0];
               n982RepresentanteRGUF = H009P2_n982RepresentanteRGUF[0];
               A981RepresentanteOrgaoExpedidor = H009P2_A981RepresentanteOrgaoExpedidor[0];
               n981RepresentanteOrgaoExpedidor = H009P2_n981RepresentanteOrgaoExpedidor[0];
               A980RepresentanteRG = H009P2_A980RepresentanteRG[0];
               n980RepresentanteRG = H009P2_n980RepresentanteRG[0];
               A979RepresentanteNome = H009P2_A979RepresentanteNome[0];
               n979RepresentanteNome = H009P2_n979RepresentanteNome[0];
               A978RepresentanteId = H009P2_A978RepresentanteId[0];
               A997RepresentanteMunicipioNome = H009P2_A997RepresentanteMunicipioNome[0];
               n997RepresentanteMunicipioNome = H009P2_n997RepresentanteMunicipioNome[0];
               A999RepresentanteProfissaoDescricao = H009P2_A999RepresentanteProfissaoDescricao[0];
               n999RepresentanteProfissaoDescricao = H009P2_n999RepresentanteProfissaoDescricao[0];
               /* Execute user event: Grid.Load */
               E279P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB9P0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9P2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_REPRESENTANTEID"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9"), context));
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
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV95Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV102Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV70Representantewwds_1_filterfulltext ,
                                              AV71Representantewwds_2_dynamicfiltersselector1 ,
                                              AV72Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV73Representantewwds_4_representantenome1 ,
                                              AV74Representantewwds_5_representantemunicipionome1 ,
                                              AV75Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV76Representantewwds_7_dynamicfiltersselector2 ,
                                              AV77Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV78Representantewwds_9_representantenome2 ,
                                              AV79Representantewwds_10_representantemunicipionome2 ,
                                              AV80Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV81Representantewwds_12_dynamicfiltersselector3 ,
                                              AV82Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV83Representantewwds_14_representantenome3 ,
                                              AV84Representantewwds_15_representantemunicipionome3 ,
                                              AV86Representantewwds_17_tfrepresentantenome_sel ,
                                              AV85Representantewwds_16_tfrepresentantenome ,
                                              AV88Representantewwds_19_tfrepresentanterg_sel ,
                                              AV87Representantewwds_18_tfrepresentanterg ,
                                              AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV89Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV92Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV91Representantewwds_22_tfrepresentanterguf ,
                                              AV94Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV93Representantewwds_24_tfrepresentantecpf ,
                                              AV95Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV97Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV96Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV98Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV101Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV100Representantewwds_31_tfrepresentanteemail ,
                                              AV102Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A168ClienteId ,
                                              AV66ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_1_filterfulltext), "%", "");
         lV73Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV73Representantewwds_4_representantenome1), "%", "");
         lV73Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV73Representantewwds_4_representantenome1), "%", "");
         lV74Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1), "%", "");
         lV74Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1), "%", "");
         lV78Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV78Representantewwds_9_representantenome2), "%", "");
         lV78Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV78Representantewwds_9_representantenome2), "%", "");
         lV79Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2), "%", "");
         lV79Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2), "%", "");
         lV83Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV83Representantewwds_14_representantenome3), "%", "");
         lV83Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV83Representantewwds_14_representantenome3), "%", "");
         lV84Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3), "%", "");
         lV84Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3), "%", "");
         lV85Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_16_tfrepresentantenome), "%", "");
         lV87Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_18_tfrepresentanterg), "%", "");
         lV89Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV91Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_22_tfrepresentanterguf), "%", "");
         lV93Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_24_tfrepresentantecpf), "%", "");
         lV96Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV96Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV98Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV100Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor H009P3 */
         pr_default.execute(1, new Object[] {AV66ClienteId, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV70Representantewwds_1_filterfulltext, lV73Representantewwds_4_representantenome1, lV73Representantewwds_4_representantenome1, lV74Representantewwds_5_representantemunicipionome1, lV74Representantewwds_5_representantemunicipionome1, lV78Representantewwds_9_representantenome2, lV78Representantewwds_9_representantenome2, lV79Representantewwds_10_representantemunicipionome2, lV79Representantewwds_10_representantemunicipionome2, lV83Representantewwds_14_representantenome3, lV83Representantewwds_14_representantenome3, lV84Representantewwds_15_representantemunicipionome3, lV84Representantewwds_15_representantemunicipionome3, lV85Representantewwds_16_tfrepresentantenome, AV86Representantewwds_17_tfrepresentantenome_sel, lV87Representantewwds_18_tfrepresentanterg, AV88Representantewwds_19_tfrepresentanterg_sel, lV89Representantewwds_20_tfrepresentanteorgaoexpedidor, AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV91Representantewwds_22_tfrepresentanterguf, AV92Representantewwds_23_tfrepresentanterguf_sel, lV93Representantewwds_24_tfrepresentantecpf, AV94Representantewwds_25_tfrepresentantecpf_sel, lV96Representantewwds_27_tfrepresentantenacionalidade, AV97Representantewwds_28_tfrepresentantenacionalidade_sel, lV98Representantewwds_29_tfrepresentanteprofissaodescricao, AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV100Representantewwds_31_tfrepresentanteemail, AV101Representantewwds_32_tfrepresentanteemail_sel});
         GRID_nRecordCount = H009P3_AGRID_nRecordCount[0];
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
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "RepresentanteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtRepresentanteId_Enabled = 0;
         edtRepresentanteNome_Enabled = 0;
         edtRepresentanteRG_Enabled = 0;
         edtRepresentanteOrgaoExpedidor_Enabled = 0;
         edtRepresentanteRGUF_Enabled = 0;
         edtRepresentanteCPF_Enabled = 0;
         cmbRepresentanteEstadoCivil.Enabled = 0;
         edtRepresentanteNacionalidade_Enabled = 0;
         edtRepresentanteProfissaoDescricao_Enabled = 0;
         edtRepresentanteProfissao_Enabled = 0;
         edtRepresentanteEmail_Enabled = 0;
         cmbRepresentanteTipo.Enabled = 0;
         edtClienteId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E259P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV58DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ",", "."), 18, MidpointRounding.ToEven));
            AV60GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV61GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV62GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
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
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18RepresentanteNome1 = cgiGet( edtavRepresentantenome1_Internalname);
            AssignAttri("", false, "AV18RepresentanteNome1", AV18RepresentanteNome1);
            AV19RepresentanteMunicipioNome1 = StringUtil.Upper( cgiGet( edtavRepresentantemunicipionome1_Internalname));
            AssignAttri("", false, "AV19RepresentanteMunicipioNome1", AV19RepresentanteMunicipioNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV23RepresentanteNome2 = cgiGet( edtavRepresentantenome2_Internalname);
            AssignAttri("", false, "AV23RepresentanteNome2", AV23RepresentanteNome2);
            AV24RepresentanteMunicipioNome2 = StringUtil.Upper( cgiGet( edtavRepresentantemunicipionome2_Internalname));
            AssignAttri("", false, "AV24RepresentanteMunicipioNome2", AV24RepresentanteMunicipioNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28RepresentanteNome3 = cgiGet( edtavRepresentantenome3_Internalname);
            AssignAttri("", false, "AV28RepresentanteNome3", AV28RepresentanteNome3);
            AV29RepresentanteMunicipioNome3 = StringUtil.Upper( cgiGet( edtavRepresentantemunicipionome3_Internalname));
            AssignAttri("", false, "AV29RepresentanteMunicipioNome3", AV29RepresentanteMunicipioNome3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME1"), AV18RepresentanteNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME1"), AV19RepresentanteMunicipioNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME2"), AV23RepresentanteNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME2"), AV24RepresentanteMunicipioNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTENOME3"), AV28RepresentanteNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREPRESENTANTEMUNICIPIONOME3"), AV29RepresentanteMunicipioNome3) != 0 )
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
         E259P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E259P2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Representante";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV58DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV58DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E269P2( )
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
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV60GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV60GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV60GridCurrentPage), 10, 0));
         AV61GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV61GridPageCount", StringUtil.LTrimStr( (decimal)(AV61GridPageCount), 10, 0));
         GXt_char2 = AV62GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char2) ;
         AV62GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV62GridAppliedFilters", AV62GridAppliedFilters);
         AV70Representantewwds_1_filterfulltext = AV15FilterFullText;
         AV71Representantewwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Representantewwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Representantewwds_4_representantenome1 = AV18RepresentanteNome1;
         AV74Representantewwds_5_representantemunicipionome1 = AV19RepresentanteMunicipioNome1;
         AV75Representantewwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Representantewwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Representantewwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Representantewwds_9_representantenome2 = AV23RepresentanteNome2;
         AV79Representantewwds_10_representantemunicipionome2 = AV24RepresentanteMunicipioNome2;
         AV80Representantewwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Representantewwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Representantewwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Representantewwds_14_representantenome3 = AV28RepresentanteNome3;
         AV84Representantewwds_15_representantemunicipionome3 = AV29RepresentanteMunicipioNome3;
         AV85Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV86Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV87Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV88Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV91Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV92Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV93Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV94Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = AV49TFRepresentanteEstadoCivil_Sels;
         AV96Representantewwds_27_tfrepresentantenacionalidade = AV50TFRepresentanteNacionalidade;
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = AV51TFRepresentanteNacionalidade_Sel;
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = AV67TFRepresentanteProfissaoDescricao;
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV68TFRepresentanteProfissaoDescricao_Sel;
         AV100Representantewwds_31_tfrepresentanteemail = AV54TFRepresentanteEmail;
         AV101Representantewwds_32_tfrepresentanteemail_sel = AV55TFRepresentanteEmail_Sel;
         AV102Representantewwds_33_tfrepresentantetipo_sels = AV57TFRepresentanteTipo_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129P2( )
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
            AV59PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV59PageToGo) ;
         }
      }

      protected void E139P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149P2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteNome") == 0 )
            {
               AV38TFRepresentanteNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFRepresentanteNome", AV38TFRepresentanteNome);
               AV39TFRepresentanteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFRepresentanteNome_Sel", AV39TFRepresentanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteRG") == 0 )
            {
               AV40TFRepresentanteRG = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFRepresentanteRG", AV40TFRepresentanteRG);
               AV41TFRepresentanteRG_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFRepresentanteRG_Sel", AV41TFRepresentanteRG_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteOrgaoExpedidor") == 0 )
            {
               AV42TFRepresentanteOrgaoExpedidor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFRepresentanteOrgaoExpedidor", AV42TFRepresentanteOrgaoExpedidor);
               AV43TFRepresentanteOrgaoExpedidor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFRepresentanteOrgaoExpedidor_Sel", AV43TFRepresentanteOrgaoExpedidor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteRGUF") == 0 )
            {
               AV44TFRepresentanteRGUF = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFRepresentanteRGUF", AV44TFRepresentanteRGUF);
               AV45TFRepresentanteRGUF_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFRepresentanteRGUF_Sel", AV45TFRepresentanteRGUF_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteCPF") == 0 )
            {
               AV46TFRepresentanteCPF = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFRepresentanteCPF", AV46TFRepresentanteCPF);
               AV47TFRepresentanteCPF_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFRepresentanteCPF_Sel", AV47TFRepresentanteCPF_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteEstadoCivil") == 0 )
            {
               AV48TFRepresentanteEstadoCivil_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFRepresentanteEstadoCivil_SelsJson", AV48TFRepresentanteEstadoCivil_SelsJson);
               AV49TFRepresentanteEstadoCivil_Sels.FromJSonString(AV48TFRepresentanteEstadoCivil_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteNacionalidade") == 0 )
            {
               AV50TFRepresentanteNacionalidade = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFRepresentanteNacionalidade", AV50TFRepresentanteNacionalidade);
               AV51TFRepresentanteNacionalidade_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFRepresentanteNacionalidade_Sel", AV51TFRepresentanteNacionalidade_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteProfissaoDescricao") == 0 )
            {
               AV67TFRepresentanteProfissaoDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFRepresentanteProfissaoDescricao", AV67TFRepresentanteProfissaoDescricao);
               AV68TFRepresentanteProfissaoDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFRepresentanteProfissaoDescricao_Sel", AV68TFRepresentanteProfissaoDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteEmail") == 0 )
            {
               AV54TFRepresentanteEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFRepresentanteEmail", AV54TFRepresentanteEmail);
               AV55TFRepresentanteEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFRepresentanteEmail_Sel", AV55TFRepresentanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RepresentanteTipo") == 0 )
            {
               AV56TFRepresentanteTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFRepresentanteTipo_SelsJson", AV56TFRepresentanteTipo_SelsJson);
               AV57TFRepresentanteTipo_Sels.FromJSonString(AV56TFRepresentanteTipo_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57TFRepresentanteTipo_Sels", AV57TFRepresentanteTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFRepresentanteEstadoCivil_Sels", AV49TFRepresentanteEstadoCivil_Sels);
      }

      private void E279P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV63Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV63Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wprepresentante"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A978RepresentanteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV66ClienteId,9,0));
         edtavDisplay_Link = formatLink("wprepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV64Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV64Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wprepresentante"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A978RepresentanteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV66ClienteId,9,0));
         edtavUpdate_Link = formatLink("wprepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 119;
         }
         sendrow_1192( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_119_Refreshing )
         {
            DoAjaxLoad(119, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E209P2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E159P2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E219P2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E229P2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E169P2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E239P2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179P2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18RepresentanteNome1, AV19RepresentanteMunicipioNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RepresentanteNome2, AV24RepresentanteMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28RepresentanteNome3, AV29RepresentanteMunicipioNome3, AV66ClienteId, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV38TFRepresentanteNome, AV39TFRepresentanteNome_Sel, AV40TFRepresentanteRG, AV41TFRepresentanteRG_Sel, AV42TFRepresentanteOrgaoExpedidor, AV43TFRepresentanteOrgaoExpedidor_Sel, AV44TFRepresentanteRGUF, AV45TFRepresentanteRGUF_Sel, AV46TFRepresentanteCPF, AV47TFRepresentanteCPF_Sel, AV49TFRepresentanteEstadoCivil_Sels, AV50TFRepresentanteNacionalidade, AV51TFRepresentanteNacionalidade_Sel, AV67TFRepresentanteProfissaoDescricao, AV68TFRepresentanteProfissaoDescricao_Sel, AV54TFRepresentanteEmail, AV55TFRepresentanteEmail_Sel, AV57TFRepresentanteTipo_Sels, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E249P2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119P2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("RepresentanteWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("RepresentanteWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "RepresentanteWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFRepresentanteEstadoCivil_Sels", AV49TFRepresentanteEstadoCivil_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57TFRepresentanteTipo_Sels", AV57TFRepresentanteTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E189P2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wprepresentante"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV66ClienteId,9,0));
         CallWebObject(formatLink("wprepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E199P2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new representantewwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavRepresentantenome1_Visible = 0;
         AssignProp("", false, edtavRepresentantenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome1_Visible), 5, 0), true);
         edtavRepresentantemunicipionome1_Visible = 0;
         AssignProp("", false, edtavRepresentantemunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 )
         {
            edtavRepresentantenome1_Visible = 1;
            AssignProp("", false, edtavRepresentantenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 )
         {
            edtavRepresentantemunicipionome1_Visible = 1;
            AssignProp("", false, edtavRepresentantemunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavRepresentantenome2_Visible = 0;
         AssignProp("", false, edtavRepresentantenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome2_Visible), 5, 0), true);
         edtavRepresentantemunicipionome2_Visible = 0;
         AssignProp("", false, edtavRepresentantemunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 )
         {
            edtavRepresentantenome2_Visible = 1;
            AssignProp("", false, edtavRepresentantenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 )
         {
            edtavRepresentantemunicipionome2_Visible = 1;
            AssignProp("", false, edtavRepresentantemunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavRepresentantenome3_Visible = 0;
         AssignProp("", false, edtavRepresentantenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome3_Visible), 5, 0), true);
         edtavRepresentantemunicipionome3_Visible = 0;
         AssignProp("", false, edtavRepresentantemunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 )
         {
            edtavRepresentantenome3_Visible = 1;
            AssignProp("", false, edtavRepresentantenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 )
         {
            edtavRepresentantemunicipionome3_Visible = 1;
            AssignProp("", false, edtavRepresentantemunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23RepresentanteNome2 = "";
         AssignAttri("", false, "AV23RepresentanteNome2", AV23RepresentanteNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28RepresentanteNome3 = "";
         AssignAttri("", false, "AV28RepresentanteNome3", AV28RepresentanteNome3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "RepresentanteWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFRepresentanteNome = "";
         AssignAttri("", false, "AV38TFRepresentanteNome", AV38TFRepresentanteNome);
         AV39TFRepresentanteNome_Sel = "";
         AssignAttri("", false, "AV39TFRepresentanteNome_Sel", AV39TFRepresentanteNome_Sel);
         AV40TFRepresentanteRG = "";
         AssignAttri("", false, "AV40TFRepresentanteRG", AV40TFRepresentanteRG);
         AV41TFRepresentanteRG_Sel = "";
         AssignAttri("", false, "AV41TFRepresentanteRG_Sel", AV41TFRepresentanteRG_Sel);
         AV42TFRepresentanteOrgaoExpedidor = "";
         AssignAttri("", false, "AV42TFRepresentanteOrgaoExpedidor", AV42TFRepresentanteOrgaoExpedidor);
         AV43TFRepresentanteOrgaoExpedidor_Sel = "";
         AssignAttri("", false, "AV43TFRepresentanteOrgaoExpedidor_Sel", AV43TFRepresentanteOrgaoExpedidor_Sel);
         AV44TFRepresentanteRGUF = "";
         AssignAttri("", false, "AV44TFRepresentanteRGUF", AV44TFRepresentanteRGUF);
         AV45TFRepresentanteRGUF_Sel = "";
         AssignAttri("", false, "AV45TFRepresentanteRGUF_Sel", AV45TFRepresentanteRGUF_Sel);
         AV46TFRepresentanteCPF = "";
         AssignAttri("", false, "AV46TFRepresentanteCPF", AV46TFRepresentanteCPF);
         AV47TFRepresentanteCPF_Sel = "";
         AssignAttri("", false, "AV47TFRepresentanteCPF_Sel", AV47TFRepresentanteCPF_Sel);
         AV49TFRepresentanteEstadoCivil_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50TFRepresentanteNacionalidade = "";
         AssignAttri("", false, "AV50TFRepresentanteNacionalidade", AV50TFRepresentanteNacionalidade);
         AV51TFRepresentanteNacionalidade_Sel = "";
         AssignAttri("", false, "AV51TFRepresentanteNacionalidade_Sel", AV51TFRepresentanteNacionalidade_Sel);
         AV67TFRepresentanteProfissaoDescricao = "";
         AssignAttri("", false, "AV67TFRepresentanteProfissaoDescricao", AV67TFRepresentanteProfissaoDescricao);
         AV68TFRepresentanteProfissaoDescricao_Sel = "";
         AssignAttri("", false, "AV68TFRepresentanteProfissaoDescricao_Sel", AV68TFRepresentanteProfissaoDescricao_Sel);
         AV54TFRepresentanteEmail = "";
         AssignAttri("", false, "AV54TFRepresentanteEmail", AV54TFRepresentanteEmail);
         AV55TFRepresentanteEmail_Sel = "";
         AssignAttri("", false, "AV55TFRepresentanteEmail_Sel", AV55TFRepresentanteEmail_Sel);
         AV57TFRepresentanteTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "REPRESENTANTENOME";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18RepresentanteNome1 = "";
         AssignAttri("", false, "AV18RepresentanteNome1", AV18RepresentanteNome1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV103GXV1 = 1;
         while ( AV103GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV103GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME") == 0 )
            {
               AV38TFRepresentanteNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFRepresentanteNome", AV38TFRepresentanteNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME_SEL") == 0 )
            {
               AV39TFRepresentanteNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFRepresentanteNome_Sel", AV39TFRepresentanteNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG") == 0 )
            {
               AV40TFRepresentanteRG = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFRepresentanteRG", AV40TFRepresentanteRG);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG_SEL") == 0 )
            {
               AV41TFRepresentanteRG_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFRepresentanteRG_Sel", AV41TFRepresentanteRG_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR") == 0 )
            {
               AV42TFRepresentanteOrgaoExpedidor = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFRepresentanteOrgaoExpedidor", AV42TFRepresentanteOrgaoExpedidor);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR_SEL") == 0 )
            {
               AV43TFRepresentanteOrgaoExpedidor_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFRepresentanteOrgaoExpedidor_Sel", AV43TFRepresentanteOrgaoExpedidor_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF") == 0 )
            {
               AV44TFRepresentanteRGUF = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFRepresentanteRGUF", AV44TFRepresentanteRGUF);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF_SEL") == 0 )
            {
               AV45TFRepresentanteRGUF_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFRepresentanteRGUF_Sel", AV45TFRepresentanteRGUF_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF") == 0 )
            {
               AV46TFRepresentanteCPF = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFRepresentanteCPF", AV46TFRepresentanteCPF);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF_SEL") == 0 )
            {
               AV47TFRepresentanteCPF_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFRepresentanteCPF_Sel", AV47TFRepresentanteCPF_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEESTADOCIVIL_SEL") == 0 )
            {
               AV48TFRepresentanteEstadoCivil_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFRepresentanteEstadoCivil_SelsJson", AV48TFRepresentanteEstadoCivil_SelsJson);
               AV49TFRepresentanteEstadoCivil_Sels.FromJSonString(AV48TFRepresentanteEstadoCivil_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE") == 0 )
            {
               AV50TFRepresentanteNacionalidade = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFRepresentanteNacionalidade", AV50TFRepresentanteNacionalidade);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE_SEL") == 0 )
            {
               AV51TFRepresentanteNacionalidade_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFRepresentanteNacionalidade_Sel", AV51TFRepresentanteNacionalidade_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO") == 0 )
            {
               AV67TFRepresentanteProfissaoDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFRepresentanteProfissaoDescricao", AV67TFRepresentanteProfissaoDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO_SEL") == 0 )
            {
               AV68TFRepresentanteProfissaoDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFRepresentanteProfissaoDescricao_Sel", AV68TFRepresentanteProfissaoDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL") == 0 )
            {
               AV54TFRepresentanteEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFRepresentanteEmail", AV54TFRepresentanteEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL_SEL") == 0 )
            {
               AV55TFRepresentanteEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFRepresentanteEmail_Sel", AV55TFRepresentanteEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTETIPO_SEL") == 0 )
            {
               AV56TFRepresentanteTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFRepresentanteTipo_SelsJson", AV56TFRepresentanteTipo_SelsJson);
               AV57TFRepresentanteTipo_Sels.FromJSonString(AV56TFRepresentanteTipo_SelsJson, null);
            }
            AV103GXV1 = (int)(AV103GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRepresentanteNome_Sel)),  AV39TFRepresentanteNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRepresentanteRG_Sel)),  AV41TFRepresentanteRG_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRepresentanteOrgaoExpedidor_Sel)),  AV43TFRepresentanteOrgaoExpedidor_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRepresentanteRGUF_Sel)),  AV45TFRepresentanteRGUF_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRepresentanteCPF_Sel)),  AV47TFRepresentanteCPF_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV49TFRepresentanteEstadoCivil_Sels.Count==0),  AV48TFRepresentanteEstadoCivil_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFRepresentanteNacionalidade_Sel)),  AV51TFRepresentanteNacionalidade_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFRepresentanteProfissaoDescricao_Sel)),  AV68TFRepresentanteProfissaoDescricao_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFRepresentanteEmail_Sel)),  AV55TFRepresentanteEmail_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV57TFRepresentanteTipo_Sels.Count==0),  AV56TFRepresentanteTipo_SelsJson, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFRepresentanteNome)),  AV38TFRepresentanteNome, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRepresentanteRG)),  AV40TFRepresentanteRG, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRepresentanteOrgaoExpedidor)),  AV42TFRepresentanteOrgaoExpedidor, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRepresentanteRGUF)),  AV44TFRepresentanteRGUF, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFRepresentanteCPF)),  AV46TFRepresentanteCPF, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRepresentanteNacionalidade)),  AV50TFRepresentanteNacionalidade, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFRepresentanteProfissaoDescricao)),  AV67TFRepresentanteProfissaoDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFRepresentanteEmail)),  AV54TFRepresentanteEmail, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"||"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18RepresentanteNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18RepresentanteNome1", AV18RepresentanteNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19RepresentanteMunicipioNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19RepresentanteMunicipioNome1", AV19RepresentanteMunicipioNome1);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23RepresentanteNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23RepresentanteNome2", AV23RepresentanteNome2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24RepresentanteMunicipioNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24RepresentanteMunicipioNome2", AV24RepresentanteMunicipioNome2);
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
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28RepresentanteNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28RepresentanteNome3", AV28RepresentanteNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29RepresentanteMunicipioNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29RepresentanteMunicipioNome3", AV29RepresentanteMunicipioNome3);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTENOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFRepresentanteNome)),  0,  AV38TFRepresentanteNome,  AV38TFRepresentanteNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRepresentanteNome_Sel)),  AV39TFRepresentanteNome_Sel,  AV39TFRepresentanteNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTERG",  "RG",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRepresentanteRG)),  0,  AV40TFRepresentanteRG,  AV40TFRepresentanteRG,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRepresentanteRG_Sel)),  AV41TFRepresentanteRG_Sel,  AV41TFRepresentanteRG_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTEORGAOEXPEDIDOR",  "Órgão expedidor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRepresentanteOrgaoExpedidor)),  0,  AV42TFRepresentanteOrgaoExpedidor,  AV42TFRepresentanteOrgaoExpedidor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRepresentanteOrgaoExpedidor_Sel)),  AV43TFRepresentanteOrgaoExpedidor_Sel,  AV43TFRepresentanteOrgaoExpedidor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTERGUF",  "RG",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRepresentanteRGUF)),  0,  AV44TFRepresentanteRGUF,  AV44TFRepresentanteRGUF,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRepresentanteRGUF_Sel)),  AV45TFRepresentanteRGUF_Sel,  AV45TFRepresentanteRGUF_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTECPF",  "CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFRepresentanteCPF)),  0,  AV46TFRepresentanteCPF,  AV46TFRepresentanteCPF,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRepresentanteCPF_Sel)),  AV47TFRepresentanteCPF_Sel,  AV47TFRepresentanteCPF_Sel) ;
         AV65AuxText = ((AV49TFRepresentanteEstadoCivil_Sels.Count==1) ? "["+((string)AV49TFRepresentanteEstadoCivil_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREPRESENTANTEESTADOCIVIL_SEL",  "Estado Civil",  !(AV49TFRepresentanteEstadoCivil_Sels.Count==0),  0,  AV49TFRepresentanteEstadoCivil_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV65AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV65AuxText, "[SOLTEIRO]", "Solteiro(a)"), "[CASADO]", "Casado(a)"), "[DIVORCIADO]", "Divorciado(a)"), "[VIUVO]", "Viúvo(a)"), "[SEPARADO]", "Separado(a)"), "[UNIAO_ESTAVEL]", "União Estável")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTENACIONALIDADE",  "Nacionalidade",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRepresentanteNacionalidade)),  0,  AV50TFRepresentanteNacionalidade,  AV50TFRepresentanteNacionalidade,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFRepresentanteNacionalidade_Sel)),  AV51TFRepresentanteNacionalidade_Sel,  AV51TFRepresentanteNacionalidade_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTEPROFISSAODESCRICAO",  "Profissão",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFRepresentanteProfissaoDescricao)),  0,  AV67TFRepresentanteProfissaoDescricao,  AV67TFRepresentanteProfissaoDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFRepresentanteProfissaoDescricao_Sel)),  AV68TFRepresentanteProfissaoDescricao_Sel,  AV68TFRepresentanteProfissaoDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREPRESENTANTEEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFRepresentanteEmail)),  0,  AV54TFRepresentanteEmail,  AV54TFRepresentanteEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFRepresentanteEmail_Sel)),  AV55TFRepresentanteEmail_Sel,  AV55TFRepresentanteEmail_Sel) ;
         AV65AuxText = ((AV57TFRepresentanteTipo_Sels.Count==1) ? "["+((string)AV57TFRepresentanteTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREPRESENTANTETIPO_SEL",  "Tipo",  !(AV57TFRepresentanteTipo_Sels.Count==0),  0,  AV57TFRepresentanteTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV65AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV65AuxText, "[Representante]", "Representante"), "[Responsavel_solidario]", "Responsável Solidário")),  false,  "",  "") ;
         if ( ! (0==AV66ClienteId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV66ClienteId), 9, 0);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18RepresentanteNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome",  AV17DynamicFiltersOperator1,  AV18RepresentanteNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18RepresentanteNome1, "Contém"+" "+AV18RepresentanteNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19RepresentanteMunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV17DynamicFiltersOperator1,  AV19RepresentanteMunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19RepresentanteMunicipioNome1, "Contém"+" "+AV19RepresentanteMunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23RepresentanteNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome",  AV22DynamicFiltersOperator2,  AV23RepresentanteNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV23RepresentanteNome2, "Contém"+" "+AV23RepresentanteNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24RepresentanteMunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV22DynamicFiltersOperator2,  AV24RepresentanteMunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24RepresentanteMunicipioNome2, "Contém"+" "+AV24RepresentanteMunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28RepresentanteNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome",  AV27DynamicFiltersOperator3,  AV28RepresentanteNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28RepresentanteNome3, "Contém"+" "+AV28RepresentanteNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29RepresentanteMunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV27DynamicFiltersOperator3,  AV29RepresentanteMunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29RepresentanteMunicipioNome3, "Contém"+" "+AV29RepresentanteMunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Representante";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_98_9P2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantenome3_Internalname, "Representante Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantenome3_Internalname, AV28RepresentanteNome3, StringUtil.RTrim( context.localUtil.Format( AV28RepresentanteNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantenome3_Visible, edtavRepresentantenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantemunicipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantemunicipionome3_Internalname, "Representante Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantemunicipionome3_Internalname, AV29RepresentanteMunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV29RepresentanteMunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantemunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantemunicipionome3_Visible, edtavRepresentantemunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RepresentanteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_98_9P2e( true) ;
         }
         else
         {
            wb_table3_98_9P2e( false) ;
         }
      }

      protected void wb_table2_73_9P2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantenome2_Internalname, "Representante Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantenome2_Internalname, AV23RepresentanteNome2, StringUtil.RTrim( context.localUtil.Format( AV23RepresentanteNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantenome2_Visible, edtavRepresentantenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantemunicipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantemunicipionome2_Internalname, "Representante Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantemunicipionome2_Internalname, AV24RepresentanteMunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV24RepresentanteMunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantemunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantemunicipionome2_Visible, edtavRepresentantemunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RepresentanteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RepresentanteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_73_9P2e( true) ;
         }
         else
         {
            wb_table2_73_9P2e( false) ;
         }
      }

      protected void wb_table1_48_9P2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_RepresentanteWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantenome1_Internalname, "Representante Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantenome1_Internalname, AV18RepresentanteNome1, StringUtil.RTrim( context.localUtil.Format( AV18RepresentanteNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantenome1_Visible, edtavRepresentantenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_representantemunicipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantemunicipionome1_Internalname, "Representante Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantemunicipionome1_Internalname, AV19RepresentanteMunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV19RepresentanteMunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantemunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentantemunicipionome1_Visible, edtavRepresentantemunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RepresentanteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RepresentanteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RepresentanteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_9P2e( true) ;
         }
         else
         {
            wb_table1_48_9P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV66ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV66ClienteId", StringUtil.LTrimStr( (decimal)(AV66ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66ClienteId), "ZZZZZZZZ9"), context));
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
         PA9P2( ) ;
         WS9P2( ) ;
         WE9P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101929061", true, true);
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
         context.AddJavascriptSource("representanteww.js", "?20256101929061", false, true);
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

      protected void SubsflControlProps_1192( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_119_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_119_idx;
         edtRepresentanteId_Internalname = "REPRESENTANTEID_"+sGXsfl_119_idx;
         edtRepresentanteNome_Internalname = "REPRESENTANTENOME_"+sGXsfl_119_idx;
         edtRepresentanteRG_Internalname = "REPRESENTANTERG_"+sGXsfl_119_idx;
         edtRepresentanteOrgaoExpedidor_Internalname = "REPRESENTANTEORGAOEXPEDIDOR_"+sGXsfl_119_idx;
         edtRepresentanteRGUF_Internalname = "REPRESENTANTERGUF_"+sGXsfl_119_idx;
         edtRepresentanteCPF_Internalname = "REPRESENTANTECPF_"+sGXsfl_119_idx;
         cmbRepresentanteEstadoCivil_Internalname = "REPRESENTANTEESTADOCIVIL_"+sGXsfl_119_idx;
         edtRepresentanteNacionalidade_Internalname = "REPRESENTANTENACIONALIDADE_"+sGXsfl_119_idx;
         edtRepresentanteProfissaoDescricao_Internalname = "REPRESENTANTEPROFISSAODESCRICAO_"+sGXsfl_119_idx;
         edtRepresentanteProfissao_Internalname = "REPRESENTANTEPROFISSAO_"+sGXsfl_119_idx;
         edtRepresentanteEmail_Internalname = "REPRESENTANTEEMAIL_"+sGXsfl_119_idx;
         cmbRepresentanteTipo_Internalname = "REPRESENTANTETIPO_"+sGXsfl_119_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_119_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_119_fel_idx;
         edtRepresentanteId_Internalname = "REPRESENTANTEID_"+sGXsfl_119_fel_idx;
         edtRepresentanteNome_Internalname = "REPRESENTANTENOME_"+sGXsfl_119_fel_idx;
         edtRepresentanteRG_Internalname = "REPRESENTANTERG_"+sGXsfl_119_fel_idx;
         edtRepresentanteOrgaoExpedidor_Internalname = "REPRESENTANTEORGAOEXPEDIDOR_"+sGXsfl_119_fel_idx;
         edtRepresentanteRGUF_Internalname = "REPRESENTANTERGUF_"+sGXsfl_119_fel_idx;
         edtRepresentanteCPF_Internalname = "REPRESENTANTECPF_"+sGXsfl_119_fel_idx;
         cmbRepresentanteEstadoCivil_Internalname = "REPRESENTANTEESTADOCIVIL_"+sGXsfl_119_fel_idx;
         edtRepresentanteNacionalidade_Internalname = "REPRESENTANTENACIONALIDADE_"+sGXsfl_119_fel_idx;
         edtRepresentanteProfissaoDescricao_Internalname = "REPRESENTANTEPROFISSAODESCRICAO_"+sGXsfl_119_fel_idx;
         edtRepresentanteProfissao_Internalname = "REPRESENTANTEPROFISSAO_"+sGXsfl_119_fel_idx;
         edtRepresentanteEmail_Internalname = "REPRESENTANTEEMAIL_"+sGXsfl_119_fel_idx;
         cmbRepresentanteTipo_Internalname = "REPRESENTANTETIPO_"+sGXsfl_119_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         WB9P0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_119_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_119_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_119_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV63Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV64Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A978RepresentanteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteNome_Internalname,(string)A979RepresentanteNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteRG_Internalname,(string)A980RepresentanteRG,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteRG_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteOrgaoExpedidor_Internalname,(string)A981RepresentanteOrgaoExpedidor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteOrgaoExpedidor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteRGUF_Internalname,(string)A982RepresentanteRGUF,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteRGUF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteCPF_Internalname,(string)A983RepresentanteCPF,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbRepresentanteEstadoCivil.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "REPRESENTANTEESTADOCIVIL_" + sGXsfl_119_idx;
               cmbRepresentanteEstadoCivil.Name = GXCCtl;
               cmbRepresentanteEstadoCivil.WebTags = "";
               cmbRepresentanteEstadoCivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
               cmbRepresentanteEstadoCivil.addItem("CASADO", "Casado(a)", 0);
               cmbRepresentanteEstadoCivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
               cmbRepresentanteEstadoCivil.addItem("VIUVO", "Viúvo(a)", 0);
               cmbRepresentanteEstadoCivil.addItem("SEPARADO", "Separado(a)", 0);
               cmbRepresentanteEstadoCivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
               if ( cmbRepresentanteEstadoCivil.ItemCount > 0 )
               {
                  A984RepresentanteEstadoCivil = cmbRepresentanteEstadoCivil.getValidValue(A984RepresentanteEstadoCivil);
                  n984RepresentanteEstadoCivil = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRepresentanteEstadoCivil,(string)cmbRepresentanteEstadoCivil_Internalname,StringUtil.RTrim( A984RepresentanteEstadoCivil),(short)1,(string)cmbRepresentanteEstadoCivil_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbRepresentanteEstadoCivil.CurrentValue = StringUtil.RTrim( A984RepresentanteEstadoCivil);
            AssignProp("", false, cmbRepresentanteEstadoCivil_Internalname, "Values", (string)(cmbRepresentanteEstadoCivil.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteNacionalidade_Internalname,(string)A985RepresentanteNacionalidade,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteNacionalidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteProfissaoDescricao_Internalname,(string)A999RepresentanteProfissaoDescricao,StringUtil.RTrim( context.localUtil.Format( A999RepresentanteProfissaoDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteProfissaoDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteProfissao_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A977RepresentanteProfissao), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepresentanteProfissao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepresentanteEmail_Internalname,(string)A986RepresentanteEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A986RepresentanteEmail,(string)"",(string)"",(string)"",(string)edtRepresentanteEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbRepresentanteTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "REPRESENTANTETIPO_" + sGXsfl_119_idx;
               cmbRepresentanteTipo.Name = GXCCtl;
               cmbRepresentanteTipo.WebTags = "";
               cmbRepresentanteTipo.addItem("Representante", "Representante", 0);
               cmbRepresentanteTipo.addItem("Responsavel_solidario", "Responsável Solidário", 0);
               if ( cmbRepresentanteTipo.ItemCount > 0 )
               {
                  A998RepresentanteTipo = cmbRepresentanteTipo.getValidValue(A998RepresentanteTipo);
                  n998RepresentanteTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRepresentanteTipo,(string)cmbRepresentanteTipo_Internalname,StringUtil.RTrim( A998RepresentanteTipo),(short)1,(string)cmbRepresentanteTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbRepresentanteTipo.CurrentValue = StringUtil.RTrim( A998RepresentanteTipo);
            AssignProp("", false, cmbRepresentanteTipo_Internalname, "Values", (string)(cmbRepresentanteTipo.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9P2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         /* End function sendrow_1192 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("REPRESENTANTENOME", "Nome", 0);
         cmbavDynamicfiltersselector1.addItem("REPRESENTANTEMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("REPRESENTANTENOME", "Nome", 0);
         cmbavDynamicfiltersselector2.addItem("REPRESENTANTEMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("REPRESENTANTENOME", "Nome", 0);
         cmbavDynamicfiltersselector3.addItem("REPRESENTANTEMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "REPRESENTANTEESTADOCIVIL_" + sGXsfl_119_idx;
         cmbRepresentanteEstadoCivil.Name = GXCCtl;
         cmbRepresentanteEstadoCivil.WebTags = "";
         cmbRepresentanteEstadoCivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("CASADO", "Casado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbRepresentanteEstadoCivil.ItemCount > 0 )
         {
            A984RepresentanteEstadoCivil = cmbRepresentanteEstadoCivil.getValidValue(A984RepresentanteEstadoCivil);
            n984RepresentanteEstadoCivil = false;
         }
         GXCCtl = "REPRESENTANTETIPO_" + sGXsfl_119_idx;
         cmbRepresentanteTipo.Name = GXCCtl;
         cmbRepresentanteTipo.WebTags = "";
         cmbRepresentanteTipo.addItem("Representante", "Representante", 0);
         cmbRepresentanteTipo.addItem("Responsavel_solidario", "Responsável Solidário", 0);
         if ( cmbRepresentanteTipo.ItemCount > 0 )
         {
            A998RepresentanteTipo = cmbRepresentanteTipo.getValidValue(A998RepresentanteTipo);
            n998RepresentanteTipo = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl119( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"119\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "RG") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Órgão expedidor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "RG") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Estado Civil") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nacionalidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Profissão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Profissao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV63Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV64Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A978RepresentanteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A979RepresentanteNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A980RepresentanteRG));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A981RepresentanteOrgaoExpedidor));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A982RepresentanteRGUF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A983RepresentanteCPF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A984RepresentanteEstadoCivil));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A985RepresentanteNacionalidade));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A999RepresentanteProfissaoDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A986RepresentanteEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A998RepresentanteTipo));
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
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavRepresentantenome1_Internalname = "vREPRESENTANTENOME1";
         cellFilter_representantenome1_cell_Internalname = "FILTER_REPRESENTANTENOME1_CELL";
         edtavRepresentantemunicipionome1_Internalname = "vREPRESENTANTEMUNICIPIONOME1";
         cellFilter_representantemunicipionome1_cell_Internalname = "FILTER_REPRESENTANTEMUNICIPIONOME1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavRepresentantenome2_Internalname = "vREPRESENTANTENOME2";
         cellFilter_representantenome2_cell_Internalname = "FILTER_REPRESENTANTENOME2_CELL";
         edtavRepresentantemunicipionome2_Internalname = "vREPRESENTANTEMUNICIPIONOME2";
         cellFilter_representantemunicipionome2_cell_Internalname = "FILTER_REPRESENTANTEMUNICIPIONOME2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavRepresentantenome3_Internalname = "vREPRESENTANTENOME3";
         cellFilter_representantenome3_cell_Internalname = "FILTER_REPRESENTANTENOME3_CELL";
         edtavRepresentantemunicipionome3_Internalname = "vREPRESENTANTEMUNICIPIONOME3";
         cellFilter_representantemunicipionome3_cell_Internalname = "FILTER_REPRESENTANTEMUNICIPIONOME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtRepresentanteId_Internalname = "REPRESENTANTEID";
         edtRepresentanteNome_Internalname = "REPRESENTANTENOME";
         edtRepresentanteRG_Internalname = "REPRESENTANTERG";
         edtRepresentanteOrgaoExpedidor_Internalname = "REPRESENTANTEORGAOEXPEDIDOR";
         edtRepresentanteRGUF_Internalname = "REPRESENTANTERGUF";
         edtRepresentanteCPF_Internalname = "REPRESENTANTECPF";
         cmbRepresentanteEstadoCivil_Internalname = "REPRESENTANTEESTADOCIVIL";
         edtRepresentanteNacionalidade_Internalname = "REPRESENTANTENACIONALIDADE";
         edtRepresentanteProfissaoDescricao_Internalname = "REPRESENTANTEPROFISSAODESCRICAO";
         edtRepresentanteProfissao_Internalname = "REPRESENTANTEPROFISSAO";
         edtRepresentanteEmail_Internalname = "REPRESENTANTEEMAIL";
         cmbRepresentanteTipo_Internalname = "REPRESENTANTETIPO";
         edtClienteId_Internalname = "CLIENTEID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
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
         edtClienteId_Jsonclick = "";
         cmbRepresentanteTipo_Jsonclick = "";
         edtRepresentanteEmail_Jsonclick = "";
         edtRepresentanteProfissao_Jsonclick = "";
         edtRepresentanteProfissaoDescricao_Jsonclick = "";
         edtRepresentanteNacionalidade_Jsonclick = "";
         cmbRepresentanteEstadoCivil_Jsonclick = "";
         edtRepresentanteCPF_Jsonclick = "";
         edtRepresentanteRGUF_Jsonclick = "";
         edtRepresentanteOrgaoExpedidor_Jsonclick = "";
         edtRepresentanteRG_Jsonclick = "";
         edtRepresentanteNome_Jsonclick = "";
         edtRepresentanteId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavRepresentantemunicipionome1_Jsonclick = "";
         edtavRepresentantemunicipionome1_Enabled = 1;
         edtavRepresentantenome1_Jsonclick = "";
         edtavRepresentantenome1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavRepresentantemunicipionome2_Jsonclick = "";
         edtavRepresentantemunicipionome2_Enabled = 1;
         edtavRepresentantenome2_Jsonclick = "";
         edtavRepresentantenome2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavRepresentantemunicipionome3_Jsonclick = "";
         edtavRepresentantemunicipionome3_Enabled = 1;
         edtavRepresentantenome3_Jsonclick = "";
         edtavRepresentantenome3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavRepresentantemunicipionome3_Visible = 1;
         edtavRepresentantenome3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavRepresentantemunicipionome2_Visible = 1;
         edtavRepresentantenome2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavRepresentantemunicipionome1_Visible = 1;
         edtavRepresentantenome1_Visible = 1;
         edtClienteId_Enabled = 0;
         cmbRepresentanteTipo.Enabled = 0;
         edtRepresentanteEmail_Enabled = 0;
         edtRepresentanteProfissao_Enabled = 0;
         edtRepresentanteProfissaoDescricao_Enabled = 0;
         edtRepresentanteNacionalidade_Enabled = 0;
         cmbRepresentanteEstadoCivil.Enabled = 0;
         edtRepresentanteCPF_Enabled = 0;
         edtRepresentanteRGUF_Enabled = 0;
         edtRepresentanteOrgaoExpedidor_Enabled = 0;
         edtRepresentanteRG_Enabled = 0;
         edtRepresentanteNome_Enabled = 0;
         edtRepresentanteId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "RepresentanteWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||SOLTEIRO:Solteiro(a),CASADO:Casado(a),DIVORCIADO:Divorciado(a),VIUVO:Viúvo(a),SEPARADO:Separado(a),UNIAO_ESTAVEL:União Estável||||Representante:Representante,Responsavel_solidario:Responsável Solidário";
         Ddo_grid_Allowmultipleselection = "|||||T||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character||Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "3:RepresentanteNome|4:RepresentanteRG|5:RepresentanteOrgaoExpedidor|6:RepresentanteRGUF|7:RepresentanteCPF|8:RepresentanteEstadoCivil|9:RepresentanteNacionalidade|10:RepresentanteProfissaoDescricao|12:RepresentanteEmail|13:RepresentanteTipo";
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
         Form.Caption = " Representante";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV56TFRepresentanteTipo_SelsJson","fld":"vTFREPRESENTANTETIPO_SELSJSON","type":"vchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV48TFRepresentanteEstadoCivil_SelsJson","fld":"vTFREPRESENTANTEESTADOCIVIL_SELSJSON","type":"vchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E279P2","iparms":[{"av":"A978RepresentanteId","fld":"REPRESENTANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV63Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV64Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E209P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"edtavRepresentantenome2_Visible","ctrl":"vREPRESENTANTENOME2","prop":"Visible"},{"av":"edtavRepresentantemunicipionome2_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME2","prop":"Visible"},{"av":"edtavRepresentantenome3_Visible","ctrl":"vREPRESENTANTENOME3","prop":"Visible"},{"av":"edtavRepresentantemunicipionome3_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME3","prop":"Visible"},{"av":"edtavRepresentantenome1_Visible","ctrl":"vREPRESENTANTENOME1","prop":"Visible"},{"av":"edtavRepresentantemunicipionome1_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219P2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavRepresentantenome1_Visible","ctrl":"vREPRESENTANTENOME1","prop":"Visible"},{"av":"edtavRepresentantemunicipionome1_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E229P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"edtavRepresentantenome2_Visible","ctrl":"vREPRESENTANTENOME2","prop":"Visible"},{"av":"edtavRepresentantemunicipionome2_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME2","prop":"Visible"},{"av":"edtavRepresentantenome3_Visible","ctrl":"vREPRESENTANTENOME3","prop":"Visible"},{"av":"edtavRepresentantemunicipionome3_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME3","prop":"Visible"},{"av":"edtavRepresentantenome1_Visible","ctrl":"vREPRESENTANTENOME1","prop":"Visible"},{"av":"edtavRepresentantemunicipionome1_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E239P2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavRepresentantenome2_Visible","ctrl":"vREPRESENTANTENOME2","prop":"Visible"},{"av":"edtavRepresentantemunicipionome2_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"edtavRepresentantenome2_Visible","ctrl":"vREPRESENTANTENOME2","prop":"Visible"},{"av":"edtavRepresentantemunicipionome2_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME2","prop":"Visible"},{"av":"edtavRepresentantenome3_Visible","ctrl":"vREPRESENTANTENOME3","prop":"Visible"},{"av":"edtavRepresentantemunicipionome3_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME3","prop":"Visible"},{"av":"edtavRepresentantenome1_Visible","ctrl":"vREPRESENTANTENOME1","prop":"Visible"},{"av":"edtavRepresentantemunicipionome1_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E249P2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavRepresentantenome3_Visible","ctrl":"vREPRESENTANTENOME3","prop":"Visible"},{"av":"edtavRepresentantemunicipionome3_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV48TFRepresentanteEstadoCivil_SelsJson","fld":"vTFREPRESENTANTEESTADOCIVIL_SELSJSON","type":"vchar"},{"av":"AV56TFRepresentanteTipo_SelsJson","fld":"vTFREPRESENTANTETIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFRepresentanteNome","fld":"vTFREPRESENTANTENOME","type":"svchar"},{"av":"AV39TFRepresentanteNome_Sel","fld":"vTFREPRESENTANTENOME_SEL","type":"svchar"},{"av":"AV40TFRepresentanteRG","fld":"vTFREPRESENTANTERG","type":"svchar"},{"av":"AV41TFRepresentanteRG_Sel","fld":"vTFREPRESENTANTERG_SEL","type":"svchar"},{"av":"AV42TFRepresentanteOrgaoExpedidor","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR","type":"svchar"},{"av":"AV43TFRepresentanteOrgaoExpedidor_Sel","fld":"vTFREPRESENTANTEORGAOEXPEDIDOR_SEL","type":"svchar"},{"av":"AV44TFRepresentanteRGUF","fld":"vTFREPRESENTANTERGUF","type":"svchar"},{"av":"AV45TFRepresentanteRGUF_Sel","fld":"vTFREPRESENTANTERGUF_SEL","type":"svchar"},{"av":"AV46TFRepresentanteCPF","fld":"vTFREPRESENTANTECPF","type":"svchar"},{"av":"AV47TFRepresentanteCPF_Sel","fld":"vTFREPRESENTANTECPF_SEL","type":"svchar"},{"av":"AV49TFRepresentanteEstadoCivil_Sels","fld":"vTFREPRESENTANTEESTADOCIVIL_SELS","type":""},{"av":"AV50TFRepresentanteNacionalidade","fld":"vTFREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"AV51TFRepresentanteNacionalidade_Sel","fld":"vTFREPRESENTANTENACIONALIDADE_SEL","type":"svchar"},{"av":"AV67TFRepresentanteProfissaoDescricao","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"},{"av":"AV68TFRepresentanteProfissaoDescricao_Sel","fld":"vTFREPRESENTANTEPROFISSAODESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV54TFRepresentanteEmail","fld":"vTFREPRESENTANTEEMAIL","type":"svchar"},{"av":"AV55TFRepresentanteEmail_Sel","fld":"vTFREPRESENTANTEEMAIL_SEL","type":"svchar"},{"av":"AV57TFRepresentanteTipo_Sels","fld":"vTFREPRESENTANTETIPO_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18RepresentanteNome1","fld":"vREPRESENTANTENOME1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV56TFRepresentanteTipo_SelsJson","fld":"vTFREPRESENTANTETIPO_SELSJSON","type":"vchar"},{"av":"AV48TFRepresentanteEstadoCivil_SelsJson","fld":"vTFREPRESENTANTEESTADOCIVIL_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19RepresentanteMunicipioNome1","fld":"vREPRESENTANTEMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23RepresentanteNome2","fld":"vREPRESENTANTENOME2","type":"svchar"},{"av":"AV24RepresentanteMunicipioNome2","fld":"vREPRESENTANTEMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28RepresentanteNome3","fld":"vREPRESENTANTENOME3","type":"svchar"},{"av":"AV29RepresentanteMunicipioNome3","fld":"vREPRESENTANTEMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"edtavRepresentantenome1_Visible","ctrl":"vREPRESENTANTENOME1","prop":"Visible"},{"av":"edtavRepresentantemunicipionome1_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME1","prop":"Visible"},{"av":"edtavRepresentantenome2_Visible","ctrl":"vREPRESENTANTENOME2","prop":"Visible"},{"av":"edtavRepresentantemunicipionome2_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME2","prop":"Visible"},{"av":"edtavRepresentantenome3_Visible","ctrl":"vREPRESENTANTENOME3","prop":"Visible"},{"av":"edtavRepresentantemunicipionome3_Visible","ctrl":"vREPRESENTANTEMUNICIPIONOME3","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189P2","iparms":[{"av":"A978RepresentanteId","fld":"REPRESENTANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV66ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199P2","iparms":[]}""");
         setEventMetadata("VALID_REPRESENTANTEPROFISSAO","""{"handler":"Valid_Representanteprofissao","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18RepresentanteNome1 = "";
         AV19RepresentanteMunicipioNome1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23RepresentanteNome2 = "";
         AV24RepresentanteMunicipioNome2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28RepresentanteNome3 = "";
         AV29RepresentanteMunicipioNome3 = "";
         AV69Pgmname = "";
         AV38TFRepresentanteNome = "";
         AV39TFRepresentanteNome_Sel = "";
         AV40TFRepresentanteRG = "";
         AV41TFRepresentanteRG_Sel = "";
         AV42TFRepresentanteOrgaoExpedidor = "";
         AV43TFRepresentanteOrgaoExpedidor_Sel = "";
         AV44TFRepresentanteRGUF = "";
         AV45TFRepresentanteRGUF_Sel = "";
         AV46TFRepresentanteCPF = "";
         AV47TFRepresentanteCPF_Sel = "";
         AV49TFRepresentanteEstadoCivil_Sels = new GxSimpleCollection<string>();
         AV50TFRepresentanteNacionalidade = "";
         AV51TFRepresentanteNacionalidade_Sel = "";
         AV67TFRepresentanteProfissaoDescricao = "";
         AV68TFRepresentanteProfissaoDescricao_Sel = "";
         AV54TFRepresentanteEmail = "";
         AV55TFRepresentanteEmail_Sel = "";
         AV57TFRepresentanteTipo_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62GridAppliedFilters = "";
         AV58DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV48TFRepresentanteEstadoCivil_SelsJson = "";
         AV56TFRepresentanteTipo_SelsJson = "";
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
         bttBtn_cancel_Jsonclick = "";
         ucDvpanel_tableheader = new GXUserControl();
         bttBtninsert_Jsonclick = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV63Display = "";
         AV64Update = "";
         A979RepresentanteNome = "";
         A980RepresentanteRG = "";
         A981RepresentanteOrgaoExpedidor = "";
         A982RepresentanteRGUF = "";
         A983RepresentanteCPF = "";
         A984RepresentanteEstadoCivil = "";
         A985RepresentanteNacionalidade = "";
         A999RepresentanteProfissaoDescricao = "";
         A986RepresentanteEmail = "";
         A998RepresentanteTipo = "";
         GXDecQS = "";
         AV95Representantewwds_26_tfrepresentanteestadocivil_sels = new GxSimpleCollection<string>();
         AV102Representantewwds_33_tfrepresentantetipo_sels = new GxSimpleCollection<string>();
         lV70Representantewwds_1_filterfulltext = "";
         lV73Representantewwds_4_representantenome1 = "";
         lV74Representantewwds_5_representantemunicipionome1 = "";
         lV78Representantewwds_9_representantenome2 = "";
         lV79Representantewwds_10_representantemunicipionome2 = "";
         lV83Representantewwds_14_representantenome3 = "";
         lV84Representantewwds_15_representantemunicipionome3 = "";
         lV85Representantewwds_16_tfrepresentantenome = "";
         lV87Representantewwds_18_tfrepresentanterg = "";
         lV89Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         lV91Representantewwds_22_tfrepresentanterguf = "";
         lV93Representantewwds_24_tfrepresentantecpf = "";
         lV96Representantewwds_27_tfrepresentantenacionalidade = "";
         lV98Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         lV100Representantewwds_31_tfrepresentanteemail = "";
         AV70Representantewwds_1_filterfulltext = "";
         AV71Representantewwds_2_dynamicfiltersselector1 = "";
         AV73Representantewwds_4_representantenome1 = "";
         AV74Representantewwds_5_representantemunicipionome1 = "";
         AV76Representantewwds_7_dynamicfiltersselector2 = "";
         AV78Representantewwds_9_representantenome2 = "";
         AV79Representantewwds_10_representantemunicipionome2 = "";
         AV81Representantewwds_12_dynamicfiltersselector3 = "";
         AV83Representantewwds_14_representantenome3 = "";
         AV84Representantewwds_15_representantemunicipionome3 = "";
         AV86Representantewwds_17_tfrepresentantenome_sel = "";
         AV85Representantewwds_16_tfrepresentantenome = "";
         AV88Representantewwds_19_tfrepresentanterg_sel = "";
         AV87Representantewwds_18_tfrepresentanterg = "";
         AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = "";
         AV89Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         AV92Representantewwds_23_tfrepresentanterguf_sel = "";
         AV91Representantewwds_22_tfrepresentanterguf = "";
         AV94Representantewwds_25_tfrepresentantecpf_sel = "";
         AV93Representantewwds_24_tfrepresentantecpf = "";
         AV97Representantewwds_28_tfrepresentantenacionalidade_sel = "";
         AV96Representantewwds_27_tfrepresentantenacionalidade = "";
         AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel = "";
         AV98Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         AV101Representantewwds_32_tfrepresentanteemail_sel = "";
         AV100Representantewwds_31_tfrepresentanteemail = "";
         A997RepresentanteMunicipioNome = "";
         H009P2_A991RepresentanteMunicipio = new string[] {""} ;
         H009P2_n991RepresentanteMunicipio = new bool[] {false} ;
         H009P2_A997RepresentanteMunicipioNome = new string[] {""} ;
         H009P2_n997RepresentanteMunicipioNome = new bool[] {false} ;
         H009P2_A168ClienteId = new int[1] ;
         H009P2_n168ClienteId = new bool[] {false} ;
         H009P2_A998RepresentanteTipo = new string[] {""} ;
         H009P2_n998RepresentanteTipo = new bool[] {false} ;
         H009P2_A986RepresentanteEmail = new string[] {""} ;
         H009P2_n986RepresentanteEmail = new bool[] {false} ;
         H009P2_A977RepresentanteProfissao = new int[1] ;
         H009P2_n977RepresentanteProfissao = new bool[] {false} ;
         H009P2_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         H009P2_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         H009P2_A985RepresentanteNacionalidade = new string[] {""} ;
         H009P2_n985RepresentanteNacionalidade = new bool[] {false} ;
         H009P2_A984RepresentanteEstadoCivil = new string[] {""} ;
         H009P2_n984RepresentanteEstadoCivil = new bool[] {false} ;
         H009P2_A983RepresentanteCPF = new string[] {""} ;
         H009P2_n983RepresentanteCPF = new bool[] {false} ;
         H009P2_A982RepresentanteRGUF = new string[] {""} ;
         H009P2_n982RepresentanteRGUF = new bool[] {false} ;
         H009P2_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         H009P2_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         H009P2_A980RepresentanteRG = new string[] {""} ;
         H009P2_n980RepresentanteRG = new bool[] {false} ;
         H009P2_A979RepresentanteNome = new string[] {""} ;
         H009P2_n979RepresentanteNome = new bool[] {false} ;
         H009P2_A978RepresentanteId = new int[1] ;
         A991RepresentanteMunicipio = "";
         H009P3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
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
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV65AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representanteww__default(),
            new Object[][] {
                new Object[] {
               H009P2_A991RepresentanteMunicipio, H009P2_n991RepresentanteMunicipio, H009P2_A997RepresentanteMunicipioNome, H009P2_n997RepresentanteMunicipioNome, H009P2_A168ClienteId, H009P2_n168ClienteId, H009P2_A998RepresentanteTipo, H009P2_n998RepresentanteTipo, H009P2_A986RepresentanteEmail, H009P2_n986RepresentanteEmail,
               H009P2_A977RepresentanteProfissao, H009P2_n977RepresentanteProfissao, H009P2_A999RepresentanteProfissaoDescricao, H009P2_n999RepresentanteProfissaoDescricao, H009P2_A985RepresentanteNacionalidade, H009P2_n985RepresentanteNacionalidade, H009P2_A984RepresentanteEstadoCivil, H009P2_n984RepresentanteEstadoCivil, H009P2_A983RepresentanteCPF, H009P2_n983RepresentanteCPF,
               H009P2_A982RepresentanteRGUF, H009P2_n982RepresentanteRGUF, H009P2_A981RepresentanteOrgaoExpedidor, H009P2_n981RepresentanteOrgaoExpedidor, H009P2_A980RepresentanteRG, H009P2_n980RepresentanteRG, H009P2_A979RepresentanteNome, H009P2_n979RepresentanteNome, H009P2_A978RepresentanteId
               }
               , new Object[] {
               H009P3_AGRID_nRecordCount
               }
            }
         );
         AV69Pgmname = "RepresentanteWW";
         /* GeneXus formulas. */
         AV69Pgmname = "RepresentanteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV72Representantewwds_3_dynamicfiltersoperator1 ;
      private short AV77Representantewwds_8_dynamicfiltersoperator2 ;
      private short AV82Representantewwds_13_dynamicfiltersoperator3 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV66ClienteId ;
      private int wcpOAV66ClienteId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int nGXsfl_119_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A978RepresentanteId ;
      private int A977RepresentanteProfissao ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV95Representantewwds_26_tfrepresentanteestadocivil_sels_Count ;
      private int AV102Representantewwds_33_tfrepresentantetipo_sels_Count ;
      private int edtRepresentanteId_Enabled ;
      private int edtRepresentanteNome_Enabled ;
      private int edtRepresentanteRG_Enabled ;
      private int edtRepresentanteOrgaoExpedidor_Enabled ;
      private int edtRepresentanteRGUF_Enabled ;
      private int edtRepresentanteCPF_Enabled ;
      private int edtRepresentanteNacionalidade_Enabled ;
      private int edtRepresentanteProfissaoDescricao_Enabled ;
      private int edtRepresentanteProfissao_Enabled ;
      private int edtRepresentanteEmail_Enabled ;
      private int edtClienteId_Enabled ;
      private int AV59PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavRepresentantenome1_Visible ;
      private int edtavRepresentantemunicipionome1_Visible ;
      private int edtavRepresentantenome2_Visible ;
      private int edtavRepresentantemunicipionome2_Visible ;
      private int edtavRepresentantenome3_Visible ;
      private int edtavRepresentantemunicipionome3_Visible ;
      private int AV103GXV1 ;
      private int edtavRepresentantenome3_Enabled ;
      private int edtavRepresentantemunicipionome3_Enabled ;
      private int edtavRepresentantenome2_Enabled ;
      private int edtavRepresentantemunicipionome2_Enabled ;
      private int edtavRepresentantenome1_Enabled ;
      private int edtavRepresentantemunicipionome1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV60GridCurrentPage ;
      private long AV61GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_119_idx="0001" ;
      private string AV69Pgmname ;
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
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV63Display ;
      private string edtavDisplay_Internalname ;
      private string AV64Update ;
      private string edtavUpdate_Internalname ;
      private string edtRepresentanteId_Internalname ;
      private string edtRepresentanteNome_Internalname ;
      private string edtRepresentanteRG_Internalname ;
      private string edtRepresentanteOrgaoExpedidor_Internalname ;
      private string edtRepresentanteRGUF_Internalname ;
      private string edtRepresentanteCPF_Internalname ;
      private string cmbRepresentanteEstadoCivil_Internalname ;
      private string edtRepresentanteNacionalidade_Internalname ;
      private string edtRepresentanteProfissaoDescricao_Internalname ;
      private string edtRepresentanteProfissao_Internalname ;
      private string edtRepresentanteEmail_Internalname ;
      private string cmbRepresentanteTipo_Internalname ;
      private string edtClienteId_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavRepresentantenome1_Internalname ;
      private string edtavRepresentantemunicipionome1_Internalname ;
      private string edtavRepresentantenome2_Internalname ;
      private string edtavRepresentantemunicipionome2_Internalname ;
      private string edtavRepresentantenome3_Internalname ;
      private string edtavRepresentantemunicipionome3_Internalname ;
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
      private string edtavDisplay_Link ;
      private string edtavUpdate_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_representantenome3_cell_Internalname ;
      private string edtavRepresentantenome3_Jsonclick ;
      private string cellFilter_representantemunicipionome3_cell_Internalname ;
      private string edtavRepresentantemunicipionome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_representantenome2_cell_Internalname ;
      private string edtavRepresentantenome2_Jsonclick ;
      private string cellFilter_representantemunicipionome2_cell_Internalname ;
      private string edtavRepresentantemunicipionome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_representantenome1_cell_Internalname ;
      private string edtavRepresentantenome1_Jsonclick ;
      private string cellFilter_representantemunicipionome1_cell_Internalname ;
      private string edtavRepresentantemunicipionome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtRepresentanteId_Jsonclick ;
      private string edtRepresentanteNome_Jsonclick ;
      private string edtRepresentanteRG_Jsonclick ;
      private string edtRepresentanteOrgaoExpedidor_Jsonclick ;
      private string edtRepresentanteRGUF_Jsonclick ;
      private string edtRepresentanteCPF_Jsonclick ;
      private string GXCCtl ;
      private string cmbRepresentanteEstadoCivil_Jsonclick ;
      private string edtRepresentanteNacionalidade_Jsonclick ;
      private string edtRepresentanteProfissaoDescricao_Jsonclick ;
      private string edtRepresentanteProfissao_Jsonclick ;
      private string edtRepresentanteEmail_Jsonclick ;
      private string cmbRepresentanteTipo_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
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
      private bool n979RepresentanteNome ;
      private bool n980RepresentanteRG ;
      private bool n981RepresentanteOrgaoExpedidor ;
      private bool n982RepresentanteRGUF ;
      private bool n983RepresentanteCPF ;
      private bool n984RepresentanteEstadoCivil ;
      private bool n985RepresentanteNacionalidade ;
      private bool n999RepresentanteProfissaoDescricao ;
      private bool n977RepresentanteProfissao ;
      private bool n986RepresentanteEmail ;
      private bool n998RepresentanteTipo ;
      private bool n168ClienteId ;
      private bool bGXsfl_119_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV75Representantewwds_6_dynamicfiltersenabled2 ;
      private bool AV80Representantewwds_11_dynamicfiltersenabled3 ;
      private bool n991RepresentanteMunicipio ;
      private bool n997RepresentanteMunicipioNome ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV48TFRepresentanteEstadoCivil_SelsJson ;
      private string AV56TFRepresentanteTipo_SelsJson ;
      private string AV36ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18RepresentanteNome1 ;
      private string AV19RepresentanteMunicipioNome1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23RepresentanteNome2 ;
      private string AV24RepresentanteMunicipioNome2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28RepresentanteNome3 ;
      private string AV29RepresentanteMunicipioNome3 ;
      private string AV38TFRepresentanteNome ;
      private string AV39TFRepresentanteNome_Sel ;
      private string AV40TFRepresentanteRG ;
      private string AV41TFRepresentanteRG_Sel ;
      private string AV42TFRepresentanteOrgaoExpedidor ;
      private string AV43TFRepresentanteOrgaoExpedidor_Sel ;
      private string AV44TFRepresentanteRGUF ;
      private string AV45TFRepresentanteRGUF_Sel ;
      private string AV46TFRepresentanteCPF ;
      private string AV47TFRepresentanteCPF_Sel ;
      private string AV50TFRepresentanteNacionalidade ;
      private string AV51TFRepresentanteNacionalidade_Sel ;
      private string AV67TFRepresentanteProfissaoDescricao ;
      private string AV68TFRepresentanteProfissaoDescricao_Sel ;
      private string AV54TFRepresentanteEmail ;
      private string AV55TFRepresentanteEmail_Sel ;
      private string AV62GridAppliedFilters ;
      private string A979RepresentanteNome ;
      private string A980RepresentanteRG ;
      private string A981RepresentanteOrgaoExpedidor ;
      private string A982RepresentanteRGUF ;
      private string A983RepresentanteCPF ;
      private string A984RepresentanteEstadoCivil ;
      private string A985RepresentanteNacionalidade ;
      private string A999RepresentanteProfissaoDescricao ;
      private string A986RepresentanteEmail ;
      private string A998RepresentanteTipo ;
      private string lV70Representantewwds_1_filterfulltext ;
      private string lV73Representantewwds_4_representantenome1 ;
      private string lV74Representantewwds_5_representantemunicipionome1 ;
      private string lV78Representantewwds_9_representantenome2 ;
      private string lV79Representantewwds_10_representantemunicipionome2 ;
      private string lV83Representantewwds_14_representantenome3 ;
      private string lV84Representantewwds_15_representantemunicipionome3 ;
      private string lV85Representantewwds_16_tfrepresentantenome ;
      private string lV87Representantewwds_18_tfrepresentanterg ;
      private string lV89Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string lV91Representantewwds_22_tfrepresentanterguf ;
      private string lV93Representantewwds_24_tfrepresentantecpf ;
      private string lV96Representantewwds_27_tfrepresentantenacionalidade ;
      private string lV98Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string lV100Representantewwds_31_tfrepresentanteemail ;
      private string AV70Representantewwds_1_filterfulltext ;
      private string AV71Representantewwds_2_dynamicfiltersselector1 ;
      private string AV73Representantewwds_4_representantenome1 ;
      private string AV74Representantewwds_5_representantemunicipionome1 ;
      private string AV76Representantewwds_7_dynamicfiltersselector2 ;
      private string AV78Representantewwds_9_representantenome2 ;
      private string AV79Representantewwds_10_representantemunicipionome2 ;
      private string AV81Representantewwds_12_dynamicfiltersselector3 ;
      private string AV83Representantewwds_14_representantenome3 ;
      private string AV84Representantewwds_15_representantemunicipionome3 ;
      private string AV86Representantewwds_17_tfrepresentantenome_sel ;
      private string AV85Representantewwds_16_tfrepresentantenome ;
      private string AV88Representantewwds_19_tfrepresentanterg_sel ;
      private string AV87Representantewwds_18_tfrepresentanterg ;
      private string AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ;
      private string AV89Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string AV92Representantewwds_23_tfrepresentanterguf_sel ;
      private string AV91Representantewwds_22_tfrepresentanterguf ;
      private string AV94Representantewwds_25_tfrepresentantecpf_sel ;
      private string AV93Representantewwds_24_tfrepresentantecpf ;
      private string AV97Representantewwds_28_tfrepresentantenacionalidade_sel ;
      private string AV96Representantewwds_27_tfrepresentantenacionalidade ;
      private string AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel ;
      private string AV98Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string AV101Representantewwds_32_tfrepresentanteemail_sel ;
      private string AV100Representantewwds_31_tfrepresentanteemail ;
      private string A997RepresentanteMunicipioNome ;
      private string A991RepresentanteMunicipio ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV65AuxText ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbRepresentanteEstadoCivil ;
      private GXCombobox cmbRepresentanteTipo ;
      private GxSimpleCollection<string> AV49TFRepresentanteEstadoCivil_Sels ;
      private GxSimpleCollection<string> AV57TFRepresentanteTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV58DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV95Representantewwds_26_tfrepresentanteestadocivil_sels ;
      private GxSimpleCollection<string> AV102Representantewwds_33_tfrepresentantetipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H009P2_A991RepresentanteMunicipio ;
      private bool[] H009P2_n991RepresentanteMunicipio ;
      private string[] H009P2_A997RepresentanteMunicipioNome ;
      private bool[] H009P2_n997RepresentanteMunicipioNome ;
      private int[] H009P2_A168ClienteId ;
      private bool[] H009P2_n168ClienteId ;
      private string[] H009P2_A998RepresentanteTipo ;
      private bool[] H009P2_n998RepresentanteTipo ;
      private string[] H009P2_A986RepresentanteEmail ;
      private bool[] H009P2_n986RepresentanteEmail ;
      private int[] H009P2_A977RepresentanteProfissao ;
      private bool[] H009P2_n977RepresentanteProfissao ;
      private string[] H009P2_A999RepresentanteProfissaoDescricao ;
      private bool[] H009P2_n999RepresentanteProfissaoDescricao ;
      private string[] H009P2_A985RepresentanteNacionalidade ;
      private bool[] H009P2_n985RepresentanteNacionalidade ;
      private string[] H009P2_A984RepresentanteEstadoCivil ;
      private bool[] H009P2_n984RepresentanteEstadoCivil ;
      private string[] H009P2_A983RepresentanteCPF ;
      private bool[] H009P2_n983RepresentanteCPF ;
      private string[] H009P2_A982RepresentanteRGUF ;
      private bool[] H009P2_n982RepresentanteRGUF ;
      private string[] H009P2_A981RepresentanteOrgaoExpedidor ;
      private bool[] H009P2_n981RepresentanteOrgaoExpedidor ;
      private string[] H009P2_A980RepresentanteRG ;
      private bool[] H009P2_n980RepresentanteRG ;
      private string[] H009P2_A979RepresentanteNome ;
      private bool[] H009P2_n979RepresentanteNome ;
      private int[] H009P2_A978RepresentanteId ;
      private long[] H009P3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class representanteww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009P2( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV95Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV102Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV70Representantewwds_1_filterfulltext ,
                                             string AV71Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV72Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV73Representantewwds_4_representantenome1 ,
                                             string AV74Representantewwds_5_representantemunicipionome1 ,
                                             bool AV75Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV76Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV77Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV78Representantewwds_9_representantenome2 ,
                                             string AV79Representantewwds_10_representantemunicipionome2 ,
                                             bool AV80Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV81Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV82Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV83Representantewwds_14_representantenome3 ,
                                             string AV84Representantewwds_15_representantemunicipionome3 ,
                                             string AV86Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV85Representantewwds_16_tfrepresentantenome ,
                                             string AV88Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV87Representantewwds_18_tfrepresentanterg ,
                                             string AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV89Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV92Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV91Representantewwds_22_tfrepresentanterguf ,
                                             string AV94Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV93Representantewwds_24_tfrepresentantecpf ,
                                             int AV95Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV97Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV96Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV98Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV101Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV100Representantewwds_31_tfrepresentanteemail ,
                                             int AV102Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A168ClienteId ,
                                             int AV66ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[48];
         Object[] GXv_Object14 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.RepresentanteMunicipio AS RepresentanteMunicipio, T2.MunicipioNome AS RepresentanteMunicipioNome, T1.ClienteId, T1.RepresentanteTipo, T1.RepresentanteEmail, T1.RepresentanteProfissao AS RepresentanteProfissao, T3.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId";
         sFromString = " FROM ((Representante T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.RepresentanteMunicipio) LEFT JOIN Profissao T3 ON T3.ProfissaoId = T1.RepresentanteProfissao)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.ClienteId = :AV66ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV70Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV70Representantewwds_1_filterfulltext) or ( T3.ProfissaoNome like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV70Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
            GXv_int13[11] = 1;
            GXv_int13[12] = 1;
            GXv_int13[13] = 1;
            GXv_int13[14] = 1;
            GXv_int13[15] = 1;
            GXv_int13[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV73Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV73Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV74Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV74Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV78Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV78Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV79Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV79Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV83Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV83Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV84Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV84Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV86Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV86Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int13[30] = 1;
         }
         if ( StringUtil.StrCmp(AV86Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV87Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int13[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV88Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int13[32] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV89Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int13[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int13[34] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV91Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int13[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV92Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int13[36] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV93Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int13[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV94Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int13[38] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV95Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV95Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV96Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int13[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV97Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV97Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int13[40] = 1;
         }
         if ( StringUtil.StrCmp(AV97Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome like :lV98Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int13[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome = ( :AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int13[42] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T3.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV100Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int13[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV101Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int13[44] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV102Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV102Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteNome, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteNome DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteRG, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteRG DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteOrgaoExpedidor, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteOrgaoExpedidor DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteRGUF, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteRGUF DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteCPF, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteCPF DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteEstadoCivil, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteEstadoCivil DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteNacionalidade, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteNacionalidade DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ProfissaoNome, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ProfissaoNome DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteEmail, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteEmail DESC, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.RepresentanteTipo, T1.RepresentanteId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.RepresentanteTipo DESC, T1.RepresentanteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.RepresentanteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H009P3( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV95Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV102Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV70Representantewwds_1_filterfulltext ,
                                             string AV71Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV72Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV73Representantewwds_4_representantenome1 ,
                                             string AV74Representantewwds_5_representantemunicipionome1 ,
                                             bool AV75Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV76Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV77Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV78Representantewwds_9_representantenome2 ,
                                             string AV79Representantewwds_10_representantemunicipionome2 ,
                                             bool AV80Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV81Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV82Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV83Representantewwds_14_representantenome3 ,
                                             string AV84Representantewwds_15_representantemunicipionome3 ,
                                             string AV86Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV85Representantewwds_16_tfrepresentantenome ,
                                             string AV88Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV87Representantewwds_18_tfrepresentanterg ,
                                             string AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV89Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV92Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV91Representantewwds_22_tfrepresentanterguf ,
                                             string AV94Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV93Representantewwds_24_tfrepresentantecpf ,
                                             int AV95Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV97Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV96Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV98Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV101Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV100Representantewwds_31_tfrepresentanteemail ,
                                             int AV102Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A168ClienteId ,
                                             int AV66ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[45];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Representante T1 LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio) LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV66ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV70Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV70Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV70Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV70Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV70Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
            GXv_int15[8] = 1;
            GXv_int15[9] = 1;
            GXv_int15[10] = 1;
            GXv_int15[11] = 1;
            GXv_int15[12] = 1;
            GXv_int15[13] = 1;
            GXv_int15[14] = 1;
            GXv_int15[15] = 1;
            GXv_int15[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV73Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV73Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV74Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV72Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV74Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV78Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV78Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV79Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( AV75Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV77Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV79Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV83Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV83Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV84Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int15[27] = 1;
         }
         if ( AV80Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV82Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV84Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int15[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV86Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV86Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int15[30] = 1;
         }
         if ( StringUtil.StrCmp(AV86Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV87Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int15[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV88Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int15[32] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV89Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int15[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int15[34] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV91Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int15[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV92Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int15[36] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV93Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int15[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV94Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int15[38] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV95Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV95Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV96Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int15[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV97Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV97Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int15[40] = 1;
         }
         if ( StringUtil.StrCmp(AV97Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV98Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int15[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int15[42] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV100Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int15[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV101Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int15[44] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV102Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV102Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
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
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009P2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
               case 1 :
                     return conditional_H009P3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
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
          Object[] prmH009P2;
          prmH009P2 = new Object[] {
          new ParDef("AV66ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV73Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV74Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV74Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV78Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV78Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV79Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV79Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV83Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV83Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV84Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV84Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV86Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV88Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV89Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV96Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV97Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV98Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV100Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV101Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009P3;
          prmH009P3 = new Object[] {
          new ParDef("AV66ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV73Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV74Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV74Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV78Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV78Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV79Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV79Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV83Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV83Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV84Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV84Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV86Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV88Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV89Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV96Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV97Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV98Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV99Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV100Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV101Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009P3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
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
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
