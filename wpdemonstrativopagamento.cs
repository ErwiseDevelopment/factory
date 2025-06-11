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
   public class wpdemonstrativopagamento : GXDataArea
   {
      public wpdemonstrativopagamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdemonstrativopagamento( IGxContext context )
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV87PropostaResponsavelDocumento1 = GetPar( "PropostaResponsavelDocumento1");
         AV88PropostaPacienteClienteDocumento1 = GetPar( "PropostaPacienteClienteDocumento1");
         AV89PropostaClinicaDocumento1 = GetPar( "PropostaClinicaDocumento1");
         AV18PropostaPacienteClienteRazaoSocial1 = GetPar( "PropostaPacienteClienteRazaoSocial1");
         AV19ContratoNome1 = GetPar( "ContratoNome1");
         AV20ConvenioCategoriaDescricao1 = GetPar( "ConvenioCategoriaDescricao1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV91PropostaResponsavelDocumento2 = GetPar( "PropostaResponsavelDocumento2");
         AV92PropostaPacienteClienteDocumento2 = GetPar( "PropostaPacienteClienteDocumento2");
         AV93PropostaClinicaDocumento2 = GetPar( "PropostaClinicaDocumento2");
         AV24PropostaPacienteClienteRazaoSocial2 = GetPar( "PropostaPacienteClienteRazaoSocial2");
         AV25ContratoNome2 = GetPar( "ContratoNome2");
         AV26ConvenioCategoriaDescricao2 = GetPar( "ConvenioCategoriaDescricao2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV95PropostaResponsavelDocumento3 = GetPar( "PropostaResponsavelDocumento3");
         AV96PropostaPacienteClienteDocumento3 = GetPar( "PropostaPacienteClienteDocumento3");
         AV97PropostaClinicaDocumento3 = GetPar( "PropostaClinicaDocumento3");
         AV30PropostaPacienteClienteRazaoSocial3 = GetPar( "PropostaPacienteClienteRazaoSocial3");
         AV31ContratoNome3 = GetPar( "ContratoNome3");
         AV32ConvenioCategoriaDescricao3 = GetPar( "ConvenioCategoriaDescricao3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV98Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV86PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F1"), "."), 18, MidpointRounding.ToEven));
         AV90PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F2"), "."), 18, MidpointRounding.ToEven));
         AV94PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaMaxReembolsoId_F3"), "."), 18, MidpointRounding.ToEven));
         AV41TFPropostaPacienteClienteRazaoSocial = GetPar( "TFPropostaPacienteClienteRazaoSocial");
         AV42TFPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFPropostaPacienteClienteRazaoSocial_Sel");
         AV45TFPropostaDescricao = GetPar( "TFPropostaDescricao");
         AV46TFPropostaDescricao_Sel = GetPar( "TFPropostaDescricao_Sel");
         AV47TFPropostaValor = NumberUtil.Val( GetPar( "TFPropostaValor"), ".");
         AV48TFPropostaValor_To = NumberUtil.Val( GetPar( "TFPropostaValor_To"), ".");
         AV49TFPropostaTaxaAdministrativa = NumberUtil.Val( GetPar( "TFPropostaTaxaAdministrativa"), ".");
         AV50TFPropostaTaxaAdministrativa_To = NumberUtil.Val( GetPar( "TFPropostaTaxaAdministrativa_To"), ".");
         AV77TFPropostaValorTaxa_F = NumberUtil.Val( GetPar( "TFPropostaValorTaxa_F"), ".");
         AV78TFPropostaValorTaxa_F_To = NumberUtil.Val( GetPar( "TFPropostaValorTaxa_F_To"), ".");
         AV53TFPropostaJurosMora = NumberUtil.Val( GetPar( "TFPropostaJurosMora"), ".");
         AV54TFPropostaJurosMora_To = NumberUtil.Val( GetPar( "TFPropostaJurosMora_To"), ".");
         AV81TFPropostaDataCreditoCliente_F = context.localUtil.ParseDateParm( GetPar( "TFPropostaDataCreditoCliente_F"));
         AV82TFPropostaDataCreditoCliente_F_To = context.localUtil.ParseDateParm( GetPar( "TFPropostaDataCreditoCliente_F_To"));
         AV79TFPropostaValorJurosMora_F = NumberUtil.Val( GetPar( "TFPropostaValorJurosMora_F"), ".");
         AV80TFPropostaValorJurosMora_F_To = NumberUtil.Val( GetPar( "TFPropostaValorJurosMora_F_To"), ".");
         AV74TFPropostaSecUserName = GetPar( "TFPropostaSecUserName");
         AV75TFPropostaSecUserName_Sel = GetPar( "TFPropostaSecUserName_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV61TFPropostaStatus_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV34DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV33DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
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
         PA6J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdemonstrativopagamento") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV98Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV98Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO1", AV87PropostaResponsavelDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1", AV88PropostaPacienteClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO1", AV89PropostaClinicaDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1", AV18PropostaPacienteClienteRazaoSocial1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV19ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO1", AV20ConvenioCategoriaDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO2", AV91PropostaResponsavelDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2", AV92PropostaPacienteClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO2", AV93PropostaClinicaDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2", AV24PropostaPacienteClienteRazaoSocial2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV25ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO2", AV26ConvenioCategoriaDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTARESPONSAVELDOCUMENTO3", AV95PropostaResponsavelDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3", AV96PropostaPacienteClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTACLINICADOCUMENTO3", AV97PropostaClinicaDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3", AV30PropostaPacienteClienteRazaoSocial3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV31ContratoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONVENIOCATEGORIADESCRICAO3", AV32ConvenioCategoriaDescricao3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_159", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_159), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV72GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_PROPOSTADATACREDITOCLIENTE_FAUXDATE", context.localUtil.DToC( AV83DDO_PropostaDataCreditoCliente_FAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_PROPOSTADATACREDITOCLIENTE_FAUXDATETO", context.localUtil.DToC( AV84DDO_PropostaDataCreditoCliente_FAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV98Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV98Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV41TFPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV42TFPropostaPacienteClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADESCRICAO", AV45TFPropostaDescricao);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADESCRICAO_SEL", AV46TFPropostaDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR", StringUtil.LTrim( StringUtil.NToC( AV47TFPropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV48TFPropostaValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTATAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( AV49TFPropostaTaxaAdministrativa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTATAXAADMINISTRATIVA_TO", StringUtil.LTrim( StringUtil.NToC( AV50TFPropostaTaxaAdministrativa_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALORTAXA_F", StringUtil.LTrim( StringUtil.NToC( AV77TFPropostaValorTaxa_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALORTAXA_F_TO", StringUtil.LTrim( StringUtil.NToC( AV78TFPropostaValorTaxa_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAJUROSMORA", StringUtil.LTrim( StringUtil.NToC( AV53TFPropostaJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAJUROSMORA_TO", StringUtil.LTrim( StringUtil.NToC( AV54TFPropostaJurosMora_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADATACREDITOCLIENTE_F", context.localUtil.DToC( AV81TFPropostaDataCreditoCliente_F, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADATACREDITOCLIENTE_F_TO", context.localUtil.DToC( AV82TFPropostaDataCreditoCliente_F_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALORJUROSMORA_F", StringUtil.LTrim( StringUtil.NToC( AV79TFPropostaValorJurosMora_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALORJUROSMORA_F_TO", StringUtil.LTrim( StringUtil.NToC( AV80TFPropostaValorJurosMora_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASECUSERNAME", AV74TFPropostaSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASECUSERNAME_SEL", AV75TFPropostaSecUserName_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROPOSTASTATUS_SELS", AV61TFPropostaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROPOSTASTATUS_SELS", AV61TFPropostaStatus_Sels);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV34DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV33DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASTATUS_SELSJSON", AV60TFPropostaStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE6J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6J2( ) ;
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
         return formatLink("wpdemonstrativopagamento")  ;
      }

      public override string GetPgmname( )
      {
         return "WpDemonstrativoPagamento" ;
      }

      public override string GetPgmdesc( )
      {
         return " Proposta" ;
      }

      protected void WB6J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(159), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpDemonstrativoPagamento.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_6J2( true) ;
         }
         else
         {
            wb_table1_43_6J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_6J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_83_6J2( true) ;
         }
         else
         {
            wb_table2_83_6J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_83_6J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_159_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_123_6J2( true) ;
         }
         else
         {
            wb_table3_123_6J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_123_6J2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV70GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV71GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV72GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpDemonstrativoPagamento.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_propostadatacreditocliente_fauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_propostadatacreditocliente_fauxdatetext_Internalname, AV85DDO_PropostaDataCreditoCliente_FAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV85DDO_PropostaDataCreditoCliente_FAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,188);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_propostadatacreditocliente_fauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            /* User Defined Control */
            ucTfpropostadatacreditocliente_f_rangepicker.SetProperty("Start Date", AV83DDO_PropostaDataCreditoCliente_FAuxDate);
            ucTfpropostadatacreditocliente_f_rangepicker.SetProperty("End Date", AV84DDO_PropostaDataCreditoCliente_FAuxDateTo);
            ucTfpropostadatacreditocliente_f_rangepicker.Render(context, "wwp.daterangepicker", Tfpropostadatacreditocliente_f_rangepicker_Internalname, "TFPROPOSTADATACREDITOCLIENTE_F_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START6J2( )
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
         STRUP6J0( ) ;
      }

      protected void WS6J2( )
      {
         START6J2( ) ;
         EVT6J2( ) ;
      }

      protected void EVT6J2( )
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
                              E116J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E146J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E156J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E166J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E176J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E186J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E196J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E206J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E216J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E226J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E236J2 ();
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
                              AV76ConsultaTitulo = cgiGet( edtavConsultatitulo_Internalname);
                              AssignAttri("", false, edtavConsultatitulo_Internalname, AV76ConsultaTitulo);
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaPacienteClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n504PropostaPacienteClienteId = false;
                              A505PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtPropostaPacienteClienteRazaoSocial_Internalname));
                              n505PropostaPacienteClienteRazaoSocial = false;
                              A376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n376ProcedimentosMedicosId = false;
                              A325PropostaDescricao = cgiGet( edtPropostaDescricao_Internalname);
                              n325PropostaDescricao = false;
                              A326PropostaValor = context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".");
                              n326PropostaValor = false;
                              A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( edtPropostaTaxaAdministrativa_Internalname), ",", ".");
                              n501PropostaTaxaAdministrativa = false;
                              A513PropostaValorTaxa_F = context.localUtil.CToN( cgiGet( edtPropostaValorTaxa_F_Internalname), ",", ".");
                              A508PropostaJurosMora = context.localUtil.CToN( cgiGet( edtPropostaJurosMora_Internalname), ",", ".");
                              n508PropostaJurosMora = false;
                              A515PropostaDataCreditoCliente_F = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPropostaDataCreditoCliente_F_Internalname), 0));
                              n515PropostaDataCreditoCliente_F = false;
                              A514PropostaValorJurosMora_F = context.localUtil.CToN( cgiGet( edtPropostaValorJurosMora_F_Internalname), ",", ".");
                              A507PropostaSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaSLA_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n507PropostaSLA = false;
                              A328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n328PropostaCratedBy = false;
                              A512PropostaSecUserName = StringUtil.Upper( cgiGet( edtPropostaSecUserName_Internalname));
                              n512PropostaSecUserName = false;
                              cmbPropostaStatus.Name = cmbPropostaStatus_Internalname;
                              cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
                              A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
                              n329PropostaStatus = false;
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E246J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E256J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E266J2 ();
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
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV87PropostaResponsavelDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV88PropostaPacienteClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV89PropostaClinicaDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18PropostaPacienteClienteRazaoSocial1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV20ConvenioCategoriaDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV91PropostaResponsavelDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV92PropostaPacienteClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV93PropostaClinicaDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV24PropostaPacienteClienteRazaoSocial2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV25ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV26ConvenioCategoriaDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaresponsaveldocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV95PropostaResponsavelDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV96PropostaPacienteClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostaclinicadocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV97PropostaClinicaDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostapacienteclienterazaosocial3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV30PropostaPacienteClienteRazaoSocial3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV31ContratoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conveniocategoriadescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV32ConvenioCategoriaDescricao3) != 0 )
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

      protected void WE6J2( )
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

      protected void PA6J2( )
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
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV87PropostaResponsavelDocumento1 ,
                                       string AV88PropostaPacienteClienteDocumento1 ,
                                       string AV89PropostaClinicaDocumento1 ,
                                       string AV18PropostaPacienteClienteRazaoSocial1 ,
                                       string AV19ContratoNome1 ,
                                       string AV20ConvenioCategoriaDescricao1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV91PropostaResponsavelDocumento2 ,
                                       string AV92PropostaPacienteClienteDocumento2 ,
                                       string AV93PropostaClinicaDocumento2 ,
                                       string AV24PropostaPacienteClienteRazaoSocial2 ,
                                       string AV25ContratoNome2 ,
                                       string AV26ConvenioCategoriaDescricao2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       string AV95PropostaResponsavelDocumento3 ,
                                       string AV96PropostaPacienteClienteDocumento3 ,
                                       string AV97PropostaClinicaDocumento3 ,
                                       string AV30PropostaPacienteClienteRazaoSocial3 ,
                                       string AV31ContratoNome3 ,
                                       string AV32ConvenioCategoriaDescricao3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       string AV98Pgmname ,
                                       string AV15FilterFullText ,
                                       int AV86PropostaMaxReembolsoId_F1 ,
                                       int AV90PropostaMaxReembolsoId_F2 ,
                                       int AV94PropostaMaxReembolsoId_F3 ,
                                       string AV41TFPropostaPacienteClienteRazaoSocial ,
                                       string AV42TFPropostaPacienteClienteRazaoSocial_Sel ,
                                       string AV45TFPropostaDescricao ,
                                       string AV46TFPropostaDescricao_Sel ,
                                       decimal AV47TFPropostaValor ,
                                       decimal AV48TFPropostaValor_To ,
                                       decimal AV49TFPropostaTaxaAdministrativa ,
                                       decimal AV50TFPropostaTaxaAdministrativa_To ,
                                       decimal AV77TFPropostaValorTaxa_F ,
                                       decimal AV78TFPropostaValorTaxa_F_To ,
                                       decimal AV53TFPropostaJurosMora ,
                                       decimal AV54TFPropostaJurosMora_To ,
                                       DateTime AV81TFPropostaDataCreditoCliente_F ,
                                       DateTime AV82TFPropostaDataCreditoCliente_F_To ,
                                       decimal AV79TFPropostaValorJurosMora_F ,
                                       decimal AV80TFPropostaValorJurosMora_F_To ,
                                       string AV74TFPropostaSecUserName ,
                                       string AV75TFPropostaSecUserName_Sel ,
                                       GxSimpleCollection<string> AV61TFPropostaStatus_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV34DynamicFiltersIgnoreFirst ,
                                       bool AV33DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6J2( ) ;
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
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV98Pgmname = "WpDemonstrativoPagamento";
         edtavConsultatitulo_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              AV107Wpdemonstrativopagamentods_9_contratonome1 ,
                                              AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              AV117Wpdemonstrativopagamentods_19_contratonome2 ,
                                              AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              AV127Wpdemonstrativopagamentods_29_contratonome3 ,
                                              AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              AV131Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              AV133Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              AV145Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A501PropostaTaxaAdministrativa ,
                                              A508PropostaJurosMora ,
                                              A512PropostaSecUserName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV99Wpdemonstrativopagamentods_1_filterfulltext ,
                                              A513PropostaValorTaxa_F ,
                                              A514PropostaValorJurosMora_F ,
                                              AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              A515PropostaDataCreditoCliente_F ,
                                              AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV107Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV107Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV117Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV117Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV127Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV127Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
         lV131Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV131Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
         lV145Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV145Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
         /* Using cursor H006J5 */
         pr_default.execute(0, new Object[] {AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV107Wpdemonstrativopagamentods_9_contratonome1, lV107Wpdemonstrativopagamentods_9_contratonome1, lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV117Wpdemonstrativopagamentods_19_contratonome2, lV117Wpdemonstrativopagamentods_19_contratonome2, lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV127Wpdemonstrativopagamentods_29_contratonome3, lV127Wpdemonstrativopagamentods_29_contratonome3, lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV131Wpdemonstrativopagamentods_33_tfpropostadescricao, AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV133Wpdemonstrativopagamentods_35_tfpropostavalor, AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV145Wpdemonstrativopagamentods_47_tfpropostasecusername, AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A493ConvenioCategoriaId = H006J5_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = H006J5_n493ConvenioCategoriaId[0];
            A553PropostaResponsavelId = H006J5_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H006J5_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = H006J5_A642PropostaClinicaId[0];
            n642PropostaClinicaId = H006J5_n642PropostaClinicaId[0];
            A494ConvenioCategoriaDescricao = H006J5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H006J5_n494ConvenioCategoriaDescricao[0];
            A652PropostaClinicaDocumento = H006J5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = H006J5_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = H006J5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H006J5_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = H006J5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H006J5_n580PropostaResponsavelDocumento[0];
            A327PropostaCreatedAt = H006J5_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = H006J5_n327PropostaCreatedAt[0];
            A228ContratoNome = H006J5_A228ContratoNome[0];
            n228ContratoNome = H006J5_n228ContratoNome[0];
            A227ContratoId = H006J5_A227ContratoId[0];
            n227ContratoId = H006J5_n227ContratoId[0];
            A329PropostaStatus = H006J5_A329PropostaStatus[0];
            n329PropostaStatus = H006J5_n329PropostaStatus[0];
            A512PropostaSecUserName = H006J5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = H006J5_n512PropostaSecUserName[0];
            A328PropostaCratedBy = H006J5_A328PropostaCratedBy[0];
            n328PropostaCratedBy = H006J5_n328PropostaCratedBy[0];
            A513PropostaValorTaxa_F = H006J5_A513PropostaValorTaxa_F[0];
            A325PropostaDescricao = H006J5_A325PropostaDescricao[0];
            n325PropostaDescricao = H006J5_n325PropostaDescricao[0];
            A376ProcedimentosMedicosId = H006J5_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H006J5_n376ProcedimentosMedicosId[0];
            A505PropostaPacienteClienteRazaoSocial = H006J5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H006J5_n505PropostaPacienteClienteRazaoSocial[0];
            A504PropostaPacienteClienteId = H006J5_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H006J5_n504PropostaPacienteClienteId[0];
            A323PropostaId = H006J5_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = H006J5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = H006J5_n649PropostaMaxReembolsoId_F[0];
            A501PropostaTaxaAdministrativa = H006J5_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = H006J5_n501PropostaTaxaAdministrativa[0];
            A326PropostaValor = H006J5_A326PropostaValor[0];
            n326PropostaValor = H006J5_n326PropostaValor[0];
            A508PropostaJurosMora = H006J5_A508PropostaJurosMora[0];
            n508PropostaJurosMora = H006J5_n508PropostaJurosMora[0];
            A507PropostaSLA = H006J5_A507PropostaSLA[0];
            n507PropostaSLA = H006J5_n507PropostaSLA[0];
            A515PropostaDataCreditoCliente_F = H006J5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = H006J5_n515PropostaDataCreditoCliente_F[0];
            A494ConvenioCategoriaDescricao = H006J5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H006J5_n494ConvenioCategoriaDescricao[0];
            A580PropostaResponsavelDocumento = H006J5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H006J5_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = H006J5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = H006J5_n652PropostaClinicaDocumento[0];
            A228ContratoNome = H006J5_A228ContratoNome[0];
            n228ContratoNome = H006J5_n228ContratoNome[0];
            A512PropostaSecUserName = H006J5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = H006J5_n512PropostaSecUserName[0];
            A540PropostaPacienteClienteDocumento = H006J5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H006J5_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = H006J5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H006J5_n505PropostaPacienteClienteRazaoSocial[0];
            A649PropostaMaxReembolsoId_F = H006J5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = H006J5_n649PropostaMaxReembolsoId_F[0];
            A515PropostaDataCreditoCliente_F = H006J5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = H006J5_n515PropostaDataCreditoCliente_F[0];
            GXt_decimal1 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
            A514PropostaValorJurosMora_F = GXt_decimal1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
            ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
                  {
                     GRID_nRecordCount = (long)(GRID_nRecordCount+1);
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

      protected void RF6J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 159;
         /* Execute user event: Refresh */
         E256J2 ();
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
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A329PropostaStatus ,
                                                 AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                                 AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                                 AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                                 AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                                 AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                                 AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                                 AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                                 AV107Wpdemonstrativopagamentods_9_contratonome1 ,
                                                 AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                                 AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                                 AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                                 AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                                 AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                                 AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                                 AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                                 AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                                 AV117Wpdemonstrativopagamentods_19_contratonome2 ,
                                                 AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                                 AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                                 AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                                 AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                                 AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                                 AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                                 AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                                 AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                                 AV127Wpdemonstrativopagamentods_29_contratonome3 ,
                                                 AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                                 AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                                 AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                                 AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                                 AV131Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                                 AV133Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                                 AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                                 AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                                 AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                                 AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                                 AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                                 AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                                 AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                                 AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                                 AV145Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                                 AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                                 A580PropostaResponsavelDocumento ,
                                                 A540PropostaPacienteClienteDocumento ,
                                                 A652PropostaClinicaDocumento ,
                                                 A505PropostaPacienteClienteRazaoSocial ,
                                                 A228ContratoNome ,
                                                 A494ConvenioCategoriaDescricao ,
                                                 A325PropostaDescricao ,
                                                 A326PropostaValor ,
                                                 A501PropostaTaxaAdministrativa ,
                                                 A508PropostaJurosMora ,
                                                 A512PropostaSecUserName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV99Wpdemonstrativopagamentods_1_filterfulltext ,
                                                 A513PropostaValorTaxa_F ,
                                                 A514PropostaValorJurosMora_F ,
                                                 AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                                 A649PropostaMaxReembolsoId_F ,
                                                 AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                                 AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                                 AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                                 A515PropostaDataCreditoCliente_F ,
                                                 AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                                 AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                                 AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                                 }
            });
            lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
            lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
            lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
            lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
            lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
            lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
            lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
            lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
            lV107Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1), "%", "");
            lV107Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1), "%", "");
            lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
            lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
            lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
            lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
            lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
            lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
            lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
            lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
            lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
            lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
            lV117Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2), "%", "");
            lV117Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2), "%", "");
            lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
            lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
            lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
            lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
            lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
            lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
            lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
            lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
            lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
            lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
            lV127Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3), "%", "");
            lV127Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3), "%", "");
            lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
            lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
            lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
            lV131Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV131Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
            lV145Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV145Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
            /* Using cursor H006J9 */
            pr_default.execute(1, new Object[] {AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV107Wpdemonstrativopagamentods_9_contratonome1, lV107Wpdemonstrativopagamentods_9_contratonome1, lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV117Wpdemonstrativopagamentods_19_contratonome2, lV117Wpdemonstrativopagamentods_19_contratonome2, lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV127Wpdemonstrativopagamentods_29_contratonome3, lV127Wpdemonstrativopagamentods_29_contratonome3, lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV131Wpdemonstrativopagamentods_33_tfpropostadescricao, AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV133Wpdemonstrativopagamentods_35_tfpropostavalor, AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV145Wpdemonstrativopagamentods_47_tfpropostasecusername, AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
            nGXsfl_159_idx = 1;
            sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
            SubsflControlProps_1592( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A493ConvenioCategoriaId = H006J9_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = H006J9_n493ConvenioCategoriaId[0];
               A553PropostaResponsavelId = H006J9_A553PropostaResponsavelId[0];
               n553PropostaResponsavelId = H006J9_n553PropostaResponsavelId[0];
               A642PropostaClinicaId = H006J9_A642PropostaClinicaId[0];
               n642PropostaClinicaId = H006J9_n642PropostaClinicaId[0];
               A494ConvenioCategoriaDescricao = H006J9_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H006J9_n494ConvenioCategoriaDescricao[0];
               A652PropostaClinicaDocumento = H006J9_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H006J9_n652PropostaClinicaDocumento[0];
               A540PropostaPacienteClienteDocumento = H006J9_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H006J9_n540PropostaPacienteClienteDocumento[0];
               A580PropostaResponsavelDocumento = H006J9_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H006J9_n580PropostaResponsavelDocumento[0];
               A327PropostaCreatedAt = H006J9_A327PropostaCreatedAt[0];
               n327PropostaCreatedAt = H006J9_n327PropostaCreatedAt[0];
               A228ContratoNome = H006J9_A228ContratoNome[0];
               n228ContratoNome = H006J9_n228ContratoNome[0];
               A227ContratoId = H006J9_A227ContratoId[0];
               n227ContratoId = H006J9_n227ContratoId[0];
               A329PropostaStatus = H006J9_A329PropostaStatus[0];
               n329PropostaStatus = H006J9_n329PropostaStatus[0];
               A512PropostaSecUserName = H006J9_A512PropostaSecUserName[0];
               n512PropostaSecUserName = H006J9_n512PropostaSecUserName[0];
               A328PropostaCratedBy = H006J9_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H006J9_n328PropostaCratedBy[0];
               A513PropostaValorTaxa_F = H006J9_A513PropostaValorTaxa_F[0];
               A325PropostaDescricao = H006J9_A325PropostaDescricao[0];
               n325PropostaDescricao = H006J9_n325PropostaDescricao[0];
               A376ProcedimentosMedicosId = H006J9_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = H006J9_n376ProcedimentosMedicosId[0];
               A505PropostaPacienteClienteRazaoSocial = H006J9_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H006J9_n505PropostaPacienteClienteRazaoSocial[0];
               A504PropostaPacienteClienteId = H006J9_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H006J9_n504PropostaPacienteClienteId[0];
               A323PropostaId = H006J9_A323PropostaId[0];
               A649PropostaMaxReembolsoId_F = H006J9_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H006J9_n649PropostaMaxReembolsoId_F[0];
               A501PropostaTaxaAdministrativa = H006J9_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H006J9_n501PropostaTaxaAdministrativa[0];
               A326PropostaValor = H006J9_A326PropostaValor[0];
               n326PropostaValor = H006J9_n326PropostaValor[0];
               A508PropostaJurosMora = H006J9_A508PropostaJurosMora[0];
               n508PropostaJurosMora = H006J9_n508PropostaJurosMora[0];
               A507PropostaSLA = H006J9_A507PropostaSLA[0];
               n507PropostaSLA = H006J9_n507PropostaSLA[0];
               A515PropostaDataCreditoCliente_F = H006J9_A515PropostaDataCreditoCliente_F[0];
               n515PropostaDataCreditoCliente_F = H006J9_n515PropostaDataCreditoCliente_F[0];
               A494ConvenioCategoriaDescricao = H006J9_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H006J9_n494ConvenioCategoriaDescricao[0];
               A580PropostaResponsavelDocumento = H006J9_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H006J9_n580PropostaResponsavelDocumento[0];
               A652PropostaClinicaDocumento = H006J9_A652PropostaClinicaDocumento[0];
               n652PropostaClinicaDocumento = H006J9_n652PropostaClinicaDocumento[0];
               A228ContratoNome = H006J9_A228ContratoNome[0];
               n228ContratoNome = H006J9_n228ContratoNome[0];
               A512PropostaSecUserName = H006J9_A512PropostaSecUserName[0];
               n512PropostaSecUserName = H006J9_n512PropostaSecUserName[0];
               A540PropostaPacienteClienteDocumento = H006J9_A540PropostaPacienteClienteDocumento[0];
               n540PropostaPacienteClienteDocumento = H006J9_n540PropostaPacienteClienteDocumento[0];
               A505PropostaPacienteClienteRazaoSocial = H006J9_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H006J9_n505PropostaPacienteClienteRazaoSocial[0];
               A649PropostaMaxReembolsoId_F = H006J9_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = H006J9_n649PropostaMaxReembolsoId_F[0];
               A515PropostaDataCreditoCliente_F = H006J9_A515PropostaDataCreditoCliente_F[0];
               n515PropostaDataCreditoCliente_F = H006J9_n515PropostaDataCreditoCliente_F[0];
               GXt_decimal1 = A514PropostaValorJurosMora_F;
               new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
               A514PropostaValorJurosMora_F = GXt_decimal1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV99Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
               ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
               ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV99Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
               )
               {
                  if ( (Convert.ToDecimal(0)==AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
                  {
                     if ( (Convert.ToDecimal(0)==AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E266J2 ();
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 159;
            WB6J0( ) ;
         }
         bGXsfl_159_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV98Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV98Pgmname, "")), context));
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
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV98Pgmname = "WpDemonstrativoPagamento";
         edtavConsultatitulo_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtPropostaPacienteClienteId_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtPropostaValorTaxa_F_Enabled = 0;
         edtPropostaJurosMora_Enabled = 0;
         edtPropostaDataCreditoCliente_F_Enabled = 0;
         edtPropostaValorJurosMora_F_Enabled = 0;
         edtPropostaSLA_Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         edtPropostaSecUserName_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtContratoId_Enabled = 0;
         edtContratoNome_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E246J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV68DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_159 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_159"), ",", "."), 18, MidpointRounding.ToEven));
            AV70GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV71GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV72GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV83DDO_PropostaDataCreditoCliente_FAuxDate = context.localUtil.CToD( cgiGet( "vDDO_PROPOSTADATACREDITOCLIENTE_FAUXDATE"), 0);
            AV84DDO_PropostaDataCreditoCliente_FAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_PROPOSTADATACREDITOCLIENTE_FAUXDATETO"), 0);
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F1");
               GX_FocusControl = edtavPropostamaxreembolsoid_f1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV86PropostaMaxReembolsoId_F1 = 0;
               AssignAttri("", false, "AV86PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0));
            }
            else
            {
               AV86PropostaMaxReembolsoId_F1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV86PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0));
            }
            AV87PropostaResponsavelDocumento1 = cgiGet( edtavPropostaresponsaveldocumento1_Internalname);
            AssignAttri("", false, "AV87PropostaResponsavelDocumento1", AV87PropostaResponsavelDocumento1);
            AV88PropostaPacienteClienteDocumento1 = cgiGet( edtavPropostapacienteclientedocumento1_Internalname);
            AssignAttri("", false, "AV88PropostaPacienteClienteDocumento1", AV88PropostaPacienteClienteDocumento1);
            AV89PropostaClinicaDocumento1 = cgiGet( edtavPropostaclinicadocumento1_Internalname);
            AssignAttri("", false, "AV89PropostaClinicaDocumento1", AV89PropostaClinicaDocumento1);
            AV18PropostaPacienteClienteRazaoSocial1 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial1_Internalname));
            AssignAttri("", false, "AV18PropostaPacienteClienteRazaoSocial1", AV18PropostaPacienteClienteRazaoSocial1);
            AV19ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
            AV20ConvenioCategoriaDescricao1 = cgiGet( edtavConveniocategoriadescricao1_Internalname);
            AssignAttri("", false, "AV20ConvenioCategoriaDescricao1", AV20ConvenioCategoriaDescricao1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F2");
               GX_FocusControl = edtavPropostamaxreembolsoid_f2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV90PropostaMaxReembolsoId_F2 = 0;
               AssignAttri("", false, "AV90PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0));
            }
            else
            {
               AV90PropostaMaxReembolsoId_F2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV90PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0));
            }
            AV91PropostaResponsavelDocumento2 = cgiGet( edtavPropostaresponsaveldocumento2_Internalname);
            AssignAttri("", false, "AV91PropostaResponsavelDocumento2", AV91PropostaResponsavelDocumento2);
            AV92PropostaPacienteClienteDocumento2 = cgiGet( edtavPropostapacienteclientedocumento2_Internalname);
            AssignAttri("", false, "AV92PropostaPacienteClienteDocumento2", AV92PropostaPacienteClienteDocumento2);
            AV93PropostaClinicaDocumento2 = cgiGet( edtavPropostaclinicadocumento2_Internalname);
            AssignAttri("", false, "AV93PropostaClinicaDocumento2", AV93PropostaClinicaDocumento2);
            AV24PropostaPacienteClienteRazaoSocial2 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial2_Internalname));
            AssignAttri("", false, "AV24PropostaPacienteClienteRazaoSocial2", AV24PropostaPacienteClienteRazaoSocial2);
            AV25ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV25ContratoNome2", AV25ContratoNome2);
            AV26ConvenioCategoriaDescricao2 = cgiGet( edtavConveniocategoriadescricao2_Internalname);
            AssignAttri("", false, "AV26ConvenioCategoriaDescricao2", AV26ConvenioCategoriaDescricao2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAMAXREEMBOLSOID_F3");
               GX_FocusControl = edtavPropostamaxreembolsoid_f3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV94PropostaMaxReembolsoId_F3 = 0;
               AssignAttri("", false, "AV94PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0));
            }
            else
            {
               AV94PropostaMaxReembolsoId_F3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostamaxreembolsoid_f3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV94PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0));
            }
            AV95PropostaResponsavelDocumento3 = cgiGet( edtavPropostaresponsaveldocumento3_Internalname);
            AssignAttri("", false, "AV95PropostaResponsavelDocumento3", AV95PropostaResponsavelDocumento3);
            AV96PropostaPacienteClienteDocumento3 = cgiGet( edtavPropostapacienteclientedocumento3_Internalname);
            AssignAttri("", false, "AV96PropostaPacienteClienteDocumento3", AV96PropostaPacienteClienteDocumento3);
            AV97PropostaClinicaDocumento3 = cgiGet( edtavPropostaclinicadocumento3_Internalname);
            AssignAttri("", false, "AV97PropostaClinicaDocumento3", AV97PropostaClinicaDocumento3);
            AV30PropostaPacienteClienteRazaoSocial3 = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial3_Internalname));
            AssignAttri("", false, "AV30PropostaPacienteClienteRazaoSocial3", AV30PropostaPacienteClienteRazaoSocial3);
            AV31ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV31ContratoNome3", AV31ContratoNome3);
            AV32ConvenioCategoriaDescricao3 = cgiGet( edtavConveniocategoriadescricao3_Internalname);
            AssignAttri("", false, "AV32ConvenioCategoriaDescricao3", AV32ConvenioCategoriaDescricao3);
            AV85DDO_PropostaDataCreditoCliente_FAuxDateText = cgiGet( edtavDdo_propostadatacreditocliente_fauxdatetext_Internalname);
            AssignAttri("", false, "AV85DDO_PropostaDataCreditoCliente_FAuxDateText", AV85DDO_PropostaDataCreditoCliente_FAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO1"), AV87PropostaResponsavelDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO1"), AV88PropostaPacienteClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO1"), AV89PropostaClinicaDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18PropostaPacienteClienteRazaoSocial1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO1"), AV20ConvenioCategoriaDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO2"), AV91PropostaResponsavelDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO2"), AV92PropostaPacienteClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO2"), AV93PropostaClinicaDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV24PropostaPacienteClienteRazaoSocial2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV25ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO2"), AV26ConvenioCategoriaDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTARESPONSAVELDOCUMENTO3"), AV95PropostaResponsavelDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTEDOCUMENTO3"), AV96PropostaPacienteClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTACLINICADOCUMENTO3"), AV97PropostaClinicaDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV30PropostaPacienteClienteRazaoSocial3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV31ContratoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONVENIOCATEGORIADESCRICAO3"), AV32ConvenioCategoriaDescricao3) != 0 )
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
         E246J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E246J2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFPROPOSTADATACREDITOCLIENTE_F_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_propostadatacreditocliente_fauxdatetext_Internalname});
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
         AV22DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV68DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV68DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E256J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONTRATONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         AV70GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV70GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV70GridCurrentPage), 10, 0));
         AV71GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV71GridPageCount", StringUtil.LTrimStr( (decimal)(AV71GridPageCount), 10, 0));
         GXt_char3 = AV72GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV98Pgmname, out  GXt_char3) ;
         AV72GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV72GridAppliedFilters", AV72GridAppliedFilters);
         cmbPropostaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbPropostaStatus_Internalname, "Columnheaderclass", cmbPropostaStatus_Columnheaderclass, !bGXsfl_159_Refreshing);
         AV99Wpdemonstrativopagamentods_1_filterfulltext = AV15FilterFullText;
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV86PropostaMaxReembolsoId_F1;
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV87PropostaResponsavelDocumento1;
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV88PropostaPacienteClienteDocumento1;
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV89PropostaClinicaDocumento1;
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV18PropostaPacienteClienteRazaoSocial1;
         AV107Wpdemonstrativopagamentods_9_contratonome1 = AV19ContratoNome1;
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV20ConvenioCategoriaDescricao1;
         AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV90PropostaMaxReembolsoId_F2;
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV91PropostaResponsavelDocumento2;
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV92PropostaPacienteClienteDocumento2;
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV93PropostaClinicaDocumento2;
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV24PropostaPacienteClienteRazaoSocial2;
         AV117Wpdemonstrativopagamentods_19_contratonome2 = AV25ContratoNome2;
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV30PropostaPacienteClienteRazaoSocial3;
         AV127Wpdemonstrativopagamentods_29_contratonome3 = AV31ContratoNome3;
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV32ConvenioCategoriaDescricao3;
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV133Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV77TFPropostaValorTaxa_F;
         AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV78TFPropostaValorTaxa_F_To;
         AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV81TFPropostaDataCreditoCliente_F;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV82TFPropostaDataCreditoCliente_F_To;
         AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV79TFPropostaValorJurosMora_F;
         AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV80TFPropostaValorJurosMora_F_To;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV61TFPropostaStatus_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E126J2( )
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
            AV69PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV69PageToGo) ;
         }
      }

      protected void E136J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E146J2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaPacienteClienteRazaoSocial") == 0 )
            {
               AV41TFPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFPropostaPacienteClienteRazaoSocial", AV41TFPropostaPacienteClienteRazaoSocial);
               AV42TFPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFPropostaPacienteClienteRazaoSocial_Sel", AV42TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaDescricao") == 0 )
            {
               AV45TFPropostaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFPropostaDescricao", AV45TFPropostaDescricao);
               AV46TFPropostaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFPropostaDescricao_Sel", AV46TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaValor") == 0 )
            {
               AV47TFPropostaValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV47TFPropostaValor", StringUtil.LTrimStr( AV47TFPropostaValor, 18, 2));
               AV48TFPropostaValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV48TFPropostaValor_To", StringUtil.LTrimStr( AV48TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaTaxaAdministrativa") == 0 )
            {
               AV49TFPropostaTaxaAdministrativa = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV49TFPropostaTaxaAdministrativa", StringUtil.LTrimStr( AV49TFPropostaTaxaAdministrativa, 16, 4));
               AV50TFPropostaTaxaAdministrativa_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV50TFPropostaTaxaAdministrativa_To", StringUtil.LTrimStr( AV50TFPropostaTaxaAdministrativa_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaValorTaxa_F") == 0 )
            {
               AV77TFPropostaValorTaxa_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV77TFPropostaValorTaxa_F", StringUtil.LTrimStr( AV77TFPropostaValorTaxa_F, 18, 2));
               AV78TFPropostaValorTaxa_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV78TFPropostaValorTaxa_F_To", StringUtil.LTrimStr( AV78TFPropostaValorTaxa_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaJurosMora") == 0 )
            {
               AV53TFPropostaJurosMora = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV53TFPropostaJurosMora", StringUtil.LTrimStr( AV53TFPropostaJurosMora, 16, 4));
               AV54TFPropostaJurosMora_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV54TFPropostaJurosMora_To", StringUtil.LTrimStr( AV54TFPropostaJurosMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaDataCreditoCliente_F") == 0 )
            {
               AV81TFPropostaDataCreditoCliente_F = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV81TFPropostaDataCreditoCliente_F", context.localUtil.Format(AV81TFPropostaDataCreditoCliente_F, "99/99/9999"));
               AV82TFPropostaDataCreditoCliente_F_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV82TFPropostaDataCreditoCliente_F_To", context.localUtil.Format(AV82TFPropostaDataCreditoCliente_F_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaValorJurosMora_F") == 0 )
            {
               AV79TFPropostaValorJurosMora_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV79TFPropostaValorJurosMora_F", StringUtil.LTrimStr( AV79TFPropostaValorJurosMora_F, 18, 2));
               AV80TFPropostaValorJurosMora_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV80TFPropostaValorJurosMora_F_To", StringUtil.LTrimStr( AV80TFPropostaValorJurosMora_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaSecUserName") == 0 )
            {
               AV74TFPropostaSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFPropostaSecUserName", AV74TFPropostaSecUserName);
               AV75TFPropostaSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFPropostaSecUserName_Sel", AV75TFPropostaSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaStatus") == 0 )
            {
               AV60TFPropostaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFPropostaStatus_SelsJson", AV60TFPropostaStatus_SelsJson);
               AV61TFPropostaStatus_Sels.FromJSonString(AV60TFPropostaStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61TFPropostaStatus_Sels", AV61TFPropostaStatus_Sels);
      }

      private void E266J2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV76ConsultaTitulo = "<i class=\"fas fa-money-bill\"></i>";
            AssignAttri("", false, edtavConsultatitulo_Internalname, AV76ConsultaTitulo);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "titulopropostaww"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
            edtavConsultatitulo_Link = formatLink("titulopropostaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
            {
               cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
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
               cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
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
               wbStart = 159;
            }
            sendrow_1592( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_159_Refreshing )
         {
            DoAjaxLoad(159, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E196J2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E156J2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV34DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV34DynamicFiltersIgnoreFirst", AV34DynamicFiltersIgnoreFirst);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV34DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV34DynamicFiltersIgnoreFirst", AV34DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E206J2( )
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

      protected void E216J2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E166J2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E226J2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E176J2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV87PropostaResponsavelDocumento1, AV88PropostaPacienteClienteDocumento1, AV89PropostaClinicaDocumento1, AV18PropostaPacienteClienteRazaoSocial1, AV19ContratoNome1, AV20ConvenioCategoriaDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV91PropostaResponsavelDocumento2, AV92PropostaPacienteClienteDocumento2, AV93PropostaClinicaDocumento2, AV24PropostaPacienteClienteRazaoSocial2, AV25ContratoNome2, AV26ConvenioCategoriaDescricao2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV95PropostaResponsavelDocumento3, AV96PropostaPacienteClienteDocumento3, AV97PropostaClinicaDocumento3, AV30PropostaPacienteClienteRazaoSocial3, AV31ContratoNome3, AV32ConvenioCategoriaDescricao3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV98Pgmname, AV15FilterFullText, AV86PropostaMaxReembolsoId_F1, AV90PropostaMaxReembolsoId_F2, AV94PropostaMaxReembolsoId_F3, AV41TFPropostaPacienteClienteRazaoSocial, AV42TFPropostaPacienteClienteRazaoSocial_Sel, AV45TFPropostaDescricao, AV46TFPropostaDescricao_Sel, AV47TFPropostaValor, AV48TFPropostaValor_To, AV49TFPropostaTaxaAdministrativa, AV50TFPropostaTaxaAdministrativa_To, AV77TFPropostaValorTaxa_F, AV78TFPropostaValorTaxa_F_To, AV53TFPropostaJurosMora, AV54TFPropostaJurosMora_To, AV81TFPropostaDataCreditoCliente_F, AV82TFPropostaDataCreditoCliente_F_To, AV79TFPropostaValorJurosMora_F, AV80TFPropostaValorJurosMora_F_To, AV74TFPropostaSecUserName, AV75TFPropostaSecUserName_Sel, AV61TFPropostaStatus_Sels, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E236J2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E116J2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpDemonstrativoPagamentoFilters")) + "," + UrlEncode(StringUtil.RTrim(AV98Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpDemonstrativoPagamentoFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpDemonstrativoPagamentoFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV39ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV98Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV10GridState.FromXml(AV39ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61TFPropostaStatus_Sels", AV61TFPropostaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E186J2( )
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
         new wpdemonstrativopagamentoexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         if ( StringUtil.StrCmp(AV35ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV35ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV36ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61TFPropostaStatus_Sels", AV61TFPropostaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
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
         edtavPropostapacienteclienterazaosocial1_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial1_Visible), 5, 0), true);
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial1_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial1_Visible), 5, 0), true);
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
         edtavPropostapacienteclientedocumento2_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
         edtavPropostaclinicadocumento2_Visible = 0;
         AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
         edtavPropostapacienteclienterazaosocial2_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial2_Visible), 5, 0), true);
         edtavContratonome2_Visible = 0;
         AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
         edtavConveniocategoriadescricao2_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f2_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento2_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento2_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial2_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         edtavPropostapacienteclienterazaosocial3_Visible = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial3_Visible), 5, 0), true);
         edtavContratonome3_Visible = 0;
         AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
         edtavConveniocategoriadescricao3_Visible = 0;
         AssignProp("", false, edtavConveniocategoriadescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
         {
            edtavPropostamaxreembolsoid_f3_Visible = 1;
            AssignProp("", false, edtavPropostamaxreembolsoid_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostamaxreembolsoid_f3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
         {
            edtavPropostaresponsaveldocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaresponsaveldocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsaveldocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            edtavPropostapacienteclientedocumento3_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
         {
            edtavPropostaclinicadocumento3_Visible = 1;
            AssignProp("", false, edtavPropostaclinicadocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaclinicadocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavPropostapacienteclienterazaosocial3_Visible = 1;
            AssignProp("", false, edtavPropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
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
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV90PropostaMaxReembolsoId_F2 = 0;
         AssignAttri("", false, "AV90PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "PROPOSTAMAXREEMBOLSOID_F";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV94PropostaMaxReembolsoId_F3 = 0;
         AssignAttri("", false, "AV94PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpDemonstrativoPagamentoFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV41TFPropostaPacienteClienteRazaoSocial = "";
         AssignAttri("", false, "AV41TFPropostaPacienteClienteRazaoSocial", AV41TFPropostaPacienteClienteRazaoSocial);
         AV42TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV42TFPropostaPacienteClienteRazaoSocial_Sel", AV42TFPropostaPacienteClienteRazaoSocial_Sel);
         AV45TFPropostaDescricao = "";
         AssignAttri("", false, "AV45TFPropostaDescricao", AV45TFPropostaDescricao);
         AV46TFPropostaDescricao_Sel = "";
         AssignAttri("", false, "AV46TFPropostaDescricao_Sel", AV46TFPropostaDescricao_Sel);
         AV47TFPropostaValor = 0;
         AssignAttri("", false, "AV47TFPropostaValor", StringUtil.LTrimStr( AV47TFPropostaValor, 18, 2));
         AV48TFPropostaValor_To = 0;
         AssignAttri("", false, "AV48TFPropostaValor_To", StringUtil.LTrimStr( AV48TFPropostaValor_To, 18, 2));
         AV49TFPropostaTaxaAdministrativa = 0;
         AssignAttri("", false, "AV49TFPropostaTaxaAdministrativa", StringUtil.LTrimStr( AV49TFPropostaTaxaAdministrativa, 16, 4));
         AV50TFPropostaTaxaAdministrativa_To = 0;
         AssignAttri("", false, "AV50TFPropostaTaxaAdministrativa_To", StringUtil.LTrimStr( AV50TFPropostaTaxaAdministrativa_To, 16, 4));
         AV77TFPropostaValorTaxa_F = 0;
         AssignAttri("", false, "AV77TFPropostaValorTaxa_F", StringUtil.LTrimStr( AV77TFPropostaValorTaxa_F, 18, 2));
         AV78TFPropostaValorTaxa_F_To = 0;
         AssignAttri("", false, "AV78TFPropostaValorTaxa_F_To", StringUtil.LTrimStr( AV78TFPropostaValorTaxa_F_To, 18, 2));
         AV53TFPropostaJurosMora = 0;
         AssignAttri("", false, "AV53TFPropostaJurosMora", StringUtil.LTrimStr( AV53TFPropostaJurosMora, 16, 4));
         AV54TFPropostaJurosMora_To = 0;
         AssignAttri("", false, "AV54TFPropostaJurosMora_To", StringUtil.LTrimStr( AV54TFPropostaJurosMora_To, 16, 4));
         AV81TFPropostaDataCreditoCliente_F = DateTime.MinValue;
         AssignAttri("", false, "AV81TFPropostaDataCreditoCliente_F", context.localUtil.Format(AV81TFPropostaDataCreditoCliente_F, "99/99/9999"));
         AV82TFPropostaDataCreditoCliente_F_To = DateTime.MinValue;
         AssignAttri("", false, "AV82TFPropostaDataCreditoCliente_F_To", context.localUtil.Format(AV82TFPropostaDataCreditoCliente_F_To, "99/99/9999"));
         AV79TFPropostaValorJurosMora_F = 0;
         AssignAttri("", false, "AV79TFPropostaValorJurosMora_F", StringUtil.LTrimStr( AV79TFPropostaValorJurosMora_F, 18, 2));
         AV80TFPropostaValorJurosMora_F_To = 0;
         AssignAttri("", false, "AV80TFPropostaValorJurosMora_F_To", StringUtil.LTrimStr( AV80TFPropostaValorJurosMora_F_To, 18, 2));
         AV74TFPropostaSecUserName = "";
         AssignAttri("", false, "AV74TFPropostaSecUserName", AV74TFPropostaSecUserName);
         AV75TFPropostaSecUserName_Sel = "";
         AssignAttri("", false, "AV75TFPropostaSecUserName_Sel", AV75TFPropostaSecUserName_Sel);
         AV61TFPropostaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
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
         AV86PropostaMaxReembolsoId_F1 = 0;
         AssignAttri("", false, "AV86PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0));
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
         if ( StringUtil.StrCmp(AV37Session.Get(AV98Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV98Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV37Session.Get(AV98Pgmname+"GridState"), null, "", "");
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
         AV148GXV1 = 1;
         while ( AV148GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV148GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFPropostaPacienteClienteRazaoSocial", AV41TFPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFPropostaPacienteClienteRazaoSocial_Sel", AV42TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV45TFPropostaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFPropostaDescricao", AV45TFPropostaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV46TFPropostaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFPropostaDescricao_Sel", AV46TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV47TFPropostaValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV47TFPropostaValor", StringUtil.LTrimStr( AV47TFPropostaValor, 18, 2));
               AV48TFPropostaValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV48TFPropostaValor_To", StringUtil.LTrimStr( AV48TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTATAXAADMINISTRATIVA") == 0 )
            {
               AV49TFPropostaTaxaAdministrativa = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV49TFPropostaTaxaAdministrativa", StringUtil.LTrimStr( AV49TFPropostaTaxaAdministrativa, 16, 4));
               AV50TFPropostaTaxaAdministrativa_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV50TFPropostaTaxaAdministrativa_To", StringUtil.LTrimStr( AV50TFPropostaTaxaAdministrativa_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORTAXA_F") == 0 )
            {
               AV77TFPropostaValorTaxa_F = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV77TFPropostaValorTaxa_F", StringUtil.LTrimStr( AV77TFPropostaValorTaxa_F, 18, 2));
               AV78TFPropostaValorTaxa_F_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV78TFPropostaValorTaxa_F_To", StringUtil.LTrimStr( AV78TFPropostaValorTaxa_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAJUROSMORA") == 0 )
            {
               AV53TFPropostaJurosMora = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV53TFPropostaJurosMora", StringUtil.LTrimStr( AV53TFPropostaJurosMora, 16, 4));
               AV54TFPropostaJurosMora_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV54TFPropostaJurosMora_To", StringUtil.LTrimStr( AV54TFPropostaJurosMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADATACREDITOCLIENTE_F") == 0 )
            {
               AV81TFPropostaDataCreditoCliente_F = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV81TFPropostaDataCreditoCliente_F", context.localUtil.Format(AV81TFPropostaDataCreditoCliente_F, "99/99/9999"));
               AV82TFPropostaDataCreditoCliente_F_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV82TFPropostaDataCreditoCliente_F_To", context.localUtil.Format(AV82TFPropostaDataCreditoCliente_F_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORJUROSMORA_F") == 0 )
            {
               AV79TFPropostaValorJurosMora_F = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV79TFPropostaValorJurosMora_F", StringUtil.LTrimStr( AV79TFPropostaValorJurosMora_F, 18, 2));
               AV80TFPropostaValorJurosMora_F_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV80TFPropostaValorJurosMora_F_To", StringUtil.LTrimStr( AV80TFPropostaValorJurosMora_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME") == 0 )
            {
               AV74TFPropostaSecUserName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFPropostaSecUserName", AV74TFPropostaSecUserName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME_SEL") == 0 )
            {
               AV75TFPropostaSecUserName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFPropostaSecUserName_Sel", AV75TFPropostaSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV60TFPropostaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFPropostaStatus_SelsJson", AV60TFPropostaStatus_SelsJson);
               AV61TFPropostaStatus_Sels.FromJSonString(AV60TFPropostaStatus_SelsJson, null);
            }
            AV148GXV1 = (int)(AV148GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPropostaPacienteClienteRazaoSocial_Sel)),  AV42TFPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPropostaDescricao_Sel)),  AV46TFPropostaDescricao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPropostaSecUserName_Sel)),  AV75TFPropostaSecUserName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV61TFPropostaStatus_Sels.Count==0),  AV60TFPropostaStatus_SelsJson, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|||||||"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPropostaPacienteClienteRazaoSocial)),  AV41TFPropostaPacienteClienteRazaoSocial, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPropostaDescricao)),  AV45TFPropostaDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPropostaSecUserName)),  AV74TFPropostaSecUserName, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+((Convert.ToDecimal(0)==AV47TFPropostaValor) ? "" : StringUtil.Str( AV47TFPropostaValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV49TFPropostaTaxaAdministrativa) ? "" : StringUtil.Str( AV49TFPropostaTaxaAdministrativa, 16, 4))+"|"+((Convert.ToDecimal(0)==AV77TFPropostaValorTaxa_F) ? "" : StringUtil.Str( AV77TFPropostaValorTaxa_F, 18, 2))+"|"+((Convert.ToDecimal(0)==AV53TFPropostaJurosMora) ? "" : StringUtil.Str( AV53TFPropostaJurosMora, 16, 4))+"|"+((DateTime.MinValue==AV81TFPropostaDataCreditoCliente_F) ? "" : context.localUtil.DToC( AV81TFPropostaDataCreditoCliente_F, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV79TFPropostaValorJurosMora_F) ? "" : StringUtil.Str( AV79TFPropostaValorJurosMora_F, 18, 2))+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((Convert.ToDecimal(0)==AV48TFPropostaValor_To) ? "" : StringUtil.Str( AV48TFPropostaValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV50TFPropostaTaxaAdministrativa_To) ? "" : StringUtil.Str( AV50TFPropostaTaxaAdministrativa_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV78TFPropostaValorTaxa_F_To) ? "" : StringUtil.Str( AV78TFPropostaValorTaxa_F_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV54TFPropostaJurosMora_To) ? "" : StringUtil.Str( AV54TFPropostaJurosMora_To, 16, 4))+"|"+((DateTime.MinValue==AV82TFPropostaDataCreditoCliente_F_To) ? "" : context.localUtil.DToC( AV82TFPropostaDataCreditoCliente_F_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV80TFPropostaValorJurosMora_F_To) ? "" : StringUtil.Str( AV80TFPropostaValorJurosMora_F_To, 18, 2))+"||";
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
               AV86PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV86PropostaMaxReembolsoId_F1", StringUtil.LTrimStr( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV87PropostaResponsavelDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV87PropostaResponsavelDocumento1", AV87PropostaResponsavelDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV88PropostaPacienteClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV88PropostaPacienteClienteDocumento1", AV88PropostaPacienteClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV89PropostaClinicaDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV89PropostaClinicaDocumento1", AV89PropostaClinicaDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18PropostaPacienteClienteRazaoSocial1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18PropostaPacienteClienteRazaoSocial1", AV18PropostaPacienteClienteRazaoSocial1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ContratoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20ConvenioCategoriaDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ConvenioCategoriaDescricao1", AV20ConvenioCategoriaDescricao1);
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
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV90PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV90PropostaMaxReembolsoId_F2", StringUtil.LTrimStr( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV91PropostaResponsavelDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV91PropostaResponsavelDocumento2", AV91PropostaResponsavelDocumento2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV92PropostaPacienteClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV92PropostaPacienteClienteDocumento2", AV92PropostaPacienteClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV93PropostaClinicaDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV93PropostaClinicaDocumento2", AV93PropostaClinicaDocumento2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24PropostaPacienteClienteRazaoSocial2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24PropostaPacienteClienteRazaoSocial2", AV24PropostaPacienteClienteRazaoSocial2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV25ContratoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ContratoNome2", AV25ContratoNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV26ConvenioCategoriaDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26ConvenioCategoriaDescricao2", AV26ConvenioCategoriaDescricao2);
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
                  AV27DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV94PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV94PropostaMaxReembolsoId_F3", StringUtil.LTrimStr( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV95PropostaResponsavelDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV95PropostaResponsavelDocumento3", AV95PropostaResponsavelDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV96PropostaPacienteClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV96PropostaPacienteClienteDocumento3", AV96PropostaPacienteClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV97PropostaClinicaDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV97PropostaClinicaDocumento3", AV97PropostaClinicaDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30PropostaPacienteClienteRazaoSocial3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV30PropostaPacienteClienteRazaoSocial3", AV30PropostaPacienteClienteRazaoSocial3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31ContratoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ContratoNome3", AV31ContratoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV32ConvenioCategoriaDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32ConvenioCategoriaDescricao3", AV32ConvenioCategoriaDescricao3);
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
         if ( AV33DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV37Session.Get(AV98Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPropostaPacienteClienteRazaoSocial)),  0,  AV41TFPropostaPacienteClienteRazaoSocial,  AV41TFPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPropostaPacienteClienteRazaoSocial_Sel)),  AV42TFPropostaPacienteClienteRazaoSocial_Sel,  AV42TFPropostaPacienteClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTADESCRICAO",  "Descricao",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPropostaDescricao)),  0,  AV45TFPropostaDescricao,  AV45TFPropostaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPropostaDescricao_Sel)),  AV46TFPropostaDescricao_Sel,  AV46TFPropostaDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV47TFPropostaValor)&&(Convert.ToDecimal(0)==AV48TFPropostaValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV47TFPropostaValor, 18, 2)),  ((Convert.ToDecimal(0)==AV47TFPropostaValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV48TFPropostaValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV48TFPropostaValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFPropostaValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTATAXAADMINISTRATIVA",  "(%)Taxa",  !((Convert.ToDecimal(0)==AV49TFPropostaTaxaAdministrativa)&&(Convert.ToDecimal(0)==AV50TFPropostaTaxaAdministrativa_To)),  0,  StringUtil.Trim( StringUtil.Str( AV49TFPropostaTaxaAdministrativa, 16, 4)),  ((Convert.ToDecimal(0)==AV49TFPropostaTaxaAdministrativa) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFPropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV50TFPropostaTaxaAdministrativa_To, 16, 4)),  ((Convert.ToDecimal(0)==AV50TFPropostaTaxaAdministrativa_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV50TFPropostaTaxaAdministrativa_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAVALORTAXA_F",  "Taxa",  !((Convert.ToDecimal(0)==AV77TFPropostaValorTaxa_F)&&(Convert.ToDecimal(0)==AV78TFPropostaValorTaxa_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV77TFPropostaValorTaxa_F, 18, 2)),  ((Convert.ToDecimal(0)==AV77TFPropostaValorTaxa_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV77TFPropostaValorTaxa_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV78TFPropostaValorTaxa_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV78TFPropostaValorTaxa_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV78TFPropostaValorTaxa_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAJUROSMORA",  "(%)Juros mora",  !((Convert.ToDecimal(0)==AV53TFPropostaJurosMora)&&(Convert.ToDecimal(0)==AV54TFPropostaJurosMora_To)),  0,  StringUtil.Trim( StringUtil.Str( AV53TFPropostaJurosMora, 16, 4)),  ((Convert.ToDecimal(0)==AV53TFPropostaJurosMora) ? "" : StringUtil.Trim( context.localUtil.Format( AV53TFPropostaJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV54TFPropostaJurosMora_To, 16, 4)),  ((Convert.ToDecimal(0)==AV54TFPropostaJurosMora_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV54TFPropostaJurosMora_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTADATACREDITOCLIENTE_F",  "Data",  !((DateTime.MinValue==AV81TFPropostaDataCreditoCliente_F)&&(DateTime.MinValue==AV82TFPropostaDataCreditoCliente_F_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV81TFPropostaDataCreditoCliente_F, 4, "/")),  ((DateTime.MinValue==AV81TFPropostaDataCreditoCliente_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV81TFPropostaDataCreditoCliente_F, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV82TFPropostaDataCreditoCliente_F_To, 4, "/")),  ((DateTime.MinValue==AV82TFPropostaDataCreditoCliente_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV82TFPropostaDataCreditoCliente_F_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAVALORJUROSMORA_F",  "Juros mora",  !((Convert.ToDecimal(0)==AV79TFPropostaValorJurosMora_F)&&(Convert.ToDecimal(0)==AV80TFPropostaValorJurosMora_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV79TFPropostaValorJurosMora_F, 18, 2)),  ((Convert.ToDecimal(0)==AV79TFPropostaValorJurosMora_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV79TFPropostaValorJurosMora_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV80TFPropostaValorJurosMora_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV80TFPropostaValorJurosMora_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV80TFPropostaValorJurosMora_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTASECUSERNAME",  "Clinica",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPropostaSecUserName)),  0,  AV74TFPropostaSecUserName,  AV74TFPropostaSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPropostaSecUserName_Sel)),  AV75TFPropostaSecUserName_Sel,  AV75TFPropostaSecUserName_Sel) ;
         AV73AuxText = ((AV61TFPropostaStatus_Sels.Count==1) ? "["+((string)AV61TFPropostaStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTASTATUS_SEL",  "Status",  !(AV61TFPropostaStatus_Sels.Count==0),  0,  AV61TFPropostaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV73AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV73AuxText, "[PENDENTE]", "Pendente aprovação"), "[EM_ANALISE]", "Em análise"), "[APROVADO]", "Aprovado"), "[REJEITADO]", "Rejeitado"), "[REVISAO]", "Revisão"), "[CANCELADO]", "Cancelado"), "[AGUARDANDO_ASSINATURA]", "Aguardando assinatura"), "[AnaliseReprovada]", "Análise reprovada")),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV98Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV34DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV86PropostaMaxReembolsoId_F1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV86PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV86PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV86PropostaMaxReembolsoId_F1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV87PropostaResponsavelDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV17DynamicFiltersOperator1,  AV87PropostaResponsavelDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV87PropostaResponsavelDocumento1, "Contém"+" "+AV87PropostaResponsavelDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV88PropostaPacienteClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV17DynamicFiltersOperator1,  AV88PropostaPacienteClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV88PropostaPacienteClienteDocumento1, "Contém"+" "+AV88PropostaPacienteClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV89PropostaClinicaDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV17DynamicFiltersOperator1,  AV89PropostaClinicaDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV89PropostaClinicaDocumento1, "Contém"+" "+AV89PropostaClinicaDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PropostaPacienteClienteRazaoSocial1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV17DynamicFiltersOperator1,  AV18PropostaPacienteClienteRazaoSocial1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18PropostaPacienteClienteRazaoSocial1, "Contém"+" "+AV18PropostaPacienteClienteRazaoSocial1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV17DynamicFiltersOperator1,  AV19ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ContratoNome1, "Contém"+" "+AV19ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConvenioCategoriaDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV17DynamicFiltersOperator1,  AV20ConvenioCategoriaDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20ConvenioCategoriaDescricao1, "Contém"+" "+AV20ConvenioCategoriaDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV90PropostaMaxReembolsoId_F2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV23DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV90PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV90PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV90PropostaMaxReembolsoId_F2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV91PropostaResponsavelDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV23DynamicFiltersOperator2,  AV91PropostaResponsavelDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV91PropostaResponsavelDocumento2, "Contém"+" "+AV91PropostaResponsavelDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV92PropostaPacienteClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV23DynamicFiltersOperator2,  AV92PropostaPacienteClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV92PropostaPacienteClienteDocumento2, "Contém"+" "+AV92PropostaPacienteClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV93PropostaClinicaDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV23DynamicFiltersOperator2,  AV93PropostaClinicaDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV93PropostaClinicaDocumento2, "Contém"+" "+AV93PropostaClinicaDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24PropostaPacienteClienteRazaoSocial2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV23DynamicFiltersOperator2,  AV24PropostaPacienteClienteRazaoSocial2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24PropostaPacienteClienteRazaoSocial2, "Contém"+" "+AV24PropostaPacienteClienteRazaoSocial2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV23DynamicFiltersOperator2,  AV25ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV25ContratoNome2, "Contém"+" "+AV25ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConvenioCategoriaDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV23DynamicFiltersOperator2,  AV26ConvenioCategoriaDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV26ConvenioCategoriaDescricao2, "Contém"+" "+AV26ConvenioCategoriaDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 ) && ! (0==AV94PropostaMaxReembolsoId_F3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Reembolso Id_F",  AV29DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV94PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV94PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV94PropostaMaxReembolsoId_F3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV95PropostaResponsavelDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Responsavel Documento",  AV29DynamicFiltersOperator3,  AV95PropostaResponsavelDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV95PropostaResponsavelDocumento3, "Contém"+" "+AV95PropostaResponsavelDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV96PropostaPacienteClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV29DynamicFiltersOperator3,  AV96PropostaPacienteClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV96PropostaPacienteClienteDocumento3, "Contém"+" "+AV96PropostaPacienteClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV97PropostaClinicaDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Clinica Documento",  AV29DynamicFiltersOperator3,  AV97PropostaClinicaDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV97PropostaClinicaDocumento3, "Contém"+" "+AV97PropostaClinicaDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PropostaPacienteClienteRazaoSocial3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Proposta Paciente Cliente Razao Social",  AV29DynamicFiltersOperator3,  AV30PropostaPacienteClienteRazaoSocial3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV30PropostaPacienteClienteRazaoSocial3, "Contém"+" "+AV30PropostaPacienteClienteRazaoSocial3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV29DynamicFiltersOperator3,  AV31ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV31ContratoNome3, "Contém"+" "+AV31ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ConvenioCategoriaDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV29DynamicFiltersOperator3,  AV32ConvenioCategoriaDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV32ConvenioCategoriaDescricao3, "Contém"+" "+AV32ConvenioCategoriaDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV98Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Proposta";
         AV37Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_123_6J2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
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
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV94PropostaMaxReembolsoId_F3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV94PropostaMaxReembolsoId_F3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV94PropostaMaxReembolsoId_F3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f3_Visible, edtavPropostamaxreembolsoid_f3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento3_Internalname, "Proposta Responsavel Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento3_Internalname, AV95PropostaResponsavelDocumento3, StringUtil.RTrim( context.localUtil.Format( AV95PropostaResponsavelDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento3_Visible, edtavPropostaresponsaveldocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento3_Internalname, "Proposta Paciente Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento3_Internalname, AV96PropostaPacienteClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV96PropostaPacienteClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento3_Visible, edtavPropostapacienteclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento3_Internalname, "Proposta Clinica Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento3_Internalname, AV97PropostaClinicaDocumento3, StringUtil.RTrim( context.localUtil.Format( AV97PropostaClinicaDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento3_Visible, edtavPropostaclinicadocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial3_Internalname, "Proposta Paciente Cliente Razao Social3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial3_Internalname, AV30PropostaPacienteClienteRazaoSocial3, StringUtil.RTrim( context.localUtil.Format( AV30PropostaPacienteClienteRazaoSocial3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial3_Visible, edtavPropostapacienteclienterazaosocial3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV31ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV31ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao3_Internalname, "Convenio Categoria Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao3_Internalname, AV32ConvenioCategoriaDescricao3, StringUtil.RTrim( context.localUtil.Format( AV32ConvenioCategoriaDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao3_Visible, edtavConveniocategoriadescricao3_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpDemonstrativoPagamento.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_123_6J2e( true) ;
         }
         else
         {
            wb_table3_123_6J2e( false) ;
         }
      }

      protected void wb_table2_83_6J2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
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
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90PropostaMaxReembolsoId_F2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV90PropostaMaxReembolsoId_F2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV90PropostaMaxReembolsoId_F2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f2_Visible, edtavPropostamaxreembolsoid_f2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento2_Internalname, "Proposta Responsavel Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento2_Internalname, AV91PropostaResponsavelDocumento2, StringUtil.RTrim( context.localUtil.Format( AV91PropostaResponsavelDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento2_Visible, edtavPropostaresponsaveldocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento2_Internalname, "Proposta Paciente Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento2_Internalname, AV92PropostaPacienteClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV92PropostaPacienteClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento2_Visible, edtavPropostapacienteclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento2_Internalname, "Proposta Clinica Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento2_Internalname, AV93PropostaClinicaDocumento2, StringUtil.RTrim( context.localUtil.Format( AV93PropostaClinicaDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento2_Visible, edtavPropostaclinicadocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial2_Internalname, "Proposta Paciente Cliente Razao Social2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial2_Internalname, AV24PropostaPacienteClienteRazaoSocial2, StringUtil.RTrim( context.localUtil.Format( AV24PropostaPacienteClienteRazaoSocial2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial2_Visible, edtavPropostapacienteclienterazaosocial2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV25ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV25ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao2_Internalname, "Convenio Categoria Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao2_Internalname, AV26ConvenioCategoriaDescricao2, StringUtil.RTrim( context.localUtil.Format( AV26ConvenioCategoriaDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao2_Visible, edtavConveniocategoriadescricao2_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpDemonstrativoPagamento.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpDemonstrativoPagamento.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_83_6J2e( true) ;
         }
         else
         {
            wb_table2_83_6J2e( false) ;
         }
      }

      protected void wb_table1_43_6J2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpDemonstrativoPagamento.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavPropostamaxreembolsoid_f1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86PropostaMaxReembolsoId_F1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostamaxreembolsoid_f1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV86PropostaMaxReembolsoId_F1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV86PropostaMaxReembolsoId_F1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostamaxreembolsoid_f1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostamaxreembolsoid_f1_Visible, edtavPropostamaxreembolsoid_f1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaresponsaveldocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaresponsaveldocumento1_Internalname, "Proposta Responsavel Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsaveldocumento1_Internalname, AV87PropostaResponsavelDocumento1, StringUtil.RTrim( context.localUtil.Format( AV87PropostaResponsavelDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsaveldocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsaveldocumento1_Visible, edtavPropostaresponsaveldocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento1_Internalname, "Proposta Paciente Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento1_Internalname, AV88PropostaPacienteClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV88PropostaPacienteClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclientedocumento1_Visible, edtavPropostapacienteclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaclinicadocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaclinicadocumento1_Internalname, "Proposta Clinica Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaclinicadocumento1_Internalname, AV89PropostaClinicaDocumento1, StringUtil.RTrim( context.localUtil.Format( AV89PropostaClinicaDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaclinicadocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaclinicadocumento1_Visible, edtavPropostaclinicadocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostapacienteclienterazaosocial1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial1_Internalname, "Proposta Paciente Cliente Razao Social1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial1_Internalname, AV18PropostaPacienteClienteRazaoSocial1, StringUtil.RTrim( context.localUtil.Format( AV18PropostaPacienteClienteRazaoSocial1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostapacienteclienterazaosocial1_Visible, edtavPropostapacienteclienterazaosocial1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV19ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV19ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conveniocategoriadescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao1_Internalname, "Convenio Categoria Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_159_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao1_Internalname, AV20ConvenioCategoriaDescricao1, StringUtil.RTrim( context.localUtil.Format( AV20ConvenioCategoriaDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriadescricao1_Visible, edtavConveniocategoriadescricao1_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpDemonstrativoPagamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpDemonstrativoPagamento.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpDemonstrativoPagamento.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_6J2e( true) ;
         }
         else
         {
            wb_table1_43_6J2e( false) ;
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
         PA6J2( ) ;
         WS6J2( ) ;
         WE6J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101926364", true, true);
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
         context.AddJavascriptSource("wpdemonstrativopagamento.js", "?20256101926365", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1592( )
      {
         edtavConsultatitulo_Internalname = "vCONSULTATITULO_"+sGXsfl_159_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_159_idx;
         edtPropostaPacienteClienteId_Internalname = "PROPOSTAPACIENTECLIENTEID_"+sGXsfl_159_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_159_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_159_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_159_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_159_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_159_idx;
         edtPropostaValorTaxa_F_Internalname = "PROPOSTAVALORTAXA_F_"+sGXsfl_159_idx;
         edtPropostaJurosMora_Internalname = "PROPOSTAJUROSMORA_"+sGXsfl_159_idx;
         edtPropostaDataCreditoCliente_F_Internalname = "PROPOSTADATACREDITOCLIENTE_F_"+sGXsfl_159_idx;
         edtPropostaValorJurosMora_F_Internalname = "PROPOSTAVALORJUROSMORA_F_"+sGXsfl_159_idx;
         edtPropostaSLA_Internalname = "PROPOSTASLA_"+sGXsfl_159_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_159_idx;
         edtPropostaSecUserName_Internalname = "PROPOSTASECUSERNAME_"+sGXsfl_159_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_159_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_159_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_159_idx;
      }

      protected void SubsflControlProps_fel_1592( )
      {
         edtavConsultatitulo_Internalname = "vCONSULTATITULO_"+sGXsfl_159_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_159_fel_idx;
         edtPropostaPacienteClienteId_Internalname = "PROPOSTAPACIENTECLIENTEID_"+sGXsfl_159_fel_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_159_fel_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_159_fel_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_159_fel_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_159_fel_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_159_fel_idx;
         edtPropostaValorTaxa_F_Internalname = "PROPOSTAVALORTAXA_F_"+sGXsfl_159_fel_idx;
         edtPropostaJurosMora_Internalname = "PROPOSTAJUROSMORA_"+sGXsfl_159_fel_idx;
         edtPropostaDataCreditoCliente_F_Internalname = "PROPOSTADATACREDITOCLIENTE_F_"+sGXsfl_159_fel_idx;
         edtPropostaValorJurosMora_F_Internalname = "PROPOSTAVALORJUROSMORA_F_"+sGXsfl_159_fel_idx;
         edtPropostaSLA_Internalname = "PROPOSTASLA_"+sGXsfl_159_fel_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_159_fel_idx;
         edtPropostaSecUserName_Internalname = "PROPOSTASECUSERNAME_"+sGXsfl_159_fel_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_159_fel_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_159_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_159_fel_idx;
      }

      protected void sendrow_1592( )
      {
         sGXsfl_159_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_159_idx), 4, 0), 4, "0");
         SubsflControlProps_1592( ) ;
         WB6J0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsultatitulo_Internalname,StringUtil.RTrim( AV76ConsultaTitulo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavConsultatitulo_Link,(string)"",(string)"Titulos",(string)"",(string)edtavConsultatitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsultatitulo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A504PropostaPacienteClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaPacienteClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaDescricao_Internalname,(string)A325PropostaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaTaxaAdministrativa_Internalname,StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A501PropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaTaxaAdministrativa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaValorTaxa_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A513PropostaValorTaxa_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A513PropostaValorTaxa_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaValorTaxa_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaJurosMora_Internalname,StringUtil.LTrim( StringUtil.NToC( A508PropostaJurosMora, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A508PropostaJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaJurosMora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaDataCreditoCliente_F_Internalname,context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"),context.localUtil.Format( A515PropostaDataCreditoCliente_F, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaDataCreditoCliente_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaValorJurosMora_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A514PropostaValorJurosMora_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A514PropostaValorJurosMora_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaValorJurosMora_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaSLA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A507PropostaSLA), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A507PropostaSLA), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaSLA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaSecUserName_Internalname,(string)A512PropostaSecUserName,StringUtil.RTrim( context.localUtil.Format( A512PropostaSecUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), !bGXsfl_159_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)159,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6J2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector1.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Contrato Nome", 0);
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
         cmbavDynamicfiltersselector2.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Contrato Nome", 0);
         cmbavDynamicfiltersselector2.addItem("CONVENIOCATEGORIADESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROPOSTAMAXREEMBOLSOID_F", "Reembolso Id_F", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTARESPONSAVELDOCUMENTO", "Responsavel Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTAPACIENTECLIENTEDOCUMENTO", "Cliente Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTACLINICADOCUMENTO", "Clinica Documento", 0);
         cmbavDynamicfiltersselector3.addItem("PROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Proposta Paciente Cliente Razao Social", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Contrato Nome", 0);
         cmbavDynamicfiltersselector3.addItem("CONVENIOCATEGORIADESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "PROPOSTASTATUS_" + sGXsfl_159_idx;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Medicos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descricao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "(%)Taxa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "(%)Juros mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Juros mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "SLA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Crated By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Clinica") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV76ConsultaTitulo)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsultatitulo_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavConsultatitulo_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A505PropostaPacienteClienteRazaoSocial));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A513PropostaValorTaxa_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A508PropostaJurosMora, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A514PropostaValorJurosMora_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A507PropostaSLA), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A512PropostaSecUserName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329PropostaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbPropostaStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
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
         edtavPropostapacienteclientedocumento1_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO1";
         cellFilter_propostapacienteclientedocumento1_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO1_CELL";
         edtavPropostaclinicadocumento1_Internalname = "vPROPOSTACLINICADOCUMENTO1";
         cellFilter_propostaclinicadocumento1_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO1_CELL";
         edtavPropostapacienteclienterazaosocial1_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1";
         cellFilter_propostapacienteclienterazaosocial1_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL1_CELL";
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
         edtavPropostapacienteclientedocumento2_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO2";
         cellFilter_propostapacienteclientedocumento2_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO2_CELL";
         edtavPropostaclinicadocumento2_Internalname = "vPROPOSTACLINICADOCUMENTO2";
         cellFilter_propostaclinicadocumento2_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO2_CELL";
         edtavPropostapacienteclienterazaosocial2_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2";
         cellFilter_propostapacienteclienterazaosocial2_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL2_CELL";
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
         edtavPropostapacienteclientedocumento3_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO3";
         cellFilter_propostapacienteclientedocumento3_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTEDOCUMENTO3_CELL";
         edtavPropostaclinicadocumento3_Internalname = "vPROPOSTACLINICADOCUMENTO3";
         cellFilter_propostaclinicadocumento3_cell_Internalname = "FILTER_PROPOSTACLINICADOCUMENTO3_CELL";
         edtavPropostapacienteclienterazaosocial3_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3";
         cellFilter_propostapacienteclienterazaosocial3_cell_Internalname = "FILTER_PROPOSTAPACIENTECLIENTERAZAOSOCIAL3_CELL";
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
         edtavConsultatitulo_Internalname = "vCONSULTATITULO";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtPropostaPacienteClienteId_Internalname = "PROPOSTAPACIENTECLIENTEID";
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID";
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO";
         edtPropostaValor_Internalname = "PROPOSTAVALOR";
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA";
         edtPropostaValorTaxa_F_Internalname = "PROPOSTAVALORTAXA_F";
         edtPropostaJurosMora_Internalname = "PROPOSTAJUROSMORA";
         edtPropostaDataCreditoCliente_F_Internalname = "PROPOSTADATACREDITOCLIENTE_F";
         edtPropostaValorJurosMora_F_Internalname = "PROPOSTAVALORJUROSMORA_F";
         edtPropostaSLA_Internalname = "PROPOSTASLA";
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY";
         edtPropostaSecUserName_Internalname = "PROPOSTASECUSERNAME";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_propostadatacreditocliente_fauxdatetext_Internalname = "vDDO_PROPOSTADATACREDITOCLIENTE_FAUXDATETEXT";
         Tfpropostadatacreditocliente_f_rangepicker_Internalname = "TFPROPOSTADATACREDITOCLIENTE_F_RANGEPICKER";
         divDdo_propostadatacreditocliente_fauxdates_Internalname = "DDO_PROPOSTADATACREDITOCLIENTE_FAUXDATES";
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
         edtContratoNome_Jsonclick = "";
         edtContratoId_Jsonclick = "";
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus_Columnclass = "WWColumn";
         edtPropostaSecUserName_Jsonclick = "";
         edtPropostaCratedBy_Jsonclick = "";
         edtPropostaSLA_Jsonclick = "";
         edtPropostaValorJurosMora_F_Jsonclick = "";
         edtPropostaDataCreditoCliente_F_Jsonclick = "";
         edtPropostaJurosMora_Jsonclick = "";
         edtPropostaValorTaxa_F_Jsonclick = "";
         edtPropostaTaxaAdministrativa_Jsonclick = "";
         edtPropostaValor_Jsonclick = "";
         edtPropostaDescricao_Jsonclick = "";
         edtProcedimentosMedicosId_Jsonclick = "";
         edtPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtPropostaPacienteClienteId_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtavConsultatitulo_Jsonclick = "";
         edtavConsultatitulo_Link = "";
         edtavConsultatitulo_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavConveniocategoriadescricao1_Jsonclick = "";
         edtavConveniocategoriadescricao1_Enabled = 1;
         edtavContratonome1_Jsonclick = "";
         edtavContratonome1_Enabled = 1;
         edtavPropostapacienteclienterazaosocial1_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial1_Enabled = 1;
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
         edtavContratonome2_Jsonclick = "";
         edtavContratonome2_Enabled = 1;
         edtavPropostapacienteclienterazaosocial2_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial2_Enabled = 1;
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
         edtavContratonome3_Jsonclick = "";
         edtavContratonome3_Enabled = 1;
         edtavPropostapacienteclienterazaosocial3_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial3_Enabled = 1;
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
         edtavContratonome3_Visible = 1;
         edtavPropostapacienteclienterazaosocial3_Visible = 1;
         edtavPropostaclinicadocumento3_Visible = 1;
         edtavPropostapacienteclientedocumento3_Visible = 1;
         edtavPropostaresponsaveldocumento3_Visible = 1;
         edtavPropostamaxreembolsoid_f3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavConveniocategoriadescricao2_Visible = 1;
         edtavContratonome2_Visible = 1;
         edtavPropostapacienteclienterazaosocial2_Visible = 1;
         edtavPropostaclinicadocumento2_Visible = 1;
         edtavPropostapacienteclientedocumento2_Visible = 1;
         edtavPropostaresponsaveldocumento2_Visible = 1;
         edtavPropostamaxreembolsoid_f2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavConveniocategoriadescricao1_Visible = 1;
         edtavContratonome1_Visible = 1;
         edtavPropostapacienteclienterazaosocial1_Visible = 1;
         edtavPropostaclinicadocumento1_Visible = 1;
         edtavPropostapacienteclientedocumento1_Visible = 1;
         edtavPropostaresponsaveldocumento1_Visible = 1;
         edtavPropostamaxreembolsoid_f1_Visible = 1;
         cmbPropostaStatus_Columnheaderclass = "";
         edtContratoNome_Enabled = 0;
         edtContratoId_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtPropostaSecUserName_Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         edtPropostaSLA_Enabled = 0;
         edtPropostaValorJurosMora_F_Enabled = 0;
         edtPropostaDataCreditoCliente_F_Enabled = 0;
         edtPropostaJurosMora_Enabled = 0;
         edtPropostaValorTaxa_F_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaPacienteClienteId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_propostadatacreditocliente_fauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "||18.2|16.2|18.2|16.2||18.2||";
         Ddo_grid_Datalistproc = "WpDemonstrativoPagamentoGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||||PENDENTE:Pendente aprovação,EM_ANALISE:Em análise,APROVADO:Aprovado,REJEITADO:Rejeitado,REVISAO:Revisão,CANCELADO:Cancelado,AGUARDANDO_ASSINATURA:Aguardando assinatura,AnaliseReprovada:Análise reprovada";
         Ddo_grid_Allowmultipleselection = "|||||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||||||Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T|T|||||||T|T";
         Ddo_grid_Filterisrange = "||T|T|T|T|P|T||";
         Ddo_grid_Filtertype = "Character|Character|Numeric|Numeric|Numeric|Numeric|Date|Numeric|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T|T|T|T||T|||T|T";
         Ddo_grid_Columnssortvalues = "2|3|4|5||6|||7|8";
         Ddo_grid_Columnids = "3:PropostaPacienteClienteRazaoSocial|5:PropostaDescricao|6:PropostaValor|7:PropostaTaxaAdministrativa|8:PropostaValorTaxa_F|9:PropostaJurosMora|10:PropostaDataCreditoCliente_F|11:PropostaValorJurosMora_F|14:PropostaSecUserName|15:PropostaStatus";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E146J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV60TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E266J2","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbPropostaStatus"},{"av":"A329PropostaStatus","fld":"PROPOSTASTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV76ConsultaTitulo","fld":"vCONSULTATITULO","type":"char"},{"av":"edtavConsultatitulo_Link","ctrl":"vCONSULTATITULO","prop":"Link"},{"av":"cmbPropostaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E196J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E156J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E206J2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E216J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E166J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E226J2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E176J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E236J2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV60TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV60TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"},{"av":"AV70GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV71GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV72GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E186J2","iparms":[{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV60TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV87PropostaResponsavelDocumento1","fld":"vPROPOSTARESPONSAVELDOCUMENTO1","type":"svchar"},{"av":"AV88PropostaPacienteClienteDocumento1","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV89PropostaClinicaDocumento1","fld":"vPROPOSTACLINICADOCUMENTO1","type":"svchar"},{"av":"AV18PropostaPacienteClienteRazaoSocial1","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ConvenioCategoriaDescricao1","fld":"vCONVENIOCATEGORIADESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV91PropostaResponsavelDocumento2","fld":"vPROPOSTARESPONSAVELDOCUMENTO2","type":"svchar"},{"av":"AV92PropostaPacienteClienteDocumento2","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV93PropostaClinicaDocumento2","fld":"vPROPOSTACLINICADOCUMENTO2","type":"svchar"},{"av":"AV24PropostaPacienteClienteRazaoSocial2","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV25ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26ConvenioCategoriaDescricao2","fld":"vCONVENIOCATEGORIADESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV95PropostaResponsavelDocumento3","fld":"vPROPOSTARESPONSAVELDOCUMENTO3","type":"svchar"},{"av":"AV96PropostaPacienteClienteDocumento3","fld":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV97PropostaClinicaDocumento3","fld":"vPROPOSTACLINICADOCUMENTO3","type":"svchar"},{"av":"AV30PropostaPacienteClienteRazaoSocial3","fld":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV31ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV32ConvenioCategoriaDescricao3","fld":"vCONVENIOCATEGORIADESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV98Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV86PropostaMaxReembolsoId_F1","fld":"vPROPOSTAMAXREEMBOLSOID_F1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV90PropostaMaxReembolsoId_F2","fld":"vPROPOSTAMAXREEMBOLSOID_F2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV94PropostaMaxReembolsoId_F3","fld":"vPROPOSTAMAXREEMBOLSOID_F3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV46TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV47TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFPropostaTaxaAdministrativa","fld":"vTFPROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFPropostaTaxaAdministrativa_To","fld":"vTFPROPOSTATAXAADMINISTRATIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV77TFPropostaValorTaxa_F","fld":"vTFPROPOSTAVALORTAXA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFPropostaValorTaxa_F_To","fld":"vTFPROPOSTAVALORTAXA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV53TFPropostaJurosMora","fld":"vTFPROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFPropostaJurosMora_To","fld":"vTFPROPOSTAJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV81TFPropostaDataCreditoCliente_F","fld":"vTFPROPOSTADATACREDITOCLIENTE_F","type":"date"},{"av":"AV82TFPropostaDataCreditoCliente_F_To","fld":"vTFPROPOSTADATACREDITOCLIENTE_F_TO","type":"date"},{"av":"AV79TFPropostaValorJurosMora_F","fld":"vTFPROPOSTAVALORJUROSMORA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV80TFPropostaValorJurosMora_F_To","fld":"vTFPROPOSTAVALORJUROSMORA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFPropostaSecUserName","fld":"vTFPROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV75TFPropostaSecUserName_Sel","fld":"vTFPROPOSTASECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV61TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV60TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostamaxreembolsoid_f1_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F1","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento1_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavPropostaclinicadocumento1_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO1","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial1_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavConveniocategoriadescricao1_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO1","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f2_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F2","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento2_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavPropostaclinicadocumento2_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO2","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial2_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavConveniocategoriadescricao2_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO2","prop":"Visible"},{"av":"edtavPropostamaxreembolsoid_f3_Visible","ctrl":"vPROPOSTAMAXREEMBOLSOID_F3","prop":"Visible"},{"av":"edtavPropostaresponsaveldocumento3_Visible","ctrl":"vPROPOSTARESPONSAVELDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclientedocumento3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavPropostaclinicadocumento3_Visible","ctrl":"vPROPOSTACLINICADOCUMENTO3","prop":"Visible"},{"av":"edtavPropostapacienteclienterazaosocial3_Visible","ctrl":"vPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavConveniocategoriadescricao3_Visible","ctrl":"vCONVENIOCATEGORIADESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAPACIENTECLIENTEID","""{"handler":"Valid_Propostapacienteclienteid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAPACIENTECLIENTERAZAOSOCIAL","""{"handler":"Valid_Propostapacienteclienterazaosocial","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTADESCRICAO","""{"handler":"Valid_Propostadescricao","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAVALOR","""{"handler":"Valid_Propostavalor","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTATAXAADMINISTRATIVA","""{"handler":"Valid_Propostataxaadministrativa","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAVALORTAXA_F","""{"handler":"Valid_Propostavalortaxa_f","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAJUROSMORA","""{"handler":"Valid_Propostajurosmora","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTADATACREDITOCLIENTE_F","""{"handler":"Valid_Propostadatacreditocliente_f","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAVALORJUROSMORA_F","""{"handler":"Valid_Propostavalorjurosmora_f","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTASLA","""{"handler":"Valid_Propostasla","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTACRATEDBY","""{"handler":"Valid_Propostacratedby","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTASECUSERNAME","""{"handler":"Valid_Propostasecusername","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTASTATUS","""{"handler":"Valid_Propostastatus","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Contratonome","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16DynamicFiltersSelector1 = "";
         AV87PropostaResponsavelDocumento1 = "";
         AV88PropostaPacienteClienteDocumento1 = "";
         AV89PropostaClinicaDocumento1 = "";
         AV18PropostaPacienteClienteRazaoSocial1 = "";
         AV19ContratoNome1 = "";
         AV20ConvenioCategoriaDescricao1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV91PropostaResponsavelDocumento2 = "";
         AV92PropostaPacienteClienteDocumento2 = "";
         AV93PropostaClinicaDocumento2 = "";
         AV24PropostaPacienteClienteRazaoSocial2 = "";
         AV25ContratoNome2 = "";
         AV26ConvenioCategoriaDescricao2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV95PropostaResponsavelDocumento3 = "";
         AV96PropostaPacienteClienteDocumento3 = "";
         AV97PropostaClinicaDocumento3 = "";
         AV30PropostaPacienteClienteRazaoSocial3 = "";
         AV31ContratoNome3 = "";
         AV32ConvenioCategoriaDescricao3 = "";
         AV98Pgmname = "";
         AV15FilterFullText = "";
         AV41TFPropostaPacienteClienteRazaoSocial = "";
         AV42TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV45TFPropostaDescricao = "";
         AV46TFPropostaDescricao_Sel = "";
         AV81TFPropostaDataCreditoCliente_F = DateTime.MinValue;
         AV82TFPropostaDataCreditoCliente_F_To = DateTime.MinValue;
         AV74TFPropostaSecUserName = "";
         AV75TFPropostaSecUserName_Sel = "";
         AV61TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV72GridAppliedFilters = "";
         AV68DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV83DDO_PropostaDataCreditoCliente_FAuxDate = DateTime.MinValue;
         AV84DDO_PropostaDataCreditoCliente_FAuxDateTo = DateTime.MinValue;
         AV60TFPropostaStatus_SelsJson = "";
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
         AV85DDO_PropostaDataCreditoCliente_FAuxDateText = "";
         ucTfpropostadatacreditocliente_f_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV76ConsultaTitulo = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A325PropostaDescricao = "";
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         A512PropostaSecUserName = "";
         A329PropostaStatus = "";
         A228ContratoNome = "";
         AV99Wpdemonstrativopagamentods_1_filterfulltext = "";
         AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = "";
         AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         AV107Wpdemonstrativopagamentods_9_contratonome1 = "";
         AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = "";
         AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         AV117Wpdemonstrativopagamentods_19_contratonome2 = "";
         AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = "";
         AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         AV127Wpdemonstrativopagamentods_29_contratonome3 = "";
         AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = "";
         AV131Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = "";
         AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = DateTime.MinValue;
         AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = DateTime.MinValue;
         AV145Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = "";
         AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV99Wpdemonstrativopagamentods_1_filterfulltext = "";
         lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         lV107Wpdemonstrativopagamentods_9_contratonome1 = "";
         lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         lV117Wpdemonstrativopagamentods_19_contratonome2 = "";
         lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         lV127Wpdemonstrativopagamentods_29_contratonome3 = "";
         lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         lV131Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         lV145Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A494ConvenioCategoriaDescricao = "";
         H006J5_A493ConvenioCategoriaId = new int[1] ;
         H006J5_n493ConvenioCategoriaId = new bool[] {false} ;
         H006J5_A553PropostaResponsavelId = new int[1] ;
         H006J5_n553PropostaResponsavelId = new bool[] {false} ;
         H006J5_A642PropostaClinicaId = new int[1] ;
         H006J5_n642PropostaClinicaId = new bool[] {false} ;
         H006J5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H006J5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H006J5_A652PropostaClinicaDocumento = new string[] {""} ;
         H006J5_n652PropostaClinicaDocumento = new bool[] {false} ;
         H006J5_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H006J5_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H006J5_A580PropostaResponsavelDocumento = new string[] {""} ;
         H006J5_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H006J5_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H006J5_n327PropostaCreatedAt = new bool[] {false} ;
         H006J5_A228ContratoNome = new string[] {""} ;
         H006J5_n228ContratoNome = new bool[] {false} ;
         H006J5_A227ContratoId = new int[1] ;
         H006J5_n227ContratoId = new bool[] {false} ;
         H006J5_A329PropostaStatus = new string[] {""} ;
         H006J5_n329PropostaStatus = new bool[] {false} ;
         H006J5_A512PropostaSecUserName = new string[] {""} ;
         H006J5_n512PropostaSecUserName = new bool[] {false} ;
         H006J5_A328PropostaCratedBy = new short[1] ;
         H006J5_n328PropostaCratedBy = new bool[] {false} ;
         H006J5_A513PropostaValorTaxa_F = new decimal[1] ;
         H006J5_A325PropostaDescricao = new string[] {""} ;
         H006J5_n325PropostaDescricao = new bool[] {false} ;
         H006J5_A376ProcedimentosMedicosId = new int[1] ;
         H006J5_n376ProcedimentosMedicosId = new bool[] {false} ;
         H006J5_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H006J5_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H006J5_A504PropostaPacienteClienteId = new int[1] ;
         H006J5_n504PropostaPacienteClienteId = new bool[] {false} ;
         H006J5_A323PropostaId = new int[1] ;
         H006J5_A649PropostaMaxReembolsoId_F = new int[1] ;
         H006J5_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         H006J5_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H006J5_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H006J5_A326PropostaValor = new decimal[1] ;
         H006J5_n326PropostaValor = new bool[] {false} ;
         H006J5_A508PropostaJurosMora = new decimal[1] ;
         H006J5_n508PropostaJurosMora = new bool[] {false} ;
         H006J5_A507PropostaSLA = new short[1] ;
         H006J5_n507PropostaSLA = new bool[] {false} ;
         H006J5_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         H006J5_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         H006J9_A493ConvenioCategoriaId = new int[1] ;
         H006J9_n493ConvenioCategoriaId = new bool[] {false} ;
         H006J9_A553PropostaResponsavelId = new int[1] ;
         H006J9_n553PropostaResponsavelId = new bool[] {false} ;
         H006J9_A642PropostaClinicaId = new int[1] ;
         H006J9_n642PropostaClinicaId = new bool[] {false} ;
         H006J9_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H006J9_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H006J9_A652PropostaClinicaDocumento = new string[] {""} ;
         H006J9_n652PropostaClinicaDocumento = new bool[] {false} ;
         H006J9_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H006J9_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H006J9_A580PropostaResponsavelDocumento = new string[] {""} ;
         H006J9_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H006J9_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H006J9_n327PropostaCreatedAt = new bool[] {false} ;
         H006J9_A228ContratoNome = new string[] {""} ;
         H006J9_n228ContratoNome = new bool[] {false} ;
         H006J9_A227ContratoId = new int[1] ;
         H006J9_n227ContratoId = new bool[] {false} ;
         H006J9_A329PropostaStatus = new string[] {""} ;
         H006J9_n329PropostaStatus = new bool[] {false} ;
         H006J9_A512PropostaSecUserName = new string[] {""} ;
         H006J9_n512PropostaSecUserName = new bool[] {false} ;
         H006J9_A328PropostaCratedBy = new short[1] ;
         H006J9_n328PropostaCratedBy = new bool[] {false} ;
         H006J9_A513PropostaValorTaxa_F = new decimal[1] ;
         H006J9_A325PropostaDescricao = new string[] {""} ;
         H006J9_n325PropostaDescricao = new bool[] {false} ;
         H006J9_A376ProcedimentosMedicosId = new int[1] ;
         H006J9_n376ProcedimentosMedicosId = new bool[] {false} ;
         H006J9_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H006J9_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H006J9_A504PropostaPacienteClienteId = new int[1] ;
         H006J9_n504PropostaPacienteClienteId = new bool[] {false} ;
         H006J9_A323PropostaId = new int[1] ;
         H006J9_A649PropostaMaxReembolsoId_F = new int[1] ;
         H006J9_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         H006J9_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H006J9_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H006J9_A326PropostaValor = new decimal[1] ;
         H006J9_n326PropostaValor = new bool[] {false} ;
         H006J9_A508PropostaJurosMora = new decimal[1] ;
         H006J9_n508PropostaJurosMora = new bool[] {false} ;
         H006J9_A507PropostaSLA = new short[1] ;
         H006J9_n507PropostaSLA = new bool[] {false} ;
         H006J9_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         H006J9_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV73AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdemonstrativopagamento__default(),
            new Object[][] {
                new Object[] {
               H006J5_A493ConvenioCategoriaId, H006J5_n493ConvenioCategoriaId, H006J5_A553PropostaResponsavelId, H006J5_n553PropostaResponsavelId, H006J5_A642PropostaClinicaId, H006J5_n642PropostaClinicaId, H006J5_A494ConvenioCategoriaDescricao, H006J5_n494ConvenioCategoriaDescricao, H006J5_A652PropostaClinicaDocumento, H006J5_n652PropostaClinicaDocumento,
               H006J5_A540PropostaPacienteClienteDocumento, H006J5_n540PropostaPacienteClienteDocumento, H006J5_A580PropostaResponsavelDocumento, H006J5_n580PropostaResponsavelDocumento, H006J5_A327PropostaCreatedAt, H006J5_n327PropostaCreatedAt, H006J5_A228ContratoNome, H006J5_n228ContratoNome, H006J5_A227ContratoId, H006J5_n227ContratoId,
               H006J5_A329PropostaStatus, H006J5_n329PropostaStatus, H006J5_A512PropostaSecUserName, H006J5_n512PropostaSecUserName, H006J5_A328PropostaCratedBy, H006J5_n328PropostaCratedBy, H006J5_A513PropostaValorTaxa_F, H006J5_A325PropostaDescricao, H006J5_n325PropostaDescricao, H006J5_A376ProcedimentosMedicosId,
               H006J5_n376ProcedimentosMedicosId, H006J5_A505PropostaPacienteClienteRazaoSocial, H006J5_n505PropostaPacienteClienteRazaoSocial, H006J5_A504PropostaPacienteClienteId, H006J5_n504PropostaPacienteClienteId, H006J5_A323PropostaId, H006J5_A649PropostaMaxReembolsoId_F, H006J5_n649PropostaMaxReembolsoId_F, H006J5_A501PropostaTaxaAdministrativa, H006J5_n501PropostaTaxaAdministrativa,
               H006J5_A326PropostaValor, H006J5_n326PropostaValor, H006J5_A508PropostaJurosMora, H006J5_n508PropostaJurosMora, H006J5_A507PropostaSLA, H006J5_n507PropostaSLA, H006J5_A515PropostaDataCreditoCliente_F, H006J5_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               H006J9_A493ConvenioCategoriaId, H006J9_n493ConvenioCategoriaId, H006J9_A553PropostaResponsavelId, H006J9_n553PropostaResponsavelId, H006J9_A642PropostaClinicaId, H006J9_n642PropostaClinicaId, H006J9_A494ConvenioCategoriaDescricao, H006J9_n494ConvenioCategoriaDescricao, H006J9_A652PropostaClinicaDocumento, H006J9_n652PropostaClinicaDocumento,
               H006J9_A540PropostaPacienteClienteDocumento, H006J9_n540PropostaPacienteClienteDocumento, H006J9_A580PropostaResponsavelDocumento, H006J9_n580PropostaResponsavelDocumento, H006J9_A327PropostaCreatedAt, H006J9_n327PropostaCreatedAt, H006J9_A228ContratoNome, H006J9_n228ContratoNome, H006J9_A227ContratoId, H006J9_n227ContratoId,
               H006J9_A329PropostaStatus, H006J9_n329PropostaStatus, H006J9_A512PropostaSecUserName, H006J9_n512PropostaSecUserName, H006J9_A328PropostaCratedBy, H006J9_n328PropostaCratedBy, H006J9_A513PropostaValorTaxa_F, H006J9_A325PropostaDescricao, H006J9_n325PropostaDescricao, H006J9_A376ProcedimentosMedicosId,
               H006J9_n376ProcedimentosMedicosId, H006J9_A505PropostaPacienteClienteRazaoSocial, H006J9_n505PropostaPacienteClienteRazaoSocial, H006J9_A504PropostaPacienteClienteId, H006J9_n504PropostaPacienteClienteId, H006J9_A323PropostaId, H006J9_A649PropostaMaxReembolsoId_F, H006J9_n649PropostaMaxReembolsoId_F, H006J9_A501PropostaTaxaAdministrativa, H006J9_n501PropostaTaxaAdministrativa,
               H006J9_A326PropostaValor, H006J9_n326PropostaValor, H006J9_A508PropostaJurosMora, H006J9_n508PropostaJurosMora, H006J9_A507PropostaSLA, H006J9_n507PropostaSLA, H006J9_A515PropostaDataCreditoCliente_F, H006J9_n515PropostaDataCreditoCliente_F
               }
            }
         );
         AV98Pgmname = "WpDemonstrativoPagamento";
         /* GeneXus formulas. */
         AV98Pgmname = "WpDemonstrativoPagamento";
         edtavConsultatitulo_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A507PropostaSLA ;
      private short A328PropostaCratedBy ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ;
      private short AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ;
      private short AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_159 ;
      private int nGXsfl_159_idx=1 ;
      private int AV86PropostaMaxReembolsoId_F1 ;
      private int AV90PropostaMaxReembolsoId_F2 ;
      private int AV94PropostaMaxReembolsoId_F3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A323PropostaId ;
      private int A504PropostaPacienteClienteId ;
      private int A376ProcedimentosMedicosId ;
      private int A227ContratoId ;
      private int subGrid_Islastpage ;
      private int edtavConsultatitulo_Enabled ;
      private int AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ;
      private int AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ;
      private int AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ;
      private int AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A493ConvenioCategoriaId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaPacienteClienteId_Enabled ;
      private int edtPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtProcedimentosMedicosId_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtPropostaValor_Enabled ;
      private int edtPropostaTaxaAdministrativa_Enabled ;
      private int edtPropostaValorTaxa_F_Enabled ;
      private int edtPropostaJurosMora_Enabled ;
      private int edtPropostaDataCreditoCliente_F_Enabled ;
      private int edtPropostaValorJurosMora_F_Enabled ;
      private int edtPropostaSLA_Enabled ;
      private int edtPropostaCratedBy_Enabled ;
      private int edtPropostaSecUserName_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int AV69PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPropostamaxreembolsoid_f1_Visible ;
      private int edtavPropostaresponsaveldocumento1_Visible ;
      private int edtavPropostapacienteclientedocumento1_Visible ;
      private int edtavPropostaclinicadocumento1_Visible ;
      private int edtavPropostapacienteclienterazaosocial1_Visible ;
      private int edtavContratonome1_Visible ;
      private int edtavConveniocategoriadescricao1_Visible ;
      private int edtavPropostamaxreembolsoid_f2_Visible ;
      private int edtavPropostaresponsaveldocumento2_Visible ;
      private int edtavPropostapacienteclientedocumento2_Visible ;
      private int edtavPropostaclinicadocumento2_Visible ;
      private int edtavPropostapacienteclienterazaosocial2_Visible ;
      private int edtavContratonome2_Visible ;
      private int edtavConveniocategoriadescricao2_Visible ;
      private int edtavPropostamaxreembolsoid_f3_Visible ;
      private int edtavPropostaresponsaveldocumento3_Visible ;
      private int edtavPropostapacienteclientedocumento3_Visible ;
      private int edtavPropostaclinicadocumento3_Visible ;
      private int edtavPropostapacienteclienterazaosocial3_Visible ;
      private int edtavContratonome3_Visible ;
      private int edtavConveniocategoriadescricao3_Visible ;
      private int AV148GXV1 ;
      private int edtavPropostamaxreembolsoid_f3_Enabled ;
      private int edtavPropostaresponsaveldocumento3_Enabled ;
      private int edtavPropostapacienteclientedocumento3_Enabled ;
      private int edtavPropostaclinicadocumento3_Enabled ;
      private int edtavPropostapacienteclienterazaosocial3_Enabled ;
      private int edtavContratonome3_Enabled ;
      private int edtavConveniocategoriadescricao3_Enabled ;
      private int edtavPropostamaxreembolsoid_f2_Enabled ;
      private int edtavPropostaresponsaveldocumento2_Enabled ;
      private int edtavPropostapacienteclientedocumento2_Enabled ;
      private int edtavPropostaclinicadocumento2_Enabled ;
      private int edtavPropostapacienteclienterazaosocial2_Enabled ;
      private int edtavContratonome2_Enabled ;
      private int edtavConveniocategoriadescricao2_Enabled ;
      private int edtavPropostamaxreembolsoid_f1_Enabled ;
      private int edtavPropostaresponsaveldocumento1_Enabled ;
      private int edtavPropostapacienteclientedocumento1_Enabled ;
      private int edtavPropostaclinicadocumento1_Enabled ;
      private int edtavPropostapacienteclienterazaosocial1_Enabled ;
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
      private long AV70GridCurrentPage ;
      private long AV71GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV47TFPropostaValor ;
      private decimal AV48TFPropostaValor_To ;
      private decimal AV49TFPropostaTaxaAdministrativa ;
      private decimal AV50TFPropostaTaxaAdministrativa_To ;
      private decimal AV77TFPropostaValorTaxa_F ;
      private decimal AV78TFPropostaValorTaxa_F_To ;
      private decimal AV53TFPropostaJurosMora ;
      private decimal AV54TFPropostaJurosMora_To ;
      private decimal AV79TFPropostaValorJurosMora_F ;
      private decimal AV80TFPropostaValorJurosMora_F_To ;
      private decimal A326PropostaValor ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A513PropostaValorTaxa_F ;
      private decimal A508PropostaJurosMora ;
      private decimal A514PropostaValorJurosMora_F ;
      private decimal AV133Wpdemonstrativopagamentods_35_tfpropostavalor ;
      private decimal AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to ;
      private decimal AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ;
      private decimal AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ;
      private decimal AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ;
      private decimal AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ;
      private decimal AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora ;
      private decimal AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ;
      private decimal AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ;
      private decimal AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ;
      private decimal GXt_decimal1 ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_159_idx="0001" ;
      private string AV98Pgmname ;
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
      private string divDdo_propostadatacreditocliente_fauxdates_Internalname ;
      private string edtavDdo_propostadatacreditocliente_fauxdatetext_Internalname ;
      private string edtavDdo_propostadatacreditocliente_fauxdatetext_Jsonclick ;
      private string Tfpropostadatacreditocliente_f_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV76ConsultaTitulo ;
      private string edtavConsultatitulo_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaPacienteClienteId_Internalname ;
      private string edtPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtProcedimentosMedicosId_Internalname ;
      private string edtPropostaDescricao_Internalname ;
      private string edtPropostaValor_Internalname ;
      private string edtPropostaTaxaAdministrativa_Internalname ;
      private string edtPropostaValorTaxa_F_Internalname ;
      private string edtPropostaJurosMora_Internalname ;
      private string edtPropostaDataCreditoCliente_F_Internalname ;
      private string edtPropostaValorJurosMora_F_Internalname ;
      private string edtPropostaSLA_Internalname ;
      private string edtPropostaCratedBy_Internalname ;
      private string edtPropostaSecUserName_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoNome_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavPropostamaxreembolsoid_f1_Internalname ;
      private string edtavPropostaresponsaveldocumento1_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Internalname ;
      private string edtavPropostaclinicadocumento1_Internalname ;
      private string edtavPropostapacienteclienterazaosocial1_Internalname ;
      private string edtavContratonome1_Internalname ;
      private string edtavConveniocategoriadescricao1_Internalname ;
      private string edtavPropostamaxreembolsoid_f2_Internalname ;
      private string edtavPropostaresponsaveldocumento2_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Internalname ;
      private string edtavPropostaclinicadocumento2_Internalname ;
      private string edtavPropostapacienteclienterazaosocial2_Internalname ;
      private string edtavContratonome2_Internalname ;
      private string edtavConveniocategoriadescricao2_Internalname ;
      private string edtavPropostamaxreembolsoid_f3_Internalname ;
      private string edtavPropostaresponsaveldocumento3_Internalname ;
      private string edtavPropostapacienteclientedocumento3_Internalname ;
      private string edtavPropostaclinicadocumento3_Internalname ;
      private string edtavPropostapacienteclienterazaosocial3_Internalname ;
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
      private string edtavConsultatitulo_Link ;
      private string GXEncryptionTmp ;
      private string cmbPropostaStatus_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char7 ;
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
      private string cellFilter_propostapacienteclienterazaosocial3_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial3_Jsonclick ;
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
      private string cellFilter_propostapacienteclientedocumento2_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento2_Jsonclick ;
      private string cellFilter_propostaclinicadocumento2_cell_Internalname ;
      private string edtavPropostaclinicadocumento2_Jsonclick ;
      private string cellFilter_propostapacienteclienterazaosocial2_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial2_Jsonclick ;
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
      private string cellFilter_propostapacienteclientedocumento1_cell_Internalname ;
      private string edtavPropostapacienteclientedocumento1_Jsonclick ;
      private string cellFilter_propostaclinicadocumento1_cell_Internalname ;
      private string edtavPropostaclinicadocumento1_Jsonclick ;
      private string cellFilter_propostapacienteclienterazaosocial1_cell_Internalname ;
      private string edtavPropostapacienteclienterazaosocial1_Jsonclick ;
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
      private string edtavConsultatitulo_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtPropostaPacienteClienteId_Jsonclick ;
      private string edtPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtProcedimentosMedicosId_Jsonclick ;
      private string edtPropostaDescricao_Jsonclick ;
      private string edtPropostaValor_Jsonclick ;
      private string edtPropostaTaxaAdministrativa_Jsonclick ;
      private string edtPropostaValorTaxa_F_Jsonclick ;
      private string edtPropostaJurosMora_Jsonclick ;
      private string edtPropostaDataCreditoCliente_F_Jsonclick ;
      private string edtPropostaValorJurosMora_F_Jsonclick ;
      private string edtPropostaSLA_Jsonclick ;
      private string edtPropostaCratedBy_Jsonclick ;
      private string edtPropostaSecUserName_Jsonclick ;
      private string GXCCtl ;
      private string cmbPropostaStatus_Jsonclick ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime AV81TFPropostaDataCreditoCliente_F ;
      private DateTime AV82TFPropostaDataCreditoCliente_F_To ;
      private DateTime AV83DDO_PropostaDataCreditoCliente_FAuxDate ;
      private DateTime AV84DDO_PropostaDataCreditoCliente_FAuxDateTo ;
      private DateTime A515PropostaDataCreditoCliente_F ;
      private DateTime AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ;
      private DateTime AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV34DynamicFiltersIgnoreFirst ;
      private bool AV33DynamicFiltersRemoving ;
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
      private bool n504PropostaPacienteClienteId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n376ProcedimentosMedicosId ;
      private bool n325PropostaDescricao ;
      private bool n326PropostaValor ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n508PropostaJurosMora ;
      private bool n515PropostaDataCreditoCliente_F ;
      private bool n507PropostaSLA ;
      private bool n328PropostaCratedBy ;
      private bool n512PropostaSecUserName ;
      private bool n329PropostaStatus ;
      private bool n227ContratoId ;
      private bool n228ContratoNome ;
      private bool AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ;
      private bool AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ;
      private bool n493ConvenioCategoriaId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n327PropostaCreatedAt ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool bGXsfl_159_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV60TFPropostaStatus_SelsJson ;
      private string AV39ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV87PropostaResponsavelDocumento1 ;
      private string AV88PropostaPacienteClienteDocumento1 ;
      private string AV89PropostaClinicaDocumento1 ;
      private string AV18PropostaPacienteClienteRazaoSocial1 ;
      private string AV19ContratoNome1 ;
      private string AV20ConvenioCategoriaDescricao1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV91PropostaResponsavelDocumento2 ;
      private string AV92PropostaPacienteClienteDocumento2 ;
      private string AV93PropostaClinicaDocumento2 ;
      private string AV24PropostaPacienteClienteRazaoSocial2 ;
      private string AV25ContratoNome2 ;
      private string AV26ConvenioCategoriaDescricao2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV95PropostaResponsavelDocumento3 ;
      private string AV96PropostaPacienteClienteDocumento3 ;
      private string AV97PropostaClinicaDocumento3 ;
      private string AV30PropostaPacienteClienteRazaoSocial3 ;
      private string AV31ContratoNome3 ;
      private string AV32ConvenioCategoriaDescricao3 ;
      private string AV15FilterFullText ;
      private string AV41TFPropostaPacienteClienteRazaoSocial ;
      private string AV42TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV45TFPropostaDescricao ;
      private string AV46TFPropostaDescricao_Sel ;
      private string AV74TFPropostaSecUserName ;
      private string AV75TFPropostaSecUserName_Sel ;
      private string AV72GridAppliedFilters ;
      private string AV85DDO_PropostaDataCreditoCliente_FAuxDateText ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A325PropostaDescricao ;
      private string A512PropostaSecUserName ;
      private string A329PropostaStatus ;
      private string A228ContratoNome ;
      private string AV99Wpdemonstrativopagamentods_1_filterfulltext ;
      private string AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ;
      private string AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string AV107Wpdemonstrativopagamentods_9_contratonome1 ;
      private string AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ;
      private string AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string AV117Wpdemonstrativopagamentods_19_contratonome2 ;
      private string AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ;
      private string AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string AV127Wpdemonstrativopagamentods_29_contratonome3 ;
      private string AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ;
      private string AV131Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ;
      private string AV145Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ;
      private string lV99Wpdemonstrativopagamentods_1_filterfulltext ;
      private string lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string lV107Wpdemonstrativopagamentods_9_contratonome1 ;
      private string lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string lV117Wpdemonstrativopagamentods_19_contratonome2 ;
      private string lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string lV127Wpdemonstrativopagamentods_29_contratonome3 ;
      private string lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string lV131Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string lV145Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private string AV73AuxText ;
      private IGxSession AV37Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfpropostadatacreditocliente_f_rangepicker ;
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
      private GxSimpleCollection<string> AV61TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV68DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H006J5_A493ConvenioCategoriaId ;
      private bool[] H006J5_n493ConvenioCategoriaId ;
      private int[] H006J5_A553PropostaResponsavelId ;
      private bool[] H006J5_n553PropostaResponsavelId ;
      private int[] H006J5_A642PropostaClinicaId ;
      private bool[] H006J5_n642PropostaClinicaId ;
      private string[] H006J5_A494ConvenioCategoriaDescricao ;
      private bool[] H006J5_n494ConvenioCategoriaDescricao ;
      private string[] H006J5_A652PropostaClinicaDocumento ;
      private bool[] H006J5_n652PropostaClinicaDocumento ;
      private string[] H006J5_A540PropostaPacienteClienteDocumento ;
      private bool[] H006J5_n540PropostaPacienteClienteDocumento ;
      private string[] H006J5_A580PropostaResponsavelDocumento ;
      private bool[] H006J5_n580PropostaResponsavelDocumento ;
      private DateTime[] H006J5_A327PropostaCreatedAt ;
      private bool[] H006J5_n327PropostaCreatedAt ;
      private string[] H006J5_A228ContratoNome ;
      private bool[] H006J5_n228ContratoNome ;
      private int[] H006J5_A227ContratoId ;
      private bool[] H006J5_n227ContratoId ;
      private string[] H006J5_A329PropostaStatus ;
      private bool[] H006J5_n329PropostaStatus ;
      private string[] H006J5_A512PropostaSecUserName ;
      private bool[] H006J5_n512PropostaSecUserName ;
      private short[] H006J5_A328PropostaCratedBy ;
      private bool[] H006J5_n328PropostaCratedBy ;
      private decimal[] H006J5_A513PropostaValorTaxa_F ;
      private string[] H006J5_A325PropostaDescricao ;
      private bool[] H006J5_n325PropostaDescricao ;
      private int[] H006J5_A376ProcedimentosMedicosId ;
      private bool[] H006J5_n376ProcedimentosMedicosId ;
      private string[] H006J5_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H006J5_n505PropostaPacienteClienteRazaoSocial ;
      private int[] H006J5_A504PropostaPacienteClienteId ;
      private bool[] H006J5_n504PropostaPacienteClienteId ;
      private int[] H006J5_A323PropostaId ;
      private int[] H006J5_A649PropostaMaxReembolsoId_F ;
      private bool[] H006J5_n649PropostaMaxReembolsoId_F ;
      private decimal[] H006J5_A501PropostaTaxaAdministrativa ;
      private bool[] H006J5_n501PropostaTaxaAdministrativa ;
      private decimal[] H006J5_A326PropostaValor ;
      private bool[] H006J5_n326PropostaValor ;
      private decimal[] H006J5_A508PropostaJurosMora ;
      private bool[] H006J5_n508PropostaJurosMora ;
      private short[] H006J5_A507PropostaSLA ;
      private bool[] H006J5_n507PropostaSLA ;
      private DateTime[] H006J5_A515PropostaDataCreditoCliente_F ;
      private bool[] H006J5_n515PropostaDataCreditoCliente_F ;
      private int[] H006J9_A493ConvenioCategoriaId ;
      private bool[] H006J9_n493ConvenioCategoriaId ;
      private int[] H006J9_A553PropostaResponsavelId ;
      private bool[] H006J9_n553PropostaResponsavelId ;
      private int[] H006J9_A642PropostaClinicaId ;
      private bool[] H006J9_n642PropostaClinicaId ;
      private string[] H006J9_A494ConvenioCategoriaDescricao ;
      private bool[] H006J9_n494ConvenioCategoriaDescricao ;
      private string[] H006J9_A652PropostaClinicaDocumento ;
      private bool[] H006J9_n652PropostaClinicaDocumento ;
      private string[] H006J9_A540PropostaPacienteClienteDocumento ;
      private bool[] H006J9_n540PropostaPacienteClienteDocumento ;
      private string[] H006J9_A580PropostaResponsavelDocumento ;
      private bool[] H006J9_n580PropostaResponsavelDocumento ;
      private DateTime[] H006J9_A327PropostaCreatedAt ;
      private bool[] H006J9_n327PropostaCreatedAt ;
      private string[] H006J9_A228ContratoNome ;
      private bool[] H006J9_n228ContratoNome ;
      private int[] H006J9_A227ContratoId ;
      private bool[] H006J9_n227ContratoId ;
      private string[] H006J9_A329PropostaStatus ;
      private bool[] H006J9_n329PropostaStatus ;
      private string[] H006J9_A512PropostaSecUserName ;
      private bool[] H006J9_n512PropostaSecUserName ;
      private short[] H006J9_A328PropostaCratedBy ;
      private bool[] H006J9_n328PropostaCratedBy ;
      private decimal[] H006J9_A513PropostaValorTaxa_F ;
      private string[] H006J9_A325PropostaDescricao ;
      private bool[] H006J9_n325PropostaDescricao ;
      private int[] H006J9_A376ProcedimentosMedicosId ;
      private bool[] H006J9_n376ProcedimentosMedicosId ;
      private string[] H006J9_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H006J9_n505PropostaPacienteClienteRazaoSocial ;
      private int[] H006J9_A504PropostaPacienteClienteId ;
      private bool[] H006J9_n504PropostaPacienteClienteId ;
      private int[] H006J9_A323PropostaId ;
      private int[] H006J9_A649PropostaMaxReembolsoId_F ;
      private bool[] H006J9_n649PropostaMaxReembolsoId_F ;
      private decimal[] H006J9_A501PropostaTaxaAdministrativa ;
      private bool[] H006J9_n501PropostaTaxaAdministrativa ;
      private decimal[] H006J9_A326PropostaValor ;
      private bool[] H006J9_n326PropostaValor ;
      private decimal[] H006J9_A508PropostaJurosMora ;
      private bool[] H006J9_n508PropostaJurosMora ;
      private short[] H006J9_A507PropostaSLA ;
      private bool[] H006J9_n507PropostaSLA ;
      private DateTime[] H006J9_A515PropostaDataCreditoCliente_F ;
      private bool[] H006J9_n515PropostaDataCreditoCliente_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpdemonstrativopagamento__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006J5( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                             string AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                             short AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                             string AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                             string AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                             string AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                             string AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                             string AV107Wpdemonstrativopagamentods_9_contratonome1 ,
                                             string AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                             bool AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                             string AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                             short AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                             string AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                             string AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                             string AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                             string AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                             string AV117Wpdemonstrativopagamentods_19_contratonome2 ,
                                             string AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                             bool AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                             string AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                             short AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                             string AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                             string AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                             string AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                             string AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                             string AV127Wpdemonstrativopagamentods_29_contratonome3 ,
                                             string AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                             string AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                             string AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                             string AV131Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                             decimal AV133Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                             decimal AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                             decimal AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                             decimal AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                             decimal AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                             decimal AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                             decimal AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                             decimal AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                             string AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                             string AV145Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                             int AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             decimal A501PropostaTaxaAdministrativa ,
                                             decimal A508PropostaJurosMora ,
                                             string A512PropostaSecUserName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV99Wpdemonstrativopagamentods_1_filterfulltext ,
                                             decimal A513PropostaValorTaxa_F ,
                                             decimal A514PropostaValorJurosMora_F ,
                                             int AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                             int AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                             DateTime AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                             DateTime A515PropostaDataCreditoCliente_F ,
                                             DateTime AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                             decimal AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                             decimal AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[96];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.ConvenioCategoriaId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T2.ConvenioCategoriaDescricao, T4.ClienteDocumento AS PropostaClinicaDocumento, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T3.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaCreatedAt, T5.ContratoNome, T1.ContratoId, T1.PropostaStatus, T6.SecUserFullName AS PropostaSecUserName, T1.PropostaCratedBy AS PropostaCratedBy, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T1.PropostaDescricao, T1.ProcedimentosMedicosId, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaTaxaAdministrativa, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN ConvenioCategoria T2 ON T2.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaClinicaId) LEFT JOIN Contrato T5 ON T5.ContratoId = T1.ContratoId) LEFT JOIN SecUser T6 ON T6.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE";
         scmdbuf += " '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId = T11.NotaFiscalId) LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T9 ON T9.TituloPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV107Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV107Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int8[59] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int8[60] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int8[61] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int8[62] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int8[63] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int8[64] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int8[65] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV117Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int8[66] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV117Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int8[67] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int8[68] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int8[69] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int8[70] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int8[71] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int8[72] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int8[73] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int8[74] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int8[75] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int8[76] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int8[77] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV127Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int8[78] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV127Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int8[79] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int8[80] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int8[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int8[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial = ( :AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int8[83] = 1;
         }
         if ( StringUtil.StrCmp(AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T7.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV131Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int8[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int8[85] = 1;
         }
         if ( StringUtil.StrCmp(AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV133Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int8[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int8[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int8[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int8[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int8[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int8[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int8[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int8[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName like :lV145Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int8[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName = ( :AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int8[95] = 1;
         }
         if ( StringUtil.StrCmp(AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T6.SecUserFullName))=0))");
         }
         if ( AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaDescricao, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaDescricao DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaValor, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaValor DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.SecUserFullName, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.SecUserFullName DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC, T1.PropostaId";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H006J9( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                             string AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                             short AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                             string AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                             string AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                             string AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                             string AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                             string AV107Wpdemonstrativopagamentods_9_contratonome1 ,
                                             string AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                             bool AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                             string AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                             short AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                             string AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                             string AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                             string AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                             string AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                             string AV117Wpdemonstrativopagamentods_19_contratonome2 ,
                                             string AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                             bool AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                             string AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                             short AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                             string AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                             string AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                             string AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                             string AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                             string AV127Wpdemonstrativopagamentods_29_contratonome3 ,
                                             string AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                             string AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                             string AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                             string AV131Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                             decimal AV133Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                             decimal AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                             decimal AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                             decimal AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                             decimal AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                             decimal AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                             decimal AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                             decimal AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                             string AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                             string AV145Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                             int AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             decimal A501PropostaTaxaAdministrativa ,
                                             decimal A508PropostaJurosMora ,
                                             string A512PropostaSecUserName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV99Wpdemonstrativopagamentods_1_filterfulltext ,
                                             decimal A513PropostaValorTaxa_F ,
                                             decimal A514PropostaValorJurosMora_F ,
                                             int AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                             int AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                             DateTime AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                             DateTime A515PropostaDataCreditoCliente_F ,
                                             DateTime AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                             decimal AV143Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                             decimal AV144Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[96];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.ConvenioCategoriaId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T2.ConvenioCategoriaDescricao, T4.ClienteDocumento AS PropostaClinicaDocumento, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T3.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaCreatedAt, T5.ContratoNome, T1.ContratoId, T1.PropostaStatus, T6.SecUserFullName AS PropostaSecUserName, T1.PropostaCratedBy AS PropostaCratedBy, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T1.PropostaDescricao, T1.ProcedimentosMedicosId, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaTaxaAdministrativa, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN ConvenioCategoria T2 ON T2.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaClinicaId) LEFT JOIN Contrato T5 ON T5.ContratoId = T1.ContratoId) LEFT JOIN SecUser T6 ON T6.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE";
         scmdbuf += " '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId = T11.NotaFiscalId) LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T9 ON T9.TituloPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T9.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV107Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV107Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int10[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int10[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int10[57] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int10[58] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int10[59] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int10[60] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int10[61] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int10[62] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int10[63] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int10[64] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int10[65] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV117Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int10[66] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV117Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int10[67] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int10[68] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int10[69] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int10[70] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int10[71] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int10[72] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int10[73] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int10[74] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int10[75] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int10[76] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int10[77] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV127Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int10[78] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV127Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int10[79] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int10[80] = 1;
         }
         if ( AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int10[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int10[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial = ( :AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int10[83] = 1;
         }
         if ( StringUtil.StrCmp(AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T7.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV131Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int10[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int10[85] = 1;
         }
         if ( StringUtil.StrCmp(AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV133Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int10[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int10[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int10[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int10[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int10[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int10[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int10[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int10[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName like :lV145Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int10[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName = ( :AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int10[95] = 1;
         }
         if ( StringUtil.StrCmp(AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T6.SecUserFullName))=0))");
         }
         if ( AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV147Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaDescricao, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaDescricao DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaValor, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaValor DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.SecUserFullName, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.SecUserFullName DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC, T1.PropostaId";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H006J5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (int)dynConstraints[61] , (int)dynConstraints[62] , (DateTime)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (decimal)dynConstraints[66] , (decimal)dynConstraints[67] );
               case 1 :
                     return conditional_H006J9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (int)dynConstraints[61] , (int)dynConstraints[62] , (DateTime)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (decimal)dynConstraints[66] , (decimal)dynConstraints[67] );
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
          Object[] prmH006J5;
          prmH006J5 = new Object[] {
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV127Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV127Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV131Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV133Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV145Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          Object[] prmH006J9;
          prmH006J9 = new Object[] {
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV121Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV141Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV142Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV127Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV127Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV129Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV130Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV131Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV132Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV133Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV134Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV135Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV136Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV137Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV138Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV139Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV140Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV145Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV146Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006J5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006J9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J9,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((short[]) buf[44])[0] = rslt.getShort(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((short[]) buf[44])[0] = rslt.getShort(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                return;
       }
    }

 }

}
