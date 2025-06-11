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
   public class wppropostasassinaturas : GXDataArea
   {
      public wppropostasassinaturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wppropostasassinaturas( IGxContext context )
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
         nRC_GXsfl_159 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_159"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_159_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_159_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_159_idx = GetPar( "sGXsfl_159_idx");
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
         AV66PropostaResponsavelDocumento1 = GetPar( "PropostaResponsavelDocumento1");
         AV18PropostaPacienteClienteRazaoSocial1 = GetPar( "PropostaPacienteClienteRazaoSocial1");
         AV19PropostaPacienteClienteDocumento1 = GetPar( "PropostaPacienteClienteDocumento1");
         AV67PropostaClinicaDocumento1 = GetPar( "PropostaClinicaDocumento1");
         AV20ContratoNome1 = GetPar( "ContratoNome1");
         AV21ConvenioCategoriaDescricao1 = GetPar( "ConvenioCategoriaDescricao1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV69PropostaResponsavelDocumento2 = GetPar( "PropostaResponsavelDocumento2");
         AV25PropostaPacienteClienteRazaoSocial2 = GetPar( "PropostaPacienteClienteRazaoSocial2");
         AV26PropostaPacienteClienteDocumento2 = GetPar( "PropostaPacienteClienteDocumento2");
         AV70PropostaClinicaDocumento2 = GetPar( "PropostaClinicaDocumento2");
         AV27ContratoNome2 = GetPar( "ContratoNome2");
         AV28ConvenioCategoriaDescricao2 = GetPar( "ConvenioCategoriaDescricao2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV72PropostaResponsavelDocumento3 = GetPar( "PropostaResponsavelDocumento3");
         AV32PropostaPacienteClienteRazaoSocial3 = GetPar( "PropostaPacienteClienteRazaoSocial3");
         AV33PropostaPacienteClienteDocumento3 = GetPar( "PropostaPacienteClienteDocumento3");
         AV73PropostaClinicaDocumento3 = GetPar( "PropostaClinicaDocumento3");
         AV34ContratoNome3 = GetPar( "ContratoNome3");
         AV35ConvenioCategoriaDescricao3 = GetPar( "ConvenioCategoriaDescricao3");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV29DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV74Pgmname = GetPar( "Pgmname");
         AV65PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F1"), "."), 18, MidpointRounding.ToEven));
         AV68PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F2"), "."), 18, MidpointRounding.ToEven));
         AV71PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F3"), "."), 18, MidpointRounding.ToEven));
         AV44TFProcedimentosMedicosNome = GetPar( "TFProcedimentosMedicosNome");
         AV45TFProcedimentosMedicosNome_Sel = GetPar( "TFProcedimentosMedicosNome_Sel");
         AV48TFPropostaValor = NumberUtil.Val( GetPar( "TFPropostaValor"), ".");
         AV49TFPropostaValor_To = NumberUtil.Val( GetPar( "TFPropostaValor_To"), ".");
         AV59TFPropostaPacienteClienteRazaoSocial = GetPar( "TFPropostaPacienteClienteRazaoSocial");
         AV60TFPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFPropostaPacienteClienteRazaoSocial_Sel");
         AV61TFPropostaPacienteClienteDocumento = GetPar( "TFPropostaPacienteClienteDocumento");
         AV62TFPropostaPacienteClienteDocumento_Sel = GetPar( "TFPropostaPacienteClienteDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV51TFPropostaStatus_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV37DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV36DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         PA782( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START782( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wppropostasassinaturas") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO1", AV66PropostaResponsavelDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1", AV18PropostaPacienteClienteRazaoSocial1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1", AV19PropostaPacienteClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO1", AV67PropostaClinicaDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV20ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO1", AV21ConvenioCategoriaDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO2", AV69PropostaResponsavelDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2", AV25PropostaPacienteClienteRazaoSocial2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2", AV26PropostaPacienteClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO2", AV70PropostaClinicaDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV27ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO2", AV28ConvenioCategoriaDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV30DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO3", AV72PropostaResponsavelDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3", AV32PropostaPacienteClienteRazaoSocial3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3", AV33PropostaPacienteClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO3", AV73PropostaClinicaDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV34ContratoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO3", AV35ConvenioCategoriaDescricao3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_159", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_159), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV29DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROCEDIMENTOSMEDICOSNOME", AV44TFProcedimentosMedicosNome);
         GxWebStd.gx_hidden_field( context, "vTFPROCEDIMENTOSMEDICOSNOME_SEL", AV45TFProcedimentosMedicosNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR", StringUtil.LTrim( StringUtil.NToC( AV48TFPropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV49TFPropostaValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV59TFPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV60TFPropostaPacienteClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTEDOCUMENTO", AV61TFPropostaPacienteClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL", AV62TFPropostaPacienteClienteDocumento_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV37DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV36DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
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
            WE782( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT782( ) ;
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
         return formatLink("wppropostasassinaturas")  ;
      }

      public override string GetPgmname( )
      {
         return "WpPropostasAssinaturas" ;
      }

      public override string GetPgmdesc( )
      {
         return " Proposta" ;
      }

      protected void WB780( )
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
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(159), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpPropostasAssinaturas.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_782( true) ;
         }
         else
         {
            wb_table1_43_782( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_782e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_83_782( true) ;
         }
         else
         {
            wb_table2_83_782( false) ;
         }
         return  ;
      }

      protected void wb_table2_83_782e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV30DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_123_782( true) ;
         }
         else
         {
            wb_table3_123_782( false) ;
         }
         return  ;
      }

      protected void wb_table3_123_782e( bool wbgen )
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
            StartGridControl159( ) ;
         }
         if ( wbEnd == 159 )
         {
            wbEnd = 0;
            nRC_GXsfl_159 = (int)(nGXsfl_159_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpPropostasAssinaturas.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
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
         if ( wbEnd == 159 )
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

      protected void START782( )
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
         STRUP780( ) ;
      }

      protected void WS782( )
      {
         START782( ) ;
         EVT782( ) ;
      }

      protected void EVT782( )
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
                              E11782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E18782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23782 ();
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
                              nGXsfl_159_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
                              SubsflControlProps_1592( ) ;
                              AV58Contratos = cgiGet( edtavContratos_Internalname);
                              AssignAttri("", false, edtavContratos_Internalname, AV58Contratos);
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A377ProcedimentosMedicosNome = cgiGet( edtProcedimentosMedicosNome_Internalname);
                              n377ProcedimentosMedicosNome = false;
                              A376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n376ProcedimentosMedicosId = false;
                              A325PropostaDescricao = cgiGet( edtPropostaDescricao_Internalname);
                              n325PropostaDescricao = false;
                              A326PropostaValor = context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".");
                              n326PropostaValor = false;
                              A327PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtPropostaCreatedAt_Internalname), 0);
                              n327PropostaCreatedAt = false;
                              A328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n328PropostaCratedBy = false;
                              A505PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtPropostaPacienteClienteRazaoSocial_Internalname));
                              n505PropostaPacienteClienteRazaoSocial = false;
                              A540PropostaPacienteClienteDocumento = cgiGet( edtPropostaPacienteClienteDocumento_Internalname);
                              n540PropostaPacienteClienteDocumento = false;
                              A541PropostaPacienteContatoEmail = cgiGet( edtPropostaPacienteContatoEmail_Internalname);
                              n541PropostaPacienteContatoEmail = false;
                              cmbPropostaStatus.Name = cmbPropostaStatus_Internalname;
                              cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
                              A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
                              n329PropostaStatus = false;
                              A330PropostaQuantidadeAprovadores = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQuantidadeAprovadores_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n330PropostaQuantidadeAprovadores = false;
                              A345PropostaReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoesPermitidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n345PropostaReprovacoesPermitidas = false;
                              A341PropostaAprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n341PropostaAprovacoes_F = false;
                              A342PropostaReprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n342PropostaReprovacoes_F = false;
                              A343PropostaAprovacoesRestantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoesRestantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24782 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25782 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E26782 ();
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
                                       /* Set Refresh If Propostaresponsaveldocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV66PropostaResponsavelDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18PropostaPacienteClienteRazaoSocial1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV19PropostaPacienteClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV67PropostaClinicaDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV20ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV21ConvenioCategoriaDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV69PropostaResponsavelDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV25PropostaPacienteClienteRazaoSocial2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV26PropostaPacienteClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV70PropostaClinicaDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV27ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV28ConvenioCategoriaDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV72PropostaResponsavelDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV32PropostaPacienteClienteRazaoSocial3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV33PropostaPacienteClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV73PropostaClinicaDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV34ContratoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV35ConvenioCategoriaDescricao3) != 0 )
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

      protected void WE782( )
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

      protected void PA782( )
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
         SubsflControlProps_1592( ) ;
         while ( nGXsfl_159_idx <= nRC_GXsfl_159 )
         {
            sendrow_1592( ) ;
            nGXsfl_159_idx = ((subGrid_Islastpage==1)&&(nGXsfl_159_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_159_idx+1);
            sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
            SubsflControlProps_1592( ) ;
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
                                       string AV66PropostaResponsavelDocumento1 ,
                                       string AV18PropostaPacienteClienteRazaoSocial1 ,
                                       string AV19PropostaPacienteClienteDocumento1 ,
                                       string AV67PropostaClinicaDocumento1 ,
                                       string AV20ContratoNome1 ,
                                       string AV21ConvenioCategoriaDescricao1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV69PropostaResponsavelDocumento2 ,
                                       string AV25PropostaPacienteClienteRazaoSocial2 ,
                                       string AV26PropostaPacienteClienteDocumento2 ,
                                       string AV70PropostaClinicaDocumento2 ,
                                       string AV27ContratoNome2 ,
                                       string AV28ConvenioCategoriaDescricao2 ,
                                       string AV30DynamicFiltersSelector3 ,
                                       short AV31DynamicFiltersOperator3 ,
                                       string AV72PropostaResponsavelDocumento3 ,
                                       string AV32PropostaPacienteClienteRazaoSocial3 ,
                                       string AV33PropostaPacienteClienteDocumento3 ,
                                       string AV73PropostaClinicaDocumento3 ,
                                       string AV34ContratoNome3 ,
                                       string AV35ConvenioCategoriaDescricao3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV29DynamicFiltersEnabled3 ,
                                       string AV74Pgmname ,
                                       int AV65PropostaMaxReembolsoId_F1 ,
                                       int AV68PropostaMaxReembolsoId_F2 ,
                                       int AV71PropostaMaxReembolsoId_F3 ,
                                       string AV44TFProcedimentosMedicosNome ,
                                       string AV45TFProcedimentosMedicosNome_Sel ,
                                       decimal AV48TFPropostaValor ,
                                       decimal AV49TFPropostaValor_To ,
                                       string AV59TFPropostaPacienteClienteRazaoSocial ,
                                       string AV60TFPropostaPacienteClienteRazaoSocial_Sel ,
                                       string AV61TFPropostaPacienteClienteDocumento ,
                                       string AV62TFPropostaPacienteClienteDocumento_Sel ,
                                       GxSimpleCollection<string> AV51TFPropostaStatus_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV37DynamicFiltersIgnoreFirst ,
                                       bool AV36DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF782( ) ;
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
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF782( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV74Pgmname = "WpPropostasAssinaturas";
         edtavContratos_Enabled = 0;
      }

      protected void RF782( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 159;
         /* Execute user event: Refresh */
         E25782 ();
         nGXsfl_159_idx = 1;
         sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
         SubsflControlProps_1592( ) ;
         bGXsfl_159_Refreshing = true;
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
            SubsflControlProps_1592( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A329PropostaStatus ,
                                                 AV113Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                                 AV75Wppropostasassinaturasds_1_filterfulltext ,
                                                 AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                                 AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                                 AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                                 AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                                 AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                                 AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                                 AV83Wppropostasassinaturasds_9_contratonome1 ,
                                                 AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                                 AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                                 AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                                 AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                                 AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                                 AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                                 AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                                 AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                                 AV93Wppropostasassinaturasds_19_contratonome2 ,
                                                 AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                                 AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                                 AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                                 AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                                 AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                                 AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                                 AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                                 AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                                 AV103Wppropostasassinaturasds_29_contratonome3 ,
                                                 AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                                 AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                                 AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                                 AV107Wppropostasassinaturasds_33_tfpropostavalor ,
                                                 AV108Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                                 AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                                 AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                                 AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                                 AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                                 AV113Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                                 A377ProcedimentosMedicosNome ,
                                                 A326PropostaValor ,
                                                 A505PropostaPacienteClienteRazaoSocial ,
                                                 A540PropostaPacienteClienteDocumento ,
                                                 A580PropostaResponsavelDocumento ,
                                                 A652PropostaClinicaDocumento ,
                                                 A228ContratoNome ,
                                                 A494ConvenioCategoriaDescricao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                                 A649PropostaMaxReembolsoId_F ,
                                                 AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                                 AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
            lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
            lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
            lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
            lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
            lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
            lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
            lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
            lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
            lV83Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1), "%", "");
            lV83Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1), "%", "");
            lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
            lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
            lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
            lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
            lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
            lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
            lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
            lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
            lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
            lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
            lV93Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2), "%", "");
            lV93Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2), "%", "");
            lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
            lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
            lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
            lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
            lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
            lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
            lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
            lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
            lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
            lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
            lV103Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3), "%", "");
            lV103Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3), "%", "");
            lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
            lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
            lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
            lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
            lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
            /* Using cursor H00785 */
            pr_default.execute(0, new Object[] {AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV82Wppropostasassinaturasds_8_propostaclinicadocumento1, lV82Wppropostasassinaturasds_8_propostaclinicadocumento1, lV83Wppropostasassinaturasds_9_contratonome1, lV83Wppropostasassinaturasds_9_contratonome1, lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV92Wppropostasassinaturasds_18_propostaclinicadocumento2, lV92Wppropostasassinaturasds_18_propostaclinicadocumento2, lV93Wppropostasassinaturasds_19_contratonome2, lV93Wppropostasassinaturasds_19_contratonome2, lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV102Wppropostasassinaturasds_28_propostaclinicadocumento3, lV102Wppropostasassinaturasds_28_propostaclinicadocumento3, lV103Wppropostasassinaturasds_29_contratonome3, lV103Wppropostasassinaturasds_29_contratonome3, lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV107Wppropostasassinaturasds_33_tfpropostavalor, AV108Wppropostasassinaturasds_34_tfpropostavalor_to, lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_159_idx = 1;
            sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
            SubsflControlProps_1592( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A227ContratoId = H00785_A227ContratoId[0];
               n227ContratoId = H00785_n227ContratoId[0];
               A493ConvenioCategoriaId = H00785_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = H00785_n493ConvenioCategoriaId[0];
               A504PropostaPacienteClienteId = H00785_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H00785_n504PropostaPacienteClienteId[0];
               A553PropostaResponsavelId = H00785_A553PropostaResponsavelId[0];
               n553PropostaResponsavelId = H00785_n553PropostaResponsavelId[0];
               A642PropostaClinicaId = H00785_A642PropostaClinicaId[0];
               n642PropostaClinicaId = H00785_n642PropostaClinicaId[0];
               A494ConvenioCategoriaDescricao = H00785_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H00785_n494ConvenioCategoriaDescricao[0];
               A228ContratoNome = H00785_A228ContratoNome[0];
               n228ContratoNome = H00785_n228ContratoNome[0];
               A652PropostaClinicaDocumento = H00785_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H00785_n652PropostaClinicaDocumento[0];
               A580PropostaResponsavelDocumento = H00785_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H00785_n580PropostaResponsavelDocumento[0];
               A345PropostaReprovacoesPermitidas = H00785_A345PropostaReprovacoesPermitidas[0];
               n345PropostaReprovacoesPermitidas = H00785_n345PropostaReprovacoesPermitidas[0];
               A329PropostaStatus = H00785_A329PropostaStatus[0];
               n329PropostaStatus = H00785_n329PropostaStatus[0];
               A541PropostaPacienteContatoEmail = H00785_A541PropostaPacienteContatoEmail[0];
               n541PropostaPacienteContatoEmail = H00785_n541PropostaPacienteContatoEmail[0];
               A540PropostaPacienteClienteDocumento = H00785_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H00785_n540PropostaPacienteClienteDocumento[0];
               A505PropostaPacienteClienteRazaoSocial = H00785_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H00785_n505PropostaPacienteClienteRazaoSocial[0];
               A328PropostaCratedBy = H00785_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H00785_n328PropostaCratedBy[0];
               A327PropostaCreatedAt = H00785_A327PropostaCreatedAt[0];
               n327PropostaCreatedAt = H00785_n327PropostaCreatedAt[0];
               A326PropostaValor = H00785_A326PropostaValor[0];
               n326PropostaValor = H00785_n326PropostaValor[0];
               A325PropostaDescricao = H00785_A325PropostaDescricao[0];
               n325PropostaDescricao = H00785_n325PropostaDescricao[0];
               A376ProcedimentosMedicosId = H00785_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = H00785_n376ProcedimentosMedicosId[0];
               A377ProcedimentosMedicosNome = H00785_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H00785_n377ProcedimentosMedicosNome[0];
               A323PropostaId = H00785_A323PropostaId[0];
               n323PropostaId = H00785_n323PropostaId[0];
               A649PropostaMaxReembolsoId_F = H00785_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H00785_n649PropostaMaxReembolsoId_F[0];
               A342PropostaReprovacoes_F = H00785_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = H00785_n342PropostaReprovacoes_F[0];
               A341PropostaAprovacoes_F = H00785_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = H00785_n341PropostaAprovacoes_F[0];
               A330PropostaQuantidadeAprovadores = H00785_A330PropostaQuantidadeAprovadores[0];
               n330PropostaQuantidadeAprovadores = H00785_n330PropostaQuantidadeAprovadores[0];
               A228ContratoNome = H00785_A228ContratoNome[0];
               n228ContratoNome = H00785_n228ContratoNome[0];
               A494ConvenioCategoriaDescricao = H00785_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H00785_n494ConvenioCategoriaDescricao[0];
               A541PropostaPacienteContatoEmail = H00785_A541PropostaPacienteContatoEmail[0];
               n541PropostaPacienteContatoEmail = H00785_n541PropostaPacienteContatoEmail[0];
               A540PropostaPacienteClienteDocumento = H00785_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H00785_n540PropostaPacienteClienteDocumento[0];
               A505PropostaPacienteClienteRazaoSocial = H00785_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H00785_n505PropostaPacienteClienteRazaoSocial[0];
               A580PropostaResponsavelDocumento = H00785_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H00785_n580PropostaResponsavelDocumento[0];
               A652PropostaClinicaDocumento = H00785_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H00785_n652PropostaClinicaDocumento[0];
               A377ProcedimentosMedicosNome = H00785_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H00785_n377ProcedimentosMedicosNome[0];
               A649PropostaMaxReembolsoId_F = H00785_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H00785_n649PropostaMaxReembolsoId_F[0];
               A341PropostaAprovacoes_F = H00785_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = H00785_n341PropostaAprovacoes_F[0];
               A342PropostaReprovacoes_F = H00785_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = H00785_n342PropostaReprovacoes_F[0];
               A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
               /* Execute user event: Grid.Load */
               E26782 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 159;
            WB780( ) ;
         }
         bGXsfl_159_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes782( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
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
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV113Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                              AV75Wppropostasassinaturasds_1_filterfulltext ,
                                              AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                              AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                              AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                              AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                              AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                              AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                              AV83Wppropostasassinaturasds_9_contratonome1 ,
                                              AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                              AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                              AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                              AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                              AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                              AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                              AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                              AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                              AV93Wppropostasassinaturasds_19_contratonome2 ,
                                              AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                              AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                              AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                              AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                              AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                              AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                              AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                              AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                              AV103Wppropostasassinaturasds_29_contratonome3 ,
                                              AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                              AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                              AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                              AV107Wppropostasassinaturasds_33_tfpropostavalor ,
                                              AV108Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                              AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                              AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                              AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                              AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                              AV113Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                              A377ProcedimentosMedicosNome ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A580PropostaResponsavelDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                              AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV83Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV83Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV93Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV93Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV103Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV103Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
         lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
         lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
         /* Using cursor H00789 */
         pr_default.execute(1, new Object[] {AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_1_filterfulltext, lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV82Wppropostasassinaturasds_8_propostaclinicadocumento1, lV82Wppropostasassinaturasds_8_propostaclinicadocumento1, lV83Wppropostasassinaturasds_9_contratonome1, lV83Wppropostasassinaturasds_9_contratonome1, lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV92Wppropostasassinaturasds_18_propostaclinicadocumento2, lV92Wppropostasassinaturasds_18_propostaclinicadocumento2, lV93Wppropostasassinaturasds_19_contratonome2, lV93Wppropostasassinaturasds_19_contratonome2, lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV102Wppropostasassinaturasds_28_propostaclinicadocumento3, lV102Wppropostasassinaturasds_28_propostaclinicadocumento3, lV103Wppropostasassinaturasds_29_contratonome3, lV103Wppropostasassinaturasds_29_contratonome3, lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV107Wppropostasassinaturasds_33_tfpropostavalor, AV108Wppropostasassinaturasds_34_tfpropostavalor_to, lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel});
         GRID_nRecordCount = H00789_AGRID_nRecordCount[0];
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
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV74Pgmname = "WpPropostasAssinaturas";
         edtavContratos_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaPacienteClienteDocumento_Enabled = 0;
         edtPropostaPacienteContatoEmail_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtPropostaQuantidadeAprovadores_Enabled = 0;
         edtPropostaReprovacoesPermitidas_Enabled = 0;
         edtPropostaAprovacoes_F_Enabled = 0;
         edtPropostaReprovacoes_F_Enabled = 0;
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP780( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24782 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_159 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_159"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
               AV65PropostaMaxReembolsoId_F1 = 0;
               AssignAttri("", false, "AV65PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0));
            }
            else
            {
               AV65PropostaMaxReembolsoId_F1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV65PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0));
            }
            AV66PropostaResponsavelDocumento1 = cgiGet( edtavPropostaresponsaveldocumento1_Internalname);
            AssignAttri("", false, "AV66PropostaResponsavelDocumento1", AV66PropostaResponsavelDocumento1);
            AV18PropostaPacienteClienteRazaoSocial1 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial1_Internalname));
            AssignAttri("", false, "AV18PropostaPacienteClienteRazaoSocial1", AV18PropostaPacienteClienteRazaoSocial1);
            AV19PropostaPacienteClienteDocumento1 = cgiGet( edtavPropostapacienteclientedocumento1_Internalname);
            AssignAttri("", false, "AV19PropostaPacienteClienteDocumento1", AV19PropostaPacienteClienteDocumento1);
            AV67PropostaClinicaDocumento1 = cgiGet( edtavPropostaclinicadocumento1_Internalname);
            AssignAttri("", false, "AV67PropostaClinicaDocumento1", AV67PropostaClinicaDocumento1);
            AV20ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV20ContratoNome1", AV20ContratoNome1);
            AV21ConvenioCategoriaDescricao1 = cgiGet( edtavConveniocategoriadescricao1_Internalname);
            AssignAttri("", false, "AV21ConvenioCategoriaDescricao1", AV21ConvenioCategoriaDescricao1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F2");
               GX_FocusControl = edtavPropostamaxreembolsoid_f2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV68PropostaMaxReembolsoId_F2 = 0;
               AssignAttri("", false, "AV68PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0));
            }
            else
            {
               AV68PropostaMaxReembolsoId_F2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV68PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0));
            }
            AV69PropostaResponsavelDocumento2 = cgiGet( edtavPropostaresponsaveldocumento2_Internalname);
            AssignAttri("", false, "AV69PropostaResponsavelDocumento2", AV69PropostaResponsavelDocumento2);
            AV25PropostaPacienteClienteRazaoSocial2 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial2_Internalname));
            AssignAttri("", false, "AV25PropostaPacienteClienteRazaoSocial2", AV25PropostaPacienteClienteRazaoSocial2);
            AV26PropostaPacienteClienteDocumento2 = cgiGet( edtavPropostapacienteclientedocumento2_Internalname);
            AssignAttri("", false, "AV26PropostaPacienteClienteDocumento2", AV26PropostaPacienteClienteDocumento2);
            AV70PropostaClinicaDocumento2 = cgiGet( edtavPropostaclinicadocumento2_Internalname);
            AssignAttri("", false, "AV70PropostaClinicaDocumento2", AV70PropostaClinicaDocumento2);
            AV27ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV27ContratoNome2", AV27ContratoNome2);
            AV28ConvenioCategoriaDescricao2 = cgiGet( edtavConveniocategoriadescricao2_Internalname);
            AssignAttri("", false, "AV28ConvenioCategoriaDescricao2", AV28ConvenioCategoriaDescricao2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV30DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F3");
               GX_FocusControl = edtavPropostamaxreembolsoid_f3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV71PropostaMaxReembolsoId_F3 = 0;
               AssignAttri("", false, "AV71PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0));
            }
            else
            {
               AV71PropostaMaxReembolsoId_F3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV71PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0));
            }
            AV72PropostaResponsavelDocumento3 = cgiGet( edtavPropostaresponsaveldocumento3_Internalname);
            AssignAttri("", false, "AV72PropostaResponsavelDocumento3", AV72PropostaResponsavelDocumento3);
            AV32PropostaPacienteClienteRazaoSocial3 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial3_Internalname));
            AssignAttri("", false, "AV32PropostaPacienteClienteRazaoSocial3", AV32PropostaPacienteClienteRazaoSocial3);
            AV33PropostaPacienteClienteDocumento3 = cgiGet( edtavPropostapacienteclientedocumento3_Internalname);
            AssignAttri("", false, "AV33PropostaPacienteClienteDocumento3", AV33PropostaPacienteClienteDocumento3);
            AV73PropostaClinicaDocumento3 = cgiGet( edtavPropostaclinicadocumento3_Internalname);
            AssignAttri("", false, "AV73PropostaClinicaDocumento3", AV73PropostaClinicaDocumento3);
            AV34ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV34ContratoNome3", AV34ContratoNome3);
            AV35ConvenioCategoriaDescricao3 = cgiGet( edtavConveniocategoriadescricao3_Internalname);
            AssignAttri("", false, "AV35ConvenioCategoriaDescricao3", AV35ConvenioCategoriaDescricao3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV66PropostaResponsavelDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18PropostaPacienteClienteRazaoSocial1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV19PropostaPacienteClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV67PropostaClinicaDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV20ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV21ConvenioCategoriaDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV69PropostaResponsavelDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV25PropostaPacienteClienteRazaoSocial2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV26PropostaPacienteClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV70PropostaClinicaDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV27ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV28ConvenioCategoriaDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV72PropostaResponsavelDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV32PropostaPacienteClienteRazaoSocial3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV33PropostaPacienteClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV73PropostaClinicaDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV34ContratoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV35ConvenioCategoriaDescricao3) != 0 )
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
         E24782 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24782( )
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
         AV16DynamicFiltersSelector1 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25782( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
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
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTRATONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            if ( AV29DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
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
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV74Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         cmbPropostaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbPropostaStatus_Internalname, "Columnheaderclass", cmbPropostaStatus_Columnheaderclass, !bGXsfl_159_Refreshing);
         AV75Wppropostasassinaturasds_1_filterfulltext = AV15FilterFullText;
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV65PropostaMaxReembolsoId_F1;
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV66PropostaResponsavelDocumento1;
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV19PropostaPacienteClienteDocumento1;
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV67PropostaClinicaDocumento1;
         AV83Wppropostasassinaturasds_9_contratonome1 = AV20ContratoNome1;
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV21ConvenioCategoriaDescricao1;
         AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV68PropostaMaxReembolsoId_F2;
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV69PropostaResponsavelDocumento2;
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV25PropostaPacienteClienteRazaoSocial2;
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV26PropostaPacienteClienteDocumento2;
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV70PropostaClinicaDocumento2;
         AV93Wppropostasassinaturasds_19_contratonome2 = AV27ContratoNome2;
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV28ConvenioCategoriaDescricao2;
         AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV71PropostaMaxReembolsoId_F3;
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV72PropostaResponsavelDocumento3;
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV32PropostaPacienteClienteRazaoSocial3;
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV33PropostaPacienteClienteDocumento3;
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV73PropostaClinicaDocumento3;
         AV103Wppropostasassinaturasds_29_contratonome3 = AV34ContratoNome3;
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV107Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV108Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV59TFPropostaPacienteClienteRazaoSocial;
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV60TFPropostaPacienteClienteRazaoSocial_Sel;
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV61TFPropostaPacienteClienteDocumento;
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV62TFPropostaPacienteClienteDocumento_Sel;
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12782( )
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
            AV53PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E13782( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14782( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProcedimentosMedicosNome") == 0 )
            {
               AV44TFProcedimentosMedicosNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFProcedimentosMedicosNome", AV44TFProcedimentosMedicosNome);
               AV45TFProcedimentosMedicosNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFProcedimentosMedicosNome_Sel", AV45TFProcedimentosMedicosNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaValor") == 0 )
            {
               AV48TFPropostaValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV48TFPropostaValor", StringUtil.LTrimStr( AV48TFPropostaValor, 18, 2));
               AV49TFPropostaValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV49TFPropostaValor_To", StringUtil.LTrimStr( AV49TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaPacienteClienteRazaoSocial") == 0 )
            {
               AV59TFPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV59TFPropostaPacienteClienteRazaoSocial", AV59TFPropostaPacienteClienteRazaoSocial);
               AV60TFPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFPropostaPacienteClienteRazaoSocial_Sel", AV60TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaPacienteClienteDocumento") == 0 )
            {
               AV61TFPropostaPacienteClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV61TFPropostaPacienteClienteDocumento", AV61TFPropostaPacienteClienteDocumento);
               AV62TFPropostaPacienteClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV62TFPropostaPacienteClienteDocumento_Sel", AV62TFPropostaPacienteClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaStatus") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
      }

      private void E26782( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV58Contratos = "<i class=\"fas fa-file-contract\"></i>";
         AssignAttri("", false, edtavContratos_Internalname, AV58Contratos);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpcontratosassinatura"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtavContratos_Link = formatLink("wpcontratosassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
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
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else
         {
            cmbPropostaStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 159;
         }
         sendrow_1592( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_159_Refreshing )
         {
            DoAjaxLoad(159, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E19782( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15782( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E20782( )
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

      protected void E21782( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16782( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E22782( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E17782( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV66PropostaResponsavelDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19PropostaPacienteClienteDocumento1, AV67PropostaClinicaDocumento1, AV20ContratoNome1, AV21ConvenioCategoriaDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV69PropostaResponsavelDocumento2, AV25PropostaPacienteClienteRazaoSocial2, AV26PropostaPacienteClienteDocumento2, AV70PropostaClinicaDocumento2, AV27ContratoNome2, AV28ConvenioCategoriaDescricao2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV72PropostaResponsavelDocumento3, AV32PropostaPacienteClienteRazaoSocial3, AV33PropostaPacienteClienteDocumento3, AV73PropostaClinicaDocumento3, AV34ContratoNome3, AV35ConvenioCategoriaDescricao3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV74Pgmname, AV65PropostaMaxReembolsoId_F1, AV68PropostaMaxReembolsoId_F2, AV71PropostaMaxReembolsoId_F3, AV44TFProcedimentosMedicosNome, AV45TFProcedimentosMedicosNome_Sel, AV48TFPropostaValor, AV49TFPropostaValor_To, AV59TFPropostaPacienteClienteRazaoSocial, AV60TFPropostaPacienteClienteRazaoSocial_Sel, AV61TFPropostaPacienteClienteDocumento, AV62TFPropostaPacienteClienteDocumento_Sel, AV51TFPropostaStatus_Sels, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E23782( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E11782( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpPropostasAssinaturasFilters")) + "," + UrlEncode(StringUtil.RTrim(AV74Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpPropostasAssinaturasFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpPropostasAssinaturasFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV74Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV10GridState.FromXml(AV42ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E18782( )
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
         new wppropostasassinaturasexport(context ).execute( out  AV38ExcelFilename, out  AV39ErrorMessage) ;
         if ( StringUtil.StrCmp(AV38ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV38ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV39ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
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
         edtavPropostapacienteclienterazaosocial1_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial1_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento1_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento1_Visible), 5, 0), true);
         edtavPropostaclinicadocumento1_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento1_Visible), 5, 0), true);
         edtavContratonome1_Visible = 0;
         AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial1_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial1_Visible), 5, 0), true);
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            edtavContratonome1_Visible = 1;
            AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
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
         edtavPropostapacienteclienterazaosocial2_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial2_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento2_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
         edtavPropostaclinicadocumento2_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
         edtavContratonome2_Visible = 0;
         AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
         edtavConveniocategoriadescricao2_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f2_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial2_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento2_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         edtavPropostapacienteclienterazaosocial3_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial3_Visible), 5, 0), true);
         edtavPropostapacienteclientedocumento3_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento3_Visible), 5, 0), true);
         edtavPropostaclinicadocumento3_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento3_Visible), 5, 0), true);
         edtavContratonome3_Visible = 0;
         AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
         edtavConveniocategoriadescricao3_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f3_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial3_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento3_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV68PropostaMaxReembolsoId_F2 = 0;
         AssignAttri("", false, "AV68PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         AV30DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AV71PropostaMaxReembolsoId_F3 = 0;
         AssignAttri("", false, "AV71PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpPropostasAssinaturasFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV44TFProcedimentosMedicosNome = "";
         AssignAttri("", false, "AV44TFProcedimentosMedicosNome", AV44TFProcedimentosMedicosNome);
         AV45TFProcedimentosMedicosNome_Sel = "";
         AssignAttri("", false, "AV45TFProcedimentosMedicosNome_Sel", AV45TFProcedimentosMedicosNome_Sel);
         AV48TFPropostaValor = 0;
         AssignAttri("", false, "AV48TFPropostaValor", StringUtil.LTrimStr( AV48TFPropostaValor, 18, 2));
         AV49TFPropostaValor_To = 0;
         AssignAttri("", false, "AV49TFPropostaValor_To", StringUtil.LTrimStr( AV49TFPropostaValor_To, 18, 2));
         AV59TFPropostaPacienteClienteRazaoSocial = "";
         AssignAttri("", false, "AV59TFPropostaPacienteClienteRazaoSocial", AV59TFPropostaPacienteClienteRazaoSocial);
         AV60TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV60TFPropostaPacienteClienteRazaoSocial_Sel", AV60TFPropostaPacienteClienteRazaoSocial_Sel);
         AV61TFPropostaPacienteClienteDocumento = "";
         AssignAttri("", false, "AV61TFPropostaPacienteClienteDocumento", AV61TFPropostaPacienteClienteDocumento);
         AV62TFPropostaPacienteClienteDocumento_Sel = "";
         AssignAttri("", false, "AV62TFPropostaPacienteClienteDocumento_Sel", AV62TFPropostaPacienteClienteDocumento_Sel);
         AV51TFPropostaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
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
         AV65PropostaMaxReembolsoId_F1 = 0;
         AssignAttri("", false, "AV65PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0));
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
         if ( StringUtil.StrCmp(AV40Session.Get(AV74Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV74Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV40Session.Get(AV74Pgmname+"GridState"), null, "", "");
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
         AV114GXV1 = 1;
         while ( AV114GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV114GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV44TFProcedimentosMedicosNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFProcedimentosMedicosNome", AV44TFProcedimentosMedicosNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV45TFProcedimentosMedicosNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFProcedimentosMedicosNome_Sel", AV45TFProcedimentosMedicosNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV48TFPropostaValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV48TFPropostaValor", StringUtil.LTrimStr( AV48TFPropostaValor, 18, 2));
               AV49TFPropostaValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV49TFPropostaValor_To", StringUtil.LTrimStr( AV49TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV59TFPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFPropostaPacienteClienteRazaoSocial", AV59TFPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV60TFPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFPropostaPacienteClienteRazaoSocial_Sel", AV60TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV61TFPropostaPacienteClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFPropostaPacienteClienteDocumento", AV61TFPropostaPacienteClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV62TFPropostaPacienteClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFPropostaPacienteClienteDocumento_Sel", AV62TFPropostaPacienteClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            AV114GXV1 = (int)(AV114GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProcedimentosMedicosNome_Sel)),  AV45TFProcedimentosMedicosNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFPropostaPacienteClienteRazaoSocial_Sel)),  AV60TFPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFPropostaPacienteClienteDocumento_Sel)),  AV62TFPropostaPacienteClienteDocumento_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV51TFPropostaStatus_Sels.Count==0),  AV50TFPropostaStatus_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProcedimentosMedicosNome)),  AV44TFProcedimentosMedicosNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFPropostaPacienteClienteRazaoSocial)),  AV59TFPropostaPacienteClienteRazaoSocial, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFPropostaPacienteClienteDocumento)),  AV61TFPropostaPacienteClienteDocumento, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+((Convert.ToDecimal(0)==AV48TFPropostaValor) ? "" : StringUtil.Str( AV48TFPropostaValor, 18, 2))+"|"+GXt_char5+"|"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((Convert.ToDecimal(0)==AV49TFPropostaValor_To) ? "" : StringUtil.Str( AV49TFPropostaValor_To, 18, 2))+"|||";
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
               AV65PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV65PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV66PropostaResponsavelDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV66PropostaResponsavelDocumento1", AV66PropostaResponsavelDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18PropostaPacienteClienteRazaoSocial1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18PropostaPacienteClienteRazaoSocial1", AV18PropostaPacienteClienteRazaoSocial1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19PropostaPacienteClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19PropostaPacienteClienteDocumento1", AV19PropostaPacienteClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV67PropostaClinicaDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV67PropostaClinicaDocumento1", AV67PropostaClinicaDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20ContratoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ContratoNome1", AV20ContratoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV21ConvenioCategoriaDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ConvenioCategoriaDescricao1", AV21ConvenioCategoriaDescricao1);
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
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV68PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV68PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV69PropostaResponsavelDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV69PropostaResponsavelDocumento2", AV69PropostaResponsavelDocumento2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25PropostaPacienteClienteRazaoSocial2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25PropostaPacienteClienteRazaoSocial2", AV25PropostaPacienteClienteRazaoSocial2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26PropostaPacienteClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26PropostaPacienteClienteDocumento2", AV26PropostaPacienteClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV70PropostaClinicaDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV70PropostaClinicaDocumento2", AV70PropostaClinicaDocumento2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV27ContratoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27ContratoNome2", AV27ContratoNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV28ConvenioCategoriaDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28ConvenioCategoriaDescricao2", AV28ConvenioCategoriaDescricao2);
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
                  AV29DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV71PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV71PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV72PropostaResponsavelDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV72PropostaResponsavelDocumento3", AV72PropostaResponsavelDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV32PropostaPacienteClienteRazaoSocial3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32PropostaPacienteClienteRazaoSocial3", AV32PropostaPacienteClienteRazaoSocial3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV33PropostaPacienteClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV33PropostaPacienteClienteDocumento3", AV33PropostaPacienteClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV73PropostaClinicaDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV73PropostaClinicaDocumento3", AV73PropostaClinicaDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV34ContratoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34ContratoNome3", AV34ContratoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV35ConvenioCategoriaDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35ConvenioCategoriaDescricao3", AV35ConvenioCategoriaDescricao3);
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
         if ( AV36DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV40Session.Get(AV74Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROCEDIMENTOSMEDICOSNOME",  "Procedimento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProcedimentosMedicosNome)),  0,  AV44TFProcedimentosMedicosNome,  AV44TFProcedimentosMedicosNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProcedimentosMedicosNome_Sel)),  AV45TFProcedimentosMedicosNome_Sel,  AV45TFProcedimentosMedicosNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV48TFPropostaValor)&&(Convert.ToDecimal(0)==AV49TFPropostaValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV48TFPropostaValor, 18, 2)),  ((Convert.ToDecimal(0)==AV48TFPropostaValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV49TFPropostaValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV49TFPropostaValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFPropostaValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFPropostaPacienteClienteRazaoSocial)),  0,  AV59TFPropostaPacienteClienteRazaoSocial,  AV59TFPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFPropostaPacienteClienteRazaoSocial_Sel)),  AV60TFPropostaPacienteClienteRazaoSocial_Sel,  AV60TFPropostaPacienteClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPACIENTECLIENTEDOCUMENTO",  "CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFPropostaPacienteClienteDocumento)),  0,  AV61TFPropostaPacienteClienteDocumento,  AV61TFPropostaPacienteClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFPropostaPacienteClienteDocumento_Sel)),  AV62TFPropostaPacienteClienteDocumento_Sel,  AV62TFPropostaPacienteClienteDocumento_Sel) ;
         AV57AuxText = ((AV51TFPropostaStatus_Sels.Count==1) ? "["+((string)AV51TFPropostaStatus_Sels.Item(1))+"]" : "V�rios valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTASTATUS_SEL",  "Status",  !(AV51TFPropostaStatus_Sels.Count==0),  0,  AV51TFPropostaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV57AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV57AuxText, "[PENDENTE]", "Pendente aprova��o"), "[EM_ANALISE]", "Em an�lise"), "[APROVADO]", "Aprovado"), "[REJEITADO]", "Rejeitado"), "[REVISAO]", "Revis�o"), "[CANCELADO]", "Cancelado"), "[AGUARDANDO_ASSINATURA]", "Aguardando assinatura"), "[AnaliseReprovada]", "An�lise reprovada")),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV74Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV37DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV65PropostaMaxReembolsoId_F1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV65PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV65PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV65PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV66PropostaResponsavelDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV17DynamicFiltersOperator1,  AV66PropostaResponsavelDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV66PropostaResponsavelDocumento1, "Cont�m"+" "+AV66PropostaResponsavelDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PropostaPacienteClienteRazaoSocial1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV17DynamicFiltersOperator1,  AV18PropostaPacienteClienteRazaoSocial1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV18PropostaPacienteClienteRazaoSocial1, "Cont�m"+" "+AV18PropostaPacienteClienteRazaoSocial1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PropostaPacienteClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV17DynamicFiltersOperator1,  AV19PropostaPacienteClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV19PropostaPacienteClienteDocumento1, "Cont�m"+" "+AV19PropostaPacienteClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV67PropostaClinicaDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV17DynamicFiltersOperator1,  AV67PropostaClinicaDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV67PropostaClinicaDocumento1, "Cont�m"+" "+AV67PropostaClinicaDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV17DynamicFiltersOperator1,  AV20ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV20ContratoNome1, "Cont�m"+" "+AV20ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConvenioCategoriaDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descri��o",  AV17DynamicFiltersOperator1,  AV21ConvenioCategoriaDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV21ConvenioCategoriaDescricao1, "Cont�m"+" "+AV21ConvenioCategoriaDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV68PropostaMaxReembolsoId_F2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV24DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV68PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV68PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV68PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69PropostaResponsavelDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV24DynamicFiltersOperator2,  AV69PropostaResponsavelDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV69PropostaResponsavelDocumento2, "Cont�m"+" "+AV69PropostaResponsavelDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PropostaPacienteClienteRazaoSocial2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV24DynamicFiltersOperator2,  AV25PropostaPacienteClienteRazaoSocial2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV25PropostaPacienteClienteRazaoSocial2, "Cont�m"+" "+AV25PropostaPacienteClienteRazaoSocial2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PropostaPacienteClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV24DynamicFiltersOperator2,  AV26PropostaPacienteClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV26PropostaPacienteClienteDocumento2, "Cont�m"+" "+AV26PropostaPacienteClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70PropostaClinicaDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV24DynamicFiltersOperator2,  AV70PropostaClinicaDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV70PropostaClinicaDocumento2, "Cont�m"+" "+AV70PropostaClinicaDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV24DynamicFiltersOperator2,  AV27ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV27ContratoNome2, "Cont�m"+" "+AV27ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConvenioCategoriaDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descri��o",  AV24DynamicFiltersOperator2,  AV28ConvenioCategoriaDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV28ConvenioCategoriaDescricao2, "Cont�m"+" "+AV28ConvenioCategoriaDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV29DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV30DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV71PropostaMaxReembolsoId_F3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV31DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV72PropostaResponsavelDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV31DynamicFiltersOperator3,  AV72PropostaResponsavelDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV72PropostaResponsavelDocumento3, "Cont�m"+" "+AV72PropostaResponsavelDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PropostaPacienteClienteRazaoSocial3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV31DynamicFiltersOperator3,  AV32PropostaPacienteClienteRazaoSocial3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV32PropostaPacienteClienteRazaoSocial3, "Cont�m"+" "+AV32PropostaPacienteClienteRazaoSocial3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV33PropostaPacienteClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV31DynamicFiltersOperator3,  AV33PropostaPacienteClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV33PropostaPacienteClienteDocumento3, "Cont�m"+" "+AV33PropostaPacienteClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV73PropostaClinicaDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV31DynamicFiltersOperator3,  AV73PropostaClinicaDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV73PropostaClinicaDocumento3, "Cont�m"+" "+AV73PropostaClinicaDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV31DynamicFiltersOperator3,  AV34ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV34ContratoNome3, "Cont�m"+" "+AV34ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ConvenioCategoriaDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descri��o",  AV31DynamicFiltersOperator3,  AV35ConvenioCategoriaDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV35ConvenioCategoriaDescricao3, "Cont�m"+" "+AV35ConvenioCategoriaDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV74Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Proposta";
         AV40Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_123_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostamaxreembolsoid_f3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostamaxreembolsoid_f3_Internalname, "Proposta Max Reembolso Id_F3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71PropostaMaxReembolsoId_F3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV71PropostaMaxReembolsoId_F3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV71PropostaMaxReembolsoId_F3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f3_Visible, edtavPropostamaxreembolsoid_f3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento3_Internalname, "Proposta Responsavel Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento3_Internalname, AV72PropostaResponsavelDocumento3, StringUtil.RTrim( context.localUtil.Format( AV72PropostaResponsavelDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento3_Visible, edtavPropostaresponsaveldocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial3_Internalname, "Proposta Paciente Cliente Razao Social3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial3_Internalname, AV32PropostaPacienteClienteRazaoSocial3, StringUtil.RTrim( context.localUtil.Format( AV32PropostaPacienteClienteRazaoSocial3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial3_Visible, edtavPropostapacienteclienterazaosocial3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento3_Internalname, "Proposta Paciente Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento3_Internalname, AV33PropostaPacienteClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV33PropostaPacienteClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento3_Visible, edtavPropostapacienteclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento3_Internalname, "Proposta Clinica Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento3_Internalname, AV73PropostaClinicaDocumento3, StringUtil.RTrim( context.localUtil.Format( AV73PropostaClinicaDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento3_Visible, edtavPropostaclinicadocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV34ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV34ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao3_Internalname, "Convenio Categoria Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao3_Internalname, AV35ConvenioCategoriaDescricao3, StringUtil.RTrim( context.localUtil.Format( AV35ConvenioCategoriaDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao3_Visible, edtavConveniocategoriadescricao3_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPropostasAssinaturas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_123_782e( true) ;
         }
         else
         {
            wb_table3_123_782e( false) ;
         }
      }

      protected void wb_table2_83_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostamaxreembolsoid_f2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostamaxreembolsoid_f2_Internalname, "Proposta Max Reembolso Id_F2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68PropostaMaxReembolsoId_F2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV68PropostaMaxReembolsoId_F2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV68PropostaMaxReembolsoId_F2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f2_Visible, edtavPropostamaxreembolsoid_f2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento2_Internalname, "Proposta Responsavel Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento2_Internalname, AV69PropostaResponsavelDocumento2, StringUtil.RTrim( context.localUtil.Format( AV69PropostaResponsavelDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento2_Visible, edtavPropostaresponsaveldocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial2_Internalname, "Proposta Paciente Cliente Razao Social2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial2_Internalname, AV25PropostaPacienteClienteRazaoSocial2, StringUtil.RTrim( context.localUtil.Format( AV25PropostaPacienteClienteRazaoSocial2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial2_Visible, edtavPropostapacienteclienterazaosocial2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento2_Internalname, "Proposta Paciente Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento2_Internalname, AV26PropostaPacienteClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV26PropostaPacienteClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento2_Visible, edtavPropostapacienteclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento2_Internalname, "Proposta Clinica Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento2_Internalname, AV70PropostaClinicaDocumento2, StringUtil.RTrim( context.localUtil.Format( AV70PropostaClinicaDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento2_Visible, edtavPropostaclinicadocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV27ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV27ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao2_Internalname, "Convenio Categoria Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao2_Internalname, AV28ConvenioCategoriaDescricao2, StringUtil.RTrim( context.localUtil.Format( AV28ConvenioCategoriaDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao2_Visible, edtavConveniocategoriadescricao2_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPropostasAssinaturas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPropostasAssinaturas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_83_782e( true) ;
         }
         else
         {
            wb_table2_83_782e( false) ;
         }
      }

      protected void wb_table1_43_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpPropostasAssinaturas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65PropostaMaxReembolsoId_F1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV65PropostaMaxReembolsoId_F1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV65PropostaMaxReembolsoId_F1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f1_Visible, edtavPropostamaxreembolsoid_f1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento1_Internalname, "Proposta Responsavel Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento1_Internalname, AV66PropostaResponsavelDocumento1, StringUtil.RTrim( context.localUtil.Format( AV66PropostaResponsavelDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento1_Visible, edtavPropostaresponsaveldocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial1_Internalname, "Proposta Paciente Cliente Razao Social1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial1_Internalname, AV18PropostaPacienteClienteRazaoSocial1, StringUtil.RTrim( context.localUtil.Format( AV18PropostaPacienteClienteRazaoSocial1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial1_Visible, edtavPropostapacienteclienterazaosocial1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento1_Internalname, "Proposta Paciente Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento1_Internalname, AV19PropostaPacienteClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV19PropostaPacienteClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento1_Visible, edtavPropostapacienteclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento1_Internalname, "Proposta Clinica Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento1_Internalname, AV67PropostaClinicaDocumento1, StringUtil.RTrim( context.localUtil.Format( AV67PropostaClinicaDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento1_Visible, edtavPropostaclinicadocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV20ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV20ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao1_Internalname, "Convenio Categoria Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao1_Internalname, AV21ConvenioCategoriaDescricao1, StringUtil.RTrim( context.localUtil.Format( AV21ConvenioCategoriaDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao1_Visible, edtavConveniocategoriadescricao1_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPropostasAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPropostasAssinaturas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPropostasAssinaturas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_782e( true) ;
         }
         else
         {
            wb_table1_43_782e( false) ;
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
         PA782( ) ;
         WS782( ) ;
         WE782( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101927369", true, true);
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
         context.AddJavascriptSource("wppropostasassinaturas.js", "?20256101927369", false, true);
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

      protected void SubsflControlProps_1592( )
      {
         edtavContratos_Internalname = "vCONTRATOS_"+sGXsfl_159_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_159_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_159_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_159_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_159_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_159_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_159_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_159_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_159_idx;
         edtPropostaPacienteClienteDocumento_Internalname = "PROPOSTAPACIENTECLIENTEDOCUMENTO_"+sGXsfl_159_idx;
         edtPropostaPacienteContatoEmail_Internalname = "PROPOSTAPACIENTECONTATOEMAIL_"+sGXsfl_159_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_159_idx;
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES_"+sGXsfl_159_idx;
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS_"+sGXsfl_159_idx;
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F_"+sGXsfl_159_idx;
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F_"+sGXsfl_159_idx;
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F_"+sGXsfl_159_idx;
      }

      protected void SubsflControlProps_fel_1592( )
      {
         edtavContratos_Internalname = "vCONTRATOS_"+sGXsfl_159_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_159_fel_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_159_fel_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_159_fel_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_159_fel_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_159_fel_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_159_fel_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_159_fel_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_159_fel_idx;
         edtPropostaPacienteClienteDocumento_Internalname = "PROPOSTAPACIENTECLIENTEDOCUMENTO_"+sGXsfl_159_fel_idx;
         edtPropostaPacienteContatoEmail_Internalname = "PROPOSTAPACIENTECONTATOEMAIL_"+sGXsfl_159_fel_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_159_fel_idx;
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES_"+sGXsfl_159_fel_idx;
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS_"+sGXsfl_159_fel_idx;
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F_"+sGXsfl_159_fel_idx;
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F_"+sGXsfl_159_fel_idx;
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F_"+sGXsfl_159_fel_idx;
      }

      protected void sendrow_1592( )
      {
         sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
         SubsflControlProps_1592( ) ;
         WB780( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_159_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_159_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_159_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_159_idx + "',159)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavContratos_Internalname,StringUtil.RTrim( AV58Contratos),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavContratos_Link,(string)"",(string)"Contratos",(string)"",(string)edtavContratos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavContratos_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosNome_Internalname,(string)A377ProcedimentosMedicosNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaDescricao_Internalname,(string)A325PropostaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaCreatedAt_Internalname,context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaCratedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A328PropostaCratedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaCratedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteClienteRazaoSocial_Internalname,(string)A505PropostaPacienteClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A505PropostaPacienteClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaPacienteClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteClienteDocumento_Internalname,(string)A540PropostaPacienteClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaPacienteClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteContatoEmail_Internalname,(string)A541PropostaPacienteContatoEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A541PropostaPacienteContatoEmail,(string)"",(string)"",(string)"",(string)edtPropostaPacienteContatoEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPropostaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROPOSTASTATUS_" + sGXsfl_159_idx;
               cmbPropostaStatus.Name = GXCCtl;
               cmbPropostaStatus.WebTags = "";
               cmbPropostaStatus.addItem("PENDENTE", "Pendente aprova��o", 0);
               cmbPropostaStatus.addItem("EM_ANALISE", "Em an�lise", 0);
               cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
               cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbPropostaStatus.addItem("REVISAO", "Revis�o", 0);
               cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
               cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
               cmbPropostaStatus.addItem("AnaliseReprovada", "An�lise reprovada", 0);
               if ( cmbPropostaStatus.ItemCount > 0 )
               {
                  A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
                  n329PropostaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaStatus,(string)cmbPropostaStatus_Internalname,StringUtil.RTrim( A329PropostaStatus),(short)1,(string)cmbPropostaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbPropostaStatus_Columnclass,(string)cmbPropostaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), !bGXsfl_159_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaQuantidadeAprovadores_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaQuantidadeAprovadores_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaReprovacoesPermitidas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaReprovacoesPermitidas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaAprovacoes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaAprovacoes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaReprovacoes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaReprovacoes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaAprovacoesRestantes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaAprovacoesRestantes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes782( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_159_idx = ((subGrid_Islastpage==1)&&(nGXsfl_159_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_159_idx+1);
            sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
            SubsflControlProps_1592( ) ;
         }
         /* End function sendrow_1592 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Contrato Nome", 0);
         cmbavDynamicfiltersselector1.addItem("CONVENIOCATEGORIADESCRICAO", "Descri��o", 0);
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
         cmbavDynamicfiltersselector2.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector2.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector2.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Contrato Nome", 0);
         cmbavDynamicfiltersselector2.addItem("CONVENIOCATEGORIADESCRICAO", "Descri��o", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Contrato Nome", 0);
         cmbavDynamicfiltersselector3.addItem("CONVENIOCATEGORIADESCRICAO", "Descri��o", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "PROPOSTASTATUS_" + sGXsfl_159_idx;
         cmbPropostaStatus.Name = GXCCtl;
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprova��o", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em an�lise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revis�o", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "An�lise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl159( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"159\">") ;
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
            context.SendWebValue( "Procedimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Procedimentos Medicos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Descri��o") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created At") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Crated By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprovados") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reprovacoes Permitidas") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprova��es") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reprova��es") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprova��es restantes") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58Contratos)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavContratos_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavContratos_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A377ProcedimentosMedicosNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A325PropostaDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A505PropostaPacienteClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A540PropostaPacienteClienteDocumento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A541PropostaPacienteContatoEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329PropostaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbPropostaStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ".", ""))));
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
         edtavPropostapacienteclienterazaosocial1_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1";
         cellFilter_propostapacienteclienterazaosocial1_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL1_CELL";
         edtavPropostapacienteclientedocumento1_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO1";
         cellFilter_propostapacienteclientedocumento1_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO1_CELL";
         edtavPropostaclinicadocumento1_Internalname = "vPROPOSTACLINICADOCUMENTO1";
         cellFilter_propostaclinicadocumento1_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO1_CELL";
         edtavContratonome1_Internalname = "vCONTRATONOME1";
         cellFilter_contratonome1_cell_Internalname = "FILTER_CONTRATONOME1_CELL";
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
         edtavPropostapacienteclienterazaosocial2_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2";
         cellFilter_propostapacienteclienterazaosocial2_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL2_CELL";
         edtavPropostapacienteclientedocumento2_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO2";
         cellFilter_propostapacienteclientedocumento2_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO2_CELL";
         edtavPropostaclinicadocumento2_Internalname = "vPROPOSTACLINICADOCUMENTO2";
         cellFilter_propostaclinicadocumento2_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO2_CELL";
         edtavContratonome2_Internalname = "vCONTRATONOME2";
         cellFilter_contratonome2_cell_Internalname = "FILTER_CONTRATONOME2_CELL";
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
         edtavPropostapacienteclienterazaosocial3_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3";
         cellFilter_propostapacienteclienterazaosocial3_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL3_CELL";
         edtavPropostapacienteclientedocumento3_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO3";
         cellFilter_propostapacienteclientedocumento3_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO3_CELL";
         edtavPropostaclinicadocumento3_Internalname = "vPROPOSTACLINICADOCUMENTO3";
         cellFilter_propostaclinicadocumento3_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO3_CELL";
         edtavContratonome3_Internalname = "vCONTRATONOME3";
         cellFilter_contratonome3_cell_Internalname = "FILTER_CONTRATONOME3_CELL";
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
         edtavContratos_Internalname = "vCONTRATOS";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME";
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID";
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO";
         edtPropostaValor_Internalname = "PROPOSTAVALOR";
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT";
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY";
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtPropostaPacienteClienteDocumento_Internalname = "PROPOSTAPACIENTECLIENTEDOCUMENTO";
         edtPropostaPacienteContatoEmail_Internalname = "PROPOSTAPACIENTECONTATOEMAIL";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES";
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS";
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F";
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F";
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F";
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
         edtPropostaAprovacoesRestantes_F_Jsonclick = "";
         edtPropostaReprovacoes_F_Jsonclick = "";
         edtPropostaAprovacoes_F_Jsonclick = "";
         edtPropostaReprovacoesPermitidas_Jsonclick = "";
         edtPropostaQuantidadeAprovadores_Jsonclick = "";
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus_Columnclass = "WWColumn";
         edtPropostaPacienteContatoEmail_Jsonclick = "";
         edtPropostaPacienteClienteDocumento_Jsonclick = "";
         edtPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtPropostaCratedBy_Jsonclick = "";
         edtPropostaCreatedAt_Jsonclick = "";
         edtPropostaValor_Jsonclick = "";
         edtPropostaDescricao_Jsonclick = "";
         edtProcedimentosMedicosId_Jsonclick = "";
         edtProcedimentosMedicosNome_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtavContratos_Jsonclick = "";
         edtavContratos_Link = "";
         edtavContratos_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavConveniocategoriadescricao1_Jsonclick = "";
         edtavConveniocategoriadescricao1_Enabled = 1;
         edtavContratonome1_Jsonclick = "";
         edtavContratonome1_Enabled = 1;
         edtavPropostaclinicadocumento1_Jsonclick = "";
         edtavPropostaclinicadocumento1_Enabled = 1;
         edtavPropostapacienteclientedocumento1_Jsonclick = "";
         edtavPropostapacienteclientedocumento1_Enabled = 1;
         edtavPropostapacienteclienterazaosocial1_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial1_Enabled = 1;
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
         edtavContratonome2_Jsonclick = "";
         edtavContratonome2_Enabled = 1;
         edtavPropostaclinicadocumento2_Jsonclick = "";
         edtavPropostaclinicadocumento2_Enabled = 1;
         edtavPropostapacienteclientedocumento2_Jsonclick = "";
         edtavPropostapacienteclientedocumento2_Enabled = 1;
         edtavPropostapacienteclienterazaosocial2_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial2_Enabled = 1;
         edtavPropostaresponsaveldocumento2_Jsonclick = "";
         edtavPropostaresponsaveldocumento2_Enabled = 1;
         edtavPropostamaxreembolsoid_f2_Jsonclick = "";
         edtavPropostamaxreembolsoid_f2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavConveniocategoriadescricao3_Jsonclick = "";
         edtavConveniocategoriadescricao3_Enabled = 1;
         edtavContratonome3_Jsonclick = "";
         edtavContratonome3_Enabled = 1;
         edtavPropostaclinicadocumento3_Jsonclick = "";
         edtavPropostaclinicadocumento3_Enabled = 1;
         edtavPropostapacienteclientedocumento3_Jsonclick = "";
         edtavPropostapacienteclientedocumento3_Enabled = 1;
         edtavPropostapacienteclienterazaosocial3_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial3_Enabled = 1;
         edtavPropostaresponsaveldocumento3_Jsonclick = "";
         edtavPropostaresponsaveldocumento3_Enabled = 1;
         edtavPropostamaxreembolsoid_f3_Jsonclick = "";
         edtavPropostamaxreembolsoid_f3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavConveniocategoriadescricao3_Visible = 1;
         edtavContratonome3_Visible = 1;
         edtavPropostaclinicadocumento3_Visible = 1;
         edtavPropostapacienteclientedocumento3_Visible = 1;
         edtavPropostapacienteclienterazaosocial3_Visible = 1;
         edtavPropostaresponsaveldocumento3_Visible = 1;
         edtavPropostamaxreembolsoid_f3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavConveniocategoriadescricao2_Visible = 1;
         edtavContratonome2_Visible = 1;
         edtavPropostaclinicadocumento2_Visible = 1;
         edtavPropostapacienteclientedocumento2_Visible = 1;
         edtavPropostapacienteclienterazaosocial2_Visible = 1;
         edtavPropostaresponsaveldocumento2_Visible = 1;
         edtavPropostamaxreembolsoid_f2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavConveniocategoriadescricao1_Visible = 1;
         edtavContratonome1_Visible = 1;
         edtavPropostaclinicadocumento1_Visible = 1;
         edtavPropostapacienteclientedocumento1_Visible = 1;
         edtavPropostapacienteclienterazaosocial1_Visible = 1;
         edtavPropostaresponsaveldocumento1_Visible = 1;
         edtavPropostamaxreembolsoid_f1_Visible = 1;
         cmbPropostaStatus_Columnheaderclass = "";
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         edtPropostaReprovacoes_F_Enabled = 0;
         edtPropostaAprovacoes_F_Enabled = 0;
         edtPropostaReprovacoesPermitidas_Enabled = 0;
         edtPropostaQuantidadeAprovadores_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtPropostaPacienteContatoEmail_Enabled = 0;
         edtPropostaPacienteClienteDocumento_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
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
         Ddo_grid_Format = "|18.2|||";
         Ddo_grid_Datalistproc = "WpPropostasAssinaturasGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||PENDENTE:Pendente aprova��o,EM_ANALISE:Em an�lise,APROVADO:Aprovado,REJEITADO:Rejeitado,REVISAO:Revis�o,CANCELADO:Cancelado,AGUARDANDO_ASSINATURA:Aguardando assinatura,AnaliseReprovada:An�lise reprovada";
         Ddo_grid_Allowmultipleselection = "||||T";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T||T|T|T";
         Ddo_grid_Filterisrange = "|T|||";
         Ddo_grid_Filtertype = "Character|Numeric|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "2:ProcedimentosMedicosNome|5:PropostaValor|8:PropostaPacienteClienteRazaoSocial|9:PropostaPacienteClienteDocumento|11:PropostaStatus";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E26782","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbPropostaStatus"},{"av":"A329PropostaStatus","fld":"PROPOSTASTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV58Contratos","fld":"vCONTRATOS","type":"char"},{"av":"edtavContratos_Link","ctrl":"vCONTRATOS","prop":"Link"},{"av":"cmbPropostaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E19782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E20782","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E21782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E22782","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E23782","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11782","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV41ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E18782","iparms":[{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV66PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV67PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV20ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV21ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV69PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV25PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV26PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV27ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV28ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV72PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV32PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV33PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV73PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV34ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV35ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV65PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV68PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV45TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV48TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV60TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaPacienteClienteDocumento","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO","type":"svchar"},{"av":"AV62TFPropostaPacienteClienteDocumento_Sel","fld":"vTFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID","""{"handler":"Valid_Procedimentosmedicosid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAQUANTIDADEAPROVADORES","""{"handler":"Valid_Propostaquantidadeaprovadores","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAAPROVACOES_F","""{"handler":"Valid_Propostaaprovacoes_f","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Propostaaprovacoesrestantes_f","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV66PropostaResponsavelDocumento1 = "";
         AV18PropostaPacienteClienteRazaoSocial1 = "";
         AV19PropostaPacienteClienteDocumento1 = "";
         AV67PropostaClinicaDocumento1 = "";
         AV20ContratoNome1 = "";
         AV21ConvenioCategoriaDescricao1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV69PropostaResponsavelDocumento2 = "";
         AV25PropostaPacienteClienteRazaoSocial2 = "";
         AV26PropostaPacienteClienteDocumento2 = "";
         AV70PropostaClinicaDocumento2 = "";
         AV27ContratoNome2 = "";
         AV28ConvenioCategoriaDescricao2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV72PropostaResponsavelDocumento3 = "";
         AV32PropostaPacienteClienteRazaoSocial3 = "";
         AV33PropostaPacienteClienteDocumento3 = "";
         AV73PropostaClinicaDocumento3 = "";
         AV34ContratoNome3 = "";
         AV35ConvenioCategoriaDescricao3 = "";
         AV74Pgmname = "";
         AV44TFProcedimentosMedicosNome = "";
         AV45TFProcedimentosMedicosNome_Sel = "";
         AV59TFPropostaPacienteClienteRazaoSocial = "";
         AV60TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV61TFPropostaPacienteClienteDocumento = "";
         AV62TFPropostaPacienteClienteDocumento_Sel = "";
         AV51TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50TFPropostaStatus_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         AV58Contratos = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A541PropostaPacienteContatoEmail = "";
         A329PropostaStatus = "";
         AV113Wppropostasassinaturasds_39_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV75Wppropostasassinaturasds_1_filterfulltext = "";
         lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         lV83Wppropostasassinaturasds_9_contratonome1 = "";
         lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         lV93Wppropostasassinaturasds_19_contratonome2 = "";
         lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         lV103Wppropostasassinaturasds_29_contratonome3 = "";
         lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         AV75Wppropostasassinaturasds_1_filterfulltext = "";
         AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = "";
         AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         AV83Wppropostasassinaturasds_9_contratonome1 = "";
         AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = "";
         AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         AV93Wppropostasassinaturasds_19_contratonome2 = "";
         AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = "";
         AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         AV103Wppropostasassinaturasds_29_contratonome3 = "";
         AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = "";
         AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = "";
         AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = "";
         AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         A580PropostaResponsavelDocumento = "";
         A652PropostaClinicaDocumento = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         H00785_A227ContratoId = new int[1] ;
         H00785_n227ContratoId = new bool[] {false} ;
         H00785_A493ConvenioCategoriaId = new int[1] ;
         H00785_n493ConvenioCategoriaId = new bool[] {false} ;
         H00785_A504PropostaPacienteClienteId = new int[1] ;
         H00785_n504PropostaPacienteClienteId = new bool[] {false} ;
         H00785_A553PropostaResponsavelId = new int[1] ;
         H00785_n553PropostaResponsavelId = new bool[] {false} ;
         H00785_A642PropostaClinicaId = new int[1] ;
         H00785_n642PropostaClinicaId = new bool[] {false} ;
         H00785_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H00785_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H00785_A228ContratoNome = new string[] {""} ;
         H00785_n228ContratoNome = new bool[] {false} ;
         H00785_A652PropostaClinicaDocumento = new string[] {""} ;
         H00785_n652PropostaClinicaDocumento = new bool[] {false} ;
         H00785_A580PropostaResponsavelDocumento = new string[] {""} ;
         H00785_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H00785_A345PropostaReprovacoesPermitidas = new short[1] ;
         H00785_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         H00785_A329PropostaStatus = new string[] {""} ;
         H00785_n329PropostaStatus = new bool[] {false} ;
         H00785_A541PropostaPacienteContatoEmail = new string[] {""} ;
         H00785_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         H00785_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H00785_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H00785_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00785_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H00785_A328PropostaCratedBy = new short[1] ;
         H00785_n328PropostaCratedBy = new bool[] {false} ;
         H00785_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00785_n327PropostaCreatedAt = new bool[] {false} ;
         H00785_A326PropostaValor = new decimal[1] ;
         H00785_n326PropostaValor = new bool[] {false} ;
         H00785_A325PropostaDescricao = new string[] {""} ;
         H00785_n325PropostaDescricao = new bool[] {false} ;
         H00785_A376ProcedimentosMedicosId = new int[1] ;
         H00785_n376ProcedimentosMedicosId = new bool[] {false} ;
         H00785_A377ProcedimentosMedicosNome = new string[] {""} ;
         H00785_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H00785_A323PropostaId = new int[1] ;
         H00785_n323PropostaId = new bool[] {false} ;
         H00785_A649PropostaMaxReembolsoId_F = new int[1] ;
         H00785_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         H00785_A342PropostaReprovacoes_F = new short[1] ;
         H00785_n342PropostaReprovacoes_F = new bool[] {false} ;
         H00785_A341PropostaAprovacoes_F = new short[1] ;
         H00785_n341PropostaAprovacoes_F = new bool[] {false} ;
         H00785_A330PropostaQuantidadeAprovadores = new short[1] ;
         H00785_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         H00789_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV38ExcelFilename = "";
         AV39ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV57AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppropostasassinaturas__default(),
            new Object[][] {
                new Object[] {
               H00785_A227ContratoId, H00785_n227ContratoId, H00785_A493ConvenioCategoriaId, H00785_n493ConvenioCategoriaId, H00785_A504PropostaPacienteClienteId, H00785_n504PropostaPacienteClienteId, H00785_A553PropostaResponsavelId, H00785_n553PropostaResponsavelId, H00785_A642PropostaClinicaId, H00785_n642PropostaClinicaId,
               H00785_A494ConvenioCategoriaDescricao, H00785_n494ConvenioCategoriaDescricao, H00785_A228ContratoNome, H00785_n228ContratoNome, H00785_A652PropostaClinicaDocumento, H00785_n652PropostaClinicaDocumento, H00785_A580PropostaResponsavelDocumento, H00785_n580PropostaResponsavelDocumento, H00785_A345PropostaReprovacoesPermitidas, H00785_n345PropostaReprovacoesPermitidas,
               H00785_A329PropostaStatus, H00785_n329PropostaStatus, H00785_A541PropostaPacienteContatoEmail, H00785_n541PropostaPacienteContatoEmail, H00785_A540PropostaPacienteClienteDocumento, H00785_n540PropostaPacienteClienteDocumento, H00785_A505PropostaPacienteClienteRazaoSocial, H00785_n505PropostaPacienteClienteRazaoSocial, H00785_A328PropostaCratedBy, H00785_n328PropostaCratedBy,
               H00785_A327PropostaCreatedAt, H00785_n327PropostaCreatedAt, H00785_A326PropostaValor, H00785_n326PropostaValor, H00785_A325PropostaDescricao, H00785_n325PropostaDescricao, H00785_A376ProcedimentosMedicosId, H00785_n376ProcedimentosMedicosId, H00785_A377ProcedimentosMedicosNome, H00785_n377ProcedimentosMedicosNome,
               H00785_A323PropostaId, H00785_A649PropostaMaxReembolsoId_F, H00785_n649PropostaMaxReembolsoId_F, H00785_A342PropostaReprovacoes_F, H00785_n342PropostaReprovacoes_F, H00785_A341PropostaAprovacoes_F, H00785_n341PropostaAprovacoes_F, H00785_A330PropostaQuantidadeAprovadores, H00785_n330PropostaQuantidadeAprovadores
               }
               , new Object[] {
               H00789_AGRID_nRecordCount
               }
            }
         );
         AV74Pgmname = "WpPropostasAssinaturas";
         /* GeneXus formulas. */
         AV74Pgmname = "WpPropostasAssinaturas";
         edtavContratos_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A328PropostaCratedBy ;
      private short A330PropostaQuantidadeAprovadores ;
      private short A345PropostaReprovacoesPermitidas ;
      private short A341PropostaAprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short A343PropostaAprovacoesRestantes_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 ;
      private short AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 ;
      private short AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_159 ;
      private int nGXsfl_159_idx=1 ;
      private int AV65PropostaMaxReembolsoId_F1 ;
      private int AV68PropostaMaxReembolsoId_F2 ;
      private int AV71PropostaMaxReembolsoId_F3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A323PropostaId ;
      private int A376ProcedimentosMedicosId ;
      private int subGrid_Islastpage ;
      private int edtavContratos_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV113Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ;
      private int AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ;
      private int A649PropostaMaxReembolsoId_F ;
      private int AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ;
      private int AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 ;
      private int A227ContratoId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int edtPropostaId_Enabled ;
      private int edtProcedimentosMedicosNome_Enabled ;
      private int edtProcedimentosMedicosId_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtPropostaValor_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int edtPropostaCratedBy_Enabled ;
      private int edtPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtPropostaPacienteClienteDocumento_Enabled ;
      private int edtPropostaPacienteContatoEmail_Enabled ;
      private int edtPropostaQuantidadeAprovadores_Enabled ;
      private int edtPropostaReprovacoesPermitidas_Enabled ;
      private int edtPropostaAprovacoes_F_Enabled ;
      private int edtPropostaReprovacoes_F_Enabled ;
      private int edtPropostaAprovacoesRestantes_F_Enabled ;
      private int AV53PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPropostamaxreembolsoid_f1_Visible ;
      private int edtavPropostaresponsaveldocumento1_Visible ;
      private int edtavPropostapacienteclienterazaosocial1_Visible ;
      private int edtavPropostapacienteclientedocumento1_Visible ;
      private int edtavPropostaclinicadocumento1_Visible ;
      private int edtavContratonome1_Visible ;
      private int edtavConveniocategoriadescricao1_Visible ;
      private int edtavPropostamaxreembolsoid_f2_Visible ;
      private int edtavPropostaresponsaveldocumento2_Visible ;
      private int edtavPropostapacienteclienterazaosocial2_Visible ;
      private int edtavPropostapacienteclientedocumento2_Visible ;
      private int edtavPropostaclinicadocumento2_Visible ;
      private int edtavContratonome2_Visible ;
      private int edtavConveniocategoriadescricao2_Visible ;
      private int edtavPropostamaxreembolsoid_f3_Visible ;
      private int edtavPropostaresponsaveldocumento3_Visible ;
      private int edtavPropostapacienteclienterazaosocial3_Visible ;
      private int edtavPropostapacienteclientedocumento3_Visible ;
      private int edtavPropostaclinicadocumento3_Visible ;
      private int edtavContratonome3_Visible ;
      private int edtavConveniocategoriadescricao3_Visible ;
      private int AV114GXV1 ;
      private int edtavPropostamaxreembolsoid_f3_Enabled ;
      private int edtavPropostaresponsaveldocumento3_Enabled ;
      private int edtavPropostapacienteclienterazaosocial3_Enabled ;
      private int edtavPropostapacienteclientedocumento3_Enabled ;
      private int edtavPropostaclinicadocumento3_Enabled ;
      private int edtavContratonome3_Enabled ;
      private int edtavConveniocategoriadescricao3_Enabled ;
      private int edtavPropostamaxreembolsoid_f2_Enabled ;
      private int edtavPropostaresponsaveldocumento2_Enabled ;
      private int edtavPropostapacienteclienterazaosocial2_Enabled ;
      private int edtavPropostapacienteclientedocumento2_Enabled ;
      private int edtavPropostaclinicadocumento2_Enabled ;
      private int edtavContratonome2_Enabled ;
      private int edtavConveniocategoriadescricao2_Enabled ;
      private int edtavPropostamaxreembolsoid_f1_Enabled ;
      private int edtavPropostaresponsaveldocumento1_Enabled ;
      private int edtavPropostapacienteclienterazaosocial1_Enabled ;
      private int edtavPropostapacienteclientedocumento1_Enabled ;
      private int edtavPropostaclinicadocumento1_Enabled ;
      private int edtavContratonome1_Enabled ;
      private int edtavConveniocategoriadescricao1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV48TFPropostaValor ;
      private decimal AV49TFPropostaValor_To ;
      private decimal A326PropostaValor ;
      private decimal AV107Wppropostasassinaturasds_33_tfpropostavalor ;
      private decimal AV108Wppropostasassinaturasds_34_tfpropostavalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_159_idx="0001" ;
      private string AV74Pgmname ;
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
      private string AV58Contratos ;
      private string edtavContratos_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtProcedimentosMedicosNome_Internalname ;
      private string edtProcedimentosMedicosId_Internalname ;
      private string edtPropostaDescricao_Internalname ;
      private string edtPropostaValor_Internalname ;
      private string edtPropostaCreatedAt_Internalname ;
      private string edtPropostaCratedBy_Internalname ;
      private string edtPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtPropostaPacienteClienteDocumento_Internalname ;
      private string edtPropostaPacienteContatoEmail_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string edtPropostaQuantidadeAprovadores_Internalname ;
      private string edtPropostaReprovacoesPermitidas_Internalname ;
      private string edtPropostaAprovacoes_F_Internalname ;
      private string edtPropostaReprovacoes_F_Internalname ;
      private string edtPropostaAprovacoesRestantes_F_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavPropostamaxreembolsoid_f1_Internalname ;
      private string edtavPropostaresponsaveldocumento1_Internalname ;
      private string edtavPropostapacienteclienterazaosocial1_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Internalname ;
      private string edtavPropostaclinicadocumento1_Internalname ;
      private string edtavContratonome1_Internalname ;
      private string edtavConveniocategoriadescricao1_Internalname ;
      private string edtavPropostamaxreembolsoid_f2_Internalname ;
      private string edtavPropostaresponsaveldocumento2_Internalname ;
      private string edtavPropostapacienteclienterazaosocial2_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Internalname ;
      private string edtavPropostaclinicadocumento2_Internalname ;
      private string edtavContratonome2_Internalname ;
      private string edtavConveniocategoriadescricao2_Internalname ;
      private string edtavPropostamaxreembolsoid_f3_Internalname ;
      private string edtavPropostaresponsaveldocumento3_Internalname ;
      private string edtavPropostapacienteclienterazaosocial3_Internalname ;
      private string edtavPropostapacienteclientedocumento3_Internalname ;
      private string edtavPropostaclinicadocumento3_Internalname ;
      private string edtavContratonome3_Internalname ;
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
      private string cmbPropostaStatus_Columnheaderclass ;
      private string edtavContratos_Link ;
      private string GXEncryptionTmp ;
      private string cmbPropostaStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_propostamaxreembolsoid_f3_cell_Internalname ;
      private string edtavPropostamaxreembolsoid_f3_Jsonclick ;
      private string cellFilter_propostaresponsaveldocumento3_cell_Internalname ;
      private string edtavPropostaresponsaveldocumento3_Jsonclick ;
      private string cellFilter_propostapacienteclienterazaosocial3_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial3_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento3_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento3_Jsonclick ;
      private string cellFilter_propostaclinicadocumento3_cell_Internalname ;
      private string edtavPropostaclinicadocumento3_Jsonclick ;
      private string cellFilter_contratonome3_cell_Internalname ;
      private string edtavContratonome3_Jsonclick ;
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
      private string cellFilter_propostapacienteclienterazaosocial2_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial2_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento2_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Jsonclick ;
      private string cellFilter_propostaclinicadocumento2_cell_Internalname ;
      private string edtavPropostaclinicadocumento2_Jsonclick ;
      private string cellFilter_contratonome2_cell_Internalname ;
      private string edtavContratonome2_Jsonclick ;
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
      private string cellFilter_propostapacienteclienterazaosocial1_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial1_Jsonclick ;
      private string cellFilter_propostapacienteclientedocumento1_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Jsonclick ;
      private string cellFilter_propostaclinicadocumento1_cell_Internalname ;
      private string edtavPropostaclinicadocumento1_Jsonclick ;
      private string cellFilter_contratonome1_cell_Internalname ;
      private string edtavContratonome1_Jsonclick ;
      private string cellFilter_conveniocategoriadescricao1_cell_Internalname ;
      private string edtavConveniocategoriadescricao1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_159_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavContratos_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtProcedimentosMedicosNome_Jsonclick ;
      private string edtProcedimentosMedicosId_Jsonclick ;
      private string edtPropostaDescricao_Jsonclick ;
      private string edtPropostaValor_Jsonclick ;
      private string edtPropostaCreatedAt_Jsonclick ;
      private string edtPropostaCratedBy_Jsonclick ;
      private string edtPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtPropostaPacienteClienteDocumento_Jsonclick ;
      private string edtPropostaPacienteContatoEmail_Jsonclick ;
      private string GXCCtl ;
      private string cmbPropostaStatus_Jsonclick ;
      private string edtPropostaQuantidadeAprovadores_Jsonclick ;
      private string edtPropostaReprovacoesPermitidas_Jsonclick ;
      private string edtPropostaAprovacoes_F_Jsonclick ;
      private string edtPropostaReprovacoes_F_Jsonclick ;
      private string edtPropostaAprovacoesRestantes_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A327PropostaCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV37DynamicFiltersIgnoreFirst ;
      private bool AV36DynamicFiltersRemoving ;
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
      private bool n323PropostaId ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n376ProcedimentosMedicosId ;
      private bool n325PropostaDescricao ;
      private bool n326PropostaValor ;
      private bool n327PropostaCreatedAt ;
      private bool n328PropostaCratedBy ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n329PropostaStatus ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n341PropostaAprovacoes_F ;
      private bool n342PropostaReprovacoes_F ;
      private bool bGXsfl_159_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 ;
      private bool AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 ;
      private bool n227ContratoId ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n228ContratoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV50TFPropostaStatus_SelsJson ;
      private string AV42ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV66PropostaResponsavelDocumento1 ;
      private string AV18PropostaPacienteClienteRazaoSocial1 ;
      private string AV19PropostaPacienteClienteDocumento1 ;
      private string AV67PropostaClinicaDocumento1 ;
      private string AV20ContratoNome1 ;
      private string AV21ConvenioCategoriaDescricao1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV69PropostaResponsavelDocumento2 ;
      private string AV25PropostaPacienteClienteRazaoSocial2 ;
      private string AV26PropostaPacienteClienteDocumento2 ;
      private string AV70PropostaClinicaDocumento2 ;
      private string AV27ContratoNome2 ;
      private string AV28ConvenioCategoriaDescricao2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV72PropostaResponsavelDocumento3 ;
      private string AV32PropostaPacienteClienteRazaoSocial3 ;
      private string AV33PropostaPacienteClienteDocumento3 ;
      private string AV73PropostaClinicaDocumento3 ;
      private string AV34ContratoNome3 ;
      private string AV35ConvenioCategoriaDescricao3 ;
      private string AV44TFProcedimentosMedicosNome ;
      private string AV45TFProcedimentosMedicosNome_Sel ;
      private string AV59TFPropostaPacienteClienteRazaoSocial ;
      private string AV60TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV61TFPropostaPacienteClienteDocumento ;
      private string AV62TFPropostaPacienteClienteDocumento_Sel ;
      private string AV56GridAppliedFilters ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A541PropostaPacienteContatoEmail ;
      private string A329PropostaStatus ;
      private string lV75Wppropostasassinaturasds_1_filterfulltext ;
      private string lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string lV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string lV83Wppropostasassinaturasds_9_contratonome1 ;
      private string lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string lV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string lV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string lV93Wppropostasassinaturasds_19_contratonome2 ;
      private string lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string lV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string lV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string lV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string lV103Wppropostasassinaturasds_29_contratonome3 ;
      private string lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string AV75Wppropostasassinaturasds_1_filterfulltext ;
      private string AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 ;
      private string AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string AV83Wppropostasassinaturasds_9_contratonome1 ;
      private string AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 ;
      private string AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string AV93Wppropostasassinaturasds_19_contratonome2 ;
      private string AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 ;
      private string AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string AV103Wppropostasassinaturasds_29_contratonome3 ;
      private string AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ;
      private string AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ;
      private string AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ;
      private string AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string A580PropostaResponsavelDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV38ExcelFilename ;
      private string AV39ErrorMessage ;
      private string AV57AuxText ;
      private IGxSession AV40Session ;
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
      private GXCombobox cmbPropostaStatus ;
      private GxSimpleCollection<string> AV51TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV113Wppropostasassinaturasds_39_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H00785_A227ContratoId ;
      private bool[] H00785_n227ContratoId ;
      private int[] H00785_A493ConvenioCategoriaId ;
      private bool[] H00785_n493ConvenioCategoriaId ;
      private int[] H00785_A504PropostaPacienteClienteId ;
      private bool[] H00785_n504PropostaPacienteClienteId ;
      private int[] H00785_A553PropostaResponsavelId ;
      private bool[] H00785_n553PropostaResponsavelId ;
      private int[] H00785_A642PropostaClinicaId ;
      private bool[] H00785_n642PropostaClinicaId ;
      private string[] H00785_A494ConvenioCategoriaDescricao ;
      private bool[] H00785_n494ConvenioCategoriaDescricao ;
      private string[] H00785_A228ContratoNome ;
      private bool[] H00785_n228ContratoNome ;
      private string[] H00785_A652PropostaClinicaDocumento ;
      private bool[] H00785_n652PropostaClinicaDocumento ;
      private string[] H00785_A580PropostaResponsavelDocumento ;
      private bool[] H00785_n580PropostaResponsavelDocumento ;
      private short[] H00785_A345PropostaReprovacoesPermitidas ;
      private bool[] H00785_n345PropostaReprovacoesPermitidas ;
      private string[] H00785_A329PropostaStatus ;
      private bool[] H00785_n329PropostaStatus ;
      private string[] H00785_A541PropostaPacienteContatoEmail ;
      private bool[] H00785_n541PropostaPacienteContatoEmail ;
      private string[] H00785_A540PropostaPacienteClienteDocumento ;
      private bool[] H00785_n540PropostaPacienteClienteDocumento ;
      private string[] H00785_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H00785_n505PropostaPacienteClienteRazaoSocial ;
      private short[] H00785_A328PropostaCratedBy ;
      private bool[] H00785_n328PropostaCratedBy ;
      private DateTime[] H00785_A327PropostaCreatedAt ;
      private bool[] H00785_n327PropostaCreatedAt ;
      private decimal[] H00785_A326PropostaValor ;
      private bool[] H00785_n326PropostaValor ;
      private string[] H00785_A325PropostaDescricao ;
      private bool[] H00785_n325PropostaDescricao ;
      private int[] H00785_A376ProcedimentosMedicosId ;
      private bool[] H00785_n376ProcedimentosMedicosId ;
      private string[] H00785_A377ProcedimentosMedicosNome ;
      private bool[] H00785_n377ProcedimentosMedicosNome ;
      private int[] H00785_A323PropostaId ;
      private bool[] H00785_n323PropostaId ;
      private int[] H00785_A649PropostaMaxReembolsoId_F ;
      private bool[] H00785_n649PropostaMaxReembolsoId_F ;
      private short[] H00785_A342PropostaReprovacoes_F ;
      private bool[] H00785_n342PropostaReprovacoes_F ;
      private short[] H00785_A341PropostaAprovacoes_F ;
      private bool[] H00785_n341PropostaAprovacoes_F ;
      private short[] H00785_A330PropostaQuantidadeAprovadores ;
      private bool[] H00785_n330PropostaQuantidadeAprovadores ;
      private long[] H00789_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wppropostasassinaturas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00785( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV113Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV75Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV83Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV93Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV103Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV107Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV108Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV113Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[101];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ContratoId, T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T3.ConvenioCategoriaDescricao, T2.ContratoNome, T6.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaReprovacoesPermitidas, T1.PropostaStatus, T4.ContatoEmail AS PropostaPacienteContatoEmail, T4.ClienteDocumento AS PropostaPacienteClienteDocumento, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaCratedBy, T1.PropostaCreatedAt, T1.PropostaValor, T1.PropostaDescricao, T1.ProcedimentosMedicosId, T7.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, COALESCE( T10.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T9.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, T1.PropostaQuantidadeAprovadores";
         sFromString = " FROM (((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaClinicaId) LEFT JOIN ProcedimentosMedicos T7 ON T7.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T9 ON T9.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T10 ON T10.PropostaId = T1.PropostaId)";
         sOrderString = "";
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T7.ProcedimentosMedicosNome like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( T4.ClienteDocumento like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprova��o' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em an�lise' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revis�o' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'an�lise reprovada' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int7[42] = 1;
            GXv_int7[43] = 1;
            GXv_int7[44] = 1;
            GXv_int7[45] = 1;
            GXv_int7[46] = 1;
            GXv_int7[47] = 1;
            GXv_int7[48] = 1;
            GXv_int7[49] = 1;
            GXv_int7[50] = 1;
            GXv_int7[51] = 1;
            GXv_int7[52] = 1;
            GXv_int7[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int7[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int7[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int7[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int7[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int7[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV82Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int7[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV82Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int7[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int7[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV83Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int7[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int7[69] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV91Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int7[70] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV91Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int7[71] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV92Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int7[72] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV92Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int7[73] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV93Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int7[74] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV93Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int7[75] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int7[76] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int7[77] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int7[78] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int7[79] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int7[80] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int7[81] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int7[82] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int7[83] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV102Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int7[84] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV102Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int7[85] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV103Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int7[86] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV103Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int7[87] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int7[88] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int7[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T7.ProcedimentosMedicosNome like :lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int7[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ProcedimentosMedicosNome = ( :AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int7[91] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T7.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV107Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV107Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int7[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV108Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV108Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int7[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int7[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int7[95] = 1;
         }
         if ( StringUtil.StrCmp(AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int7[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento = ( :AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int7[97] = 1;
         }
         if ( StringUtil.StrCmp(AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T4.ClienteDocumento))=0))");
         }
         if ( AV113Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV113Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T7.ProcedimentosMedicosNome, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T7.ProcedimentosMedicosNome DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaValor, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaValor DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ClienteDocumento, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ClienteDocumento DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaStatus, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaStatus DESC, T1.PropostaId";
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

      protected Object[] conditional_H00789( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV113Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV75Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV82Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV83Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV92Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV93Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV102Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV103Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV107Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV108Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV113Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[98];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T4 ON T4.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T9 ON T9.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T10 ON T10.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV76Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV86Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV96Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ProcedimentosMedicosNome like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteDocumento like '%' || :lV75Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprova��o' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em an�lise' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revis�o' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'an�lise reprovada' like '%' || LOWER(:lV75Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int9[42] = 1;
            GXv_int9[43] = 1;
            GXv_int9[44] = 1;
            GXv_int9[45] = 1;
            GXv_int9[46] = 1;
            GXv_int9[47] = 1;
            GXv_int9[48] = 1;
            GXv_int9[49] = 1;
            GXv_int9[50] = 1;
            GXv_int9[51] = 1;
            GXv_int9[52] = 1;
            GXv_int9[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int9[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int9[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int9[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int9[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int9[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int9[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV82Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int9[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV82Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int9[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int9[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV83Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int9[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int9[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int9[65] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int9[66] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int9[67] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int9[68] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int9[69] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV91Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int9[70] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV91Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int9[71] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV92Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int9[72] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV92Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int9[73] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV93Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int9[74] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV93Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int9[75] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int9[76] = 1;
         }
         if ( AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int9[77] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int9[78] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int9[79] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int9[80] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int9[81] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int9[82] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int9[83] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV102Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int9[84] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV102Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int9[85] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV103Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int9[86] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV103Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int9[87] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int9[88] = 1;
         }
         if ( AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int9[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int9[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int9[91] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV107Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV107Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int9[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV108Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV108Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int9[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int9[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int9[95] = 1;
         }
         if ( StringUtil.StrCmp(AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int9[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento = ( :AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int9[97] = 1;
         }
         if ( StringUtil.StrCmp(AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T5.ClienteDocumento))=0))");
         }
         if ( AV113Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV113Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
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
                     return conditional_H00785(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] , (int)dynConstraints[50] , (int)dynConstraints[51] );
               case 1 :
                     return conditional_H00789(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] , (int)dynConstraints[50] , (int)dynConstraints[51] );
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
          Object[] prmH00785;
          prmH00785 = new Object[] {
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV83Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV83Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV91Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV91Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV93Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV93Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV103Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV107Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV108Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00789;
          prmH00789 = new Object[] {
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV76Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV77Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV78Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV85Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV86Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV87Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV95Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV96Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV97Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV79Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV80Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV81Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV83Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV83Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV84Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV89Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV90Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV91Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV91Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV93Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV93Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV94Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV99Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV100Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV101Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV103Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV104Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV105Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV106Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV107Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV108Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV109Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV110Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV111Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV112Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00785", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00785,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00789", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00789,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((short[]) buf[18])[0] = rslt.getShort(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((short[]) buf[28])[0] = rslt.getShort(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((int[]) buf[40])[0] = rslt.getInt(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
