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
   public class propostaww : GXDataArea
   {
      public propostaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostaww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavDmusuariopendenteaprovacao = new GXCombobox();
         cmbPropostaStatus = new GXCombobox();
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
         nRC_GXsfl_143 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_143"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_143_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_143_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_143_idx = GetPar( "sGXsfl_143_idx");
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV109PropostaResponsavelDocumento1 = GetPar( "PropostaResponsavelDocumento1");
         AV110PropostaPacienteClienteDocumento1 = GetPar( "PropostaPacienteClienteDocumento1");
         AV111PropostaClinicaDocumento1 = GetPar( "PropostaClinicaDocumento1");
         AV112ConvenioCategoriaDescricao1 = GetPar( "ConvenioCategoriaDescricao1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV114PropostaResponsavelDocumento2 = GetPar( "PropostaResponsavelDocumento2");
         AV115PropostaPacienteClienteDocumento2 = GetPar( "PropostaPacienteClienteDocumento2");
         AV116PropostaClinicaDocumento2 = GetPar( "PropostaClinicaDocumento2");
         AV117ConvenioCategoriaDescricao2 = GetPar( "ConvenioCategoriaDescricao2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV119PropostaResponsavelDocumento3 = GetPar( "PropostaResponsavelDocumento3");
         AV120PropostaPacienteClienteDocumento3 = GetPar( "PropostaPacienteClienteDocumento3");
         AV121PropostaClinicaDocumento3 = GetPar( "PropostaClinicaDocumento3");
         AV122ConvenioCategoriaDescricao3 = GetPar( "ConvenioCategoriaDescricao3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV123Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV108PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F1"), "."), 18, MidpointRounding.ToEven));
         AV113PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F2"), "."), 18, MidpointRounding.ToEven));
         AV118PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F3"), "."), 18, MidpointRounding.ToEven));
         AV99TFPropostaClinicaNome = GetPar( "TFPropostaClinicaNome");
         AV100TFPropostaClinicaNome_Sel = GetPar( "TFPropostaClinicaNome_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV51TFPropostaStatus_Sels);
         AV101TFPropostaPacienteClienteRazaoSocial = GetPar( "TFPropostaPacienteClienteRazaoSocial");
         AV102TFPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFPropostaPacienteClienteRazaoSocial_Sel");
         AV103TFPropostaMaiorScore_F = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPropostaMaiorScore_F"), "."), 18, MidpointRounding.ToEven));
         AV104TFPropostaMaiorScore_F_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPropostaMaiorScore_F_To"), "."), 18, MidpointRounding.ToEven));
         AV105TFPropostaMaiorValorRecomendado = NumberUtil.Val( GetPar( "TFPropostaMaiorValorRecomendado"), ".");
         AV106TFPropostaMaiorValorRecomendado_To = NumberUtil.Val( GetPar( "TFPropostaMaiorValorRecomendado_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV86Context);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
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
         PA522( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START522( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostaww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV86Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV86Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV86Context, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO1", AV109PropostaResponsavelDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1", AV110PropostaPacienteClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO1", AV111PropostaClinicaDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO1", AV112ConvenioCategoriaDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO2", AV114PropostaResponsavelDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2", AV115PropostaPacienteClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO2", AV116PropostaClinicaDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO2", AV117ConvenioCategoriaDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO3", AV119PropostaResponsavelDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3", AV120PropostaPacienteClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO3", AV121PropostaClinicaDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO3", AV122ConvenioCategoriaDescricao3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_143", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_143), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV60GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTACLINICANOME", AV99TFPropostaClinicaNome);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTACLINICANOME_SEL", AV100TFPropostaClinicaNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV101TFPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV102TFPropostaPacienteClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAMAIORSCORE_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAMAIORSCORE_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAMAIORVALORRECOMENDADO", StringUtil.LTrim( StringUtil.NToC( AV105TFPropostaMaiorValorRecomendado, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAMAIORVALORRECOMENDADO_TO", StringUtil.LTrim( StringUtil.NToC( AV106TFPropostaMaiorValorRecomendado_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV86Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV86Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV86Context, context));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASTATUS_SELSJSON", AV50TFPropostaStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE522( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT522( ) ;
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
         return formatLink("propostaww")  ;
      }

      public override string GetPgmname( )
      {
         return "PropostaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Proposta" ;
      }

      protected void WB520( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(143), 3, 0)+","+"null"+");", "Nova Proposta", bttBtnuseraction1_Jsonclick, 5, "Nova Proposta", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(143), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PropostaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_522( true) ;
         }
         else
         {
            wb_table1_45_522( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_522e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_79_522( true) ;
         }
         else
         {
            wb_table2_79_522( false) ;
         }
         return  ;
      }

      protected void wb_table2_79_522e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_113_522( true) ;
         }
         else
         {
            wb_table3_113_522( false) ;
         }
         return  ;
      }

      protected void wb_table3_113_522e( bool wbgen )
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
            StartGridControl143( ) ;
         }
         if ( wbEnd == 143 )
         {
            wbEnd = 0;
            nRC_GXsfl_143 = (int)(nGXsfl_143_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV58GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV59GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV60GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_PropostaWW.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV56DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
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
         if ( wbEnd == 143 )
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

      protected void START522( )
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
         Form.Meta.addItem("description", " Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP520( ) ;
      }

      protected void WS522( )
      {
         START522( ) ;
         EVT522( ) ;
      }

      protected void EVT522( )
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
                              E11522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E18522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E19522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E20522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E22522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24522 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VAPROVACOES.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VAPROVACOES.CLICK") == 0 ) )
                           {
                              nGXsfl_143_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
                              SubsflControlProps_1432( ) ;
                              AV98Editar = cgiGet( edtavEditar_Internalname);
                              AssignAttri("", false, edtavEditar_Internalname, AV98Editar);
                              AV94Consultar = cgiGet( edtavConsultar_Internalname);
                              AssignAttri("", false, edtavConsultar_Internalname, AV94Consultar);
                              AV96Aprovacoes = cgiGet( edtavAprovacoes_Internalname);
                              AssignAttri("", false, edtavAprovacoes_Internalname, AV96Aprovacoes);
                              AV97Reembolso = cgiGet( edtavReembolso_Internalname);
                              AssignAttri("", false, edtavReembolso_Internalname, AV97Reembolso);
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A643PropostaClinicaNome = StringUtil.Upper( cgiGet( edtPropostaClinicaNome_Internalname));
                              n643PropostaClinicaNome = false;
                              A377ProcedimentosMedicosNome = cgiGet( edtProcedimentosMedicosNome_Internalname);
                              n377ProcedimentosMedicosNome = false;
                              cmbavDmusuariopendenteaprovacao.Name = cmbavDmusuariopendenteaprovacao_Internalname;
                              cmbavDmusuariopendenteaprovacao.CurrentValue = cgiGet( cmbavDmusuariopendenteaprovacao_Internalname);
                              AV107DmUsuarioPendenteAprovacao = cgiGet( cmbavDmusuariopendenteaprovacao_Internalname);
                              AssignAttri("", false, cmbavDmusuariopendenteaprovacao_Internalname, AV107DmUsuarioPendenteAprovacao);
                              cmbPropostaStatus.Name = cmbPropostaStatus_Internalname;
                              cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
                              A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
                              n329PropostaStatus = false;
                              A649PropostaMaxReembolsoId_F = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaMaxReembolsoId_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n649PropostaMaxReembolsoId_F = false;
                              A505PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtPropostaPacienteClienteRazaoSocial_Internalname));
                              n505PropostaPacienteClienteRazaoSocial = false;
                              A655PropostaQtdDocumentoPendente_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQtdDocumentoPendente_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n655PropostaQtdDocumentoPendente_F = false;
                              A784PropostaMaiorScore_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaMaiorScore_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n784PropostaMaiorScore_F = false;
                              A788PropostaMaiorValorRecomendado = context.localUtil.CToN( cgiGet( edtPropostaMaiorValorRecomendado_Internalname), ",", ".");
                              n788PropostaMaiorValorRecomendado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E25522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E26522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E27522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VAPROVACOES.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28522 ();
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
                                       /* Set Refresh If Propostaresponsaveldocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV109PropostaResponsavelDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV110PropostaPacienteClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV111PropostaClinicaDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV112ConvenioCategoriaDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV114PropostaResponsavelDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV115PropostaPacienteClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV116PropostaClinicaDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV117ConvenioCategoriaDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV119PropostaResponsavelDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV120PropostaPacienteClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV121PropostaClinicaDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV122ConvenioCategoriaDescricao3) != 0 )
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

      protected void WE522( )
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

      protected void PA522( )
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
         SubsflControlProps_1432( ) ;
         while ( nGXsfl_143_idx <= nRC_GXsfl_143 )
         {
            sendrow_1432( ) ;
            nGXsfl_143_idx = ((subGrid_Islastpage==1)&&(nGXsfl_143_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
            SubsflControlProps_1432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV109PropostaResponsavelDocumento1 ,
                                       string AV110PropostaPacienteClienteDocumento1 ,
                                       string AV111PropostaClinicaDocumento1 ,
                                       string AV112ConvenioCategoriaDescricao1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV114PropostaResponsavelDocumento2 ,
                                       string AV115PropostaPacienteClienteDocumento2 ,
                                       string AV116PropostaClinicaDocumento2 ,
                                       string AV117ConvenioCategoriaDescricao2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV119PropostaResponsavelDocumento3 ,
                                       string AV120PropostaPacienteClienteDocumento3 ,
                                       string AV121PropostaClinicaDocumento3 ,
                                       string AV122ConvenioCategoriaDescricao3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV123Pgmname ,
                                       string AV15FilterFullText ,
                                       int AV108PropostaMaxReembolsoId_F1 ,
                                       int AV113PropostaMaxReembolsoId_F2 ,
                                       int AV118PropostaMaxReembolsoId_F3 ,
                                       string AV99TFPropostaClinicaNome ,
                                       string AV100TFPropostaClinicaNome_Sel ,
                                       GxSimpleCollection<string> AV51TFPropostaStatus_Sels ,
                                       string AV101TFPropostaPacienteClienteRazaoSocial ,
                                       string AV102TFPropostaPacienteClienteRazaoSocial_Sel ,
                                       short AV103TFPropostaMaiorScore_F ,
                                       short AV104TFPropostaMaiorScore_F_To ,
                                       decimal AV105TFPropostaMaiorValorRecomendado ,
                                       decimal AV106TFPropostaMaiorValorRecomendado_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV86Context )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF522( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", "")));
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
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF522( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV123Pgmname = "PropostaWW";
         edtavEditar_Enabled = 0;
         edtavConsultar_Enabled = 0;
         edtavAprovacoes_Enabled = 0;
         edtavReembolso_Enabled = 0;
         cmbavDmusuariopendenteaprovacao.Enabled = 0;
      }

      protected void RF522( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 143;
         /* Execute user event: Refresh */
         E26522 ();
         nGXsfl_143_idx = 1;
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
         SubsflControlProps_1432( ) ;
         bGXsfl_143_Refreshing = true;
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
            SubsflControlProps_1432( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A329PropostaStatus ,
                                                 AV150Propostawwds_27_tfpropostastatus_sels ,
                                                 AV125Propostawwds_2_dynamicfiltersselector1 ,
                                                 AV126Propostawwds_3_dynamicfiltersoperator1 ,
                                                 AV128Propostawwds_5_propostaresponsaveldocumento1 ,
                                                 AV129Propostawwds_6_propostapacienteclientedocumento1 ,
                                                 AV130Propostawwds_7_propostaclinicadocumento1 ,
                                                 AV131Propostawwds_8_conveniocategoriadescricao1 ,
                                                 AV132Propostawwds_9_dynamicfiltersenabled2 ,
                                                 AV133Propostawwds_10_dynamicfiltersselector2 ,
                                                 AV134Propostawwds_11_dynamicfiltersoperator2 ,
                                                 AV136Propostawwds_13_propostaresponsaveldocumento2 ,
                                                 AV137Propostawwds_14_propostapacienteclientedocumento2 ,
                                                 AV138Propostawwds_15_propostaclinicadocumento2 ,
                                                 AV139Propostawwds_16_conveniocategoriadescricao2 ,
                                                 AV140Propostawwds_17_dynamicfiltersenabled3 ,
                                                 AV141Propostawwds_18_dynamicfiltersselector3 ,
                                                 AV142Propostawwds_19_dynamicfiltersoperator3 ,
                                                 AV144Propostawwds_21_propostaresponsaveldocumento3 ,
                                                 AV145Propostawwds_22_propostapacienteclientedocumento3 ,
                                                 AV146Propostawwds_23_propostaclinicadocumento3 ,
                                                 AV147Propostawwds_24_conveniocategoriadescricao3 ,
                                                 AV149Propostawwds_26_tfpropostaclinicanome_sel ,
                                                 AV148Propostawwds_25_tfpropostaclinicanome ,
                                                 AV150Propostawwds_27_tfpropostastatus_sels.Count ,
                                                 AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                                 AV151Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                                 AV6WWPContext.gxTpr_Iscliente ,
                                                 A580PropostaResponsavelDocumento ,
                                                 A540PropostaPacienteClienteDocumento ,
                                                 A652PropostaClinicaDocumento ,
                                                 A494ConvenioCategoriaDescricao ,
                                                 A643PropostaClinicaNome ,
                                                 A505PropostaPacienteClienteRazaoSocial ,
                                                 A328PropostaCratedBy ,
                                                 AV6WWPContext.gxTpr_Secuserclienteid ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV124Propostawwds_1_filterfulltext ,
                                                 A784PropostaMaiorScore_F ,
                                                 A788PropostaMaiorValorRecomendado ,
                                                 AV127Propostawwds_4_propostamaxreembolsoid_f1 ,
                                                 A649PropostaMaxReembolsoId_F ,
                                                 AV135Propostawwds_12_propostamaxreembolsoid_f2 ,
                                                 AV143Propostawwds_20_propostamaxreembolsoid_f3 ,
                                                 AV153Propostawwds_30_tfpropostamaiorscore_f ,
                                                 AV154Propostawwds_31_tfpropostamaiorscore_f_to ,
                                                 AV155Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                                 AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                                 }
            });
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
            lV128Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1), "%", "");
            lV128Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1), "%", "");
            lV129Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1), "%", "");
            lV129Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1), "%", "");
            lV130Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1), "%", "");
            lV130Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1), "%", "");
            lV131Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1), "%", "");
            lV131Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1), "%", "");
            lV136Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2), "%", "");
            lV136Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2), "%", "");
            lV137Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2), "%", "");
            lV137Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2), "%", "");
            lV138Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2), "%", "");
            lV138Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2), "%", "");
            lV139Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2), "%", "");
            lV139Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2), "%", "");
            lV144Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3), "%", "");
            lV144Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3), "%", "");
            lV145Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3), "%", "");
            lV145Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3), "%", "");
            lV146Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3), "%", "");
            lV146Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3), "%", "");
            lV147Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3), "%", "");
            lV147Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3), "%", "");
            lV148Propostawwds_25_tfpropostaclinicanome = StringUtil.Concat( StringUtil.RTrim( AV148Propostawwds_25_tfpropostaclinicanome), "%", "");
            lV151Propostawwds_28_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV151Propostawwds_28_tfpropostapacienteclienterazaosocial), "%", "");
            /* Using cursor H005214 */
            pr_default.execute(0, new Object[] {AV86Context.gxTpr_Userid, AV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV153Propostawwds_30_tfpropostamaiorscore_f, AV153Propostawwds_30_tfpropostamaiorscore_f, AV154Propostawwds_31_tfpropostamaiorscore_f_to, AV154Propostawwds_31_tfpropostamaiorscore_f_to, AV155Propostawwds_32_tfpropostamaiorvalorrecomendado, AV155Propostawwds_32_tfpropostamaiorvalorrecomendado, AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to, AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to, lV128Propostawwds_5_propostaresponsaveldocumento1, lV128Propostawwds_5_propostaresponsaveldocumento1, lV129Propostawwds_6_propostapacienteclientedocumento1, lV129Propostawwds_6_propostapacienteclientedocumento1, lV130Propostawwds_7_propostaclinicadocumento1, lV130Propostawwds_7_propostaclinicadocumento1, lV131Propostawwds_8_conveniocategoriadescricao1, lV131Propostawwds_8_conveniocategoriadescricao1, lV136Propostawwds_13_propostaresponsaveldocumento2, lV136Propostawwds_13_propostaresponsaveldocumento2, lV137Propostawwds_14_propostapacienteclientedocumento2, lV137Propostawwds_14_propostapacienteclientedocumento2, lV138Propostawwds_15_propostaclinicadocumento2, lV138Propostawwds_15_propostaclinicadocumento2, lV139Propostawwds_16_conveniocategoriadescricao2, lV139Propostawwds_16_conveniocategoriadescricao2, lV144Propostawwds_21_propostaresponsaveldocumento3, lV144Propostawwds_21_propostaresponsaveldocumento3, lV145Propostawwds_22_propostapacienteclientedocumento3, lV145Propostawwds_22_propostapacienteclientedocumento3, lV146Propostawwds_23_propostaclinicadocumento3, lV146Propostawwds_23_propostaclinicadocumento3, lV147Propostawwds_24_conveniocategoriadescricao3, lV147Propostawwds_24_conveniocategoriadescricao3, lV148Propostawwds_25_tfpropostaclinicanome, AV149Propostawwds_26_tfpropostaclinicanome_sel, lV151Propostawwds_28_tfpropostapacienteclienterazaosocial, AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, AV6WWPContext.gxTpr_Secuserclienteid, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_143_idx = 1;
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
            SubsflControlProps_1432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A376ProcedimentosMedicosId = H005214_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = H005214_n376ProcedimentosMedicosId[0];
               A493ConvenioCategoriaId = H005214_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = H005214_n493ConvenioCategoriaId[0];
               A504PropostaPacienteClienteId = H005214_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H005214_n504PropostaPacienteClienteId[0];
               A553PropostaResponsavelId = H005214_A553PropostaResponsavelId[0];
               n553PropostaResponsavelId = H005214_n553PropostaResponsavelId[0];
               A642PropostaClinicaId = H005214_A642PropostaClinicaId[0];
               n642PropostaClinicaId = H005214_n642PropostaClinicaId[0];
               A328PropostaCratedBy = H005214_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H005214_n328PropostaCratedBy[0];
               A494ConvenioCategoriaDescricao = H005214_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H005214_n494ConvenioCategoriaDescricao[0];
               A652PropostaClinicaDocumento = H005214_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H005214_n652PropostaClinicaDocumento[0];
               A540PropostaPacienteClienteDocumento = H005214_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H005214_n540PropostaPacienteClienteDocumento[0];
               A580PropostaResponsavelDocumento = H005214_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H005214_n580PropostaResponsavelDocumento[0];
               A505PropostaPacienteClienteRazaoSocial = H005214_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H005214_n505PropostaPacienteClienteRazaoSocial[0];
               A329PropostaStatus = H005214_A329PropostaStatus[0];
               n329PropostaStatus = H005214_n329PropostaStatus[0];
               A377ProcedimentosMedicosNome = H005214_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H005214_n377ProcedimentosMedicosNome[0];
               A643PropostaClinicaNome = H005214_A643PropostaClinicaNome[0];
               n643PropostaClinicaNome = H005214_n643PropostaClinicaNome[0];
               A788PropostaMaiorValorRecomendado = H005214_A788PropostaMaiorValorRecomendado[0];
               n788PropostaMaiorValorRecomendado = H005214_n788PropostaMaiorValorRecomendado[0];
               A784PropostaMaiorScore_F = H005214_A784PropostaMaiorScore_F[0];
               n784PropostaMaiorScore_F = H005214_n784PropostaMaiorScore_F[0];
               A655PropostaQtdDocumentoPendente_F = H005214_A655PropostaQtdDocumentoPendente_F[0];
               n655PropostaQtdDocumentoPendente_F = H005214_n655PropostaQtdDocumentoPendente_F[0];
               A323PropostaId = H005214_A323PropostaId[0];
               n323PropostaId = H005214_n323PropostaId[0];
               A649PropostaMaxReembolsoId_F = H005214_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H005214_n649PropostaMaxReembolsoId_F[0];
               A40000GXC1 = H005214_A40000GXC1[0];
               n40000GXC1 = H005214_n40000GXC1[0];
               A377ProcedimentosMedicosNome = H005214_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H005214_n377ProcedimentosMedicosNome[0];
               A494ConvenioCategoriaDescricao = H005214_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H005214_n494ConvenioCategoriaDescricao[0];
               A540PropostaPacienteClienteDocumento = H005214_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H005214_n540PropostaPacienteClienteDocumento[0];
               A505PropostaPacienteClienteRazaoSocial = H005214_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H005214_n505PropostaPacienteClienteRazaoSocial[0];
               A580PropostaResponsavelDocumento = H005214_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H005214_n580PropostaResponsavelDocumento[0];
               A652PropostaClinicaDocumento = H005214_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H005214_n652PropostaClinicaDocumento[0];
               A643PropostaClinicaNome = H005214_A643PropostaClinicaNome[0];
               n643PropostaClinicaNome = H005214_n643PropostaClinicaNome[0];
               A788PropostaMaiorValorRecomendado = H005214_A788PropostaMaiorValorRecomendado[0];
               n788PropostaMaiorValorRecomendado = H005214_n788PropostaMaiorValorRecomendado[0];
               A784PropostaMaiorScore_F = H005214_A784PropostaMaiorScore_F[0];
               n784PropostaMaiorScore_F = H005214_n784PropostaMaiorScore_F[0];
               A655PropostaQtdDocumentoPendente_F = H005214_A655PropostaQtdDocumentoPendente_F[0];
               n655PropostaQtdDocumentoPendente_F = H005214_n655PropostaQtdDocumentoPendente_F[0];
               A649PropostaMaxReembolsoId_F = H005214_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H005214_n649PropostaMaxReembolsoId_F[0];
               A40000GXC1 = H005214_A40000GXC1[0];
               n40000GXC1 = H005214_n40000GXC1[0];
               /* Execute user event: Grid.Load */
               E27522 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 143;
            WB520( ) ;
         }
         bGXsfl_143_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes522( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV86Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV86Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV86Context, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROPOSTAID"+"_"+sGXsfl_143_idx, GetSecureSignedToken( sGXsfl_143_idx, context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"), context));
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
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV150Propostawwds_27_tfpropostastatus_sels ,
                                              AV125Propostawwds_2_dynamicfiltersselector1 ,
                                              AV126Propostawwds_3_dynamicfiltersoperator1 ,
                                              AV128Propostawwds_5_propostaresponsaveldocumento1 ,
                                              AV129Propostawwds_6_propostapacienteclientedocumento1 ,
                                              AV130Propostawwds_7_propostaclinicadocumento1 ,
                                              AV131Propostawwds_8_conveniocategoriadescricao1 ,
                                              AV132Propostawwds_9_dynamicfiltersenabled2 ,
                                              AV133Propostawwds_10_dynamicfiltersselector2 ,
                                              AV134Propostawwds_11_dynamicfiltersoperator2 ,
                                              AV136Propostawwds_13_propostaresponsaveldocumento2 ,
                                              AV137Propostawwds_14_propostapacienteclientedocumento2 ,
                                              AV138Propostawwds_15_propostaclinicadocumento2 ,
                                              AV139Propostawwds_16_conveniocategoriadescricao2 ,
                                              AV140Propostawwds_17_dynamicfiltersenabled3 ,
                                              AV141Propostawwds_18_dynamicfiltersselector3 ,
                                              AV142Propostawwds_19_dynamicfiltersoperator3 ,
                                              AV144Propostawwds_21_propostaresponsaveldocumento3 ,
                                              AV145Propostawwds_22_propostapacienteclientedocumento3 ,
                                              AV146Propostawwds_23_propostaclinicadocumento3 ,
                                              AV147Propostawwds_24_conveniocategoriadescricao3 ,
                                              AV149Propostawwds_26_tfpropostaclinicanome_sel ,
                                              AV148Propostawwds_25_tfpropostaclinicanome ,
                                              AV150Propostawwds_27_tfpropostastatus_sels.Count ,
                                              AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              AV151Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              AV6WWPContext.gxTpr_Iscliente ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A494ConvenioCategoriaDescricao ,
                                              A643PropostaClinicaNome ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A328PropostaCratedBy ,
                                              AV6WWPContext.gxTpr_Secuserclienteid ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV124Propostawwds_1_filterfulltext ,
                                              A784PropostaMaiorScore_F ,
                                              A788PropostaMaiorValorRecomendado ,
                                              AV127Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV135Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              AV143Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              AV153Propostawwds_30_tfpropostamaiorscore_f ,
                                              AV154Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              AV155Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV124Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_1_filterfulltext), "%", "");
         lV128Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV128Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV129Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV129Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV130Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV130Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV131Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV131Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV136Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV136Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV137Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV137Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV138Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV138Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV139Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV139Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV144Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV144Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV145Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV145Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV146Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV146Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV147Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV147Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV148Propostawwds_25_tfpropostaclinicanome = StringUtil.Concat( StringUtil.RTrim( AV148Propostawwds_25_tfpropostaclinicanome), "%", "");
         lV151Propostawwds_28_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV151Propostawwds_28_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor H005227 */
         pr_default.execute(1, new Object[] {AV86Context.gxTpr_Userid, AV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, lV124Propostawwds_1_filterfulltext, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV125Propostawwds_2_dynamicfiltersselector1, AV126Propostawwds_3_dynamicfiltersoperator1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV127Propostawwds_4_propostamaxreembolsoid_f1, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV132Propostawwds_9_dynamicfiltersenabled2, AV133Propostawwds_10_dynamicfiltersselector2, AV134Propostawwds_11_dynamicfiltersoperator2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV135Propostawwds_12_propostamaxreembolsoid_f2, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV140Propostawwds_17_dynamicfiltersenabled3, AV141Propostawwds_18_dynamicfiltersselector3, AV142Propostawwds_19_dynamicfiltersoperator3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV143Propostawwds_20_propostamaxreembolsoid_f3, AV153Propostawwds_30_tfpropostamaiorscore_f, AV153Propostawwds_30_tfpropostamaiorscore_f, AV154Propostawwds_31_tfpropostamaiorscore_f_to, AV154Propostawwds_31_tfpropostamaiorscore_f_to, AV155Propostawwds_32_tfpropostamaiorvalorrecomendado, AV155Propostawwds_32_tfpropostamaiorvalorrecomendado, AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to, AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to, lV128Propostawwds_5_propostaresponsaveldocumento1, lV128Propostawwds_5_propostaresponsaveldocumento1, lV129Propostawwds_6_propostapacienteclientedocumento1, lV129Propostawwds_6_propostapacienteclientedocumento1, lV130Propostawwds_7_propostaclinicadocumento1, lV130Propostawwds_7_propostaclinicadocumento1, lV131Propostawwds_8_conveniocategoriadescricao1, lV131Propostawwds_8_conveniocategoriadescricao1, lV136Propostawwds_13_propostaresponsaveldocumento2, lV136Propostawwds_13_propostaresponsaveldocumento2, lV137Propostawwds_14_propostapacienteclientedocumento2, lV137Propostawwds_14_propostapacienteclientedocumento2, lV138Propostawwds_15_propostaclinicadocumento2, lV138Propostawwds_15_propostaclinicadocumento2, lV139Propostawwds_16_conveniocategoriadescricao2, lV139Propostawwds_16_conveniocategoriadescricao2, lV144Propostawwds_21_propostaresponsaveldocumento3, lV144Propostawwds_21_propostaresponsaveldocumento3, lV145Propostawwds_22_propostapacienteclientedocumento3, lV145Propostawwds_22_propostapacienteclientedocumento3, lV146Propostawwds_23_propostaclinicadocumento3, lV146Propostawwds_23_propostaclinicadocumento3, lV147Propostawwds_24_conveniocategoriadescricao3, lV147Propostawwds_24_conveniocategoriadescricao3, lV148Propostawwds_25_tfpropostaclinicanome, AV149Propostawwds_26_tfpropostaclinicanome_sel, lV151Propostawwds_28_tfpropostapacienteclienterazaosocial, AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, AV6WWPContext.gxTpr_Secuserclienteid});
         GRID_nRecordCount = H005227_AGRID_nRecordCount[0];
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
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV123Pgmname = "PropostaWW";
         edtavEditar_Enabled = 0;
         edtavConsultar_Enabled = 0;
         edtavAprovacoes_Enabled = 0;
         edtavReembolso_Enabled = 0;
         cmbavDmusuariopendenteaprovacao.Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtPropostaClinicaNome_Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtPropostaMaxReembolsoId_F_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaQtdDocumentoPendente_F_Enabled = 0;
         edtPropostaMaiorScore_F_Enabled = 0;
         edtPropostaMaiorValorRecomendado_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP520( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E25522 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV56DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_143 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_143"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV59GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV60GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F1");
               GX_FocusControl = edtavPropostamaxreembolsoid_f1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV108PropostaMaxReembolsoId_F1 = 0;
               AssignAttri("", false, "AV108PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0));
            }
            else
            {
               AV108PropostaMaxReembolsoId_F1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV108PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0));
            }
            AV109PropostaResponsavelDocumento1 = cgiGet( edtavPropostaresponsaveldocumento1_Internalname);
            AssignAttri("", false, "AV109PropostaResponsavelDocumento1", AV109PropostaResponsavelDocumento1);
            AV110PropostaPacienteClienteDocumento1 = cgiGet( edtavPropostapacienteclientedocumento1_Internalname);
            AssignAttri("", false, "AV110PropostaPacienteClienteDocumento1", AV110PropostaPacienteClienteDocumento1);
            AV111PropostaClinicaDocumento1 = cgiGet( edtavPropostaclinicadocumento1_Internalname);
            AssignAttri("", false, "AV111PropostaClinicaDocumento1", AV111PropostaClinicaDocumento1);
            AV112ConvenioCategoriaDescricao1 = cgiGet( edtavConveniocategoriadescricao1_Internalname);
            AssignAttri("", false, "AV112ConvenioCategoriaDescricao1", AV112ConvenioCategoriaDescricao1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F2");
               GX_FocusControl = edtavPropostamaxreembolsoid_f2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV113PropostaMaxReembolsoId_F2 = 0;
               AssignAttri("", false, "AV113PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0));
            }
            else
            {
               AV113PropostaMaxReembolsoId_F2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV113PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0));
            }
            AV114PropostaResponsavelDocumento2 = cgiGet( edtavPropostaresponsaveldocumento2_Internalname);
            AssignAttri("", false, "AV114PropostaResponsavelDocumento2", AV114PropostaResponsavelDocumento2);
            AV115PropostaPacienteClienteDocumento2 = cgiGet( edtavPropostapacienteclientedocumento2_Internalname);
            AssignAttri("", false, "AV115PropostaPacienteClienteDocumento2", AV115PropostaPacienteClienteDocumento2);
            AV116PropostaClinicaDocumento2 = cgiGet( edtavPropostaclinicadocumento2_Internalname);
            AssignAttri("", false, "AV116PropostaClinicaDocumento2", AV116PropostaClinicaDocumento2);
            AV117ConvenioCategoriaDescricao2 = cgiGet( edtavConveniocategoriadescricao2_Internalname);
            AssignAttri("", false, "AV117ConvenioCategoriaDescricao2", AV117ConvenioCategoriaDescricao2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F3");
               GX_FocusControl = edtavPropostamaxreembolsoid_f3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV118PropostaMaxReembolsoId_F3 = 0;
               AssignAttri("", false, "AV118PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0));
            }
            else
            {
               AV118PropostaMaxReembolsoId_F3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV118PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0));
            }
            AV119PropostaResponsavelDocumento3 = cgiGet( edtavPropostaresponsaveldocumento3_Internalname);
            AssignAttri("", false, "AV119PropostaResponsavelDocumento3", AV119PropostaResponsavelDocumento3);
            AV120PropostaPacienteClienteDocumento3 = cgiGet( edtavPropostapacienteclientedocumento3_Internalname);
            AssignAttri("", false, "AV120PropostaPacienteClienteDocumento3", AV120PropostaPacienteClienteDocumento3);
            AV121PropostaClinicaDocumento3 = cgiGet( edtavPropostaclinicadocumento3_Internalname);
            AssignAttri("", false, "AV121PropostaClinicaDocumento3", AV121PropostaClinicaDocumento3);
            AV122ConvenioCategoriaDescricao3 = cgiGet( edtavConveniocategoriadescricao3_Internalname);
            AssignAttri("", false, "AV122ConvenioCategoriaDescricao3", AV122ConvenioCategoriaDescricao3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV109PropostaResponsavelDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV110PropostaPacienteClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV111PropostaClinicaDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV112ConvenioCategoriaDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV114PropostaResponsavelDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV115PropostaPacienteClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV116PropostaClinicaDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV117ConvenioCategoriaDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV119PropostaResponsavelDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV120PropostaPacienteClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV121PropostaClinicaDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV122ConvenioCategoriaDescricao3) != 0 )
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
         E25522 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E25522( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV86Context;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV86Context = GXt_SdtWWPContext1;
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
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
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
         Form.Caption = " Proposta";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV56DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV56DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E26522( )
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
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV23DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         AV58GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV58GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV58GridCurrentPage), 10, 0));
         AV59GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV59GridPageCount", StringUtil.LTrimStr( (decimal)(AV59GridPageCount), 10, 0));
         GXt_char3 = AV60GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV123Pgmname, out  GXt_char3) ;
         AV60GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV60GridAppliedFilters", AV60GridAppliedFilters);
         cmbavDmusuariopendenteaprovacao_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavDmusuariopendenteaprovacao_Internalname, "Columnheaderclass", cmbavDmusuariopendenteaprovacao_Columnheaderclass, !bGXsfl_143_Refreshing);
         cmbPropostaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbPropostaStatus_Internalname, "Columnheaderclass", cmbPropostaStatus_Columnheaderclass, !bGXsfl_143_Refreshing);
         AV124Propostawwds_1_filterfulltext = AV15FilterFullText;
         AV125Propostawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV126Propostawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV127Propostawwds_4_propostamaxreembolsoid_f1 = AV108PropostaMaxReembolsoId_F1;
         AV128Propostawwds_5_propostaresponsaveldocumento1 = AV109PropostaResponsavelDocumento1;
         AV129Propostawwds_6_propostapacienteclientedocumento1 = AV110PropostaPacienteClienteDocumento1;
         AV130Propostawwds_7_propostaclinicadocumento1 = AV111PropostaClinicaDocumento1;
         AV131Propostawwds_8_conveniocategoriadescricao1 = AV112ConvenioCategoriaDescricao1;
         AV132Propostawwds_9_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV133Propostawwds_10_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV134Propostawwds_11_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV135Propostawwds_12_propostamaxreembolsoid_f2 = AV113PropostaMaxReembolsoId_F2;
         AV136Propostawwds_13_propostaresponsaveldocumento2 = AV114PropostaResponsavelDocumento2;
         AV137Propostawwds_14_propostapacienteclientedocumento2 = AV115PropostaPacienteClienteDocumento2;
         AV138Propostawwds_15_propostaclinicadocumento2 = AV116PropostaClinicaDocumento2;
         AV139Propostawwds_16_conveniocategoriadescricao2 = AV117ConvenioCategoriaDescricao2;
         AV140Propostawwds_17_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV141Propostawwds_18_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV142Propostawwds_19_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV143Propostawwds_20_propostamaxreembolsoid_f3 = AV118PropostaMaxReembolsoId_F3;
         AV144Propostawwds_21_propostaresponsaveldocumento3 = AV119PropostaResponsavelDocumento3;
         AV145Propostawwds_22_propostapacienteclientedocumento3 = AV120PropostaPacienteClienteDocumento3;
         AV146Propostawwds_23_propostaclinicadocumento3 = AV121PropostaClinicaDocumento3;
         AV147Propostawwds_24_conveniocategoriadescricao3 = AV122ConvenioCategoriaDescricao3;
         AV148Propostawwds_25_tfpropostaclinicanome = AV99TFPropostaClinicaNome;
         AV149Propostawwds_26_tfpropostaclinicanome_sel = AV100TFPropostaClinicaNome_Sel;
         AV150Propostawwds_27_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = AV101TFPropostaPacienteClienteRazaoSocial;
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV102TFPropostaPacienteClienteRazaoSocial_Sel;
         AV153Propostawwds_30_tfpropostamaiorscore_f = AV103TFPropostaMaiorScore_F;
         AV154Propostawwds_31_tfpropostamaiorscore_f_to = AV104TFPropostaMaiorScore_F_To;
         AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = AV105TFPropostaMaiorValorRecomendado;
         AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV106TFPropostaMaiorValorRecomendado_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12522( )
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

      protected void E13522( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14522( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaClinicaNome") == 0 )
            {
               AV99TFPropostaClinicaNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV99TFPropostaClinicaNome", AV99TFPropostaClinicaNome);
               AV100TFPropostaClinicaNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV100TFPropostaClinicaNome_Sel", AV100TFPropostaClinicaNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaStatus") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaPacienteClienteRazaoSocial") == 0 )
            {
               AV101TFPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV101TFPropostaPacienteClienteRazaoSocial", AV101TFPropostaPacienteClienteRazaoSocial);
               AV102TFPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV102TFPropostaPacienteClienteRazaoSocial_Sel", AV102TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaMaiorScore_F") == 0 )
            {
               AV103TFPropostaMaiorScore_F = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFPropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0));
               AV104TFPropostaMaiorScore_F_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFPropostaMaiorScore_F_To", StringUtil.LTrimStr( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaMaiorValorRecomendado") == 0 )
            {
               AV105TFPropostaMaiorValorRecomendado = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV105TFPropostaMaiorValorRecomendado", StringUtil.LTrimStr( AV105TFPropostaMaiorValorRecomendado, 18, 2));
               AV106TFPropostaMaiorValorRecomendado_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV106TFPropostaMaiorValorRecomendado_To", StringUtil.LTrimStr( AV106TFPropostaMaiorValorRecomendado_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
      }

      private void E27522( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV91Aprovados = (short)(A40000GXC1);
         if ( AV91Aprovados > 0 )
         {
            AV107DmUsuarioPendenteAprovacao = "Aprovado_por_voce";
            AssignAttri("", false, cmbavDmusuariopendenteaprovacao_Internalname, AV107DmUsuarioPendenteAprovacao);
         }
         else
         {
            AV107DmUsuarioPendenteAprovacao = "Pendente_aprovacao";
            AssignAttri("", false, cmbavDmusuariopendenteaprovacao_Internalname, AV107DmUsuarioPendenteAprovacao);
         }
         AV98Editar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri("", false, edtavEditar_Internalname, AV98Editar);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpalterarproposta"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtavEditar_Link = formatLink("wpalterarproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV94Consultar = "<i class=\"fas fa-search\"></i>";
         AssignAttri("", false, edtavConsultar_Internalname, AV94Consultar);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpconsultaproposta"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtavConsultar_Link = formatLink("wpconsultaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV96Aprovacoes = "<i class=\"fas fa-user-check\"></i>";
         AssignAttri("", false, edtavAprovacoes_Internalname, AV96Aprovacoes);
         AV97Reembolso = "<i class=\"fas fa-arrow-rotate-left\"></i>";
         AssignAttri("", false, edtavReembolso_Internalname, AV97Reembolso);
         if ( A649PropostaMaxReembolsoId_F > 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wreembolso"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
            edtavReembolso_Link = formatLink("wreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavReembolso_Class = "Attribute";
         }
         else
         {
            edtavReembolso_Link = "";
            edtavReembolso_Class = "Invisible";
         }
         if ( StringUtil.StrCmp(AV107DmUsuarioPendenteAprovacao, "Pendente_aprovacao") == 0 )
         {
            cmbavDmusuariopendenteaprovacao_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(AV107DmUsuarioPendenteAprovacao, "Aprovado_por_voce") == 0 )
         {
            cmbavDmusuariopendenteaprovacao_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else
         {
            cmbavDmusuariopendenteaprovacao_Columnclass = "WWColumn";
         }
         if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbPropostaStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 143;
         }
         sendrow_1432( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_143_Refreshing )
         {
            DoAjaxLoad(143, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavDmusuariopendenteaprovacao.CurrentValue = StringUtil.RTrim( AV107DmUsuarioPendenteAprovacao);
      }

      protected void E20522( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15522( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E21522( )
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

      protected void E22522( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16522( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E23522( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E17522( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV109PropostaResponsavelDocumento1, AV110PropostaPacienteClienteDocumento1, AV111PropostaClinicaDocumento1, AV112ConvenioCategoriaDescricao1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV114PropostaResponsavelDocumento2, AV115PropostaPacienteClienteDocumento2, AV116PropostaClinicaDocumento2, AV117ConvenioCategoriaDescricao2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV119PropostaResponsavelDocumento3, AV120PropostaPacienteClienteDocumento3, AV121PropostaClinicaDocumento3, AV122ConvenioCategoriaDescricao3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV123Pgmname, AV15FilterFullText, AV108PropostaMaxReembolsoId_F1, AV113PropostaMaxReembolsoId_F2, AV118PropostaMaxReembolsoId_F3, AV99TFPropostaClinicaNome, AV100TFPropostaClinicaNome_Sel, AV51TFPropostaStatus_Sels, AV101TFPropostaPacienteClienteRazaoSocial, AV102TFPropostaPacienteClienteRazaoSocial_Sel, AV103TFPropostaMaiorScore_F, AV104TFPropostaMaiorScore_F_To, AV105TFPropostaMaiorValorRecomendado, AV106TFPropostaMaiorValorRecomendado_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV86Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E24522( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E11522( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("PropostaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV123Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("PropostaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "PropostaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV33ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV123Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E28522( )
      {
         /* Aprovacoes_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "aprovacaoww"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         context.PopUp(formatLink("aprovacaoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E18522( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wproposta") );
         context.wjLocDisableFrm = 1;
      }

      protected void E19522( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new propostawwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
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
         edtavPropostamaxreembolsoid_f1_Visible = 0;
         AssignProp("", false, edtavPropostamaxreembolsoid_f1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f1_Visible), 5, 0), true);
         edtavPropostaresponsaveldocumento1_Visible = 0;
         AssignProp("", false, edtavPropostaresponsaveldocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento1_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento1_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento1_Visible), 5, 0), true);
         edtavPropostaclinicadocumento1_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento1_Visible), 5, 0), true);
         edtavConveniocategoriadescricao1_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f1_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento1_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento1_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento1_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            edtavConveniocategoriadescricao1_Visible = 1;
            AssignProp("", false, edtavConveniocategoriadescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavPropostamaxreembolsoid_f2_Visible = 0;
         AssignProp("", false, edtavPropostamaxreembolsoid_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f2_Visible), 5, 0), true);
         edtavPropostaresponsaveldocumento2_Visible = 0;
         AssignProp("", false, edtavPropostaresponsaveldocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento2_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento2_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
         edtavPropostaclinicadocumento2_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
         edtavConveniocategoriadescricao2_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f2_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento2_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            edtavConveniocategoriadescricao2_Visible = 1;
            AssignProp("", false, edtavConveniocategoriadescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavPropostamaxreembolsoid_f3_Visible = 0;
         AssignProp("", false, edtavPropostamaxreembolsoid_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f3_Visible), 5, 0), true);
         edtavPropostaresponsaveldocumento3_Visible = 0;
         AssignProp("", false, edtavPropostaresponsaveldocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento3_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento3_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento3_Visible), 5, 0), true);
         edtavPropostaclinicadocumento3_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento3_Visible), 5, 0), true);
         edtavConveniocategoriadescricao3_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f3_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento3_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            edtavConveniocategoriadescricao3_Visible = 1;
            AssignProp("", false, edtavConveniocategoriadescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV113PropostaMaxReembolsoId_F2 = 0;
         AssignAttri("", false, "AV113PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV118PropostaMaxReembolsoId_F3 = 0;
         AssignAttri("", false, "AV118PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "PropostaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV99TFPropostaClinicaNome = "";
         AssignAttri("", false, "AV99TFPropostaClinicaNome", AV99TFPropostaClinicaNome);
         AV100TFPropostaClinicaNome_Sel = "";
         AssignAttri("", false, "AV100TFPropostaClinicaNome_Sel", AV100TFPropostaClinicaNome_Sel);
         AV51TFPropostaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV101TFPropostaPacienteClienteRazaoSocial = "";
         AssignAttri("", false, "AV101TFPropostaPacienteClienteRazaoSocial", AV101TFPropostaPacienteClienteRazaoSocial);
         AV102TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV102TFPropostaPacienteClienteRazaoSocial_Sel", AV102TFPropostaPacienteClienteRazaoSocial_Sel);
         AV103TFPropostaMaiorScore_F = 0;
         AssignAttri("", false, "AV103TFPropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0));
         AV104TFPropostaMaiorScore_F_To = 0;
         AssignAttri("", false, "AV104TFPropostaMaiorScore_F_To", StringUtil.LTrimStr( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0));
         AV105TFPropostaMaiorValorRecomendado = 0;
         AssignAttri("", false, "AV105TFPropostaMaiorValorRecomendado", StringUtil.LTrimStr( AV105TFPropostaMaiorValorRecomendado, 18, 2));
         AV106TFPropostaMaiorValorRecomendado_To = 0;
         AssignAttri("", false, "AV106TFPropostaMaiorValorRecomendado_To", StringUtil.LTrimStr( AV106TFPropostaMaiorValorRecomendado_To, 18, 2));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV108PropostaMaxReembolsoId_F1 = 0;
         AssignAttri("", false, "AV108PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0));
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
         if ( StringUtil.StrCmp(AV31Session.Get(AV123Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV123Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV123Pgmname+"GridState"), null, "", "");
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
         AV157GXV1 = 1;
         while ( AV157GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV157GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME") == 0 )
            {
               AV99TFPropostaClinicaNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV99TFPropostaClinicaNome", AV99TFPropostaClinicaNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME_SEL") == 0 )
            {
               AV100TFPropostaClinicaNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV100TFPropostaClinicaNome_Sel", AV100TFPropostaClinicaNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV101TFPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV101TFPropostaPacienteClienteRazaoSocial", AV101TFPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV102TFPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV102TFPropostaPacienteClienteRazaoSocial_Sel", AV102TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORSCORE_F") == 0 )
            {
               AV103TFPropostaMaiorScore_F = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFPropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0));
               AV104TFPropostaMaiorScore_F_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFPropostaMaiorScore_F_To", StringUtil.LTrimStr( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORVALORRECOMENDADO") == 0 )
            {
               AV105TFPropostaMaiorValorRecomendado = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV105TFPropostaMaiorValorRecomendado", StringUtil.LTrimStr( AV105TFPropostaMaiorValorRecomendado, 18, 2));
               AV106TFPropostaMaiorValorRecomendado_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV106TFPropostaMaiorValorRecomendado_To", StringUtil.LTrimStr( AV106TFPropostaMaiorValorRecomendado_To, 18, 2));
            }
            AV157GXV1 = (int)(AV157GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV100TFPropostaClinicaNome_Sel)),  AV100TFPropostaClinicaNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV51TFPropostaStatus_Sels.Count==0),  AV50TFPropostaStatus_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV102TFPropostaPacienteClienteRazaoSocial_Sel)),  AV102TFPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV99TFPropostaClinicaNome)),  AV99TFPropostaClinicaNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV101TFPropostaPacienteClienteRazaoSocial)),  AV101TFPropostaPacienteClienteRazaoSocial, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"||"+GXt_char5+"|"+((0==AV103TFPropostaMaiorScore_F) ? "" : StringUtil.Str( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0))+"|"+((Convert.ToDecimal(0)==AV105TFPropostaMaiorValorRecomendado) ? "" : StringUtil.Str( AV105TFPropostaMaiorValorRecomendado, 18, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((0==AV104TFPropostaMaiorScore_F_To) ? "" : StringUtil.Str( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0))+"|"+((Convert.ToDecimal(0)==AV106TFPropostaMaiorValorRecomendado_To) ? "" : StringUtil.Str( AV106TFPropostaMaiorValorRecomendado_To, 18, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV108PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV108PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV109PropostaResponsavelDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV109PropostaResponsavelDocumento1", AV109PropostaResponsavelDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV110PropostaPacienteClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV110PropostaPacienteClienteDocumento1", AV110PropostaPacienteClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV111PropostaClinicaDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV111PropostaClinicaDocumento1", AV111PropostaClinicaDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV112ConvenioCategoriaDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV112ConvenioCategoriaDescricao1", AV112ConvenioCategoriaDescricao1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV113PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV113PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV114PropostaResponsavelDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV114PropostaResponsavelDocumento2", AV114PropostaResponsavelDocumento2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV115PropostaPacienteClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV115PropostaPacienteClienteDocumento2", AV115PropostaPacienteClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV116PropostaClinicaDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV116PropostaClinicaDocumento2", AV116PropostaClinicaDocumento2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV117ConvenioCategoriaDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV117ConvenioCategoriaDescricao2", AV117ConvenioCategoriaDescricao2);
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
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV118PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV118PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV119PropostaResponsavelDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV119PropostaResponsavelDocumento3", AV119PropostaResponsavelDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV120PropostaPacienteClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV120PropostaPacienteClienteDocumento3", AV120PropostaPacienteClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV121PropostaClinicaDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV121PropostaClinicaDocumento3", AV121PropostaClinicaDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV122ConvenioCategoriaDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV122ConvenioCategoriaDescricao3", AV122ConvenioCategoriaDescricao3);
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
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV123Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTACLINICANOME",  "Clinica Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV99TFPropostaClinicaNome)),  0,  AV99TFPropostaClinicaNome,  AV99TFPropostaClinicaNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV100TFPropostaClinicaNome_Sel)),  AV100TFPropostaClinicaNome_Sel,  AV100TFPropostaClinicaNome_Sel) ;
         AV64AuxText = ((AV51TFPropostaStatus_Sels.Count==1) ? "["+((string)AV51TFPropostaStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTASTATUS_SEL",  "Status",  !(AV51TFPropostaStatus_Sels.Count==0),  0,  AV51TFPropostaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV64AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV64AuxText, "[PENDENTE]", "Pendente aprovação"), "[EM_ANALISE]", "Em análise"), "[APROVADO]", "Aprovado"), "[REJEITADO]", "Rejeitado"), "[REVISAO]", "Revisão"), "[CANCELADO]", "Cancelado"), "[AGUARDANDO_ASSINATURA]", "Aguardando assinatura"), "[AnaliseReprovada]", "Análise reprovada")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV101TFPropostaPacienteClienteRazaoSocial)),  0,  AV101TFPropostaPacienteClienteRazaoSocial,  AV101TFPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV102TFPropostaPacienteClienteRazaoSocial_Sel)),  AV102TFPropostaPacienteClienteRazaoSocial_Sel,  AV102TFPropostaPacienteClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAMAIORSCORE_F",  "Maior score",  !((0==AV103TFPropostaMaiorScore_F)&&(0==AV104TFPropostaMaiorScore_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV103TFPropostaMaiorScore_F), 4, 0)),  ((0==AV103TFPropostaMaiorScore_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV103TFPropostaMaiorScore_F), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV104TFPropostaMaiorScore_F_To), 4, 0)),  ((0==AV104TFPropostaMaiorScore_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV104TFPropostaMaiorScore_F_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAMAIORVALORRECOMENDADO",  "Maior valor recomendado",  !((Convert.ToDecimal(0)==AV105TFPropostaMaiorValorRecomendado)&&(Convert.ToDecimal(0)==AV106TFPropostaMaiorValorRecomendado_To)),  0,  StringUtil.Trim( StringUtil.Str( AV105TFPropostaMaiorValorRecomendado, 18, 2)),  ((Convert.ToDecimal(0)==AV105TFPropostaMaiorValorRecomendado) ? "" : StringUtil.Trim( context.localUtil.Format( AV105TFPropostaMaiorValorRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV106TFPropostaMaiorValorRecomendado_To, 18, 2)),  ((Convert.ToDecimal(0)==AV106TFPropostaMaiorValorRecomendado_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV106TFPropostaMaiorValorRecomendado_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV123Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV108PropostaMaxReembolsoId_F1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV108PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV108PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV108PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV109PropostaResponsavelDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV17DynamicFiltersOperator1,  AV109PropostaResponsavelDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV109PropostaResponsavelDocumento1, "Contém"+" "+AV109PropostaResponsavelDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV110PropostaPacienteClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV17DynamicFiltersOperator1,  AV110PropostaPacienteClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV110PropostaPacienteClienteDocumento1, "Contém"+" "+AV110PropostaPacienteClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV111PropostaClinicaDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV17DynamicFiltersOperator1,  AV111PropostaClinicaDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV111PropostaClinicaDocumento1, "Contém"+" "+AV111PropostaClinicaDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV112ConvenioCategoriaDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV17DynamicFiltersOperator1,  AV112ConvenioCategoriaDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV112ConvenioCategoriaDescricao1, "Contém"+" "+AV112ConvenioCategoriaDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV113PropostaMaxReembolsoId_F2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV21DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV113PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV113PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV113PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV114PropostaResponsavelDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV21DynamicFiltersOperator2,  AV114PropostaResponsavelDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV114PropostaResponsavelDocumento2, "Contém"+" "+AV114PropostaResponsavelDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV115PropostaPacienteClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV21DynamicFiltersOperator2,  AV115PropostaPacienteClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV115PropostaPacienteClienteDocumento2, "Contém"+" "+AV115PropostaPacienteClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV116PropostaClinicaDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV21DynamicFiltersOperator2,  AV116PropostaClinicaDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV116PropostaClinicaDocumento2, "Contém"+" "+AV116PropostaClinicaDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV117ConvenioCategoriaDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV21DynamicFiltersOperator2,  AV117ConvenioCategoriaDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV117ConvenioCategoriaDescricao2, "Contém"+" "+AV117ConvenioCategoriaDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV118PropostaMaxReembolsoId_F3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV25DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV118PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV118PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV118PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV119PropostaResponsavelDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV25DynamicFiltersOperator3,  AV119PropostaResponsavelDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV119PropostaResponsavelDocumento3, "Contém"+" "+AV119PropostaResponsavelDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV120PropostaPacienteClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV25DynamicFiltersOperator3,  AV120PropostaPacienteClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV120PropostaPacienteClienteDocumento3, "Contém"+" "+AV120PropostaPacienteClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV121PropostaClinicaDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV25DynamicFiltersOperator3,  AV121PropostaClinicaDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV121PropostaClinicaDocumento3, "Contém"+" "+AV121PropostaClinicaDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV122ConvenioCategoriaDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV25DynamicFiltersOperator3,  AV122ConvenioCategoriaDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV122ConvenioCategoriaDescricao3, "Contém"+" "+AV122ConvenioCategoriaDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV123Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Proposta";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_113_522( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostamaxreembolsoid_f3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostamaxreembolsoid_f3_Internalname, "Proposta Max Reembolso Id_F3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV118PropostaMaxReembolsoId_F3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV118PropostaMaxReembolsoId_F3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV118PropostaMaxReembolsoId_F3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f3_Visible, edtavPropostamaxreembolsoid_f3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento3_Internalname, "Proposta Responsavel Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento3_Internalname, AV119PropostaResponsavelDocumento3, StringUtil.RTrim( context.localUtil.Format( AV119PropostaResponsavelDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento3_Visible, edtavPropostaresponsaveldocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento3_Internalname, "Proposta Paciente Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento3_Internalname, AV120PropostaPacienteClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV120PropostaPacienteClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento3_Visible, edtavPropostapacienteclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento3_Internalname, "Proposta Clinica Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento3_Internalname, AV121PropostaClinicaDocumento3, StringUtil.RTrim( context.localUtil.Format( AV121PropostaClinicaDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento3_Visible, edtavPropostaclinicadocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao3_Internalname, "Convenio Categoria Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao3_Internalname, AV122ConvenioCategoriaDescricao3, StringUtil.RTrim( context.localUtil.Format( AV122ConvenioCategoriaDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao3_Visible, edtavConveniocategoriadescricao3_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_113_522e( true) ;
         }
         else
         {
            wb_table3_113_522e( false) ;
         }
      }

      protected void wb_table2_79_522( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostamaxreembolsoid_f2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostamaxreembolsoid_f2_Internalname, "Proposta Max Reembolso Id_F2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV113PropostaMaxReembolsoId_F2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV113PropostaMaxReembolsoId_F2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV113PropostaMaxReembolsoId_F2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f2_Visible, edtavPropostamaxreembolsoid_f2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento2_Internalname, "Proposta Responsavel Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento2_Internalname, AV114PropostaResponsavelDocumento2, StringUtil.RTrim( context.localUtil.Format( AV114PropostaResponsavelDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento2_Visible, edtavPropostaresponsaveldocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento2_Internalname, "Proposta Paciente Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento2_Internalname, AV115PropostaPacienteClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV115PropostaPacienteClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento2_Visible, edtavPropostapacienteclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento2_Internalname, "Proposta Clinica Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento2_Internalname, AV116PropostaClinicaDocumento2, StringUtil.RTrim( context.localUtil.Format( AV116PropostaClinicaDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento2_Visible, edtavPropostaclinicadocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao2_Internalname, "Convenio Categoria Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao2_Internalname, AV117ConvenioCategoriaDescricao2, StringUtil.RTrim( context.localUtil.Format( AV117ConvenioCategoriaDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao2_Visible, edtavConveniocategoriadescricao2_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_79_522e( true) ;
         }
         else
         {
            wb_table2_79_522e( false) ;
         }
      }

      protected void wb_table1_45_522( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_143_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_PropostaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostamaxreembolsoid_f1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostamaxreembolsoid_f1_Internalname, "Proposta Max Reembolso Id_F1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV108PropostaMaxReembolsoId_F1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV108PropostaMaxReembolsoId_F1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV108PropostaMaxReembolsoId_F1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f1_Visible, edtavPropostamaxreembolsoid_f1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento1_Internalname, "Proposta Responsavel Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento1_Internalname, AV109PropostaResponsavelDocumento1, StringUtil.RTrim( context.localUtil.Format( AV109PropostaResponsavelDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento1_Visible, edtavPropostaresponsaveldocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento1_Internalname, "Proposta Paciente Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento1_Internalname, AV110PropostaPacienteClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV110PropostaPacienteClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento1_Visible, edtavPropostapacienteclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento1_Internalname, "Proposta Clinica Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento1_Internalname, AV111PropostaClinicaDocumento1, StringUtil.RTrim( context.localUtil.Format( AV111PropostaClinicaDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento1_Visible, edtavPropostaclinicadocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao1_Internalname, "Convenio Categoria Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_143_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao1_Internalname, AV112ConvenioCategoriaDescricao1, StringUtil.RTrim( context.localUtil.Format( AV112ConvenioCategoriaDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao1_Visible, edtavConveniocategoriadescricao1_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_522e( true) ;
         }
         else
         {
            wb_table1_45_522e( false) ;
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
         PA522( ) ;
         WS522( ) ;
         WE522( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019252758", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("propostaww.js", "?202561019252759", false, true);
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
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1432( )
      {
         edtavEditar_Internalname = "vEDITAR_"+sGXsfl_143_idx;
         edtavConsultar_Internalname = "vCONSULTAR_"+sGXsfl_143_idx;
         edtavAprovacoes_Internalname = "vAPROVACOES_"+sGXsfl_143_idx;
         edtavReembolso_Internalname = "vREEMBOLSO_"+sGXsfl_143_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_143_idx;
         edtPropostaClinicaNome_Internalname = "PROPOSTACLINICANOME_"+sGXsfl_143_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_143_idx;
         cmbavDmusuariopendenteaprovacao_Internalname = "vDMUSUARIOPENDENTEAPROVACAO_"+sGXsfl_143_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_143_idx;
         edtPropostaMaxReembolsoId_F_Internalname = "PROPOSTAMAXREEMBOLSOID_F_"+sGXsfl_143_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_143_idx;
         edtPropostaQtdDocumentoPendente_F_Internalname = "PROPOSTAQTDDOCUMENTOPENDENTE_F_"+sGXsfl_143_idx;
         edtPropostaMaiorScore_F_Internalname = "PROPOSTAMAIORSCORE_F_"+sGXsfl_143_idx;
         edtPropostaMaiorValorRecomendado_Internalname = "PROPOSTAMAIORVALORRECOMENDADO_"+sGXsfl_143_idx;
      }

      protected void SubsflControlProps_fel_1432( )
      {
         edtavEditar_Internalname = "vEDITAR_"+sGXsfl_143_fel_idx;
         edtavConsultar_Internalname = "vCONSULTAR_"+sGXsfl_143_fel_idx;
         edtavAprovacoes_Internalname = "vAPROVACOES_"+sGXsfl_143_fel_idx;
         edtavReembolso_Internalname = "vREEMBOLSO_"+sGXsfl_143_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_143_fel_idx;
         edtPropostaClinicaNome_Internalname = "PROPOSTACLINICANOME_"+sGXsfl_143_fel_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_143_fel_idx;
         cmbavDmusuariopendenteaprovacao_Internalname = "vDMUSUARIOPENDENTEAPROVACAO_"+sGXsfl_143_fel_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_143_fel_idx;
         edtPropostaMaxReembolsoId_F_Internalname = "PROPOSTAMAXREEMBOLSOID_F_"+sGXsfl_143_fel_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_143_fel_idx;
         edtPropostaQtdDocumentoPendente_F_Internalname = "PROPOSTAQTDDOCUMENTOPENDENTE_F_"+sGXsfl_143_fel_idx;
         edtPropostaMaiorScore_F_Internalname = "PROPOSTAMAIORSCORE_F_"+sGXsfl_143_fel_idx;
         edtPropostaMaiorValorRecomendado_Internalname = "PROPOSTAMAIORVALORRECOMENDADO_"+sGXsfl_143_fel_idx;
      }

      protected void sendrow_1432( )
      {
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
         SubsflControlProps_1432( ) ;
         WB520( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_143_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_143_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_143_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_143_idx + "',143)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEditar_Internalname,StringUtil.RTrim( AV98Editar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavEditar_Link,(string)"",(string)"Editar",(string)"",(string)edtavEditar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavEditar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_143_idx + "',143)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsultar_Internalname,StringUtil.RTrim( AV94Consultar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavConsultar_Link,(string)"",(string)"",(string)"",(string)edtavConsultar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsultar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_143_idx + "',143)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAprovacoes_Internalname,StringUtil.RTrim( AV96Aprovacoes),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"","'"+""+"'"+",false,"+"'"+"EVAPROVACOES.CLICK."+sGXsfl_143_idx+"'",(string)"",(string)"",(string)"Aprovações",(string)"",(string)edtavAprovacoes_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAprovacoes_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_143_idx + "',143)\"";
            ROClassString = edtavReembolso_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReembolso_Internalname,StringUtil.RTrim( AV97Reembolso),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavReembolso_Link,(string)"",(string)"Reembolso",(string)"",(string)edtavReembolso_Jsonclick,(short)0,(string)edtavReembolso_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavReembolso_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaClinicaNome_Internalname,(string)A643PropostaClinicaNome,StringUtil.RTrim( context.localUtil.Format( A643PropostaClinicaNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaClinicaNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosNome_Internalname,(string)A377ProcedimentosMedicosNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_143_idx + "',143)\"";
            if ( ( cmbavDmusuariopendenteaprovacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vDMUSUARIOPENDENTEAPROVACAO_" + sGXsfl_143_idx;
               cmbavDmusuariopendenteaprovacao.Name = GXCCtl;
               cmbavDmusuariopendenteaprovacao.WebTags = "";
               cmbavDmusuariopendenteaprovacao.addItem("Pendente_aprovacao", "Pendente aprovação", 0);
               cmbavDmusuariopendenteaprovacao.addItem("Aprovado_por_voce", "Aprovado por você", 0);
               if ( cmbavDmusuariopendenteaprovacao.ItemCount > 0 )
               {
                  AV107DmUsuarioPendenteAprovacao = cmbavDmusuariopendenteaprovacao.getValidValue(AV107DmUsuarioPendenteAprovacao);
                  AssignAttri("", false, cmbavDmusuariopendenteaprovacao_Internalname, AV107DmUsuarioPendenteAprovacao);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavDmusuariopendenteaprovacao,(string)cmbavDmusuariopendenteaprovacao_Internalname,StringUtil.RTrim( AV107DmUsuarioPendenteAprovacao),(short)1,(string)cmbavDmusuariopendenteaprovacao_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavDmusuariopendenteaprovacao.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavDmusuariopendenteaprovacao_Columnclass,(string)cmbavDmusuariopendenteaprovacao_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"",(string)"",(bool)true,(short)0});
            cmbavDmusuariopendenteaprovacao.CurrentValue = StringUtil.RTrim( AV107DmUsuarioPendenteAprovacao);
            AssignProp("", false, cmbavDmusuariopendenteaprovacao_Internalname, "Values", (string)(cmbavDmusuariopendenteaprovacao.ToJavascriptSource()), !bGXsfl_143_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPropostaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROPOSTASTATUS_" + sGXsfl_143_idx;
               cmbPropostaStatus.Name = GXCCtl;
               cmbPropostaStatus.WebTags = "";
               cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
               cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
               cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
               cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
               cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
               cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
               cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
               if ( cmbPropostaStatus.ItemCount > 0 )
               {
                  A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
                  n329PropostaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaStatus,(string)cmbPropostaStatus_Internalname,StringUtil.RTrim( A329PropostaStatus),(short)1,(string)cmbPropostaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbPropostaStatus_Columnclass,(string)cmbPropostaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), !bGXsfl_143_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaMaxReembolsoId_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaMaxReembolsoId_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteClienteRazaoSocial_Internalname,(string)A505PropostaPacienteClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A505PropostaPacienteClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaPacienteClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaQtdDocumentoPendente_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A655PropostaQtdDocumentoPendente_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaQtdDocumentoPendente_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaMaiorScore_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A784PropostaMaiorScore_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A784PropostaMaiorScore_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaMaiorScore_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaMaiorValorRecomendado_Internalname,StringUtil.LTrim( StringUtil.NToC( A788PropostaMaiorValorRecomendado, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A788PropostaMaiorValorRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaMaiorValorRecomendado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes522( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_143_idx = ((subGrid_Islastpage==1)&&(nGXsfl_143_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
            SubsflControlProps_1432( ) ;
         }
         /* End function sendrow_1432 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector1.addItem("CONVENIOCATEGORIADESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector2.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector2.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector2.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector2.addItem("CONVENIOCATEGORIADESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector3.addItem("CONVENIOCATEGORIADESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vDMUSUARIOPENDENTEAPROVACAO_" + sGXsfl_143_idx;
         cmbavDmusuariopendenteaprovacao.Name = GXCCtl;
         cmbavDmusuariopendenteaprovacao.WebTags = "";
         cmbavDmusuariopendenteaprovacao.addItem("Pendente_aprovacao", "Pendente aprovação", 0);
         cmbavDmusuariopendenteaprovacao.addItem("Aprovado_por_voce", "Aprovado por você", 0);
         if ( cmbavDmusuariopendenteaprovacao.ItemCount > 0 )
         {
            AV107DmUsuarioPendenteAprovacao = cmbavDmusuariopendenteaprovacao.getValidValue(AV107DmUsuarioPendenteAprovacao);
            AssignAttri("", false, cmbavDmusuariopendenteaprovacao_Internalname, AV107DmUsuarioPendenteAprovacao);
         }
         GXCCtl = "PROPOSTASTATUS_" + sGXsfl_143_idx;
         cmbPropostaStatus.Name = GXCCtl;
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl143( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"143\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavReembolso_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Clinica Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Procedimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status aprovação usuário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reembolso Id_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documento Pendente_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Maior score") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Maior valor recomendado") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV98Editar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEditar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavEditar_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV94Consultar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsultar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavConsultar_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV96Aprovacoes)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAprovacoes_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV97Reembolso)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavReembolso_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReembolso_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavReembolso_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A643PropostaClinicaNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A377ProcedimentosMedicosNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV107DmUsuarioPendenteAprovacao));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavDmusuariopendenteaprovacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavDmusuariopendenteaprovacao_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDmusuariopendenteaprovacao.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329PropostaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbPropostaStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A505PropostaPacienteClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A784PropostaMaiorScore_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A788PropostaMaiorValorRecomendado, 18, 2, ".", ""))));
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
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
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
         edtavPropostamaxreembolsoid_f1_Internalname = "vPROPOSTAMAXREEMBOLSOID_F1";
         cellFilter_propostamaxreembolsoid_f1_cell_Internalname = "FILTER_PROPOSTAMAXREEMBOLSOID_F1_CELL";
         edtavPropostaresponsaveldocumento1_Internalname = "vPROPOSTARESPONSAVELDOCUMENTO1";
         cellFilter_propostaresponsaveldocumento1_cell_Internalname = "FILTER_PROPOSTARESPONSAVELDOCUMENTO1_CELL";
         edtavPropostapacienteclientedocumento1_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO1";
         cellFilter_propostapacienteclientedocumento1_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO1_CELL";
         edtavPropostaclinicadocumento1_Internalname = "vPROPOSTACLINICADOCUMENTO1";
         cellFilter_propostaclinicadocumento1_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO1_CELL";
         edtavConveniocategoriadescricao1_Internalname = "vCONVENIOCATEGORIADESCRICAO1";
         cellFilter_conveniocategoriadescricao1_cell_Internalname = "FILTER_CONVENIOCATEGORIADESCRICAO1_CELL";
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
         edtavPropostamaxreembolsoid_f2_Internalname = "vPROPOSTAMAXREEMBOLSOID_F2";
         cellFilter_propostamaxreembolsoid_f2_cell_Internalname = "FILTER_PROPOSTAMAXREEMBOLSOID_F2_CELL";
         edtavPropostaresponsaveldocumento2_Internalname = "vPROPOSTARESPONSAVELDOCUMENTO2";
         cellFilter_propostaresponsaveldocumento2_cell_Internalname = "FILTER_PROPOSTARESPONSAVELDOCUMENTO2_CELL";
         edtavPropostapacienteclientedocumento2_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO2";
         cellFilter_propostapacienteclientedocumento2_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO2_CELL";
         edtavPropostaclinicadocumento2_Internalname = "vPROPOSTACLINICADOCUMENTO2";
         cellFilter_propostaclinicadocumento2_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO2_CELL";
         edtavConveniocategoriadescricao2_Internalname = "vCONVENIOCATEGORIADESCRICAO2";
         cellFilter_conveniocategoriadescricao2_cell_Internalname = "FILTER_CONVENIOCATEGORIADESCRICAO2_CELL";
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
         edtavPropostamaxreembolsoid_f3_Internalname = "vPROPOSTAMAXREEMBOLSOID_F3";
         cellFilter_propostamaxreembolsoid_f3_cell_Internalname = "FILTER_PROPOSTAMAXREEMBOLSOID_F3_CELL";
         edtavPropostaresponsaveldocumento3_Internalname = "vPROPOSTARESPONSAVELDOCUMENTO3";
         cellFilter_propostaresponsaveldocumento3_cell_Internalname = "FILTER_PROPOSTARESPONSAVELDOCUMENTO3_CELL";
         edtavPropostapacienteclientedocumento3_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO3";
         cellFilter_propostapacienteclientedocumento3_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO3_CELL";
         edtavPropostaclinicadocumento3_Internalname = "vPROPOSTACLINICADOCUMENTO3";
         cellFilter_propostaclinicadocumento3_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO3_CELL";
         edtavConveniocategoriadescricao3_Internalname = "vCONVENIOCATEGORIADESCRICAO3";
         cellFilter_conveniocategoriadescricao3_cell_Internalname = "FILTER_CONVENIOCATEGORIADESCRICAO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavEditar_Internalname = "vEDITAR";
         edtavConsultar_Internalname = "vCONSULTAR";
         edtavAprovacoes_Internalname = "vAPROVACOES";
         edtavReembolso_Internalname = "vREEMBOLSO";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtPropostaClinicaNome_Internalname = "PROPOSTACLINICANOME";
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME";
         cmbavDmusuariopendenteaprovacao_Internalname = "vDMUSUARIOPENDENTEAPROVACAO";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         edtPropostaMaxReembolsoId_F_Internalname = "PROPOSTAMAXREEMBOLSOID_F";
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtPropostaQtdDocumentoPendente_F_Internalname = "PROPOSTAQTDDOCUMENTOPENDENTE_F";
         edtPropostaMaiorScore_F_Internalname = "PROPOSTAMAIORSCORE_F";
         edtPropostaMaiorValorRecomendado_Internalname = "PROPOSTAMAIORVALORRECOMENDADO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
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
         edtPropostaMaiorValorRecomendado_Jsonclick = "";
         edtPropostaMaiorScore_F_Jsonclick = "";
         edtPropostaQtdDocumentoPendente_F_Jsonclick = "";
         edtPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtPropostaMaxReembolsoId_F_Jsonclick = "";
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus_Columnclass = "WWColumn";
         cmbavDmusuariopendenteaprovacao_Jsonclick = "";
         cmbavDmusuariopendenteaprovacao.Enabled = 1;
         cmbavDmusuariopendenteaprovacao_Columnclass = "WWColumn";
         edtProcedimentosMedicosNome_Jsonclick = "";
         edtPropostaClinicaNome_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtavReembolso_Jsonclick = "";
         edtavReembolso_Class = "Attribute";
         edtavReembolso_Link = "";
         edtavReembolso_Enabled = 1;
         edtavAprovacoes_Jsonclick = "";
         edtavAprovacoes_Enabled = 1;
         edtavConsultar_Jsonclick = "";
         edtavConsultar_Link = "";
         edtavConsultar_Enabled = 1;
         edtavEditar_Jsonclick = "";
         edtavEditar_Link = "";
         edtavEditar_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavConveniocategoriadescricao1_Jsonclick = "";
         edtavConveniocategoriadescricao1_Enabled = 1;
         edtavPropostaclinicadocumento1_Jsonclick = "";
         edtavPropostaclinicadocumento1_Enabled = 1;
         edtavPropostapacienteclientedocumento1_Jsonclick = "";
         edtavPropostapacienteclientedocumento1_Enabled = 1;
         edtavPropostaresponsaveldocumento1_Jsonclick = "";
         edtavPropostaresponsaveldocumento1_Enabled = 1;
         edtavPropostamaxreembolsoid_f1_Jsonclick = "";
         edtavPropostamaxreembolsoid_f1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavConveniocategoriadescricao2_Jsonclick = "";
         edtavConveniocategoriadescricao2_Enabled = 1;
         edtavPropostaclinicadocumento2_Jsonclick = "";
         edtavPropostaclinicadocumento2_Enabled = 1;
         edtavPropostapacienteclientedocumento2_Jsonclick = "";
         edtavPropostapacienteclientedocumento2_Enabled = 1;
         edtavPropostaresponsaveldocumento2_Jsonclick = "";
         edtavPropostaresponsaveldocumento2_Enabled = 1;
         edtavPropostamaxreembolsoid_f2_Jsonclick = "";
         edtavPropostamaxreembolsoid_f2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavConveniocategoriadescricao3_Jsonclick = "";
         edtavConveniocategoriadescricao3_Enabled = 1;
         edtavPropostaclinicadocumento3_Jsonclick = "";
         edtavPropostaclinicadocumento3_Enabled = 1;
         edtavPropostapacienteclientedocumento3_Jsonclick = "";
         edtavPropostapacienteclientedocumento3_Enabled = 1;
         edtavPropostaresponsaveldocumento3_Jsonclick = "";
         edtavPropostaresponsaveldocumento3_Enabled = 1;
         edtavPropostamaxreembolsoid_f3_Jsonclick = "";
         edtavPropostamaxreembolsoid_f3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavConveniocategoriadescricao3_Visible = 1;
         edtavPropostaclinicadocumento3_Visible = 1;
         edtavPropostapacienteclientedocumento3_Visible = 1;
         edtavPropostaresponsaveldocumento3_Visible = 1;
         edtavPropostamaxreembolsoid_f3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavConveniocategoriadescricao2_Visible = 1;
         edtavPropostaclinicadocumento2_Visible = 1;
         edtavPropostapacienteclientedocumento2_Visible = 1;
         edtavPropostaresponsaveldocumento2_Visible = 1;
         edtavPropostamaxreembolsoid_f2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavConveniocategoriadescricao1_Visible = 1;
         edtavPropostaclinicadocumento1_Visible = 1;
         edtavPropostapacienteclientedocumento1_Visible = 1;
         edtavPropostaresponsaveldocumento1_Visible = 1;
         edtavPropostamaxreembolsoid_f1_Visible = 1;
         cmbPropostaStatus_Columnheaderclass = "";
         cmbavDmusuariopendenteaprovacao_Columnheaderclass = "";
         edtPropostaMaiorValorRecomendado_Enabled = 0;
         edtPropostaMaiorScore_F_Enabled = 0;
         edtPropostaQtdDocumentoPendente_F_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaMaxReembolsoId_F_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
         edtPropostaClinicaNome_Enabled = 0;
         edtPropostaId_Enabled = 0;
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
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = ";;;;;;;;;;;;Serasa;Serasa";
         Ddo_grid_Format = "|||4.0|18.2";
         Ddo_grid_Datalistproc = "PropostaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|PENDENTE:Pendente aprovação,EM_ANALISE:Em análise,APROVADO:Aprovado,REJEITADO:Rejeitado,REVISAO:Revisão,CANCELADO:Cancelado,AGUARDANDO_ASSINATURA:Aguardando assinatura,AnaliseReprovada:Análise reprovada|||";
         Ddo_grid_Allowmultipleselection = "|T|||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|Dynamic||";
         Ddo_grid_Includedatalist = "T|T|T||";
         Ddo_grid_Filterisrange = "|||T|T";
         Ddo_grid_Filtertype = "Character||Character|Numeric|Numeric";
         Ddo_grid_Includefilter = "T||T|T|T";
         Ddo_grid_Includesortasc = "T|T|T||";
         Ddo_grid_Columnssortvalues = "2|3|4||";
         Ddo_grid_Columnids = "5:PropostaClinicaNome|8:PropostaStatus|10:PropostaPacienteClienteRazaoSocial|12:PropostaMaiorScore_F|13:PropostaMaiorValorRecomendado";
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
         Form.Caption = " Proposta";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E27522","iparms":[{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A649PropostaMaxReembolsoId_F","fld":"PROPOSTAMAXREEMBOLSOID_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbPropostaStatus"},{"av":"A329PropostaStatus","fld":"PROPOSTASTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"A40000GXC1","fld":"GXC1","pic":"999999999","type":"int"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"AV107DmUsuarioPendenteAprovacao","fld":"vDMUSUARIOPENDENTEAPROVACAO","type":"svchar"},{"av":"AV98Editar","fld":"vEDITAR","type":"char"},{"av":"edtavEditar_Link","ctrl":"vEDITAR","prop":"Link"},{"av":"AV94Consultar","fld":"vCONSULTAR","type":"char"},{"av":"edtavConsultar_Link","ctrl":"vCONSULTAR","prop":"Link"},{"av":"AV96Aprovacoes","fld":"vAPROVACOES","type":"char"},{"av":"AV97Reembolso","fld":"vREEMBOLSO","type":"char"},{"av":"edtavReembolso_Link","ctrl":"vREEMBOLSO","prop":"Link"},{"av":"edtavReembolso_Class","ctrl":"vREEMBOLSO","prop":"Class"},{"av":"cmbPropostaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E20522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E21522","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E22522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E23522","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E24522","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VAPROVACOES.CLICK","""{"handler":"E28522","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VAPROVACOES.CLICK",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbavDmusuariopendenteaprovacao"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E18522","iparms":[]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19522","iparms":[{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV109PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV110PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV111PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV112ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV114PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV115PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV116PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV117ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV119PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV120PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV121PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV122ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV123Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV108PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV113PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV118PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV99TFPropostaClinicaNome","fld":"vTFPROPOSTACLINICANOME","pic":"@!","type":"svchar"},{"av":"AV100TFPropostaClinicaNome_Sel","fld":"vTFPROPOSTACLINICANOME_SEL","pic":"@!","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV101TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV102TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV103TFPropostaMaiorScore_F","fld":"vTFPROPOSTAMAIORSCORE_F","pic":"ZZZ9","type":"int"},{"av":"AV104TFPropostaMaiorScore_F_To","fld":"vTFPROPOSTAMAIORSCORE_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV105TFPropostaMaiorValorRecomendado","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV106TFPropostaMaiorValorRecomendado_To","fld":"vTFPROPOSTAMAIORVALORRECOMENDADO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV86Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("VALIDV_DMUSUARIOPENDENTEAPROVACAO","""{"handler":"Validv_Dmusuariopendenteaprovacao","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Propostamaiorvalorrecomendado","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16DynamicFiltersSelector1 = "";
         AV109PropostaResponsavelDocumento1 = "";
         AV110PropostaPacienteClienteDocumento1 = "";
         AV111PropostaClinicaDocumento1 = "";
         AV112ConvenioCategoriaDescricao1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV114PropostaResponsavelDocumento2 = "";
         AV115PropostaPacienteClienteDocumento2 = "";
         AV116PropostaClinicaDocumento2 = "";
         AV117ConvenioCategoriaDescricao2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV119PropostaResponsavelDocumento3 = "";
         AV120PropostaPacienteClienteDocumento3 = "";
         AV121PropostaClinicaDocumento3 = "";
         AV122ConvenioCategoriaDescricao3 = "";
         AV123Pgmname = "";
         AV15FilterFullText = "";
         AV99TFPropostaClinicaNome = "";
         AV100TFPropostaClinicaNome_Sel = "";
         AV51TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV101TFPropostaPacienteClienteRazaoSocial = "";
         AV102TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV86Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60GridAppliedFilters = "";
         AV56DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50TFPropostaStatus_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         bttBtnuseraction1_Jsonclick = "";
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
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV98Editar = "";
         AV94Consultar = "";
         AV96Aprovacoes = "";
         AV97Reembolso = "";
         A643PropostaClinicaNome = "";
         A377ProcedimentosMedicosNome = "";
         AV107DmUsuarioPendenteAprovacao = "";
         A329PropostaStatus = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         AV150Propostawwds_27_tfpropostastatus_sels = new GxSimpleCollection<string>();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         lV124Propostawwds_1_filterfulltext = "";
         lV128Propostawwds_5_propostaresponsaveldocumento1 = "";
         lV129Propostawwds_6_propostapacienteclientedocumento1 = "";
         lV130Propostawwds_7_propostaclinicadocumento1 = "";
         lV131Propostawwds_8_conveniocategoriadescricao1 = "";
         lV136Propostawwds_13_propostaresponsaveldocumento2 = "";
         lV137Propostawwds_14_propostapacienteclientedocumento2 = "";
         lV138Propostawwds_15_propostaclinicadocumento2 = "";
         lV139Propostawwds_16_conveniocategoriadescricao2 = "";
         lV144Propostawwds_21_propostaresponsaveldocumento3 = "";
         lV145Propostawwds_22_propostapacienteclientedocumento3 = "";
         lV146Propostawwds_23_propostaclinicadocumento3 = "";
         lV147Propostawwds_24_conveniocategoriadescricao3 = "";
         lV148Propostawwds_25_tfpropostaclinicanome = "";
         lV151Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         AV125Propostawwds_2_dynamicfiltersselector1 = "";
         AV128Propostawwds_5_propostaresponsaveldocumento1 = "";
         AV129Propostawwds_6_propostapacienteclientedocumento1 = "";
         AV130Propostawwds_7_propostaclinicadocumento1 = "";
         AV131Propostawwds_8_conveniocategoriadescricao1 = "";
         AV133Propostawwds_10_dynamicfiltersselector2 = "";
         AV136Propostawwds_13_propostaresponsaveldocumento2 = "";
         AV137Propostawwds_14_propostapacienteclientedocumento2 = "";
         AV138Propostawwds_15_propostaclinicadocumento2 = "";
         AV139Propostawwds_16_conveniocategoriadescricao2 = "";
         AV141Propostawwds_18_dynamicfiltersselector3 = "";
         AV144Propostawwds_21_propostaresponsaveldocumento3 = "";
         AV145Propostawwds_22_propostapacienteclientedocumento3 = "";
         AV146Propostawwds_23_propostaclinicadocumento3 = "";
         AV147Propostawwds_24_conveniocategoriadescricao3 = "";
         AV149Propostawwds_26_tfpropostaclinicanome_sel = "";
         AV148Propostawwds_25_tfpropostaclinicanome = "";
         AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = "";
         AV151Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A494ConvenioCategoriaDescricao = "";
         AV124Propostawwds_1_filterfulltext = "";
         H005214_A376ProcedimentosMedicosId = new int[1] ;
         H005214_n376ProcedimentosMedicosId = new bool[] {false} ;
         H005214_A493ConvenioCategoriaId = new int[1] ;
         H005214_n493ConvenioCategoriaId = new bool[] {false} ;
         H005214_A504PropostaPacienteClienteId = new int[1] ;
         H005214_n504PropostaPacienteClienteId = new bool[] {false} ;
         H005214_A553PropostaResponsavelId = new int[1] ;
         H005214_n553PropostaResponsavelId = new bool[] {false} ;
         H005214_A642PropostaClinicaId = new int[1] ;
         H005214_n642PropostaClinicaId = new bool[] {false} ;
         H005214_A328PropostaCratedBy = new short[1] ;
         H005214_n328PropostaCratedBy = new bool[] {false} ;
         H005214_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H005214_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H005214_A652PropostaClinicaDocumento = new string[] {""} ;
         H005214_n652PropostaClinicaDocumento = new bool[] {false} ;
         H005214_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H005214_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H005214_A580PropostaResponsavelDocumento = new string[] {""} ;
         H005214_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H005214_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H005214_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H005214_A329PropostaStatus = new string[] {""} ;
         H005214_n329PropostaStatus = new bool[] {false} ;
         H005214_A377ProcedimentosMedicosNome = new string[] {""} ;
         H005214_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H005214_A643PropostaClinicaNome = new string[] {""} ;
         H005214_n643PropostaClinicaNome = new bool[] {false} ;
         H005214_A788PropostaMaiorValorRecomendado = new decimal[1] ;
         H005214_n788PropostaMaiorValorRecomendado = new bool[] {false} ;
         H005214_A784PropostaMaiorScore_F = new short[1] ;
         H005214_n784PropostaMaiorScore_F = new bool[] {false} ;
         H005214_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         H005214_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         H005214_A323PropostaId = new int[1] ;
         H005214_n323PropostaId = new bool[] {false} ;
         H005214_A649PropostaMaxReembolsoId_F = new int[1] ;
         H005214_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         H005214_A40000GXC1 = new int[1] ;
         H005214_n40000GXC1 = new bool[] {false} ;
         H005227_AGRID_nRecordCount = new long[1] ;
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV64AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostaww__default(),
            new Object[][] {
                new Object[] {
               H005214_A376ProcedimentosMedicosId, H005214_n376ProcedimentosMedicosId, H005214_A493ConvenioCategoriaId, H005214_n493ConvenioCategoriaId, H005214_A504PropostaPacienteClienteId, H005214_n504PropostaPacienteClienteId, H005214_A553PropostaResponsavelId, H005214_n553PropostaResponsavelId, H005214_A642PropostaClinicaId, H005214_n642PropostaClinicaId,
               H005214_A328PropostaCratedBy, H005214_n328PropostaCratedBy, H005214_A494ConvenioCategoriaDescricao, H005214_n494ConvenioCategoriaDescricao, H005214_A652PropostaClinicaDocumento, H005214_n652PropostaClinicaDocumento, H005214_A540PropostaPacienteClienteDocumento, H005214_n540PropostaPacienteClienteDocumento, H005214_A580PropostaResponsavelDocumento, H005214_n580PropostaResponsavelDocumento,
               H005214_A505PropostaPacienteClienteRazaoSocial, H005214_n505PropostaPacienteClienteRazaoSocial, H005214_A329PropostaStatus, H005214_n329PropostaStatus, H005214_A377ProcedimentosMedicosNome, H005214_n377ProcedimentosMedicosNome, H005214_A643PropostaClinicaNome, H005214_n643PropostaClinicaNome, H005214_A788PropostaMaiorValorRecomendado, H005214_n788PropostaMaiorValorRecomendado,
               H005214_A784PropostaMaiorScore_F, H005214_n784PropostaMaiorScore_F, H005214_A655PropostaQtdDocumentoPendente_F, H005214_n655PropostaQtdDocumentoPendente_F, H005214_A323PropostaId, H005214_A649PropostaMaxReembolsoId_F, H005214_n649PropostaMaxReembolsoId_F, H005214_A40000GXC1, H005214_n40000GXC1
               }
               , new Object[] {
               H005227_AGRID_nRecordCount
               }
            }
         );
         AV123Pgmname = "PropostaWW";
         /* GeneXus formulas. */
         AV123Pgmname = "PropostaWW";
         edtavEditar_Enabled = 0;
         edtavConsultar_Enabled = 0;
         edtavAprovacoes_Enabled = 0;
         edtavReembolso_Enabled = 0;
         cmbavDmusuariopendenteaprovacao.Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short AV103TFPropostaMaiorScore_F ;
      private short AV104TFPropostaMaiorScore_F_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A655PropostaQtdDocumentoPendente_F ;
      private short A784PropostaMaiorScore_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV6WWPContext_gxTpr_Secuserclienteid ;
      private short AV126Propostawwds_3_dynamicfiltersoperator1 ;
      private short AV134Propostawwds_11_dynamicfiltersoperator2 ;
      private short AV142Propostawwds_19_dynamicfiltersoperator3 ;
      private short A328PropostaCratedBy ;
      private short AV153Propostawwds_30_tfpropostamaiorscore_f ;
      private short AV154Propostawwds_31_tfpropostamaiorscore_f_to ;
      private short AV91Aprovados ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_143 ;
      private int nGXsfl_143_idx=1 ;
      private int AV108PropostaMaxReembolsoId_F1 ;
      private int AV113PropostaMaxReembolsoId_F2 ;
      private int AV118PropostaMaxReembolsoId_F3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A323PropostaId ;
      private int A649PropostaMaxReembolsoId_F ;
      private int subGrid_Islastpage ;
      private int edtavEditar_Enabled ;
      private int edtavConsultar_Enabled ;
      private int edtavAprovacoes_Enabled ;
      private int edtavReembolso_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV150Propostawwds_27_tfpropostastatus_sels_Count ;
      private int AV127Propostawwds_4_propostamaxreembolsoid_f1 ;
      private int AV135Propostawwds_12_propostamaxreembolsoid_f2 ;
      private int AV143Propostawwds_20_propostamaxreembolsoid_f3 ;
      private int A376ProcedimentosMedicosId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A40000GXC1 ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaClinicaNome_Enabled ;
      private int edtProcedimentosMedicosNome_Enabled ;
      private int edtPropostaMaxReembolsoId_F_Enabled ;
      private int edtPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtPropostaQtdDocumentoPendente_F_Enabled ;
      private int edtPropostaMaiorScore_F_Enabled ;
      private int edtPropostaMaiorValorRecomendado_Enabled ;
      private int AV57PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPropostamaxreembolsoid_f1_Visible ;
      private int edtavPropostaresponsaveldocumento1_Visible ;
      private int edtavPropostapacienteclientedocumento1_Visible ;
      private int edtavPropostaclinicadocumento1_Visible ;
      private int edtavConveniocategoriadescricao1_Visible ;
      private int edtavPropostamaxreembolsoid_f2_Visible ;
      private int edtavPropostaresponsaveldocumento2_Visible ;
      private int edtavPropostapacienteclientedocumento2_Visible ;
      private int edtavPropostaclinicadocumento2_Visible ;
      private int edtavConveniocategoriadescricao2_Visible ;
      private int edtavPropostamaxreembolsoid_f3_Visible ;
      private int edtavPropostaresponsaveldocumento3_Visible ;
      private int edtavPropostapacienteclientedocumento3_Visible ;
      private int edtavPropostaclinicadocumento3_Visible ;
      private int edtavConveniocategoriadescricao3_Visible ;
      private int AV157GXV1 ;
      private int edtavPropostamaxreembolsoid_f3_Enabled ;
      private int edtavPropostaresponsaveldocumento3_Enabled ;
      private int edtavPropostapacienteclientedocumento3_Enabled ;
      private int edtavPropostaclinicadocumento3_Enabled ;
      private int edtavConveniocategoriadescricao3_Enabled ;
      private int edtavPropostamaxreembolsoid_f2_Enabled ;
      private int edtavPropostaresponsaveldocumento2_Enabled ;
      private int edtavPropostapacienteclientedocumento2_Enabled ;
      private int edtavPropostaclinicadocumento2_Enabled ;
      private int edtavConveniocategoriadescricao2_Enabled ;
      private int edtavPropostamaxreembolsoid_f1_Enabled ;
      private int edtavPropostaresponsaveldocumento1_Enabled ;
      private int edtavPropostapacienteclientedocumento1_Enabled ;
      private int edtavPropostaclinicadocumento1_Enabled ;
      private int edtavConveniocategoriadescricao1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV105TFPropostaMaiorValorRecomendado ;
      private decimal AV106TFPropostaMaiorValorRecomendado_To ;
      private decimal A788PropostaMaiorValorRecomendado ;
      private decimal AV155Propostawwds_32_tfpropostamaiorvalorrecomendado ;
      private decimal AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_143_idx="0001" ;
      private string AV123Pgmname ;
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
      private string Ddo_grid_Format ;
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
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
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
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV98Editar ;
      private string edtavEditar_Internalname ;
      private string AV94Consultar ;
      private string edtavConsultar_Internalname ;
      private string AV96Aprovacoes ;
      private string edtavAprovacoes_Internalname ;
      private string AV97Reembolso ;
      private string edtavReembolso_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaClinicaNome_Internalname ;
      private string edtProcedimentosMedicosNome_Internalname ;
      private string cmbavDmusuariopendenteaprovacao_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string edtPropostaMaxReembolsoId_F_Internalname ;
      private string edtPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtPropostaQtdDocumentoPendente_F_Internalname ;
      private string edtPropostaMaiorScore_F_Internalname ;
      private string edtPropostaMaiorValorRecomendado_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavPropostamaxreembolsoid_f1_Internalname ;
      private string edtavPropostaresponsaveldocumento1_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Internalname ;
      private string edtavPropostaclinicadocumento1_Internalname ;
      private string edtavConveniocategoriadescricao1_Internalname ;
      private string edtavPropostamaxreembolsoid_f2_Internalname ;
      private string edtavPropostaresponsaveldocumento2_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Internalname ;
      private string edtavPropostaclinicadocumento2_Internalname ;
      private string edtavConveniocategoriadescricao2_Internalname ;
      private string edtavPropostamaxreembolsoid_f3_Internalname ;
      private string edtavPropostaresponsaveldocumento3_Internalname ;
      private string edtavPropostapacienteclientedocumento3_Internalname ;
      private string edtavPropostaclinicadocumento3_Internalname ;
      private string edtavConveniocategoriadescricao3_Internalname ;
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
      private string cmbavDmusuariopendenteaprovacao_Columnheaderclass ;
      private string cmbPropostaStatus_Columnheaderclass ;
      private string edtavEditar_Link ;
      private string GXEncryptionTmp ;
      private string edtavConsultar_Link ;
      private string edtavReembolso_Link ;
      private string edtavReembolso_Class ;
      private string cmbavDmusuariopendenteaprovacao_Columnclass ;
      private string cmbPropostaStatus_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_propostamaxreembolsoid_f3_cell_Internalname ;
      private string edtavPropostamaxreembolsoid_f3_Jsonclick ;
      private string cellFilter_propostaresponsaveldocumento3_cell_Internalname ;
      private string edtavPropostaresponsaveldocumento3_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento3_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento3_Jsonclick ;
      private string cellFilter_propostaclinicadocumento3_cell_Internalname ;
      private string edtavPropostaclinicadocumento3_Jsonclick ;
      private string cellFilter_conveniocategoriadescricao3_cell_Internalname ;
      private string edtavConveniocategoriadescricao3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_propostamaxreembolsoid_f2_cell_Internalname ;
      private string edtavPropostamaxreembolsoid_f2_Jsonclick ;
      private string cellFilter_propostaresponsaveldocumento2_cell_Internalname ;
      private string edtavPropostaresponsaveldocumento2_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento2_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Jsonclick ;
      private string cellFilter_propostaclinicadocumento2_cell_Internalname ;
      private string edtavPropostaclinicadocumento2_Jsonclick ;
      private string cellFilter_conveniocategoriadescricao2_cell_Internalname ;
      private string edtavConveniocategoriadescricao2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_propostamaxreembolsoid_f1_cell_Internalname ;
      private string edtavPropostamaxreembolsoid_f1_Jsonclick ;
      private string cellFilter_propostaresponsaveldocumento1_cell_Internalname ;
      private string edtavPropostaresponsaveldocumento1_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento1_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Jsonclick ;
      private string cellFilter_propostaclinicadocumento1_cell_Internalname ;
      private string edtavPropostaclinicadocumento1_Jsonclick ;
      private string cellFilter_conveniocategoriadescricao1_cell_Internalname ;
      private string edtavConveniocategoriadescricao1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_143_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavEditar_Jsonclick ;
      private string edtavConsultar_Jsonclick ;
      private string edtavAprovacoes_Jsonclick ;
      private string edtavReembolso_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtPropostaClinicaNome_Jsonclick ;
      private string edtProcedimentosMedicosNome_Jsonclick ;
      private string GXCCtl ;
      private string cmbavDmusuariopendenteaprovacao_Jsonclick ;
      private string cmbPropostaStatus_Jsonclick ;
      private string edtPropostaMaxReembolsoId_F_Jsonclick ;
      private string edtPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtPropostaQtdDocumentoPendente_F_Jsonclick ;
      private string edtPropostaMaiorScore_F_Jsonclick ;
      private string edtPropostaMaiorValorRecomendado_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
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
      private bool n323PropostaId ;
      private bool n643PropostaClinicaNome ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n329PropostaStatus ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n655PropostaQtdDocumentoPendente_F ;
      private bool n784PropostaMaiorScore_F ;
      private bool n788PropostaMaiorValorRecomendado ;
      private bool bGXsfl_143_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV6WWPContext_gxTpr_Iscliente ;
      private bool AV132Propostawwds_9_dynamicfiltersenabled2 ;
      private bool AV140Propostawwds_17_dynamicfiltersenabled3 ;
      private bool n376ProcedimentosMedicosId ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n328PropostaCratedBy ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV50TFPropostaStatus_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV109PropostaResponsavelDocumento1 ;
      private string AV110PropostaPacienteClienteDocumento1 ;
      private string AV111PropostaClinicaDocumento1 ;
      private string AV112ConvenioCategoriaDescricao1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV114PropostaResponsavelDocumento2 ;
      private string AV115PropostaPacienteClienteDocumento2 ;
      private string AV116PropostaClinicaDocumento2 ;
      private string AV117ConvenioCategoriaDescricao2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV119PropostaResponsavelDocumento3 ;
      private string AV120PropostaPacienteClienteDocumento3 ;
      private string AV121PropostaClinicaDocumento3 ;
      private string AV122ConvenioCategoriaDescricao3 ;
      private string AV15FilterFullText ;
      private string AV99TFPropostaClinicaNome ;
      private string AV100TFPropostaClinicaNome_Sel ;
      private string AV101TFPropostaPacienteClienteRazaoSocial ;
      private string AV102TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV60GridAppliedFilters ;
      private string A643PropostaClinicaNome ;
      private string A377ProcedimentosMedicosNome ;
      private string AV107DmUsuarioPendenteAprovacao ;
      private string A329PropostaStatus ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string lV124Propostawwds_1_filterfulltext ;
      private string lV128Propostawwds_5_propostaresponsaveldocumento1 ;
      private string lV129Propostawwds_6_propostapacienteclientedocumento1 ;
      private string lV130Propostawwds_7_propostaclinicadocumento1 ;
      private string lV131Propostawwds_8_conveniocategoriadescricao1 ;
      private string lV136Propostawwds_13_propostaresponsaveldocumento2 ;
      private string lV137Propostawwds_14_propostapacienteclientedocumento2 ;
      private string lV138Propostawwds_15_propostaclinicadocumento2 ;
      private string lV139Propostawwds_16_conveniocategoriadescricao2 ;
      private string lV144Propostawwds_21_propostaresponsaveldocumento3 ;
      private string lV145Propostawwds_22_propostapacienteclientedocumento3 ;
      private string lV146Propostawwds_23_propostaclinicadocumento3 ;
      private string lV147Propostawwds_24_conveniocategoriadescricao3 ;
      private string lV148Propostawwds_25_tfpropostaclinicanome ;
      private string lV151Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string AV125Propostawwds_2_dynamicfiltersselector1 ;
      private string AV128Propostawwds_5_propostaresponsaveldocumento1 ;
      private string AV129Propostawwds_6_propostapacienteclientedocumento1 ;
      private string AV130Propostawwds_7_propostaclinicadocumento1 ;
      private string AV131Propostawwds_8_conveniocategoriadescricao1 ;
      private string AV133Propostawwds_10_dynamicfiltersselector2 ;
      private string AV136Propostawwds_13_propostaresponsaveldocumento2 ;
      private string AV137Propostawwds_14_propostapacienteclientedocumento2 ;
      private string AV138Propostawwds_15_propostaclinicadocumento2 ;
      private string AV139Propostawwds_16_conveniocategoriadescricao2 ;
      private string AV141Propostawwds_18_dynamicfiltersselector3 ;
      private string AV144Propostawwds_21_propostaresponsaveldocumento3 ;
      private string AV145Propostawwds_22_propostapacienteclientedocumento3 ;
      private string AV146Propostawwds_23_propostaclinicadocumento3 ;
      private string AV147Propostawwds_24_conveniocategoriadescricao3 ;
      private string AV149Propostawwds_26_tfpropostaclinicanome_sel ;
      private string AV148Propostawwds_25_tfpropostaclinicanome ;
      private string AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ;
      private string AV151Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV124Propostawwds_1_filterfulltext ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV64AuxText ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_titlescategories ;
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
      private GXCombobox cmbavDmusuariopendenteaprovacao ;
      private GXCombobox cmbPropostaStatus ;
      private GxSimpleCollection<string> AV51TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV86Context ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV56DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV150Propostawwds_27_tfpropostastatus_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] H005214_A376ProcedimentosMedicosId ;
      private bool[] H005214_n376ProcedimentosMedicosId ;
      private int[] H005214_A493ConvenioCategoriaId ;
      private bool[] H005214_n493ConvenioCategoriaId ;
      private int[] H005214_A504PropostaPacienteClienteId ;
      private bool[] H005214_n504PropostaPacienteClienteId ;
      private int[] H005214_A553PropostaResponsavelId ;
      private bool[] H005214_n553PropostaResponsavelId ;
      private int[] H005214_A642PropostaClinicaId ;
      private bool[] H005214_n642PropostaClinicaId ;
      private short[] H005214_A328PropostaCratedBy ;
      private bool[] H005214_n328PropostaCratedBy ;
      private string[] H005214_A494ConvenioCategoriaDescricao ;
      private bool[] H005214_n494ConvenioCategoriaDescricao ;
      private string[] H005214_A652PropostaClinicaDocumento ;
      private bool[] H005214_n652PropostaClinicaDocumento ;
      private string[] H005214_A540PropostaPacienteClienteDocumento ;
      private bool[] H005214_n540PropostaPacienteClienteDocumento ;
      private string[] H005214_A580PropostaResponsavelDocumento ;
      private bool[] H005214_n580PropostaResponsavelDocumento ;
      private string[] H005214_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H005214_n505PropostaPacienteClienteRazaoSocial ;
      private string[] H005214_A329PropostaStatus ;
      private bool[] H005214_n329PropostaStatus ;
      private string[] H005214_A377ProcedimentosMedicosNome ;
      private bool[] H005214_n377ProcedimentosMedicosNome ;
      private string[] H005214_A643PropostaClinicaNome ;
      private bool[] H005214_n643PropostaClinicaNome ;
      private decimal[] H005214_A788PropostaMaiorValorRecomendado ;
      private bool[] H005214_n788PropostaMaiorValorRecomendado ;
      private short[] H005214_A784PropostaMaiorScore_F ;
      private bool[] H005214_n784PropostaMaiorScore_F ;
      private short[] H005214_A655PropostaQtdDocumentoPendente_F ;
      private bool[] H005214_n655PropostaQtdDocumentoPendente_F ;
      private int[] H005214_A323PropostaId ;
      private bool[] H005214_n323PropostaId ;
      private int[] H005214_A649PropostaMaxReembolsoId_F ;
      private bool[] H005214_n649PropostaMaxReembolsoId_F ;
      private int[] H005214_A40000GXC1 ;
      private bool[] H005214_n40000GXC1 ;
      private long[] H005227_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005214( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV150Propostawwds_27_tfpropostastatus_sels ,
                                              string AV125Propostawwds_2_dynamicfiltersselector1 ,
                                              short AV126Propostawwds_3_dynamicfiltersoperator1 ,
                                              string AV128Propostawwds_5_propostaresponsaveldocumento1 ,
                                              string AV129Propostawwds_6_propostapacienteclientedocumento1 ,
                                              string AV130Propostawwds_7_propostaclinicadocumento1 ,
                                              string AV131Propostawwds_8_conveniocategoriadescricao1 ,
                                              bool AV132Propostawwds_9_dynamicfiltersenabled2 ,
                                              string AV133Propostawwds_10_dynamicfiltersselector2 ,
                                              short AV134Propostawwds_11_dynamicfiltersoperator2 ,
                                              string AV136Propostawwds_13_propostaresponsaveldocumento2 ,
                                              string AV137Propostawwds_14_propostapacienteclientedocumento2 ,
                                              string AV138Propostawwds_15_propostaclinicadocumento2 ,
                                              string AV139Propostawwds_16_conveniocategoriadescricao2 ,
                                              bool AV140Propostawwds_17_dynamicfiltersenabled3 ,
                                              string AV141Propostawwds_18_dynamicfiltersselector3 ,
                                              short AV142Propostawwds_19_dynamicfiltersoperator3 ,
                                              string AV144Propostawwds_21_propostaresponsaveldocumento3 ,
                                              string AV145Propostawwds_22_propostapacienteclientedocumento3 ,
                                              string AV146Propostawwds_23_propostaclinicadocumento3 ,
                                              string AV147Propostawwds_24_conveniocategoriadescricao3 ,
                                              string AV149Propostawwds_26_tfpropostaclinicanome_sel ,
                                              string AV148Propostawwds_25_tfpropostaclinicanome ,
                                              int AV150Propostawwds_27_tfpropostastatus_sels_Count ,
                                              string AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV151Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              bool AV6WWPContext_gxTpr_Iscliente ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A643PropostaClinicaNome ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short A328PropostaCratedBy ,
                                              short AV6WWPContext_gxTpr_Secuserclienteid ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc ,
                                              string AV124Propostawwds_1_filterfulltext ,
                                              short A784PropostaMaiorScore_F ,
                                              decimal A788PropostaMaiorValorRecomendado ,
                                              int AV127Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV135Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              int AV143Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              short AV153Propostawwds_30_tfpropostamaiorscore_f ,
                                              short AV154Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              decimal AV155Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              decimal AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[96];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaCratedBy, T3.ConvenioCategoriaDescricao, T6.ClienteDocumento AS PropostaClinicaDocumento, T4.ClienteDocumento AS PropostaPacienteClienteDocumento, T5.ClienteDocumento AS PropostaResponsavelDocumento, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaStatus, T2.ProcedimentosMedicosNome, T6.ClienteRazaoSocial AS PropostaClinicaNome, COALESCE( T7.PropostaMaiorValorRecomendado, 0) AS PropostaMaiorValorRecomendado, COALESCE( T7.PropostaMaiorScore_F, 0) AS PropostaMaiorScore_F, COALESCE( T8.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F, T1.PropostaId, COALESCE( T9.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, COALESCE( T10.GXC1, 0) AS GXC1";
         sFromString = " FROM (((((((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaClinicaId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T12.PropostaSerasaScoreUltimaData_F, 0) > COALESCE( T13.PropostaSerasaScoreUltimaData_F, 0) THEN COALESCE( T12.PropostaSerasaScoreUltimaData_F, 0) ELSE COALESCE( T13.PropostaSerasaScoreUltimaData_F, 0) END AS PropostaMaiorScore_F, T11.PropostaId, CASE  WHEN COALESCE( T14.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) > COALESCE( T15.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) THEN COALESCE( T14.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) ELSE COALESCE( T15.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) END AS PropostaMaiorValorRecomendado FROM ((((Proposta T11 LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T12 ON T12.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F,";
         sFromString += " T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T13 ON T13.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T14 ON T14.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T15 ON T15.ClienteId = T11.PropostaPacienteClienteId) ) T7 ON T7.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*)";
         sFromString += " AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE (T1.PropostaId = PropostaId) AND (PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T8 ON T8.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovadoresId = :AV86Context__Userid) GROUP BY PropostaId ) T10 ON T10.PropostaId = T1.PropostaId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV124Propostawwds_1_filterfulltext))=0) or ( ( T6.ClienteRazaoSocial like '%' || :lV124Propostawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T4.ClienteRazaoSocial like '%' || :lV124Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaMaiorScore_F, 0),'9999'), 2) like '%' || :lV124Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaMaiorValorRecomendado, 0),'999999999999990.99'), 2) like '%' || :lV124Propostawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 0 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 1 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 2 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 0 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 1 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 2 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV153Propostawwds_30_tfpropostamaiorscore_f = 0) or ( COALESCE( T7.PropostaMaiorScore_F, 0) >= :AV153Propostawwds_30_tfpropostamaiorscore_f))");
         AddWhere(sWhereString, "((:AV154Propostawwds_31_tfpropostamaiorscore_f_to = 0) or ( COALESCE( T7.PropostaMaiorScore_F, 0) <= :AV154Propostawwds_31_tfpropostamaiorscore_f_to))");
         AddWhere(sWhereString, "((:AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = 0) or ( COALESCE( T7.PropostaMaiorValorRecomendado, 0) >= :AV155Propostawwds_32_tfpropostamaiorvalorrecomendado))");
         AddWhere(sWhereString, "((:AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = 0) or ( COALESCE( T7.PropostaMaiorValorRecomendado, 0) <= :AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to))");
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV128Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV128Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV129Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV129Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV130Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV130Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int7[69] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV131Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int7[70] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV131Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int7[71] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV136Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int7[72] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV136Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int7[73] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV137Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int7[74] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV137Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int7[75] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV138Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int7[76] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV138Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int7[77] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV139Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int7[78] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV139Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int7[79] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV144Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int7[80] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV144Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int7[81] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV145Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int7[82] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV145Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int7[83] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV146Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int7[84] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV146Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int7[85] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV147Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int7[86] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV147Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int7[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Propostawwds_26_tfpropostaclinicanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Propostawwds_25_tfpropostaclinicanome)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial like :lV148Propostawwds_25_tfpropostaclinicanome)");
         }
         else
         {
            GXv_int7[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Propostawwds_26_tfpropostaclinicanome_sel)) && ! ( StringUtil.StrCmp(AV149Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial = ( :AV149Propostawwds_26_tfpropostaclinicanome_sel))");
         }
         else
         {
            GXv_int7[89] = 1;
         }
         if ( StringUtil.StrCmp(AV149Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T6.ClienteRazaoSocial))=0))");
         }
         if ( AV150Propostawwds_27_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV150Propostawwds_27_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Propostawwds_28_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV151Propostawwds_28_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[91] = 1;
         }
         if ( StringUtil.StrCmp(AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( AV6WWPContext_gxTpr_Iscliente )
         {
            AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV6WWPCo_1Secuserclienteid)");
         }
         else
         {
            GXv_int7[92] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T6.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T6.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaStatus, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaStatus DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.PropostaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005227( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV150Propostawwds_27_tfpropostastatus_sels ,
                                              string AV125Propostawwds_2_dynamicfiltersselector1 ,
                                              short AV126Propostawwds_3_dynamicfiltersoperator1 ,
                                              string AV128Propostawwds_5_propostaresponsaveldocumento1 ,
                                              string AV129Propostawwds_6_propostapacienteclientedocumento1 ,
                                              string AV130Propostawwds_7_propostaclinicadocumento1 ,
                                              string AV131Propostawwds_8_conveniocategoriadescricao1 ,
                                              bool AV132Propostawwds_9_dynamicfiltersenabled2 ,
                                              string AV133Propostawwds_10_dynamicfiltersselector2 ,
                                              short AV134Propostawwds_11_dynamicfiltersoperator2 ,
                                              string AV136Propostawwds_13_propostaresponsaveldocumento2 ,
                                              string AV137Propostawwds_14_propostapacienteclientedocumento2 ,
                                              string AV138Propostawwds_15_propostaclinicadocumento2 ,
                                              string AV139Propostawwds_16_conveniocategoriadescricao2 ,
                                              bool AV140Propostawwds_17_dynamicfiltersenabled3 ,
                                              string AV141Propostawwds_18_dynamicfiltersselector3 ,
                                              short AV142Propostawwds_19_dynamicfiltersoperator3 ,
                                              string AV144Propostawwds_21_propostaresponsaveldocumento3 ,
                                              string AV145Propostawwds_22_propostapacienteclientedocumento3 ,
                                              string AV146Propostawwds_23_propostaclinicadocumento3 ,
                                              string AV147Propostawwds_24_conveniocategoriadescricao3 ,
                                              string AV149Propostawwds_26_tfpropostaclinicanome_sel ,
                                              string AV148Propostawwds_25_tfpropostaclinicanome ,
                                              int AV150Propostawwds_27_tfpropostastatus_sels_Count ,
                                              string AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV151Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              bool AV6WWPContext_gxTpr_Iscliente ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A643PropostaClinicaNome ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short A328PropostaCratedBy ,
                                              short AV6WWPContext_gxTpr_Secuserclienteid ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc ,
                                              string AV124Propostawwds_1_filterfulltext ,
                                              short A784PropostaMaiorScore_F ,
                                              decimal A788PropostaMaiorValorRecomendado ,
                                              int AV127Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV135Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              int AV143Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              short AV153Propostawwds_30_tfpropostamaiorscore_f ,
                                              short AV154Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              decimal AV155Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              decimal AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[93];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaClinicaId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T12.PropostaSerasaScoreUltimaData_F, 0) > COALESCE( T13.PropostaSerasaScoreUltimaData_F, 0) THEN COALESCE( T12.PropostaSerasaScoreUltimaData_F, 0) ELSE COALESCE( T13.PropostaSerasaScoreUltimaData_F, 0) END AS PropostaMaiorScore_F, T11.PropostaId, CASE  WHEN COALESCE( T14.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) > COALESCE( T15.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) THEN COALESCE( T14.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) ELSE COALESCE( T15.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) END AS PropostaMaiorValorRecomendado FROM ((((Proposta T11 LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T12 ON T12.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F,";
         scmdbuf += " T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T13 ON T13.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T14 ON T14.ClienteId = T11.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (T11.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T15 ON T15.ClienteId = T11.PropostaPacienteClienteId) ) T7 ON T7.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*)";
         scmdbuf += " AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE (T1.PropostaId = PropostaId) AND (PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T8 ON T8.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovadoresId = :AV86Context__Userid) GROUP BY PropostaId ) T10 ON T10.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV124Propostawwds_1_filterfulltext))=0) or ( ( T6.ClienteRazaoSocial like '%' || :lV124Propostawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV124Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T4.ClienteRazaoSocial like '%' || :lV124Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaMaiorScore_F, 0),'9999'), 2) like '%' || :lV124Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaMaiorValorRecomendado, 0),'999999999999990.99'), 2) like '%' || :lV124Propostawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV125Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV127Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV127Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 0 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 1 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV132Propostawwds_9_dynamicfiltersenabled2 and :AV133Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV134Propostawwds_11_dynamicfiltersoperator2 = 2 and ( Not (:AV135Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV135Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 0 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 1 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV140Propostawwds_17_dynamicfiltersenabled3 and :AV141Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV142Propostawwds_19_dynamicfiltersoperator3 = 2 and ( Not (:AV143Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV143Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV153Propostawwds_30_tfpropostamaiorscore_f = 0) or ( COALESCE( T7.PropostaMaiorScore_F, 0) >= :AV153Propostawwds_30_tfpropostamaiorscore_f))");
         AddWhere(sWhereString, "((:AV154Propostawwds_31_tfpropostamaiorscore_f_to = 0) or ( COALESCE( T7.PropostaMaiorScore_F, 0) <= :AV154Propostawwds_31_tfpropostamaiorscore_f_to))");
         AddWhere(sWhereString, "((:AV155Propostawwds_32_tfpropostamaiorvalorrecomendado = 0) or ( COALESCE( T7.PropostaMaiorValorRecomendado, 0) >= :AV155Propostawwds_32_tfpropostamaiorvalorrecomendado))");
         AddWhere(sWhereString, "((:AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to = 0) or ( COALESCE( T7.PropostaMaiorValorRecomendado, 0) <= :AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to))");
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV128Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int9[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV128Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int9[65] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV129Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int9[66] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV129Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int9[67] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV130Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int9[68] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV130Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int9[69] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV131Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int9[70] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV131Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int9[71] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV136Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int9[72] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV136Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int9[73] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV137Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int9[74] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV137Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int9[75] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV138Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int9[76] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV138Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int9[77] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV139Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int9[78] = 1;
         }
         if ( AV132Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV133Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV134Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV139Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int9[79] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV144Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int9[80] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV144Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int9[81] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV145Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int9[82] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV145Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int9[83] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV146Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int9[84] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV146Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int9[85] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV147Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int9[86] = 1;
         }
         if ( AV140Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV142Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV147Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int9[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Propostawwds_26_tfpropostaclinicanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Propostawwds_25_tfpropostaclinicanome)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial like :lV148Propostawwds_25_tfpropostaclinicanome)");
         }
         else
         {
            GXv_int9[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Propostawwds_26_tfpropostaclinicanome_sel)) && ! ( StringUtil.StrCmp(AV149Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial = ( :AV149Propostawwds_26_tfpropostaclinicanome_sel))");
         }
         else
         {
            GXv_int9[89] = 1;
         }
         if ( StringUtil.StrCmp(AV149Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T6.ClienteRazaoSocial))=0))");
         }
         if ( AV150Propostawwds_27_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV150Propostawwds_27_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Propostawwds_28_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV151Propostawwds_28_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int9[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int9[91] = 1;
         }
         if ( StringUtil.StrCmp(AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( AV6WWPContext_gxTpr_Iscliente )
         {
            AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV6WWPCo_1Secuserclienteid)");
         }
         else
         {
            GXv_int9[92] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005214(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (decimal)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] );
               case 1 :
                     return conditional_H005227(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (decimal)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] );
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
          Object[] prmH005214;
          prmH005214 = new Object[] {
          new ParDef("AV86Context__Userid",GXType.Int16,4,0) ,
          new ParDef("AV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV153Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV153Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV154Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV154Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV155Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV155Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("lV128Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV128Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV131Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV131Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV136Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV136Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV137Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV137Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV138Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV138Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV139Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV139Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV144Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV144Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV147Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV147Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV148Propostawwds_25_tfpropostaclinicanome",GXType.VarChar,150,0) ,
          new ParDef("AV149Propostawwds_26_tfpropostaclinicanome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV151Propostawwds_28_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV6WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005227;
          prmH005227 = new Object[] {
          new ParDef("AV86Context__Userid",GXType.Int16,4,0) ,
          new ParDef("AV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV124Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV125Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV132Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV133Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV134Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV135Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV140Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV141Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV142Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV143Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV153Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV153Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV154Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV154Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV155Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV155Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("AV156Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("lV128Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV128Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV131Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV131Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV136Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV136Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV137Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV137Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV138Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV138Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV139Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV139Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV144Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV144Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV147Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV147Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV148Propostawwds_25_tfpropostaclinicanome",GXType.VarChar,150,0) ,
          new ParDef("AV149Propostawwds_26_tfpropostaclinicanome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV151Propostawwds_28_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV152Propostawwds_29_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV6WWPCo_1Secuserclienteid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005214", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005214,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005227", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005227,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
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
                ((decimal[]) buf[28])[0] = rslt.getDecimal(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((short[]) buf[30])[0] = rslt.getShort(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((short[]) buf[32])[0] = rslt.getShort(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
