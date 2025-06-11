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
namespace GeneXus.Programs.costumer {
   public class wpclientes : GXDataArea
   {
      public wpclientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpclientes( IGxContext context )
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
         cmbavGridactiongroup1 = new GXCombobox();
         cmbClienteSituacao = new GXCombobox();
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
         nRC_GXsfl_186 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_186"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_186_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_186_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_186_idx = GetPar( "sGXsfl_186_idx");
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
         AV18ClienteDocumento1 = GetPar( "ClienteDocumento1");
         AV19TipoClienteDescricao1 = GetPar( "TipoClienteDescricao1");
         AV20ClienteConvenioDescricao1 = GetPar( "ClienteConvenioDescricao1");
         AV21ClienteNacionalidadeNome1 = GetPar( "ClienteNacionalidadeNome1");
         AV22ClienteProfissaoNome1 = GetPar( "ClienteProfissaoNome1");
         AV23MunicipioNome1 = GetPar( "MunicipioNome1");
         AV24BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo1"), "."), 18, MidpointRounding.ToEven));
         AV25ResponsavelNacionalidadeNome1 = GetPar( "ResponsavelNacionalidadeNome1");
         AV26ResponsavelProfissaoNome1 = GetPar( "ResponsavelProfissaoNome1");
         AV27ResponsavelMunicipioNome1 = GetPar( "ResponsavelMunicipioNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV31ClienteDocumento2 = GetPar( "ClienteDocumento2");
         AV32TipoClienteDescricao2 = GetPar( "TipoClienteDescricao2");
         AV33ClienteConvenioDescricao2 = GetPar( "ClienteConvenioDescricao2");
         AV34ClienteNacionalidadeNome2 = GetPar( "ClienteNacionalidadeNome2");
         AV35ClienteProfissaoNome2 = GetPar( "ClienteProfissaoNome2");
         AV36MunicipioNome2 = GetPar( "MunicipioNome2");
         AV37BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo2"), "."), 18, MidpointRounding.ToEven));
         AV38ResponsavelNacionalidadeNome2 = GetPar( "ResponsavelNacionalidadeNome2");
         AV39ResponsavelProfissaoNome2 = GetPar( "ResponsavelProfissaoNome2");
         AV40ResponsavelMunicipioNome2 = GetPar( "ResponsavelMunicipioNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV42DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV43DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV44ClienteDocumento3 = GetPar( "ClienteDocumento3");
         AV45TipoClienteDescricao3 = GetPar( "TipoClienteDescricao3");
         AV46ClienteConvenioDescricao3 = GetPar( "ClienteConvenioDescricao3");
         AV47ClienteNacionalidadeNome3 = GetPar( "ClienteNacionalidadeNome3");
         AV48ClienteProfissaoNome3 = GetPar( "ClienteProfissaoNome3");
         AV49MunicipioNome3 = GetPar( "MunicipioNome3");
         AV50BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo3"), "."), 18, MidpointRounding.ToEven));
         AV51ResponsavelNacionalidadeNome3 = GetPar( "ResponsavelNacionalidadeNome3");
         AV52ResponsavelProfissaoNome3 = GetPar( "ResponsavelProfissaoNome3");
         AV53ResponsavelMunicipioNome3 = GetPar( "ResponsavelMunicipioNome3");
         AV61ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV28DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV41DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV84Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV62TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV63TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV64TFResponsavelNome = GetPar( "TFResponsavelNome");
         AV65TFResponsavelNome_Sel = GetPar( "TFResponsavelNome_Sel");
         AV66TFResponsavelEmail = GetPar( "TFResponsavelEmail");
         AV67TFResponsavelEmail_Sel = GetPar( "TFResponsavelEmail_Sel");
         AV68TFClienteCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFClienteCreatedAt"));
         AV69TFClienteCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFClienteCreatedAt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV74TFClienteSituacao_Sels);
         AV75TFClienteCountNotas_F = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteCountNotas_F"), "."), 18, MidpointRounding.ToEven));
         AV76TFClienteCountNotas_F_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteCountNotas_F_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV55DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV54DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
         PA9A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9A2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costumer.wpclientes") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO1", AV18ClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO1", AV19TipoClienteDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO1", AV20ClienteConvenioDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME1", AV21ClienteNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME1", AV22ClienteProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME1", AV23MunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24BancoCodigo1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME1", AV25ResponsavelNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME1", AV26ResponsavelProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME1", AV27ResponsavelMunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV29DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO2", AV31ClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO2", AV32TipoClienteDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO2", AV33ClienteConvenioDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME2", AV34ClienteNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME2", AV35ClienteProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME2", AV36MunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37BancoCodigo2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME2", AV38ResponsavelNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME2", AV39ResponsavelProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME2", AV40ResponsavelMunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV42DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO3", AV44ClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO3", AV45TipoClienteDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO3", AV46ClienteConvenioDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME3", AV47ClienteNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME3", AV48ClienteProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME3", AV49MunicipioNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50BancoCodigo3), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME3", AV51ResponsavelNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME3", AV52ResponsavelProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME3", AV53ResponsavelMunicipioNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_186", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_186), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV59ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV59ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV81GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV77DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV77DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTECREATEDATAUXDATE", context.localUtil.DToC( AV70DDO_ClienteCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTECREATEDATAUXDATETO", context.localUtil.DToC( AV71DDO_ClienteCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV28DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV41DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV62TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV63TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME", AV64TFResponsavelNome);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME_SEL", AV65TFResponsavelNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL", AV66TFResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL_SEL", AV67TFResponsavelEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTECREATEDAT", context.localUtil.TToC( AV68TFClienteCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTECREATEDAT_TO", context.localUtil.TToC( AV69TFClienteCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTESITUACAO_SELS", AV74TFClienteSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTESITUACAO_SELS", AV74TFClienteSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTECOUNTNOTAS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75TFClienteCountNotas_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTECOUNTNOTAS_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0, ",", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV55DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV54DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "CLIENTETIPOPESSOA", A172ClienteTipoPessoa);
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEPORTALPJPF", A793TipoClientePortalPjPf);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESITUACAO_SELSJSON", AV73TFClienteSituacao_SelsJson);
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
            WE9A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9A2( ) ;
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
         return formatLink("costumer.wpclientes")  ;
      }

      public override string GetPgmname( )
      {
         return "Costumer.WpClientes" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cliente" ;
      }

