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
   public class clienterepresentantesww : GXDataArea
   {
      public clienterepresentantesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienterepresentantesww( IGxContext context )
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
         nRC_GXsfl_197 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_197"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_197_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_197_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_197_idx = GetPar( "sGXsfl_197_idx");
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
         AV100Pgmname = GetPar( "Pgmname");
         AV90TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
         AV62TFResponsavelNome = GetPar( "TFResponsavelNome");
         AV63TFResponsavelNome_Sel = GetPar( "TFResponsavelNome_Sel");
         AV64TFResponsavelCPF = GetPar( "TFResponsavelCPF");
         AV65TFResponsavelCPF_Sel = GetPar( "TFResponsavelCPF_Sel");
         AV66TFResponsavelCelular_F = GetPar( "TFResponsavelCelular_F");
         AV67TFResponsavelCelular_F_Sel = GetPar( "TFResponsavelCelular_F_Sel");
         AV68TFResponsavelEmail = GetPar( "TFResponsavelEmail");
         AV69TFResponsavelEmail_Sel = GetPar( "TFResponsavelEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV71TFResponsavelCargo_Sels);
         AV72TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV73TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         AV74TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV75TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV80TFClienteSituacao_Sels);
         AV78TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV55DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV54DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
         PA982( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START982( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clienterepresentantesww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_197", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_197), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV59ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV59ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV85GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV81DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV81DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV28DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV41DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME", AV62TFResponsavelNome);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELNOME_SEL", AV63TFResponsavelNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCPF", AV64TFResponsavelCPF);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCPF_SEL", AV65TFResponsavelCPF_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCELULAR_F", AV66TFResponsavelCelular_F);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCELULAR_F_SEL", AV67TFResponsavelCelular_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL", AV68TFResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELEMAIL_SEL", AV69TFResponsavelEmail_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRESPONSAVELCARGO_SELS", AV71TFResponsavelCargo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRESPONSAVELCARGO_SELS", AV71TFResponsavelCargo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV72TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV73TFClienteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV74TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV75TFClienteRazaoSocial_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTESITUACAO_SELS", AV80TFClienteSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTESITUACAO_SELS", AV80TFClienteSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78TFClienteStatus_Sel), 1, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vTFRESPONSAVELCARGO_SELSJSON", AV70TFResponsavelCargo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESITUACAO_SELSJSON", AV79TFClienteSituacao_SelsJson);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95ClienteId_Selected), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Confirmtype));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UADELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Result));
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
            WE982( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT982( ) ;
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
         return formatLink("clienterepresentantesww")  ;
      }

      public override string GetPgmname( )
      {
         return "ClienteRepresentantesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cliente" ;
      }

      protected void WB980( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteRepresentantesWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_982( true) ;
         }
         else
         {
            wb_table1_47_982( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_982e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_96_982( true) ;
         }
         else
         {
            wb_table2_96_982( false) ;
         }
         return  ;
      }

      protected void wb_table2_96_982e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV42DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV42DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_145_982( true) ;
         }
         else
         {
            wb_table3_145_982( false) ;
         }
         return  ;
      }

      protected void wb_table3_145_982e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInvisiblefilter_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90TipoClienteId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTipoclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV90TipoClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV90TipoClienteId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,188);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclienteid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipoclienteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteRepresentantesWW.htm");
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
            StartGridControl197( ) ;
         }
         if ( wbEnd == 197 )
         {
            wbEnd = 0;
            nRC_GXsfl_197 = (int)(nGXsfl_197_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV83GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV84GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV85GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ClienteRepresentantesWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV81DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            wb_table4_223_982( true) ;
         }
         else
         {
            wb_table4_223_982( false) ;
         }
         return  ;
      }

      protected void wb_table4_223_982e( bool wbgen )
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
         if ( wbEnd == 197 )
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

      protected void START982( )
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
         STRUP980( ) ;
      }

      protected void WS982( )
      {
         START982( ) ;
         EVT982( ) ;
      }

      protected void EVT982( )
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
                              E11982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UADELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_uadelete.Close */
                              E15982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E16982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E17982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E18982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E19982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E20982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E21982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25982 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26982 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VUASEARCH.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VUAUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VUASEARCH.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VUAUPDATE.CLICK") == 0 ) )
                           {
                              nGXsfl_197_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
                              SubsflControlProps_1972( ) ;
                              AV97UASearch = cgiGet( edtavUasearch_Internalname);
                              AssignAttri("", false, edtavUasearch_Internalname, AV97UASearch);
                              AV99UAUpdate = cgiGet( edtavUaupdate_Internalname);
                              AssignAttri("", false, edtavUaupdate_Internalname, AV99UAUpdate);
                              AV94UADelete = cgiGet( edtavUadelete_Internalname);
                              AssignAttri("", false, edtavUadelete_Internalname, AV94UADelete);
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
                                    E27982 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28982 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29982 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUASEARCH.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30982 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUAUPDATE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E31982 ();
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

      protected void WE982( )
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

      protected void PA982( )
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
         SubsflControlProps_1972( ) ;
         while ( nGXsfl_197_idx <= nRC_GXsfl_197 )
         {
            sendrow_1972( ) ;
            nGXsfl_197_idx = ((subGrid_Islastpage==1)&&(nGXsfl_197_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_197_idx+1);
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
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
                                       string AV100Pgmname ,
                                       short AV90TipoClienteId ,
                                       string AV62TFResponsavelNome ,
                                       string AV63TFResponsavelNome_Sel ,
                                       string AV64TFResponsavelCPF ,
                                       string AV65TFResponsavelCPF_Sel ,
                                       string AV66TFResponsavelCelular_F ,
                                       string AV67TFResponsavelCelular_F_Sel ,
                                       string AV68TFResponsavelEmail ,
                                       string AV69TFResponsavelEmail_Sel ,
                                       GxSimpleCollection<string> AV71TFResponsavelCargo_Sels ,
                                       string AV72TFClienteDocumento ,
                                       string AV73TFClienteDocumento_Sel ,
                                       string AV74TFClienteRazaoSocial ,
                                       string AV75TFClienteRazaoSocial_Sel ,
                                       GxSimpleCollection<string> AV80TFClienteSituacao_Sels ,
                                       short AV78TFClienteStatus_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV55DynamicFiltersIgnoreFirst ,
                                       bool AV54DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF982( ) ;
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
         RF982( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV100Pgmname = "ClienteRepresentantesWW";
         edtavUasearch_Enabled = 0;
         edtavUaupdate_Enabled = 0;
         edtavUadelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV71TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV80TFClienteSituacao_Sels ,
                                              AV16DynamicFiltersSelector1 ,
                                              AV17DynamicFiltersOperator1 ,
                                              AV18ClienteDocumento1 ,
                                              AV19TipoClienteDescricao1 ,
                                              AV20ClienteConvenioDescricao1 ,
                                              AV21ClienteNacionalidadeNome1 ,
                                              AV22ClienteProfissaoNome1 ,
                                              AV23MunicipioNome1 ,
                                              AV24BancoCodigo1 ,
                                              AV25ResponsavelNacionalidadeNome1 ,
                                              AV26ResponsavelProfissaoNome1 ,
                                              AV27ResponsavelMunicipioNome1 ,
                                              AV28DynamicFiltersEnabled2 ,
                                              AV29DynamicFiltersSelector2 ,
                                              AV30DynamicFiltersOperator2 ,
                                              AV31ClienteDocumento2 ,
                                              AV32TipoClienteDescricao2 ,
                                              AV33ClienteConvenioDescricao2 ,
                                              AV34ClienteNacionalidadeNome2 ,
                                              AV35ClienteProfissaoNome2 ,
                                              AV36MunicipioNome2 ,
                                              AV37BancoCodigo2 ,
                                              AV38ResponsavelNacionalidadeNome2 ,
                                              AV39ResponsavelProfissaoNome2 ,
                                              AV40ResponsavelMunicipioNome2 ,
                                              AV41DynamicFiltersEnabled3 ,
                                              AV42DynamicFiltersSelector3 ,
                                              AV43DynamicFiltersOperator3 ,
                                              AV44ClienteDocumento3 ,
                                              AV45TipoClienteDescricao3 ,
                                              AV46ClienteConvenioDescricao3 ,
                                              AV47ClienteNacionalidadeNome3 ,
                                              AV48ClienteProfissaoNome3 ,
                                              AV49MunicipioNome3 ,
                                              AV50BancoCodigo3 ,
                                              AV51ResponsavelNacionalidadeNome3 ,
                                              AV52ResponsavelProfissaoNome3 ,
                                              AV53ResponsavelMunicipioNome3 ,
                                              AV63TFResponsavelNome_Sel ,
                                              AV62TFResponsavelNome ,
                                              AV65TFResponsavelCPF_Sel ,
                                              AV64TFResponsavelCPF ,
                                              AV69TFResponsavelEmail_Sel ,
                                              AV68TFResponsavelEmail ,
                                              AV71TFResponsavelCargo_Sels.Count ,
                                              AV73TFClienteDocumento_Sel ,
                                              AV72TFClienteDocumento ,
                                              AV75TFClienteRazaoSocial_Sel ,
                                              AV74TFClienteRazaoSocial ,
                                              AV80TFClienteSituacao_Sels.Count ,
                                              AV78TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV15FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              A192TipoClienteId ,
                                              AV67TFResponsavelCelular_F_Sel ,
                                              AV66TFResponsavelCelular_F } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV18ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV18ClienteDocumento1), "%", "");
         lV18ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV18ClienteDocumento1), "%", "");
         lV19TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV19TipoClienteDescricao1), "%", "");
         lV19TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV19TipoClienteDescricao1), "%", "");
         lV20ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV20ClienteConvenioDescricao1), "%", "");
         lV20ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV20ClienteConvenioDescricao1), "%", "");
         lV21ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteNacionalidadeNome1), "%", "");
         lV21ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteNacionalidadeNome1), "%", "");
         lV22ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV22ClienteProfissaoNome1), "%", "");
         lV22ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV22ClienteProfissaoNome1), "%", "");
         lV23MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV23MunicipioNome1), "%", "");
         lV23MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV23MunicipioNome1), "%", "");
         lV25ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1), "%", "");
         lV25ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1), "%", "");
         lV26ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV26ResponsavelProfissaoNome1), "%", "");
         lV26ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV26ResponsavelProfissaoNome1), "%", "");
         lV27ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ResponsavelMunicipioNome1), "%", "");
         lV27ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ResponsavelMunicipioNome1), "%", "");
         lV31ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV31ClienteDocumento2), "%", "");
         lV31ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV31ClienteDocumento2), "%", "");
         lV32TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV32TipoClienteDescricao2), "%", "");
         lV32TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV32TipoClienteDescricao2), "%", "");
         lV33ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV33ClienteConvenioDescricao2), "%", "");
         lV33ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV33ClienteConvenioDescricao2), "%", "");
         lV34ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteNacionalidadeNome2), "%", "");
         lV34ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteNacionalidadeNome2), "%", "");
         lV35ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV35ClienteProfissaoNome2), "%", "");
         lV35ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV35ClienteProfissaoNome2), "%", "");
         lV36MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV36MunicipioNome2), "%", "");
         lV36MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV36MunicipioNome2), "%", "");
         lV38ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2), "%", "");
         lV38ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2), "%", "");
         lV39ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome2), "%", "");
         lV39ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome2), "%", "");
         lV40ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV40ResponsavelMunicipioNome2), "%", "");
         lV40ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV40ResponsavelMunicipioNome2), "%", "");
         lV44ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV44ClienteDocumento3), "%", "");
         lV44ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV44ClienteDocumento3), "%", "");
         lV45TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV45TipoClienteDescricao3), "%", "");
         lV45TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV45TipoClienteDescricao3), "%", "");
         lV46ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV46ClienteConvenioDescricao3), "%", "");
         lV46ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV46ClienteConvenioDescricao3), "%", "");
         lV47ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteNacionalidadeNome3), "%", "");
         lV47ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteNacionalidadeNome3), "%", "");
         lV48ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteProfissaoNome3), "%", "");
         lV48ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteProfissaoNome3), "%", "");
         lV49MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV49MunicipioNome3), "%", "");
         lV49MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV49MunicipioNome3), "%", "");
         lV51ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3), "%", "");
         lV51ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3), "%", "");
         lV52ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV52ResponsavelProfissaoNome3), "%", "");
         lV52ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV52ResponsavelProfissaoNome3), "%", "");
         lV53ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV53ResponsavelMunicipioNome3), "%", "");
         lV53ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV53ResponsavelMunicipioNome3), "%", "");
         lV62TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV62TFResponsavelNome), "%", "");
         lV64TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV64TFResponsavelCPF), "%", "");
         lV68TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV68TFResponsavelEmail), "%", "");
         lV72TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV72TFClienteDocumento), "%", "");
         lV74TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV74TFClienteRazaoSocial), "%", "");
         /* Using cursor H00982 */
         pr_default.execute(0, new Object[] {lV18ClienteDocumento1, lV18ClienteDocumento1, lV19TipoClienteDescricao1, lV19TipoClienteDescricao1, lV20ClienteConvenioDescricao1, lV20ClienteConvenioDescricao1, lV21ClienteNacionalidadeNome1, lV21ClienteNacionalidadeNome1, lV22ClienteProfissaoNome1, lV22ClienteProfissaoNome1, lV23MunicipioNome1, lV23MunicipioNome1, AV24BancoCodigo1, AV24BancoCodigo1, AV24BancoCodigo1, lV25ResponsavelNacionalidadeNome1, lV25ResponsavelNacionalidadeNome1, lV26ResponsavelProfissaoNome1, lV26ResponsavelProfissaoNome1, lV27ResponsavelMunicipioNome1, lV27ResponsavelMunicipioNome1, lV31ClienteDocumento2, lV31ClienteDocumento2, lV32TipoClienteDescricao2, lV32TipoClienteDescricao2, lV33ClienteConvenioDescricao2, lV33ClienteConvenioDescricao2, lV34ClienteNacionalidadeNome2, lV34ClienteNacionalidadeNome2, lV35ClienteProfissaoNome2, lV35ClienteProfissaoNome2, lV36MunicipioNome2, lV36MunicipioNome2, AV37BancoCodigo2, AV37BancoCodigo2, AV37BancoCodigo2, lV38ResponsavelNacionalidadeNome2, lV38ResponsavelNacionalidadeNome2, lV39ResponsavelProfissaoNome2, lV39ResponsavelProfissaoNome2, lV40ResponsavelMunicipioNome2, lV40ResponsavelMunicipioNome2, lV44ClienteDocumento3, lV44ClienteDocumento3, lV45TipoClienteDescricao3, lV45TipoClienteDescricao3, lV46ClienteConvenioDescricao3, lV46ClienteConvenioDescricao3, lV47ClienteNacionalidadeNome3, lV47ClienteNacionalidadeNome3, lV48ClienteProfissaoNome3, lV48ClienteProfissaoNome3, lV49MunicipioNome3, lV49MunicipioNome3, AV50BancoCodigo3, AV50BancoCodigo3, AV50BancoCodigo3, lV51ResponsavelNacionalidadeNome3, lV51ResponsavelNacionalidadeNome3, lV52ResponsavelProfissaoNome3, lV52ResponsavelProfissaoNome3, lV53ResponsavelMunicipioNome3, lV53ResponsavelMunicipioNome3, lV62TFResponsavelNome, AV63TFResponsavelNome_Sel, lV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, lV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, lV72TFClienteDocumento, AV73TFClienteDocumento_Sel, lV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A186MunicipioCodigo = H00982_A186MunicipioCodigo[0];
            n186MunicipioCodigo = H00982_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = H00982_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = H00982_n444ResponsavelMunicipio[0];
            A402BancoId = H00982_A402BancoId[0];
            n402BancoId = H00982_n402BancoId[0];
            A437ResponsavelNacionalidade = H00982_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = H00982_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = H00982_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = H00982_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = H00982_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = H00982_n442ResponsavelProfissao[0];
            A487ClienteProfissao = H00982_A487ClienteProfissao[0];
            n487ClienteProfissao = H00982_n487ClienteProfissao[0];
            A489ClienteConvenio = H00982_A489ClienteConvenio[0];
            n489ClienteConvenio = H00982_n489ClienteConvenio[0];
            A445ResponsavelMunicipioNome = H00982_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = H00982_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = H00982_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = H00982_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = H00982_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = H00982_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = H00982_A404BancoCodigo[0];
            n404BancoCodigo = H00982_n404BancoCodigo[0];
            A187MunicipioNome = H00982_A187MunicipioNome[0];
            n187MunicipioNome = H00982_n187MunicipioNome[0];
            A488ClienteProfissaoNome = H00982_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = H00982_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = H00982_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = H00982_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = H00982_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = H00982_n490ClienteConvenioDescricao[0];
            A192TipoClienteId = H00982_A192TipoClienteId[0];
            n192TipoClienteId = H00982_n192TipoClienteId[0];
            A174ClienteStatus = H00982_A174ClienteStatus[0];
            n174ClienteStatus = H00982_n174ClienteStatus[0];
            A884ClienteSituacao = H00982_A884ClienteSituacao[0];
            n884ClienteSituacao = H00982_n884ClienteSituacao[0];
            A193TipoClienteDescricao = H00982_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H00982_n193TipoClienteDescricao[0];
            A172ClienteTipoPessoa = H00982_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H00982_n172ClienteTipoPessoa[0];
            A171ClienteNomeFantasia = H00982_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H00982_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = H00982_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00982_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = H00982_A169ClienteDocumento[0];
            n169ClienteDocumento = H00982_n169ClienteDocumento[0];
            A885ResponsavelCargo = H00982_A885ResponsavelCargo[0];
            n885ResponsavelCargo = H00982_n885ResponsavelCargo[0];
            A456ResponsavelEmail = H00982_A456ResponsavelEmail[0];
            n456ResponsavelEmail = H00982_n456ResponsavelEmail[0];
            A447ResponsavelCPF = H00982_A447ResponsavelCPF[0];
            n447ResponsavelCPF = H00982_n447ResponsavelCPF[0];
            A436ResponsavelNome = H00982_A436ResponsavelNome[0];
            n436ResponsavelNome = H00982_n436ResponsavelNome[0];
            A168ClienteId = H00982_A168ClienteId[0];
            A455ResponsavelNumero = H00982_A455ResponsavelNumero[0];
            n455ResponsavelNumero = H00982_n455ResponsavelNumero[0];
            A454ResponsavelDDD = H00982_A454ResponsavelDDD[0];
            n454ResponsavelDDD = H00982_n454ResponsavelDDD[0];
            A187MunicipioNome = H00982_A187MunicipioNome[0];
            n187MunicipioNome = H00982_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = H00982_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = H00982_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = H00982_A404BancoCodigo[0];
            n404BancoCodigo = H00982_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = H00982_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = H00982_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = H00982_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = H00982_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = H00982_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = H00982_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = H00982_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = H00982_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = H00982_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = H00982_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = H00982_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H00982_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV15FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV66TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
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

      protected void RF982( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 197;
         /* Execute user event: Refresh */
         E28982 ();
         nGXsfl_197_idx = 1;
         sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
         SubsflControlProps_1972( ) ;
         bGXsfl_197_Refreshing = true;
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
            SubsflControlProps_1972( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A885ResponsavelCargo ,
                                                 AV71TFResponsavelCargo_Sels ,
                                                 A884ClienteSituacao ,
                                                 AV80TFClienteSituacao_Sels ,
                                                 AV16DynamicFiltersSelector1 ,
                                                 AV17DynamicFiltersOperator1 ,
                                                 AV18ClienteDocumento1 ,
                                                 AV19TipoClienteDescricao1 ,
                                                 AV20ClienteConvenioDescricao1 ,
                                                 AV21ClienteNacionalidadeNome1 ,
                                                 AV22ClienteProfissaoNome1 ,
                                                 AV23MunicipioNome1 ,
                                                 AV24BancoCodigo1 ,
                                                 AV25ResponsavelNacionalidadeNome1 ,
                                                 AV26ResponsavelProfissaoNome1 ,
                                                 AV27ResponsavelMunicipioNome1 ,
                                                 AV28DynamicFiltersEnabled2 ,
                                                 AV29DynamicFiltersSelector2 ,
                                                 AV30DynamicFiltersOperator2 ,
                                                 AV31ClienteDocumento2 ,
                                                 AV32TipoClienteDescricao2 ,
                                                 AV33ClienteConvenioDescricao2 ,
                                                 AV34ClienteNacionalidadeNome2 ,
                                                 AV35ClienteProfissaoNome2 ,
                                                 AV36MunicipioNome2 ,
                                                 AV37BancoCodigo2 ,
                                                 AV38ResponsavelNacionalidadeNome2 ,
                                                 AV39ResponsavelProfissaoNome2 ,
                                                 AV40ResponsavelMunicipioNome2 ,
                                                 AV41DynamicFiltersEnabled3 ,
                                                 AV42DynamicFiltersSelector3 ,
                                                 AV43DynamicFiltersOperator3 ,
                                                 AV44ClienteDocumento3 ,
                                                 AV45TipoClienteDescricao3 ,
                                                 AV46ClienteConvenioDescricao3 ,
                                                 AV47ClienteNacionalidadeNome3 ,
                                                 AV48ClienteProfissaoNome3 ,
                                                 AV49MunicipioNome3 ,
                                                 AV50BancoCodigo3 ,
                                                 AV51ResponsavelNacionalidadeNome3 ,
                                                 AV52ResponsavelProfissaoNome3 ,
                                                 AV53ResponsavelMunicipioNome3 ,
                                                 AV63TFResponsavelNome_Sel ,
                                                 AV62TFResponsavelNome ,
                                                 AV65TFResponsavelCPF_Sel ,
                                                 AV64TFResponsavelCPF ,
                                                 AV69TFResponsavelEmail_Sel ,
                                                 AV68TFResponsavelEmail ,
                                                 AV71TFResponsavelCargo_Sels.Count ,
                                                 AV73TFClienteDocumento_Sel ,
                                                 AV72TFClienteDocumento ,
                                                 AV75TFClienteRazaoSocial_Sel ,
                                                 AV74TFClienteRazaoSocial ,
                                                 AV80TFClienteSituacao_Sels.Count ,
                                                 AV78TFClienteStatus_Sel ,
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
                                                 A436ResponsavelNome ,
                                                 A447ResponsavelCPF ,
                                                 A456ResponsavelEmail ,
                                                 A170ClienteRazaoSocial ,
                                                 A174ClienteStatus ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV15FilterFullText ,
                                                 A577ResponsavelCelular_F ,
                                                 A192TipoClienteId ,
                                                 AV67TFResponsavelCelular_F_Sel ,
                                                 AV66TFResponsavelCelular_F } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV18ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV18ClienteDocumento1), "%", "");
            lV18ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV18ClienteDocumento1), "%", "");
            lV19TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV19TipoClienteDescricao1), "%", "");
            lV19TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV19TipoClienteDescricao1), "%", "");
            lV20ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV20ClienteConvenioDescricao1), "%", "");
            lV20ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV20ClienteConvenioDescricao1), "%", "");
            lV21ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteNacionalidadeNome1), "%", "");
            lV21ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteNacionalidadeNome1), "%", "");
            lV22ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV22ClienteProfissaoNome1), "%", "");
            lV22ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV22ClienteProfissaoNome1), "%", "");
            lV23MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV23MunicipioNome1), "%", "");
            lV23MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV23MunicipioNome1), "%", "");
            lV25ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1), "%", "");
            lV25ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1), "%", "");
            lV26ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV26ResponsavelProfissaoNome1), "%", "");
            lV26ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV26ResponsavelProfissaoNome1), "%", "");
            lV27ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ResponsavelMunicipioNome1), "%", "");
            lV27ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ResponsavelMunicipioNome1), "%", "");
            lV31ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV31ClienteDocumento2), "%", "");
            lV31ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV31ClienteDocumento2), "%", "");
            lV32TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV32TipoClienteDescricao2), "%", "");
            lV32TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV32TipoClienteDescricao2), "%", "");
            lV33ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV33ClienteConvenioDescricao2), "%", "");
            lV33ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV33ClienteConvenioDescricao2), "%", "");
            lV34ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteNacionalidadeNome2), "%", "");
            lV34ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteNacionalidadeNome2), "%", "");
            lV35ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV35ClienteProfissaoNome2), "%", "");
            lV35ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV35ClienteProfissaoNome2), "%", "");
            lV36MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV36MunicipioNome2), "%", "");
            lV36MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV36MunicipioNome2), "%", "");
            lV38ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2), "%", "");
            lV38ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2), "%", "");
            lV39ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome2), "%", "");
            lV39ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome2), "%", "");
            lV40ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV40ResponsavelMunicipioNome2), "%", "");
            lV40ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV40ResponsavelMunicipioNome2), "%", "");
            lV44ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV44ClienteDocumento3), "%", "");
            lV44ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV44ClienteDocumento3), "%", "");
            lV45TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV45TipoClienteDescricao3), "%", "");
            lV45TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV45TipoClienteDescricao3), "%", "");
            lV46ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV46ClienteConvenioDescricao3), "%", "");
            lV46ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV46ClienteConvenioDescricao3), "%", "");
            lV47ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteNacionalidadeNome3), "%", "");
            lV47ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteNacionalidadeNome3), "%", "");
            lV48ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteProfissaoNome3), "%", "");
            lV48ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteProfissaoNome3), "%", "");
            lV49MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV49MunicipioNome3), "%", "");
            lV49MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV49MunicipioNome3), "%", "");
            lV51ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3), "%", "");
            lV51ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3), "%", "");
            lV52ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV52ResponsavelProfissaoNome3), "%", "");
            lV52ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV52ResponsavelProfissaoNome3), "%", "");
            lV53ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV53ResponsavelMunicipioNome3), "%", "");
            lV53ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV53ResponsavelMunicipioNome3), "%", "");
            lV62TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV62TFResponsavelNome), "%", "");
            lV64TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV64TFResponsavelCPF), "%", "");
            lV68TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV68TFResponsavelEmail), "%", "");
            lV72TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV72TFClienteDocumento), "%", "");
            lV74TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV74TFClienteRazaoSocial), "%", "");
            /* Using cursor H00983 */
            pr_default.execute(1, new Object[] {lV18ClienteDocumento1, lV18ClienteDocumento1, lV19TipoClienteDescricao1, lV19TipoClienteDescricao1, lV20ClienteConvenioDescricao1, lV20ClienteConvenioDescricao1, lV21ClienteNacionalidadeNome1, lV21ClienteNacionalidadeNome1, lV22ClienteProfissaoNome1, lV22ClienteProfissaoNome1, lV23MunicipioNome1, lV23MunicipioNome1, AV24BancoCodigo1, AV24BancoCodigo1, AV24BancoCodigo1, lV25ResponsavelNacionalidadeNome1, lV25ResponsavelNacionalidadeNome1, lV26ResponsavelProfissaoNome1, lV26ResponsavelProfissaoNome1, lV27ResponsavelMunicipioNome1, lV27ResponsavelMunicipioNome1, lV31ClienteDocumento2, lV31ClienteDocumento2, lV32TipoClienteDescricao2, lV32TipoClienteDescricao2, lV33ClienteConvenioDescricao2, lV33ClienteConvenioDescricao2, lV34ClienteNacionalidadeNome2, lV34ClienteNacionalidadeNome2, lV35ClienteProfissaoNome2, lV35ClienteProfissaoNome2, lV36MunicipioNome2, lV36MunicipioNome2, AV37BancoCodigo2, AV37BancoCodigo2, AV37BancoCodigo2, lV38ResponsavelNacionalidadeNome2, lV38ResponsavelNacionalidadeNome2, lV39ResponsavelProfissaoNome2, lV39ResponsavelProfissaoNome2, lV40ResponsavelMunicipioNome2, lV40ResponsavelMunicipioNome2, lV44ClienteDocumento3, lV44ClienteDocumento3, lV45TipoClienteDescricao3, lV45TipoClienteDescricao3, lV46ClienteConvenioDescricao3, lV46ClienteConvenioDescricao3, lV47ClienteNacionalidadeNome3, lV47ClienteNacionalidadeNome3, lV48ClienteProfissaoNome3, lV48ClienteProfissaoNome3, lV49MunicipioNome3, lV49MunicipioNome3, AV50BancoCodigo3, AV50BancoCodigo3, AV50BancoCodigo3, lV51ResponsavelNacionalidadeNome3, lV51ResponsavelNacionalidadeNome3, lV52ResponsavelProfissaoNome3, lV52ResponsavelProfissaoNome3, lV53ResponsavelMunicipioNome3, lV53ResponsavelMunicipioNome3, lV62TFResponsavelNome, AV63TFResponsavelNome_Sel, lV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, lV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, lV72TFClienteDocumento, AV73TFClienteDocumento_Sel, lV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel});
            nGXsfl_197_idx = 1;
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A186MunicipioCodigo = H00983_A186MunicipioCodigo[0];
               n186MunicipioCodigo = H00983_n186MunicipioCodigo[0];
               A444ResponsavelMunicipio = H00983_A444ResponsavelMunicipio[0];
               n444ResponsavelMunicipio = H00983_n444ResponsavelMunicipio[0];
               A402BancoId = H00983_A402BancoId[0];
               n402BancoId = H00983_n402BancoId[0];
               A437ResponsavelNacionalidade = H00983_A437ResponsavelNacionalidade[0];
               n437ResponsavelNacionalidade = H00983_n437ResponsavelNacionalidade[0];
               A484ClienteNacionalidade = H00983_A484ClienteNacionalidade[0];
               n484ClienteNacionalidade = H00983_n484ClienteNacionalidade[0];
               A442ResponsavelProfissao = H00983_A442ResponsavelProfissao[0];
               n442ResponsavelProfissao = H00983_n442ResponsavelProfissao[0];
               A487ClienteProfissao = H00983_A487ClienteProfissao[0];
               n487ClienteProfissao = H00983_n487ClienteProfissao[0];
               A489ClienteConvenio = H00983_A489ClienteConvenio[0];
               n489ClienteConvenio = H00983_n489ClienteConvenio[0];
               A445ResponsavelMunicipioNome = H00983_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H00983_n445ResponsavelMunicipioNome[0];
               A443ResponsavelProfissaoNome = H00983_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H00983_n443ResponsavelProfissaoNome[0];
               A438ResponsavelNacionalidadeNome = H00983_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H00983_n438ResponsavelNacionalidadeNome[0];
               A404BancoCodigo = H00983_A404BancoCodigo[0];
               n404BancoCodigo = H00983_n404BancoCodigo[0];
               A187MunicipioNome = H00983_A187MunicipioNome[0];
               n187MunicipioNome = H00983_n187MunicipioNome[0];
               A488ClienteProfissaoNome = H00983_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H00983_n488ClienteProfissaoNome[0];
               A485ClienteNacionalidadeNome = H00983_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H00983_n485ClienteNacionalidadeNome[0];
               A490ClienteConvenioDescricao = H00983_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H00983_n490ClienteConvenioDescricao[0];
               A192TipoClienteId = H00983_A192TipoClienteId[0];
               n192TipoClienteId = H00983_n192TipoClienteId[0];
               A174ClienteStatus = H00983_A174ClienteStatus[0];
               n174ClienteStatus = H00983_n174ClienteStatus[0];
               A884ClienteSituacao = H00983_A884ClienteSituacao[0];
               n884ClienteSituacao = H00983_n884ClienteSituacao[0];
               A193TipoClienteDescricao = H00983_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00983_n193TipoClienteDescricao[0];
               A172ClienteTipoPessoa = H00983_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H00983_n172ClienteTipoPessoa[0];
               A171ClienteNomeFantasia = H00983_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H00983_n171ClienteNomeFantasia[0];
               A170ClienteRazaoSocial = H00983_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H00983_n170ClienteRazaoSocial[0];
               A169ClienteDocumento = H00983_A169ClienteDocumento[0];
               n169ClienteDocumento = H00983_n169ClienteDocumento[0];
               A885ResponsavelCargo = H00983_A885ResponsavelCargo[0];
               n885ResponsavelCargo = H00983_n885ResponsavelCargo[0];
               A456ResponsavelEmail = H00983_A456ResponsavelEmail[0];
               n456ResponsavelEmail = H00983_n456ResponsavelEmail[0];
               A447ResponsavelCPF = H00983_A447ResponsavelCPF[0];
               n447ResponsavelCPF = H00983_n447ResponsavelCPF[0];
               A436ResponsavelNome = H00983_A436ResponsavelNome[0];
               n436ResponsavelNome = H00983_n436ResponsavelNome[0];
               A168ClienteId = H00983_A168ClienteId[0];
               A455ResponsavelNumero = H00983_A455ResponsavelNumero[0];
               n455ResponsavelNumero = H00983_n455ResponsavelNumero[0];
               A454ResponsavelDDD = H00983_A454ResponsavelDDD[0];
               n454ResponsavelDDD = H00983_n454ResponsavelDDD[0];
               A187MunicipioNome = H00983_A187MunicipioNome[0];
               n187MunicipioNome = H00983_n187MunicipioNome[0];
               A445ResponsavelMunicipioNome = H00983_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H00983_n445ResponsavelMunicipioNome[0];
               A404BancoCodigo = H00983_A404BancoCodigo[0];
               n404BancoCodigo = H00983_n404BancoCodigo[0];
               A438ResponsavelNacionalidadeNome = H00983_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H00983_n438ResponsavelNacionalidadeNome[0];
               A485ClienteNacionalidadeNome = H00983_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H00983_n485ClienteNacionalidadeNome[0];
               A443ResponsavelProfissaoNome = H00983_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H00983_n443ResponsavelProfissaoNome[0];
               A488ClienteProfissaoNome = H00983_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H00983_n488ClienteProfissaoNome[0];
               A490ClienteConvenioDescricao = H00983_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H00983_n490ClienteConvenioDescricao[0];
               A193TipoClienteDescricao = H00983_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00983_n193TipoClienteDescricao[0];
               GXt_char1 = A577ResponsavelCelular_F;
               new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
               A577ResponsavelCelular_F = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
               ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
               ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
               ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
               ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV15FilterFullText , 150 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
               ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
               ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
               )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV66TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E29982 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 197;
            WB980( ) ;
         }
         bGXsfl_197_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes982( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_197_idx, GetSecureSignedToken( sGXsfl_197_idx, context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV100Pgmname = "ClienteRepresentantesWW";
         edtavUasearch_Enabled = 0;
         edtavUaupdate_Enabled = 0;
         edtavUadelete_Enabled = 0;
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

      protected void STRUP980( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27982 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV59ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV81DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_197 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_197"), ",", "."), 18, MidpointRounding.ToEven));
            AV83GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV84GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV85GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV95ClienteId_Selected = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEID_SELECTED"), ",", "."), 18, MidpointRounding.ToEven));
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
            Dvelop_confirmpanel_uadelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Title");
            Dvelop_confirmpanel_uadelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Confirmationtext");
            Dvelop_confirmpanel_uadelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_uadelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Nobuttoncaption");
            Dvelop_confirmpanel_uadelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_uadelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Yesbuttonposition");
            Dvelop_confirmpanel_uadelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Confirmtype");
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
            Dvelop_confirmpanel_uadelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UADELETE_Result");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOCLIENTEID");
               GX_FocusControl = edtavTipoclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV90TipoClienteId = 0;
               AssignAttri("", false, "AV90TipoClienteId", StringUtil.LTrimStr( (decimal)(AV90TipoClienteId), 4, 0));
            }
            else
            {
               AV90TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV90TipoClienteId", StringUtil.LTrimStr( (decimal)(AV90TipoClienteId), 4, 0));
            }
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
         E27982 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27982( )
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV81DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV81DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Form.Caption = "Representantes";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E28982( )
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
         AV83GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV83GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV83GridCurrentPage), 10, 0));
         AV84GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV84GridPageCount", StringUtil.LTrimStr( (decimal)(AV84GridPageCount), 10, 0));
         GXt_char1 = AV85GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV100Pgmname, out  GXt_char1) ;
         AV85GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV85GridAppliedFilters", AV85GridAppliedFilters);
         cmbClienteSituacao_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteSituacao_Internalname, "Columnheaderclass", cmbClienteSituacao_Columnheaderclass, !bGXsfl_197_Refreshing);
         cmbClienteStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteStatus_Internalname, "Columnheaderclass", cmbClienteStatus_Columnheaderclass, !bGXsfl_197_Refreshing);
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

      protected void E12982( )
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
            AV82PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV82PageToGo) ;
         }
      }

      protected void E13982( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14982( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelNome") == 0 )
            {
               AV62TFResponsavelNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFResponsavelNome", AV62TFResponsavelNome);
               AV63TFResponsavelNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFResponsavelNome_Sel", AV63TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCPF") == 0 )
            {
               AV64TFResponsavelCPF = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFResponsavelCPF", AV64TFResponsavelCPF);
               AV65TFResponsavelCPF_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFResponsavelCPF_Sel", AV65TFResponsavelCPF_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCelular_F") == 0 )
            {
               AV66TFResponsavelCelular_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFResponsavelCelular_F", AV66TFResponsavelCelular_F);
               AV67TFResponsavelCelular_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFResponsavelCelular_F_Sel", AV67TFResponsavelCelular_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelEmail") == 0 )
            {
               AV68TFResponsavelEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFResponsavelEmail", AV68TFResponsavelEmail);
               AV69TFResponsavelEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFResponsavelEmail_Sel", AV69TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResponsavelCargo") == 0 )
            {
               AV70TFResponsavelCargo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV70TFResponsavelCargo_SelsJson", AV70TFResponsavelCargo_SelsJson);
               AV71TFResponsavelCargo_Sels.FromJSonString(AV70TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV72TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV72TFClienteDocumento", AV72TFClienteDocumento);
               AV73TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFClienteDocumento_Sel", AV73TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV74TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFClienteRazaoSocial", AV74TFClienteRazaoSocial);
               AV75TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFClienteRazaoSocial_Sel", AV75TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteSituacao") == 0 )
            {
               AV79TFClienteSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV79TFClienteSituacao_SelsJson", AV79TFClienteSituacao_SelsJson);
               AV80TFClienteSituacao_Sels.FromJSonString(AV79TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteStatus") == 0 )
            {
               AV78TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV78TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV78TFClienteStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80TFClienteSituacao_Sels", AV80TFClienteSituacao_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV71TFResponsavelCargo_Sels", AV71TFResponsavelCargo_Sels);
      }

      private void E29982( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV97UASearch = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavUasearch_Internalname, AV97UASearch);
            AV99UAUpdate = "<i class=\"fa fa-pencil\"></i>";
            AssignAttri("", false, edtavUaupdate_Internalname, AV99UAUpdate);
            if ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 )
            {
               edtavUaupdate_Class = "Attribute";
            }
            else
            {
               edtavUaupdate_Class = "Invisible";
            }
            AV94UADelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavUadelete_Internalname, AV94UADelete);
            if ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 )
            {
               cmbClienteSituacao_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else if ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 )
            {
               cmbClienteSituacao_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 )
            {
               cmbClienteSituacao_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
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
               wbStart = 197;
            }
            sendrow_1972( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_197_Refreshing )
         {
            DoAjaxLoad(197, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E22982( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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

      protected void E16982( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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

      protected void E23982( )
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

      protected void E24982( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV41DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV41DynamicFiltersEnabled3", AV41DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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

      protected void E17982( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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

      protected void E25982( )
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

      protected void E18982( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
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

      protected void E26982( )
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

      protected void E11982( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ClienteRepresentantesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV100Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ClienteRepresentantesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV61ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV61ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV61ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV60ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ClienteRepresentantesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV60ManageFiltersXml = GXt_char1;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV60ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV71TFResponsavelCargo_Sels", AV71TFResponsavelCargo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80TFClienteSituacao_Sels", AV80TFClienteSituacao_Sels);
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

      protected void E15982( )
      {
         /* Dvelop_confirmpanel_uadelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uadelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO UADELETE' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
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

      protected void E19982( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         AV91Previous = "";
         AV92Current = "";
         AV93GoInBack = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wzcadastrorepresentante"+UrlEncode(StringUtil.RTrim(AV91Previous)) + "," + UrlEncode(StringUtil.RTrim(AV92Current)) + "," + UrlEncode(StringUtil.BoolToStr(AV93GoInBack));
         CallWebObject(formatLink("wzcadastrorepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E20982( )
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
         new clienterepresentanteswwexport(context ).execute( out  AV56ExcelFilename, out  AV57ErrorMessage) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80TFClienteSituacao_Sels", AV80TFClienteSituacao_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV71TFResponsavelCargo_Sels", AV71TFResponsavelCargo_Sels);
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

      protected void E21982( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("clienterepresentanteswwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80TFClienteSituacao_Sels", AV80TFClienteSituacao_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV71TFResponsavelCargo_Sels", AV71TFResponsavelCargo_Sels);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ClienteRepresentantesWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV59ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV90TipoClienteId = 0;
         AssignAttri("", false, "AV90TipoClienteId", StringUtil.LTrimStr( (decimal)(AV90TipoClienteId), 4, 0));
         AV62TFResponsavelNome = "";
         AssignAttri("", false, "AV62TFResponsavelNome", AV62TFResponsavelNome);
         AV63TFResponsavelNome_Sel = "";
         AssignAttri("", false, "AV63TFResponsavelNome_Sel", AV63TFResponsavelNome_Sel);
         AV64TFResponsavelCPF = "";
         AssignAttri("", false, "AV64TFResponsavelCPF", AV64TFResponsavelCPF);
         AV65TFResponsavelCPF_Sel = "";
         AssignAttri("", false, "AV65TFResponsavelCPF_Sel", AV65TFResponsavelCPF_Sel);
         AV66TFResponsavelCelular_F = "";
         AssignAttri("", false, "AV66TFResponsavelCelular_F", AV66TFResponsavelCelular_F);
         AV67TFResponsavelCelular_F_Sel = "";
         AssignAttri("", false, "AV67TFResponsavelCelular_F_Sel", AV67TFResponsavelCelular_F_Sel);
         AV68TFResponsavelEmail = "";
         AssignAttri("", false, "AV68TFResponsavelEmail", AV68TFResponsavelEmail);
         AV69TFResponsavelEmail_Sel = "";
         AssignAttri("", false, "AV69TFResponsavelEmail_Sel", AV69TFResponsavelEmail_Sel);
         AV71TFResponsavelCargo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV72TFClienteDocumento = "";
         AssignAttri("", false, "AV72TFClienteDocumento", AV72TFClienteDocumento);
         AV73TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV73TFClienteDocumento_Sel", AV73TFClienteDocumento_Sel);
         AV74TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV74TFClienteRazaoSocial", AV74TFClienteRazaoSocial);
         AV75TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV75TFClienteRazaoSocial_Sel", AV75TFClienteRazaoSocial_Sel);
         AV80TFClienteSituacao_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV78TFClienteStatus_Sel = 0;
         AssignAttri("", false, "AV78TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV78TFClienteStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
         /* 'DO UADELETE' Routine */
         returnInSub = false;
         GXt_SdtSdErro4 = AV96SdErro;
         new prdeletarepresentante(context ).execute(  AV95ClienteId_Selected, out  GXt_SdtSdErro4) ;
         AV96SdErro = GXt_SdtSdErro4;
         if ( AV96SdErro.gxTpr_Status != 204 )
         {
            context.RollbackDataStores("clienterepresentantesww",pr_default);
            GX_msglist.addItem(StringUtil.Trim( AV96SdErro.gxTpr_Msg));
         }
         else
         {
            context.CommitDataStores("clienterepresentantesww",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV20ClienteConvenioDescricao1, AV21ClienteNacionalidadeNome1, AV22ClienteProfissaoNome1, AV23MunicipioNome1, AV24BancoCodigo1, AV25ResponsavelNacionalidadeNome1, AV26ResponsavelProfissaoNome1, AV27ResponsavelMunicipioNome1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31ClienteDocumento2, AV32TipoClienteDescricao2, AV33ClienteConvenioDescricao2, AV34ClienteNacionalidadeNome2, AV35ClienteProfissaoNome2, AV36MunicipioNome2, AV37BancoCodigo2, AV38ResponsavelNacionalidadeNome2, AV39ResponsavelProfissaoNome2, AV40ResponsavelMunicipioNome2, AV42DynamicFiltersSelector3, AV43DynamicFiltersOperator3, AV44ClienteDocumento3, AV45TipoClienteDescricao3, AV46ClienteConvenioDescricao3, AV47ClienteNacionalidadeNome3, AV48ClienteProfissaoNome3, AV49MunicipioNome3, AV50BancoCodigo3, AV51ResponsavelNacionalidadeNome3, AV52ResponsavelProfissaoNome3, AV53ResponsavelMunicipioNome3, AV61ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV41DynamicFiltersEnabled3, AV100Pgmname, AV90TipoClienteId, AV62TFResponsavelNome, AV63TFResponsavelNome_Sel, AV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, AV66TFResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel, AV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, AV71TFResponsavelCargo_Sels, AV72TFClienteDocumento, AV73TFClienteDocumento_Sel, AV74TFClienteRazaoSocial, AV75TFClienteRazaoSocial_Sel, AV80TFClienteSituacao_Sels, AV78TFClienteStatus_Sel, AV10GridState, AV55DynamicFiltersIgnoreFirst, AV54DynamicFiltersRemoving) ;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV58Session.Get(AV100Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV100Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV58Session.Get(AV100Pgmname+"GridState"), null, "", "");
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
         AV101GXV1 = 1;
         while ( AV101GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV101GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV90TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV90TipoClienteId", StringUtil.LTrimStr( (decimal)(AV90TipoClienteId), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV62TFResponsavelNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFResponsavelNome", AV62TFResponsavelNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV63TFResponsavelNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFResponsavelNome_Sel", AV63TFResponsavelNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV64TFResponsavelCPF = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFResponsavelCPF", AV64TFResponsavelCPF);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV65TFResponsavelCPF_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFResponsavelCPF_Sel", AV65TFResponsavelCPF_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV66TFResponsavelCelular_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFResponsavelCelular_F", AV66TFResponsavelCelular_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV67TFResponsavelCelular_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFResponsavelCelular_F_Sel", AV67TFResponsavelCelular_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV68TFResponsavelEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFResponsavelEmail", AV68TFResponsavelEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV69TFResponsavelEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFResponsavelEmail_Sel", AV69TFResponsavelEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV70TFResponsavelCargo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFResponsavelCargo_SelsJson", AV70TFResponsavelCargo_SelsJson);
               AV71TFResponsavelCargo_Sels.FromJSonString(AV70TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV72TFClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFClienteDocumento", AV72TFClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV73TFClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFClienteDocumento_Sel", AV73TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV74TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFClienteRazaoSocial", AV74TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV75TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFClienteRazaoSocial_Sel", AV75TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV79TFClienteSituacao_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFClienteSituacao_SelsJson", AV79TFClienteSituacao_SelsJson);
               AV80TFClienteSituacao_Sels.FromJSonString(AV79TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV78TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV78TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV78TFClienteStatus_Sel), 1, 0));
            }
            AV101GXV1 = (int)(AV101GXV1+1);
         }
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)),  AV63TFResponsavelNome_Sel, out  GXt_char1) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)),  AV65TFResponsavelCPF_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)),  AV67TFResponsavelCelular_F_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)),  AV69TFResponsavelEmail_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV71TFResponsavelCargo_Sels.Count==0),  AV70TFResponsavelCargo_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)),  AV73TFClienteDocumento_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)),  AV75TFClienteRazaoSocial_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV80TFClienteSituacao_Sels.Count==0),  AV79TFClienteSituacao_SelsJson, out  GXt_char11) ;
         Ddo_grid_Selectedvalue_set = GXt_char1+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+((0==AV78TFClienteStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV78TFClienteStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)),  AV62TFResponsavelNome, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)),  AV64TFResponsavelCPF, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)),  AV66TFResponsavelCelular_F, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)),  AV68TFResponsavelEmail, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFClienteDocumento)),  AV72TFClienteDocumento, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteRazaoSocial)),  AV74TFClienteRazaoSocial, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"||"+GXt_char7+"|"+GXt_char6+"||";
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
         AV10GridState.FromXml(AV58Session.Get(AV100Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TIPOCLIENTEID",  "Tipo Cliente Id",  !(0==AV90TipoClienteId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV90TipoClienteId), 4, 0)),  StringUtil.Trim( context.localUtil.Format( (decimal)(AV90TipoClienteId), "ZZZ9")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELNOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)),  0,  AV62TFResponsavelNome,  AV62TFResponsavelNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)),  AV63TFResponsavelNome_Sel,  AV63TFResponsavelNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCPF",  "CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)),  0,  AV64TFResponsavelCPF,  AV64TFResponsavelCPF,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)),  AV65TFResponsavelCPF_Sel,  AV65TFResponsavelCPF_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCELULAR_F",  "Celular",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)),  0,  AV66TFResponsavelCelular_F,  AV66TFResponsavelCelular_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)),  AV67TFResponsavelCelular_F_Sel,  AV67TFResponsavelCelular_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRESPONSAVELEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)),  0,  AV68TFResponsavelEmail,  AV68TFResponsavelEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)),  AV69TFResponsavelEmail_Sel,  AV69TFResponsavelEmail_Sel) ;
         AV89AuxText = ((AV71TFResponsavelCargo_Sels.Count==1) ? "["+((string)AV71TFResponsavelCargo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRESPONSAVELCARGO_SEL",  "Cargo",  !(AV71TFResponsavelCargo_Sels.Count==0),  0,  AV71TFResponsavelCargo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV89AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV89AuxText, "[DIRETOR]", "DIRETOR"), "[GERENTE]", "GERENTE"), "[COORDENADOR]", "COORDENADOR"), "[SUPERVISOR]", "SUPERVISOR"), "[ANALISTA]", "ANALISTA"), "[ASSISTENTE]", "ASSISTENTE"), "[ESTAGIARIO]", "ESTAGIARIO"), "[OUTRO]", "OUTRO")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTEDOCUMENTO",  "CNPJ",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFClienteDocumento)),  0,  AV72TFClienteDocumento,  AV72TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)),  AV73TFClienteDocumento_Sel,  AV73TFClienteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão Social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteRazaoSocial)),  0,  AV74TFClienteRazaoSocial,  AV74TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)),  AV75TFClienteRazaoSocial_Sel,  AV75TFClienteRazaoSocial_Sel) ;
         AV89AuxText = ((AV80TFClienteSituacao_Sels.Count==1) ? "["+AV80TFClienteSituacao_Sels.GetString(1)+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESITUACAO_SEL",  "Situação",  !(AV80TFClienteSituacao_Sels.Count==0),  0,  AV80TFClienteSituacao_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV89AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV89AuxText, "[P]", "Aguardando Análise"), "[A]", "Aprovado"), "[R]", "Rejeitado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESTATUS_SEL",  "Status",  !(0==AV78TFClienteStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV78TFClienteStatus_Sel), 1, 0)),  ((AV78TFClienteStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
         AV8TrnContext.gxTpr_Callerobject = AV100Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Cliente";
         AV58Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E30982( )
      {
         /* Uasearch_Click Routine */
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

      protected void E31982( )
      {
         /* Uaupdate_Click Routine */
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

      protected void wb_table4_223_982( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uadelete_Internalname, tblTabledvelop_confirmpanel_uadelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uadelete.SetProperty("Title", Dvelop_confirmpanel_uadelete_Title);
            ucDvelop_confirmpanel_uadelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_uadelete_Confirmationtext);
            ucDvelop_confirmpanel_uadelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uadelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uadelete_Nobuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uadelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uadelete_Yesbuttonposition);
            ucDvelop_confirmpanel_uadelete.SetProperty("ConfirmType", Dvelop_confirmpanel_uadelete_Confirmtype);
            ucDvelop_confirmpanel_uadelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uadelete_Internalname, "DVELOP_CONFIRMPANEL_UADELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UADELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_223_982e( true) ;
         }
         else
         {
            wb_table4_223_982e( false) ;
         }
      }

      protected void wb_table3_145_982( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV43DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento3_Internalname, AV44ClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV44ClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento3_Visible, edtavClientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao3_Internalname, "Tipo Cliente Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao3_Internalname, AV45TipoClienteDescricao3, StringUtil.RTrim( context.localUtil.Format( AV45TipoClienteDescricao3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao3_Visible, edtavTipoclientedescricao3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao3_Internalname, "Cliente Convenio Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao3_Internalname, AV46ClienteConvenioDescricao3, StringUtil.RTrim( context.localUtil.Format( AV46ClienteConvenioDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao3_Visible, edtavClienteconveniodescricao3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome3_Internalname, "Cliente Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome3_Internalname, AV47ClienteNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV47ClienteNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome3_Visible, edtavClientenacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome3_Internalname, "Cliente Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome3_Internalname, AV48ClienteProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV48ClienteProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome3_Visible, edtavClienteprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome3_Internalname, "Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome3_Internalname, AV49MunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV49MunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome3_Visible, edtavMunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo3_Internalname, "Banco Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50BancoCodigo3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV50BancoCodigo3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo3_Visible, edtavBancocodigo3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome3_Internalname, "Responsavel Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome3_Internalname, AV51ResponsavelNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV51ResponsavelNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome3_Visible, edtavResponsavelnacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome3_Internalname, "Responsavel Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome3_Internalname, AV52ResponsavelProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV52ResponsavelProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome3_Visible, edtavResponsavelprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome3_Internalname, "Responsavel Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome3_Internalname, AV53ResponsavelMunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV53ResponsavelMunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome3_Visible, edtavResponsavelmunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteRepresentantesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_145_982e( true) ;
         }
         else
         {
            wb_table3_145_982e( false) ;
         }
      }

      protected void wb_table2_96_982( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento2_Internalname, AV31ClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV31ClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento2_Visible, edtavClientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao2_Internalname, "Tipo Cliente Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao2_Internalname, AV32TipoClienteDescricao2, StringUtil.RTrim( context.localUtil.Format( AV32TipoClienteDescricao2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao2_Visible, edtavTipoclientedescricao2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao2_Internalname, "Cliente Convenio Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao2_Internalname, AV33ClienteConvenioDescricao2, StringUtil.RTrim( context.localUtil.Format( AV33ClienteConvenioDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao2_Visible, edtavClienteconveniodescricao2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome2_Internalname, "Cliente Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome2_Internalname, AV34ClienteNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV34ClienteNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome2_Visible, edtavClientenacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome2_Internalname, "Cliente Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome2_Internalname, AV35ClienteProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV35ClienteProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome2_Visible, edtavClienteprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome2_Internalname, "Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome2_Internalname, AV36MunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV36MunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome2_Visible, edtavMunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo2_Internalname, "Banco Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37BancoCodigo2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV37BancoCodigo2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo2_Visible, edtavBancocodigo2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome2_Internalname, "Responsavel Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome2_Internalname, AV38ResponsavelNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV38ResponsavelNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome2_Visible, edtavResponsavelnacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome2_Internalname, "Responsavel Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome2_Internalname, AV39ResponsavelProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV39ResponsavelProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome2_Visible, edtavResponsavelprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome2_Internalname, "Responsavel Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome2_Internalname, AV40ResponsavelMunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV40ResponsavelMunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome2_Visible, edtavResponsavelmunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteRepresentantesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteRepresentantesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_96_982e( true) ;
         }
         else
         {
            wb_table2_96_982e( false) ;
         }
      }

      protected void wb_table1_47_982( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_ClienteRepresentantesWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento1_Internalname, AV18ClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV18ClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento1_Visible, edtavClientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao1_Internalname, "Tipo Cliente Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao1_Internalname, AV19TipoClienteDescricao1, StringUtil.RTrim( context.localUtil.Format( AV19TipoClienteDescricao1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao1_Visible, edtavTipoclientedescricao1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao1_Internalname, "Cliente Convenio Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao1_Internalname, AV20ClienteConvenioDescricao1, StringUtil.RTrim( context.localUtil.Format( AV20ClienteConvenioDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao1_Visible, edtavClienteconveniodescricao1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome1_Internalname, "Cliente Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome1_Internalname, AV21ClienteNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV21ClienteNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome1_Visible, edtavClientenacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome1_Internalname, "Cliente Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome1_Internalname, AV22ClienteProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV22ClienteProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome1_Visible, edtavClienteprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome1_Internalname, "Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome1_Internalname, AV23MunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV23MunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome1_Visible, edtavMunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo1_Internalname, "Banco Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24BancoCodigo1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV24BancoCodigo1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo1_Visible, edtavBancocodigo1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome1_Internalname, "Responsavel Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome1_Internalname, AV25ResponsavelNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV25ResponsavelNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome1_Visible, edtavResponsavelnacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome1_Internalname, "Responsavel Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome1_Internalname, AV26ResponsavelProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV26ResponsavelProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome1_Visible, edtavResponsavelprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome1_Internalname, "Responsavel Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome1_Internalname, AV27ResponsavelMunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV27ResponsavelMunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome1_Visible, edtavResponsavelmunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteRepresentantesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteRepresentantesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteRepresentantesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_982e( true) ;
         }
         else
         {
            wb_table1_47_982e( false) ;
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
         PA982( ) ;
         WS982( ) ;
         WE982( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019283111", true, true);
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
         context.AddJavascriptSource("clienterepresentantesww.js", "?202561019283111", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1972( )
      {
         edtavUasearch_Internalname = "vUASEARCH_"+sGXsfl_197_idx;
         edtavUaupdate_Internalname = "vUAUPDATE_"+sGXsfl_197_idx;
         edtavUadelete_Internalname = "vUADELETE_"+sGXsfl_197_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_197_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_197_idx;
         edtResponsavelCPF_Internalname = "RESPONSAVELCPF_"+sGXsfl_197_idx;
         edtResponsavelCelular_F_Internalname = "RESPONSAVELCELULAR_F_"+sGXsfl_197_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_197_idx;
         cmbResponsavelCargo_Internalname = "RESPONSAVELCARGO_"+sGXsfl_197_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_197_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_197_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_197_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_197_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_197_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_197_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_197_idx;
      }

      protected void SubsflControlProps_fel_1972( )
      {
         edtavUasearch_Internalname = "vUASEARCH_"+sGXsfl_197_fel_idx;
         edtavUaupdate_Internalname = "vUAUPDATE_"+sGXsfl_197_fel_idx;
         edtavUadelete_Internalname = "vUADELETE_"+sGXsfl_197_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_197_fel_idx;
         edtResponsavelNome_Internalname = "RESPONSAVELNOME_"+sGXsfl_197_fel_idx;
         edtResponsavelCPF_Internalname = "RESPONSAVELCPF_"+sGXsfl_197_fel_idx;
         edtResponsavelCelular_F_Internalname = "RESPONSAVELCELULAR_F_"+sGXsfl_197_fel_idx;
         edtResponsavelEmail_Internalname = "RESPONSAVELEMAIL_"+sGXsfl_197_fel_idx;
         cmbResponsavelCargo_Internalname = "RESPONSAVELCARGO_"+sGXsfl_197_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_197_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_197_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_197_fel_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_197_fel_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_197_fel_idx;
         cmbClienteSituacao_Internalname = "CLIENTESITUACAO_"+sGXsfl_197_fel_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_197_fel_idx;
      }

      protected void sendrow_1972( )
      {
         sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
         SubsflControlProps_1972( ) ;
         WB980( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_197_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_197_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_197_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'" + sGXsfl_197_idx + "',197)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUasearch_Internalname,StringUtil.RTrim( AV97UASearch),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"","'"+""+"'"+",false,"+"'"+"EVUASEARCH.CLICK."+sGXsfl_197_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUasearch_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUasearch_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'" + sGXsfl_197_idx + "',197)\"";
            ROClassString = edtavUaupdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaupdate_Internalname,StringUtil.RTrim( AV99UAUpdate),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"","'"+""+"'"+",false,"+"'"+"EVUAUPDATE.CLICK."+sGXsfl_197_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUaupdate_Jsonclick,(short)5,(string)edtavUaupdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUaupdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'" + sGXsfl_197_idx + "',197)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUadelete_Internalname,StringUtil.RTrim( AV94UADelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,200);\"",(string)"'"+""+"'"+",false,"+"'"+"e32982_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUadelete_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUadelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelNome_Internalname,(string)A436ResponsavelNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelCPF_Internalname,(string)A447ResponsavelCPF,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelCelular_F_Internalname,(string)A577ResponsavelCelular_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsavelCelular_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsavelEmail_Internalname,(string)A456ResponsavelEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A456ResponsavelEmail,(string)"",(string)"",(string)"",(string)edtResponsavelEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbResponsavelCargo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESPONSAVELCARGO_" + sGXsfl_197_idx;
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
            AssignProp("", false, cmbResponsavelCargo_Internalname, "Values", (string)(cmbResponsavelCargo.ToJavascriptSource()), !bGXsfl_197_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbClienteTipoPessoa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_197_idx;
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
            AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", (string)(cmbClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_197_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteDescricao_Internalname,(string)A193TipoClienteDescricao,StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)197,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESITUACAO_" + sGXsfl_197_idx;
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
            AssignProp("", false, cmbClienteSituacao_Internalname, "Values", (string)(cmbClienteSituacao.ToJavascriptSource()), !bGXsfl_197_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESTATUS_" + sGXsfl_197_idx;
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
            AssignProp("", false, cmbClienteStatus_Internalname, "Values", (string)(cmbClienteStatus.ToJavascriptSource()), !bGXsfl_197_Refreshing);
            send_integrity_lvl_hashes982( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_197_idx = ((subGrid_Islastpage==1)&&(nGXsfl_197_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_197_idx+1);
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
         }
         /* End function sendrow_1972 */
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
         GXCCtl = "RESPONSAVELCARGO_" + sGXsfl_197_idx;
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
         GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_197_idx;
         cmbClienteTipoPessoa.Name = GXCCtl;
         cmbClienteTipoPessoa.WebTags = "";
         cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
         }
         GXCCtl = "CLIENTESITUACAO_" + sGXsfl_197_idx;
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
         GXCCtl = "CLIENTESTATUS_" + sGXsfl_197_idx;
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

      protected void StartGridControl197( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"197\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUaupdate_Class+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV97UASearch)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUasearch_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV99UAUpdate)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUaupdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUaupdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV94UADelete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUadelete_Enabled), 5, 0, ".", "")));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         bttBtnexportreport_Internalname = "BTNEXPORTREPORT";
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
         edtavTipoclienteid_Internalname = "vTIPOCLIENTEID";
         divInvisiblefilter_Internalname = "INVISIBLEFILTER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavUasearch_Internalname = "vUASEARCH";
         edtavUaupdate_Internalname = "vUAUPDATE";
         edtavUadelete_Internalname = "vUADELETE";
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
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Dvelop_confirmpanel_uadelete_Internalname = "DVELOP_CONFIRMPANEL_UADELETE";
         tblTabledvelop_confirmpanel_uadelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UADELETE";
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
         cmbResponsavelCargo_Jsonclick = "";
         edtResponsavelEmail_Jsonclick = "";
         edtResponsavelCelular_F_Jsonclick = "";
         edtResponsavelCPF_Jsonclick = "";
         edtResponsavelNome_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtavUadelete_Jsonclick = "";
         edtavUadelete_Enabled = 1;
         edtavUaupdate_Jsonclick = "";
         edtavUaupdate_Class = "Attribute";
         edtavUaupdate_Enabled = 1;
         edtavUasearch_Jsonclick = "";
         edtavUasearch_Enabled = 1;
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
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         edtavTipoclienteid_Jsonclick = "";
         edtavTipoclienteid_Enabled = 1;
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
         Grid_titlescategories_Gridtitlescategories = ";;;;Representante;Representante;Representante;Representante;Representante;Empresa;Empresa;;;;Status;Status";
         Dvelop_confirmpanel_uadelete_Confirmtype = "1";
         Dvelop_confirmpanel_uadelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uadelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uadelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uadelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uadelete_Confirmationtext = "Deseja excluir o representante selecionado ?";
         Dvelop_confirmpanel_uadelete_Title = "Excluir Representante";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "ClienteRepresentantesWWGetFilterData";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E29982","iparms":[{"av":"cmbClienteSituacao"},{"av":"A884ClienteSituacao","fld":"CLIENTESITUACAO","type":"char"},{"av":"cmbClienteStatus"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV97UASearch","fld":"vUASEARCH","type":"char"},{"av":"AV99UAUpdate","fld":"vUAUPDATE","type":"char"},{"av":"edtavUaupdate_Class","ctrl":"vUAUPDATE","prop":"Class"},{"av":"AV94UADelete","fld":"vUADELETE","type":"char"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E22982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E16982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E23982","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E24982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E17982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E25982","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E18982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E26982","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11982","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VUADELETE.CLICK","""{"handler":"E32982","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VUADELETE.CLICK",""","oparms":[{"av":"AV95ClienteId_Selected","fld":"vCLIENTEID_SELECTED","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UADELETE.CLOSE","""{"handler":"E15982","iparms":[{"av":"Dvelop_confirmpanel_uadelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UADELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV95ClienteId_Selected","fld":"vCLIENTEID_SELECTED","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UADELETE.CLOSE",""","oparms":[{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV85GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteSituacao"},{"av":"cmbClienteStatus"},{"av":"AV59ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E19982","iparms":[]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E20982","iparms":[{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E21982","iparms":[{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV21ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV22ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV23MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV24BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV26ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV27ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV32TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV33ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV34ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV35ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV36MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV37BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV39ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV40ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV42DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV43DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV45TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV46ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV47ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV48ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV49MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV50BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV52ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV53ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV61ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV100Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV90TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV62TFResponsavelNome","fld":"vTFRESPONSAVELNOME","type":"svchar"},{"av":"AV63TFResponsavelNome_Sel","fld":"vTFRESPONSAVELNOME_SEL","type":"svchar"},{"av":"AV64TFResponsavelCPF","fld":"vTFRESPONSAVELCPF","type":"svchar"},{"av":"AV65TFResponsavelCPF_Sel","fld":"vTFRESPONSAVELCPF_SEL","type":"svchar"},{"av":"AV66TFResponsavelCelular_F","fld":"vTFRESPONSAVELCELULAR_F","type":"svchar"},{"av":"AV67TFResponsavelCelular_F_Sel","fld":"vTFRESPONSAVELCELULAR_F_SEL","type":"svchar"},{"av":"AV68TFResponsavelEmail","fld":"vTFRESPONSAVELEMAIL","type":"svchar"},{"av":"AV69TFResponsavelEmail_Sel","fld":"vTFRESPONSAVELEMAIL_SEL","type":"svchar"},{"av":"AV71TFResponsavelCargo_Sels","fld":"vTFRESPONSAVELCARGO_SELS","type":""},{"av":"AV72TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV73TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV74TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV75TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV80TFClienteSituacao_Sels","fld":"vTFCLIENTESITUACAO_SELS","type":""},{"av":"AV78TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV55DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV54DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV79TFClienteSituacao_SelsJson","fld":"vTFCLIENTESITUACAO_SELSJSON","type":"vchar"},{"av":"AV70TFResponsavelCargo_SelsJson","fld":"vTFRESPONSAVELCARGO_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("VUASEARCH.CLICK","""{"handler":"E30982","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VUAUPDATE.CLICK","""{"handler":"E31982","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
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
         Dvelop_confirmpanel_uadelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
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
         AV100Pgmname = "";
         AV62TFResponsavelNome = "";
         AV63TFResponsavelNome_Sel = "";
         AV64TFResponsavelCPF = "";
         AV65TFResponsavelCPF_Sel = "";
         AV66TFResponsavelCelular_F = "";
         AV67TFResponsavelCelular_F_Sel = "";
         AV68TFResponsavelEmail = "";
         AV69TFResponsavelEmail_Sel = "";
         AV71TFResponsavelCargo_Sels = new GxSimpleCollection<string>();
         AV72TFClienteDocumento = "";
         AV73TFClienteDocumento_Sel = "";
         AV74TFClienteRazaoSocial = "";
         AV75TFClienteRazaoSocial_Sel = "";
         AV80TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV59ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85GridAppliedFilters = "";
         AV81DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV70TFResponsavelCargo_SelsJson = "";
         AV79TFClienteSituacao_SelsJson = "";
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
         bttBtninsert_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         bttBtnexportreport_Jsonclick = "";
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
         ucInnewwindow1 = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV97UASearch = "";
         AV99UAUpdate = "";
         AV94UADelete = "";
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
         lV15FilterFullText = "";
         lV18ClienteDocumento1 = "";
         lV19TipoClienteDescricao1 = "";
         lV20ClienteConvenioDescricao1 = "";
         lV21ClienteNacionalidadeNome1 = "";
         lV22ClienteProfissaoNome1 = "";
         lV23MunicipioNome1 = "";
         lV25ResponsavelNacionalidadeNome1 = "";
         lV26ResponsavelProfissaoNome1 = "";
         lV27ResponsavelMunicipioNome1 = "";
         lV31ClienteDocumento2 = "";
         lV32TipoClienteDescricao2 = "";
         lV33ClienteConvenioDescricao2 = "";
         lV34ClienteNacionalidadeNome2 = "";
         lV35ClienteProfissaoNome2 = "";
         lV36MunicipioNome2 = "";
         lV38ResponsavelNacionalidadeNome2 = "";
         lV39ResponsavelProfissaoNome2 = "";
         lV40ResponsavelMunicipioNome2 = "";
         lV44ClienteDocumento3 = "";
         lV45TipoClienteDescricao3 = "";
         lV46ClienteConvenioDescricao3 = "";
         lV47ClienteNacionalidadeNome3 = "";
         lV48ClienteProfissaoNome3 = "";
         lV49MunicipioNome3 = "";
         lV51ResponsavelNacionalidadeNome3 = "";
         lV52ResponsavelProfissaoNome3 = "";
         lV53ResponsavelMunicipioNome3 = "";
         lV62TFResponsavelNome = "";
         lV64TFResponsavelCPF = "";
         lV68TFResponsavelEmail = "";
         lV72TFClienteDocumento = "";
         lV74TFClienteRazaoSocial = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         H00982_A186MunicipioCodigo = new string[] {""} ;
         H00982_n186MunicipioCodigo = new bool[] {false} ;
         H00982_A444ResponsavelMunicipio = new string[] {""} ;
         H00982_n444ResponsavelMunicipio = new bool[] {false} ;
         H00982_A402BancoId = new int[1] ;
         H00982_n402BancoId = new bool[] {false} ;
         H00982_A437ResponsavelNacionalidade = new int[1] ;
         H00982_n437ResponsavelNacionalidade = new bool[] {false} ;
         H00982_A484ClienteNacionalidade = new int[1] ;
         H00982_n484ClienteNacionalidade = new bool[] {false} ;
         H00982_A442ResponsavelProfissao = new int[1] ;
         H00982_n442ResponsavelProfissao = new bool[] {false} ;
         H00982_A487ClienteProfissao = new int[1] ;
         H00982_n487ClienteProfissao = new bool[] {false} ;
         H00982_A489ClienteConvenio = new int[1] ;
         H00982_n489ClienteConvenio = new bool[] {false} ;
         H00982_A445ResponsavelMunicipioNome = new string[] {""} ;
         H00982_n445ResponsavelMunicipioNome = new bool[] {false} ;
         H00982_A443ResponsavelProfissaoNome = new string[] {""} ;
         H00982_n443ResponsavelProfissaoNome = new bool[] {false} ;
         H00982_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         H00982_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         H00982_A404BancoCodigo = new int[1] ;
         H00982_n404BancoCodigo = new bool[] {false} ;
         H00982_A187MunicipioNome = new string[] {""} ;
         H00982_n187MunicipioNome = new bool[] {false} ;
         H00982_A488ClienteProfissaoNome = new string[] {""} ;
         H00982_n488ClienteProfissaoNome = new bool[] {false} ;
         H00982_A485ClienteNacionalidadeNome = new string[] {""} ;
         H00982_n485ClienteNacionalidadeNome = new bool[] {false} ;
         H00982_A490ClienteConvenioDescricao = new string[] {""} ;
         H00982_n490ClienteConvenioDescricao = new bool[] {false} ;
         H00982_A192TipoClienteId = new short[1] ;
         H00982_n192TipoClienteId = new bool[] {false} ;
         H00982_A174ClienteStatus = new bool[] {false} ;
         H00982_n174ClienteStatus = new bool[] {false} ;
         H00982_A884ClienteSituacao = new string[] {""} ;
         H00982_n884ClienteSituacao = new bool[] {false} ;
         H00982_A193TipoClienteDescricao = new string[] {""} ;
         H00982_n193TipoClienteDescricao = new bool[] {false} ;
         H00982_A172ClienteTipoPessoa = new string[] {""} ;
         H00982_n172ClienteTipoPessoa = new bool[] {false} ;
         H00982_A171ClienteNomeFantasia = new string[] {""} ;
         H00982_n171ClienteNomeFantasia = new bool[] {false} ;
         H00982_A170ClienteRazaoSocial = new string[] {""} ;
         H00982_n170ClienteRazaoSocial = new bool[] {false} ;
         H00982_A169ClienteDocumento = new string[] {""} ;
         H00982_n169ClienteDocumento = new bool[] {false} ;
         H00982_A885ResponsavelCargo = new string[] {""} ;
         H00982_n885ResponsavelCargo = new bool[] {false} ;
         H00982_A456ResponsavelEmail = new string[] {""} ;
         H00982_n456ResponsavelEmail = new bool[] {false} ;
         H00982_A447ResponsavelCPF = new string[] {""} ;
         H00982_n447ResponsavelCPF = new bool[] {false} ;
         H00982_A436ResponsavelNome = new string[] {""} ;
         H00982_n436ResponsavelNome = new bool[] {false} ;
         H00982_A168ClienteId = new int[1] ;
         H00982_A455ResponsavelNumero = new int[1] ;
         H00982_n455ResponsavelNumero = new bool[] {false} ;
         H00982_A454ResponsavelDDD = new short[1] ;
         H00982_n454ResponsavelDDD = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         H00983_A186MunicipioCodigo = new string[] {""} ;
         H00983_n186MunicipioCodigo = new bool[] {false} ;
         H00983_A444ResponsavelMunicipio = new string[] {""} ;
         H00983_n444ResponsavelMunicipio = new bool[] {false} ;
         H00983_A402BancoId = new int[1] ;
         H00983_n402BancoId = new bool[] {false} ;
         H00983_A437ResponsavelNacionalidade = new int[1] ;
         H00983_n437ResponsavelNacionalidade = new bool[] {false} ;
         H00983_A484ClienteNacionalidade = new int[1] ;
         H00983_n484ClienteNacionalidade = new bool[] {false} ;
         H00983_A442ResponsavelProfissao = new int[1] ;
         H00983_n442ResponsavelProfissao = new bool[] {false} ;
         H00983_A487ClienteProfissao = new int[1] ;
         H00983_n487ClienteProfissao = new bool[] {false} ;
         H00983_A489ClienteConvenio = new int[1] ;
         H00983_n489ClienteConvenio = new bool[] {false} ;
         H00983_A445ResponsavelMunicipioNome = new string[] {""} ;
         H00983_n445ResponsavelMunicipioNome = new bool[] {false} ;
         H00983_A443ResponsavelProfissaoNome = new string[] {""} ;
         H00983_n443ResponsavelProfissaoNome = new bool[] {false} ;
         H00983_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         H00983_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         H00983_A404BancoCodigo = new int[1] ;
         H00983_n404BancoCodigo = new bool[] {false} ;
         H00983_A187MunicipioNome = new string[] {""} ;
         H00983_n187MunicipioNome = new bool[] {false} ;
         H00983_A488ClienteProfissaoNome = new string[] {""} ;
         H00983_n488ClienteProfissaoNome = new bool[] {false} ;
         H00983_A485ClienteNacionalidadeNome = new string[] {""} ;
         H00983_n485ClienteNacionalidadeNome = new bool[] {false} ;
         H00983_A490ClienteConvenioDescricao = new string[] {""} ;
         H00983_n490ClienteConvenioDescricao = new bool[] {false} ;
         H00983_A192TipoClienteId = new short[1] ;
         H00983_n192TipoClienteId = new bool[] {false} ;
         H00983_A174ClienteStatus = new bool[] {false} ;
         H00983_n174ClienteStatus = new bool[] {false} ;
         H00983_A884ClienteSituacao = new string[] {""} ;
         H00983_n884ClienteSituacao = new bool[] {false} ;
         H00983_A193TipoClienteDescricao = new string[] {""} ;
         H00983_n193TipoClienteDescricao = new bool[] {false} ;
         H00983_A172ClienteTipoPessoa = new string[] {""} ;
         H00983_n172ClienteTipoPessoa = new bool[] {false} ;
         H00983_A171ClienteNomeFantasia = new string[] {""} ;
         H00983_n171ClienteNomeFantasia = new bool[] {false} ;
         H00983_A170ClienteRazaoSocial = new string[] {""} ;
         H00983_n170ClienteRazaoSocial = new bool[] {false} ;
         H00983_A169ClienteDocumento = new string[] {""} ;
         H00983_n169ClienteDocumento = new bool[] {false} ;
         H00983_A885ResponsavelCargo = new string[] {""} ;
         H00983_n885ResponsavelCargo = new bool[] {false} ;
         H00983_A456ResponsavelEmail = new string[] {""} ;
         H00983_n456ResponsavelEmail = new bool[] {false} ;
         H00983_A447ResponsavelCPF = new string[] {""} ;
         H00983_n447ResponsavelCPF = new bool[] {false} ;
         H00983_A436ResponsavelNome = new string[] {""} ;
         H00983_n436ResponsavelNome = new bool[] {false} ;
         H00983_A168ClienteId = new int[1] ;
         H00983_A455ResponsavelNumero = new int[1] ;
         H00983_n455ResponsavelNumero = new bool[] {false} ;
         H00983_A454ResponsavelDDD = new short[1] ;
         H00983_n454ResponsavelDDD = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV60ManageFiltersXml = "";
         AV91Previous = "";
         AV92Current = "";
         AV56ExcelFilename = "";
         AV57ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV96SdErro = new SdtSdErro(context);
         GXt_SdtSdErro4 = new SdtSdErro(context);
         AV58Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char1 = "";
         GXt_char5 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV89AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         ucDvelop_confirmpanel_uadelete = new GXUserControl();
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienterepresentantesww__default(),
            new Object[][] {
                new Object[] {
               H00982_A186MunicipioCodigo, H00982_n186MunicipioCodigo, H00982_A444ResponsavelMunicipio, H00982_n444ResponsavelMunicipio, H00982_A402BancoId, H00982_n402BancoId, H00982_A437ResponsavelNacionalidade, H00982_n437ResponsavelNacionalidade, H00982_A484ClienteNacionalidade, H00982_n484ClienteNacionalidade,
               H00982_A442ResponsavelProfissao, H00982_n442ResponsavelProfissao, H00982_A487ClienteProfissao, H00982_n487ClienteProfissao, H00982_A489ClienteConvenio, H00982_n489ClienteConvenio, H00982_A445ResponsavelMunicipioNome, H00982_n445ResponsavelMunicipioNome, H00982_A443ResponsavelProfissaoNome, H00982_n443ResponsavelProfissaoNome,
               H00982_A438ResponsavelNacionalidadeNome, H00982_n438ResponsavelNacionalidadeNome, H00982_A404BancoCodigo, H00982_n404BancoCodigo, H00982_A187MunicipioNome, H00982_n187MunicipioNome, H00982_A488ClienteProfissaoNome, H00982_n488ClienteProfissaoNome, H00982_A485ClienteNacionalidadeNome, H00982_n485ClienteNacionalidadeNome,
               H00982_A490ClienteConvenioDescricao, H00982_n490ClienteConvenioDescricao, H00982_A192TipoClienteId, H00982_n192TipoClienteId, H00982_A174ClienteStatus, H00982_n174ClienteStatus, H00982_A884ClienteSituacao, H00982_n884ClienteSituacao, H00982_A193TipoClienteDescricao, H00982_n193TipoClienteDescricao,
               H00982_A172ClienteTipoPessoa, H00982_n172ClienteTipoPessoa, H00982_A171ClienteNomeFantasia, H00982_n171ClienteNomeFantasia, H00982_A170ClienteRazaoSocial, H00982_n170ClienteRazaoSocial, H00982_A169ClienteDocumento, H00982_n169ClienteDocumento, H00982_A885ResponsavelCargo, H00982_n885ResponsavelCargo,
               H00982_A456ResponsavelEmail, H00982_n456ResponsavelEmail, H00982_A447ResponsavelCPF, H00982_n447ResponsavelCPF, H00982_A436ResponsavelNome, H00982_n436ResponsavelNome, H00982_A168ClienteId, H00982_A455ResponsavelNumero, H00982_n455ResponsavelNumero, H00982_A454ResponsavelDDD,
               H00982_n454ResponsavelDDD
               }
               , new Object[] {
               H00983_A186MunicipioCodigo, H00983_n186MunicipioCodigo, H00983_A444ResponsavelMunicipio, H00983_n444ResponsavelMunicipio, H00983_A402BancoId, H00983_n402BancoId, H00983_A437ResponsavelNacionalidade, H00983_n437ResponsavelNacionalidade, H00983_A484ClienteNacionalidade, H00983_n484ClienteNacionalidade,
               H00983_A442ResponsavelProfissao, H00983_n442ResponsavelProfissao, H00983_A487ClienteProfissao, H00983_n487ClienteProfissao, H00983_A489ClienteConvenio, H00983_n489ClienteConvenio, H00983_A445ResponsavelMunicipioNome, H00983_n445ResponsavelMunicipioNome, H00983_A443ResponsavelProfissaoNome, H00983_n443ResponsavelProfissaoNome,
               H00983_A438ResponsavelNacionalidadeNome, H00983_n438ResponsavelNacionalidadeNome, H00983_A404BancoCodigo, H00983_n404BancoCodigo, H00983_A187MunicipioNome, H00983_n187MunicipioNome, H00983_A488ClienteProfissaoNome, H00983_n488ClienteProfissaoNome, H00983_A485ClienteNacionalidadeNome, H00983_n485ClienteNacionalidadeNome,
               H00983_A490ClienteConvenioDescricao, H00983_n490ClienteConvenioDescricao, H00983_A192TipoClienteId, H00983_n192TipoClienteId, H00983_A174ClienteStatus, H00983_n174ClienteStatus, H00983_A884ClienteSituacao, H00983_n884ClienteSituacao, H00983_A193TipoClienteDescricao, H00983_n193TipoClienteDescricao,
               H00983_A172ClienteTipoPessoa, H00983_n172ClienteTipoPessoa, H00983_A171ClienteNomeFantasia, H00983_n171ClienteNomeFantasia, H00983_A170ClienteRazaoSocial, H00983_n170ClienteRazaoSocial, H00983_A169ClienteDocumento, H00983_n169ClienteDocumento, H00983_A885ResponsavelCargo, H00983_n885ResponsavelCargo,
               H00983_A456ResponsavelEmail, H00983_n456ResponsavelEmail, H00983_A447ResponsavelCPF, H00983_n447ResponsavelCPF, H00983_A436ResponsavelNome, H00983_n436ResponsavelNome, H00983_A168ClienteId, H00983_A455ResponsavelNumero, H00983_n455ResponsavelNumero, H00983_A454ResponsavelDDD,
               H00983_n454ResponsavelDDD
               }
            }
         );
         AV100Pgmname = "ClienteRepresentantesWW";
         /* GeneXus formulas. */
         AV100Pgmname = "ClienteRepresentantesWW";
         edtavUasearch_Enabled = 0;
         edtavUaupdate_Enabled = 0;
         edtavUadelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV30DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV61ManageFiltersExecutionStep ;
      private short AV90TipoClienteId ;
      private short AV78TFClienteStatus_Sel ;
      private short gxajaxcallmode ;
      private short A454ResponsavelDDD ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
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
      private int nRC_GXsfl_197 ;
      private int nGXsfl_197_idx=1 ;
      private int AV24BancoCodigo1 ;
      private int AV37BancoCodigo2 ;
      private int AV50BancoCodigo3 ;
      private int AV95ClienteId_Selected ;
      private int A455ResponsavelNumero ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int edtavTipoclienteid_Enabled ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int edtavUasearch_Enabled ;
      private int edtavUaupdate_Enabled ;
      private int edtavUadelete_Enabled ;
      private int AV71TFResponsavelCargo_Sels_Count ;
      private int AV80TFClienteSituacao_Sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int edtClienteId_Enabled ;
      private int edtResponsavelNome_Enabled ;
      private int edtResponsavelCPF_Enabled ;
      private int edtResponsavelCelular_F_Enabled ;
      private int edtResponsavelEmail_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int AV82PageToGo ;
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
      private int AV101GXV1 ;
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
      private long AV83GridCurrentPage ;
      private long AV84GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_uadelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_197_idx="0001" ;
      private string AV100Pgmname ;
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
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Dvelop_confirmpanel_uadelete_Title ;
      private string Dvelop_confirmpanel_uadelete_Confirmationtext ;
      private string Dvelop_confirmpanel_uadelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uadelete_Confirmtype ;
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
      private string divInvisiblefilter_Internalname ;
      private string edtavTipoclienteid_Internalname ;
      private string edtavTipoclienteid_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV97UASearch ;
      private string edtavUasearch_Internalname ;
      private string AV99UAUpdate ;
      private string edtavUaupdate_Internalname ;
      private string AV94UADelete ;
      private string edtavUadelete_Internalname ;
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
      private string cmbClienteSituacao_Columnheaderclass ;
      private string cmbClienteStatus_Columnheaderclass ;
      private string edtavUaupdate_Class ;
      private string cmbClienteSituacao_Columnclass ;
      private string cmbClienteStatus_Columnclass ;
      private string GXEncryptionTmp ;
      private string GXt_char1 ;
      private string GXt_char5 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTabledvelop_confirmpanel_uadelete_Internalname ;
      private string Dvelop_confirmpanel_uadelete_Internalname ;
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
      private string sGXsfl_197_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUasearch_Jsonclick ;
      private string edtavUaupdate_Jsonclick ;
      private string edtavUadelete_Jsonclick ;
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
      private bool AV14OrderedDsc ;
      private bool AV28DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV55DynamicFiltersIgnoreFirst ;
      private bool AV54DynamicFiltersRemoving ;
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
      private bool n192TipoClienteId ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private bool bGXsfl_197_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV93GoInBack ;
      private string AV70TFResponsavelCargo_SelsJson ;
      private string AV79TFClienteSituacao_SelsJson ;
      private string AV60ManageFiltersXml ;
      private string AV15FilterFullText ;
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
      private string AV62TFResponsavelNome ;
      private string AV63TFResponsavelNome_Sel ;
      private string AV64TFResponsavelCPF ;
      private string AV65TFResponsavelCPF_Sel ;
      private string AV66TFResponsavelCelular_F ;
      private string AV67TFResponsavelCelular_F_Sel ;
      private string AV68TFResponsavelEmail ;
      private string AV69TFResponsavelEmail_Sel ;
      private string AV72TFClienteDocumento ;
      private string AV73TFClienteDocumento_Sel ;
      private string AV74TFClienteRazaoSocial ;
      private string AV75TFClienteRazaoSocial_Sel ;
      private string AV85GridAppliedFilters ;
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
      private string lV15FilterFullText ;
      private string lV18ClienteDocumento1 ;
      private string lV19TipoClienteDescricao1 ;
      private string lV20ClienteConvenioDescricao1 ;
      private string lV21ClienteNacionalidadeNome1 ;
      private string lV22ClienteProfissaoNome1 ;
      private string lV23MunicipioNome1 ;
      private string lV25ResponsavelNacionalidadeNome1 ;
      private string lV26ResponsavelProfissaoNome1 ;
      private string lV27ResponsavelMunicipioNome1 ;
      private string lV31ClienteDocumento2 ;
      private string lV32TipoClienteDescricao2 ;
      private string lV33ClienteConvenioDescricao2 ;
      private string lV34ClienteNacionalidadeNome2 ;
      private string lV35ClienteProfissaoNome2 ;
      private string lV36MunicipioNome2 ;
      private string lV38ResponsavelNacionalidadeNome2 ;
      private string lV39ResponsavelProfissaoNome2 ;
      private string lV40ResponsavelMunicipioNome2 ;
      private string lV44ClienteDocumento3 ;
      private string lV45TipoClienteDescricao3 ;
      private string lV46ClienteConvenioDescricao3 ;
      private string lV47ClienteNacionalidadeNome3 ;
      private string lV48ClienteProfissaoNome3 ;
      private string lV49MunicipioNome3 ;
      private string lV51ResponsavelNacionalidadeNome3 ;
      private string lV52ResponsavelProfissaoNome3 ;
      private string lV53ResponsavelMunicipioNome3 ;
      private string lV62TFResponsavelNome ;
      private string lV64TFResponsavelCPF ;
      private string lV68TFResponsavelEmail ;
      private string lV72TFClienteDocumento ;
      private string lV74TFClienteRazaoSocial ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV91Previous ;
      private string AV92Current ;
      private string AV56ExcelFilename ;
      private string AV57ErrorMessage ;
      private string AV89AuxText ;
      private IGxSession AV58Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_uadelete ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbResponsavelCargo ;
      private GXCombobox cmbClienteTipoPessoa ;
      private GXCombobox cmbClienteSituacao ;
      private GXCombobox cmbClienteStatus ;
      private GxSimpleCollection<string> AV71TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV80TFClienteSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV59ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV81DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00982_A186MunicipioCodigo ;
      private bool[] H00982_n186MunicipioCodigo ;
      private string[] H00982_A444ResponsavelMunicipio ;
      private bool[] H00982_n444ResponsavelMunicipio ;
      private int[] H00982_A402BancoId ;
      private bool[] H00982_n402BancoId ;
      private int[] H00982_A437ResponsavelNacionalidade ;
      private bool[] H00982_n437ResponsavelNacionalidade ;
      private int[] H00982_A484ClienteNacionalidade ;
      private bool[] H00982_n484ClienteNacionalidade ;
      private int[] H00982_A442ResponsavelProfissao ;
      private bool[] H00982_n442ResponsavelProfissao ;
      private int[] H00982_A487ClienteProfissao ;
      private bool[] H00982_n487ClienteProfissao ;
      private int[] H00982_A489ClienteConvenio ;
      private bool[] H00982_n489ClienteConvenio ;
      private string[] H00982_A445ResponsavelMunicipioNome ;
      private bool[] H00982_n445ResponsavelMunicipioNome ;
      private string[] H00982_A443ResponsavelProfissaoNome ;
      private bool[] H00982_n443ResponsavelProfissaoNome ;
      private string[] H00982_A438ResponsavelNacionalidadeNome ;
      private bool[] H00982_n438ResponsavelNacionalidadeNome ;
      private int[] H00982_A404BancoCodigo ;
      private bool[] H00982_n404BancoCodigo ;
      private string[] H00982_A187MunicipioNome ;
      private bool[] H00982_n187MunicipioNome ;
      private string[] H00982_A488ClienteProfissaoNome ;
      private bool[] H00982_n488ClienteProfissaoNome ;
      private string[] H00982_A485ClienteNacionalidadeNome ;
      private bool[] H00982_n485ClienteNacionalidadeNome ;
      private string[] H00982_A490ClienteConvenioDescricao ;
      private bool[] H00982_n490ClienteConvenioDescricao ;
      private short[] H00982_A192TipoClienteId ;
      private bool[] H00982_n192TipoClienteId ;
      private bool[] H00982_A174ClienteStatus ;
      private bool[] H00982_n174ClienteStatus ;
      private string[] H00982_A884ClienteSituacao ;
      private bool[] H00982_n884ClienteSituacao ;
      private string[] H00982_A193TipoClienteDescricao ;
      private bool[] H00982_n193TipoClienteDescricao ;
      private string[] H00982_A172ClienteTipoPessoa ;
      private bool[] H00982_n172ClienteTipoPessoa ;
      private string[] H00982_A171ClienteNomeFantasia ;
      private bool[] H00982_n171ClienteNomeFantasia ;
      private string[] H00982_A170ClienteRazaoSocial ;
      private bool[] H00982_n170ClienteRazaoSocial ;
      private string[] H00982_A169ClienteDocumento ;
      private bool[] H00982_n169ClienteDocumento ;
      private string[] H00982_A885ResponsavelCargo ;
      private bool[] H00982_n885ResponsavelCargo ;
      private string[] H00982_A456ResponsavelEmail ;
      private bool[] H00982_n456ResponsavelEmail ;
      private string[] H00982_A447ResponsavelCPF ;
      private bool[] H00982_n447ResponsavelCPF ;
      private string[] H00982_A436ResponsavelNome ;
      private bool[] H00982_n436ResponsavelNome ;
      private int[] H00982_A168ClienteId ;
      private int[] H00982_A455ResponsavelNumero ;
      private bool[] H00982_n455ResponsavelNumero ;
      private short[] H00982_A454ResponsavelDDD ;
      private bool[] H00982_n454ResponsavelDDD ;
      private string[] H00983_A186MunicipioCodigo ;
      private bool[] H00983_n186MunicipioCodigo ;
      private string[] H00983_A444ResponsavelMunicipio ;
      private bool[] H00983_n444ResponsavelMunicipio ;
      private int[] H00983_A402BancoId ;
      private bool[] H00983_n402BancoId ;
      private int[] H00983_A437ResponsavelNacionalidade ;
      private bool[] H00983_n437ResponsavelNacionalidade ;
      private int[] H00983_A484ClienteNacionalidade ;
      private bool[] H00983_n484ClienteNacionalidade ;
      private int[] H00983_A442ResponsavelProfissao ;
      private bool[] H00983_n442ResponsavelProfissao ;
      private int[] H00983_A487ClienteProfissao ;
      private bool[] H00983_n487ClienteProfissao ;
      private int[] H00983_A489ClienteConvenio ;
      private bool[] H00983_n489ClienteConvenio ;
      private string[] H00983_A445ResponsavelMunicipioNome ;
      private bool[] H00983_n445ResponsavelMunicipioNome ;
      private string[] H00983_A443ResponsavelProfissaoNome ;
      private bool[] H00983_n443ResponsavelProfissaoNome ;
      private string[] H00983_A438ResponsavelNacionalidadeNome ;
      private bool[] H00983_n438ResponsavelNacionalidadeNome ;
      private int[] H00983_A404BancoCodigo ;
      private bool[] H00983_n404BancoCodigo ;
      private string[] H00983_A187MunicipioNome ;
      private bool[] H00983_n187MunicipioNome ;
      private string[] H00983_A488ClienteProfissaoNome ;
      private bool[] H00983_n488ClienteProfissaoNome ;
      private string[] H00983_A485ClienteNacionalidadeNome ;
      private bool[] H00983_n485ClienteNacionalidadeNome ;
      private string[] H00983_A490ClienteConvenioDescricao ;
      private bool[] H00983_n490ClienteConvenioDescricao ;
      private short[] H00983_A192TipoClienteId ;
      private bool[] H00983_n192TipoClienteId ;
      private bool[] H00983_A174ClienteStatus ;
      private bool[] H00983_n174ClienteStatus ;
      private string[] H00983_A884ClienteSituacao ;
      private bool[] H00983_n884ClienteSituacao ;
      private string[] H00983_A193TipoClienteDescricao ;
      private bool[] H00983_n193TipoClienteDescricao ;
      private string[] H00983_A172ClienteTipoPessoa ;
      private bool[] H00983_n172ClienteTipoPessoa ;
      private string[] H00983_A171ClienteNomeFantasia ;
      private bool[] H00983_n171ClienteNomeFantasia ;
      private string[] H00983_A170ClienteRazaoSocial ;
      private bool[] H00983_n170ClienteRazaoSocial ;
      private string[] H00983_A169ClienteDocumento ;
      private bool[] H00983_n169ClienteDocumento ;
      private string[] H00983_A885ResponsavelCargo ;
      private bool[] H00983_n885ResponsavelCargo ;
      private string[] H00983_A456ResponsavelEmail ;
      private bool[] H00983_n456ResponsavelEmail ;
      private string[] H00983_A447ResponsavelCPF ;
      private bool[] H00983_n447ResponsavelCPF ;
      private string[] H00983_A436ResponsavelNome ;
      private bool[] H00983_n436ResponsavelNome ;
      private int[] H00983_A168ClienteId ;
      private int[] H00983_A455ResponsavelNumero ;
      private bool[] H00983_n455ResponsavelNumero ;
      private short[] H00983_A454ResponsavelDDD ;
      private bool[] H00983_n454ResponsavelDDD ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtSdErro AV96SdErro ;
      private SdtSdErro GXt_SdtSdErro4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clienterepresentantesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00982( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV71TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV80TFClienteSituacao_Sels ,
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
                                             bool AV28DynamicFiltersEnabled2 ,
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
                                             bool AV41DynamicFiltersEnabled3 ,
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
                                             string AV63TFResponsavelNome_Sel ,
                                             string AV62TFResponsavelNome ,
                                             string AV65TFResponsavelCPF_Sel ,
                                             string AV64TFResponsavelCPF ,
                                             string AV69TFResponsavelEmail_Sel ,
                                             string AV68TFResponsavelEmail ,
                                             int AV71TFResponsavelCargo_Sels_Count ,
                                             string AV73TFClienteDocumento_Sel ,
                                             string AV72TFClienteDocumento ,
                                             string AV75TFClienteRazaoSocial_Sel ,
                                             string AV74TFClienteRazaoSocial ,
                                             int AV80TFClienteSituacao_Sels_Count ,
                                             short AV78TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV15FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             short A192TipoClienteId ,
                                             string AV67TFResponsavelCelular_F_Sel ,
                                             string AV66TFResponsavelCelular_F )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[73];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T10.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ClienteId, T1.ResponsavelNumero, T1.ResponsavelDDD FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV18ClienteDocumento1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV18ClienteDocumento1)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV19TipoClienteDescricao1)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV19TipoClienteDescricao1)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV20ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV20ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV21ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV21ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV22ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV22ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV23MunicipioNome1)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV23MunicipioNome1)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 2 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV25ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV25ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV26ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV26ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV27ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV27ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV31ClienteDocumento2)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV31ClienteDocumento2)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV32TipoClienteDescricao2)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV32TipoClienteDescricao2)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV33ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV33ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV34ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV34ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV35ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV35ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV36MunicipioNome2)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV36MunicipioNome2)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 2 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV38ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[36] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV38ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[37] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV39ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV39ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int12[39] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV40ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int12[40] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV40ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int12[41] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV44ClienteDocumento3)");
         }
         else
         {
            GXv_int12[42] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV44ClienteDocumento3)");
         }
         else
         {
            GXv_int12[43] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV45TipoClienteDescricao3)");
         }
         else
         {
            GXv_int12[44] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV45TipoClienteDescricao3)");
         }
         else
         {
            GXv_int12[45] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV46ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int12[46] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV46ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int12[47] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV47ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[48] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV47ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[49] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV48ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int12[50] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV48ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int12[51] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV49MunicipioNome3)");
         }
         else
         {
            GXv_int12[52] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV49MunicipioNome3)");
         }
         else
         {
            GXv_int12[53] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int12[54] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int12[55] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 2 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int12[56] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV51ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[57] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV51ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[58] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV52ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int12[59] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV52ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int12[60] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV53ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int12[61] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV53ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int12[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV62TFResponsavelNome)");
         }
         else
         {
            GXv_int12[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV63TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int12[64] = 1;
         }
         if ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV64TFResponsavelCPF)");
         }
         else
         {
            GXv_int12[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV65TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int12[66] = 1;
         }
         if ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV68TFResponsavelEmail)");
         }
         else
         {
            GXv_int12[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV69TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int12[68] = 1;
         }
         if ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV71TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV72TFClienteDocumento)");
         }
         else
         {
            GXv_int12[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV73TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV73TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int12[70] = 1;
         }
         if ( StringUtil.StrCmp(AV73TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV74TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int12[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV75TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV75TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int12[72] = 1;
         }
         if ( StringUtil.StrCmp(AV75TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV80TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV78TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV78TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus DESC, T1.ClienteId";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H00983( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV71TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV80TFClienteSituacao_Sels ,
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
                                             bool AV28DynamicFiltersEnabled2 ,
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
                                             bool AV41DynamicFiltersEnabled3 ,
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
                                             string AV63TFResponsavelNome_Sel ,
                                             string AV62TFResponsavelNome ,
                                             string AV65TFResponsavelCPF_Sel ,
                                             string AV64TFResponsavelCPF ,
                                             string AV69TFResponsavelEmail_Sel ,
                                             string AV68TFResponsavelEmail ,
                                             int AV71TFResponsavelCargo_Sels_Count ,
                                             string AV73TFClienteDocumento_Sel ,
                                             string AV72TFClienteDocumento ,
                                             string AV75TFClienteRazaoSocial_Sel ,
                                             string AV74TFClienteRazaoSocial ,
                                             int AV80TFClienteSituacao_Sels_Count ,
                                             short AV78TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV15FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             short A192TipoClienteId ,
                                             string AV67TFResponsavelCelular_F_Sel ,
                                             string AV66TFResponsavelCelular_F )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[73];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T10.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ClienteId, T1.ResponsavelNumero, T1.ResponsavelDDD FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV18ClienteDocumento1)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV18ClienteDocumento1)");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV19TipoClienteDescricao1)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV19TipoClienteDescricao1)");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV20ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV20ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV21ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV21ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV22ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV22ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV23MunicipioNome1)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV23MunicipioNome1)");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV17DynamicFiltersOperator1 == 2 ) && ( ! (0==AV24BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV24BancoCodigo1)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV25ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV25ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV26ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV26ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV27ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV17DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV27ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV31ClienteDocumento2)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV31ClienteDocumento2)");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV32TipoClienteDescricao2)");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV32TipoClienteDescricao2)");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV33ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV33ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV34ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int14[27] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV34ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int14[28] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV35ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int14[29] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV35ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int14[30] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV36MunicipioNome2)");
         }
         else
         {
            GXv_int14[31] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV36MunicipioNome2)");
         }
         else
         {
            GXv_int14[32] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int14[33] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int14[34] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV30DynamicFiltersOperator2 == 2 ) && ( ! (0==AV37BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV37BancoCodigo2)");
         }
         else
         {
            GXv_int14[35] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV38ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int14[36] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV38ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int14[37] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV39ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int14[38] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV39ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int14[39] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV40ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int14[40] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV40ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int14[41] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV44ClienteDocumento3)");
         }
         else
         {
            GXv_int14[42] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV44ClienteDocumento3)");
         }
         else
         {
            GXv_int14[43] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV45TipoClienteDescricao3)");
         }
         else
         {
            GXv_int14[44] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV45TipoClienteDescricao3)");
         }
         else
         {
            GXv_int14[45] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV46ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int14[46] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV46ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int14[47] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV47ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int14[48] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV47ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int14[49] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV48ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int14[50] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV48ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int14[51] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV49MunicipioNome3)");
         }
         else
         {
            GXv_int14[52] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV49MunicipioNome3)");
         }
         else
         {
            GXv_int14[53] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int14[54] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int14[55] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV43DynamicFiltersOperator3 == 2 ) && ( ! (0==AV50BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV50BancoCodigo3)");
         }
         else
         {
            GXv_int14[56] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV51ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int14[57] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV51ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int14[58] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV52ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int14[59] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV52ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int14[60] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV53ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int14[61] = 1;
         }
         if ( AV41DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV43DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV53ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int14[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV62TFResponsavelNome)");
         }
         else
         {
            GXv_int14[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV63TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int14[64] = 1;
         }
         if ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV64TFResponsavelCPF)");
         }
         else
         {
            GXv_int14[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV65TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int14[66] = 1;
         }
         if ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV68TFResponsavelEmail)");
         }
         else
         {
            GXv_int14[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV69TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int14[68] = 1;
         }
         if ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV71TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV72TFClienteDocumento)");
         }
         else
         {
            GXv_int14[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV73TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV73TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int14[70] = 1;
         }
         if ( StringUtil.StrCmp(AV73TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV74TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int14[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV75TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV75TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int14[72] = 1;
         }
         if ( StringUtil.StrCmp(AV75TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV80TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV78TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV78TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H00982(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (short)dynConstraints[70] , (bool)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] );
               case 1 :
                     return conditional_H00983(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (short)dynConstraints[70] , (bool)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] );
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
          Object[] prmH00982;
          prmH00982 = new Object[] {
          new ParDef("lV18ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV18ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV19TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV19TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV20ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV20ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV21ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV21ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV22ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV22ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV23MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV23MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV25ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV25ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV26ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV26ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV27ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV27ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV31ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV31ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV32TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV32TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV33ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV33ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV34ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV34ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV35ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV35ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV36MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV36MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV38ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV38ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV39ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV39ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV40ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV40ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV44ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV44ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV45TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV45TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV46ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV46ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV47ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV47ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV48ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV48ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV49MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV49MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV51ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV51ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV52ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV52ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV53ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV53ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV62TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV63TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV64TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV65TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV68TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV69TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV72TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV73TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV74TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV75TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmH00983;
          prmH00983 = new Object[] {
          new ParDef("lV18ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV18ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV19TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV19TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV20ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV20ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV21ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV21ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV22ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV22ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV23MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV23MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV24BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV25ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV25ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV26ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV26ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV27ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV27ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV31ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV31ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV32TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV32TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV33ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV33ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV34ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV34ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV35ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV35ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV36MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV36MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV37BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV38ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV38ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV39ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV39ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV40ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV40ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV44ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV44ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV45TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV45TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV46ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV46ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV47ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV47ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV48ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV48ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV49MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV49MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV50BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV51ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV51ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV52ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV52ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV53ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV53ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV62TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV63TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV64TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV65TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV68TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV69TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV72TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV73TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV74TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV75TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00982", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00982,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00983", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00983,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((short[]) buf[32])[0] = rslt.getShort(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((bool[]) buf[34])[0] = rslt.getBool(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getString(19, 1);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
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
                ((string[]) buf[54])[0] = rslt.getVarchar(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((short[]) buf[32])[0] = rslt.getShort(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((bool[]) buf[34])[0] = rslt.getBool(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getString(19, 1);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
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
                ((string[]) buf[54])[0] = rslt.getVarchar(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                return;
       }
    }

 }

}
