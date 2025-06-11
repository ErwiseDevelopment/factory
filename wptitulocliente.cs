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
   public class wptitulocliente : GXDataArea
   {
      public wptitulocliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wptitulocliente( IGxContext context )
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
         cmbClienteTipoPessoa = new GXCombobox();
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
         nRC_GXsfl_191 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_191"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_191_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_191_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_191_idx = GetPar( "sGXsfl_191_idx");
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
         AV68ClienteConvenioDescricao1 = GetPar( "ClienteConvenioDescricao1");
         AV69ClienteNacionalidadeNome1 = GetPar( "ClienteNacionalidadeNome1");
         AV70ClienteProfissaoNome1 = GetPar( "ClienteProfissaoNome1");
         AV20SecUserName1 = GetPar( "SecUserName1");
         AV21MunicipioNome1 = GetPar( "MunicipioNome1");
         AV71BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo1"), "."), 18, MidpointRounding.ToEven));
         AV72ResponsavelNacionalidadeNome1 = GetPar( "ResponsavelNacionalidadeNome1");
         AV73ResponsavelProfissaoNome1 = GetPar( "ResponsavelProfissaoNome1");
         AV74ResponsavelMunicipioNome1 = GetPar( "ResponsavelMunicipioNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25ClienteDocumento2 = GetPar( "ClienteDocumento2");
         AV26TipoClienteDescricao2 = GetPar( "TipoClienteDescricao2");
         AV75ClienteConvenioDescricao2 = GetPar( "ClienteConvenioDescricao2");
         AV76ClienteNacionalidadeNome2 = GetPar( "ClienteNacionalidadeNome2");
         AV77ClienteProfissaoNome2 = GetPar( "ClienteProfissaoNome2");
         AV27SecUserName2 = GetPar( "SecUserName2");
         AV28MunicipioNome2 = GetPar( "MunicipioNome2");
         AV78BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo2"), "."), 18, MidpointRounding.ToEven));
         AV79ResponsavelNacionalidadeNome2 = GetPar( "ResponsavelNacionalidadeNome2");
         AV80ResponsavelProfissaoNome2 = GetPar( "ResponsavelProfissaoNome2");
         AV81ResponsavelMunicipioNome2 = GetPar( "ResponsavelMunicipioNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV32ClienteDocumento3 = GetPar( "ClienteDocumento3");
         AV33TipoClienteDescricao3 = GetPar( "TipoClienteDescricao3");
         AV82ClienteConvenioDescricao3 = GetPar( "ClienteConvenioDescricao3");
         AV83ClienteNacionalidadeNome3 = GetPar( "ClienteNacionalidadeNome3");
         AV84ClienteProfissaoNome3 = GetPar( "ClienteProfissaoNome3");
         AV34SecUserName3 = GetPar( "SecUserName3");
         AV35MunicipioNome3 = GetPar( "MunicipioNome3");
         AV85BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo3"), "."), 18, MidpointRounding.ToEven));
         AV86ResponsavelNacionalidadeNome3 = GetPar( "ResponsavelNacionalidadeNome3");
         AV87ResponsavelProfissaoNome3 = GetPar( "ResponsavelProfissaoNome3");
         AV88ResponsavelMunicipioNome3 = GetPar( "ResponsavelMunicipioNome3");
         AV41ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV29DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV89Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV42TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV43TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV44TFClienteNomeFantasia = GetPar( "TFClienteNomeFantasia");
         AV45TFClienteNomeFantasia_Sel = GetPar( "TFClienteNomeFantasia_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFClienteTipoPessoa_Sels);
         AV48TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV49TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         AV50TFTipoClienteDescricao = GetPar( "TFTipoClienteDescricao");
         AV51TFTipoClienteDescricao_Sel = GetPar( "TFTipoClienteDescricao_Sel");
         AV52TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV62TFClienteQtdTitulos_F = (int)(Math.Round(NumberUtil.Val( GetPar( "TFClienteQtdTitulos_F"), "."), 18, MidpointRounding.ToEven));
         AV63TFClienteQtdTitulos_F_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFClienteQtdTitulos_F_To"), "."), 18, MidpointRounding.ToEven));
         AV64TFClienteValorAPagar_F = NumberUtil.Val( GetPar( "TFClienteValorAPagar_F"), ".");
         AV65TFClienteValorAPagar_F_To = NumberUtil.Val( GetPar( "TFClienteValorAPagar_F_To"), ".");
         AV66TFClienteValorAReceber_F = NumberUtil.Val( GetPar( "TFClienteValorAReceber_F"), ".");
         AV67TFClienteValorAReceber_F_To = NumberUtil.Val( GetPar( "TFClienteValorAReceber_F_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV37DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV36DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         PA502( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START502( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptitulocliente") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO1", AV68ClienteConvenioDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME1", AV69ClienteNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME1", AV70ClienteProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME1", AV20SecUserName1);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME1", AV21MunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71BancoCodigo1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME1", AV72ResponsavelNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME1", AV73ResponsavelProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME1", AV74ResponsavelMunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO2", AV25ClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO2", AV26TipoClienteDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO2", AV75ClienteConvenioDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME2", AV76ClienteNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME2", AV77ClienteProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME2", AV27SecUserName2);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME2", AV28MunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78BancoCodigo2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME2", AV79ResponsavelNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME2", AV80ResponsavelProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME2", AV81ResponsavelMunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV30DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO3", AV32ClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO3", AV33TipoClienteDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO3", AV82ClienteConvenioDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME3", AV83ClienteNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME3", AV84ClienteProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME3", AV34SecUserName3);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME3", AV35MunicipioNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85BancoCodigo3), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME3", AV86ResponsavelNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME3", AV87ResponsavelProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME3", AV88ResponsavelMunicipioNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_191", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_191), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV59GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV55DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV55DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV29DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV42TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV43TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTENOMEFANTASIA", AV44TFClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTENOMEFANTASIA_SEL", AV45TFClienteNomeFantasia_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTETIPOPESSOA_SELS", AV47TFClienteTipoPessoa_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTETIPOPESSOA_SELS", AV47TFClienteTipoPessoa_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV48TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV49TFClienteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO", AV50TFTipoClienteDescricao);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO_SEL", AV51TFTipoClienteDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TFClienteStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEQTDTITULOS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEQTDTITULOS_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEVALORAPAGAR_F", StringUtil.LTrim( StringUtil.NToC( AV64TFClienteValorAPagar_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEVALORAPAGAR_F_TO", StringUtil.LTrim( StringUtil.NToC( AV65TFClienteValorAPagar_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEVALORARECEBER_F", StringUtil.LTrim( StringUtil.NToC( AV66TFClienteValorAReceber_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEVALORARECEBER_F_TO", StringUtil.LTrim( StringUtil.NToC( AV67TFClienteValorAReceber_F_To, 18, 2, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETIPOPESSOA_SELSJSON", AV46TFClienteTipoPessoa_SelsJson);
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
            WE502( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT502( ) ;
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
         return formatLink("wptitulocliente")  ;
      }

      public override string GetPgmname( )
      {
         return "WpTituloCLiente" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cliente" ;
      }

      protected void WB500( )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV39ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpTituloCLiente.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_39_502( true) ;
         }
         else
         {
            wb_table1_39_502( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_502e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_91_502( true) ;
         }
         else
         {
            wb_table2_91_502( false) ;
         }
         return  ;
      }

      protected void wb_table2_91_502e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV30DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_143_502( true) ;
         }
         else
         {
            wb_table3_143_502( false) ;
         }
         return  ;
      }

      protected void wb_table3_143_502e( bool wbgen )
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
            StartGridControl191( ) ;
         }
         if ( wbEnd == 191 )
         {
            wbEnd = 0;
            nRC_GXsfl_191 = (int)(nGXsfl_191_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV57GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV58GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV59GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpTituloCLiente.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV55DDO_TitleSettingsIcons);
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
         if ( wbEnd == 191 )
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

      protected void START502( )
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
         STRUP500( ) ;
      }

      protected void WS502( )
      {
         START502( ) ;
         EVT502( ) ;
      }

      protected void EVT502( )
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
                              E11502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E18502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E20502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22502 ();
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
                              nGXsfl_191_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
                              SubsflControlProps_1912( ) ;
                              AV60Titulos = cgiGet( edtavTitulos_Internalname);
                              AssignAttri("", false, edtavTitulos_Internalname, AV60Titulos);
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
                              n171ClienteNomeFantasia = false;
                              cmbClienteTipoPessoa.Name = cmbClienteTipoPessoa_Internalname;
                              cmbClienteTipoPessoa.CurrentValue = cgiGet( cmbClienteTipoPessoa_Internalname);
                              A172ClienteTipoPessoa = cgiGet( cmbClienteTipoPessoa_Internalname);
                              n172ClienteTipoPessoa = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n192TipoClienteId = false;
                              A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
                              n193TipoClienteDescricao = false;
                              cmbClienteStatus.Name = cmbClienteStatus_Internalname;
                              cmbClienteStatus.CurrentValue = cgiGet( cmbClienteStatus_Internalname);
                              A174ClienteStatus = StringUtil.StrToBool( cgiGet( cmbClienteStatus_Internalname));
                              n174ClienteStatus = false;
                              A175ClienteCreatedAt = context.localUtil.CToT( cgiGet( edtClienteCreatedAt_Internalname), 0);
                              n175ClienteCreatedAt = false;
                              A176ClienteUpdatedAt = context.localUtil.CToT( cgiGet( edtClienteUpdatedAt_Internalname), 0);
                              n176ClienteUpdatedAt = false;
                              A177ClienteLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteLogUser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n177ClienteLogUser = false;
                              A309ClienteQtdTitulos_F = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteQtdTitulos_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n309ClienteQtdTitulos_F = false;
                              A310ClienteValorAPagar_F = context.localUtil.CToN( cgiGet( edtClienteValorAPagar_F_Internalname), ",", ".");
                              n310ClienteValorAPagar_F = false;
                              A311ClienteValorAReceber_F = context.localUtil.CToN( cgiGet( edtClienteValorAReceber_F_Internalname), ",", ".");
                              n311ClienteValorAReceber_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E23502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E24502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E25502 ();
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
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV68ClienteConvenioDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV69ClienteNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV70ClienteProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV20SecUserName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV21MunicipioNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV71BancoCodigo1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV72ResponsavelNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV73ResponsavelProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV74ResponsavelMunicipioNome1) != 0 )
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
                                       /* Set Refresh If Clientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV25ClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV26TipoClienteDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV75ClienteConvenioDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV76ClienteNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV77ClienteProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV27SecUserName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV28MunicipioNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV78BancoCodigo2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV79ResponsavelNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV80ResponsavelProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV81ResponsavelMunicipioNome2) != 0 )
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
                                       /* Set Refresh If Clientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV32ClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV33TipoClienteDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV82ClienteConvenioDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV83ClienteNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV84ClienteProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV34SecUserName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV35MunicipioNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV85BancoCodigo3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV86ResponsavelNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV87ResponsavelProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV88ResponsavelMunicipioNome3) != 0 )
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

      protected void WE502( )
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

      protected void PA502( )
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
         SubsflControlProps_1912( ) ;
         while ( nGXsfl_191_idx <= nRC_GXsfl_191 )
         {
            sendrow_1912( ) ;
            nGXsfl_191_idx = ((subGrid_Islastpage==1)&&(nGXsfl_191_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_191_idx+1);
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1912( ) ;
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
                                       string AV68ClienteConvenioDescricao1 ,
                                       string AV69ClienteNacionalidadeNome1 ,
                                       string AV70ClienteProfissaoNome1 ,
                                       string AV20SecUserName1 ,
                                       string AV21MunicipioNome1 ,
                                       int AV71BancoCodigo1 ,
                                       string AV72ResponsavelNacionalidadeNome1 ,
                                       string AV73ResponsavelProfissaoNome1 ,
                                       string AV74ResponsavelMunicipioNome1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV25ClienteDocumento2 ,
                                       string AV26TipoClienteDescricao2 ,
                                       string AV75ClienteConvenioDescricao2 ,
                                       string AV76ClienteNacionalidadeNome2 ,
                                       string AV77ClienteProfissaoNome2 ,
                                       string AV27SecUserName2 ,
                                       string AV28MunicipioNome2 ,
                                       int AV78BancoCodigo2 ,
                                       string AV79ResponsavelNacionalidadeNome2 ,
                                       string AV80ResponsavelProfissaoNome2 ,
                                       string AV81ResponsavelMunicipioNome2 ,
                                       string AV30DynamicFiltersSelector3 ,
                                       short AV31DynamicFiltersOperator3 ,
                                       string AV32ClienteDocumento3 ,
                                       string AV33TipoClienteDescricao3 ,
                                       string AV82ClienteConvenioDescricao3 ,
                                       string AV83ClienteNacionalidadeNome3 ,
                                       string AV84ClienteProfissaoNome3 ,
                                       string AV34SecUserName3 ,
                                       string AV35MunicipioNome3 ,
                                       int AV85BancoCodigo3 ,
                                       string AV86ResponsavelNacionalidadeNome3 ,
                                       string AV87ResponsavelProfissaoNome3 ,
                                       string AV88ResponsavelMunicipioNome3 ,
                                       short AV41ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV29DynamicFiltersEnabled3 ,
                                       string AV89Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV42TFClienteRazaoSocial ,
                                       string AV43TFClienteRazaoSocial_Sel ,
                                       string AV44TFClienteNomeFantasia ,
                                       string AV45TFClienteNomeFantasia_Sel ,
                                       GxSimpleCollection<string> AV47TFClienteTipoPessoa_Sels ,
                                       string AV48TFClienteDocumento ,
                                       string AV49TFClienteDocumento_Sel ,
                                       string AV50TFTipoClienteDescricao ,
                                       string AV51TFTipoClienteDescricao_Sel ,
                                       short AV52TFClienteStatus_Sel ,
                                       int AV62TFClienteQtdTitulos_F ,
                                       int AV63TFClienteQtdTitulos_F_To ,
                                       decimal AV64TFClienteValorAPagar_F ,
                                       decimal AV65TFClienteValorAPagar_F_To ,
                                       decimal AV66TFClienteValorAReceber_F ,
                                       decimal AV67TFClienteValorAReceber_F_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV37DynamicFiltersIgnoreFirst ,
                                       bool AV36DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF502( ) ;
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
         RF502( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV89Pgmname = "WpTituloCLiente";
         edtavTitulos_Enabled = 0;
      }

      protected void RF502( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 191;
         /* Execute user event: Refresh */
         E24502 ();
         nGXsfl_191_idx = 1;
         sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
         SubsflControlProps_1912( ) ;
         bGXsfl_191_Refreshing = true;
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
            SubsflControlProps_1912( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A172ClienteTipoPessoa ,
                                                 AV136Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                                 AV91Wptituloclienteds_2_dynamicfiltersselector1 ,
                                                 AV92Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                                 AV93Wptituloclienteds_4_clientedocumento1 ,
                                                 AV94Wptituloclienteds_5_tipoclientedescricao1 ,
                                                 AV95Wptituloclienteds_6_clienteconveniodescricao1 ,
                                                 AV96Wptituloclienteds_7_clientenacionalidadenome1 ,
                                                 AV97Wptituloclienteds_8_clienteprofissaonome1 ,
                                                 AV98Wptituloclienteds_9_secusername1 ,
                                                 AV99Wptituloclienteds_10_municipionome1 ,
                                                 AV100Wptituloclienteds_11_bancocodigo1 ,
                                                 AV101Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                                 AV102Wptituloclienteds_13_responsavelprofissaonome1 ,
                                                 AV103Wptituloclienteds_14_responsavelmunicipionome1 ,
                                                 AV104Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                                 AV105Wptituloclienteds_16_dynamicfiltersselector2 ,
                                                 AV106Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                                 AV107Wptituloclienteds_18_clientedocumento2 ,
                                                 AV108Wptituloclienteds_19_tipoclientedescricao2 ,
                                                 AV109Wptituloclienteds_20_clienteconveniodescricao2 ,
                                                 AV110Wptituloclienteds_21_clientenacionalidadenome2 ,
                                                 AV111Wptituloclienteds_22_clienteprofissaonome2 ,
                                                 AV112Wptituloclienteds_23_secusername2 ,
                                                 AV113Wptituloclienteds_24_municipionome2 ,
                                                 AV114Wptituloclienteds_25_bancocodigo2 ,
                                                 AV115Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                                 AV116Wptituloclienteds_27_responsavelprofissaonome2 ,
                                                 AV117Wptituloclienteds_28_responsavelmunicipionome2 ,
                                                 AV118Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                                 AV119Wptituloclienteds_30_dynamicfiltersselector3 ,
                                                 AV120Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                                 AV121Wptituloclienteds_32_clientedocumento3 ,
                                                 AV122Wptituloclienteds_33_tipoclientedescricao3 ,
                                                 AV123Wptituloclienteds_34_clienteconveniodescricao3 ,
                                                 AV124Wptituloclienteds_35_clientenacionalidadenome3 ,
                                                 AV125Wptituloclienteds_36_clienteprofissaonome3 ,
                                                 AV126Wptituloclienteds_37_secusername3 ,
                                                 AV127Wptituloclienteds_38_municipionome3 ,
                                                 AV128Wptituloclienteds_39_bancocodigo3 ,
                                                 AV129Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                                 AV130Wptituloclienteds_41_responsavelprofissaonome3 ,
                                                 AV131Wptituloclienteds_42_responsavelmunicipionome3 ,
                                                 AV133Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                                 AV132Wptituloclienteds_43_tfclienterazaosocial ,
                                                 AV135Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                                 AV134Wptituloclienteds_45_tfclientenomefantasia ,
                                                 AV136Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                                 AV138Wptituloclienteds_49_tfclientedocumento_sel ,
                                                 AV137Wptituloclienteds_48_tfclientedocumento ,
                                                 AV140Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                                 AV139Wptituloclienteds_50_tftipoclientedescricao ,
                                                 AV141Wptituloclienteds_52_tfclientestatus_sel ,
                                                 AV144Wptituloclienteds_55_tfclientevalorapagar_f ,
                                                 AV145Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                                 AV146Wptituloclienteds_57_tfclientevalorareceber_f ,
                                                 AV147Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                                 A169ClienteDocumento ,
                                                 A193TipoClienteDescricao ,
                                                 A490ClienteConvenioDescricao ,
                                                 A485ClienteNacionalidadeNome ,
                                                 A488ClienteProfissaoNome ,
                                                 A141SecUserName ,
                                                 A187MunicipioNome ,
                                                 A404BancoCodigo ,
                                                 A438ResponsavelNacionalidadeNome ,
                                                 A443ResponsavelProfissaoNome ,
                                                 A445ResponsavelMunicipioNome ,
                                                 A170ClienteRazaoSocial ,
                                                 A171ClienteNomeFantasia ,
                                                 A174ClienteStatus ,
                                                 A310ClienteValorAPagar_F ,
                                                 A311ClienteValorAReceber_F ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV90Wptituloclienteds_1_filterfulltext ,
                                                 A309ClienteQtdTitulos_F ,
                                                 AV142Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                                 AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
            lV93Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1), "%", "");
            lV93Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1), "%", "");
            lV94Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1), "%", "");
            lV94Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1), "%", "");
            lV95Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
            lV95Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
            lV96Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
            lV96Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
            lV97Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1), "%", "");
            lV97Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1), "%", "");
            lV98Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1), "%", "");
            lV98Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1), "%", "");
            lV99Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1), "%", "");
            lV99Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1), "%", "");
            lV101Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
            lV101Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
            lV102Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
            lV102Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
            lV103Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
            lV103Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
            lV107Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2), "%", "");
            lV107Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2), "%", "");
            lV108Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2), "%", "");
            lV108Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2), "%", "");
            lV109Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
            lV109Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
            lV110Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
            lV110Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
            lV111Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2), "%", "");
            lV111Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2), "%", "");
            lV112Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2), "%", "");
            lV112Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2), "%", "");
            lV113Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2), "%", "");
            lV113Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2), "%", "");
            lV115Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
            lV115Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
            lV116Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
            lV116Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
            lV117Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
            lV117Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
            lV121Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3), "%", "");
            lV121Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3), "%", "");
            lV122Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3), "%", "");
            lV122Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3), "%", "");
            lV123Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
            lV123Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
            lV124Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
            lV124Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
            lV125Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3), "%", "");
            lV125Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3), "%", "");
            lV126Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3), "%", "");
            lV126Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3), "%", "");
            lV127Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3), "%", "");
            lV127Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3), "%", "");
            lV129Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
            lV129Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
            lV130Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
            lV130Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
            lV131Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
            lV131Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
            lV132Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_43_tfclienterazaosocial), "%", "");
            lV134Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_45_tfclientenomefantasia), "%", "");
            lV137Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_48_tfclientedocumento), "%", "");
            lV139Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_50_tftipoclientedescricao), "%", "");
            /* Using cursor H00508 */
            pr_default.execute(0, new Object[] {AV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, AV142Wptituloclienteds_53_tfclienteqtdtitulos_f, AV142Wptituloclienteds_53_tfclienteqtdtitulos_f, AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV93Wptituloclienteds_4_clientedocumento1, lV93Wptituloclienteds_4_clientedocumento1, lV94Wptituloclienteds_5_tipoclientedescricao1, lV94Wptituloclienteds_5_tipoclientedescricao1, lV95Wptituloclienteds_6_clienteconveniodescricao1, lV95Wptituloclienteds_6_clienteconveniodescricao1, lV96Wptituloclienteds_7_clientenacionalidadenome1, lV96Wptituloclienteds_7_clientenacionalidadenome1, lV97Wptituloclienteds_8_clienteprofissaonome1, lV97Wptituloclienteds_8_clienteprofissaonome1, lV98Wptituloclienteds_9_secusername1, lV98Wptituloclienteds_9_secusername1, lV99Wptituloclienteds_10_municipionome1, lV99Wptituloclienteds_10_municipionome1, AV100Wptituloclienteds_11_bancocodigo1, AV100Wptituloclienteds_11_bancocodigo1, AV100Wptituloclienteds_11_bancocodigo1, lV101Wptituloclienteds_12_responsavelnacionalidadenome1, lV101Wptituloclienteds_12_responsavelnacionalidadenome1, lV102Wptituloclienteds_13_responsavelprofissaonome1, lV102Wptituloclienteds_13_responsavelprofissaonome1, lV103Wptituloclienteds_14_responsavelmunicipionome1, lV103Wptituloclienteds_14_responsavelmunicipionome1, lV107Wptituloclienteds_18_clientedocumento2, lV107Wptituloclienteds_18_clientedocumento2, lV108Wptituloclienteds_19_tipoclientedescricao2, lV108Wptituloclienteds_19_tipoclientedescricao2, lV109Wptituloclienteds_20_clienteconveniodescricao2, lV109Wptituloclienteds_20_clienteconveniodescricao2, lV110Wptituloclienteds_21_clientenacionalidadenome2, lV110Wptituloclienteds_21_clientenacionalidadenome2, lV111Wptituloclienteds_22_clienteprofissaonome2, lV111Wptituloclienteds_22_clienteprofissaonome2, lV112Wptituloclienteds_23_secusername2, lV112Wptituloclienteds_23_secusername2, lV113Wptituloclienteds_24_municipionome2, lV113Wptituloclienteds_24_municipionome2, AV114Wptituloclienteds_25_bancocodigo2, AV114Wptituloclienteds_25_bancocodigo2, AV114Wptituloclienteds_25_bancocodigo2, lV115Wptituloclienteds_26_responsavelnacionalidadenome2, lV115Wptituloclienteds_26_responsavelnacionalidadenome2, lV116Wptituloclienteds_27_responsavelprofissaonome2, lV116Wptituloclienteds_27_responsavelprofissaonome2, lV117Wptituloclienteds_28_responsavelmunicipionome2, lV117Wptituloclienteds_28_responsavelmunicipionome2, lV121Wptituloclienteds_32_clientedocumento3, lV121Wptituloclienteds_32_clientedocumento3, lV122Wptituloclienteds_33_tipoclientedescricao3, lV122Wptituloclienteds_33_tipoclientedescricao3, lV123Wptituloclienteds_34_clienteconveniodescricao3, lV123Wptituloclienteds_34_clienteconveniodescricao3, lV124Wptituloclienteds_35_clientenacionalidadenome3, lV124Wptituloclienteds_35_clientenacionalidadenome3, lV125Wptituloclienteds_36_clienteprofissaonome3, lV125Wptituloclienteds_36_clienteprofissaonome3, lV126Wptituloclienteds_37_secusername3, lV126Wptituloclienteds_37_secusername3, lV127Wptituloclienteds_38_municipionome3, lV127Wptituloclienteds_38_municipionome3, AV128Wptituloclienteds_39_bancocodigo3, AV128Wptituloclienteds_39_bancocodigo3, AV128Wptituloclienteds_39_bancocodigo3, lV129Wptituloclienteds_40_responsavelnacionalidadenome3, lV129Wptituloclienteds_40_responsavelnacionalidadenome3, lV130Wptituloclienteds_41_responsavelprofissaonome3, lV130Wptituloclienteds_41_responsavelprofissaonome3, lV131Wptituloclienteds_42_responsavelmunicipionome3, lV131Wptituloclienteds_42_responsavelmunicipionome3, lV132Wptituloclienteds_43_tfclienterazaosocial, AV133Wptituloclienteds_44_tfclienterazaosocial_sel, lV134Wptituloclienteds_45_tfclientenomefantasia, AV135Wptituloclienteds_46_tfclientenomefantasia_sel, lV137Wptituloclienteds_48_tfclientedocumento, AV138Wptituloclienteds_49_tfclientedocumento_sel, lV139Wptituloclienteds_50_tftipoclientedescricao, AV140Wptituloclienteds_51_tftipoclientedescricao_sel, AV144Wptituloclienteds_55_tfclientevalorapagar_f, AV145Wptituloclienteds_56_tfclientevalorapagar_f_to, AV146Wptituloclienteds_57_tfclientevalorareceber_f, AV147Wptituloclienteds_58_tfclientevalorareceber_f_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_191_idx = 1;
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1912( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A186MunicipioCodigo = H00508_A186MunicipioCodigo[0];
               n186MunicipioCodigo = H00508_n186MunicipioCodigo[0];
               A444ResponsavelMunicipio = H00508_A444ResponsavelMunicipio[0];
               n444ResponsavelMunicipio = H00508_n444ResponsavelMunicipio[0];
               A402BancoId = H00508_A402BancoId[0];
               n402BancoId = H00508_n402BancoId[0];
               A457EspecialidadeId = H00508_A457EspecialidadeId[0];
               n457EspecialidadeId = H00508_n457EspecialidadeId[0];
               A597EspecialidadeCreatedBy = H00508_A597EspecialidadeCreatedBy[0];
               n597EspecialidadeCreatedBy = H00508_n597EspecialidadeCreatedBy[0];
               A437ResponsavelNacionalidade = H00508_A437ResponsavelNacionalidade[0];
               n437ResponsavelNacionalidade = H00508_n437ResponsavelNacionalidade[0];
               A484ClienteNacionalidade = H00508_A484ClienteNacionalidade[0];
               n484ClienteNacionalidade = H00508_n484ClienteNacionalidade[0];
               A442ResponsavelProfissao = H00508_A442ResponsavelProfissao[0];
               n442ResponsavelProfissao = H00508_n442ResponsavelProfissao[0];
               A487ClienteProfissao = H00508_A487ClienteProfissao[0];
               n487ClienteProfissao = H00508_n487ClienteProfissao[0];
               A489ClienteConvenio = H00508_A489ClienteConvenio[0];
               n489ClienteConvenio = H00508_n489ClienteConvenio[0];
               A445ResponsavelMunicipioNome = H00508_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H00508_n445ResponsavelMunicipioNome[0];
               A443ResponsavelProfissaoNome = H00508_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H00508_n443ResponsavelProfissaoNome[0];
               A438ResponsavelNacionalidadeNome = H00508_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H00508_n438ResponsavelNacionalidadeNome[0];
               A404BancoCodigo = H00508_A404BancoCodigo[0];
               n404BancoCodigo = H00508_n404BancoCodigo[0];
               A187MunicipioNome = H00508_A187MunicipioNome[0];
               n187MunicipioNome = H00508_n187MunicipioNome[0];
               A141SecUserName = H00508_A141SecUserName[0];
               n141SecUserName = H00508_n141SecUserName[0];
               A488ClienteProfissaoNome = H00508_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H00508_n488ClienteProfissaoNome[0];
               A485ClienteNacionalidadeNome = H00508_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H00508_n485ClienteNacionalidadeNome[0];
               A490ClienteConvenioDescricao = H00508_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H00508_n490ClienteConvenioDescricao[0];
               A177ClienteLogUser = H00508_A177ClienteLogUser[0];
               n177ClienteLogUser = H00508_n177ClienteLogUser[0];
               A176ClienteUpdatedAt = H00508_A176ClienteUpdatedAt[0];
               n176ClienteUpdatedAt = H00508_n176ClienteUpdatedAt[0];
               A175ClienteCreatedAt = H00508_A175ClienteCreatedAt[0];
               n175ClienteCreatedAt = H00508_n175ClienteCreatedAt[0];
               A174ClienteStatus = H00508_A174ClienteStatus[0];
               n174ClienteStatus = H00508_n174ClienteStatus[0];
               A193TipoClienteDescricao = H00508_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00508_n193TipoClienteDescricao[0];
               A192TipoClienteId = H00508_A192TipoClienteId[0];
               n192TipoClienteId = H00508_n192TipoClienteId[0];
               A169ClienteDocumento = H00508_A169ClienteDocumento[0];
               n169ClienteDocumento = H00508_n169ClienteDocumento[0];
               A172ClienteTipoPessoa = H00508_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H00508_n172ClienteTipoPessoa[0];
               A171ClienteNomeFantasia = H00508_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H00508_n171ClienteNomeFantasia[0];
               A170ClienteRazaoSocial = H00508_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H00508_n170ClienteRazaoSocial[0];
               A168ClienteId = H00508_A168ClienteId[0];
               n168ClienteId = H00508_n168ClienteId[0];
               A311ClienteValorAReceber_F = H00508_A311ClienteValorAReceber_F[0];
               n311ClienteValorAReceber_F = H00508_n311ClienteValorAReceber_F[0];
               A310ClienteValorAPagar_F = H00508_A310ClienteValorAPagar_F[0];
               n310ClienteValorAPagar_F = H00508_n310ClienteValorAPagar_F[0];
               A309ClienteQtdTitulos_F = H00508_A309ClienteQtdTitulos_F[0];
               n309ClienteQtdTitulos_F = H00508_n309ClienteQtdTitulos_F[0];
               A187MunicipioNome = H00508_A187MunicipioNome[0];
               n187MunicipioNome = H00508_n187MunicipioNome[0];
               A445ResponsavelMunicipioNome = H00508_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H00508_n445ResponsavelMunicipioNome[0];
               A404BancoCodigo = H00508_A404BancoCodigo[0];
               n404BancoCodigo = H00508_n404BancoCodigo[0];
               A597EspecialidadeCreatedBy = H00508_A597EspecialidadeCreatedBy[0];
               n597EspecialidadeCreatedBy = H00508_n597EspecialidadeCreatedBy[0];
               A141SecUserName = H00508_A141SecUserName[0];
               n141SecUserName = H00508_n141SecUserName[0];
               A438ResponsavelNacionalidadeNome = H00508_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H00508_n438ResponsavelNacionalidadeNome[0];
               A485ClienteNacionalidadeNome = H00508_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H00508_n485ClienteNacionalidadeNome[0];
               A443ResponsavelProfissaoNome = H00508_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H00508_n443ResponsavelProfissaoNome[0];
               A488ClienteProfissaoNome = H00508_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H00508_n488ClienteProfissaoNome[0];
               A490ClienteConvenioDescricao = H00508_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H00508_n490ClienteConvenioDescricao[0];
               A193TipoClienteDescricao = H00508_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H00508_n193TipoClienteDescricao[0];
               A311ClienteValorAReceber_F = H00508_A311ClienteValorAReceber_F[0];
               n311ClienteValorAReceber_F = H00508_n311ClienteValorAReceber_F[0];
               A310ClienteValorAPagar_F = H00508_A310ClienteValorAPagar_F[0];
               n310ClienteValorAPagar_F = H00508_n310ClienteValorAPagar_F[0];
               A309ClienteQtdTitulos_F = H00508_A309ClienteQtdTitulos_F[0];
               n309ClienteQtdTitulos_F = H00508_n309ClienteQtdTitulos_F[0];
               /* Execute user event: Grid.Load */
               E25502 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 191;
            WB500( ) ;
         }
         bGXsfl_191_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes502( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
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
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV136Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              AV91Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              AV92Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              AV93Wptituloclienteds_4_clientedocumento1 ,
                                              AV94Wptituloclienteds_5_tipoclientedescricao1 ,
                                              AV95Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              AV96Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              AV97Wptituloclienteds_8_clienteprofissaonome1 ,
                                              AV98Wptituloclienteds_9_secusername1 ,
                                              AV99Wptituloclienteds_10_municipionome1 ,
                                              AV100Wptituloclienteds_11_bancocodigo1 ,
                                              AV101Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              AV102Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              AV103Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              AV104Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              AV105Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              AV106Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              AV107Wptituloclienteds_18_clientedocumento2 ,
                                              AV108Wptituloclienteds_19_tipoclientedescricao2 ,
                                              AV109Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              AV110Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              AV111Wptituloclienteds_22_clienteprofissaonome2 ,
                                              AV112Wptituloclienteds_23_secusername2 ,
                                              AV113Wptituloclienteds_24_municipionome2 ,
                                              AV114Wptituloclienteds_25_bancocodigo2 ,
                                              AV115Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              AV116Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              AV117Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              AV118Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              AV119Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              AV120Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              AV121Wptituloclienteds_32_clientedocumento3 ,
                                              AV122Wptituloclienteds_33_tipoclientedescricao3 ,
                                              AV123Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              AV124Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              AV125Wptituloclienteds_36_clienteprofissaonome3 ,
                                              AV126Wptituloclienteds_37_secusername3 ,
                                              AV127Wptituloclienteds_38_municipionome3 ,
                                              AV128Wptituloclienteds_39_bancocodigo3 ,
                                              AV129Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              AV130Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              AV131Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              AV133Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              AV132Wptituloclienteds_43_tfclienterazaosocial ,
                                              AV135Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              AV134Wptituloclienteds_45_tfclientenomefantasia ,
                                              AV136Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                              AV138Wptituloclienteds_49_tfclientedocumento_sel ,
                                              AV137Wptituloclienteds_48_tfclientedocumento ,
                                              AV140Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              AV139Wptituloclienteds_50_tftipoclientedescricao ,
                                              AV141Wptituloclienteds_52_tfclientestatus_sel ,
                                              AV144Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              AV145Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              AV146Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              AV147Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A141SecUserName ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A174ClienteStatus ,
                                              A310ClienteValorAPagar_F ,
                                              A311ClienteValorAReceber_F ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV90Wptituloclienteds_1_filterfulltext ,
                                              A309ClienteQtdTitulos_F ,
                                              AV142Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV90Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Wptituloclienteds_1_filterfulltext), "%", "");
         lV93Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1), "%", "");
         lV93Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1), "%", "");
         lV94Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV94Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV95Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV95Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV96Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV96Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV97Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV97Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV98Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1), "%", "");
         lV98Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1), "%", "");
         lV99Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1), "%", "");
         lV99Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1), "%", "");
         lV101Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV101Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV102Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV102Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV103Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV103Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV107Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2), "%", "");
         lV107Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2), "%", "");
         lV108Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV108Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV109Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV109Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV110Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV110Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV111Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV111Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV112Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2), "%", "");
         lV112Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2), "%", "");
         lV113Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2), "%", "");
         lV113Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2), "%", "");
         lV115Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV115Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV116Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV116Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV117Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV117Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV121Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3), "%", "");
         lV121Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3), "%", "");
         lV122Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV122Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV123Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV123Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV124Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV124Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV125Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV125Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV126Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3), "%", "");
         lV126Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3), "%", "");
         lV127Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3), "%", "");
         lV127Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3), "%", "");
         lV129Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV129Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV130Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV130Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV131Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV131Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV132Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_43_tfclienterazaosocial), "%", "");
         lV134Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_45_tfclientenomefantasia), "%", "");
         lV137Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_48_tfclientedocumento), "%", "");
         lV139Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_50_tftipoclientedescricao), "%", "");
         /* Using cursor H005015 */
         pr_default.execute(1, new Object[] {AV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, lV90Wptituloclienteds_1_filterfulltext, AV142Wptituloclienteds_53_tfclienteqtdtitulos_f, AV142Wptituloclienteds_53_tfclienteqtdtitulos_f, AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV93Wptituloclienteds_4_clientedocumento1, lV93Wptituloclienteds_4_clientedocumento1, lV94Wptituloclienteds_5_tipoclientedescricao1, lV94Wptituloclienteds_5_tipoclientedescricao1, lV95Wptituloclienteds_6_clienteconveniodescricao1, lV95Wptituloclienteds_6_clienteconveniodescricao1, lV96Wptituloclienteds_7_clientenacionalidadenome1, lV96Wptituloclienteds_7_clientenacionalidadenome1, lV97Wptituloclienteds_8_clienteprofissaonome1, lV97Wptituloclienteds_8_clienteprofissaonome1, lV98Wptituloclienteds_9_secusername1, lV98Wptituloclienteds_9_secusername1, lV99Wptituloclienteds_10_municipionome1, lV99Wptituloclienteds_10_municipionome1, AV100Wptituloclienteds_11_bancocodigo1, AV100Wptituloclienteds_11_bancocodigo1, AV100Wptituloclienteds_11_bancocodigo1, lV101Wptituloclienteds_12_responsavelnacionalidadenome1, lV101Wptituloclienteds_12_responsavelnacionalidadenome1, lV102Wptituloclienteds_13_responsavelprofissaonome1, lV102Wptituloclienteds_13_responsavelprofissaonome1, lV103Wptituloclienteds_14_responsavelmunicipionome1, lV103Wptituloclienteds_14_responsavelmunicipionome1, lV107Wptituloclienteds_18_clientedocumento2, lV107Wptituloclienteds_18_clientedocumento2, lV108Wptituloclienteds_19_tipoclientedescricao2, lV108Wptituloclienteds_19_tipoclientedescricao2, lV109Wptituloclienteds_20_clienteconveniodescricao2, lV109Wptituloclienteds_20_clienteconveniodescricao2, lV110Wptituloclienteds_21_clientenacionalidadenome2, lV110Wptituloclienteds_21_clientenacionalidadenome2, lV111Wptituloclienteds_22_clienteprofissaonome2, lV111Wptituloclienteds_22_clienteprofissaonome2, lV112Wptituloclienteds_23_secusername2, lV112Wptituloclienteds_23_secusername2, lV113Wptituloclienteds_24_municipionome2, lV113Wptituloclienteds_24_municipionome2, AV114Wptituloclienteds_25_bancocodigo2, AV114Wptituloclienteds_25_bancocodigo2, AV114Wptituloclienteds_25_bancocodigo2, lV115Wptituloclienteds_26_responsavelnacionalidadenome2, lV115Wptituloclienteds_26_responsavelnacionalidadenome2, lV116Wptituloclienteds_27_responsavelprofissaonome2, lV116Wptituloclienteds_27_responsavelprofissaonome2, lV117Wptituloclienteds_28_responsavelmunicipionome2, lV117Wptituloclienteds_28_responsavelmunicipionome2, lV121Wptituloclienteds_32_clientedocumento3, lV121Wptituloclienteds_32_clientedocumento3, lV122Wptituloclienteds_33_tipoclientedescricao3, lV122Wptituloclienteds_33_tipoclientedescricao3, lV123Wptituloclienteds_34_clienteconveniodescricao3, lV123Wptituloclienteds_34_clienteconveniodescricao3, lV124Wptituloclienteds_35_clientenacionalidadenome3, lV124Wptituloclienteds_35_clientenacionalidadenome3, lV125Wptituloclienteds_36_clienteprofissaonome3, lV125Wptituloclienteds_36_clienteprofissaonome3, lV126Wptituloclienteds_37_secusername3, lV126Wptituloclienteds_37_secusername3, lV127Wptituloclienteds_38_municipionome3, lV127Wptituloclienteds_38_municipionome3, AV128Wptituloclienteds_39_bancocodigo3, AV128Wptituloclienteds_39_bancocodigo3, AV128Wptituloclienteds_39_bancocodigo3, lV129Wptituloclienteds_40_responsavelnacionalidadenome3, lV129Wptituloclienteds_40_responsavelnacionalidadenome3, lV130Wptituloclienteds_41_responsavelprofissaonome3, lV130Wptituloclienteds_41_responsavelprofissaonome3, lV131Wptituloclienteds_42_responsavelmunicipionome3, lV131Wptituloclienteds_42_responsavelmunicipionome3, lV132Wptituloclienteds_43_tfclienterazaosocial, AV133Wptituloclienteds_44_tfclienterazaosocial_sel, lV134Wptituloclienteds_45_tfclientenomefantasia, AV135Wptituloclienteds_46_tfclientenomefantasia_sel, lV137Wptituloclienteds_48_tfclientedocumento, AV138Wptituloclienteds_49_tfclientedocumento_sel, lV139Wptituloclienteds_50_tftipoclientedescricao, AV140Wptituloclienteds_51_tftipoclientedescricao_sel, AV144Wptituloclienteds_55_tfclientevalorapagar_f, AV145Wptituloclienteds_56_tfclientevalorapagar_f_to, AV146Wptituloclienteds_57_tfclientevalorareceber_f, AV147Wptituloclienteds_58_tfclientevalorareceber_f_to});
         GRID_nRecordCount = H005015_AGRID_nRecordCount[0];
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
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV89Pgmname = "WpTituloCLiente";
         edtavTitulos_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtTipoClienteId_Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         cmbClienteStatus.Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         edtClienteUpdatedAt_Enabled = 0;
         edtClienteLogUser_Enabled = 0;
         edtClienteQtdTitulos_F_Enabled = 0;
         edtClienteValorAPagar_F_Enabled = 0;
         edtClienteValorAReceber_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP500( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E23502 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV39ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV55DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_191 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_191"), ",", "."), 18, MidpointRounding.ToEven));
            AV57GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV59GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV68ClienteConvenioDescricao1 = cgiGet( edtavClienteconveniodescricao1_Internalname);
            AssignAttri("", false, "AV68ClienteConvenioDescricao1", AV68ClienteConvenioDescricao1);
            AV69ClienteNacionalidadeNome1 = cgiGet( edtavClientenacionalidadenome1_Internalname);
            AssignAttri("", false, "AV69ClienteNacionalidadeNome1", AV69ClienteNacionalidadeNome1);
            AV70ClienteProfissaoNome1 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome1_Internalname));
            AssignAttri("", false, "AV70ClienteProfissaoNome1", AV70ClienteProfissaoNome1);
            AV20SecUserName1 = StringUtil.Upper( cgiGet( edtavSecusername1_Internalname));
            AssignAttri("", false, "AV20SecUserName1", AV20SecUserName1);
            AV21MunicipioNome1 = StringUtil.Upper( cgiGet( edtavMunicipionome1_Internalname));
            AssignAttri("", false, "AV21MunicipioNome1", AV21MunicipioNome1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO1");
               GX_FocusControl = edtavBancocodigo1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV71BancoCodigo1 = 0;
               AssignAttri("", false, "AV71BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV71BancoCodigo1), 9, 0));
            }
            else
            {
               AV71BancoCodigo1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV71BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV71BancoCodigo1), 9, 0));
            }
            AV72ResponsavelNacionalidadeNome1 = cgiGet( edtavResponsavelnacionalidadenome1_Internalname);
            AssignAttri("", false, "AV72ResponsavelNacionalidadeNome1", AV72ResponsavelNacionalidadeNome1);
            AV73ResponsavelProfissaoNome1 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome1_Internalname));
            AssignAttri("", false, "AV73ResponsavelProfissaoNome1", AV73ResponsavelProfissaoNome1);
            AV74ResponsavelMunicipioNome1 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome1_Internalname));
            AssignAttri("", false, "AV74ResponsavelMunicipioNome1", AV74ResponsavelMunicipioNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV25ClienteDocumento2 = cgiGet( edtavClientedocumento2_Internalname);
            AssignAttri("", false, "AV25ClienteDocumento2", AV25ClienteDocumento2);
            AV26TipoClienteDescricao2 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao2_Internalname));
            AssignAttri("", false, "AV26TipoClienteDescricao2", AV26TipoClienteDescricao2);
            AV75ClienteConvenioDescricao2 = cgiGet( edtavClienteconveniodescricao2_Internalname);
            AssignAttri("", false, "AV75ClienteConvenioDescricao2", AV75ClienteConvenioDescricao2);
            AV76ClienteNacionalidadeNome2 = cgiGet( edtavClientenacionalidadenome2_Internalname);
            AssignAttri("", false, "AV76ClienteNacionalidadeNome2", AV76ClienteNacionalidadeNome2);
            AV77ClienteProfissaoNome2 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome2_Internalname));
            AssignAttri("", false, "AV77ClienteProfissaoNome2", AV77ClienteProfissaoNome2);
            AV27SecUserName2 = StringUtil.Upper( cgiGet( edtavSecusername2_Internalname));
            AssignAttri("", false, "AV27SecUserName2", AV27SecUserName2);
            AV28MunicipioNome2 = StringUtil.Upper( cgiGet( edtavMunicipionome2_Internalname));
            AssignAttri("", false, "AV28MunicipioNome2", AV28MunicipioNome2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO2");
               GX_FocusControl = edtavBancocodigo2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV78BancoCodigo2 = 0;
               AssignAttri("", false, "AV78BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV78BancoCodigo2), 9, 0));
            }
            else
            {
               AV78BancoCodigo2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV78BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV78BancoCodigo2), 9, 0));
            }
            AV79ResponsavelNacionalidadeNome2 = cgiGet( edtavResponsavelnacionalidadenome2_Internalname);
            AssignAttri("", false, "AV79ResponsavelNacionalidadeNome2", AV79ResponsavelNacionalidadeNome2);
            AV80ResponsavelProfissaoNome2 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome2_Internalname));
            AssignAttri("", false, "AV80ResponsavelProfissaoNome2", AV80ResponsavelProfissaoNome2);
            AV81ResponsavelMunicipioNome2 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome2_Internalname));
            AssignAttri("", false, "AV81ResponsavelMunicipioNome2", AV81ResponsavelMunicipioNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV30DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AV32ClienteDocumento3 = cgiGet( edtavClientedocumento3_Internalname);
            AssignAttri("", false, "AV32ClienteDocumento3", AV32ClienteDocumento3);
            AV33TipoClienteDescricao3 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao3_Internalname));
            AssignAttri("", false, "AV33TipoClienteDescricao3", AV33TipoClienteDescricao3);
            AV82ClienteConvenioDescricao3 = cgiGet( edtavClienteconveniodescricao3_Internalname);
            AssignAttri("", false, "AV82ClienteConvenioDescricao3", AV82ClienteConvenioDescricao3);
            AV83ClienteNacionalidadeNome3 = cgiGet( edtavClientenacionalidadenome3_Internalname);
            AssignAttri("", false, "AV83ClienteNacionalidadeNome3", AV83ClienteNacionalidadeNome3);
            AV84ClienteProfissaoNome3 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome3_Internalname));
            AssignAttri("", false, "AV84ClienteProfissaoNome3", AV84ClienteProfissaoNome3);
            AV34SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri("", false, "AV34SecUserName3", AV34SecUserName3);
            AV35MunicipioNome3 = StringUtil.Upper( cgiGet( edtavMunicipionome3_Internalname));
            AssignAttri("", false, "AV35MunicipioNome3", AV35MunicipioNome3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO3");
               GX_FocusControl = edtavBancocodigo3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV85BancoCodigo3 = 0;
               AssignAttri("", false, "AV85BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV85BancoCodigo3), 9, 0));
            }
            else
            {
               AV85BancoCodigo3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV85BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV85BancoCodigo3), 9, 0));
            }
            AV86ResponsavelNacionalidadeNome3 = cgiGet( edtavResponsavelnacionalidadenome3_Internalname);
            AssignAttri("", false, "AV86ResponsavelNacionalidadeNome3", AV86ResponsavelNacionalidadeNome3);
            AV87ResponsavelProfissaoNome3 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome3_Internalname));
            AssignAttri("", false, "AV87ResponsavelProfissaoNome3", AV87ResponsavelProfissaoNome3);
            AV88ResponsavelMunicipioNome3 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome3_Internalname));
            AssignAttri("", false, "AV88ResponsavelMunicipioNome3", AV88ResponsavelMunicipioNome3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV68ClienteConvenioDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV69ClienteNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV70ClienteProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV20SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV21MunicipioNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV71BancoCodigo1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV72ResponsavelNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV73ResponsavelProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV74ResponsavelMunicipioNome1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV25ClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV26TipoClienteDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV75ClienteConvenioDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV76ClienteNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV77ClienteProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV27SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV28MunicipioNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV78BancoCodigo2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV79ResponsavelNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV80ResponsavelProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV81ResponsavelMunicipioNome2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV32ClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV33TipoClienteDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV82ClienteConvenioDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV83ClienteNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV84ClienteProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV34SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV35MunicipioNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV85BancoCodigo3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV86ResponsavelNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV87ResponsavelProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV88ResponsavelMunicipioNome3) != 0 )
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
         E23502 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E23502( )
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
         AV16DynamicFiltersSelector1 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV55DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV55DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E24502( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV41ManageFiltersExecutionStep == 1 )
         {
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV41ManageFiltersExecutionStep == 2 )
         {
            AV41ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
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
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV29DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "SECUSERNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         AV57GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV57GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV57GridCurrentPage), 10, 0));
         AV58GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV58GridPageCount", StringUtil.LTrimStr( (decimal)(AV58GridPageCount), 10, 0));
         GXt_char2 = AV59GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV89Pgmname, out  GXt_char2) ;
         AV59GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV59GridAppliedFilters", AV59GridAppliedFilters);
         cmbClienteStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteStatus_Internalname, "Columnheaderclass", cmbClienteStatus_Columnheaderclass, !bGXsfl_191_Refreshing);
         AV90Wptituloclienteds_1_filterfulltext = AV15FilterFullText;
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV92Wptituloclienteds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV93Wptituloclienteds_4_clientedocumento1 = AV18ClienteDocumento1;
         AV94Wptituloclienteds_5_tipoclientedescricao1 = AV19TipoClienteDescricao1;
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = AV68ClienteConvenioDescricao1;
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = AV69ClienteNacionalidadeNome1;
         AV97Wptituloclienteds_8_clienteprofissaonome1 = AV70ClienteProfissaoNome1;
         AV98Wptituloclienteds_9_secusername1 = AV20SecUserName1;
         AV99Wptituloclienteds_10_municipionome1 = AV21MunicipioNome1;
         AV100Wptituloclienteds_11_bancocodigo1 = AV71BancoCodigo1;
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = AV72ResponsavelNacionalidadeNome1;
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = AV73ResponsavelProfissaoNome1;
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = AV74ResponsavelMunicipioNome1;
         AV104Wptituloclienteds_15_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV106Wptituloclienteds_17_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV107Wptituloclienteds_18_clientedocumento2 = AV25ClienteDocumento2;
         AV108Wptituloclienteds_19_tipoclientedescricao2 = AV26TipoClienteDescricao2;
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = AV75ClienteConvenioDescricao2;
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = AV76ClienteNacionalidadeNome2;
         AV111Wptituloclienteds_22_clienteprofissaonome2 = AV77ClienteProfissaoNome2;
         AV112Wptituloclienteds_23_secusername2 = AV27SecUserName2;
         AV113Wptituloclienteds_24_municipionome2 = AV28MunicipioNome2;
         AV114Wptituloclienteds_25_bancocodigo2 = AV78BancoCodigo2;
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = AV79ResponsavelNacionalidadeNome2;
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = AV80ResponsavelProfissaoNome2;
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = AV81ResponsavelMunicipioNome2;
         AV118Wptituloclienteds_29_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV120Wptituloclienteds_31_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV121Wptituloclienteds_32_clientedocumento3 = AV32ClienteDocumento3;
         AV122Wptituloclienteds_33_tipoclientedescricao3 = AV33TipoClienteDescricao3;
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = AV82ClienteConvenioDescricao3;
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = AV83ClienteNacionalidadeNome3;
         AV125Wptituloclienteds_36_clienteprofissaonome3 = AV84ClienteProfissaoNome3;
         AV126Wptituloclienteds_37_secusername3 = AV34SecUserName3;
         AV127Wptituloclienteds_38_municipionome3 = AV35MunicipioNome3;
         AV128Wptituloclienteds_39_bancocodigo3 = AV85BancoCodigo3;
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = AV86ResponsavelNacionalidadeNome3;
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = AV87ResponsavelProfissaoNome3;
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = AV88ResponsavelMunicipioNome3;
         AV132Wptituloclienteds_43_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV134Wptituloclienteds_45_tfclientenomefantasia = AV44TFClienteNomeFantasia;
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = AV45TFClienteNomeFantasia_Sel;
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = AV47TFClienteTipoPessoa_Sels;
         AV137Wptituloclienteds_48_tfclientedocumento = AV48TFClienteDocumento;
         AV138Wptituloclienteds_49_tfclientedocumento_sel = AV49TFClienteDocumento_Sel;
         AV139Wptituloclienteds_50_tftipoclientedescricao = AV50TFTipoClienteDescricao;
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = AV51TFTipoClienteDescricao_Sel;
         AV141Wptituloclienteds_52_tfclientestatus_sel = AV52TFClienteStatus_Sel;
         AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = AV62TFClienteQtdTitulos_F;
         AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV63TFClienteQtdTitulos_F_To;
         AV144Wptituloclienteds_55_tfclientevalorapagar_f = AV64TFClienteValorAPagar_F;
         AV145Wptituloclienteds_56_tfclientevalorapagar_f_to = AV65TFClienteValorAPagar_F_To;
         AV146Wptituloclienteds_57_tfclientevalorareceber_f = AV66TFClienteValorAReceber_F;
         AV147Wptituloclienteds_58_tfclientevalorareceber_f_to = AV67TFClienteValorAReceber_F_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12502( )
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
            AV56PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV56PageToGo) ;
         }
      }

      protected void E13502( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14502( )
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
               AV42TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFClienteRazaoSocial", AV42TFClienteRazaoSocial);
               AV43TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFClienteRazaoSocial_Sel", AV43TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteNomeFantasia") == 0 )
            {
               AV44TFClienteNomeFantasia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFClienteNomeFantasia", AV44TFClienteNomeFantasia);
               AV45TFClienteNomeFantasia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFClienteNomeFantasia_Sel", AV45TFClienteNomeFantasia_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTipoPessoa") == 0 )
            {
               AV46TFClienteTipoPessoa_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFClienteTipoPessoa_SelsJson", AV46TFClienteTipoPessoa_SelsJson);
               AV47TFClienteTipoPessoa_Sels.FromJSonString(AV46TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV48TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFClienteDocumento", AV48TFClienteDocumento);
               AV49TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFClienteDocumento_Sel", AV49TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoClienteDescricao") == 0 )
            {
               AV50TFTipoClienteDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFTipoClienteDescricao", AV50TFTipoClienteDescricao);
               AV51TFTipoClienteDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFTipoClienteDescricao_Sel", AV51TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteStatus") == 0 )
            {
               AV52TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV52TFClienteStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteQtdTitulos_F") == 0 )
            {
               AV62TFClienteQtdTitulos_F = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV62TFClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0));
               AV63TFClienteQtdTitulos_F_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV63TFClienteQtdTitulos_F_To", StringUtil.LTrimStr( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteValorAPagar_F") == 0 )
            {
               AV64TFClienteValorAPagar_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV64TFClienteValorAPagar_F", StringUtil.LTrimStr( AV64TFClienteValorAPagar_F, 18, 2));
               AV65TFClienteValorAPagar_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV65TFClienteValorAPagar_F_To", StringUtil.LTrimStr( AV65TFClienteValorAPagar_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteValorAReceber_F") == 0 )
            {
               AV66TFClienteValorAReceber_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV66TFClienteValorAReceber_F", StringUtil.LTrimStr( AV66TFClienteValorAReceber_F, 18, 2));
               AV67TFClienteValorAReceber_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV67TFClienteValorAReceber_F_To", StringUtil.LTrimStr( AV67TFClienteValorAReceber_F_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFClienteTipoPessoa_Sels", AV47TFClienteTipoPessoa_Sels);
      }

      private void E25502( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV60Titulos = "<i class=\"fas fa-search\"></i>";
         AssignAttri("", false, edtavTitulos_Internalname, AV60Titulos);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wplistatituloscliente"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(A170ClienteRazaoSocial));
         edtavTitulos_Link = formatLink("wplistatituloscliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         edtClienteDocumento_Link = formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A192TipoClienteId,4,0));
         edtTipoClienteDescricao_Link = formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
            wbStart = 191;
         }
         sendrow_1912( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_191_Refreshing )
         {
            DoAjaxLoad(191, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E18502( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15502( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E19502( )
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

      protected void E20502( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16502( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E21502( )
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

      protected void E17502( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ClienteDocumento1, AV19TipoClienteDescricao1, AV68ClienteConvenioDescricao1, AV69ClienteNacionalidadeNome1, AV70ClienteProfissaoNome1, AV20SecUserName1, AV21MunicipioNome1, AV71BancoCodigo1, AV72ResponsavelNacionalidadeNome1, AV73ResponsavelProfissaoNome1, AV74ResponsavelMunicipioNome1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ClienteDocumento2, AV26TipoClienteDescricao2, AV75ClienteConvenioDescricao2, AV76ClienteNacionalidadeNome2, AV77ClienteProfissaoNome2, AV27SecUserName2, AV28MunicipioNome2, AV78BancoCodigo2, AV79ResponsavelNacionalidadeNome2, AV80ResponsavelProfissaoNome2, AV81ResponsavelMunicipioNome2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV32ClienteDocumento3, AV33TipoClienteDescricao3, AV82ClienteConvenioDescricao3, AV83ClienteNacionalidadeNome3, AV84ClienteProfissaoNome3, AV34SecUserName3, AV35MunicipioNome3, AV85BancoCodigo3, AV86ResponsavelNacionalidadeNome3, AV87ResponsavelProfissaoNome3, AV88ResponsavelMunicipioNome3, AV41ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV89Pgmname, AV15FilterFullText, AV42TFClienteRazaoSocial, AV43TFClienteRazaoSocial_Sel, AV44TFClienteNomeFantasia, AV45TFClienteNomeFantasia_Sel, AV47TFClienteTipoPessoa_Sels, AV48TFClienteDocumento, AV49TFClienteDocumento_Sel, AV50TFTipoClienteDescricao, AV51TFTipoClienteDescricao_Sel, AV52TFClienteStatus_Sel, AV62TFClienteQtdTitulos_F, AV63TFClienteQtdTitulos_F_To, AV64TFClienteValorAPagar_F, AV65TFClienteValorAPagar_F_To, AV66TFClienteValorAReceber_F, AV67TFClienteValorAReceber_F_To, AV10GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E22502( )
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

      protected void E11502( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpTituloCLienteFilters")) + "," + UrlEncode(StringUtil.RTrim(AV89Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpTituloCLienteFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV40ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpTituloCLienteFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV40ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV40ManageFiltersXml) ;
               AV10GridState.FromXml(AV40ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFClienteTipoPessoa_Sels", AV47TFClienteTipoPessoa_Sels);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
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
         edtavSecusername1_Visible = 0;
         AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
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
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
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
         edtavSecusername2_Visible = 0;
         AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
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
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento2_Visible = 1;
            AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao2_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao2_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome2_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome2_Visible = 1;
            AssignProp("", false, edtavMunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo2_Visible = 1;
            AssignProp("", false, edtavBancocodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome2_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         edtavSecusername3_Visible = 0;
         AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
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
         if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento3_Visible = 1;
            AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao3_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao3_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome3_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome3_Visible = 1;
            AssignProp("", false, edtavMunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo3_Visible = 1;
            AssignProp("", false, edtavBancocodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome3_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25ClienteDocumento2 = "";
         AssignAttri("", false, "AV25ClienteDocumento2", AV25ClienteDocumento2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         AV30DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AV32ClienteDocumento3 = "";
         AssignAttri("", false, "AV32ClienteDocumento3", AV32ClienteDocumento3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV39ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpTituloCLienteFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV39ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV42TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV42TFClienteRazaoSocial", AV42TFClienteRazaoSocial);
         AV43TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV43TFClienteRazaoSocial_Sel", AV43TFClienteRazaoSocial_Sel);
         AV44TFClienteNomeFantasia = "";
         AssignAttri("", false, "AV44TFClienteNomeFantasia", AV44TFClienteNomeFantasia);
         AV45TFClienteNomeFantasia_Sel = "";
         AssignAttri("", false, "AV45TFClienteNomeFantasia_Sel", AV45TFClienteNomeFantasia_Sel);
         AV47TFClienteTipoPessoa_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48TFClienteDocumento = "";
         AssignAttri("", false, "AV48TFClienteDocumento", AV48TFClienteDocumento);
         AV49TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV49TFClienteDocumento_Sel", AV49TFClienteDocumento_Sel);
         AV50TFTipoClienteDescricao = "";
         AssignAttri("", false, "AV50TFTipoClienteDescricao", AV50TFTipoClienteDescricao);
         AV51TFTipoClienteDescricao_Sel = "";
         AssignAttri("", false, "AV51TFTipoClienteDescricao_Sel", AV51TFTipoClienteDescricao_Sel);
         AV52TFClienteStatus_Sel = 0;
         AssignAttri("", false, "AV52TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV52TFClienteStatus_Sel), 1, 0));
         AV62TFClienteQtdTitulos_F = 0;
         AssignAttri("", false, "AV62TFClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0));
         AV63TFClienteQtdTitulos_F_To = 0;
         AssignAttri("", false, "AV63TFClienteQtdTitulos_F_To", StringUtil.LTrimStr( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0));
         AV64TFClienteValorAPagar_F = 0;
         AssignAttri("", false, "AV64TFClienteValorAPagar_F", StringUtil.LTrimStr( AV64TFClienteValorAPagar_F, 18, 2));
         AV65TFClienteValorAPagar_F_To = 0;
         AssignAttri("", false, "AV65TFClienteValorAPagar_F_To", StringUtil.LTrimStr( AV65TFClienteValorAPagar_F_To, 18, 2));
         AV66TFClienteValorAReceber_F = 0;
         AssignAttri("", false, "AV66TFClienteValorAReceber_F", StringUtil.LTrimStr( AV66TFClienteValorAReceber_F, 18, 2));
         AV67TFClienteValorAReceber_F_To = 0;
         AssignAttri("", false, "AV67TFClienteValorAReceber_F_To", StringUtil.LTrimStr( AV67TFClienteValorAReceber_F_To, 18, 2));
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

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get(AV89Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV89Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV38Session.Get(AV89Pgmname+"GridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV42TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFClienteRazaoSocial", AV42TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV43TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFClienteRazaoSocial_Sel", AV43TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA") == 0 )
            {
               AV44TFClienteNomeFantasia = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFClienteNomeFantasia", AV44TFClienteNomeFantasia);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA_SEL") == 0 )
            {
               AV45TFClienteNomeFantasia_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFClienteNomeFantasia_Sel", AV45TFClienteNomeFantasia_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV46TFClienteTipoPessoa_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFClienteTipoPessoa_SelsJson", AV46TFClienteTipoPessoa_SelsJson);
               AV47TFClienteTipoPessoa_Sels.FromJSonString(AV46TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV48TFClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFClienteDocumento", AV48TFClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV49TFClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFClienteDocumento_Sel", AV49TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV50TFTipoClienteDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFTipoClienteDescricao", AV50TFTipoClienteDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV51TFTipoClienteDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFTipoClienteDescricao_Sel", AV51TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV52TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV52TFClienteStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEQTDTITULOS_F") == 0 )
            {
               AV62TFClienteQtdTitulos_F = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV62TFClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0));
               AV63TFClienteQtdTitulos_F_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV63TFClienteQtdTitulos_F_To", StringUtil.LTrimStr( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEVALORAPAGAR_F") == 0 )
            {
               AV64TFClienteValorAPagar_F = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV64TFClienteValorAPagar_F", StringUtil.LTrimStr( AV64TFClienteValorAPagar_F, 18, 2));
               AV65TFClienteValorAPagar_F_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV65TFClienteValorAPagar_F_To", StringUtil.LTrimStr( AV65TFClienteValorAPagar_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEVALORARECEBER_F") == 0 )
            {
               AV66TFClienteValorAReceber_F = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV66TFClienteValorAReceber_F", StringUtil.LTrimStr( AV66TFClienteValorAReceber_F, 18, 2));
               AV67TFClienteValorAReceber_F_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV67TFClienteValorAReceber_F_To", StringUtil.LTrimStr( AV67TFClienteValorAReceber_F_To, 18, 2));
            }
            AV148GXV1 = (int)(AV148GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteRazaoSocial_Sel)),  AV43TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFClienteNomeFantasia_Sel)),  AV45TFClienteNomeFantasia_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFClienteTipoPessoa_Sels.Count==0),  AV46TFClienteTipoPessoa_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFClienteDocumento_Sel)),  AV49TFClienteDocumento_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipoClienteDescricao_Sel)),  AV51TFTipoClienteDescricao_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+((0==AV52TFClienteStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV52TFClienteStatus_Sel), 1, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial)),  AV42TFClienteRazaoSocial, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteNomeFantasia)),  AV44TFClienteNomeFantasia, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFClienteDocumento)),  AV48TFClienteDocumento, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTipoClienteDescricao)),  AV50TFTipoClienteDescricao, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"||"+GXt_char5+"|"+GXt_char4+"||"+((0==AV62TFClienteQtdTitulos_F) ? "" : StringUtil.Str( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0))+"|"+((Convert.ToDecimal(0)==AV64TFClienteValorAPagar_F) ? "" : StringUtil.Str( AV64TFClienteValorAPagar_F, 18, 2))+"|"+((Convert.ToDecimal(0)==AV66TFClienteValorAReceber_F) ? "" : StringUtil.Str( AV66TFClienteValorAReceber_F, 18, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||||"+((0==AV63TFClienteQtdTitulos_F_To) ? "" : StringUtil.Str( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0))+"|"+((Convert.ToDecimal(0)==AV65TFClienteValorAPagar_F_To) ? "" : StringUtil.Str( AV65TFClienteValorAPagar_F_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV67TFClienteValorAReceber_F_To) ? "" : StringUtil.Str( AV67TFClienteValorAReceber_F_To, 18, 2));
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
               AV68ClienteConvenioDescricao1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV68ClienteConvenioDescricao1", AV68ClienteConvenioDescricao1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV69ClienteNacionalidadeNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV69ClienteNacionalidadeNome1", AV69ClienteNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV70ClienteProfissaoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV70ClienteProfissaoNome1", AV70ClienteProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20SecUserName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20SecUserName1", AV20SecUserName1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV21MunicipioNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21MunicipioNome1", AV21MunicipioNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV71BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV71BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV71BancoCodigo1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV72ResponsavelNacionalidadeNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV72ResponsavelNacionalidadeNome1", AV72ResponsavelNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV73ResponsavelProfissaoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV73ResponsavelProfissaoNome1", AV73ResponsavelProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV74ResponsavelMunicipioNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV74ResponsavelMunicipioNome1", AV74ResponsavelMunicipioNome1);
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25ClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ClienteDocumento2", AV25ClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26TipoClienteDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26TipoClienteDescricao2", AV26TipoClienteDescricao2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV75ClienteConvenioDescricao2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV75ClienteConvenioDescricao2", AV75ClienteConvenioDescricao2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV76ClienteNacionalidadeNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV76ClienteNacionalidadeNome2", AV76ClienteNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV77ClienteProfissaoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV77ClienteProfissaoNome2", AV77ClienteProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV27SecUserName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27SecUserName2", AV27SecUserName2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV28MunicipioNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28MunicipioNome2", AV28MunicipioNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV78BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV78BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV78BancoCodigo2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV79ResponsavelNacionalidadeNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV79ResponsavelNacionalidadeNome2", AV79ResponsavelNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV80ResponsavelProfissaoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV80ResponsavelProfissaoNome2", AV80ResponsavelProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV81ResponsavelMunicipioNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV81ResponsavelMunicipioNome2", AV81ResponsavelMunicipioNome2);
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
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV32ClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32ClienteDocumento3", AV32ClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV33TipoClienteDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV33TipoClienteDescricao3", AV33TipoClienteDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV82ClienteConvenioDescricao3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV82ClienteConvenioDescricao3", AV82ClienteConvenioDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV83ClienteNacionalidadeNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV83ClienteNacionalidadeNome3", AV83ClienteNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV84ClienteProfissaoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV84ClienteProfissaoNome3", AV84ClienteProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV34SecUserName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34SecUserName3", AV34SecUserName3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV35MunicipioNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35MunicipioNome3", AV35MunicipioNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV85BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV85BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV85BancoCodigo3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV86ResponsavelNacionalidadeNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV86ResponsavelNacionalidadeNome3", AV86ResponsavelNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV87ResponsavelProfissaoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV87ResponsavelProfissaoNome3", AV87ResponsavelProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV88ResponsavelMunicipioNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV88ResponsavelMunicipioNome3", AV88ResponsavelMunicipioNome3);
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
         AV10GridState.FromXml(AV38Session.Get(AV89Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial)),  0,  AV42TFClienteRazaoSocial,  AV42TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteRazaoSocial_Sel)),  AV43TFClienteRazaoSocial_Sel,  AV43TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTENOMEFANTASIA",  "Nome fantasia",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteNomeFantasia)),  0,  AV44TFClienteNomeFantasia,  AV44TFClienteNomeFantasia,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFClienteNomeFantasia_Sel)),  AV45TFClienteNomeFantasia_Sel,  AV45TFClienteNomeFantasia_Sel) ;
         AV61AuxText = ((AV47TFClienteTipoPessoa_Sels.Count==1) ? "["+((string)AV47TFClienteTipoPessoa_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETIPOPESSOA_SEL",  "Tipo pessoa",  !(AV47TFClienteTipoPessoa_Sels.Count==0),  0,  AV47TFClienteTipoPessoa_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV61AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV61AuxText, "[FISICA]", "Física"), "[JURIDICA]", "Jurídica")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTEDOCUMENTO",  "Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFClienteDocumento)),  0,  AV48TFClienteDocumento,  AV48TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFClienteDocumento_Sel)),  AV49TFClienteDocumento_Sel,  AV49TFClienteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPOCLIENTEDESCRICAO",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTipoClienteDescricao)),  0,  AV50TFTipoClienteDescricao,  AV50TFTipoClienteDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipoClienteDescricao_Sel)),  AV51TFTipoClienteDescricao_Sel,  AV51TFTipoClienteDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTESTATUS_SEL",  "Status",  !(0==AV52TFClienteStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV52TFClienteStatus_Sel), 1, 0)),  ((AV52TFClienteStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTEQTDTITULOS_F",  "Quantidade de títulos",  !((0==AV62TFClienteQtdTitulos_F)&&(0==AV63TFClienteQtdTitulos_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV62TFClienteQtdTitulos_F), 9, 0)),  ((0==AV62TFClienteQtdTitulos_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV62TFClienteQtdTitulos_F), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV63TFClienteQtdTitulos_F_To), 9, 0)),  ((0==AV63TFClienteQtdTitulos_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV63TFClienteQtdTitulos_F_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTEVALORAPAGAR_F",  "Total a pagar",  !((Convert.ToDecimal(0)==AV64TFClienteValorAPagar_F)&&(Convert.ToDecimal(0)==AV65TFClienteValorAPagar_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV64TFClienteValorAPagar_F, 18, 2)),  ((Convert.ToDecimal(0)==AV64TFClienteValorAPagar_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV64TFClienteValorAPagar_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV65TFClienteValorAPagar_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV65TFClienteValorAPagar_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV65TFClienteValorAPagar_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTEVALORARECEBER_F",  "Total a receber",  !((Convert.ToDecimal(0)==AV66TFClienteValorAReceber_F)&&(Convert.ToDecimal(0)==AV67TFClienteValorAReceber_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV66TFClienteValorAReceber_F, 18, 2)),  ((Convert.ToDecimal(0)==AV66TFClienteValorAReceber_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV66TFClienteValorAReceber_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV67TFClienteValorAReceber_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV67TFClienteValorAReceber_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV67TFClienteValorAReceber_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV17DynamicFiltersOperator1,  AV18ClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18ClienteDocumento1, "Contém"+" "+AV18ClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TipoClienteDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV17DynamicFiltersOperator1,  AV19TipoClienteDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19TipoClienteDescricao1, "Contém"+" "+AV19TipoClienteDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ClienteConvenioDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV17DynamicFiltersOperator1,  AV68ClienteConvenioDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV68ClienteConvenioDescricao1, "Contém"+" "+AV68ClienteConvenioDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV17DynamicFiltersOperator1,  AV69ClienteNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV69ClienteNacionalidadeNome1, "Contém"+" "+AV69ClienteNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV17DynamicFiltersOperator1,  AV70ClienteProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV70ClienteProfissaoNome1, "Contém"+" "+AV70ClienteProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV17DynamicFiltersOperator1,  AV20SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20SecUserName1, "Contém"+" "+AV20SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV17DynamicFiltersOperator1,  AV21MunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21MunicipioNome1, "Contém"+" "+AV21MunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ! (0==AV71BancoCodigo1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV71BancoCodigo1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71BancoCodigo1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71BancoCodigo1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV71BancoCodigo1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV72ResponsavelNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV17DynamicFiltersOperator1,  AV72ResponsavelNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV72ResponsavelNacionalidadeNome1, "Contém"+" "+AV72ResponsavelNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV73ResponsavelProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV17DynamicFiltersOperator1,  AV73ResponsavelProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV73ResponsavelProfissaoNome1, "Contém"+" "+AV73ResponsavelProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelMunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV17DynamicFiltersOperator1,  AV74ResponsavelMunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV74ResponsavelMunicipioNome1, "Contém"+" "+AV74ResponsavelMunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV24DynamicFiltersOperator2,  AV25ClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV25ClienteDocumento2, "Contém"+" "+AV25ClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TipoClienteDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV24DynamicFiltersOperator2,  AV26TipoClienteDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV26TipoClienteDescricao2, "Contém"+" "+AV26TipoClienteDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ClienteConvenioDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV24DynamicFiltersOperator2,  AV75ClienteConvenioDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV75ClienteConvenioDescricao2, "Contém"+" "+AV75ClienteConvenioDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ClienteNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV24DynamicFiltersOperator2,  AV76ClienteNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV76ClienteNacionalidadeNome2, "Contém"+" "+AV76ClienteNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV77ClienteProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV24DynamicFiltersOperator2,  AV77ClienteProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV77ClienteProfissaoNome2, "Contém"+" "+AV77ClienteProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV24DynamicFiltersOperator2,  AV27SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV27SecUserName2, "Contém"+" "+AV27SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV24DynamicFiltersOperator2,  AV28MunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV28MunicipioNome2, "Contém"+" "+AV28MunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ! (0==AV78BancoCodigo2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV24DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV78BancoCodigo2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV78BancoCodigo2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV78BancoCodigo2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV78BancoCodigo2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV79ResponsavelNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV24DynamicFiltersOperator2,  AV79ResponsavelNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV79ResponsavelNacionalidadeNome2, "Contém"+" "+AV79ResponsavelNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ResponsavelProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV24DynamicFiltersOperator2,  AV80ResponsavelProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV80ResponsavelProfissaoNome2, "Contém"+" "+AV80ResponsavelProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV81ResponsavelMunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV24DynamicFiltersOperator2,  AV81ResponsavelMunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV81ResponsavelMunicipioNome2, "Contém"+" "+AV81ResponsavelMunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV31DynamicFiltersOperator3,  AV32ClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV32ClienteDocumento3, "Contém"+" "+AV32ClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TipoClienteDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Descrição",  AV31DynamicFiltersOperator3,  AV33TipoClienteDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV33TipoClienteDescricao3, "Contém"+" "+AV33TipoClienteDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Descricao",  AV31DynamicFiltersOperator3,  AV82ClienteConvenioDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV82ClienteConvenioDescricao3, "Contém"+" "+AV82ClienteConvenioDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV31DynamicFiltersOperator3,  AV83ClienteNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV83ClienteNacionalidadeNome3, "Contém"+" "+AV83ClienteNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV31DynamicFiltersOperator3,  AV84ClienteProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV84ClienteProfissaoNome3, "Contém"+" "+AV84ClienteProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV31DynamicFiltersOperator3,  AV34SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV34SecUserName3, "Contém"+" "+AV34SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35MunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV31DynamicFiltersOperator3,  AV35MunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV35MunicipioNome3, "Contém"+" "+AV35MunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ! (0==AV85BancoCodigo3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Banco Codigo",  AV31DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV85BancoCodigo3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV85BancoCodigo3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV85BancoCodigo3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV85BancoCodigo3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV86ResponsavelNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nacionalidade Nome",  AV31DynamicFiltersOperator3,  AV86ResponsavelNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV86ResponsavelNacionalidadeNome3, "Contém"+" "+AV86ResponsavelNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Profissao Nome",  AV31DynamicFiltersOperator3,  AV87ResponsavelProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV87ResponsavelProfissaoNome3, "Contém"+" "+AV87ResponsavelProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelMunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Municipio Nome",  AV31DynamicFiltersOperator3,  AV88ResponsavelMunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV88ResponsavelMunicipioNome3, "Contém"+" "+AV88ResponsavelMunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV89Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Cliente";
         AV38Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_143_502( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento3_Internalname, "Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento3_Internalname, AV32ClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV32ClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento3_Visible, edtavClientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao3_Internalname, "Tipo Cliente Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao3_Internalname, AV33TipoClienteDescricao3, StringUtil.RTrim( context.localUtil.Format( AV33TipoClienteDescricao3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao3_Visible, edtavTipoclientedescricao3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao3_Internalname, "Cliente Convenio Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao3_Internalname, AV82ClienteConvenioDescricao3, StringUtil.RTrim( context.localUtil.Format( AV82ClienteConvenioDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao3_Visible, edtavClienteconveniodescricao3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome3_Internalname, "Cliente Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome3_Internalname, AV83ClienteNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV83ClienteNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome3_Visible, edtavClientenacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome3_Internalname, "Cliente Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome3_Internalname, AV84ClienteProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV84ClienteProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome3_Visible, edtavClienteprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV34SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV34SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome3_Internalname, "Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome3_Internalname, AV35MunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV35MunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome3_Visible, edtavMunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo3_Internalname, "Banco Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85BancoCodigo3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV85BancoCodigo3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV85BancoCodigo3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo3_Visible, edtavBancocodigo3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome3_Internalname, "Responsavel Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome3_Internalname, AV86ResponsavelNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV86ResponsavelNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome3_Visible, edtavResponsavelnacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome3_Internalname, "Responsavel Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome3_Internalname, AV87ResponsavelProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV87ResponsavelProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome3_Visible, edtavResponsavelprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome3_Internalname, "Responsavel Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome3_Internalname, AV88ResponsavelMunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV88ResponsavelMunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome3_Visible, edtavResponsavelmunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpTituloCLiente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_143_502e( true) ;
         }
         else
         {
            wb_table3_143_502e( false) ;
         }
      }

      protected void wb_table2_91_502( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento2_Internalname, "Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento2_Internalname, AV25ClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV25ClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento2_Visible, edtavClientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao2_Internalname, "Tipo Cliente Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao2_Internalname, AV26TipoClienteDescricao2, StringUtil.RTrim( context.localUtil.Format( AV26TipoClienteDescricao2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao2_Visible, edtavTipoclientedescricao2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao2_Internalname, "Cliente Convenio Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao2_Internalname, AV75ClienteConvenioDescricao2, StringUtil.RTrim( context.localUtil.Format( AV75ClienteConvenioDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao2_Visible, edtavClienteconveniodescricao2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome2_Internalname, "Cliente Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome2_Internalname, AV76ClienteNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV76ClienteNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome2_Visible, edtavClientenacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome2_Internalname, "Cliente Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome2_Internalname, AV77ClienteProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV77ClienteProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome2_Visible, edtavClienteprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV27SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV27SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome2_Internalname, "Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome2_Internalname, AV28MunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV28MunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome2_Visible, edtavMunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo2_Internalname, "Banco Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78BancoCodigo2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV78BancoCodigo2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV78BancoCodigo2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo2_Visible, edtavBancocodigo2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome2_Internalname, "Responsavel Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome2_Internalname, AV79ResponsavelNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV79ResponsavelNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome2_Visible, edtavResponsavelnacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome2_Internalname, "Responsavel Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome2_Internalname, AV80ResponsavelProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV80ResponsavelProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome2_Visible, edtavResponsavelprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome2_Internalname, "Responsavel Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome2_Internalname, AV81ResponsavelMunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV81ResponsavelMunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome2_Visible, edtavResponsavelmunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpTituloCLiente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpTituloCLiente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_91_502e( true) ;
         }
         else
         {
            wb_table2_91_502e( false) ;
         }
      }

      protected void wb_table1_39_502( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_191_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WpTituloCLiente.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento1_Internalname, AV18ClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV18ClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento1_Visible, edtavClientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao1_Internalname, "Tipo Cliente Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao1_Internalname, AV19TipoClienteDescricao1, StringUtil.RTrim( context.localUtil.Format( AV19TipoClienteDescricao1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao1_Visible, edtavTipoclientedescricao1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao1_Internalname, "Cliente Convenio Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao1_Internalname, AV68ClienteConvenioDescricao1, StringUtil.RTrim( context.localUtil.Format( AV68ClienteConvenioDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao1_Visible, edtavClienteconveniodescricao1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome1_Internalname, "Cliente Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome1_Internalname, AV69ClienteNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV69ClienteNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome1_Visible, edtavClientenacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome1_Internalname, "Cliente Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome1_Internalname, AV70ClienteProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV70ClienteProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome1_Visible, edtavClienteprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV20SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV20SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome1_Internalname, "Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome1_Internalname, AV21MunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV21MunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome1_Visible, edtavMunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo1_Internalname, "Banco Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71BancoCodigo1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV71BancoCodigo1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV71BancoCodigo1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo1_Visible, edtavBancocodigo1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome1_Internalname, "Responsavel Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome1_Internalname, AV72ResponsavelNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV72ResponsavelNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome1_Visible, edtavResponsavelnacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome1_Internalname, "Responsavel Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome1_Internalname, AV73ResponsavelProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV73ResponsavelProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome1_Visible, edtavResponsavelprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome1_Internalname, "Responsavel Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_191_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome1_Internalname, AV74ResponsavelMunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV74ResponsavelMunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome1_Visible, edtavResponsavelmunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTituloCLiente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpTituloCLiente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpTituloCLiente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_502e( true) ;
         }
         else
         {
            wb_table1_39_502e( false) ;
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
         PA502( ) ;
         WS502( ) ;
         WE502( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019255022", true, true);
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
         context.AddJavascriptSource("wptitulocliente.js", "?202561019255023", false, true);
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

      protected void SubsflControlProps_1912( )
      {
         edtavTitulos_Internalname = "vTITULOS_"+sGXsfl_191_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_191_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_191_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_191_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_191_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_191_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_191_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_191_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_191_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_191_idx;
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT_"+sGXsfl_191_idx;
         edtClienteLogUser_Internalname = "CLIENTELOGUSER_"+sGXsfl_191_idx;
         edtClienteQtdTitulos_F_Internalname = "CLIENTEQTDTITULOS_F_"+sGXsfl_191_idx;
         edtClienteValorAPagar_F_Internalname = "CLIENTEVALORAPAGAR_F_"+sGXsfl_191_idx;
         edtClienteValorAReceber_F_Internalname = "CLIENTEVALORARECEBER_F_"+sGXsfl_191_idx;
      }

      protected void SubsflControlProps_fel_1912( )
      {
         edtavTitulos_Internalname = "vTITULOS_"+sGXsfl_191_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_191_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_191_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_191_fel_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_191_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_191_fel_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_191_fel_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_191_fel_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_191_fel_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_191_fel_idx;
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT_"+sGXsfl_191_fel_idx;
         edtClienteLogUser_Internalname = "CLIENTELOGUSER_"+sGXsfl_191_fel_idx;
         edtClienteQtdTitulos_F_Internalname = "CLIENTEQTDTITULOS_F_"+sGXsfl_191_fel_idx;
         edtClienteValorAPagar_F_Internalname = "CLIENTEVALORAPAGAR_F_"+sGXsfl_191_fel_idx;
         edtClienteValorAReceber_F_Internalname = "CLIENTEVALORARECEBER_F_"+sGXsfl_191_fel_idx;
      }

      protected void sendrow_1912( )
      {
         sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
         SubsflControlProps_1912( ) ;
         WB500( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_191_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_191_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_191_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'" + sGXsfl_191_idx + "',191)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTitulos_Internalname,StringUtil.RTrim( AV60Titulos),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavTitulos_Link,(string)"",(string)"Consultar títulos",(string)"",(string)edtavTitulos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavTitulos_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)191,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteTipoPessoa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_191_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteTipoPessoa,(string)cmbClienteTipoPessoa_Internalname,StringUtil.RTrim( A172ClienteTipoPessoa),(short)1,(string)cmbClienteTipoPessoa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A172ClienteTipoPessoa);
            AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", (string)(cmbClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_191_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtClienteDocumento_Link,(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteDescricao_Internalname,(string)A193TipoClienteDescricao,StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipoClienteDescricao_Link,(string)"",(string)"",(string)"",(string)edtTipoClienteDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESTATUS_" + sGXsfl_191_idx;
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
            AssignProp("", false, cmbClienteStatus_Internalname, "Values", (string)(cmbClienteStatus.ToJavascriptSource()), !bGXsfl_191_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCreatedAt_Internalname,context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A175ClienteCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteUpdatedAt_Internalname,context.localUtil.TToC( A176ClienteUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A176ClienteUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteLogUser_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A177ClienteLogUser), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A177ClienteLogUser), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteLogUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteQtdTitulos_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A309ClienteQtdTitulos_F), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A309ClienteQtdTitulos_F), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteQtdTitulos_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteValorAPagar_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A310ClienteValorAPagar_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A310ClienteValorAPagar_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteValorAPagar_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteValorAReceber_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A311ClienteValorAReceber_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A311ClienteValorAReceber_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteValorAReceber_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)191,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes502( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_191_idx = ((subGrid_Islastpage==1)&&(nGXsfl_191_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_191_idx+1);
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1912( ) ;
         }
         /* End function sendrow_1912 */
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
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usuário", 0);
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
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector2.addItem("MUNICIPIONOME", "Municipio Nome", 0);
         cmbavDynamicfiltersselector2.addItem("BANCOCODIGO", "Banco Codigo", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELNACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector2.addItem("RESPONSAVELMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector3.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTECONVENIODESCRICAO", "Convenio Descricao", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTENACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTEPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector3.addItem("MUNICIPIONOME", "Municipio Nome", 0);
         cmbavDynamicfiltersselector3.addItem("BANCOCODIGO", "Banco Codigo", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELNACIONALIDADENOME", "Nacionalidade Nome", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELPROFISSAONOME", "Profissao Nome", 0);
         cmbavDynamicfiltersselector3.addItem("RESPONSAVELMUNICIPIONOME", "Municipio Nome", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_191_idx;
         cmbClienteTipoPessoa.Name = GXCCtl;
         cmbClienteTipoPessoa.WebTags = "";
         cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
         }
         GXCCtl = "CLIENTESTATUS_" + sGXsfl_191_idx;
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

      protected void StartGridControl191( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"191\">") ;
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
            context.SendWebValue( "Razão social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo pessoa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Criação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Atualização") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Usuário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantidade de títulos") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total a pagar") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total a receber") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV60Titulos)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTitulos_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavTitulos_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A169ClienteDocumento));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtClienteDocumento_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193TipoClienteDescricao));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipoClienteDescricao_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A174ClienteStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbClienteStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbClienteStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A176ClienteUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A177ClienteLogUser), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A309ClienteQtdTitulos_F), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A310ClienteValorAPagar_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A311ClienteValorAReceber_F, 18, 2, ".", ""))));
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
         edtavSecusername1_Internalname = "vSECUSERNAME1";
         cellFilter_secusername1_cell_Internalname = "FILTER_SECUSERNAME1_CELL";
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
         edtavSecusername2_Internalname = "vSECUSERNAME2";
         cellFilter_secusername2_cell_Internalname = "FILTER_SECUSERNAME2_CELL";
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
         edtavSecusername3_Internalname = "vSECUSERNAME3";
         cellFilter_secusername3_cell_Internalname = "FILTER_SECUSERNAME3_CELL";
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
         edtavTitulos_Internalname = "vTITULOS";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtTipoClienteId_Internalname = "TIPOCLIENTEID";
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         cmbClienteStatus_Internalname = "CLIENTESTATUS";
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT";
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT";
         edtClienteLogUser_Internalname = "CLIENTELOGUSER";
         edtClienteQtdTitulos_F_Internalname = "CLIENTEQTDTITULOS_F";
         edtClienteValorAPagar_F_Internalname = "CLIENTEVALORAPAGAR_F";
         edtClienteValorAReceber_F_Internalname = "CLIENTEVALORARECEBER_F";
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
         edtClienteValorAReceber_F_Jsonclick = "";
         edtClienteValorAPagar_F_Jsonclick = "";
         edtClienteQtdTitulos_F_Jsonclick = "";
         edtClienteLogUser_Jsonclick = "";
         edtClienteUpdatedAt_Jsonclick = "";
         edtClienteCreatedAt_Jsonclick = "";
         cmbClienteStatus_Jsonclick = "";
         cmbClienteStatus_Columnclass = "WWColumn";
         edtTipoClienteDescricao_Jsonclick = "";
         edtTipoClienteDescricao_Link = "";
         edtTipoClienteId_Jsonclick = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteDocumento_Link = "";
         cmbClienteTipoPessoa_Jsonclick = "";
         edtClienteNomeFantasia_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtavTitulos_Jsonclick = "";
         edtavTitulos_Link = "";
         edtavTitulos_Enabled = 0;
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
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
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
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
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
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
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
         edtavSecusername3_Visible = 1;
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
         edtavSecusername2_Visible = 1;
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
         edtavSecusername1_Visible = 1;
         edtavClienteprofissaonome1_Visible = 1;
         edtavClientenacionalidadenome1_Visible = 1;
         edtavClienteconveniodescricao1_Visible = 1;
         edtavTipoclientedescricao1_Visible = 1;
         edtavClientedocumento1_Visible = 1;
         cmbClienteStatus_Columnheaderclass = "";
         edtClienteValorAReceber_F_Enabled = 0;
         edtClienteValorAPagar_F_Enabled = 0;
         edtClienteQtdTitulos_F_Enabled = 0;
         edtClienteLogUser_Enabled = 0;
         edtClienteUpdatedAt_Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         cmbClienteStatus.Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         edtTipoClienteId_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Enabled = 0;
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
         Ddo_grid_Format = "||||||9.0|18.2|18.2";
         Ddo_grid_Datalistproc = "WpTituloCLienteGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||FISICA:Física,JURIDICA:Jurídica|||1:WWP_TSChecked,2:WWP_TSUnChecked|||";
         Ddo_grid_Allowmultipleselection = "||T||||||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|Dynamic|Dynamic|FixedValues|||";
         Ddo_grid_Includedatalist = "T|T|T|T|T|T|||";
         Ddo_grid_Filterisrange = "||||||T|T|T";
         Ddo_grid_Filtertype = "Character|Character||Character|Character||Numeric|Numeric|Numeric";
         Ddo_grid_Includefilter = "T|T||T|T||T|T|T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|||";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|||";
         Ddo_grid_Columnids = "2:ClienteRazaoSocial|3:ClienteNomeFantasia|4:ClienteTipoPessoa|5:ClienteDocumento|7:TipoClienteDescricao|8:ClienteStatus|12:ClienteQtdTitulos_F|13:ClienteValorAPagar_F|14:ClienteValorAReceber_F";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV46TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E25502","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbClienteStatus"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV60Titulos","fld":"vTITULOS","type":"char"},{"av":"edtavTitulos_Link","ctrl":"vTITULOS","prop":"Link"},{"av":"edtClienteDocumento_Link","ctrl":"CLIENTEDOCUMENTO","prop":"Link"},{"av":"edtTipoClienteDescricao_Link","ctrl":"TIPOCLIENTEDESCRICAO","prop":"Link"},{"av":"cmbClienteStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E18502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E19502","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E20502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E21502","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E22502","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11502","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV46TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteNomeFantasia","fld":"vTFCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV45TFClienteNomeFantasia_Sel","fld":"vTFCLIENTENOMEFANTASIA_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV48TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV49TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV50TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV51TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV52TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV62TFClienteQtdTitulos_F","fld":"vTFCLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV63TFClienteQtdTitulos_F_To","fld":"vTFCLIENTEQTDTITULOS_F_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV64TFClienteValorAPagar_F","fld":"vTFCLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFClienteValorAPagar_F_To","fld":"vTFCLIENTEVALORAPAGAR_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV66TFClienteValorAReceber_F","fld":"vTFCLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV67TFClienteValorAReceber_F_To","fld":"vTFCLIENTEVALORARECEBER_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV46TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV74ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV73ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV72ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV71BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV20SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV70ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV69ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV68ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV19TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV81ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV80ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV79ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV78BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV77ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV76ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV75ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV26TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV29DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV30DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV31DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV88ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV87ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV86ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV85BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV34SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV84ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV83ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV82ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV33TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV32ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"AV57GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTEID","""{"handler":"Valid_Tipoclienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Clientevalorareceber_f","iparms":[]}""");
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
         AV68ClienteConvenioDescricao1 = "";
         AV69ClienteNacionalidadeNome1 = "";
         AV70ClienteProfissaoNome1 = "";
         AV20SecUserName1 = "";
         AV21MunicipioNome1 = "";
         AV72ResponsavelNacionalidadeNome1 = "";
         AV73ResponsavelProfissaoNome1 = "";
         AV74ResponsavelMunicipioNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ClienteDocumento2 = "";
         AV26TipoClienteDescricao2 = "";
         AV75ClienteConvenioDescricao2 = "";
         AV76ClienteNacionalidadeNome2 = "";
         AV77ClienteProfissaoNome2 = "";
         AV27SecUserName2 = "";
         AV28MunicipioNome2 = "";
         AV79ResponsavelNacionalidadeNome2 = "";
         AV80ResponsavelProfissaoNome2 = "";
         AV81ResponsavelMunicipioNome2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32ClienteDocumento3 = "";
         AV33TipoClienteDescricao3 = "";
         AV82ClienteConvenioDescricao3 = "";
         AV83ClienteNacionalidadeNome3 = "";
         AV84ClienteProfissaoNome3 = "";
         AV34SecUserName3 = "";
         AV35MunicipioNome3 = "";
         AV86ResponsavelNacionalidadeNome3 = "";
         AV87ResponsavelProfissaoNome3 = "";
         AV88ResponsavelMunicipioNome3 = "";
         AV89Pgmname = "";
         AV15FilterFullText = "";
         AV42TFClienteRazaoSocial = "";
         AV43TFClienteRazaoSocial_Sel = "";
         AV44TFClienteNomeFantasia = "";
         AV45TFClienteNomeFantasia_Sel = "";
         AV47TFClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV48TFClienteDocumento = "";
         AV49TFClienteDocumento_Sel = "";
         AV50TFTipoClienteDescricao = "";
         AV51TFTipoClienteDescricao_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV39ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59GridAppliedFilters = "";
         AV55DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV46TFClienteTipoPessoa_SelsJson = "";
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
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         ClassString = "";
         StyleString = "";
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
         AV60Titulos = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         A172ClienteTipoPessoa = "";
         A169ClienteDocumento = "";
         A193TipoClienteDescricao = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         AV136Wptituloclienteds_47_tfclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV90Wptituloclienteds_1_filterfulltext = "";
         lV93Wptituloclienteds_4_clientedocumento1 = "";
         lV94Wptituloclienteds_5_tipoclientedescricao1 = "";
         lV95Wptituloclienteds_6_clienteconveniodescricao1 = "";
         lV96Wptituloclienteds_7_clientenacionalidadenome1 = "";
         lV97Wptituloclienteds_8_clienteprofissaonome1 = "";
         lV98Wptituloclienteds_9_secusername1 = "";
         lV99Wptituloclienteds_10_municipionome1 = "";
         lV101Wptituloclienteds_12_responsavelnacionalidadenome1 = "";
         lV102Wptituloclienteds_13_responsavelprofissaonome1 = "";
         lV103Wptituloclienteds_14_responsavelmunicipionome1 = "";
         lV107Wptituloclienteds_18_clientedocumento2 = "";
         lV108Wptituloclienteds_19_tipoclientedescricao2 = "";
         lV109Wptituloclienteds_20_clienteconveniodescricao2 = "";
         lV110Wptituloclienteds_21_clientenacionalidadenome2 = "";
         lV111Wptituloclienteds_22_clienteprofissaonome2 = "";
         lV112Wptituloclienteds_23_secusername2 = "";
         lV113Wptituloclienteds_24_municipionome2 = "";
         lV115Wptituloclienteds_26_responsavelnacionalidadenome2 = "";
         lV116Wptituloclienteds_27_responsavelprofissaonome2 = "";
         lV117Wptituloclienteds_28_responsavelmunicipionome2 = "";
         lV121Wptituloclienteds_32_clientedocumento3 = "";
         lV122Wptituloclienteds_33_tipoclientedescricao3 = "";
         lV123Wptituloclienteds_34_clienteconveniodescricao3 = "";
         lV124Wptituloclienteds_35_clientenacionalidadenome3 = "";
         lV125Wptituloclienteds_36_clienteprofissaonome3 = "";
         lV126Wptituloclienteds_37_secusername3 = "";
         lV127Wptituloclienteds_38_municipionome3 = "";
         lV129Wptituloclienteds_40_responsavelnacionalidadenome3 = "";
         lV130Wptituloclienteds_41_responsavelprofissaonome3 = "";
         lV131Wptituloclienteds_42_responsavelmunicipionome3 = "";
         lV132Wptituloclienteds_43_tfclienterazaosocial = "";
         lV134Wptituloclienteds_45_tfclientenomefantasia = "";
         lV137Wptituloclienteds_48_tfclientedocumento = "";
         lV139Wptituloclienteds_50_tftipoclientedescricao = "";
         AV91Wptituloclienteds_2_dynamicfiltersselector1 = "";
         AV93Wptituloclienteds_4_clientedocumento1 = "";
         AV94Wptituloclienteds_5_tipoclientedescricao1 = "";
         AV95Wptituloclienteds_6_clienteconveniodescricao1 = "";
         AV96Wptituloclienteds_7_clientenacionalidadenome1 = "";
         AV97Wptituloclienteds_8_clienteprofissaonome1 = "";
         AV98Wptituloclienteds_9_secusername1 = "";
         AV99Wptituloclienteds_10_municipionome1 = "";
         AV101Wptituloclienteds_12_responsavelnacionalidadenome1 = "";
         AV102Wptituloclienteds_13_responsavelprofissaonome1 = "";
         AV103Wptituloclienteds_14_responsavelmunicipionome1 = "";
         AV105Wptituloclienteds_16_dynamicfiltersselector2 = "";
         AV107Wptituloclienteds_18_clientedocumento2 = "";
         AV108Wptituloclienteds_19_tipoclientedescricao2 = "";
         AV109Wptituloclienteds_20_clienteconveniodescricao2 = "";
         AV110Wptituloclienteds_21_clientenacionalidadenome2 = "";
         AV111Wptituloclienteds_22_clienteprofissaonome2 = "";
         AV112Wptituloclienteds_23_secusername2 = "";
         AV113Wptituloclienteds_24_municipionome2 = "";
         AV115Wptituloclienteds_26_responsavelnacionalidadenome2 = "";
         AV116Wptituloclienteds_27_responsavelprofissaonome2 = "";
         AV117Wptituloclienteds_28_responsavelmunicipionome2 = "";
         AV119Wptituloclienteds_30_dynamicfiltersselector3 = "";
         AV121Wptituloclienteds_32_clientedocumento3 = "";
         AV122Wptituloclienteds_33_tipoclientedescricao3 = "";
         AV123Wptituloclienteds_34_clienteconveniodescricao3 = "";
         AV124Wptituloclienteds_35_clientenacionalidadenome3 = "";
         AV125Wptituloclienteds_36_clienteprofissaonome3 = "";
         AV126Wptituloclienteds_37_secusername3 = "";
         AV127Wptituloclienteds_38_municipionome3 = "";
         AV129Wptituloclienteds_40_responsavelnacionalidadenome3 = "";
         AV130Wptituloclienteds_41_responsavelprofissaonome3 = "";
         AV131Wptituloclienteds_42_responsavelmunicipionome3 = "";
         AV133Wptituloclienteds_44_tfclienterazaosocial_sel = "";
         AV132Wptituloclienteds_43_tfclienterazaosocial = "";
         AV135Wptituloclienteds_46_tfclientenomefantasia_sel = "";
         AV134Wptituloclienteds_45_tfclientenomefantasia = "";
         AV138Wptituloclienteds_49_tfclientedocumento_sel = "";
         AV137Wptituloclienteds_48_tfclientedocumento = "";
         AV140Wptituloclienteds_51_tftipoclientedescricao_sel = "";
         AV139Wptituloclienteds_50_tftipoclientedescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A141SecUserName = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         AV90Wptituloclienteds_1_filterfulltext = "";
         H00508_A186MunicipioCodigo = new string[] {""} ;
         H00508_n186MunicipioCodigo = new bool[] {false} ;
         H00508_A444ResponsavelMunicipio = new string[] {""} ;
         H00508_n444ResponsavelMunicipio = new bool[] {false} ;
         H00508_A402BancoId = new int[1] ;
         H00508_n402BancoId = new bool[] {false} ;
         H00508_A457EspecialidadeId = new int[1] ;
         H00508_n457EspecialidadeId = new bool[] {false} ;
         H00508_A597EspecialidadeCreatedBy = new short[1] ;
         H00508_n597EspecialidadeCreatedBy = new bool[] {false} ;
         H00508_A437ResponsavelNacionalidade = new int[1] ;
         H00508_n437ResponsavelNacionalidade = new bool[] {false} ;
         H00508_A484ClienteNacionalidade = new int[1] ;
         H00508_n484ClienteNacionalidade = new bool[] {false} ;
         H00508_A442ResponsavelProfissao = new int[1] ;
         H00508_n442ResponsavelProfissao = new bool[] {false} ;
         H00508_A487ClienteProfissao = new int[1] ;
         H00508_n487ClienteProfissao = new bool[] {false} ;
         H00508_A489ClienteConvenio = new int[1] ;
         H00508_n489ClienteConvenio = new bool[] {false} ;
         H00508_A445ResponsavelMunicipioNome = new string[] {""} ;
         H00508_n445ResponsavelMunicipioNome = new bool[] {false} ;
         H00508_A443ResponsavelProfissaoNome = new string[] {""} ;
         H00508_n443ResponsavelProfissaoNome = new bool[] {false} ;
         H00508_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         H00508_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         H00508_A404BancoCodigo = new int[1] ;
         H00508_n404BancoCodigo = new bool[] {false} ;
         H00508_A187MunicipioNome = new string[] {""} ;
         H00508_n187MunicipioNome = new bool[] {false} ;
         H00508_A141SecUserName = new string[] {""} ;
         H00508_n141SecUserName = new bool[] {false} ;
         H00508_A488ClienteProfissaoNome = new string[] {""} ;
         H00508_n488ClienteProfissaoNome = new bool[] {false} ;
         H00508_A485ClienteNacionalidadeNome = new string[] {""} ;
         H00508_n485ClienteNacionalidadeNome = new bool[] {false} ;
         H00508_A490ClienteConvenioDescricao = new string[] {""} ;
         H00508_n490ClienteConvenioDescricao = new bool[] {false} ;
         H00508_A177ClienteLogUser = new short[1] ;
         H00508_n177ClienteLogUser = new bool[] {false} ;
         H00508_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H00508_n176ClienteUpdatedAt = new bool[] {false} ;
         H00508_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00508_n175ClienteCreatedAt = new bool[] {false} ;
         H00508_A174ClienteStatus = new bool[] {false} ;
         H00508_n174ClienteStatus = new bool[] {false} ;
         H00508_A193TipoClienteDescricao = new string[] {""} ;
         H00508_n193TipoClienteDescricao = new bool[] {false} ;
         H00508_A192TipoClienteId = new short[1] ;
         H00508_n192TipoClienteId = new bool[] {false} ;
         H00508_A169ClienteDocumento = new string[] {""} ;
         H00508_n169ClienteDocumento = new bool[] {false} ;
         H00508_A172ClienteTipoPessoa = new string[] {""} ;
         H00508_n172ClienteTipoPessoa = new bool[] {false} ;
         H00508_A171ClienteNomeFantasia = new string[] {""} ;
         H00508_n171ClienteNomeFantasia = new bool[] {false} ;
         H00508_A170ClienteRazaoSocial = new string[] {""} ;
         H00508_n170ClienteRazaoSocial = new bool[] {false} ;
         H00508_A168ClienteId = new int[1] ;
         H00508_n168ClienteId = new bool[] {false} ;
         H00508_A311ClienteValorAReceber_F = new decimal[1] ;
         H00508_n311ClienteValorAReceber_F = new bool[] {false} ;
         H00508_A310ClienteValorAPagar_F = new decimal[1] ;
         H00508_n310ClienteValorAPagar_F = new bool[] {false} ;
         H00508_A309ClienteQtdTitulos_F = new int[1] ;
         H00508_n309ClienteQtdTitulos_F = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         H005015_AGRID_nRecordCount = new long[1] ;
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
         AV40ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV61AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptitulocliente__default(),
            new Object[][] {
                new Object[] {
               H00508_A186MunicipioCodigo, H00508_n186MunicipioCodigo, H00508_A444ResponsavelMunicipio, H00508_n444ResponsavelMunicipio, H00508_A402BancoId, H00508_n402BancoId, H00508_A457EspecialidadeId, H00508_n457EspecialidadeId, H00508_A597EspecialidadeCreatedBy, H00508_n597EspecialidadeCreatedBy,
               H00508_A437ResponsavelNacionalidade, H00508_n437ResponsavelNacionalidade, H00508_A484ClienteNacionalidade, H00508_n484ClienteNacionalidade, H00508_A442ResponsavelProfissao, H00508_n442ResponsavelProfissao, H00508_A487ClienteProfissao, H00508_n487ClienteProfissao, H00508_A489ClienteConvenio, H00508_n489ClienteConvenio,
               H00508_A445ResponsavelMunicipioNome, H00508_n445ResponsavelMunicipioNome, H00508_A443ResponsavelProfissaoNome, H00508_n443ResponsavelProfissaoNome, H00508_A438ResponsavelNacionalidadeNome, H00508_n438ResponsavelNacionalidadeNome, H00508_A404BancoCodigo, H00508_n404BancoCodigo, H00508_A187MunicipioNome, H00508_n187MunicipioNome,
               H00508_A141SecUserName, H00508_n141SecUserName, H00508_A488ClienteProfissaoNome, H00508_n488ClienteProfissaoNome, H00508_A485ClienteNacionalidadeNome, H00508_n485ClienteNacionalidadeNome, H00508_A490ClienteConvenioDescricao, H00508_n490ClienteConvenioDescricao, H00508_A177ClienteLogUser, H00508_n177ClienteLogUser,
               H00508_A176ClienteUpdatedAt, H00508_n176ClienteUpdatedAt, H00508_A175ClienteCreatedAt, H00508_n175ClienteCreatedAt, H00508_A174ClienteStatus, H00508_n174ClienteStatus, H00508_A193TipoClienteDescricao, H00508_n193TipoClienteDescricao, H00508_A192TipoClienteId, H00508_n192TipoClienteId,
               H00508_A169ClienteDocumento, H00508_n169ClienteDocumento, H00508_A172ClienteTipoPessoa, H00508_n172ClienteTipoPessoa, H00508_A171ClienteNomeFantasia, H00508_n171ClienteNomeFantasia, H00508_A170ClienteRazaoSocial, H00508_n170ClienteRazaoSocial, H00508_A168ClienteId, H00508_A311ClienteValorAReceber_F,
               H00508_n311ClienteValorAReceber_F, H00508_A310ClienteValorAPagar_F, H00508_n310ClienteValorAPagar_F, H00508_A309ClienteQtdTitulos_F, H00508_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               H005015_AGRID_nRecordCount
               }
            }
         );
         AV89Pgmname = "WpTituloCLiente";
         /* GeneXus formulas. */
         AV89Pgmname = "WpTituloCLiente";
         edtavTitulos_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV41ManageFiltersExecutionStep ;
      private short AV52TFClienteStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A192TipoClienteId ;
      private short A177ClienteLogUser ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV92Wptituloclienteds_3_dynamicfiltersoperator1 ;
      private short AV106Wptituloclienteds_17_dynamicfiltersoperator2 ;
      private short AV120Wptituloclienteds_31_dynamicfiltersoperator3 ;
      private short AV141Wptituloclienteds_52_tfclientestatus_sel ;
      private short A597EspecialidadeCreatedBy ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_191 ;
      private int nGXsfl_191_idx=1 ;
      private int AV71BancoCodigo1 ;
      private int AV78BancoCodigo2 ;
      private int AV85BancoCodigo3 ;
      private int AV62TFClienteQtdTitulos_F ;
      private int AV63TFClienteQtdTitulos_F_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A168ClienteId ;
      private int A309ClienteQtdTitulos_F ;
      private int subGrid_Islastpage ;
      private int edtavTitulos_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV136Wptituloclienteds_47_tfclientetipopessoa_sels_Count ;
      private int AV100Wptituloclienteds_11_bancocodigo1 ;
      private int AV114Wptituloclienteds_25_bancocodigo2 ;
      private int AV128Wptituloclienteds_39_bancocodigo3 ;
      private int A404BancoCodigo ;
      private int AV142Wptituloclienteds_53_tfclienteqtdtitulos_f ;
      private int AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to ;
      private int A402BancoId ;
      private int A457EspecialidadeId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtTipoClienteId_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int edtClienteCreatedAt_Enabled ;
      private int edtClienteUpdatedAt_Enabled ;
      private int edtClienteLogUser_Enabled ;
      private int edtClienteQtdTitulos_F_Enabled ;
      private int edtClienteValorAPagar_F_Enabled ;
      private int edtClienteValorAReceber_F_Enabled ;
      private int AV56PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavClientedocumento1_Visible ;
      private int edtavTipoclientedescricao1_Visible ;
      private int edtavClienteconveniodescricao1_Visible ;
      private int edtavClientenacionalidadenome1_Visible ;
      private int edtavClienteprofissaonome1_Visible ;
      private int edtavSecusername1_Visible ;
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
      private int edtavSecusername2_Visible ;
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
      private int edtavSecusername3_Visible ;
      private int edtavMunicipionome3_Visible ;
      private int edtavBancocodigo3_Visible ;
      private int edtavResponsavelnacionalidadenome3_Visible ;
      private int edtavResponsavelprofissaonome3_Visible ;
      private int edtavResponsavelmunicipionome3_Visible ;
      private int AV148GXV1 ;
      private int edtavClientedocumento3_Enabled ;
      private int edtavTipoclientedescricao3_Enabled ;
      private int edtavClienteconveniodescricao3_Enabled ;
      private int edtavClientenacionalidadenome3_Enabled ;
      private int edtavClienteprofissaonome3_Enabled ;
      private int edtavSecusername3_Enabled ;
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
      private int edtavSecusername2_Enabled ;
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
      private int edtavSecusername1_Enabled ;
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
      private long AV57GridCurrentPage ;
      private long AV58GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV64TFClienteValorAPagar_F ;
      private decimal AV65TFClienteValorAPagar_F_To ;
      private decimal AV66TFClienteValorAReceber_F ;
      private decimal AV67TFClienteValorAReceber_F_To ;
      private decimal A310ClienteValorAPagar_F ;
      private decimal A311ClienteValorAReceber_F ;
      private decimal AV144Wptituloclienteds_55_tfclientevalorapagar_f ;
      private decimal AV145Wptituloclienteds_56_tfclientevalorapagar_f_to ;
      private decimal AV146Wptituloclienteds_57_tfclientevalorareceber_f ;
      private decimal AV147Wptituloclienteds_58_tfclientevalorareceber_f_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_191_idx="0001" ;
      private string AV89Pgmname ;
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
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
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
      private string ClassString ;
      private string StyleString ;
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
      private string AV60Titulos ;
      private string edtavTitulos_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteNomeFantasia_Internalname ;
      private string cmbClienteTipoPessoa_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string edtTipoClienteId_Internalname ;
      private string edtTipoClienteDescricao_Internalname ;
      private string cmbClienteStatus_Internalname ;
      private string edtClienteCreatedAt_Internalname ;
      private string edtClienteUpdatedAt_Internalname ;
      private string edtClienteLogUser_Internalname ;
      private string edtClienteQtdTitulos_F_Internalname ;
      private string edtClienteValorAPagar_F_Internalname ;
      private string edtClienteValorAReceber_F_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavClientedocumento1_Internalname ;
      private string edtavTipoclientedescricao1_Internalname ;
      private string edtavClienteconveniodescricao1_Internalname ;
      private string edtavClientenacionalidadenome1_Internalname ;
      private string edtavClienteprofissaonome1_Internalname ;
      private string edtavSecusername1_Internalname ;
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
      private string edtavSecusername2_Internalname ;
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
      private string edtavSecusername3_Internalname ;
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
      private string cmbClienteStatus_Columnheaderclass ;
      private string edtavTitulos_Link ;
      private string GXEncryptionTmp ;
      private string edtClienteDocumento_Link ;
      private string edtTipoClienteDescricao_Link ;
      private string cmbClienteStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char7 ;
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
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
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
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
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
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
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
      private string sGXsfl_191_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavTitulos_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string GXCCtl ;
      private string cmbClienteTipoPessoa_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtTipoClienteId_Jsonclick ;
      private string edtTipoClienteDescricao_Jsonclick ;
      private string cmbClienteStatus_Jsonclick ;
      private string edtClienteCreatedAt_Jsonclick ;
      private string edtClienteUpdatedAt_Jsonclick ;
      private string edtClienteLogUser_Jsonclick ;
      private string edtClienteQtdTitulos_F_Jsonclick ;
      private string edtClienteValorAPagar_F_Jsonclick ;
      private string edtClienteValorAReceber_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A175ClienteCreatedAt ;
      private DateTime A176ClienteUpdatedAt ;
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
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n172ClienteTipoPessoa ;
      private bool n169ClienteDocumento ;
      private bool n192TipoClienteId ;
      private bool n193TipoClienteDescricao ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool n175ClienteCreatedAt ;
      private bool n176ClienteUpdatedAt ;
      private bool n177ClienteLogUser ;
      private bool n309ClienteQtdTitulos_F ;
      private bool n310ClienteValorAPagar_F ;
      private bool n311ClienteValorAReceber_F ;
      private bool bGXsfl_191_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV104Wptituloclienteds_15_dynamicfiltersenabled2 ;
      private bool AV118Wptituloclienteds_29_dynamicfiltersenabled3 ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n457EspecialidadeId ;
      private bool n597EspecialidadeCreatedBy ;
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
      private bool n141SecUserName ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV46TFClienteTipoPessoa_SelsJson ;
      private string AV40ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ClienteDocumento1 ;
      private string AV19TipoClienteDescricao1 ;
      private string AV68ClienteConvenioDescricao1 ;
      private string AV69ClienteNacionalidadeNome1 ;
      private string AV70ClienteProfissaoNome1 ;
      private string AV20SecUserName1 ;
      private string AV21MunicipioNome1 ;
      private string AV72ResponsavelNacionalidadeNome1 ;
      private string AV73ResponsavelProfissaoNome1 ;
      private string AV74ResponsavelMunicipioNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ClienteDocumento2 ;
      private string AV26TipoClienteDescricao2 ;
      private string AV75ClienteConvenioDescricao2 ;
      private string AV76ClienteNacionalidadeNome2 ;
      private string AV77ClienteProfissaoNome2 ;
      private string AV27SecUserName2 ;
      private string AV28MunicipioNome2 ;
      private string AV79ResponsavelNacionalidadeNome2 ;
      private string AV80ResponsavelProfissaoNome2 ;
      private string AV81ResponsavelMunicipioNome2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32ClienteDocumento3 ;
      private string AV33TipoClienteDescricao3 ;
      private string AV82ClienteConvenioDescricao3 ;
      private string AV83ClienteNacionalidadeNome3 ;
      private string AV84ClienteProfissaoNome3 ;
      private string AV34SecUserName3 ;
      private string AV35MunicipioNome3 ;
      private string AV86ResponsavelNacionalidadeNome3 ;
      private string AV87ResponsavelProfissaoNome3 ;
      private string AV88ResponsavelMunicipioNome3 ;
      private string AV15FilterFullText ;
      private string AV42TFClienteRazaoSocial ;
      private string AV43TFClienteRazaoSocial_Sel ;
      private string AV44TFClienteNomeFantasia ;
      private string AV45TFClienteNomeFantasia_Sel ;
      private string AV48TFClienteDocumento ;
      private string AV49TFClienteDocumento_Sel ;
      private string AV50TFTipoClienteDescricao ;
      private string AV51TFTipoClienteDescricao_Sel ;
      private string AV59GridAppliedFilters ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A172ClienteTipoPessoa ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string lV90Wptituloclienteds_1_filterfulltext ;
      private string lV93Wptituloclienteds_4_clientedocumento1 ;
      private string lV94Wptituloclienteds_5_tipoclientedescricao1 ;
      private string lV95Wptituloclienteds_6_clienteconveniodescricao1 ;
      private string lV96Wptituloclienteds_7_clientenacionalidadenome1 ;
      private string lV97Wptituloclienteds_8_clienteprofissaonome1 ;
      private string lV98Wptituloclienteds_9_secusername1 ;
      private string lV99Wptituloclienteds_10_municipionome1 ;
      private string lV101Wptituloclienteds_12_responsavelnacionalidadenome1 ;
      private string lV102Wptituloclienteds_13_responsavelprofissaonome1 ;
      private string lV103Wptituloclienteds_14_responsavelmunicipionome1 ;
      private string lV107Wptituloclienteds_18_clientedocumento2 ;
      private string lV108Wptituloclienteds_19_tipoclientedescricao2 ;
      private string lV109Wptituloclienteds_20_clienteconveniodescricao2 ;
      private string lV110Wptituloclienteds_21_clientenacionalidadenome2 ;
      private string lV111Wptituloclienteds_22_clienteprofissaonome2 ;
      private string lV112Wptituloclienteds_23_secusername2 ;
      private string lV113Wptituloclienteds_24_municipionome2 ;
      private string lV115Wptituloclienteds_26_responsavelnacionalidadenome2 ;
      private string lV116Wptituloclienteds_27_responsavelprofissaonome2 ;
      private string lV117Wptituloclienteds_28_responsavelmunicipionome2 ;
      private string lV121Wptituloclienteds_32_clientedocumento3 ;
      private string lV122Wptituloclienteds_33_tipoclientedescricao3 ;
      private string lV123Wptituloclienteds_34_clienteconveniodescricao3 ;
      private string lV124Wptituloclienteds_35_clientenacionalidadenome3 ;
      private string lV125Wptituloclienteds_36_clienteprofissaonome3 ;
      private string lV126Wptituloclienteds_37_secusername3 ;
      private string lV127Wptituloclienteds_38_municipionome3 ;
      private string lV129Wptituloclienteds_40_responsavelnacionalidadenome3 ;
      private string lV130Wptituloclienteds_41_responsavelprofissaonome3 ;
      private string lV131Wptituloclienteds_42_responsavelmunicipionome3 ;
      private string lV132Wptituloclienteds_43_tfclienterazaosocial ;
      private string lV134Wptituloclienteds_45_tfclientenomefantasia ;
      private string lV137Wptituloclienteds_48_tfclientedocumento ;
      private string lV139Wptituloclienteds_50_tftipoclientedescricao ;
      private string AV91Wptituloclienteds_2_dynamicfiltersselector1 ;
      private string AV93Wptituloclienteds_4_clientedocumento1 ;
      private string AV94Wptituloclienteds_5_tipoclientedescricao1 ;
      private string AV95Wptituloclienteds_6_clienteconveniodescricao1 ;
      private string AV96Wptituloclienteds_7_clientenacionalidadenome1 ;
      private string AV97Wptituloclienteds_8_clienteprofissaonome1 ;
      private string AV98Wptituloclienteds_9_secusername1 ;
      private string AV99Wptituloclienteds_10_municipionome1 ;
      private string AV101Wptituloclienteds_12_responsavelnacionalidadenome1 ;
      private string AV102Wptituloclienteds_13_responsavelprofissaonome1 ;
      private string AV103Wptituloclienteds_14_responsavelmunicipionome1 ;
      private string AV105Wptituloclienteds_16_dynamicfiltersselector2 ;
      private string AV107Wptituloclienteds_18_clientedocumento2 ;
      private string AV108Wptituloclienteds_19_tipoclientedescricao2 ;
      private string AV109Wptituloclienteds_20_clienteconveniodescricao2 ;
      private string AV110Wptituloclienteds_21_clientenacionalidadenome2 ;
      private string AV111Wptituloclienteds_22_clienteprofissaonome2 ;
      private string AV112Wptituloclienteds_23_secusername2 ;
      private string AV113Wptituloclienteds_24_municipionome2 ;
      private string AV115Wptituloclienteds_26_responsavelnacionalidadenome2 ;
      private string AV116Wptituloclienteds_27_responsavelprofissaonome2 ;
      private string AV117Wptituloclienteds_28_responsavelmunicipionome2 ;
      private string AV119Wptituloclienteds_30_dynamicfiltersselector3 ;
      private string AV121Wptituloclienteds_32_clientedocumento3 ;
      private string AV122Wptituloclienteds_33_tipoclientedescricao3 ;
      private string AV123Wptituloclienteds_34_clienteconveniodescricao3 ;
      private string AV124Wptituloclienteds_35_clientenacionalidadenome3 ;
      private string AV125Wptituloclienteds_36_clienteprofissaonome3 ;
      private string AV126Wptituloclienteds_37_secusername3 ;
      private string AV127Wptituloclienteds_38_municipionome3 ;
      private string AV129Wptituloclienteds_40_responsavelnacionalidadenome3 ;
      private string AV130Wptituloclienteds_41_responsavelprofissaonome3 ;
      private string AV131Wptituloclienteds_42_responsavelmunicipionome3 ;
      private string AV133Wptituloclienteds_44_tfclienterazaosocial_sel ;
      private string AV132Wptituloclienteds_43_tfclienterazaosocial ;
      private string AV135Wptituloclienteds_46_tfclientenomefantasia_sel ;
      private string AV134Wptituloclienteds_45_tfclientenomefantasia ;
      private string AV138Wptituloclienteds_49_tfclientedocumento_sel ;
      private string AV137Wptituloclienteds_48_tfclientedocumento ;
      private string AV140Wptituloclienteds_51_tftipoclientedescricao_sel ;
      private string AV139Wptituloclienteds_50_tftipoclientedescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A141SecUserName ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string AV90Wptituloclienteds_1_filterfulltext ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV61AuxText ;
      private IGxSession AV38Session ;
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
      private GXCombobox cmbClienteTipoPessoa ;
      private GXCombobox cmbClienteStatus ;
      private GxSimpleCollection<string> AV47TFClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV39ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV55DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV136Wptituloclienteds_47_tfclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00508_A186MunicipioCodigo ;
      private bool[] H00508_n186MunicipioCodigo ;
      private string[] H00508_A444ResponsavelMunicipio ;
      private bool[] H00508_n444ResponsavelMunicipio ;
      private int[] H00508_A402BancoId ;
      private bool[] H00508_n402BancoId ;
      private int[] H00508_A457EspecialidadeId ;
      private bool[] H00508_n457EspecialidadeId ;
      private short[] H00508_A597EspecialidadeCreatedBy ;
      private bool[] H00508_n597EspecialidadeCreatedBy ;
      private int[] H00508_A437ResponsavelNacionalidade ;
      private bool[] H00508_n437ResponsavelNacionalidade ;
      private int[] H00508_A484ClienteNacionalidade ;
      private bool[] H00508_n484ClienteNacionalidade ;
      private int[] H00508_A442ResponsavelProfissao ;
      private bool[] H00508_n442ResponsavelProfissao ;
      private int[] H00508_A487ClienteProfissao ;
      private bool[] H00508_n487ClienteProfissao ;
      private int[] H00508_A489ClienteConvenio ;
      private bool[] H00508_n489ClienteConvenio ;
      private string[] H00508_A445ResponsavelMunicipioNome ;
      private bool[] H00508_n445ResponsavelMunicipioNome ;
      private string[] H00508_A443ResponsavelProfissaoNome ;
      private bool[] H00508_n443ResponsavelProfissaoNome ;
      private string[] H00508_A438ResponsavelNacionalidadeNome ;
      private bool[] H00508_n438ResponsavelNacionalidadeNome ;
      private int[] H00508_A404BancoCodigo ;
      private bool[] H00508_n404BancoCodigo ;
      private string[] H00508_A187MunicipioNome ;
      private bool[] H00508_n187MunicipioNome ;
      private string[] H00508_A141SecUserName ;
      private bool[] H00508_n141SecUserName ;
      private string[] H00508_A488ClienteProfissaoNome ;
      private bool[] H00508_n488ClienteProfissaoNome ;
      private string[] H00508_A485ClienteNacionalidadeNome ;
      private bool[] H00508_n485ClienteNacionalidadeNome ;
      private string[] H00508_A490ClienteConvenioDescricao ;
      private bool[] H00508_n490ClienteConvenioDescricao ;
      private short[] H00508_A177ClienteLogUser ;
      private bool[] H00508_n177ClienteLogUser ;
      private DateTime[] H00508_A176ClienteUpdatedAt ;
      private bool[] H00508_n176ClienteUpdatedAt ;
      private DateTime[] H00508_A175ClienteCreatedAt ;
      private bool[] H00508_n175ClienteCreatedAt ;
      private bool[] H00508_A174ClienteStatus ;
      private bool[] H00508_n174ClienteStatus ;
      private string[] H00508_A193TipoClienteDescricao ;
      private bool[] H00508_n193TipoClienteDescricao ;
      private short[] H00508_A192TipoClienteId ;
      private bool[] H00508_n192TipoClienteId ;
      private string[] H00508_A169ClienteDocumento ;
      private bool[] H00508_n169ClienteDocumento ;
      private string[] H00508_A172ClienteTipoPessoa ;
      private bool[] H00508_n172ClienteTipoPessoa ;
      private string[] H00508_A171ClienteNomeFantasia ;
      private bool[] H00508_n171ClienteNomeFantasia ;
      private string[] H00508_A170ClienteRazaoSocial ;
      private bool[] H00508_n170ClienteRazaoSocial ;
      private int[] H00508_A168ClienteId ;
      private bool[] H00508_n168ClienteId ;
      private decimal[] H00508_A311ClienteValorAReceber_F ;
      private bool[] H00508_n311ClienteValorAReceber_F ;
      private decimal[] H00508_A310ClienteValorAPagar_F ;
      private bool[] H00508_n310ClienteValorAPagar_F ;
      private int[] H00508_A309ClienteQtdTitulos_F ;
      private bool[] H00508_n309ClienteQtdTitulos_F ;
      private long[] H005015_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wptitulocliente__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00508( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV136Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                             string AV91Wptituloclienteds_2_dynamicfiltersselector1 ,
                                             short AV92Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                             string AV93Wptituloclienteds_4_clientedocumento1 ,
                                             string AV94Wptituloclienteds_5_tipoclientedescricao1 ,
                                             string AV95Wptituloclienteds_6_clienteconveniodescricao1 ,
                                             string AV96Wptituloclienteds_7_clientenacionalidadenome1 ,
                                             string AV97Wptituloclienteds_8_clienteprofissaonome1 ,
                                             string AV98Wptituloclienteds_9_secusername1 ,
                                             string AV99Wptituloclienteds_10_municipionome1 ,
                                             int AV100Wptituloclienteds_11_bancocodigo1 ,
                                             string AV101Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                             string AV102Wptituloclienteds_13_responsavelprofissaonome1 ,
                                             string AV103Wptituloclienteds_14_responsavelmunicipionome1 ,
                                             bool AV104Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                             string AV105Wptituloclienteds_16_dynamicfiltersselector2 ,
                                             short AV106Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                             string AV107Wptituloclienteds_18_clientedocumento2 ,
                                             string AV108Wptituloclienteds_19_tipoclientedescricao2 ,
                                             string AV109Wptituloclienteds_20_clienteconveniodescricao2 ,
                                             string AV110Wptituloclienteds_21_clientenacionalidadenome2 ,
                                             string AV111Wptituloclienteds_22_clienteprofissaonome2 ,
                                             string AV112Wptituloclienteds_23_secusername2 ,
                                             string AV113Wptituloclienteds_24_municipionome2 ,
                                             int AV114Wptituloclienteds_25_bancocodigo2 ,
                                             string AV115Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                             string AV116Wptituloclienteds_27_responsavelprofissaonome2 ,
                                             string AV117Wptituloclienteds_28_responsavelmunicipionome2 ,
                                             bool AV118Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                             string AV119Wptituloclienteds_30_dynamicfiltersselector3 ,
                                             short AV120Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                             string AV121Wptituloclienteds_32_clientedocumento3 ,
                                             string AV122Wptituloclienteds_33_tipoclientedescricao3 ,
                                             string AV123Wptituloclienteds_34_clienteconveniodescricao3 ,
                                             string AV124Wptituloclienteds_35_clientenacionalidadenome3 ,
                                             string AV125Wptituloclienteds_36_clienteprofissaonome3 ,
                                             string AV126Wptituloclienteds_37_secusername3 ,
                                             string AV127Wptituloclienteds_38_municipionome3 ,
                                             int AV128Wptituloclienteds_39_bancocodigo3 ,
                                             string AV129Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                             string AV130Wptituloclienteds_41_responsavelprofissaonome3 ,
                                             string AV131Wptituloclienteds_42_responsavelmunicipionome3 ,
                                             string AV133Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                             string AV132Wptituloclienteds_43_tfclienterazaosocial ,
                                             string AV135Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                             string AV134Wptituloclienteds_45_tfclientenomefantasia ,
                                             int AV136Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                             string AV138Wptituloclienteds_49_tfclientedocumento_sel ,
                                             string AV137Wptituloclienteds_48_tfclientedocumento ,
                                             string AV140Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                             string AV139Wptituloclienteds_50_tftipoclientedescricao ,
                                             short AV141Wptituloclienteds_52_tfclientestatus_sel ,
                                             decimal AV144Wptituloclienteds_55_tfclientevalorapagar_f ,
                                             decimal AV145Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                             decimal AV146Wptituloclienteds_57_tfclientevalorareceber_f ,
                                             decimal AV147Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A141SecUserName ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             bool A174ClienteStatus ,
                                             decimal A310ClienteValorAPagar_F ,
                                             decimal A311ClienteValorAReceber_F ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV90Wptituloclienteds_1_filterfulltext ,
                                             int A309ClienteQtdTitulos_F ,
                                             int AV142Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                             int AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[100];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.EspecialidadeId, T5.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T9.ProfissaoNome AS ResponsavelProfissaoNome, T7.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T6.SecUserName, T10.ProfissaoNome AS ClienteProfissaoNome, T8.NacionalidadeNome AS ClienteNacionalidadeNome, T11.ConvenioDescricao AS ClienteConvenioDescricao, T1.ClienteLogUser, T1.ClienteUpdatedAt, T1.ClienteCreatedAt, T1.ClienteStatus, T12.TipoClienteDescricao, T1.TipoClienteId, T1.ClienteDocumento, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteId, COALESCE( T13.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T14.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T15.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F";
         sFromString = " FROM ((((((((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Especialidade T5 ON T5.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T6 ON T6.SecUserId = T5.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T11 ON T11.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T12 ON T12.TipoClienteId = T1.TipoClienteId) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T16.TituloValor,";
         sFromString += " 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T15 ON T15.ClienteId = T1.ClienteId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV90Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( T12.TipoClienteDescricao like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T15.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) >= :AV142Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) <= :AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV93Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV93Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like :lV94Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like '%' || :lV94Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV95Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV95Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV96Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV96Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV97Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV97Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV98Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV98Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV99Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV99Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV101Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV101Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV102Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV102Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV103Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV103Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV107Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV107Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like :lV108Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like '%' || :lV108Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV109Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV109Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV110Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV110Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV111Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV111Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV112Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV112Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV113Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV113Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV115Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV115Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV116Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV116Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int8[59] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV117Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int8[60] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV117Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int8[61] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV121Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int8[62] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV121Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int8[63] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like :lV122Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int8[64] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like '%' || :lV122Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int8[65] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV123Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int8[66] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV123Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int8[67] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV124Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int8[68] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV124Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int8[69] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV125Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int8[70] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV125Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int8[71] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV126Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int8[72] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV126Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int8[73] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV127Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int8[74] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV127Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int8[75] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int8[76] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int8[77] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int8[78] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV129Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int8[79] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV129Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int8[80] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV130Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int8[81] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV130Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int8[82] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV131Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int8[83] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV131Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int8[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV132Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int8[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV133Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV133Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[86] = 1;
         }
         if ( StringUtil.StrCmp(AV133Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV134Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int8[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV135Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV135Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int8[88] = 1;
         }
         if ( StringUtil.StrCmp(AV135Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV136Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV136Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV137Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int8[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV138Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int8[90] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao like :lV139Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int8[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao = ( :AV140Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int8[92] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T12.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T12.TipoClienteDescricao))=0))");
         }
         if ( AV141Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV141Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV144Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) >= :AV144Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int8[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV145Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) <= :AV145Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int8[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV146Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) >= :AV146Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int8[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) <= :AV147Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int8[96] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteDocumento DESC";
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
            sOrderString += " ORDER BY T1.ClienteNomeFantasia, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteNomeFantasia DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteTipoPessoa, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteTipoPessoa DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T12.TipoClienteDescricao, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T12.TipoClienteDescricao DESC, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteStatus DESC, T1.ClienteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ClienteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H005015( IGxContext context ,
                                              string A172ClienteTipoPessoa ,
                                              GxSimpleCollection<string> AV136Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              string AV91Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              short AV92Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              string AV93Wptituloclienteds_4_clientedocumento1 ,
                                              string AV94Wptituloclienteds_5_tipoclientedescricao1 ,
                                              string AV95Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              string AV96Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              string AV97Wptituloclienteds_8_clienteprofissaonome1 ,
                                              string AV98Wptituloclienteds_9_secusername1 ,
                                              string AV99Wptituloclienteds_10_municipionome1 ,
                                              int AV100Wptituloclienteds_11_bancocodigo1 ,
                                              string AV101Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              string AV102Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              string AV103Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              bool AV104Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              string AV105Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              short AV106Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              string AV107Wptituloclienteds_18_clientedocumento2 ,
                                              string AV108Wptituloclienteds_19_tipoclientedescricao2 ,
                                              string AV109Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              string AV110Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              string AV111Wptituloclienteds_22_clienteprofissaonome2 ,
                                              string AV112Wptituloclienteds_23_secusername2 ,
                                              string AV113Wptituloclienteds_24_municipionome2 ,
                                              int AV114Wptituloclienteds_25_bancocodigo2 ,
                                              string AV115Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              string AV116Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              string AV117Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              bool AV118Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              string AV119Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              short AV120Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              string AV121Wptituloclienteds_32_clientedocumento3 ,
                                              string AV122Wptituloclienteds_33_tipoclientedescricao3 ,
                                              string AV123Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              string AV124Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              string AV125Wptituloclienteds_36_clienteprofissaonome3 ,
                                              string AV126Wptituloclienteds_37_secusername3 ,
                                              string AV127Wptituloclienteds_38_municipionome3 ,
                                              int AV128Wptituloclienteds_39_bancocodigo3 ,
                                              string AV129Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              string AV130Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              string AV131Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              string AV133Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              string AV132Wptituloclienteds_43_tfclienterazaosocial ,
                                              string AV135Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              string AV134Wptituloclienteds_45_tfclientenomefantasia ,
                                              int AV136Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                              string AV138Wptituloclienteds_49_tfclientedocumento_sel ,
                                              string AV137Wptituloclienteds_48_tfclientedocumento ,
                                              string AV140Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              string AV139Wptituloclienteds_50_tftipoclientedescricao ,
                                              short AV141Wptituloclienteds_52_tfclientestatus_sel ,
                                              decimal AV144Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              decimal AV145Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              decimal AV146Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              decimal AV147Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              string A169ClienteDocumento ,
                                              string A193TipoClienteDescricao ,
                                              string A490ClienteConvenioDescricao ,
                                              string A485ClienteNacionalidadeNome ,
                                              string A488ClienteProfissaoNome ,
                                              string A141SecUserName ,
                                              string A187MunicipioNome ,
                                              int A404BancoCodigo ,
                                              string A438ResponsavelNacionalidadeNome ,
                                              string A443ResponsavelProfissaoNome ,
                                              string A445ResponsavelMunicipioNome ,
                                              string A170ClienteRazaoSocial ,
                                              string A171ClienteNomeFantasia ,
                                              bool A174ClienteStatus ,
                                              decimal A310ClienteValorAPagar_F ,
                                              decimal A311ClienteValorAReceber_F ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc ,
                                              string AV90Wptituloclienteds_1_filterfulltext ,
                                              int A309ClienteQtdTitulos_F ,
                                              int AV142Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              int AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[97];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((((((((((((((Cliente T1 LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Especialidade T6 ON T6.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T7 ON T7.SecUserId = T6.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T9 ON T9.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T11 ON T11.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T12 ON T12.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE(";
         scmdbuf += " T16.TituloValor, 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T15 ON T15.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV90Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( T2.TipoClienteDescricao like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV90Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T15.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV90Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV142Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) >= :AV142Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) <= :AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV93Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV93Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV94Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV94Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV95Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV95Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV96Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV96Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV97Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV97Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV98Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV98Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV99Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV99Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV100Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV100Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV101Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV101Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV102Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV102Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV103Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV91Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV92Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV103Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV107Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV107Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV108Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV108Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV109Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV109Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV110Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV110Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV111Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV111Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV112Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV112Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV113Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV113Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV114Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV114Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int10[55] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV115Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int10[56] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV115Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int10[57] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV116Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int10[58] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV116Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int10[59] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV117Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int10[60] = 1;
         }
         if ( AV104Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV117Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int10[61] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV121Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int10[62] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV121Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int10[63] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV122Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int10[64] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV122Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int10[65] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV123Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int10[66] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV123Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int10[67] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV124Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int10[68] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV124Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int10[69] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV125Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int10[70] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV125Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int10[71] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV126Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int10[72] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV126Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int10[73] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV127Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int10[74] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV127Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int10[75] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int10[76] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int10[77] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV128Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV128Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int10[78] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV129Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int10[79] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV129Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int10[80] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV130Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int10[81] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV130Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int10[82] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV131Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int10[83] = 1;
         }
         if ( AV118Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV131Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int10[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV132Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int10[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV133Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV133Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int10[86] = 1;
         }
         if ( StringUtil.StrCmp(AV133Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV134Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int10[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV135Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV135Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int10[88] = 1;
         }
         if ( StringUtil.StrCmp(AV135Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV136Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV136Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV137Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int10[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV138Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int10[90] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV139Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int10[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV140Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int10[92] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( AV141Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV141Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV144Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) >= :AV144Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int10[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV145Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) <= :AV145Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int10[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV146Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) >= :AV146Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int10[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) <= :AV147Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int10[96] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H00508(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (short)dynConstraints[73] , (bool)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] );
               case 1 :
                     return conditional_H005015(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (short)dynConstraints[73] , (bool)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] );
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
          Object[] prmH00508;
          prmH00508 = new Object[] {
          new ParDef("AV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV142Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV142Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV93Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV93Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV94Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV94Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV95Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV95Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV96Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV97Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV98Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV98Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV99Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV101Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV103Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV107Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV107Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV108Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV109Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV109Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV110Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV110Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV111Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV111Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV112Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV112Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV113Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV115Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV117Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV121Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV121Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV123Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV123Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV124Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV124Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV125Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV125Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV126Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV126Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV127Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV129Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV131Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV134Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV135Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV138Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV139Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV144Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV145Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV146Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV147Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005015;
          prmH005015 = new Object[] {
          new ParDef("AV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV142Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV142Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV143Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV93Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV93Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV94Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV94Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV95Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV95Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV96Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV97Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV98Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV98Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV99Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV100Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV101Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV103Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV107Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV107Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV108Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV109Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV109Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV110Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV110Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV111Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV111Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV112Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV112Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV113Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV115Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV117Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV121Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV121Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV123Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV123Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV124Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV124Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV125Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV125Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV126Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV126Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV127Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV128Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV129Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV131Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV134Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV135Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV138Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV139Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV144Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV145Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV146Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV147Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00508", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00508,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005015", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005015,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((short[]) buf[38])[0] = rslt.getShort(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[42])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((bool[]) buf[44])[0] = rslt.getBool(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((short[]) buf[48])[0] = rslt.getShort(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((string[]) buf[52])[0] = rslt.getVarchar(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((string[]) buf[54])[0] = rslt.getVarchar(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((string[]) buf[56])[0] = rslt.getVarchar(29);
                ((bool[]) buf[57])[0] = rslt.wasNull(29);
                ((int[]) buf[58])[0] = rslt.getInt(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((decimal[]) buf[61])[0] = rslt.getDecimal(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((int[]) buf[63])[0] = rslt.getInt(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