      protected void WB9A0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(186), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Costumer/WpClientes.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV59ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Costumer/WpClientes.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_9A2( true) ;
         }
         else
         {
            wb_table1_43_9A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_9A2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_92_9A2( true) ;
         }
         else
         {
            wb_table2_92_9A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_92_9A2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV42DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_141_9A2( true) ;
         }
         else
         {
            wb_table3_141_9A2( false) ;
         }
         return  ;
      }

      protected void wb_table3_141_9A2e( bool wbgen )
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
            StartGridControl186( ) ;
         }
         if ( wbEnd == 186 )
         {
            wbEnd = 0;
            nRC_GXsfl_186 = (int)(nGXsfl_186_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV79GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV80GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV81GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Costumer/WpClientes.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV77DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_clientecreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_clientecreatedatauxdatetext_Internalname, AV72DDO_ClienteCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV72DDO_ClienteCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_clientecreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            /* User Defined Control */
            ucTfclientecreatedat_rangepicker.SetProperty("Start Date", AV70DDO_ClienteCreatedAtAuxDate);
            ucTfclientecreatedat_rangepicker.SetProperty("End Date", AV71DDO_ClienteCreatedAtAuxDateTo);
            ucTfclientecreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfclientecreatedat_rangepicker_Internalname, "TFCLIENTECREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 186 )
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

      protected void START9A2( )
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
         STRUP9A0( ) ;
      }

      protected void WS9A2( )
      {
         START9A2( ) ;
         EVT9A2( ) ;
      }

      protected void EVT9A2( )
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
                              E119A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E189A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E199A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E209A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E219A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E229A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239A2 ();
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
                              nGXsfl_186_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
                              SubsflControlProps_1862( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV83GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV83GridActionGroup1), 4, 0));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A436ResponsavelNome = cgiGet( edtResponsavelNome_Internalname);
                              n436ResponsavelNome = false;
                              A456ResponsavelEmail = cgiGet( edtResponsavelEmail_Internalname);
                              n456ResponsavelEmail = false;
                              A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
                              n171ClienteNomeFantasia = false;
                              A175ClienteCreatedAt = context.localUtil.CToT( cgiGet( edtClienteCreatedAt_Internalname), 0);
                              n175ClienteCreatedAt = false;
                              cmbClienteSituacao.Name = cmbClienteSituacao_Internalname;
                              cmbClienteSituacao.CurrentValue = cgiGet( cmbClienteSituacao_Internalname);
                              A884ClienteSituacao = cgiGet( cmbClienteSituacao_Internalname);
                              n884ClienteSituacao = false;
                              A886ClienteCountNotas_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteCountNotas_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n886ClienteCountNotas_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E249A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E259A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E269A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E279A2 ();
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
                                       /* Set Refresh If Clientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV18ClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV19TipoClienteDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV20ClienteConvenioDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV21ClienteNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV22ClienteProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV23MunicipioNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV24BancoCodigo1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV25ResponsavelNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV26ResponsavelProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV27ResponsavelMunicipioNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV31ClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV32TipoClienteDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV33ClienteConvenioDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV34ClienteNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV35ClienteProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV36MunicipioNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV37BancoCodigo2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV38ResponsavelNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV39ResponsavelProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV40ResponsavelMunicipioNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV42DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV43DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV44ClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV45TipoClienteDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV46ClienteConvenioDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV47ClienteNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV48ClienteProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV49MunicipioNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV50BancoCodigo3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV51ResponsavelNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV52ResponsavelProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV53ResponsavelMunicipioNome3) != 0 )
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

      protected void WE9A2( )
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

      protected void PA9A2( )
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
         SubsflControlProps_1862( ) ;
         while ( nGXsfl_186_idx <= nRC_GXsfl_186 )
         {
            sendrow_1862( ) ;
            nGXsfl_186_idx = ((subGrid_Islastpage==1)&&(nGXsfl_186_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_186_idx+1);
            sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
            SubsflControlProps_1862( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18ClienteDocumento1 ,
                                       string AV19TipoClienteDescricao1 ,
                                       string AV20ClienteConvenioDescricao1 ,
                                       string AV21ClienteNacionalidadeNome1 ,
                                       string AV22ClienteProfissaoNome1 ,
                                       string AV23MunicipioNome1 ,
                                       int AV24BancoCodigo1 ,
                                       string AV25ResponsavelNacionalidadeNome1 ,
                                       string AV26ResponsavelProfissaoNome1 ,
                                       string AV27ResponsavelMunicipioNome1 ,
                                       string AV29DynamicFiltersSelector2 ,
                                       short AV30DynamicFiltersOperator2 ,
                                       string AV31ClienteDocumento2 ,
                                       string AV32TipoClienteDescricao2 ,
                                       string AV33ClienteConvenioDescricao2 ,
                                       string AV34ClienteNacionalidadeNome2 ,
                                       string AV35ClienteProfissaoNome2 ,
                                       string AV36MunicipioNome2 ,
                                       int AV37BancoCodigo2 ,
                                       string AV38ResponsavelNacionalidadeNome2 ,
                                       string AV39ResponsavelProfissaoNome2 ,
                                       string AV40ResponsavelMunicipioNome2 ,
                                       string AV42DynamicFiltersSelector3 ,
                                       short AV43DynamicFiltersOperator3 ,
                                       string AV44ClienteDocumento3 ,
                                       string AV45TipoClienteDescricao3 ,
                                       string AV46ClienteConvenioDescricao3 ,
                                       string AV47ClienteNacionalidadeNome3 ,
                                       string AV48ClienteProfissaoNome3 ,
                                       string AV49MunicipioNome3 ,
                                       int AV50BancoCodigo3 ,
                                       string AV51ResponsavelNacionalidadeNome3 ,
                                       string AV52ResponsavelProfissaoNome3 ,
                                       string AV53ResponsavelMunicipioNome3 ,
                                       short AV61ManageFiltersExecutionStep ,
                                       bool AV28DynamicFiltersEnabled2 ,
                                       bool AV41DynamicFiltersEnabled3 ,
                                       string AV84Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV62TFClienteRazaoSocial ,
                                       string AV63TFClienteRazaoSocial_Sel ,
                                       string AV64TFResponsavelNome ,
                                       string AV65TFResponsavelNome_Sel ,
                                       string AV66TFResponsavelEmail ,
                                       string AV67TFResponsavelEmail_Sel ,
                                       DateTime AV68TFClienteCreatedAt ,
                                       DateTime AV69TFClienteCreatedAt_To ,
                                       GxSimpleCollection<string> AV74TFClienteSituacao_Sels ,
                                       short AV75TFClienteCountNotas_F ,
                                       short AV76TFClienteCountNotas_F_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV55DynamicFiltersIgnoreFirst ,
                                       bool AV54DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9A2( ) ;
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
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV42DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV42DynamicFiltersSelector3);
            AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV43DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV84Pgmname = "Costumer.WpClientes";
      }

      protected void RF9A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 186;
         /* Execute user event: Refresh */
         E259A2 ();
         nGXsfl_186_idx = 1;
         sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
         SubsflControlProps_1862( ) ;
         bGXsfl_186_Refreshing = true;
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
            SubsflControlProps_1862( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A884ClienteSituacao ,
                                                 AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                                 AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                                 AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                                 AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                                 AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                                 AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                                 AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                                 AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                                 AV93Costumer_wpclientesds_9_municipionome1 ,
                                                 AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                                 AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                                 AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                                 AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                                 AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                                 AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                                 AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                                 AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                                 AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                                 AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                                 AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                                 AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                                 AV106Costumer_wpclientesds_22_municipionome2 ,
                                                 AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                                 AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                                 AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                                 AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                                 AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                                 AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                                 AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                                 AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                                 AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                                 AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                                 AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                                 AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                                 AV119Costumer_wpclientesds_35_municipionome3 ,
                                                 AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                                 AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                                 AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                                 AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                                 AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                                 AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                                 AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                                 AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                                 AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                                 AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                                 AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                                 AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                                 AV132Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
                                                 A169ClienteDocumento ,
                                                 A193TipoClienteDescricao ,
                                                 A490ClienteConvenioDescricao ,
                                                 A485ClienteNacionalidadeNome ,
                                                 A488ClienteProfissaoNome ,
                                                 A187MunicipioNome ,
                                                 A404BancoCodigo ,
                                                 A438ResponsavelNacionalidadeNome ,
                                                 A443ResponsavelProfissaoNome ,
                                                 A445ResponsavelMunicipioNome ,
                                                 A170ClienteRazaoSocial ,
                                                 A436ResponsavelNome ,
                                                 A456ResponsavelEmail ,
                                                 A175ClienteCreatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV85Costumer_wpclientesds_1_filterfulltext ,
                                                 A886ClienteCountNotas_F ,
                                                 AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                                 AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                                 A793TipoClientePortalPjPf } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
            lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
            lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
            lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
            lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
            lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
            lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
            lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
            lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
            lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
            lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
            lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
            lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
            lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
            lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
            lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
            lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
            lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
            lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
            lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
            lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
            lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
            lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
            lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
            lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
            lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
            lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
            lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
            lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
            lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
            lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
            lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
            lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
            lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
            lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
            lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
            lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
            lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
            lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
            lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
            lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
            lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
            lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
            lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
            lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
            lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
            lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
            lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
            lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
            lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
            lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
            lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
            lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
            lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
            lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
            lV124Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
            lV126Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
            lV128Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
            /* Using cursor H009A3 */
            pr_default.execute(0, new Object[] {AV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV88Costumer_wpclientesds_4_clientedocumento1, lV88Costumer_wpclientesds_4_clientedocumento1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV93Costumer_wpclientesds_9_municipionome1, lV93Costumer_wpclientesds_9_municipionome1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV101Costumer_wpclientesds_17_clientedocumento2, lV101Costumer_wpclientesds_17_clientedocumento2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV106Costumer_wpclientesds_22_municipionome2, lV106Costumer_wpclientesds_22_municipionome2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV114Costumer_wpclientesds_30_clientedocumento3, lV114Costumer_wpclientesds_30_clientedocumento3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV119Costumer_wpclientesds_35_municipionome3, lV119Costumer_wpclientesds_35_municipionome3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV124Costumer_wpclientesds_40_tfclienterazaosocial, AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV126Costumer_wpclientesds_42_tfresponsavelnome, AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, lV128Costumer_wpclientesds_44_tfresponsavelemail, AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, AV130Costumer_wpclientesds_46_tfclientecreatedat, AV131Costumer_wpclientesds_47_tfclientecreatedat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_186_idx = 1;
            sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
            SubsflControlProps_1862( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A192TipoClienteId = H009A3_A192TipoClienteId[0];
               n192TipoClienteId = H009A3_n192TipoClienteId[0];
               A186MunicipioCodigo = H009A3_A186MunicipioCodigo[0];
               n186MunicipioCodigo = H009A3_n186MunicipioCodigo[0];
               A444ResponsavelMunicipio = H009A3_A444ResponsavelMunicipio[0];
               n444ResponsavelMunicipio = H009A3_n444ResponsavelMunicipio[0];
               A402BancoId = H009A3_A402BancoId[0];
               n402BancoId = H009A3_n402BancoId[0];
               A437ResponsavelNacionalidade = H009A3_A437ResponsavelNacionalidade[0];
               n437ResponsavelNacionalidade = H009A3_n437ResponsavelNacionalidade[0];
               A484ClienteNacionalidade = H009A3_A484ClienteNacionalidade[0];
               n484ClienteNacionalidade = H009A3_n484ClienteNacionalidade[0];
               A442ResponsavelProfissao = H009A3_A442ResponsavelProfissao[0];
               n442ResponsavelProfissao = H009A3_n442ResponsavelProfissao[0];
               A487ClienteProfissao = H009A3_A487ClienteProfissao[0];
               n487ClienteProfissao = H009A3_n487ClienteProfissao[0];
               A489ClienteConvenio = H009A3_A489ClienteConvenio[0];
               n489ClienteConvenio = H009A3_n489ClienteConvenio[0];
               A445ResponsavelMunicipioNome = H009A3_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H009A3_n445ResponsavelMunicipioNome[0];
               A443ResponsavelProfissaoNome = H009A3_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H009A3_n443ResponsavelProfissaoNome[0];
               A438ResponsavelNacionalidadeNome = H009A3_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H009A3_n438ResponsavelNacionalidadeNome[0];
               A404BancoCodigo = H009A3_A404BancoCodigo[0];
               n404BancoCodigo = H009A3_n404BancoCodigo[0];
               A187MunicipioNome = H009A3_A187MunicipioNome[0];
               n187MunicipioNome = H009A3_n187MunicipioNome[0];
               A488ClienteProfissaoNome = H009A3_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H009A3_n488ClienteProfissaoNome[0];
               A485ClienteNacionalidadeNome = H009A3_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H009A3_n485ClienteNacionalidadeNome[0];
               A490ClienteConvenioDescricao = H009A3_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H009A3_n490ClienteConvenioDescricao[0];
               A193TipoClienteDescricao = H009A3_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H009A3_n193TipoClienteDescricao[0];
               A793TipoClientePortalPjPf = H009A3_A793TipoClientePortalPjPf[0];
               n793TipoClientePortalPjPf = H009A3_n793TipoClientePortalPjPf[0];
               A172ClienteTipoPessoa = H009A3_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H009A3_n172ClienteTipoPessoa[0];
               A884ClienteSituacao = H009A3_A884ClienteSituacao[0];
               n884ClienteSituacao = H009A3_n884ClienteSituacao[0];
               A175ClienteCreatedAt = H009A3_A175ClienteCreatedAt[0];
               n175ClienteCreatedAt = H009A3_n175ClienteCreatedAt[0];
               A171ClienteNomeFantasia = H009A3_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H009A3_n171ClienteNomeFantasia[0];
               A456ResponsavelEmail = H009A3_A456ResponsavelEmail[0];
               n456ResponsavelEmail = H009A3_n456ResponsavelEmail[0];
               A436ResponsavelNome = H009A3_A436ResponsavelNome[0];
               n436ResponsavelNome = H009A3_n436ResponsavelNome[0];
               A170ClienteRazaoSocial = H009A3_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H009A3_n170ClienteRazaoSocial[0];
               A169ClienteDocumento = H009A3_A169ClienteDocumento[0];
               n169ClienteDocumento = H009A3_n169ClienteDocumento[0];
               A168ClienteId = H009A3_A168ClienteId[0];
               n168ClienteId = H009A3_n168ClienteId[0];
               A886ClienteCountNotas_F = H009A3_A886ClienteCountNotas_F[0];
               n886ClienteCountNotas_F = H009A3_n886ClienteCountNotas_F[0];
               A193TipoClienteDescricao = H009A3_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H009A3_n193TipoClienteDescricao[0];
               A793TipoClientePortalPjPf = H009A3_A793TipoClientePortalPjPf[0];
               n793TipoClientePortalPjPf = H009A3_n793TipoClientePortalPjPf[0];
               A187MunicipioNome = H009A3_A187MunicipioNome[0];
               n187MunicipioNome = H009A3_n187MunicipioNome[0];
               A445ResponsavelMunicipioNome = H009A3_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H009A3_n445ResponsavelMunicipioNome[0];
               A404BancoCodigo = H009A3_A404BancoCodigo[0];
               n404BancoCodigo = H009A3_n404BancoCodigo[0];
               A438ResponsavelNacionalidadeNome = H009A3_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H009A3_n438ResponsavelNacionalidadeNome[0];
               A485ClienteNacionalidadeNome = H009A3_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H009A3_n485ClienteNacionalidadeNome[0];
               A443ResponsavelProfissaoNome = H009A3_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H009A3_n443ResponsavelProfissaoNome[0];
               A488ClienteProfissaoNome = H009A3_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H009A3_n488ClienteProfissaoNome[0];
               A490ClienteConvenioDescricao = H009A3_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H009A3_n490ClienteConvenioDescricao[0];
               A886ClienteCountNotas_F = H009A3_A886ClienteCountNotas_F[0];
               n886ClienteCountNotas_F = H009A3_n886ClienteCountNotas_F[0];
               /* Execute user event: Grid.Load */
               E269A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 186;
            WB9A0( ) ;
         }
         bGXsfl_186_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_186_idx, GetSecureSignedToken( sGXsfl_186_idx, context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
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
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A884ClienteSituacao ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                              AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                              AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                              AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                              AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                              AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                              AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                              AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                              AV93Costumer_wpclientesds_9_municipionome1 ,
                                              AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                              AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                              AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                              AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                              AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                              AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                              AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                              AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                              AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                              AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                              AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                              AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                              AV106Costumer_wpclientesds_22_municipionome2 ,
                                              AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                              AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                              AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                              AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                              AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                              AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                              AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                              AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                              AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                              AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                              AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                              AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                              AV119Costumer_wpclientesds_35_municipionome3 ,
                                              AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                              AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                              AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                              AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                              AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                              AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                              AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                              AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                              AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                              AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                              AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                              AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A436ResponsavelNome ,
                                              A456ResponsavelEmail ,
                                              A175ClienteCreatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV85Costumer_wpclientesds_1_filterfulltext ,
                                              A886ClienteCountNotas_F ,
                                              AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                              AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                              A793TipoClientePortalPjPf } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
         lV126Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
         lV128Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
         /* Using cursor H009A5 */
         pr_default.execute(1, new Object[] {AV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV88Costumer_wpclientesds_4_clientedocumento1, lV88Costumer_wpclientesds_4_clientedocumento1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV93Costumer_wpclientesds_9_municipionome1, lV93Costumer_wpclientesds_9_municipionome1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV101Costumer_wpclientesds_17_clientedocumento2, lV101Costumer_wpclientesds_17_clientedocumento2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV106Costumer_wpclientesds_22_municipionome2, lV106Costumer_wpclientesds_22_municipionome2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV114Costumer_wpclientesds_30_clientedocumento3, lV114Costumer_wpclientesds_30_clientedocumento3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV119Costumer_wpclientesds_35_municipionome3, lV119Costumer_wpclientesds_35_municipionome3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV124Costumer_wpclientesds_40_tfclienterazaosocial, AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV126Costumer_wpclientesds_42_tfresponsavelnome, AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, lV128Costumer_wpclientesds_44_tfresponsavelemail, AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, AV130Costumer_wpclientesds_46_tfclientecreatedat, AV131Costumer_wpclientesds_47_tfclientecreatedat_to});
         GRID_nRecordCount = H009A5_AGRID_nRecordCount[0];
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
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV84Pgmname = "Costumer.WpClientes";
         edtClienteId_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtResponsavelNome_Enabled = 0;
         edtResponsavelEmail_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         cmbClienteSituacao.Enabled = 0;
         edtClienteCountNotas_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E249A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV59ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV77DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_186 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_186"), ",", "."), 18, MidpointRounding.ToEven));
            AV79GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV80GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV81GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV70DDO_ClienteCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CLIENTECREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV70DDO_ClienteCreatedAtAuxDate", context.localUtil.Format(AV70DDO_ClienteCreatedAtAuxDate, "99/99/99"));
            AV71DDO_ClienteCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CLIENTECREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV71DDO_ClienteCreatedAtAuxDateTo", context.localUtil.Format(AV71DDO_ClienteCreatedAtAuxDateTo, "99/99/99"));
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
            AV18ClienteDocumento1 = cgiGet( edtavClientedocumento1_Internalname);
            AssignAttri("", false, "AV18ClienteDocumento1", AV18ClienteDocumento1);
            AV19TipoClienteDescricao1 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao1_Internalname));
            AssignAttri("", false, "AV19TipoClienteDescricao1", AV19TipoClienteDescricao1);
            AV20ClienteConvenioDescricao1 = cgiGet( edtavClienteconveniodescricao1_Internalname);
            AssignAttri("", false, "AV20ClienteConvenioDescricao1", AV20ClienteConvenioDescricao1);
            AV21ClienteNacionalidadeNome1 = cgiGet( edtavClientenacionalidadenome1_Internalname);
            AssignAttri("", false, "AV21ClienteNacionalidadeNome1", AV21ClienteNacionalidadeNome1);
            AV22ClienteProfissaoNome1 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome1_Internalname));
            AssignAttri("", false, "AV22ClienteProfissaoNome1", AV22ClienteProfissaoNome1);
            AV23MunicipioNome1 = StringUtil.Upper( cgiGet( edtavMunicipionome1_Internalname));
            AssignAttri("", false, "AV23MunicipioNome1", AV23MunicipioNome1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO1");
               GX_FocusControl = edtavBancocodigo1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24BancoCodigo1 = 0;
               AssignAttri("", false, "AV24BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV24BancoCodigo1), 9, 0));
            }
            else
            {
               AV24BancoCodigo1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV24BancoCodigo1), 9, 0));
            }
            AV25ResponsavelNacionalidadeNome1 = cgiGet( edtavResponsavelnacionalidadenome1_Internalname);
            AssignAttri("", false, "AV25ResponsavelNacionalidadeNome1", AV25ResponsavelNacionalidadeNome1);
            AV26ResponsavelProfissaoNome1 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome1_Internalname));
            AssignAttri("", false, "AV26ResponsavelProfissaoNome1", AV26ResponsavelProfissaoNome1);
            AV27ResponsavelMunicipioNome1 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome1_Internalname));
            AssignAttri("", false, "AV27ResponsavelMunicipioNome1", AV27ResponsavelMunicipioNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV29DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AV31ClienteDocumento2 = cgiGet( edtavClientedocumento2_Internalname);
            AssignAttri("", false, "AV31ClienteDocumento2", AV31ClienteDocumento2);
            AV32TipoClienteDescricao2 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao2_Internalname));
            AssignAttri("", false, "AV32TipoClienteDescricao2", AV32TipoClienteDescricao2);
            AV33ClienteConvenioDescricao2 = cgiGet( edtavClienteconveniodescricao2_Internalname);
            AssignAttri("", false, "AV33ClienteConvenioDescricao2", AV33ClienteConvenioDescricao2);
            AV34ClienteNacionalidadeNome2 = cgiGet( edtavClientenacionalidadenome2_Internalname);
            AssignAttri("", false, "AV34ClienteNacionalidadeNome2", AV34ClienteNacionalidadeNome2);
            AV35ClienteProfissaoNome2 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome2_Internalname));
            AssignAttri("", false, "AV35ClienteProfissaoNome2", AV35ClienteProfissaoNome2);
            AV36MunicipioNome2 = StringUtil.Upper( cgiGet( edtavMunicipionome2_Internalname));
            AssignAttri("", false, "AV36MunicipioNome2", AV36MunicipioNome2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO2");
               GX_FocusControl = edtavBancocodigo2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37BancoCodigo2 = 0;
               AssignAttri("", false, "AV37BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV37BancoCodigo2), 9, 0));
            }
            else
            {
               AV37BancoCodigo2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV37BancoCodigo2), 9, 0));
            }
            AV38ResponsavelNacionalidadeNome2 = cgiGet( edtavResponsavelnacionalidadenome2_Internalname);
            AssignAttri("", false, "AV38ResponsavelNacionalidadeNome2", AV38ResponsavelNacionalidadeNome2);
            AV39ResponsavelProfissaoNome2 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome2_Internalname));
            AssignAttri("", false, "AV39ResponsavelProfissaoNome2", AV39ResponsavelProfissaoNome2);
            AV40ResponsavelMunicipioNome2 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome2_Internalname));
            AssignAttri("", false, "AV40ResponsavelMunicipioNome2", AV40ResponsavelMunicipioNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV42DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV43DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
            AV44ClienteDocumento3 = cgiGet( edtavClientedocumento3_Internalname);
            AssignAttri("", false, "AV44ClienteDocumento3", AV44ClienteDocumento3);
            AV45TipoClienteDescricao3 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao3_Internalname));
            AssignAttri("", false, "AV45TipoClienteDescricao3", AV45TipoClienteDescricao3);
            AV46ClienteConvenioDescricao3 = cgiGet( edtavClienteconveniodescricao3_Internalname);
            AssignAttri("", false, "AV46ClienteConvenioDescricao3", AV46ClienteConvenioDescricao3);
            AV47ClienteNacionalidadeNome3 = cgiGet( edtavClientenacionalidadenome3_Internalname);
            AssignAttri("", false, "AV47ClienteNacionalidadeNome3", AV47ClienteNacionalidadeNome3);
            AV48ClienteProfissaoNome3 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome3_Internalname));
            AssignAttri("", false, "AV48ClienteProfissaoNome3", AV48ClienteProfissaoNome3);
            AV49MunicipioNome3 = StringUtil.Upper( cgiGet( edtavMunicipionome3_Internalname));
            AssignAttri("", false, "AV49MunicipioNome3", AV49MunicipioNome3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO3");
               GX_FocusControl = edtavBancocodigo3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50BancoCodigo3 = 0;
               AssignAttri("", false, "AV50BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV50BancoCodigo3), 9, 0));
            }
            else
            {
               AV50BancoCodigo3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV50BancoCodigo3), 9, 0));
            }
            AV51ResponsavelNacionalidadeNome3 = cgiGet( edtavResponsavelnacionalidadenome3_Internalname);
            AssignAttri("", false, "AV51ResponsavelNacionalidadeNome3", AV51ResponsavelNacionalidadeNome3);
            AV52ResponsavelProfissaoNome3 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome3_Internalname));
            AssignAttri("", false, "AV52ResponsavelProfissaoNome3", AV52ResponsavelProfissaoNome3);
            AV53ResponsavelMunicipioNome3 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome3_Internalname));
            AssignAttri("", false, "AV53ResponsavelMunicipioNome3", AV53ResponsavelMunicipioNome3);
            AV72DDO_ClienteCreatedAtAuxDateText = cgiGet( edtavDdo_clientecreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV72DDO_ClienteCreatedAtAuxDateText", AV72DDO_ClienteCreatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV18ClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV19TipoClienteDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV20ClienteConvenioDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV21ClienteNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV22ClienteProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV23MunicipioNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV24BancoCodigo1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV25ResponsavelNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV26ResponsavelProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV27ResponsavelMunicipioNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV31ClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV32TipoClienteDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV33ClienteConvenioDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV34ClienteNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV35ClienteProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV36MunicipioNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV37BancoCodigo2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV38ResponsavelNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV39ResponsavelProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV40ResponsavelMunicipioNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV42DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV43DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV44ClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV45TipoClienteDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV46ClienteConvenioDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV47ClienteNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV48ClienteProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV49MunicipioNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV50BancoCodigo3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV51ResponsavelNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV52ResponsavelProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV53ResponsavelMunicipioNome3) != 0 )
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
         E249A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E249A2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCLIENTECREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_clientecreatedatauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV42DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
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
         Form.Caption = " Cliente";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV77DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV77DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E259A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV61ManageFiltersExecutionStep == 1 )
         {
            AV61ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV61ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV61ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV61ManageFiltersExecutionStep == 2 )
         {
            AV61ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV61ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV61ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV41DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         AV79GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV79GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV79GridCurrentPage), 10, 0));
         AV80GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV80GridPageCount", StringUtil.LTrimStr( (decimal)(AV80GridPageCount), 10, 0));
         GXt_char2 = AV81GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV84Pgmname, out  GXt_char2) ;
         AV81GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV81GridAppliedFilters", AV81GridAppliedFilters);
         AV85Costumer_wpclientesds_1_filterfulltext = AV15FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV20ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV21ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV22ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV23MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV24BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV25ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV26ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV27ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV31ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV32TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV33ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV34ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV35ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV36MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV37BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV38ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV39ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV40ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV44ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV45TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV46ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV47ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV48ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV49MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV50BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV51ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV52ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV53ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV74TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV75TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV76TFClienteCountNotas_F_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129A2( )
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
            AV78PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV78PageToGo) ;
         }
      }

      protected void E139A2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149A2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV62TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFClienteRazaoSocial", AV62TFClienteRazaoSocial);
               AV63TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFClienteRazaoSocial_Sel", AV63TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelNome") == 0 )
            {
               AV64TFResponsavelNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFResponsavelNome", AV64TFResponsavelNome);
               AV65TFResponsavelNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFResponsavelNome_Sel", AV65TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelEmail") == 0 )
            {
               AV66TFResponsavelEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFResponsavelEmail", AV66TFResponsavelEmail);
               AV67TFResponsavelEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFResponsavelEmail_Sel", AV67TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteCreatedAt") == 0 )
            {
               AV68TFClienteCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV68TFClienteCreatedAt", context.localUtil.TToC( AV68TFClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV69TFClienteCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV69TFClienteCreatedAt_To", context.localUtil.TToC( AV69TFClienteCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV69TFClienteCreatedAt_To) )
               {
                  AV69TFClienteCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV69TFClienteCreatedAt_To)), (short)(DateTimeUtil.Month( AV69TFClienteCreatedAt_To)), (short)(DateTimeUtil.Day( AV69TFClienteCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV69TFClienteCreatedAt_To", context.localUtil.TToC( AV69TFClienteCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteSituacao") == 0 )
            {
               AV73TFClienteSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFClienteSituacao_SelsJson", AV73TFClienteSituacao_SelsJson);
               AV74TFClienteSituacao_Sels.FromJSonString(AV73TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteCountNotas_F") == 0 )
            {
               AV75TFClienteCountNotas_F = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV75TFClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(AV75TFClienteCountNotas_F), 4, 0));
               AV76TFClienteCountNotas_F_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV76TFClienteCountNotas_F_To", StringUtil.LTrimStr( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFClienteSituacao_Sels", AV74TFClienteSituacao_Sels);
      }

      private void E269A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         if ( ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 ) && A793TipoClientePortalPjPf )
         {
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Representantes", "fas fa-user-large", "", "", "", "", "", "", ""), 0);
         }
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Contratos", "fas fa-file-contract", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", "Documentos", "fas fa-folder", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", "Operações", "fas fa-right-left", "", "", "", "", "", "", ""), 0);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 186;
         }
         sendrow_1862( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_186_Refreshing )
         {
            DoAjaxLoad(186, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0));
      }

      protected void E199A2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E159A2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV54DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         AV55DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV55DynamicFiltersIgnoreFirst", AV55DynamicFiltersIgnoreFirst);
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
         AV54DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         AV55DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV55DynamicFiltersIgnoreFirst", AV55DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
      }

      protected void E209A2( )
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

      protected void E219A2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV41DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV41DynamicFiltersEnabled3", AV41DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E169A2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV54DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
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
         AV54DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
      }

      protected void E229A2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179A2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV54DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         AV41DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV41DynamicFiltersEnabled3", AV41DynamicFiltersEnabled3);
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
         AV54DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV54DynamicFiltersRemoving", AV54DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV84Pgmname, AV15FilterFullText, AV62TFClienteRazaoSocial, AV63TFClienteRazaoSocial_Sel, AV64TFResponsavelNome, AV65TFResponsavelNome_Sel, AV66TFResponsavelEmail, AV67TFResponsavelEmail_Sel, AV68TFClienteCreatedAt, AV69TFClienteCreatedAt_To, AV74TFClienteSituacao_Sels, AV75TFClienteCountNotas_F, AV76TFClienteCountNotas_F_To, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
      }

      protected void E239A2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV43DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119A2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("Costumer.WpClientesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV84Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV61ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV61ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV61ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("Costumer.WpClientesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV61ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV61ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV61ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV60ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Costumer.WpClientesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV60ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV60ManageFiltersXml) ;
               AV10GridState.FromXml(AV60ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFClienteSituacao_Sels", AV74TFClienteSituacao_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ManageFiltersData", AV59ManageFiltersData);
      }

      protected void E279A2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV83GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO REPRESENTANTES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV83GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO CONTRATOS' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV83GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO DOCUMENTOS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV83GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO OPERACOES' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV83GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV83GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E189A2( )
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
         new GeneXus.Programs.costumer.wpclientesexport(context ).execute( out  AV56ExcelFilename, out  AV57ErrorMessage) ;
         if ( StringUtil.StrCmp(AV56ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV56ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV57ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFClienteSituacao_Sels", AV74TFClienteSituacao_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
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
         edtavClientedocumento1_Visible = 0;
         AssignProp("", false, edtavClientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento1_Visible), 5, 0), true);
         edtavTipoclientedescricao1_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao1_Visible), 5, 0), true);
         edtavClienteconveniodescricao1_Visible = 0;
         AssignProp("", false, edtavClienteconveniodescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao1_Visible), 5, 0), true);
         edtavClientenacionalidadenome1_Visible = 0;
         AssignProp("", false, edtavClientenacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome1_Visible), 5, 0), true);
         edtavClienteprofissaonome1_Visible = 0;
         AssignProp("", false, edtavClienteprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome1_Visible), 5, 0), true);
         edtavMunicipionome1_Visible = 0;
         AssignProp("", false, edtavMunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome1_Visible), 5, 0), true);
         edtavBancocodigo1_Visible = 0;
         AssignProp("", false, edtavBancocodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo1_Visible), 5, 0), true);
         edtavResponsavelnacionalidadenome1_Visible = 0;
         AssignProp("", false, edtavResponsavelnacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome1_Visible), 5, 0), true);
         edtavResponsavelprofissaonome1_Visible = 0;
         AssignProp("", false, edtavResponsavelprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome1_Visible), 5, 0), true);
         edtavResponsavelmunicipionome1_Visible = 0;
         AssignProp("", false, edtavResponsavelmunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento1_Visible = 1;
            AssignProp("", false, edtavClientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao1_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao1_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome1_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome1_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome1_Visible = 1;
            AssignProp("", false, edtavMunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo1_Visible = 1;
            AssignProp("", false, edtavBancocodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome1_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome1_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
         {
            edtavResponsavelmunicipionome1_Visible = 1;
            AssignProp("", false, edtavResponsavelmunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavClientedocumento2_Visible = 0;
         AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
         edtavTipoclientedescricao2_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
         edtavClienteconveniodescricao2_Visible = 0;
         AssignProp("", false, edtavClienteconveniodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao2_Visible), 5, 0), true);
         edtavClientenacionalidadenome2_Visible = 0;
         AssignProp("", false, edtavClientenacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome2_Visible), 5, 0), true);
         edtavClienteprofissaonome2_Visible = 0;
         AssignProp("", false, edtavClienteprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome2_Visible), 5, 0), true);
         edtavMunicipionome2_Visible = 0;
         AssignProp("", false, edtavMunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome2_Visible), 5, 0), true);
         edtavBancocodigo2_Visible = 0;
         AssignProp("", false, edtavBancocodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo2_Visible), 5, 0), true);
         edtavResponsavelnacionalidadenome2_Visible = 0;
         AssignProp("", false, edtavResponsavelnacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome2_Visible), 5, 0), true);
         edtavResponsavelprofissaonome2_Visible = 0;
         AssignProp("", false, edtavResponsavelprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome2_Visible), 5, 0), true);
         edtavResponsavelmunicipionome2_Visible = 0;
         AssignProp("", false, edtavResponsavelmunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento2_Visible = 1;
            AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao2_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao2_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome2_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome2_Visible = 1;
            AssignProp("", false, edtavMunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo2_Visible = 1;
            AssignProp("", false, edtavBancocodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome2_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
         {
            edtavResponsavelmunicipionome2_Visible = 1;
            AssignProp("", false, edtavResponsavelmunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavClientedocumento3_Visible = 0;
         AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
         edtavTipoclientedescricao3_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
         edtavClienteconveniodescricao3_Visible = 0;
         AssignProp("", false, edtavClienteconveniodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao3_Visible), 5, 0), true);
         edtavClientenacionalidadenome3_Visible = 0;
         AssignProp("", false, edtavClientenacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome3_Visible), 5, 0), true);
         edtavClienteprofissaonome3_Visible = 0;
         AssignProp("", false, edtavClienteprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome3_Visible), 5, 0), true);
         edtavMunicipionome3_Visible = 0;
         AssignProp("", false, edtavMunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome3_Visible), 5, 0), true);
         edtavBancocodigo3_Visible = 0;
         AssignProp("", false, edtavBancocodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo3_Visible), 5, 0), true);
         edtavResponsavelnacionalidadenome3_Visible = 0;
         AssignProp("", false, edtavResponsavelnacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome3_Visible), 5, 0), true);
         edtavResponsavelprofissaonome3_Visible = 0;
         AssignProp("", false, edtavResponsavelprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome3_Visible), 5, 0), true);
         edtavResponsavelmunicipionome3_Visible = 0;
         AssignProp("", false, edtavResponsavelmunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento3_Visible = 1;
            AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao3_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao3_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome3_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome3_Visible = 1;
            AssignProp("", false, edtavMunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo3_Visible = 1;
            AssignProp("", false, edtavBancocodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome3_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
         {
            edtavResponsavelmunicipionome3_Visible = 1;
            AssignProp("", false, edtavResponsavelmunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         AV29DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AV31ClienteDocumento2 = "";
         AssignAttri("", false, "AV31ClienteDocumento2", AV31ClienteDocumento2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV41DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV41DynamicFiltersEnabled3", AV41DynamicFiltersEnabled3);
         AV42DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
         AV43DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         AV44ClienteDocumento3 = "";
         AssignAttri("", false, "AV44ClienteDocumento3", AV44ClienteDocumento3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV59ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Costumer.WpClientesFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV59ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV62TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV62TFClienteRazaoSocial", AV62TFClienteRazaoSocial);
         AV63TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV63TFClienteRazaoSocial_Sel", AV63TFClienteRazaoSocial_Sel);
         AV64TFResponsavelNome = "";
         AssignAttri("", false, "AV64TFResponsavelNome", AV64TFResponsavelNome);
         AV65TFResponsavelNome_Sel = "";
         AssignAttri("", false, "AV65TFResponsavelNome_Sel", AV65TFResponsavelNome_Sel);
         AV66TFResponsavelEmail = "";
         AssignAttri("", false, "AV66TFResponsavelEmail", AV66TFResponsavelEmail);
         AV67TFResponsavelEmail_Sel = "";
         AssignAttri("", false, "AV67TFResponsavelEmail_Sel", AV67TFResponsavelEmail_Sel);
         AV68TFClienteCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV68TFClienteCreatedAt", context.localUtil.TToC( AV68TFClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV69TFClienteCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV69TFClienteCreatedAt_To", context.localUtil.TToC( AV69TFClienteCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV74TFClienteSituacao_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV75TFClienteCountNotas_F = 0;
         AssignAttri("", false, "AV75TFClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(AV75TFClienteCountNotas_F), 4, 0));
         AV76TFClienteCountNotas_F_To = 0;
         AssignAttri("", false, "AV76TFClienteCountNotas_F_To", StringUtil.LTrimStr( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18ClienteDocumento1 = "";
         AssignAttri("", false, "AV18ClienteDocumento1", AV18ClienteDocumento1);
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

      protected void S242( )
      {
         /* 'DO REPRESENTANTES' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "representanteww"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("representanteww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO CONTRATOS' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpcontratost"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wpcontratost") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO DOCUMENTOS' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "clientedocumentoww"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("clientedocumentoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO OPERACOES' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacoeslista"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("operacoeslista") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV58Session.Get(AV84Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV84Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV58Session.Get(AV84Pgmname+"GridState"), null, "", "");
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
         AV135GXV1 = 1;
         while ( AV135GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV135GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV62TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFClienteRazaoSocial", AV62TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV63TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFClienteRazaoSocial_Sel", AV63TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV64TFResponsavelNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFResponsavelNome", AV64TFResponsavelNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV65TFResponsavelNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFResponsavelNome_Sel", AV65TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV66TFResponsavelEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFResponsavelEmail", AV66TFResponsavelEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV67TFResponsavelEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFResponsavelEmail_Sel", AV67TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTECREATEDAT") == 0 )
            {
               AV68TFClienteCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV68TFClienteCreatedAt", context.localUtil.TToC( AV68TFClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV69TFClienteCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV69TFClienteCreatedAt_To", context.localUtil.TToC( AV69TFClienteCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV70DDO_ClienteCreatedAtAuxDate = DateTimeUtil.ResetTime(AV68TFClienteCreatedAt);
               AssignAttri("", false, "AV70DDO_ClienteCreatedAtAuxDate", context.localUtil.Format(AV70DDO_ClienteCreatedAtAuxDate, "99/99/99"));
               AV71DDO_ClienteCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV69TFClienteCreatedAt_To);
               AssignAttri("", false, "AV71DDO_ClienteCreatedAtAuxDateTo", context.localUtil.Format(AV71DDO_ClienteCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV73TFClienteSituacao_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFClienteSituacao_SelsJson", AV73TFClienteSituacao_SelsJson);
               AV74TFClienteSituacao_Sels.FromJSonString(AV73TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTECOUNTNOTAS_F") == 0 )
            {
               AV75TFClienteCountNotas_F = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV75TFClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(AV75TFClienteCountNotas_F), 4, 0));
               AV76TFClienteCountNotas_F_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV76TFClienteCountNotas_F_To", StringUtil.LTrimStr( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0));
            }
            AV135GXV1 = (int)(AV135GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFClienteRazaoSocial_Sel)),  AV63TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelNome_Sel)),  AV65TFResponsavelNome_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelEmail_Sel)),  AV67TFResponsavelEmail_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV74TFClienteSituacao_Sels.Count==0),  AV73TFClienteSituacao_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"||"+GXt_char6+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFClienteRazaoSocial)),  AV62TFClienteRazaoSocial, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelNome)),  AV64TFResponsavelNome, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelEmail)),  AV66TFResponsavelEmail, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV68TFClienteCreatedAt) ? "" : context.localUtil.DToC( AV70DDO_ClienteCreatedAtAuxDate, 4, "/"))+"||"+((0==AV75TFClienteCountNotas_F) ? "" : StringUtil.Str( (decimal)(AV75TFClienteCountNotas_F), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((DateTime.MinValue==AV69TFClienteCreatedAt_To) ? "" : context.localUtil.DToC( AV71DDO_ClienteCreatedAtAuxDateTo, 4, "/"))+"||"+((0==AV76TFClienteCountNotas_F_To) ? "" : StringUtil.Str( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0));
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18ClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18ClienteDocumento1", AV18ClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19TipoClienteDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19TipoClienteDescricao1", AV19TipoClienteDescricao1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20ClienteConvenioDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ClienteConvenioDescricao1", AV20ClienteConvenioDescricao1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV21ClienteNacionalidadeNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ClienteNacionalidadeNome1", AV21ClienteNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV22ClienteProfissaoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV22ClienteProfissaoNome1", AV22ClienteProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV23MunicipioNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV23MunicipioNome1", AV23MunicipioNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV24BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV24BancoCodigo1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV25ResponsavelNacionalidadeNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV25ResponsavelNacionalidadeNome1", AV25ResponsavelNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV26ResponsavelProfissaoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV26ResponsavelProfissaoNome1", AV26ResponsavelProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV27ResponsavelMunicipioNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV27ResponsavelMunicipioNome1", AV27ResponsavelMunicipioNome1);
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
               AV28DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV29DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV31ClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV31ClienteDocumento2", AV31ClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV32TipoClienteDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV32TipoClienteDescricao2", AV32TipoClienteDescricao2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV33ClienteConvenioDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV33ClienteConvenioDescricao2", AV33ClienteConvenioDescricao2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV34ClienteNacionalidadeNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV34ClienteNacionalidadeNome2", AV34ClienteNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV35ClienteProfissaoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV35ClienteProfissaoNome2", AV35ClienteProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV36MunicipioNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV36MunicipioNome2", AV36MunicipioNome2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV37BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV37BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV37BancoCodigo2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV38ResponsavelNacionalidadeNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV38ResponsavelNacionalidadeNome2", AV38ResponsavelNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV39ResponsavelProfissaoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV39ResponsavelProfissaoNome2", AV39ResponsavelProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV40ResponsavelMunicipioNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV40ResponsavelMunicipioNome2", AV40ResponsavelMunicipioNome2);
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
                  AV41DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV41DynamicFiltersEnabled3", AV41DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV44ClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV44ClienteDocumento3", AV44ClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV45TipoClienteDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV45TipoClienteDescricao3", AV45TipoClienteDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV46ClienteConvenioDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV46ClienteConvenioDescricao3", AV46ClienteConvenioDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV47ClienteNacionalidadeNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV47ClienteNacionalidadeNome3", AV47ClienteNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV48ClienteProfissaoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV48ClienteProfissaoNome3", AV48ClienteProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV49MunicipioNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV49MunicipioNome3", AV49MunicipioNome3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV50BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV50BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV50BancoCodigo3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV51ResponsavelNacionalidadeNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV51ResponsavelNacionalidadeNome3", AV51ResponsavelNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV52ResponsavelProfissaoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV52ResponsavelProfissaoNome3", AV52ResponsavelProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
                     AV53ResponsavelMunicipioNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV53ResponsavelMunicipioNome3", AV53ResponsavelMunicipioNome3);
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
         if ( AV54DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV58Session.Get(AV84Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFClienteRazaoSocial)),  0,  AV62TFClienteRazaoSocial,  AV62TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFClienteRazaoSocial_Sel)),  AV63TFClienteRazaoSocial_Sel,  AV63TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELNOME",  "Representante",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelNome)),  0,  AV64TFResponsavelNome,  AV64TFResponsavelNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelNome_Sel)),  AV65TFResponsavelNome_Sel,  AV65TFResponsavelNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelEmail)),  0,  AV66TFResponsavelEmail,  AV66TFResponsavelEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelEmail_Sel)),  AV67TFResponsavelEmail_Sel,  AV67TFResponsavelEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTECREATEDAT",  "Data de registro",  !((DateTime.MinValue==AV68TFClienteCreatedAt)&&(DateTime.MinValue==AV69TFClienteCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV68TFClienteCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV68TFClienteCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV68TFClienteCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV69TFClienteCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV69TFClienteCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV69TFClienteCreatedAt_To, "99/99/99 99:99")))) ;
         AV82AuxText = ((AV74TFClienteSituacao_Sels.Count==1) ? "["+AV74TFClienteSituacao_Sels.GetString(1)+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESITUACAO_SEL",  "Status",  !(AV74TFClienteSituacao_Sels.Count==0),  0,  AV74TFClienteSituacao_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV82AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV82AuxText, "[P]", "Aguardando Análise"), "[A]", "Aprovado"), "[R]", "Rejeitado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTECOUNTNOTAS_F",  "Notas",  !((0==AV75TFClienteCountNotas_F)&&(0==AV76TFClienteCountNotas_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV75TFClienteCountNotas_F), 4, 0)),  ((0==AV75TFClienteCountNotas_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV75TFClienteCountNotas_F), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV76TFClienteCountNotas_F_To), 4, 0)),  ((0==AV76TFClienteCountNotas_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV76TFClienteCountNotas_F_To), "ZZZ9")))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV55DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV17DynamicFiltersOperator1,  AV18ClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18ClienteDocumento1, "Contém"+" "+AV18ClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV17DynamicFiltersOperator1,  AV19TipoClienteDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19TipoClienteDescricao1, "Contém"+" "+AV19TipoClienteDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteConvenioDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV17DynamicFiltersOperator1,  AV20ClienteConvenioDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20ClienteConvenioDescricao1, "Contém"+" "+AV20ClienteConvenioDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV17DynamicFiltersOperator1,  AV21ClienteNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21ClienteNacionalidadeNome1, "Contém"+" "+AV21ClienteNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV17DynamicFiltersOperator1,  AV22ClienteProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV22ClienteProfissaoNome1, "Contém"+" "+AV22ClienteProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV17DynamicFiltersOperator1,  AV23MunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV23MunicipioNome1, "Contém"+" "+AV23MunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ! (0==AV24BancoCodigo1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24BancoCodigo1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV17DynamicFiltersOperator1,  AV25ResponsavelNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV25ResponsavelNacionalidadeNome1, "Contém"+" "+AV25ResponsavelNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ResponsavelProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV17DynamicFiltersOperator1,  AV26ResponsavelProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV26ResponsavelProfissaoNome1, "Contém"+" "+AV26ResponsavelProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ResponsavelMunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV17DynamicFiltersOperator1,  AV27ResponsavelMunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV27ResponsavelMunicipioNome1, "Contém"+" "+AV27ResponsavelMunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV54DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV30DynamicFiltersOperator2,  AV31ClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV31ClienteDocumento2, "Contém"+" "+AV31ClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TipoClienteDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV30DynamicFiltersOperator2,  AV32TipoClienteDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV32TipoClienteDescricao2, "Contém"+" "+AV32TipoClienteDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ClienteConvenioDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV30DynamicFiltersOperator2,  AV33ClienteConvenioDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV33ClienteConvenioDescricao2, "Contém"+" "+AV33ClienteConvenioDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV30DynamicFiltersOperator2,  AV34ClienteNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV34ClienteNacionalidadeNome2, "Contém"+" "+AV34ClienteNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ClienteProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV30DynamicFiltersOperator2,  AV35ClienteProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV35ClienteProfissaoNome2, "Contém"+" "+AV35ClienteProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36MunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV30DynamicFiltersOperator2,  AV36MunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV36MunicipioNome2, "Contém"+" "+AV36MunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ! (0==AV37BancoCodigo2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV30DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37BancoCodigo2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV30DynamicFiltersOperator2,  AV38ResponsavelNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV38ResponsavelNacionalidadeNome2, "Contém"+" "+AV38ResponsavelNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV30DynamicFiltersOperator2,  AV39ResponsavelProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV39ResponsavelProfissaoNome2, "Contém"+" "+AV39ResponsavelProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResponsavelMunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV30DynamicFiltersOperator2,  AV40ResponsavelMunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV40ResponsavelMunicipioNome2, "Contém"+" "+AV40ResponsavelMunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV54DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV41DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV42DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV43DynamicFiltersOperator3,  AV44ClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV44ClienteDocumento3, "Contém"+" "+AV44ClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipoClienteDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV43DynamicFiltersOperator3,  AV45TipoClienteDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV45TipoClienteDescricao3, "Contém"+" "+AV45TipoClienteDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ClienteConvenioDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV43DynamicFiltersOperator3,  AV46ClienteConvenioDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV46ClienteConvenioDescricao3, "Contém"+" "+AV46ClienteConvenioDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV43DynamicFiltersOperator3,  AV47ClienteNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV47ClienteNacionalidadeNome3, "Contém"+" "+AV47ClienteNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV43DynamicFiltersOperator3,  AV48ClienteProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV48ClienteProfissaoNome3, "Contém"+" "+AV48ClienteProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV43DynamicFiltersOperator3,  AV49MunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV49MunicipioNome3, "Contém"+" "+AV49MunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ! (0==AV50BancoCodigo3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV43DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50BancoCodigo3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV43DynamicFiltersOperator3,  AV51ResponsavelNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV51ResponsavelNacionalidadeNome3, "Contém"+" "+AV51ResponsavelNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ResponsavelProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV43DynamicFiltersOperator3,  AV52ResponsavelProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV52ResponsavelProfissaoNome3, "Contém"+" "+AV52ResponsavelProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ResponsavelMunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV43DynamicFiltersOperator3,  AV53ResponsavelMunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV53ResponsavelMunicipioNome3, "Contém"+" "+AV53ResponsavelMunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV54DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV84Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Cliente";
         AV58Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_141_9A2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento3_Internalname, "Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento3_Internalname, AV44ClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV44ClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento3_Visible, edtavClientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao3_Internalname, "Tipo Cliente Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao3_Internalname, AV45TipoClienteDescricao3, StringUtil.RTrim( context.localUtil.Format( AV45TipoClienteDescricao3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao3_Visible, edtavTipoclientedescricao3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao3_Internalname, "Cliente Convenio Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao3_Internalname, AV46ClienteConvenioDescricao3, StringUtil.RTrim( context.localUtil.Format( AV46ClienteConvenioDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao3_Visible, edtavClienteconveniodescricao3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome3_Internalname, "Cliente Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome3_Internalname, AV47ClienteNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV47ClienteNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome3_Visible, edtavClientenacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome3_Internalname, "Cliente Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome3_Internalname, AV48ClienteProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV48ClienteProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,160);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome3_Visible, edtavClienteprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome3_Internalname, "Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome3_Internalname, AV49MunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV49MunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome3_Visible, edtavMunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo3_Internalname, "Banco Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50BancoCodigo3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo3_Visible, edtavBancocodigo3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome3_Internalname, "Responsavel Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome3_Internalname, AV51ResponsavelNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV51ResponsavelNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome3_Visible, edtavResponsavelnacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome3_Internalname, "Responsavel Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome3_Internalname, AV52ResponsavelProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV52ResponsavelProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome3_Visible, edtavResponsavelprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome3_Internalname, "Responsavel Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome3_Internalname, AV53ResponsavelMunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV53ResponsavelMunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,175);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome3_Visible, edtavResponsavelmunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/WpClientes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_141_9A2e( true) ;
         }
         else
         {
            wb_table3_141_9A2e( false) ;
         }
      }

      protected void wb_table2_92_9A2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento2_Internalname, "Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento2_Internalname, AV31ClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV31ClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento2_Visible, edtavClientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao2_Internalname, "Tipo Cliente Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao2_Internalname, AV32TipoClienteDescricao2, StringUtil.RTrim( context.localUtil.Format( AV32TipoClienteDescricao2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao2_Visible, edtavTipoclientedescricao2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao2_Internalname, "Cliente Convenio Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao2_Internalname, AV33ClienteConvenioDescricao2, StringUtil.RTrim( context.localUtil.Format( AV33ClienteConvenioDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao2_Visible, edtavClienteconveniodescricao2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome2_Internalname, "Cliente Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome2_Internalname, AV34ClienteNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV34ClienteNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome2_Visible, edtavClientenacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome2_Internalname, "Cliente Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome2_Internalname, AV35ClienteProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV35ClienteProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome2_Visible, edtavClienteprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome2_Internalname, "Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome2_Internalname, AV36MunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV36MunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome2_Visible, edtavMunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo2_Internalname, "Banco Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37BancoCodigo2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo2_Visible, edtavBancocodigo2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome2_Internalname, "Responsavel Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome2_Internalname, AV38ResponsavelNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV38ResponsavelNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome2_Visible, edtavResponsavelnacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome2_Internalname, "Responsavel Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome2_Internalname, AV39ResponsavelProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV39ResponsavelProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome2_Visible, edtavResponsavelprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome2_Internalname, "Responsavel Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome2_Internalname, AV40ResponsavelMunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV40ResponsavelMunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome2_Visible, edtavResponsavelmunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/WpClientes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/WpClientes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_92_9A2e( true) ;
         }
         else
         {
            wb_table2_92_9A2e( false) ;
         }
      }

      protected void wb_table1_43_9A2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_186_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_Costumer/WpClientes.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento1_Internalname, "Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento1_Internalname, AV18ClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV18ClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento1_Visible, edtavClientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao1_Internalname, "Tipo Cliente Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao1_Internalname, AV19TipoClienteDescricao1, StringUtil.RTrim( context.localUtil.Format( AV19TipoClienteDescricao1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao1_Visible, edtavTipoclientedescricao1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao1_Internalname, "Cliente Convenio Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao1_Internalname, AV20ClienteConvenioDescricao1, StringUtil.RTrim( context.localUtil.Format( AV20ClienteConvenioDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao1_Visible, edtavClienteconveniodescricao1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome1_Internalname, "Cliente Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome1_Internalname, AV21ClienteNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV21ClienteNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome1_Visible, edtavClientenacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome1_Internalname, "Cliente Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome1_Internalname, AV22ClienteProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV22ClienteProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome1_Visible, edtavClienteprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome1_Internalname, "Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome1_Internalname, AV23MunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV23MunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome1_Visible, edtavMunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo1_Internalname, "Banco Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24BancoCodigo1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo1_Visible, edtavBancocodigo1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome1_Internalname, "Responsavel Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome1_Internalname, AV25ResponsavelNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV25ResponsavelNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome1_Visible, edtavResponsavelnacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome1_Internalname, "Responsavel Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome1_Internalname, AV26ResponsavelProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV26ResponsavelProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome1_Visible, edtavResponsavelprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome1_Internalname, "Responsavel Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_186_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome1_Internalname, AV27ResponsavelMunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV27ResponsavelMunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome1_Visible, edtavResponsavelmunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/WpClientes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/WpClientes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/WpClientes.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_9A2e( true) ;
         }
         else
         {
            wb_table1_43_9A2e( false) ;
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
         PA9A2( ) ;
         WS9A2( ) ;
         WE9A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019282968", true, true);
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
         context.AddJavascriptSource("costumer/wpclientes.js", "?202561019282969", false, true);
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

      protected void SubsflControlProps_1862( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_186_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_186_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_186_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_186_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_186_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_186_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_186_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_186_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_186_idx;
         edtClienteCountNotas_F_Internalname = "CLIENTECOUNTNOTAS_F_"+sGXsfl_186_idx;
      }

      protected void SubsflControlProps_fel_1862( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_186_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_186_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_186_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_186_fel_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_186_fel_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_186_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_186_fel_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_186_fel_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_186_fel_idx;
         edtClienteCountNotas_F_Internalname = "CLIENTECOUNTNOTAS_F_"+sGXsfl_186_fel_idx;
      }

      protected void sendrow_1862( )
      {
         sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
         SubsflControlProps_1862( ) ;
         WB9A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_186_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_186_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_186_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'" + sGXsfl_186_idx + "',186)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_186_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV83GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV83GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_186_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,187);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_186_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelNome_Internalname,(string)A436ResponsavelNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelEmail_Internalname,(string)A456ResponsavelEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A456ResponsavelEmail,(string)"",(string)"",(string)"",(string)edtResponsavelEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCreatedAt_Internalname,context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A175ClienteCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESITUACAO_" + sGXsfl_186_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteSituacao,(string)cmbClienteSituacao_Internalname,StringUtil.RTrim( A884ClienteSituacao),(short)1,(string)cmbClienteSituacao_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbClienteSituacao.CurrentValue = StringUtil.RTrim( A884ClienteSituacao);
            AssignProp("", false, cmbClienteSituacao_Internalname, "Values", (string)(cmbClienteSituacao.ToJavascriptSource()), !bGXsfl_186_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCountNotas_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A886ClienteCountNotas_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A886ClienteCountNotas_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCountNotas_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)186,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_186_idx = ((subGrid_Islastpage==1)&&(nGXsfl_186_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_186_idx+1);
            sGXsfl_186_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_186_idx), 4, 0), 4, "0");
            SubsflControlProps_1862( ) ;
         }
         /* End function sendrow_1862 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector1.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         cmbavDynamicfiltersselector1.addItem("CLIENTECONVENIODESCRICAO", "Convenio Descricao", 0);
         cmbavDynamicfiltersselector1.addItem("CLIENTENACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector1.addItem("CLIENTEPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector1.addItem("MUNICIPIONOME", "Municipio Nome", 0);
         cmbavDynamicfiltersselector1.addItem("BANCOCODIGO", "Banco Codigo", 0);
         cmbavDynamicfiltersselector1.addItem("RESPONSAVELNACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector1.addItem("RESPONSAVELPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector1.addItem("RESPONSAVELMUNICIPIONOME", "Municipio Nome", 0);
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
         cmbavDynamicfiltersselector2.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector2.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         cmbavDynamicfiltersselector2.addItem("CLIENTECONVENIODESCRICAO", "Convenio Descricao", 0);
         cmbavDynamicfiltersselector2.addItem("CLIENTENACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector2.addItem("CLIENTEPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector2.addItem("MUNICIPIONOME", "Municipio Nome", 0);
         cmbavDynamicfiltersselector2.addItem("BANCOCODIGO", "Banco Codigo", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELNACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector3.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTECONVENIODESCRICAO", "Convenio Descricao", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTENACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTEPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector3.addItem("MUNICIPIONOME", "Municipio Nome", 0);
         cmbavDynamicfiltersselector3.addItem("BANCOCODIGO", "Banco Codigo", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELNACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV42DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV42DynamicFiltersSelector3);
            AssignAttri("", false, "AV42DynamicFiltersSelector3", AV42DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV43DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV43DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV43DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_186_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV83GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV83GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV83GridActionGroup1), 4, 0));
         }
         GXCCtl = "CLIENTESITUACAO_" + sGXsfl_186_idx;
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
         /* End function init_web_controls */
      }

      protected void StartGridControl186( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"186\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Representante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data de registro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notas") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83GridActionGroup1), 4, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A436ResponsavelNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A456ResponsavelEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A171ClienteNomeFantasia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A884ClienteSituacao)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A886ClienteCountNotas_F), 4, 0, ".", ""))));
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
         edtavClientedocumento1_Internalname = "vCLIENTEDOCUMENTO1";
         cellFilter_clientedocumento1_cell_Internalname = "FILTER_CLIENTEDOCUMENTO1_CELL";
         edtavTipoclientedescricao1_Internalname = "vTIPOCLIENTEDESCRICAO1";
         cellFilter_tipoclientedescricao1_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO1_CELL";
         edtavClienteconveniodescricao1_Internalname = "vCLIENTECONVENIODESCRICAO1";
         cellFilter_clienteconveniodescricao1_cell_Internalname = "FILTER_CLIENTECONVENIODESCRICAO1_CELL";
         edtavClientenacionalidadenome1_Internalname = "vCLIENTENACIONALIDADENOME1";
         cellFilter_clientenacionalidadenome1_cell_Internalname = "FILTER_CLIENTENACIONALIDADENOME1_CELL";
         edtavClienteprofissaonome1_Internalname = "vCLIENTEPROFISSAONOME1";
         cellFilter_clienteprofissaonome1_cell_Internalname = "FILTER_CLIENTEPROFISSAONOME1_CELL";
         edtavMunicipionome1_Internalname = "vMUNICIPIONOME1";
         cellFilter_municipionome1_cell_Internalname = "FILTER_MUNICIPIONOME1_CELL";
         edtavBancocodigo1_Internalname = "vBANCOCODIGO1";
         cellFilter_bancocodigo1_cell_Internalname = "FILTER_BANCOCODIGO1_CELL";
         edtavResponsavelnacionalidadenome1_Internalname = "vRESPONSAVELNACIONALIDADENOME1";
         cellFilter_responsavelnacionalidadenome1_cell_Internalname = "FILTER_RESPONSAVELNACIONALIDADENOME1_CELL";
         edtavResponsavelprofissaonome1_Internalname = "vRESPONSAVELPROFISSAONOME1";
         cellFilter_responsavelprofissaonome1_cell_Internalname = "FILTER_RESPONSAVELPROFISSAONOME1_CELL";
         edtavResponsavelmunicipionome1_Internalname = "vRESPONSAVELMUNICIPIONOME1";
         cellFilter_responsavelmunicipionome1_cell_Internalname = "FILTER_RESPONSAVELMUNICIPIONOME1_CELL";
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
         edtavClientedocumento2_Internalname = "vCLIENTEDOCUMENTO2";
         cellFilter_clientedocumento2_cell_Internalname = "FILTER_CLIENTEDOCUMENTO2_CELL";
         edtavTipoclientedescricao2_Internalname = "vTIPOCLIENTEDESCRICAO2";
         cellFilter_tipoclientedescricao2_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO2_CELL";
         edtavClienteconveniodescricao2_Internalname = "vCLIENTECONVENIODESCRICAO2";
         cellFilter_clienteconveniodescricao2_cell_Internalname = "FILTER_CLIENTECONVENIODESCRICAO2_CELL";
         edtavClientenacionalidadenome2_Internalname = "vCLIENTENACIONALIDADENOME2";
         cellFilter_clientenacionalidadenome2_cell_Internalname = "FILTER_CLIENTENACIONALIDADENOME2_CELL";
         edtavClienteprofissaonome2_Internalname = "vCLIENTEPROFISSAONOME2";
         cellFilter_clienteprofissaonome2_cell_Internalname = "FILTER_CLIENTEPROFISSAONOME2_CELL";
         edtavMunicipionome2_Internalname = "vMUNICIPIONOME2";
         cellFilter_municipionome2_cell_Internalname = "FILTER_MUNICIPIONOME2_CELL";
         edtavBancocodigo2_Internalname = "vBANCOCODIGO2";
         cellFilter_bancocodigo2_cell_Internalname = "FILTER_BANCOCODIGO2_CELL";
         edtavResponsavelnacionalidadenome2_Internalname = "vRESPONSAVELNACIONALIDADENOME2";
         cellFilter_responsavelnacionalidadenome2_cell_Internalname = "FILTER_RESPONSAVELNACIONALIDADENOME2_CELL";
         edtavResponsavelprofissaonome2_Internalname = "vRESPONSAVELPROFISSAONOME2";
         cellFilter_responsavelprofissaonome2_cell_Internalname = "FILTER_RESPONSAVELPROFISSAONOME2_CELL";
         edtavResponsavelmunicipionome2_Internalname = "vRESPONSAVELMUNICIPIONOME2";
         cellFilter_responsavelmunicipionome2_cell_Internalname = "FILTER_RESPONSAVELMUNICIPIONOME2_CELL";
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
         edtavClientedocumento3_Internalname = "vCLIENTEDOCUMENTO3";
         cellFilter_clientedocumento3_cell_Internalname = "FILTER_CLIENTEDOCUMENTO3_CELL";
         edtavTipoclientedescricao3_Internalname = "vTIPOCLIENTEDESCRICAO3";
         cellFilter_tipoclientedescricao3_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO3_CELL";
         edtavClienteconveniodescricao3_Internalname = "vCLIENTECONVENIODESCRICAO3";
         cellFilter_clienteconveniodescricao3_cell_Internalname = "FILTER_CLIENTECONVENIODESCRICAO3_CELL";
         edtavClientenacionalidadenome3_Internalname = "vCLIENTENACIONALIDADENOME3";
         cellFilter_clientenacionalidadenome3_cell_Internalname = "FILTER_CLIENTENACIONALIDADENOME3_CELL";
         edtavClienteprofissaonome3_Internalname = "vCLIENTEPROFISSAONOME3";
         cellFilter_clienteprofissaonome3_cell_Internalname = "FILTER_CLIENTEPROFISSAONOME3_CELL";
         edtavMunicipionome3_Internalname = "vMUNICIPIONOME3";
         cellFilter_municipionome3_cell_Internalname = "FILTER_MUNICIPIONOME3_CELL";
         edtavBancocodigo3_Internalname = "vBANCOCODIGO3";
         cellFilter_bancocodigo3_cell_Internalname = "FILTER_BANCOCODIGO3_CELL";
         edtavResponsavelnacionalidadenome3_Internalname = "vRESPONSAVELNACIONALIDADENOME3";
         cellFilter_responsavelnacionalidadenome3_cell_Internalname = "FILTER_RESPONSAVELNACIONALIDADENOME3_CELL";
         edtavResponsavelprofissaonome3_Internalname = "vRESPONSAVELPROFISSAONOME3";
         cellFilter_responsavelprofissaonome3_cell_Internalname = "FILTER_RESPONSAVELPROFISSAONOME3_CELL";
         edtavResponsavelmunicipionome3_Internalname = "vRESPONSAVELMUNICIPIONOME3";
         cellFilter_responsavelmunicipionome3_cell_Internalname = "FILTER_RESPONSAVELMUNICIPIONOME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtResponsavelNome_Internalname = "RESPONSAVELNOME";
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT";
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO";
         edtClienteCountNotas_F_Internalname = "CLIENTECOUNTNOTAS_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_clientecreatedatauxdatetext_Internalname = "vDDO_CLIENTECREATEDATAUXDATETEXT";
         Tfclientecreatedat_rangepicker_Internalname = "TFCLIENTECREATEDAT_RANGEPICKER";
         divDdo_clientecreatedatauxdates_Internalname = "DDO_CLIENTECREATEDATAUXDATES";
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
         edtClienteCountNotas_F_Jsonclick = "";
         cmbClienteSituacao_Jsonclick = "";
         edtClienteCreatedAt_Jsonclick = "";
         edtClienteNomeFantasia_Jsonclick = "";
         edtResponsavelEmail_Jsonclick = "";
         edtResponsavelNome_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavResponsavelmunicipionome1_Jsonclick = "";
         edtavResponsavelmunicipionome1_Enabled = 1;
         edtavResponsavelprofissaonome1_Jsonclick = "";
         edtavResponsavelprofissaonome1_Enabled = 1;
         edtavResponsavelnacionalidadenome1_Jsonclick = "";
         edtavResponsavelnacionalidadenome1_Enabled = 1;
         edtavBancocodigo1_Jsonclick = "";
         edtavBancocodigo1_Enabled = 1;
         edtavMunicipionome1_Jsonclick = "";
         edtavMunicipionome1_Enabled = 1;
         edtavClienteprofissaonome1_Jsonclick = "";
         edtavClienteprofissaonome1_Enabled = 1;
         edtavClientenacionalidadenome1_Jsonclick = "";
         edtavClientenacionalidadenome1_Enabled = 1;
         edtavClienteconveniodescricao1_Jsonclick = "";
         edtavClienteconveniodescricao1_Enabled = 1;
         edtavTipoclientedescricao1_Jsonclick = "";
         edtavTipoclientedescricao1_Enabled = 1;
         edtavClientedocumento1_Jsonclick = "";
         edtavClientedocumento1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavResponsavelmunicipionome2_Jsonclick = "";
         edtavResponsavelmunicipionome2_Enabled = 1;
         edtavResponsavelprofissaonome2_Jsonclick = "";
         edtavResponsavelprofissaonome2_Enabled = 1;
         edtavResponsavelnacionalidadenome2_Jsonclick = "";
         edtavResponsavelnacionalidadenome2_Enabled = 1;
         edtavBancocodigo2_Jsonclick = "";
         edtavBancocodigo2_Enabled = 1;
         edtavMunicipionome2_Jsonclick = "";
         edtavMunicipionome2_Enabled = 1;
         edtavClienteprofissaonome2_Jsonclick = "";
         edtavClienteprofissaonome2_Enabled = 1;
         edtavClientenacionalidadenome2_Jsonclick = "";
         edtavClientenacionalidadenome2_Enabled = 1;
         edtavClienteconveniodescricao2_Jsonclick = "";
         edtavClienteconveniodescricao2_Enabled = 1;
         edtavTipoclientedescricao2_Jsonclick = "";
         edtavTipoclientedescricao2_Enabled = 1;
         edtavClientedocumento2_Jsonclick = "";
         edtavClientedocumento2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavResponsavelmunicipionome3_Jsonclick = "";
         edtavResponsavelmunicipionome3_Enabled = 1;
         edtavResponsavelprofissaonome3_Jsonclick = "";
         edtavResponsavelprofissaonome3_Enabled = 1;
         edtavResponsavelnacionalidadenome3_Jsonclick = "";
         edtavResponsavelnacionalidadenome3_Enabled = 1;
         edtavBancocodigo3_Jsonclick = "";
         edtavBancocodigo3_Enabled = 1;
         edtavMunicipionome3_Jsonclick = "";
         edtavMunicipionome3_Enabled = 1;
         edtavClienteprofissaonome3_Jsonclick = "";
         edtavClienteprofissaonome3_Enabled = 1;
         edtavClientenacionalidadenome3_Jsonclick = "";
         edtavClientenacionalidadenome3_Enabled = 1;
         edtavClienteconveniodescricao3_Jsonclick = "";
         edtavClienteconveniodescricao3_Enabled = 1;
         edtavTipoclientedescricao3_Jsonclick = "";
         edtavTipoclientedescricao3_Enabled = 1;
         edtavClientedocumento3_Jsonclick = "";
         edtavClientedocumento3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavResponsavelmunicipionome3_Visible = 1;
         edtavResponsavelprofissaonome3_Visible = 1;
         edtavResponsavelnacionalidadenome3_Visible = 1;
         edtavBancocodigo3_Visible = 1;
         edtavMunicipionome3_Visible = 1;
         edtavClienteprofissaonome3_Visible = 1;
         edtavClientenacionalidadenome3_Visible = 1;
         edtavClienteconveniodescricao3_Visible = 1;
         edtavTipoclientedescricao3_Visible = 1;
         edtavClientedocumento3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavResponsavelmunicipionome2_Visible = 1;
         edtavResponsavelprofissaonome2_Visible = 1;
         edtavResponsavelnacionalidadenome2_Visible = 1;
         edtavBancocodigo2_Visible = 1;
         edtavMunicipionome2_Visible = 1;
         edtavClienteprofissaonome2_Visible = 1;
         edtavClientenacionalidadenome2_Visible = 1;
         edtavClienteconveniodescricao2_Visible = 1;
         edtavTipoclientedescricao2_Visible = 1;
         edtavClientedocumento2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavResponsavelmunicipionome1_Visible = 1;
         edtavResponsavelprofissaonome1_Visible = 1;
         edtavResponsavelnacionalidadenome1_Visible = 1;
         edtavBancocodigo1_Visible = 1;
         edtavMunicipionome1_Visible = 1;
         edtavClienteprofissaonome1_Visible = 1;
         edtavClientenacionalidadenome1_Visible = 1;
         edtavClienteconveniodescricao1_Visible = 1;
         edtavTipoclientedescricao1_Visible = 1;
         edtavClientedocumento1_Visible = 1;
         edtClienteCountNotas_F_Enabled = 0;
         cmbClienteSituacao.Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtResponsavelEmail_Enabled = 0;
         edtResponsavelNome_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_clientecreatedatauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "|||||4.0";
         Ddo_grid_Datalistproc = "Costumer.WpClientesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||P:Aguardando Análise,A:Aprovado,R:Rejeitado|";
         Ddo_grid_Allowmultipleselection = "||||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic||FixedValues|";
         Ddo_grid_Includedatalist = "T|T|T||T|";
         Ddo_grid_Filterisrange = "|||P||T";
         Ddo_grid_Filtertype = "Character|Character|Character|Date||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T||T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|";
         Ddo_grid_Columnids = "3:ClienteRazaoSocial|4:ResponsavelNome|5:ResponsavelEmail|7:ClienteCreatedAt|8:ClienteSituacao|9:ClienteCountNotas_F";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV73TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E269A2","iparms":[{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A793TipoClientePortalPjPf","fld":"TIPOCLIENTEPORTALPJPF","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV83GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E199A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E209A2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E219A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E229A2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E239A2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119A2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV73TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70DDO_ClienteCreatedAtAuxDate","fld":"vDDO_CLIENTECREATEDATAUXDATE","type":"date"},{"av":"AV71DDO_ClienteCreatedAtAuxDateTo","fld":"vDDO_CLIENTECREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV73TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70DDO_ClienteCreatedAtAuxDate","fld":"vDDO_CLIENTECREATEDATAUXDATE","type":"date"},{"av":"AV71DDO_ClienteCreatedAtAuxDateTo","fld":"vDDO_CLIENTECREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV81GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E279A2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV83GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV83GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E189A2","iparms":[{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV73TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV70DDO_ClienteCreatedAtAuxDate","fld":"vDDO_CLIENTECREATEDATAUXDATE","type":"date"},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV71DDO_ClienteCreatedAtAuxDateTo","fld":"vDDO_CLIENTECREATEDATAUXDATETO","type":"date"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV62TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV63TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV64TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV65TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV66TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV67TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV68TFClienteCreatedAt","fld":"vTFCLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV69TFClienteCreatedAt_To","fld":"vTFCLIENTECREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV75TFClienteCountNotas_F","fld":"vTFCLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"AV76TFClienteCountNotas_F_To","fld":"vTFCLIENTECOUNTNOTAS_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV73TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70DDO_ClienteCreatedAtAuxDate","fld":"vDDO_CLIENTECREATEDATAUXDATE","type":"date"},{"av":"AV71DDO_ClienteCreatedAtAuxDateTo","fld":"vDDO_CLIENTECREATEDATAUXDATETO","type":"date"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Clientecountnotas_f","iparms":[]}""");
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
         AV18ClienteDocumento1 = "";
         AV19TipoClienteDescricao1 = "";
         AV20ClienteConvenioDescricao1 = "";
         AV21ClienteNacionalidadeNome1 = "";
         AV22ClienteProfissaoNome1 = "";
         AV23MunicipioNome1 = "";
         AV25ResponsavelNacionalidadeNome1 = "";
         AV26ResponsavelProfissaoNome1 = "";
         AV27ResponsavelMunicipioNome1 = "";
         AV29DynamicFiltersSelector2 = "";
         AV31ClienteDocumento2 = "";
         AV32TipoClienteDescricao2 = "";
         AV33ClienteConvenioDescricao2 = "";
         AV34ClienteNacionalidadeNome2 = "";
         AV35ClienteProfissaoNome2 = "";
         AV36MunicipioNome2 = "";
         AV38ResponsavelNacionalidadeNome2 = "";
         AV39ResponsavelProfissaoNome2 = "";
         AV40ResponsavelMunicipioNome2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44ClienteDocumento3 = "";
         AV45TipoClienteDescricao3 = "";
         AV46ClienteConvenioDescricao3 = "";
         AV47ClienteNacionalidadeNome3 = "";
         AV48ClienteProfissaoNome3 = "";
         AV49MunicipioNome3 = "";
         AV51ResponsavelNacionalidadeNome3 = "";
         AV52ResponsavelProfissaoNome3 = "";
         AV53ResponsavelMunicipioNome3 = "";
         AV84Pgmname = "";
         AV15FilterFullText = "";
         AV62TFClienteRazaoSocial = "";
         AV63TFClienteRazaoSocial_Sel = "";
         AV64TFResponsavelNome = "";
         AV65TFResponsavelNome_Sel = "";
         AV66TFResponsavelEmail = "";
         AV67TFResponsavelEmail_Sel = "";
         AV68TFClienteCreatedAt = (DateTime)(DateTime.MinValue);
         AV69TFClienteCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV74TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV59ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV81GridAppliedFilters = "";
         AV77DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV70DDO_ClienteCreatedAtAuxDate = DateTime.MinValue;
         AV71DDO_ClienteCreatedAtAuxDateTo = DateTime.MinValue;
         A172ClienteTipoPessoa = "";
         AV73TFClienteSituacao_SelsJson = "";
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
         AV72DDO_ClienteCreatedAtAuxDateText = "";
         ucTfclientecreatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A436ResponsavelNome = "";
         A456ResponsavelEmail = "";
         A171ClienteNomeFantasia = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A884ClienteSituacao = "";
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = new GxSimpleCollection<string>();
         lV85Costumer_wpclientesds_1_filterfulltext = "";
         lV88Costumer_wpclientesds_4_clientedocumento1 = "";
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         lV93Costumer_wpclientesds_9_municipionome1 = "";
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         lV101Costumer_wpclientesds_17_clientedocumento2 = "";
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         lV106Costumer_wpclientesds_22_municipionome2 = "";
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         lV114Costumer_wpclientesds_30_clientedocumento3 = "";
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         lV119Costumer_wpclientesds_35_municipionome3 = "";
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = "";
         lV126Costumer_wpclientesds_42_tfresponsavelnome = "";
         lV128Costumer_wpclientesds_44_tfresponsavelemail = "";
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = "";
         AV88Costumer_wpclientesds_4_clientedocumento1 = "";
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         AV93Costumer_wpclientesds_9_municipionome1 = "";
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = "";
         AV101Costumer_wpclientesds_17_clientedocumento2 = "";
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         AV106Costumer_wpclientesds_22_municipionome2 = "";
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = "";
         AV114Costumer_wpclientesds_30_clientedocumento3 = "";
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         AV119Costumer_wpclientesds_35_municipionome3 = "";
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = "";
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = "";
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = "";
         AV126Costumer_wpclientesds_42_tfresponsavelnome = "";
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = "";
         AV128Costumer_wpclientesds_44_tfresponsavelemail = "";
         AV130Costumer_wpclientesds_46_tfclientecreatedat = (DateTime)(DateTime.MinValue);
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = (DateTime)(DateTime.MinValue);
         A193TipoClienteDescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         AV85Costumer_wpclientesds_1_filterfulltext = "";
         H009A3_A192TipoClienteId = new short[1] ;
         H009A3_n192TipoClienteId = new bool[] {false} ;
         H009A3_A186MunicipioCodigo = new string[] {""} ;
         H009A3_n186MunicipioCodigo = new bool[] {false} ;
         H009A3_A444ResponsavelMunicipio = new string[] {""} ;
         H009A3_n444ResponsavelMunicipio = new bool[] {false} ;
         H009A3_A402BancoId = new int[1] ;
         H009A3_n402BancoId = new bool[] {false} ;
         H009A3_A437ResponsavelNacionalidade = new int[1] ;
         H009A3_n437ResponsavelNacionalidade = new bool[] {false} ;
         H009A3_A484ClienteNacionalidade = new int[1] ;
         H009A3_n484ClienteNacionalidade = new bool[] {false} ;
         H009A3_A442ResponsavelProfissao = new int[1] ;
         H009A3_n442ResponsavelProfissao = new bool[] {false} ;
         H009A3_A487ClienteProfissao = new int[1] ;
         H009A3_n487ClienteProfissao = new bool[] {false} ;
         H009A3_A489ClienteConvenio = new int[1] ;
         H009A3_n489ClienteConvenio = new bool[] {false} ;
         H009A3_A445ResponsavelMunicipioNome = new string[] {""} ;
         H009A3_n445ResponsavelMunicipioNome = new bool[] {false} ;
         H009A3_A443ResponsavelProfissaoNome = new string[] {""} ;
         H009A3_n443ResponsavelProfissaoNome = new bool[] {false} ;
         H009A3_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         H009A3_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         H009A3_A404BancoCodigo = new int[1] ;
         H009A3_n404BancoCodigo = new bool[] {false} ;
         H009A3_A187MunicipioNome = new string[] {""} ;
         H009A3_n187MunicipioNome = new bool[] {false} ;
         H009A3_A488ClienteProfissaoNome = new string[] {""} ;
         H009A3_n488ClienteProfissaoNome = new bool[] {false} ;
         H009A3_A485ClienteNacionalidadeNome = new string[] {""} ;
         H009A3_n485ClienteNacionalidadeNome = new bool[] {false} ;
         H009A3_A490ClienteConvenioDescricao = new string[] {""} ;
         H009A3_n490ClienteConvenioDescricao = new bool[] {false} ;
         H009A3_A193TipoClienteDescricao = new string[] {""} ;
         H009A3_n193TipoClienteDescricao = new bool[] {false} ;
         H009A3_A793TipoClientePortalPjPf = new bool[] {false} ;
         H009A3_n793TipoClientePortalPjPf = new bool[] {false} ;
         H009A3_A172ClienteTipoPessoa = new string[] {""} ;
         H009A3_n172ClienteTipoPessoa = new bool[] {false} ;
         H009A3_A884ClienteSituacao = new string[] {""} ;
         H009A3_n884ClienteSituacao = new bool[] {false} ;
         H009A3_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009A3_n175ClienteCreatedAt = new bool[] {false} ;
         H009A3_A171ClienteNomeFantasia = new string[] {""} ;
         H009A3_n171ClienteNomeFantasia = new bool[] {false} ;
         H009A3_A456ResponsavelEmail = new string[] {""} ;
         H009A3_n456ResponsavelEmail = new bool[] {false} ;
         H009A3_A436ResponsavelNome = new string[] {""} ;
         H009A3_n436ResponsavelNome = new bool[] {false} ;
         H009A3_A170ClienteRazaoSocial = new string[] {""} ;
         H009A3_n170ClienteRazaoSocial = new bool[] {false} ;
         H009A3_A169ClienteDocumento = new string[] {""} ;
         H009A3_n169ClienteDocumento = new bool[] {false} ;
         H009A3_A168ClienteId = new int[1] ;
         H009A3_n168ClienteId = new bool[] {false} ;
         H009A3_A886ClienteCountNotas_F = new short[1] ;
         H009A3_n886ClienteCountNotas_F = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         H009A5_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV60ManageFiltersXml = "";
         AV56ExcelFilename = "";
         AV57ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV82AuxText = "";
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.wpclientes__default(),
            new Object[][] {
                new Object[] {
               H009A3_A192TipoClienteId, H009A3_n192TipoClienteId, H009A3_A186MunicipioCodigo, H009A3_n186MunicipioCodigo, H009A3_A444ResponsavelMunicipio, H009A3_n444ResponsavelMunicipio, H009A3_A402BancoId, H009A3_n402BancoId, H009A3_A437ResponsavelNacionalidade, H009A3_n437ResponsavelNacionalidade,
               H009A3_A484ClienteNacionalidade, H009A3_n484ClienteNacionalidade, H009A3_A442ResponsavelProfissao, H009A3_n442ResponsavelProfissao, H009A3_A487ClienteProfissao, H009A3_n487ClienteProfissao, H009A3_A489ClienteConvenio, H009A3_n489ClienteConvenio, H009A3_A445ResponsavelMunicipioNome, H009A3_n445ResponsavelMunicipioNome,
               H009A3_A443ResponsavelProfissaoNome, H009A3_n443ResponsavelProfissaoNome, H009A3_A438ResponsavelNacionalidadeNome, H009A3_n438ResponsavelNacionalidadeNome, H009A3_A404BancoCodigo, H009A3_n404BancoCodigo, H009A3_A187MunicipioNome, H009A3_n187MunicipioNome, H009A3_A488ClienteProfissaoNome, H009A3_n488ClienteProfissaoNome,
               H009A3_A485ClienteNacionalidadeNome, H009A3_n485ClienteNacionalidadeNome, H009A3_A490ClienteConvenioDescricao, H009A3_n490ClienteConvenioDescricao, H009A3_A193TipoClienteDescricao, H009A3_n193TipoClienteDescricao, H009A3_A793TipoClientePortalPjPf, H009A3_n793TipoClientePortalPjPf, H009A3_A172ClienteTipoPessoa, H009A3_n172ClienteTipoPessoa,
               H009A3_A884ClienteSituacao, H009A3_n884ClienteSituacao, H009A3_A175ClienteCreatedAt, H009A3_n175ClienteCreatedAt, H009A3_A171ClienteNomeFantasia, H009A3_n171ClienteNomeFantasia, H009A3_A456ResponsavelEmail, H009A3_n456ResponsavelEmail, H009A3_A436ResponsavelNome, H009A3_n436ResponsavelNome,
               H009A3_A170ClienteRazaoSocial, H009A3_n170ClienteRazaoSocial, H009A3_A169ClienteDocumento, H009A3_n169ClienteDocumento, H009A3_A168ClienteId, H009A3_A886ClienteCountNotas_F, H009A3_n886ClienteCountNotas_F
               }
               , new Object[] {
               H009A5_AGRID_nRecordCount
               }
            }
         );
         AV84Pgmname = "Costumer.WpClientes";
         /* GeneXus formulas. */
         AV84Pgmname = "Costumer.WpClientes";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV30DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV61ManageFiltersExecutionStep ;
      private short AV75TFClienteCountNotas_F ;
      private short AV76TFClienteCountNotas_F_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV83GridActionGroup1 ;
      private short A886ClienteCountNotas_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ;
      private short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ;
      private short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ;
      private short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ;
      private short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ;
      private short A192TipoClienteId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_186 ;
      private int nGXsfl_186_idx=1 ;
      private int AV24BancoCodigo1 ;
      private int AV37BancoCodigo2 ;
      private int AV50BancoCodigo3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ;
      private int AV94Costumer_wpclientesds_10_bancocodigo1 ;
      private int AV107Costumer_wpclientesds_23_bancocodigo2 ;
      private int AV120Costumer_wpclientesds_36_bancocodigo3 ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int edtClienteId_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtResponsavelNome_Enabled ;
      private int edtResponsavelEmail_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtClienteCreatedAt_Enabled ;
      private int edtClienteCountNotas_F_Enabled ;
      private int AV78PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavClientedocumento1_Visible ;
      private int edtavTipoclientedescricao1_Visible ;
      private int edtavClienteconveniodescricao1_Visible ;
      private int edtavClientenacionalidadenome1_Visible ;
      private int edtavClienteprofissaonome1_Visible ;
      private int edtavMunicipionome1_Visible ;
      private int edtavBancocodigo1_Visible ;
      private int edtavResponsavelnacionalidadenome1_Visible ;
      private int edtavResponsavelprofissaonome1_Visible ;
      private int edtavResponsavelmunicipionome1_Visible ;
      private int edtavClientedocumento2_Visible ;
      private int edtavTipoclientedescricao2_Visible ;
      private int edtavClienteconveniodescricao2_Visible ;
      private int edtavClientenacionalidadenome2_Visible ;
      private int edtavClienteprofissaonome2_Visible ;
      private int edtavMunicipionome2_Visible ;
      private int edtavBancocodigo2_Visible ;
      private int edtavResponsavelnacionalidadenome2_Visible ;
      private int edtavResponsavelprofissaonome2_Visible ;
      private int edtavResponsavelmunicipionome2_Visible ;
      private int edtavClientedocumento3_Visible ;
      private int edtavTipoclientedescricao3_Visible ;
      private int edtavClienteconveniodescricao3_Visible ;
      private int edtavClientenacionalidadenome3_Visible ;
      private int edtavClienteprofissaonome3_Visible ;
      private int edtavMunicipionome3_Visible ;
      private int edtavBancocodigo3_Visible ;
      private int edtavResponsavelnacionalidadenome3_Visible ;
      private int edtavResponsavelprofissaonome3_Visible ;
      private int edtavResponsavelmunicipionome3_Visible ;
      private int AV135GXV1 ;
      private int edtavClientedocumento3_Enabled ;
      private int edtavTipoclientedescricao3_Enabled ;
      private int edtavClienteconveniodescricao3_Enabled ;
      private int edtavClientenacionalidadenome3_Enabled ;
      private int edtavClienteprofissaonome3_Enabled ;
      private int edtavMunicipionome3_Enabled ;
      private int edtavBancocodigo3_Enabled ;
      private int edtavResponsavelnacionalidadenome3_Enabled ;
      private int edtavResponsavelprofissaonome3_Enabled ;
      private int edtavResponsavelmunicipionome3_Enabled ;
      private int edtavClientedocumento2_Enabled ;
      private int edtavTipoclientedescricao2_Enabled ;
      private int edtavClienteconveniodescricao2_Enabled ;
      private int edtavClientenacionalidadenome2_Enabled ;
      private int edtavClienteprofissaonome2_Enabled ;
      private int edtavMunicipionome2_Enabled ;
      private int edtavBancocodigo2_Enabled ;
      private int edtavResponsavelnacionalidadenome2_Enabled ;
      private int edtavResponsavelprofissaonome2_Enabled ;
      private int edtavResponsavelmunicipionome2_Enabled ;
      private int edtavClientedocumento1_Enabled ;
      private int edtavTipoclientedescricao1_Enabled ;
      private int edtavClienteconveniodescricao1_Enabled ;
      private int edtavClientenacionalidadenome1_Enabled ;
      private int edtavClienteprofissaonome1_Enabled ;
      private int edtavMunicipionome1_Enabled ;
      private int edtavBancocodigo1_Enabled ;
      private int edtavResponsavelnacionalidadenome1_Enabled ;
      private int edtavResponsavelprofissaonome1_Enabled ;
      private int edtavResponsavelmunicipionome1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV79GridCurrentPage ;
      private long AV80GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_186_idx="0001" ;
      private string AV84Pgmname ;
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
      private string divDdo_clientecreatedatauxdates_Internalname ;
      private string edtavDdo_clientecreatedatauxdatetext_Internalname ;
      private string edtavDdo_clientecreatedatauxdatetext_Jsonclick ;
      private string Tfclientecreatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtResponsavelNome_Internalname ;
      private string edtResponsavelEmail_Internalname ;
      private string edtClienteNomeFantasia_Internalname ;
      private string edtClienteCreatedAt_Internalname ;
      private string cmbClienteSituacao_Internalname ;
      private string A884ClienteSituacao ;
      private string edtClienteCountNotas_F_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavClientedocumento1_Internalname ;
      private string edtavTipoclientedescricao1_Internalname ;
      private string edtavClienteconveniodescricao1_Internalname ;
      private string edtavClientenacionalidadenome1_Internalname ;
      private string edtavClienteprofissaonome1_Internalname ;
      private string edtavMunicipionome1_Internalname ;
      private string edtavBancocodigo1_Internalname ;
      private string edtavResponsavelnacionalidadenome1_Internalname ;
      private string edtavResponsavelprofissaonome1_Internalname ;
      private string edtavResponsavelmunicipionome1_Internalname ;
      private string edtavClientedocumento2_Internalname ;
      private string edtavTipoclientedescricao2_Internalname ;
      private string edtavClienteconveniodescricao2_Internalname ;
      private string edtavClientenacionalidadenome2_Internalname ;
      private string edtavClienteprofissaonome2_Internalname ;
      private string edtavMunicipionome2_Internalname ;
      private string edtavBancocodigo2_Internalname ;
      private string edtavResponsavelnacionalidadenome2_Internalname ;
      private string edtavResponsavelprofissaonome2_Internalname ;
      private string edtavResponsavelmunicipionome2_Internalname ;
      private string edtavClientedocumento3_Internalname ;
      private string edtavTipoclientedescricao3_Internalname ;
      private string edtavClienteconveniodescricao3_Internalname ;
      private string edtavClientenacionalidadenome3_Internalname ;
      private string edtavClienteprofissaonome3_Internalname ;
      private string edtavMunicipionome3_Internalname ;
      private string edtavBancocodigo3_Internalname ;
      private string edtavResponsavelnacionalidadenome3_Internalname ;
      private string edtavResponsavelprofissaonome3_Internalname ;
      private string edtavResponsavelmunicipionome3_Internalname ;
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
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_clientedocumento3_cell_Internalname ;
      private string edtavClientedocumento3_Jsonclick ;
      private string cellFilter_tipoclientedescricao3_cell_Internalname ;
      private string edtavTipoclientedescricao3_Jsonclick ;
      private string cellFilter_clienteconveniodescricao3_cell_Internalname ;
      private string edtavClienteconveniodescricao3_Jsonclick ;
      private string cellFilter_clientenacionalidadenome3_cell_Internalname ;
      private string edtavClientenacionalidadenome3_Jsonclick ;
      private string cellFilter_clienteprofissaonome3_cell_Internalname ;
      private string edtavClienteprofissaonome3_Jsonclick ;
      private string cellFilter_municipionome3_cell_Internalname ;
      private string edtavMunicipionome3_Jsonclick ;
      private string cellFilter_bancocodigo3_cell_Internalname ;
      private string edtavBancocodigo3_Jsonclick ;
      private string cellFilter_responsavelnacionalidadenome3_cell_Internalname ;
      private string edtavResponsavelnacionalidadenome3_Jsonclick ;
      private string cellFilter_responsavelprofissaonome3_cell_Internalname ;
      private string edtavResponsavelprofissaonome3_Jsonclick ;
      private string cellFilter_responsavelmunicipionome3_cell_Internalname ;
      private string edtavResponsavelmunicipionome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_clientedocumento2_cell_Internalname ;
      private string edtavClientedocumento2_Jsonclick ;
      private string cellFilter_tipoclientedescricao2_cell_Internalname ;
      private string edtavTipoclientedescricao2_Jsonclick ;
      private string cellFilter_clienteconveniodescricao2_cell_Internalname ;
      private string edtavClienteconveniodescricao2_Jsonclick ;
      private string cellFilter_clientenacionalidadenome2_cell_Internalname ;
      private string edtavClientenacionalidadenome2_Jsonclick ;
      private string cellFilter_clienteprofissaonome2_cell_Internalname ;
      private string edtavClienteprofissaonome2_Jsonclick ;
      private string cellFilter_municipionome2_cell_Internalname ;
      private string edtavMunicipionome2_Jsonclick ;
      private string cellFilter_bancocodigo2_cell_Internalname ;
      private string edtavBancocodigo2_Jsonclick ;
      private string cellFilter_responsavelnacionalidadenome2_cell_Internalname ;
      private string edtavResponsavelnacionalidadenome2_Jsonclick ;
      private string cellFilter_responsavelprofissaonome2_cell_Internalname ;
      private string edtavResponsavelprofissaonome2_Jsonclick ;
      private string cellFilter_responsavelmunicipionome2_cell_Internalname ;
      private string edtavResponsavelmunicipionome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_clientedocumento1_cell_Internalname ;
      private string edtavClientedocumento1_Jsonclick ;
      private string cellFilter_tipoclientedescricao1_cell_Internalname ;
      private string edtavTipoclientedescricao1_Jsonclick ;
      private string cellFilter_clienteconveniodescricao1_cell_Internalname ;
      private string edtavClienteconveniodescricao1_Jsonclick ;
      private string cellFilter_clientenacionalidadenome1_cell_Internalname ;
      private string edtavClientenacionalidadenome1_Jsonclick ;
      private string cellFilter_clienteprofissaonome1_cell_Internalname ;
      private string edtavClienteprofissaonome1_Jsonclick ;
      private string cellFilter_municipionome1_cell_Internalname ;
      private string edtavMunicipionome1_Jsonclick ;
      private string cellFilter_bancocodigo1_cell_Internalname ;
      private string edtavBancocodigo1_Jsonclick ;
      private string cellFilter_responsavelnacionalidadenome1_cell_Internalname ;
      private string edtavResponsavelnacionalidadenome1_Jsonclick ;
      private string cellFilter_responsavelprofissaonome1_cell_Internalname ;
      private string edtavResponsavelprofissaonome1_Jsonclick ;
      private string cellFilter_responsavelmunicipionome1_cell_Internalname ;
      private string edtavResponsavelmunicipionome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_186_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtResponsavelNome_Jsonclick ;
      private string edtResponsavelEmail_Jsonclick ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string edtClienteCreatedAt_Jsonclick ;
      private string cmbClienteSituacao_Jsonclick ;
      private string edtClienteCountNotas_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV68TFClienteCreatedAt ;
      private DateTime AV69TFClienteCreatedAt_To ;
      private DateTime A175ClienteCreatedAt ;
      private DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ;
      private DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ;
      private DateTime AV70DDO_ClienteCreatedAtAuxDate ;
      private DateTime AV71DDO_ClienteCreatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV28DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV55DynamicFiltersIgnoreFirst ;
      private bool AV54DynamicFiltersRemoving ;
      private bool A793TipoClientePortalPjPf ;
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
      private bool n168ClienteId ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n436ResponsavelNome ;
      private bool n456ResponsavelEmail ;
      private bool n171ClienteNomeFantasia ;
      private bool n175ClienteCreatedAt ;
      private bool n884ClienteSituacao ;
      private bool n886ClienteCountNotas_F ;
      private bool bGXsfl_186_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ;
      private bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n793TipoClientePortalPjPf ;
      private bool n172ClienteTipoPessoa ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV73TFClienteSituacao_SelsJson ;
      private string AV60ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ClienteDocumento1 ;
      private string AV19TipoClienteDescricao1 ;
      private string AV20ClienteConvenioDescricao1 ;
      private string AV21ClienteNacionalidadeNome1 ;
      private string AV22ClienteProfissaoNome1 ;
      private string AV23MunicipioNome1 ;
      private string AV25ResponsavelNacionalidadeNome1 ;
      private string AV26ResponsavelProfissaoNome1 ;
      private string AV27ResponsavelMunicipioNome1 ;
      private string AV29DynamicFiltersSelector2 ;
      private string AV31ClienteDocumento2 ;
      private string AV32TipoClienteDescricao2 ;
      private string AV33ClienteConvenioDescricao2 ;
      private string AV34ClienteNacionalidadeNome2 ;
      private string AV35ClienteProfissaoNome2 ;
      private string AV36MunicipioNome2 ;
      private string AV38ResponsavelNacionalidadeNome2 ;
      private string AV39ResponsavelProfissaoNome2 ;
      private string AV40ResponsavelMunicipioNome2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV44ClienteDocumento3 ;
      private string AV45TipoClienteDescricao3 ;
      private string AV46ClienteConvenioDescricao3 ;
      private string AV47ClienteNacionalidadeNome3 ;
      private string AV48ClienteProfissaoNome3 ;
      private string AV49MunicipioNome3 ;
      private string AV51ResponsavelNacionalidadeNome3 ;
      private string AV52ResponsavelProfissaoNome3 ;
      private string AV53ResponsavelMunicipioNome3 ;
      private string AV15FilterFullText ;
      private string AV62TFClienteRazaoSocial ;
      private string AV63TFClienteRazaoSocial_Sel ;
      private string AV64TFResponsavelNome ;
      private string AV65TFResponsavelNome_Sel ;
      private string AV66TFResponsavelEmail ;
      private string AV67TFResponsavelEmail_Sel ;
      private string AV81GridAppliedFilters ;
      private string A172ClienteTipoPessoa ;
      private string AV72DDO_ClienteCreatedAtAuxDateText ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A436ResponsavelNome ;
      private string A456ResponsavelEmail ;
      private string A171ClienteNomeFantasia ;
      private string lV85Costumer_wpclientesds_1_filterfulltext ;
      private string lV88Costumer_wpclientesds_4_clientedocumento1 ;
      private string lV89Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string lV90Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string lV91Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string lV92Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string lV93Costumer_wpclientesds_9_municipionome1 ;
      private string lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string lV96Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string lV97Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string lV101Costumer_wpclientesds_17_clientedocumento2 ;
      private string lV102Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string lV103Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string lV104Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string lV105Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string lV106Costumer_wpclientesds_22_municipionome2 ;
      private string lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string lV109Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string lV110Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string lV114Costumer_wpclientesds_30_clientedocumento3 ;
      private string lV115Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string lV116Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string lV117Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string lV118Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string lV119Costumer_wpclientesds_35_municipionome3 ;
      private string lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string lV122Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string lV123Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string lV124Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string lV126Costumer_wpclientesds_42_tfresponsavelnome ;
      private string lV128Costumer_wpclientesds_44_tfresponsavelemail ;
      private string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ;
      private string AV88Costumer_wpclientesds_4_clientedocumento1 ;
      private string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string AV93Costumer_wpclientesds_9_municipionome1 ;
      private string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ;
      private string AV101Costumer_wpclientesds_17_clientedocumento2 ;
      private string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string AV106Costumer_wpclientesds_22_municipionome2 ;
      private string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ;
      private string AV114Costumer_wpclientesds_30_clientedocumento3 ;
      private string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string AV119Costumer_wpclientesds_35_municipionome3 ;
      private string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ;
      private string AV124Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ;
      private string AV126Costumer_wpclientesds_42_tfresponsavelnome ;
      private string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ;
      private string AV128Costumer_wpclientesds_44_tfresponsavelemail ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string AV85Costumer_wpclientesds_1_filterfulltext ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV56ExcelFilename ;
      private string AV57ErrorMessage ;
      private string AV82AuxText ;
      private IGxSession AV58Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfclientecreatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbClienteSituacao ;
      private GxSimpleCollection<string> AV74TFClienteSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV59ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV77DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ;
      private IDataStoreProvider pr_default ;
      private short[] H009A3_A192TipoClienteId ;
      private bool[] H009A3_n192TipoClienteId ;
      private string[] H009A3_A186MunicipioCodigo ;
      private bool[] H009A3_n186MunicipioCodigo ;
      private string[] H009A3_A444ResponsavelMunicipio ;
      private bool[] H009A3_n444ResponsavelMunicipio ;
      private int[] H009A3_A402BancoId ;
      private bool[] H009A3_n402BancoId ;
      private int[] H009A3_A437ResponsavelNacionalidade ;
      private bool[] H009A3_n437ResponsavelNacionalidade ;
      private int[] H009A3_A484ClienteNacionalidade ;
      private bool[] H009A3_n484ClienteNacionalidade ;
      private int[] H009A3_A442ResponsavelProfissao ;
      private bool[] H009A3_n442ResponsavelProfissao ;
      private int[] H009A3_A487ClienteProfissao ;
      private bool[] H009A3_n487ClienteProfissao ;
      private int[] H009A3_A489ClienteConvenio ;
      private bool[] H009A3_n489ClienteConvenio ;
      private string[] H009A3_A445ResponsavelMunicipioNome ;
      private bool[] H009A3_n445ResponsavelMunicipioNome ;
      private string[] H009A3_A443ResponsavelProfissaoNome ;
      private bool[] H009A3_n443ResponsavelProfissaoNome ;
      private string[] H009A3_A438ResponsavelNacionalidadeNome ;
      private bool[] H009A3_n438ResponsavelNacionalidadeNome ;
      private int[] H009A3_A404BancoCodigo ;
      private bool[] H009A3_n404BancoCodigo ;
      private string[] H009A3_A187MunicipioNome ;
      private bool[] H009A3_n187MunicipioNome ;
      private string[] H009A3_A488ClienteProfissaoNome ;
      private bool[] H009A3_n488ClienteProfissaoNome ;
      private string[] H009A3_A485ClienteNacionalidadeNome ;
      private bool[] H009A3_n485ClienteNacionalidadeNome ;
      private string[] H009A3_A490ClienteConvenioDescricao ;
      private bool[] H009A3_n490ClienteConvenioDescricao ;
      private string[] H009A3_A193TipoClienteDescricao ;
      private bool[] H009A3_n193TipoClienteDescricao ;
      private bool[] H009A3_A793TipoClientePortalPjPf ;
      private bool[] H009A3_n793TipoClientePortalPjPf ;
      private string[] H009A3_A172ClienteTipoPessoa ;
      private bool[] H009A3_n172ClienteTipoPessoa ;
      private string[] H009A3_A884ClienteSituacao ;
      private bool[] H009A3_n884ClienteSituacao ;
      private DateTime[] H009A3_A175ClienteCreatedAt ;
      private bool[] H009A3_n175ClienteCreatedAt ;
      private string[] H009A3_A171ClienteNomeFantasia ;
      private bool[] H009A3_n171ClienteNomeFantasia ;
      private string[] H009A3_A456ResponsavelEmail ;
      private bool[] H009A3_n456ResponsavelEmail ;
      private string[] H009A3_A436ResponsavelNome ;
      private bool[] H009A3_n436ResponsavelNome ;
      private string[] H009A3_A170ClienteRazaoSocial ;
      private bool[] H009A3_n170ClienteRazaoSocial ;
      private string[] H009A3_A169ClienteDocumento ;
      private bool[] H009A3_n169ClienteDocumento ;
      private int[] H009A3_A168ClienteId ;
      private bool[] H009A3_n168ClienteId ;
      private short[] H009A3_A886ClienteCountNotas_F ;
      private bool[] H009A3_n886ClienteCountNotas_F ;
      private long[] H009A5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpclientes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009A3( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV93Costumer_wpclientesds_9_municipionome1 ,
                                             int AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV106Costumer_wpclientesds_22_municipionome2 ,
                                             int AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV119Costumer_wpclientesds_35_municipionome3 ,
                                             int AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV85Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[86];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T2.TipoClientePortalPjPf, T1.ClienteTipoPessoa, T1.ClienteSituacao, T1.ClienteCreatedAt, T1.ClienteNomeFantasia, T1.ResponsavelEmail, T1.ResponsavelNome, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ClienteId, COALESCE( T11.ClienteCountNotas_F, 0) AS ClienteCountNotas_F";
         sFromString = " FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV85Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV85Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV133Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV133Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[51] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[52] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[53] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int7[55] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[56] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[57] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[58] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[59] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[60] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[61] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[62] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[63] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[69] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[70] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[71] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[72] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[73] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV124Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int7[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[76] = 1;
         }
         if ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV126Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int7[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV127Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int7[78] = 1;
         }
         if ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV128Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int7[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV129Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int7[80] = 1;
         }
         if ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV130Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV130Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int7[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV131Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int7[82] = 1;
         }
         if ( AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV132Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResponsavelNome, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResponsavelNome DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResponsavelEmail, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResponsavelEmail DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteCreatedAt, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteCreatedAt DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteSituacao, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteSituacao DESC, T1.ClienteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ClienteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H009A5( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV93Costumer_wpclientesds_9_municipionome1 ,
                                             int AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV106Costumer_wpclientesds_22_municipionome2 ,
                                             int AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV119Costumer_wpclientesds_35_municipionome3 ,
                                             int AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV85Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[83];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV85Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV85Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV133Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV133Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int9[36] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int9[37] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int9[38] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int9[39] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int9[40] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int9[41] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int9[42] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int9[43] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int9[44] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[45] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[46] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[47] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int9[48] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int9[49] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int9[50] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int9[51] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int9[52] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int9[53] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int9[54] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int9[55] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int9[56] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int9[57] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int9[58] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int9[59] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int9[60] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int9[61] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int9[62] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int9[63] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int9[64] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int9[65] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[66] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[67] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[68] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int9[69] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int9[70] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int9[71] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int9[72] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int9[73] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int9[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV124Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int9[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int9[76] = 1;
         }
         if ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV126Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int9[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV127Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int9[78] = 1;
         }
         if ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV128Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int9[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV129Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int9[80] = 1;
         }
         if ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV130Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV130Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int9[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV131Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int9[82] = 1;
         }
         if ( AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV132Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
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
                     return conditional_H009A3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (string)dynConstraints[65] , (short)dynConstraints[66] , (short)dynConstraints[67] , (short)dynConstraints[68] , (bool)dynConstraints[69] );
               case 1 :
                     return conditional_H009A5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (string)dynConstraints[65] , (short)dynConstraints[66] , (short)dynConstraints[67] , (short)dynConstraints[68] , (bool)dynConstraints[69] );
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
          Object[] prmH009A3;
          prmH009A3 = new Object[] {
          new ParDef("AV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV124Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV126Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV127Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV128Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV129Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV130Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV131Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009A5;
          prmH009A5 = new Object[] {
          new ParDef("AV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV124Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV126Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV127Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV128Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV129Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV130Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV131Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H009A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009A3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009A5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((bool[]) buf[36])[0] = rslt.getBool(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[42])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((string[]) buf[52])[0] = rslt.getVarchar(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((int[]) buf[54])[0] = rslt.getInt(28);
                ((short[]) buf[55])[0] = rslt.getShort(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
