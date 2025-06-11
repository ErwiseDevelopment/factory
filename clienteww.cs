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
   public class clienteww : GXDataArea
   {
      public clienteww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienteww( IGxContext context )
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
         cmbClienteTipoPessoa = new GXCombobox();
         cmbClienteStatus = new GXCombobox();
         cmbTipoClientePortal = new GXCombobox();
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
         nRC_GXsfl_188 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_188"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_188_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_188_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_188_idx = GetPar( "sGXsfl_188_idx");
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
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20ClienteDocumento1 = GetPar( "ClienteDocumento1");
         AV68TipoClienteDescricao1 = GetPar( "TipoClienteDescricao1");
         AV93ClienteConvenioDescricao1 = GetPar( "ClienteConvenioDescricao1");
         AV94ClienteNacionalidadeNome1 = GetPar( "ClienteNacionalidadeNome1");
         AV95ClienteProfissaoNome1 = GetPar( "ClienteProfissaoNome1");
         AV79MunicipioNome1 = GetPar( "MunicipioNome1");
         AV96BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo1"), "."), 18, MidpointRounding.ToEven));
         AV97ResponsavelNacionalidadeNome1 = GetPar( "ResponsavelNacionalidadeNome1");
         AV98ResponsavelProfissaoNome1 = GetPar( "ResponsavelProfissaoNome1");
         AV99ResponsavelMunicipioNome1 = GetPar( "ResponsavelMunicipioNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24ClienteDocumento2 = GetPar( "ClienteDocumento2");
         AV70TipoClienteDescricao2 = GetPar( "TipoClienteDescricao2");
         AV100ClienteConvenioDescricao2 = GetPar( "ClienteConvenioDescricao2");
         AV101ClienteNacionalidadeNome2 = GetPar( "ClienteNacionalidadeNome2");
         AV102ClienteProfissaoNome2 = GetPar( "ClienteProfissaoNome2");
         AV80MunicipioNome2 = GetPar( "MunicipioNome2");
         AV103BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo2"), "."), 18, MidpointRounding.ToEven));
         AV104ResponsavelNacionalidadeNome2 = GetPar( "ResponsavelNacionalidadeNome2");
         AV105ResponsavelProfissaoNome2 = GetPar( "ResponsavelProfissaoNome2");
         AV106ResponsavelMunicipioNome2 = GetPar( "ResponsavelMunicipioNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28ClienteDocumento3 = GetPar( "ClienteDocumento3");
         AV72TipoClienteDescricao3 = GetPar( "TipoClienteDescricao3");
         AV107ClienteConvenioDescricao3 = GetPar( "ClienteConvenioDescricao3");
         AV108ClienteNacionalidadeNome3 = GetPar( "ClienteNacionalidadeNome3");
         AV109ClienteProfissaoNome3 = GetPar( "ClienteProfissaoNome3");
         AV81MunicipioNome3 = GetPar( "MunicipioNome3");
         AV110BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoCodigo3"), "."), 18, MidpointRounding.ToEven));
         AV111ResponsavelNacionalidadeNome3 = GetPar( "ResponsavelNacionalidadeNome3");
         AV112ResponsavelProfissaoNome3 = GetPar( "ResponsavelProfissaoNome3");
         AV113ResponsavelMunicipioNome3 = GetPar( "ResponsavelMunicipioNome3");
         AV36ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV115Pgmname = GetPar( "Pgmname");
         AV77TFTipoClienteDescricao = GetPar( "TFTipoClienteDescricao");
         AV78TFTipoClienteDescricao_Sel = GetPar( "TFTipoClienteDescricao_Sel");
         AV37TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV38TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV41TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV42TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV44TFClienteTipoPessoa_Sels);
         AV45TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFClienteStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA3T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clienteww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV115Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV115Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV16OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO1", AV20ClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO1", AV68TipoClienteDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO1", AV93ClienteConvenioDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME1", AV94ClienteNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME1", AV95ClienteProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME1", AV79MunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96BancoCodigo1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME1", AV97ResponsavelNacionalidadeNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME1", AV98ResponsavelProfissaoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME1", AV99ResponsavelMunicipioNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO2", AV24ClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO2", AV70TipoClienteDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO2", AV100ClienteConvenioDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME2", AV101ClienteNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME2", AV102ClienteProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME2", AV80MunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103BancoCodigo2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME2", AV104ResponsavelNacionalidadeNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME2", AV105ResponsavelProfissaoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME2", AV106ResponsavelMunicipioNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO3", AV28ClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO3", AV72TipoClienteDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTECONVENIODESCRICAO3", AV107ClienteConvenioDescricao3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTENACIONALIDADENOME3", AV108ClienteNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEPROFISSAONOME3", AV109ClienteProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vMUNICIPIONOME3", AV81MunicipioNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vBANCOCODIGO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV110BancoCodigo3), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELNACIONALIDADENOME3", AV111ResponsavelNacionalidadeNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELPROFISSAONOME3", AV112ResponsavelProfissaoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vRESPONSAVELMUNICIPIONOME3", AV113ResponsavelMunicipioNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_188", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_188), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV34ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV34ManageFiltersData);
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
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV115Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV115Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO", AV77TFTipoClienteDescricao);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO_SEL", AV78TFTipoClienteDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV37TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV38TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV41TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV42TFClienteDocumento_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTETIPOPESSOA_SELS", AV44TFClienteTipoPessoa_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTETIPOPESSOA_SELS", AV44TFClienteTipoPessoa_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTESTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFClienteStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV16OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETIPOPESSOA_SELSJSON", AV43TFClienteTipoPessoa_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATODDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATONUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOTELEFONEDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOTELEFONENUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            WE3T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3T2( ) ;
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
         return formatLink("clienteww")  ;
      }

      public override string GetPgmname( )
      {
         return "ClienteWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cliente" ;
      }

      protected void WB3T0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(188), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(188), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV34ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ClienteWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_3T2( true) ;
         }
         else
         {
            wb_table1_45_3T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_3T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_94_3T2( true) ;
         }
         else
         {
            wb_table2_94_3T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_94_3T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_143_3T2( true) ;
         }
         else
         {
            wb_table3_143_3T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_143_3T2e( bool wbgen )
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
            StartGridControl188( ) ;
         }
         if ( wbEnd == 188 )
         {
            wbEnd = 0;
            nRC_GXsfl_188 = (int)(nGXsfl_188_idx-1);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ClienteWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV56DDO_TitleSettingsIcons);
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
         if ( wbEnd == 188 )
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

      protected void START3T2( )
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
         STRUP3T0( ) ;
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
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
                              E113T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E153T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E163T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E173T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E183T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E193T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E203T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E213T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E223T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E233T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243T2 ();
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
                              nGXsfl_188_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
                              SubsflControlProps_1882( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV114GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV114GridActionGroup1), 4, 0));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
                              n193TipoClienteDescricao = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
                              n171ClienteNomeFantasia = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              cmbClienteTipoPessoa.Name = cmbClienteTipoPessoa_Internalname;
                              cmbClienteTipoPessoa.CurrentValue = cgiGet( cmbClienteTipoPessoa_Internalname);
                              A172ClienteTipoPessoa = cgiGet( cmbClienteTipoPessoa_Internalname);
                              n172ClienteTipoPessoa = false;
                              A206ClienteCelular_F = cgiGet( edtClienteCelular_F_Internalname);
                              A205ClienteTelefone_F = cgiGet( edtClienteTelefone_F_Internalname);
                              A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n192TipoClienteId = false;
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
                              A608SecUserId_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n608SecUserId_F = false;
                              cmbTipoClientePortal.Name = cmbTipoClientePortal_Internalname;
                              cmbTipoClientePortal.CurrentValue = cgiGet( cmbTipoClientePortal_Internalname);
                              A207TipoClientePortal = StringUtil.StrToBool( cgiGet( cmbTipoClientePortal_Internalname));
                              n207TipoClientePortal = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E253T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E263T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E273T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E283T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV16OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV20ClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV68TipoClienteDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV93ClienteConvenioDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV94ClienteNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV95ClienteProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV79MunicipioNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV96BancoCodigo1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV97ResponsavelNacionalidadeNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV98ResponsavelProfissaoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV99ResponsavelMunicipioNome1) != 0 )
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
                                       /* Set Refresh If Clientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV24ClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV70TipoClienteDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV100ClienteConvenioDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV101ClienteNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV102ClienteProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV80MunicipioNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV103BancoCodigo2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV104ResponsavelNacionalidadeNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV105ResponsavelProfissaoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV106ResponsavelMunicipioNome2) != 0 )
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
                                       /* Set Refresh If Clientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV28ClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV72TipoClienteDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteconveniodescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV107ClienteConvenioDescricao3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientenacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV108ClienteNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clienteprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV109ClienteProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Municipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV81MunicipioNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Bancocodigo3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV110BancoCodigo3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelnacionalidadenome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV111ResponsavelNacionalidadeNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelprofissaonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV112ResponsavelProfissaoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Responsavelmunicipionome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV113ResponsavelMunicipioNome3) != 0 )
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

      protected void WE3T2( )
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

      protected void PA3T2( )
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
         SubsflControlProps_1882( ) ;
         while ( nGXsfl_188_idx <= nRC_GXsfl_188 )
         {
            sendrow_1882( ) ;
            nGXsfl_188_idx = ((subGrid_Islastpage==1)&&(nGXsfl_188_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_188_idx+1);
            sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
            SubsflControlProps_1882( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20ClienteDocumento1 ,
                                       string AV68TipoClienteDescricao1 ,
                                       string AV93ClienteConvenioDescricao1 ,
                                       string AV94ClienteNacionalidadeNome1 ,
                                       string AV95ClienteProfissaoNome1 ,
                                       string AV79MunicipioNome1 ,
                                       int AV96BancoCodigo1 ,
                                       string AV97ResponsavelNacionalidadeNome1 ,
                                       string AV98ResponsavelProfissaoNome1 ,
                                       string AV99ResponsavelMunicipioNome1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24ClienteDocumento2 ,
                                       string AV70TipoClienteDescricao2 ,
                                       string AV100ClienteConvenioDescricao2 ,
                                       string AV101ClienteNacionalidadeNome2 ,
                                       string AV102ClienteProfissaoNome2 ,
                                       string AV80MunicipioNome2 ,
                                       int AV103BancoCodigo2 ,
                                       string AV104ResponsavelNacionalidadeNome2 ,
                                       string AV105ResponsavelProfissaoNome2 ,
                                       string AV106ResponsavelMunicipioNome2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28ClienteDocumento3 ,
                                       string AV72TipoClienteDescricao3 ,
                                       string AV107ClienteConvenioDescricao3 ,
                                       string AV108ClienteNacionalidadeNome3 ,
                                       string AV109ClienteProfissaoNome3 ,
                                       string AV81MunicipioNome3 ,
                                       int AV110BancoCodigo3 ,
                                       string AV111ResponsavelNacionalidadeNome3 ,
                                       string AV112ResponsavelProfissaoNome3 ,
                                       string AV113ResponsavelMunicipioNome3 ,
                                       short AV36ManageFiltersExecutionStep ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV115Pgmname ,
                                       string AV77TFTipoClienteDescricao ,
                                       string AV78TFTipoClienteDescricao_Sel ,
                                       string AV37TFClienteRazaoSocial ,
                                       string AV38TFClienteRazaoSocial_Sel ,
                                       string AV41TFClienteDocumento ,
                                       string AV42TFClienteDocumento_Sel ,
                                       GxSimpleCollection<string> AV44TFClienteTipoPessoa_Sels ,
                                       short AV45TFClienteStatus_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3T2( ) ;
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
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
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
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV115Pgmname = "ClienteWW";
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 188;
         /* Execute user event: Refresh */
         E263T2 ();
         nGXsfl_188_idx = 1;
         sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
         SubsflControlProps_1882( ) ;
         bGXsfl_188_Refreshing = true;
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
            SubsflControlProps_1882( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A172ClienteTipoPessoa ,
                                                 AV161Clientewwds_46_tfclientetipopessoa_sels ,
                                                 AV116Clientewwds_1_filterfulltext ,
                                                 AV117Clientewwds_2_dynamicfiltersselector1 ,
                                                 AV118Clientewwds_3_dynamicfiltersoperator1 ,
                                                 AV119Clientewwds_4_clientedocumento1 ,
                                                 AV120Clientewwds_5_tipoclientedescricao1 ,
                                                 AV121Clientewwds_6_clienteconveniodescricao1 ,
                                                 AV122Clientewwds_7_clientenacionalidadenome1 ,
                                                 AV123Clientewwds_8_clienteprofissaonome1 ,
                                                 AV124Clientewwds_9_municipionome1 ,
                                                 AV125Clientewwds_10_bancocodigo1 ,
                                                 AV126Clientewwds_11_responsavelnacionalidadenome1 ,
                                                 AV127Clientewwds_12_responsavelprofissaonome1 ,
                                                 AV128Clientewwds_13_responsavelmunicipionome1 ,
                                                 AV129Clientewwds_14_dynamicfiltersenabled2 ,
                                                 AV130Clientewwds_15_dynamicfiltersselector2 ,
                                                 AV131Clientewwds_16_dynamicfiltersoperator2 ,
                                                 AV132Clientewwds_17_clientedocumento2 ,
                                                 AV133Clientewwds_18_tipoclientedescricao2 ,
                                                 AV134Clientewwds_19_clienteconveniodescricao2 ,
                                                 AV135Clientewwds_20_clientenacionalidadenome2 ,
                                                 AV136Clientewwds_21_clienteprofissaonome2 ,
                                                 AV137Clientewwds_22_municipionome2 ,
                                                 AV138Clientewwds_23_bancocodigo2 ,
                                                 AV139Clientewwds_24_responsavelnacionalidadenome2 ,
                                                 AV140Clientewwds_25_responsavelprofissaonome2 ,
                                                 AV141Clientewwds_26_responsavelmunicipionome2 ,
                                                 AV142Clientewwds_27_dynamicfiltersenabled3 ,
                                                 AV143Clientewwds_28_dynamicfiltersselector3 ,
                                                 AV144Clientewwds_29_dynamicfiltersoperator3 ,
                                                 AV145Clientewwds_30_clientedocumento3 ,
                                                 AV146Clientewwds_31_tipoclientedescricao3 ,
                                                 AV147Clientewwds_32_clienteconveniodescricao3 ,
                                                 AV148Clientewwds_33_clientenacionalidadenome3 ,
                                                 AV149Clientewwds_34_clienteprofissaonome3 ,
                                                 AV150Clientewwds_35_municipionome3 ,
                                                 AV151Clientewwds_36_bancocodigo3 ,
                                                 AV152Clientewwds_37_responsavelnacionalidadenome3 ,
                                                 AV153Clientewwds_38_responsavelprofissaonome3 ,
                                                 AV154Clientewwds_39_responsavelmunicipionome3 ,
                                                 AV156Clientewwds_41_tftipoclientedescricao_sel ,
                                                 AV155Clientewwds_40_tftipoclientedescricao ,
                                                 AV158Clientewwds_43_tfclienterazaosocial_sel ,
                                                 AV157Clientewwds_42_tfclienterazaosocial ,
                                                 AV160Clientewwds_45_tfclientedocumento_sel ,
                                                 AV159Clientewwds_44_tfclientedocumento ,
                                                 AV161Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                                 AV162Clientewwds_47_tfclientestatus_sel ,
                                                 A193TipoClienteDescricao ,
                                                 A170ClienteRazaoSocial ,
                                                 A169ClienteDocumento ,
                                                 A174ClienteStatus ,
                                                 A490ClienteConvenioDescricao ,
                                                 A485ClienteNacionalidadeNome ,
                                                 A488ClienteProfissaoNome ,
                                                 A187MunicipioNome ,
                                                 A404BancoCodigo ,
                                                 A438ResponsavelNacionalidadeNome ,
                                                 A443ResponsavelProfissaoNome ,
                                                 A445ResponsavelMunicipioNome ,
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
            lV119Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1), "%", "");
            lV119Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1), "%", "");
            lV120Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1), "%", "");
            lV120Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1), "%", "");
            lV121Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1), "%", "");
            lV121Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1), "%", "");
            lV122Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1), "%", "");
            lV122Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1), "%", "");
            lV123Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1), "%", "");
            lV123Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1), "%", "");
            lV124Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_9_municipionome1), "%", "");
            lV124Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_9_municipionome1), "%", "");
            lV126Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1), "%", "");
            lV126Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1), "%", "");
            lV127Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1), "%", "");
            lV127Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1), "%", "");
            lV128Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1), "%", "");
            lV128Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1), "%", "");
            lV132Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2), "%", "");
            lV132Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2), "%", "");
            lV133Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2), "%", "");
            lV133Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2), "%", "");
            lV134Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2), "%", "");
            lV134Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2), "%", "");
            lV135Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2), "%", "");
            lV135Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2), "%", "");
            lV136Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2), "%", "");
            lV136Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2), "%", "");
            lV137Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_22_municipionome2), "%", "");
            lV137Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_22_municipionome2), "%", "");
            lV139Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2), "%", "");
            lV139Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2), "%", "");
            lV140Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2), "%", "");
            lV140Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2), "%", "");
            lV141Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2), "%", "");
            lV141Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2), "%", "");
            lV145Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3), "%", "");
            lV145Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3), "%", "");
            lV146Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3), "%", "");
            lV146Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3), "%", "");
            lV147Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3), "%", "");
            lV147Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3), "%", "");
            lV148Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3), "%", "");
            lV148Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3), "%", "");
            lV149Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3), "%", "");
            lV149Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3), "%", "");
            lV150Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV150Clientewwds_35_municipionome3), "%", "");
            lV150Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV150Clientewwds_35_municipionome3), "%", "");
            lV152Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3), "%", "");
            lV152Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3), "%", "");
            lV153Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3), "%", "");
            lV153Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3), "%", "");
            lV154Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3), "%", "");
            lV154Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3), "%", "");
            lV155Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV155Clientewwds_40_tftipoclientedescricao), "%", "");
            lV157Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV157Clientewwds_42_tfclienterazaosocial), "%", "");
            lV159Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV159Clientewwds_44_tfclientedocumento), "%", "");
            /* Using cursor H003T3 */
            pr_default.execute(0, new Object[] {lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV119Clientewwds_4_clientedocumento1, lV119Clientewwds_4_clientedocumento1, lV120Clientewwds_5_tipoclientedescricao1, lV120Clientewwds_5_tipoclientedescricao1, lV121Clientewwds_6_clienteconveniodescricao1, lV121Clientewwds_6_clienteconveniodescricao1, lV122Clientewwds_7_clientenacionalidadenome1, lV122Clientewwds_7_clientenacionalidadenome1, lV123Clientewwds_8_clienteprofissaonome1, lV123Clientewwds_8_clienteprofissaonome1, lV124Clientewwds_9_municipionome1, lV124Clientewwds_9_municipionome1, AV125Clientewwds_10_bancocodigo1, AV125Clientewwds_10_bancocodigo1, AV125Clientewwds_10_bancocodigo1, lV126Clientewwds_11_responsavelnacionalidadenome1, lV126Clientewwds_11_responsavelnacionalidadenome1, lV127Clientewwds_12_responsavelprofissaonome1, lV127Clientewwds_12_responsavelprofissaonome1, lV128Clientewwds_13_responsavelmunicipionome1, lV128Clientewwds_13_responsavelmunicipionome1, lV132Clientewwds_17_clientedocumento2, lV132Clientewwds_17_clientedocumento2, lV133Clientewwds_18_tipoclientedescricao2, lV133Clientewwds_18_tipoclientedescricao2, lV134Clientewwds_19_clienteconveniodescricao2, lV134Clientewwds_19_clienteconveniodescricao2, lV135Clientewwds_20_clientenacionalidadenome2, lV135Clientewwds_20_clientenacionalidadenome2, lV136Clientewwds_21_clienteprofissaonome2, lV136Clientewwds_21_clienteprofissaonome2, lV137Clientewwds_22_municipionome2, lV137Clientewwds_22_municipionome2, AV138Clientewwds_23_bancocodigo2, AV138Clientewwds_23_bancocodigo2, AV138Clientewwds_23_bancocodigo2, lV139Clientewwds_24_responsavelnacionalidadenome2, lV139Clientewwds_24_responsavelnacionalidadenome2, lV140Clientewwds_25_responsavelprofissaonome2, lV140Clientewwds_25_responsavelprofissaonome2, lV141Clientewwds_26_responsavelmunicipionome2, lV141Clientewwds_26_responsavelmunicipionome2, lV145Clientewwds_30_clientedocumento3, lV145Clientewwds_30_clientedocumento3, lV146Clientewwds_31_tipoclientedescricao3, lV146Clientewwds_31_tipoclientedescricao3, lV147Clientewwds_32_clienteconveniodescricao3, lV147Clientewwds_32_clienteconveniodescricao3, lV148Clientewwds_33_clientenacionalidadenome3, lV148Clientewwds_33_clientenacionalidadenome3, lV149Clientewwds_34_clienteprofissaonome3, lV149Clientewwds_34_clienteprofissaonome3, lV150Clientewwds_35_municipionome3, lV150Clientewwds_35_municipionome3, AV151Clientewwds_36_bancocodigo3, AV151Clientewwds_36_bancocodigo3, AV151Clientewwds_36_bancocodigo3, lV152Clientewwds_37_responsavelnacionalidadenome3, lV152Clientewwds_37_responsavelnacionalidadenome3, lV153Clientewwds_38_responsavelprofissaonome3, lV153Clientewwds_38_responsavelprofissaonome3, lV154Clientewwds_39_responsavelmunicipionome3, lV154Clientewwds_39_responsavelmunicipionome3, lV155Clientewwds_40_tftipoclientedescricao, AV156Clientewwds_41_tftipoclientedescricao_sel, lV157Clientewwds_42_tfclienterazaosocial, AV158Clientewwds_43_tfclienterazaosocial_sel, lV159Clientewwds_44_tfclientedocumento, AV160Clientewwds_45_tfclientedocumento_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_188_idx = 1;
            sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
            SubsflControlProps_1882( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A186MunicipioCodigo = H003T3_A186MunicipioCodigo[0];
               n186MunicipioCodigo = H003T3_n186MunicipioCodigo[0];
               A444ResponsavelMunicipio = H003T3_A444ResponsavelMunicipio[0];
               n444ResponsavelMunicipio = H003T3_n444ResponsavelMunicipio[0];
               A402BancoId = H003T3_A402BancoId[0];
               n402BancoId = H003T3_n402BancoId[0];
               A437ResponsavelNacionalidade = H003T3_A437ResponsavelNacionalidade[0];
               n437ResponsavelNacionalidade = H003T3_n437ResponsavelNacionalidade[0];
               A484ClienteNacionalidade = H003T3_A484ClienteNacionalidade[0];
               n484ClienteNacionalidade = H003T3_n484ClienteNacionalidade[0];
               A442ResponsavelProfissao = H003T3_A442ResponsavelProfissao[0];
               n442ResponsavelProfissao = H003T3_n442ResponsavelProfissao[0];
               A487ClienteProfissao = H003T3_A487ClienteProfissao[0];
               n487ClienteProfissao = H003T3_n487ClienteProfissao[0];
               A489ClienteConvenio = H003T3_A489ClienteConvenio[0];
               n489ClienteConvenio = H003T3_n489ClienteConvenio[0];
               A445ResponsavelMunicipioNome = H003T3_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H003T3_n445ResponsavelMunicipioNome[0];
               A443ResponsavelProfissaoNome = H003T3_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H003T3_n443ResponsavelProfissaoNome[0];
               A438ResponsavelNacionalidadeNome = H003T3_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H003T3_n438ResponsavelNacionalidadeNome[0];
               A404BancoCodigo = H003T3_A404BancoCodigo[0];
               n404BancoCodigo = H003T3_n404BancoCodigo[0];
               A187MunicipioNome = H003T3_A187MunicipioNome[0];
               n187MunicipioNome = H003T3_n187MunicipioNome[0];
               A488ClienteProfissaoNome = H003T3_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H003T3_n488ClienteProfissaoNome[0];
               A485ClienteNacionalidadeNome = H003T3_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H003T3_n485ClienteNacionalidadeNome[0];
               A490ClienteConvenioDescricao = H003T3_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H003T3_n490ClienteConvenioDescricao[0];
               A207TipoClientePortal = H003T3_A207TipoClientePortal[0];
               n207TipoClientePortal = H003T3_n207TipoClientePortal[0];
               A177ClienteLogUser = H003T3_A177ClienteLogUser[0];
               n177ClienteLogUser = H003T3_n177ClienteLogUser[0];
               A176ClienteUpdatedAt = H003T3_A176ClienteUpdatedAt[0];
               n176ClienteUpdatedAt = H003T3_n176ClienteUpdatedAt[0];
               A175ClienteCreatedAt = H003T3_A175ClienteCreatedAt[0];
               n175ClienteCreatedAt = H003T3_n175ClienteCreatedAt[0];
               A174ClienteStatus = H003T3_A174ClienteStatus[0];
               n174ClienteStatus = H003T3_n174ClienteStatus[0];
               A192TipoClienteId = H003T3_A192TipoClienteId[0];
               n192TipoClienteId = H003T3_n192TipoClienteId[0];
               A172ClienteTipoPessoa = H003T3_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H003T3_n172ClienteTipoPessoa[0];
               A169ClienteDocumento = H003T3_A169ClienteDocumento[0];
               n169ClienteDocumento = H003T3_n169ClienteDocumento[0];
               A171ClienteNomeFantasia = H003T3_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H003T3_n171ClienteNomeFantasia[0];
               A170ClienteRazaoSocial = H003T3_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H003T3_n170ClienteRazaoSocial[0];
               A193TipoClienteDescricao = H003T3_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H003T3_n193TipoClienteDescricao[0];
               A168ClienteId = H003T3_A168ClienteId[0];
               A608SecUserId_F = H003T3_A608SecUserId_F[0];
               n608SecUserId_F = H003T3_n608SecUserId_F[0];
               A200ContatoNumero = H003T3_A200ContatoNumero[0];
               n200ContatoNumero = H003T3_n200ContatoNumero[0];
               A198ContatoDDD = H003T3_A198ContatoDDD[0];
               n198ContatoDDD = H003T3_n198ContatoDDD[0];
               A202ContatoTelefoneNumero = H003T3_A202ContatoTelefoneNumero[0];
               n202ContatoTelefoneNumero = H003T3_n202ContatoTelefoneNumero[0];
               A203ContatoTelefoneDDD = H003T3_A203ContatoTelefoneDDD[0];
               n203ContatoTelefoneDDD = H003T3_n203ContatoTelefoneDDD[0];
               A187MunicipioNome = H003T3_A187MunicipioNome[0];
               n187MunicipioNome = H003T3_n187MunicipioNome[0];
               A445ResponsavelMunicipioNome = H003T3_A445ResponsavelMunicipioNome[0];
               n445ResponsavelMunicipioNome = H003T3_n445ResponsavelMunicipioNome[0];
               A404BancoCodigo = H003T3_A404BancoCodigo[0];
               n404BancoCodigo = H003T3_n404BancoCodigo[0];
               A438ResponsavelNacionalidadeNome = H003T3_A438ResponsavelNacionalidadeNome[0];
               n438ResponsavelNacionalidadeNome = H003T3_n438ResponsavelNacionalidadeNome[0];
               A485ClienteNacionalidadeNome = H003T3_A485ClienteNacionalidadeNome[0];
               n485ClienteNacionalidadeNome = H003T3_n485ClienteNacionalidadeNome[0];
               A443ResponsavelProfissaoNome = H003T3_A443ResponsavelProfissaoNome[0];
               n443ResponsavelProfissaoNome = H003T3_n443ResponsavelProfissaoNome[0];
               A488ClienteProfissaoNome = H003T3_A488ClienteProfissaoNome[0];
               n488ClienteProfissaoNome = H003T3_n488ClienteProfissaoNome[0];
               A490ClienteConvenioDescricao = H003T3_A490ClienteConvenioDescricao[0];
               n490ClienteConvenioDescricao = H003T3_n490ClienteConvenioDescricao[0];
               A207TipoClientePortal = H003T3_A207TipoClientePortal[0];
               n207TipoClientePortal = H003T3_n207TipoClientePortal[0];
               A193TipoClienteDescricao = H003T3_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H003T3_n193TipoClienteDescricao[0];
               A608SecUserId_F = H003T3_A608SecUserId_F[0];
               n608SecUserId_F = H003T3_n608SecUserId_F[0];
               A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
               A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
               /* Execute user event: Grid.Load */
               E273T2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 188;
            WB3T0( ) ;
         }
         bGXsfl_188_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV115Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV115Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_188_idx, GetSecureSignedToken( sGXsfl_188_idx, context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"), context));
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
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV161Clientewwds_46_tfclientetipopessoa_sels ,
                                              AV116Clientewwds_1_filterfulltext ,
                                              AV117Clientewwds_2_dynamicfiltersselector1 ,
                                              AV118Clientewwds_3_dynamicfiltersoperator1 ,
                                              AV119Clientewwds_4_clientedocumento1 ,
                                              AV120Clientewwds_5_tipoclientedescricao1 ,
                                              AV121Clientewwds_6_clienteconveniodescricao1 ,
                                              AV122Clientewwds_7_clientenacionalidadenome1 ,
                                              AV123Clientewwds_8_clienteprofissaonome1 ,
                                              AV124Clientewwds_9_municipionome1 ,
                                              AV125Clientewwds_10_bancocodigo1 ,
                                              AV126Clientewwds_11_responsavelnacionalidadenome1 ,
                                              AV127Clientewwds_12_responsavelprofissaonome1 ,
                                              AV128Clientewwds_13_responsavelmunicipionome1 ,
                                              AV129Clientewwds_14_dynamicfiltersenabled2 ,
                                              AV130Clientewwds_15_dynamicfiltersselector2 ,
                                              AV131Clientewwds_16_dynamicfiltersoperator2 ,
                                              AV132Clientewwds_17_clientedocumento2 ,
                                              AV133Clientewwds_18_tipoclientedescricao2 ,
                                              AV134Clientewwds_19_clienteconveniodescricao2 ,
                                              AV135Clientewwds_20_clientenacionalidadenome2 ,
                                              AV136Clientewwds_21_clienteprofissaonome2 ,
                                              AV137Clientewwds_22_municipionome2 ,
                                              AV138Clientewwds_23_bancocodigo2 ,
                                              AV139Clientewwds_24_responsavelnacionalidadenome2 ,
                                              AV140Clientewwds_25_responsavelprofissaonome2 ,
                                              AV141Clientewwds_26_responsavelmunicipionome2 ,
                                              AV142Clientewwds_27_dynamicfiltersenabled3 ,
                                              AV143Clientewwds_28_dynamicfiltersselector3 ,
                                              AV144Clientewwds_29_dynamicfiltersoperator3 ,
                                              AV145Clientewwds_30_clientedocumento3 ,
                                              AV146Clientewwds_31_tipoclientedescricao3 ,
                                              AV147Clientewwds_32_clienteconveniodescricao3 ,
                                              AV148Clientewwds_33_clientenacionalidadenome3 ,
                                              AV149Clientewwds_34_clienteprofissaonome3 ,
                                              AV150Clientewwds_35_municipionome3 ,
                                              AV151Clientewwds_36_bancocodigo3 ,
                                              AV152Clientewwds_37_responsavelnacionalidadenome3 ,
                                              AV153Clientewwds_38_responsavelprofissaonome3 ,
                                              AV154Clientewwds_39_responsavelmunicipionome3 ,
                                              AV156Clientewwds_41_tftipoclientedescricao_sel ,
                                              AV155Clientewwds_40_tftipoclientedescricao ,
                                              AV158Clientewwds_43_tfclienterazaosocial_sel ,
                                              AV157Clientewwds_42_tfclienterazaosocial ,
                                              AV160Clientewwds_45_tfclientedocumento_sel ,
                                              AV159Clientewwds_44_tfclientedocumento ,
                                              AV161Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                              AV162Clientewwds_47_tfclientestatus_sel ,
                                              A193TipoClienteDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A174ClienteStatus ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              AV15OrderedBy ,
                                              AV16OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV116Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_1_filterfulltext), "%", "");
         lV119Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1), "%", "");
         lV119Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1), "%", "");
         lV120Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1), "%", "");
         lV120Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1), "%", "");
         lV121Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV121Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV122Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV122Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV123Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1), "%", "");
         lV123Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1), "%", "");
         lV124Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_9_municipionome1), "%", "");
         lV124Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_9_municipionome1), "%", "");
         lV126Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV126Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV127Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV127Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV128Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV128Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV132Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2), "%", "");
         lV132Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2), "%", "");
         lV133Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2), "%", "");
         lV133Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2), "%", "");
         lV134Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV134Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV135Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV135Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV136Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2), "%", "");
         lV136Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2), "%", "");
         lV137Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_22_municipionome2), "%", "");
         lV137Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_22_municipionome2), "%", "");
         lV139Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV139Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV140Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV140Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV141Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV141Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV145Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3), "%", "");
         lV145Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3), "%", "");
         lV146Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3), "%", "");
         lV146Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3), "%", "");
         lV147Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV147Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV148Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV148Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV149Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3), "%", "");
         lV149Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3), "%", "");
         lV150Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV150Clientewwds_35_municipionome3), "%", "");
         lV150Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV150Clientewwds_35_municipionome3), "%", "");
         lV152Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV152Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV153Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV153Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV154Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV154Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV155Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV155Clientewwds_40_tftipoclientedescricao), "%", "");
         lV157Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV157Clientewwds_42_tfclienterazaosocial), "%", "");
         lV159Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV159Clientewwds_44_tfclientedocumento), "%", "");
         /* Using cursor H003T5 */
         pr_default.execute(1, new Object[] {lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV116Clientewwds_1_filterfulltext, lV119Clientewwds_4_clientedocumento1, lV119Clientewwds_4_clientedocumento1, lV120Clientewwds_5_tipoclientedescricao1, lV120Clientewwds_5_tipoclientedescricao1, lV121Clientewwds_6_clienteconveniodescricao1, lV121Clientewwds_6_clienteconveniodescricao1, lV122Clientewwds_7_clientenacionalidadenome1, lV122Clientewwds_7_clientenacionalidadenome1, lV123Clientewwds_8_clienteprofissaonome1, lV123Clientewwds_8_clienteprofissaonome1, lV124Clientewwds_9_municipionome1, lV124Clientewwds_9_municipionome1, AV125Clientewwds_10_bancocodigo1, AV125Clientewwds_10_bancocodigo1, AV125Clientewwds_10_bancocodigo1, lV126Clientewwds_11_responsavelnacionalidadenome1, lV126Clientewwds_11_responsavelnacionalidadenome1, lV127Clientewwds_12_responsavelprofissaonome1, lV127Clientewwds_12_responsavelprofissaonome1, lV128Clientewwds_13_responsavelmunicipionome1, lV128Clientewwds_13_responsavelmunicipionome1, lV132Clientewwds_17_clientedocumento2, lV132Clientewwds_17_clientedocumento2, lV133Clientewwds_18_tipoclientedescricao2, lV133Clientewwds_18_tipoclientedescricao2, lV134Clientewwds_19_clienteconveniodescricao2, lV134Clientewwds_19_clienteconveniodescricao2, lV135Clientewwds_20_clientenacionalidadenome2, lV135Clientewwds_20_clientenacionalidadenome2, lV136Clientewwds_21_clienteprofissaonome2, lV136Clientewwds_21_clienteprofissaonome2, lV137Clientewwds_22_municipionome2, lV137Clientewwds_22_municipionome2, AV138Clientewwds_23_bancocodigo2, AV138Clientewwds_23_bancocodigo2, AV138Clientewwds_23_bancocodigo2, lV139Clientewwds_24_responsavelnacionalidadenome2, lV139Clientewwds_24_responsavelnacionalidadenome2, lV140Clientewwds_25_responsavelprofissaonome2, lV140Clientewwds_25_responsavelprofissaonome2, lV141Clientewwds_26_responsavelmunicipionome2, lV141Clientewwds_26_responsavelmunicipionome2, lV145Clientewwds_30_clientedocumento3, lV145Clientewwds_30_clientedocumento3, lV146Clientewwds_31_tipoclientedescricao3, lV146Clientewwds_31_tipoclientedescricao3, lV147Clientewwds_32_clienteconveniodescricao3, lV147Clientewwds_32_clienteconveniodescricao3, lV148Clientewwds_33_clientenacionalidadenome3, lV148Clientewwds_33_clientenacionalidadenome3, lV149Clientewwds_34_clienteprofissaonome3, lV149Clientewwds_34_clienteprofissaonome3, lV150Clientewwds_35_municipionome3, lV150Clientewwds_35_municipionome3, AV151Clientewwds_36_bancocodigo3, AV151Clientewwds_36_bancocodigo3, AV151Clientewwds_36_bancocodigo3, lV152Clientewwds_37_responsavelnacionalidadenome3, lV152Clientewwds_37_responsavelnacionalidadenome3, lV153Clientewwds_38_responsavelprofissaonome3, lV153Clientewwds_38_responsavelprofissaonome3, lV154Clientewwds_39_responsavelmunicipionome3, lV154Clientewwds_39_responsavelmunicipionome3, lV155Clientewwds_40_tftipoclientedescricao, AV156Clientewwds_41_tftipoclientedescricao_sel, lV157Clientewwds_42_tfclienterazaosocial, AV158Clientewwds_43_tfclienterazaosocial_sel, lV159Clientewwds_44_tfclientedocumento, AV160Clientewwds_45_tfclientedocumento_sel});
         GRID_nRecordCount = H003T5_AGRID_nRecordCount[0];
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
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV115Pgmname = "ClienteWW";
         edtClienteId_Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtClienteCelular_F_Enabled = 0;
         edtClienteTelefone_F_Enabled = 0;
         edtTipoClienteId_Enabled = 0;
         cmbClienteStatus.Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         edtClienteUpdatedAt_Enabled = 0;
         edtClienteLogUser_Enabled = 0;
         edtSecUserId_F_Enabled = 0;
         cmbTipoClientePortal.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E253T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV34ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV56DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_188 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_188"), ",", "."), 18, MidpointRounding.ToEven));
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
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV20ClienteDocumento1 = cgiGet( edtavClientedocumento1_Internalname);
            AssignAttri("", false, "AV20ClienteDocumento1", AV20ClienteDocumento1);
            AV68TipoClienteDescricao1 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao1_Internalname));
            AssignAttri("", false, "AV68TipoClienteDescricao1", AV68TipoClienteDescricao1);
            AV93ClienteConvenioDescricao1 = cgiGet( edtavClienteconveniodescricao1_Internalname);
            AssignAttri("", false, "AV93ClienteConvenioDescricao1", AV93ClienteConvenioDescricao1);
            AV94ClienteNacionalidadeNome1 = cgiGet( edtavClientenacionalidadenome1_Internalname);
            AssignAttri("", false, "AV94ClienteNacionalidadeNome1", AV94ClienteNacionalidadeNome1);
            AV95ClienteProfissaoNome1 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome1_Internalname));
            AssignAttri("", false, "AV95ClienteProfissaoNome1", AV95ClienteProfissaoNome1);
            AV79MunicipioNome1 = StringUtil.Upper( cgiGet( edtavMunicipionome1_Internalname));
            AssignAttri("", false, "AV79MunicipioNome1", AV79MunicipioNome1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO1");
               GX_FocusControl = edtavBancocodigo1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV96BancoCodigo1 = 0;
               AssignAttri("", false, "AV96BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV96BancoCodigo1), 9, 0));
            }
            else
            {
               AV96BancoCodigo1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV96BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV96BancoCodigo1), 9, 0));
            }
            AV97ResponsavelNacionalidadeNome1 = cgiGet( edtavResponsavelnacionalidadenome1_Internalname);
            AssignAttri("", false, "AV97ResponsavelNacionalidadeNome1", AV97ResponsavelNacionalidadeNome1);
            AV98ResponsavelProfissaoNome1 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome1_Internalname));
            AssignAttri("", false, "AV98ResponsavelProfissaoNome1", AV98ResponsavelProfissaoNome1);
            AV99ResponsavelMunicipioNome1 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome1_Internalname));
            AssignAttri("", false, "AV99ResponsavelMunicipioNome1", AV99ResponsavelMunicipioNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24ClienteDocumento2 = cgiGet( edtavClientedocumento2_Internalname);
            AssignAttri("", false, "AV24ClienteDocumento2", AV24ClienteDocumento2);
            AV70TipoClienteDescricao2 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao2_Internalname));
            AssignAttri("", false, "AV70TipoClienteDescricao2", AV70TipoClienteDescricao2);
            AV100ClienteConvenioDescricao2 = cgiGet( edtavClienteconveniodescricao2_Internalname);
            AssignAttri("", false, "AV100ClienteConvenioDescricao2", AV100ClienteConvenioDescricao2);
            AV101ClienteNacionalidadeNome2 = cgiGet( edtavClientenacionalidadenome2_Internalname);
            AssignAttri("", false, "AV101ClienteNacionalidadeNome2", AV101ClienteNacionalidadeNome2);
            AV102ClienteProfissaoNome2 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome2_Internalname));
            AssignAttri("", false, "AV102ClienteProfissaoNome2", AV102ClienteProfissaoNome2);
            AV80MunicipioNome2 = StringUtil.Upper( cgiGet( edtavMunicipionome2_Internalname));
            AssignAttri("", false, "AV80MunicipioNome2", AV80MunicipioNome2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO2");
               GX_FocusControl = edtavBancocodigo2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV103BancoCodigo2 = 0;
               AssignAttri("", false, "AV103BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV103BancoCodigo2), 9, 0));
            }
            else
            {
               AV103BancoCodigo2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV103BancoCodigo2), 9, 0));
            }
            AV104ResponsavelNacionalidadeNome2 = cgiGet( edtavResponsavelnacionalidadenome2_Internalname);
            AssignAttri("", false, "AV104ResponsavelNacionalidadeNome2", AV104ResponsavelNacionalidadeNome2);
            AV105ResponsavelProfissaoNome2 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome2_Internalname));
            AssignAttri("", false, "AV105ResponsavelProfissaoNome2", AV105ResponsavelProfissaoNome2);
            AV106ResponsavelMunicipioNome2 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome2_Internalname));
            AssignAttri("", false, "AV106ResponsavelMunicipioNome2", AV106ResponsavelMunicipioNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28ClienteDocumento3 = cgiGet( edtavClientedocumento3_Internalname);
            AssignAttri("", false, "AV28ClienteDocumento3", AV28ClienteDocumento3);
            AV72TipoClienteDescricao3 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao3_Internalname));
            AssignAttri("", false, "AV72TipoClienteDescricao3", AV72TipoClienteDescricao3);
            AV107ClienteConvenioDescricao3 = cgiGet( edtavClienteconveniodescricao3_Internalname);
            AssignAttri("", false, "AV107ClienteConvenioDescricao3", AV107ClienteConvenioDescricao3);
            AV108ClienteNacionalidadeNome3 = cgiGet( edtavClientenacionalidadenome3_Internalname);
            AssignAttri("", false, "AV108ClienteNacionalidadeNome3", AV108ClienteNacionalidadeNome3);
            AV109ClienteProfissaoNome3 = StringUtil.Upper( cgiGet( edtavClienteprofissaonome3_Internalname));
            AssignAttri("", false, "AV109ClienteProfissaoNome3", AV109ClienteProfissaoNome3);
            AV81MunicipioNome3 = StringUtil.Upper( cgiGet( edtavMunicipionome3_Internalname));
            AssignAttri("", false, "AV81MunicipioNome3", AV81MunicipioNome3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOCODIGO3");
               GX_FocusControl = edtavBancocodigo3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV110BancoCodigo3 = 0;
               AssignAttri("", false, "AV110BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV110BancoCodigo3), 9, 0));
            }
            else
            {
               AV110BancoCodigo3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancocodigo3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV110BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV110BancoCodigo3), 9, 0));
            }
            AV111ResponsavelNacionalidadeNome3 = cgiGet( edtavResponsavelnacionalidadenome3_Internalname);
            AssignAttri("", false, "AV111ResponsavelNacionalidadeNome3", AV111ResponsavelNacionalidadeNome3);
            AV112ResponsavelProfissaoNome3 = StringUtil.Upper( cgiGet( edtavResponsavelprofissaonome3_Internalname));
            AssignAttri("", false, "AV112ResponsavelProfissaoNome3", AV112ResponsavelProfissaoNome3);
            AV113ResponsavelMunicipioNome3 = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome3_Internalname));
            AssignAttri("", false, "AV113ResponsavelMunicipioNome3", AV113ResponsavelMunicipioNome3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV16OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV20ClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV68TipoClienteDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO1"), AV93ClienteConvenioDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME1"), AV94ClienteNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME1"), AV95ClienteProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME1"), AV79MunicipioNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO1"), ",", ".") != Convert.ToDecimal( AV96BancoCodigo1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME1"), AV97ResponsavelNacionalidadeNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME1"), AV98ResponsavelProfissaoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME1"), AV99ResponsavelMunicipioNome1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV24ClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV70TipoClienteDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO2"), AV100ClienteConvenioDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME2"), AV101ClienteNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME2"), AV102ClienteProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME2"), AV80MunicipioNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO2"), ",", ".") != Convert.ToDecimal( AV103BancoCodigo2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME2"), AV104ResponsavelNacionalidadeNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME2"), AV105ResponsavelProfissaoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME2"), AV106ResponsavelMunicipioNome2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV28ClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV72TipoClienteDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTECONVENIODESCRICAO3"), AV107ClienteConvenioDescricao3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTENACIONALIDADENOME3"), AV108ClienteNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEPROFISSAONOME3"), AV109ClienteProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUNICIPIONOME3"), AV81MunicipioNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBANCOCODIGO3"), ",", ".") != Convert.ToDecimal( AV110BancoCodigo3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELNACIONALIDADENOME3"), AV111ResponsavelNacionalidadeNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELPROFISSAONOME3"), AV112ResponsavelProfissaoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRESPONSAVELMUNICIPIONOME3"), AV113ResponsavelMunicipioNome3) != 0 )
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
         E253T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E253T2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV9HTTPRequest.Method, "GET") == 0 )
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
         AV18DynamicFiltersSelector1 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
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
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV56DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV56DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E263T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV36ManageFiltersExecutionStep == 1 )
         {
            AV36ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV36ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV36ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV36ManageFiltersExecutionStep == 2 )
         {
            AV36ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV36ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV36ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         GXt_char2 = AV60GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV115Pgmname, out  GXt_char2) ;
         AV60GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV60GridAppliedFilters", AV60GridAppliedFilters);
         cmbClienteStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbClienteStatus_Internalname, "Columnheaderclass", cmbClienteStatus_Columnheaderclass, !bGXsfl_188_Refreshing);
         AV116Clientewwds_1_filterfulltext = AV17FilterFullText;
         AV117Clientewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV118Clientewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV119Clientewwds_4_clientedocumento1 = AV20ClienteDocumento1;
         AV120Clientewwds_5_tipoclientedescricao1 = AV68TipoClienteDescricao1;
         AV121Clientewwds_6_clienteconveniodescricao1 = AV93ClienteConvenioDescricao1;
         AV122Clientewwds_7_clientenacionalidadenome1 = AV94ClienteNacionalidadeNome1;
         AV123Clientewwds_8_clienteprofissaonome1 = AV95ClienteProfissaoNome1;
         AV124Clientewwds_9_municipionome1 = AV79MunicipioNome1;
         AV125Clientewwds_10_bancocodigo1 = AV96BancoCodigo1;
         AV126Clientewwds_11_responsavelnacionalidadenome1 = AV97ResponsavelNacionalidadeNome1;
         AV127Clientewwds_12_responsavelprofissaonome1 = AV98ResponsavelProfissaoNome1;
         AV128Clientewwds_13_responsavelmunicipionome1 = AV99ResponsavelMunicipioNome1;
         AV129Clientewwds_14_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV130Clientewwds_15_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV131Clientewwds_16_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV132Clientewwds_17_clientedocumento2 = AV24ClienteDocumento2;
         AV133Clientewwds_18_tipoclientedescricao2 = AV70TipoClienteDescricao2;
         AV134Clientewwds_19_clienteconveniodescricao2 = AV100ClienteConvenioDescricao2;
         AV135Clientewwds_20_clientenacionalidadenome2 = AV101ClienteNacionalidadeNome2;
         AV136Clientewwds_21_clienteprofissaonome2 = AV102ClienteProfissaoNome2;
         AV137Clientewwds_22_municipionome2 = AV80MunicipioNome2;
         AV138Clientewwds_23_bancocodigo2 = AV103BancoCodigo2;
         AV139Clientewwds_24_responsavelnacionalidadenome2 = AV104ResponsavelNacionalidadeNome2;
         AV140Clientewwds_25_responsavelprofissaonome2 = AV105ResponsavelProfissaoNome2;
         AV141Clientewwds_26_responsavelmunicipionome2 = AV106ResponsavelMunicipioNome2;
         AV142Clientewwds_27_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV143Clientewwds_28_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV144Clientewwds_29_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV145Clientewwds_30_clientedocumento3 = AV28ClienteDocumento3;
         AV146Clientewwds_31_tipoclientedescricao3 = AV72TipoClienteDescricao3;
         AV147Clientewwds_32_clienteconveniodescricao3 = AV107ClienteConvenioDescricao3;
         AV148Clientewwds_33_clientenacionalidadenome3 = AV108ClienteNacionalidadeNome3;
         AV149Clientewwds_34_clienteprofissaonome3 = AV109ClienteProfissaoNome3;
         AV150Clientewwds_35_municipionome3 = AV81MunicipioNome3;
         AV151Clientewwds_36_bancocodigo3 = AV110BancoCodigo3;
         AV152Clientewwds_37_responsavelnacionalidadenome3 = AV111ResponsavelNacionalidadeNome3;
         AV153Clientewwds_38_responsavelprofissaonome3 = AV112ResponsavelProfissaoNome3;
         AV154Clientewwds_39_responsavelmunicipionome3 = AV113ResponsavelMunicipioNome3;
         AV155Clientewwds_40_tftipoclientedescricao = AV77TFTipoClienteDescricao;
         AV156Clientewwds_41_tftipoclientedescricao_sel = AV78TFTipoClienteDescricao_Sel;
         AV157Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV158Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV159Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV160Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV161Clientewwds_46_tfclientetipopessoa_sels = AV44TFClienteTipoPessoa_Sels;
         AV162Clientewwds_47_tfclientestatus_sel = AV45TFClienteStatus_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
      }

      protected void E123T2( )
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

      protected void E133T2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143T2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoClienteDescricao") == 0 )
            {
               AV77TFTipoClienteDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV77TFTipoClienteDescricao", AV77TFTipoClienteDescricao);
               AV78TFTipoClienteDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV78TFTipoClienteDescricao_Sel", AV78TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV37TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFClienteRazaoSocial", AV37TFClienteRazaoSocial);
               AV38TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFClienteRazaoSocial_Sel", AV38TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV41TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFClienteDocumento", AV41TFClienteDocumento);
               AV42TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFClienteDocumento_Sel", AV42TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTipoPessoa") == 0 )
            {
               AV43TFClienteTipoPessoa_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFClienteTipoPessoa_SelsJson", AV43TFClienteTipoPessoa_SelsJson);
               AV44TFClienteTipoPessoa_Sels.FromJSonString(AV43TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteStatus") == 0 )
            {
               AV45TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV45TFClienteStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44TFClienteTipoPessoa_Sels", AV44TFClienteTipoPessoa_Sels);
      }

      private void E273T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Mostrar", "fa fa-search", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         if ( A207TipoClientePortal )
         {
            cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", "Usuário", "fas fa-user-shield", "", "", "", "", "", "", ""), 0);
         }
         if ( A207TipoClientePortal )
         {
            cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", "Contratos", "fas fa-file-contract", "", "", "", "", "", "", ""), 0);
         }
         if ( A207TipoClientePortal )
         {
            cmbavGridactiongroup1.addItem("5", StringUtil.Format( "%1;%2", "Documentos", "far fa-folder-open", "", "", "", "", "", "", ""), 0);
         }
         if ( ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 ) && A207TipoClientePortal )
         {
            cmbavGridactiongroup1.addItem("6", StringUtil.Format( "%1;%2", "Responsável", "fas fa-user-large", "", "", "", "", "", "", ""), 0);
         }
         cmbavGridactiongroup1.addItem("7", StringUtil.Format( "%1;%2", "Crédito", "fas fa-hand-holding-dollar", "", "", "", "", "", "", ""), 0);
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
            wbStart = 188;
         }
         sendrow_1882( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_188_Refreshing )
         {
            DoAjaxLoad(188, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0));
      }

      protected void E203T2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
      }

      protected void E153T2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
      }

      protected void E213T2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E223T2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
      }

      protected void E163T2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
      }

      protected void E233T2( )
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

      protected void E173T2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ClienteDocumento1, AV68TipoClienteDescricao1, AV93ClienteConvenioDescricao1, AV94ClienteNacionalidadeNome1, AV95ClienteProfissaoNome1, AV79MunicipioNome1, AV96BancoCodigo1, AV97ResponsavelNacionalidadeNome1, AV98ResponsavelProfissaoNome1, AV99ResponsavelMunicipioNome1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ClienteDocumento2, AV70TipoClienteDescricao2, AV100ClienteConvenioDescricao2, AV101ClienteNacionalidadeNome2, AV102ClienteProfissaoNome2, AV80MunicipioNome2, AV103BancoCodigo2, AV104ResponsavelNacionalidadeNome2, AV105ResponsavelProfissaoNome2, AV106ResponsavelMunicipioNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28ClienteDocumento3, AV72TipoClienteDescricao3, AV107ClienteConvenioDescricao3, AV108ClienteNacionalidadeNome3, AV109ClienteProfissaoNome3, AV81MunicipioNome3, AV110BancoCodigo3, AV111ResponsavelNacionalidadeNome3, AV112ResponsavelProfissaoNome3, AV113ResponsavelMunicipioNome3, AV36ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV115Pgmname, AV77TFTipoClienteDescricao, AV78TFTipoClienteDescricao_Sel, AV37TFClienteRazaoSocial, AV38TFClienteRazaoSocial_Sel, AV41TFClienteDocumento, AV42TFClienteDocumento_Sel, AV44TFClienteTipoPessoa_Sels, AV45TFClienteStatus_Sel, AV12GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
      }

      protected void E243T2( )
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

      protected void E113T2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ClienteWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV115Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV36ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV36ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV36ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ClienteWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV36ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV36ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV36ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV35ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ClienteWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV35ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV115Pgmname+"GridState",  AV35ManageFiltersXml) ;
               AV12GridState.FromXml(AV35ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44TFClienteTipoPessoa_Sels", AV44TFClienteTipoPessoa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ManageFiltersData", AV34ManageFiltersData);
      }

      protected void E283T2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV114GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO USUARIO' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO CONTRATO' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 5 )
         {
            /* Execute user subroutine: 'DO ARQUIVOS' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 6 )
         {
            /* Execute user subroutine: 'DO RESPONSAVEL' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV114GridActionGroup1 == 7 )
         {
            /* Execute user subroutine: 'DO CREDITO' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV114GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV114GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E183T2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E193T2( )
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
         new clientewwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44TFClienteTipoPessoa_Sels", AV44TFClienteTipoPessoa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
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
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento1_Visible = 1;
            AssignProp("", false, edtavClientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao1_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao1_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome1_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome1_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome1_Visible = 1;
            AssignProp("", false, edtavMunicipionome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo1_Visible = 1;
            AssignProp("", false, edtavBancocodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome1_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome1_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento2_Visible = 1;
            AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao2_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao2_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome2_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome2_Visible = 1;
            AssignProp("", false, edtavMunicipionome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo2_Visible = 1;
            AssignProp("", false, edtavBancocodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome2_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome2_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento3_Visible = 1;
            AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao3_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
         {
            edtavClienteconveniodescricao3_Visible = 1;
            AssignProp("", false, edtavClienteconveniodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteconveniodescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
         {
            edtavClientenacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavClientenacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
         {
            edtavClienteprofissaonome3_Visible = 1;
            AssignProp("", false, edtavClienteprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
         {
            edtavMunicipionome3_Visible = 1;
            AssignProp("", false, edtavMunicipionome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
         {
            edtavBancocodigo3_Visible = 1;
            AssignProp("", false, edtavBancocodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancocodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
         {
            edtavResponsavelnacionalidadenome3_Visible = 1;
            AssignProp("", false, edtavResponsavelnacionalidadenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidadenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
         {
            edtavResponsavelprofissaonome3_Visible = 1;
            AssignProp("", false, edtavResponsavelprofissaonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissaonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
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
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24ClienteDocumento2 = "";
         AssignAttri("", false, "AV24ClienteDocumento2", AV24ClienteDocumento2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28ClienteDocumento3 = "";
         AssignAttri("", false, "AV28ClienteDocumento3", AV28ClienteDocumento3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV34ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ClienteWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV34ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV77TFTipoClienteDescricao = "";
         AssignAttri("", false, "AV77TFTipoClienteDescricao", AV77TFTipoClienteDescricao);
         AV78TFTipoClienteDescricao_Sel = "";
         AssignAttri("", false, "AV78TFTipoClienteDescricao_Sel", AV78TFTipoClienteDescricao_Sel);
         AV37TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV37TFClienteRazaoSocial", AV37TFClienteRazaoSocial);
         AV38TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV38TFClienteRazaoSocial_Sel", AV38TFClienteRazaoSocial_Sel);
         AV41TFClienteDocumento = "";
         AssignAttri("", false, "AV41TFClienteDocumento", AV41TFClienteDocumento);
         AV42TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV42TFClienteDocumento_Sel", AV42TFClienteDocumento_Sel);
         AV44TFClienteTipoPessoa_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45TFClienteStatus_Sel = 0;
         AssignAttri("", false, "AV45TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV45TFClienteStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV18DynamicFiltersSelector1 = "CLIENTEDOCUMENTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20ClienteDocumento1 = "";
         AssignAttri("", false, "AV20ClienteDocumento1", AV20ClienteDocumento1);
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
         AV12GridState.gxTpr_Dynamicfilters.Clear();
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
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO USUARIO' Routine */
         returnInSub = false;
      }

      protected void S272( )
      {
         /* 'DO CONTRATO' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contratoww"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("contratoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO ARQUIVOS' Routine */
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

      protected void S292( )
      {
         /* 'DO RESPONSAVEL' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpresponsavel"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wpresponsavel") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S302( )
      {
         /* 'DO CREDITO' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcredito"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         CallWebObject(formatLink("wcredito") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV115Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV115Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV33Session.Get(AV115Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV163GXV1 = 1;
         while ( AV163GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV163GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV77TFTipoClienteDescricao = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFTipoClienteDescricao", AV77TFTipoClienteDescricao);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV78TFTipoClienteDescricao_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFTipoClienteDescricao_Sel", AV78TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV37TFClienteRazaoSocial = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFClienteRazaoSocial", AV37TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV38TFClienteRazaoSocial_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFClienteRazaoSocial_Sel", AV38TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV41TFClienteDocumento = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFClienteDocumento", AV41TFClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV42TFClienteDocumento_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFClienteDocumento_Sel", AV42TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV43TFClienteTipoPessoa_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFClienteTipoPessoa_SelsJson", AV43TFClienteTipoPessoa_SelsJson);
               AV44TFClienteTipoPessoa_Sels.FromJSonString(AV43TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV45TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFClienteStatus_Sel", StringUtil.Str( (decimal)(AV45TFClienteStatus_Sel), 1, 0));
            }
            AV163GXV1 = (int)(AV163GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFTipoClienteDescricao_Sel)),  AV78TFTipoClienteDescricao_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFClienteRazaoSocial_Sel)),  AV38TFClienteRazaoSocial_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteDocumento_Sel)),  AV42TFClienteDocumento_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV44TFClienteTipoPessoa_Sels.Count==0),  AV43TFClienteTipoPessoa_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+((0==AV45TFClienteStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV45TFClienteStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFTipoClienteDescricao)),  AV77TFTipoClienteDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClienteRazaoSocial)),  AV37TFClienteRazaoSocial, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteDocumento)),  AV41TFClienteDocumento, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"||";
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
         if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV14GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20ClienteDocumento1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ClienteDocumento1", AV20ClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV68TipoClienteDescricao1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV68TipoClienteDescricao1", AV68TipoClienteDescricao1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV93ClienteConvenioDescricao1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV93ClienteConvenioDescricao1", AV93ClienteConvenioDescricao1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV94ClienteNacionalidadeNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV94ClienteNacionalidadeNome1", AV94ClienteNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV95ClienteProfissaoNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV95ClienteProfissaoNome1", AV95ClienteProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV79MunicipioNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV79MunicipioNome1", AV79MunicipioNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV96BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV14GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV96BancoCodigo1", StringUtil.LTrimStr( (decimal)(AV96BancoCodigo1), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV97ResponsavelNacionalidadeNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV97ResponsavelNacionalidadeNome1", AV97ResponsavelNacionalidadeNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV98ResponsavelProfissaoNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV98ResponsavelProfissaoNome1", AV98ResponsavelProfissaoNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV99ResponsavelMunicipioNome1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV99ResponsavelMunicipioNome1", AV99ResponsavelMunicipioNome1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 2 )
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
               AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV14GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24ClienteDocumento2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24ClienteDocumento2", AV24ClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV70TipoClienteDescricao2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV70TipoClienteDescricao2", AV70TipoClienteDescricao2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV100ClienteConvenioDescricao2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV100ClienteConvenioDescricao2", AV100ClienteConvenioDescricao2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV101ClienteNacionalidadeNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV101ClienteNacionalidadeNome2", AV101ClienteNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV102ClienteProfissaoNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV102ClienteProfissaoNome2", AV102ClienteProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV80MunicipioNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV80MunicipioNome2", AV80MunicipioNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV103BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV14GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV103BancoCodigo2", StringUtil.LTrimStr( (decimal)(AV103BancoCodigo2), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV104ResponsavelNacionalidadeNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV104ResponsavelNacionalidadeNome2", AV104ResponsavelNacionalidadeNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV105ResponsavelProfissaoNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV105ResponsavelProfissaoNome2", AV105ResponsavelProfissaoNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV106ResponsavelMunicipioNome2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV106ResponsavelMunicipioNome2", AV106ResponsavelMunicipioNome2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV14GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28ClienteDocumento3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28ClienteDocumento3", AV28ClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV72TipoClienteDescricao3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV72TipoClienteDescricao3", AV72TipoClienteDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV107ClienteConvenioDescricao3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV107ClienteConvenioDescricao3", AV107ClienteConvenioDescricao3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV108ClienteNacionalidadeNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV108ClienteNacionalidadeNome3", AV108ClienteNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV109ClienteProfissaoNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV109ClienteProfissaoNome3", AV109ClienteProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV81MunicipioNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV81MunicipioNome3", AV81MunicipioNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV110BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV14GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV110BancoCodigo3", StringUtil.LTrimStr( (decimal)(AV110BancoCodigo3), 9, 0));
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV111ResponsavelNacionalidadeNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV111ResponsavelNacionalidadeNome3", AV111ResponsavelNacionalidadeNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV112ResponsavelProfissaoNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV112ResponsavelProfissaoNome3", AV112ResponsavelProfissaoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV113ResponsavelMunicipioNome3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV113ResponsavelMunicipioNome3", AV113ResponsavelMunicipioNome3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV33Session.Get(AV115Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  AV17FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFTIPOCLIENTEDESCRICAO",  "Tipo cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFTipoClienteDescricao)),  0,  AV77TFTipoClienteDescricao,  AV77TFTipoClienteDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFTipoClienteDescricao_Sel)),  AV78TFTipoClienteDescricao_Sel,  AV78TFTipoClienteDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão social / nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClienteRazaoSocial)),  0,  AV37TFClienteRazaoSocial,  AV37TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFClienteRazaoSocial_Sel)),  AV38TFClienteRazaoSocial_Sel,  AV38TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCLIENTEDOCUMENTO",  "Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteDocumento)),  0,  AV41TFClienteDocumento,  AV41TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteDocumento_Sel)),  AV42TFClienteDocumento_Sel,  AV42TFClienteDocumento_Sel) ;
         AV67AuxText = ((AV44TFClienteTipoPessoa_Sels.Count==1) ? "["+((string)AV44TFClienteTipoPessoa_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCLIENTETIPOPESSOA_SEL",  "Tipo pessoa",  !(AV44TFClienteTipoPessoa_Sels.Count==0),  0,  AV44TFClienteTipoPessoa_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV67AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV67AuxText, "[FISICA]", "Física"), "[JURIDICA]", "Jurídica")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCLIENTESTATUS_SEL",  "Status",  !(0==AV45TFClienteStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFClienteStatus_Sel), 1, 0)),  ((AV45TFClienteStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV115Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV12GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Documento",  AV19DynamicFiltersOperator1,  AV20ClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20ClienteDocumento1, "Contém"+" "+AV20ClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV19DynamicFiltersOperator1,  AV68TipoClienteDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV68TipoClienteDescricao1, "Contém"+" "+AV68TipoClienteDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV93ClienteConvenioDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Convenio Descricao",  AV19DynamicFiltersOperator1,  AV93ClienteConvenioDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV93ClienteConvenioDescricao1, "Contém"+" "+AV93ClienteConvenioDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV94ClienteNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV19DynamicFiltersOperator1,  AV94ClienteNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV94ClienteNacionalidadeNome1, "Contém"+" "+AV94ClienteNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV95ClienteProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV19DynamicFiltersOperator1,  AV95ClienteProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV95ClienteProfissaoNome1, "Contém"+" "+AV95ClienteProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV79MunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV19DynamicFiltersOperator1,  AV79MunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV79MunicipioNome1, "Contém"+" "+AV79MunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ! (0==AV96BancoCodigo1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Banco Codigo",  AV19DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV96BancoCodigo1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV96BancoCodigo1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV96BancoCodigo1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV96BancoCodigo1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV97ResponsavelNacionalidadeNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV19DynamicFiltersOperator1,  AV97ResponsavelNacionalidadeNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV97ResponsavelNacionalidadeNome1, "Contém"+" "+AV97ResponsavelNacionalidadeNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV98ResponsavelProfissaoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV19DynamicFiltersOperator1,  AV98ResponsavelProfissaoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV98ResponsavelProfissaoNome1, "Contém"+" "+AV98ResponsavelProfissaoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV99ResponsavelMunicipioNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV19DynamicFiltersOperator1,  AV99ResponsavelMunicipioNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV99ResponsavelMunicipioNome1, "Contém"+" "+AV99ResponsavelMunicipioNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Documento",  AV23DynamicFiltersOperator2,  AV24ClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24ClienteDocumento2, "Contém"+" "+AV24ClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TipoClienteDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV23DynamicFiltersOperator2,  AV70TipoClienteDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV70TipoClienteDescricao2, "Contém"+" "+AV70TipoClienteDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV100ClienteConvenioDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Convenio Descricao",  AV23DynamicFiltersOperator2,  AV100ClienteConvenioDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV100ClienteConvenioDescricao2, "Contém"+" "+AV100ClienteConvenioDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV101ClienteNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV23DynamicFiltersOperator2,  AV101ClienteNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV101ClienteNacionalidadeNome2, "Contém"+" "+AV101ClienteNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV102ClienteProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV23DynamicFiltersOperator2,  AV102ClienteProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV102ClienteProfissaoNome2, "Contém"+" "+AV102ClienteProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV80MunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV23DynamicFiltersOperator2,  AV80MunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV80MunicipioNome2, "Contém"+" "+AV80MunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ! (0==AV103BancoCodigo2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Banco Codigo",  AV23DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV103BancoCodigo2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV103BancoCodigo2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV103BancoCodigo2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV103BancoCodigo2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV104ResponsavelNacionalidadeNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV23DynamicFiltersOperator2,  AV104ResponsavelNacionalidadeNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV104ResponsavelNacionalidadeNome2, "Contém"+" "+AV104ResponsavelNacionalidadeNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV105ResponsavelProfissaoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV23DynamicFiltersOperator2,  AV105ResponsavelProfissaoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV105ResponsavelProfissaoNome2, "Contém"+" "+AV105ResponsavelProfissaoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV106ResponsavelMunicipioNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV23DynamicFiltersOperator2,  AV106ResponsavelMunicipioNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV106ResponsavelMunicipioNome2, "Contém"+" "+AV106ResponsavelMunicipioNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Documento",  AV27DynamicFiltersOperator3,  AV28ClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28ClienteDocumento3, "Contém"+" "+AV28ClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TipoClienteDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV27DynamicFiltersOperator3,  AV72TipoClienteDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV72TipoClienteDescricao3, "Contém"+" "+AV72TipoClienteDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV107ClienteConvenioDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Convenio Descricao",  AV27DynamicFiltersOperator3,  AV107ClienteConvenioDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV107ClienteConvenioDescricao3, "Contém"+" "+AV107ClienteConvenioDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV108ClienteNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV27DynamicFiltersOperator3,  AV108ClienteNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV108ClienteNacionalidadeNome3, "Contém"+" "+AV108ClienteNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV109ClienteProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV27DynamicFiltersOperator3,  AV109ClienteProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV109ClienteProfissaoNome3, "Contém"+" "+AV109ClienteProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV81MunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV27DynamicFiltersOperator3,  AV81MunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV81MunicipioNome3, "Contém"+" "+AV81MunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ! (0==AV110BancoCodigo3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Banco Codigo",  AV27DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV110BancoCodigo3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV110BancoCodigo3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV110BancoCodigo3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV110BancoCodigo3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV111ResponsavelNacionalidadeNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Nacionalidade Nome",  AV27DynamicFiltersOperator3,  AV111ResponsavelNacionalidadeNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV111ResponsavelNacionalidadeNome3, "Contém"+" "+AV111ResponsavelNacionalidadeNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV112ResponsavelProfissaoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Profissao Nome",  AV27DynamicFiltersOperator3,  AV112ResponsavelProfissaoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV112ResponsavelProfissaoNome3, "Contém"+" "+AV112ResponsavelProfissaoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV113ResponsavelMunicipioNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Municipio Nome",  AV27DynamicFiltersOperator3,  AV113ResponsavelMunicipioNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV113ResponsavelMunicipioNome3, "Contém"+" "+AV113ResponsavelMunicipioNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV115Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Cliente";
         AV33Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_143_3T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento3_Internalname, "Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento3_Internalname, AV28ClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV28ClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento3_Visible, edtavClientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao3_Internalname, "Tipo Cliente Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao3_Internalname, AV72TipoClienteDescricao3, StringUtil.RTrim( context.localUtil.Format( AV72TipoClienteDescricao3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao3_Visible, edtavTipoclientedescricao3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao3_Internalname, "Cliente Convenio Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao3_Internalname, AV107ClienteConvenioDescricao3, StringUtil.RTrim( context.localUtil.Format( AV107ClienteConvenioDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao3_Visible, edtavClienteconveniodescricao3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome3_Internalname, "Cliente Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome3_Internalname, AV108ClienteNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV108ClienteNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome3_Visible, edtavClientenacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome3_Internalname, "Cliente Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome3_Internalname, AV109ClienteProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV109ClienteProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome3_Visible, edtavClienteprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome3_Internalname, "Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome3_Internalname, AV81MunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV81MunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome3_Visible, edtavMunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo3_Internalname, "Banco Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV110BancoCodigo3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV110BancoCodigo3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV110BancoCodigo3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo3_Visible, edtavBancocodigo3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome3_Internalname, "Responsavel Nacionalidade Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome3_Internalname, AV111ResponsavelNacionalidadeNome3, StringUtil.RTrim( context.localUtil.Format( AV111ResponsavelNacionalidadeNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome3_Visible, edtavResponsavelnacionalidadenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome3_Internalname, "Responsavel Profissao Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome3_Internalname, AV112ResponsavelProfissaoNome3, StringUtil.RTrim( context.localUtil.Format( AV112ResponsavelProfissaoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome3_Visible, edtavResponsavelprofissaonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome3_Internalname, "Responsavel Municipio Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome3_Internalname, AV113ResponsavelMunicipioNome3, StringUtil.RTrim( context.localUtil.Format( AV113ResponsavelMunicipioNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome3_Visible, edtavResponsavelmunicipionome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_143_3T2e( true) ;
         }
         else
         {
            wb_table3_143_3T2e( false) ;
         }
      }

      protected void wb_table2_94_3T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento2_Internalname, "Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento2_Internalname, AV24ClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV24ClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento2_Visible, edtavClientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao2_Internalname, "Tipo Cliente Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao2_Internalname, AV70TipoClienteDescricao2, StringUtil.RTrim( context.localUtil.Format( AV70TipoClienteDescricao2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao2_Visible, edtavTipoclientedescricao2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao2_Internalname, "Cliente Convenio Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao2_Internalname, AV100ClienteConvenioDescricao2, StringUtil.RTrim( context.localUtil.Format( AV100ClienteConvenioDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao2_Visible, edtavClienteconveniodescricao2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome2_Internalname, "Cliente Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome2_Internalname, AV101ClienteNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV101ClienteNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome2_Visible, edtavClientenacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome2_Internalname, "Cliente Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome2_Internalname, AV102ClienteProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV102ClienteProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome2_Visible, edtavClienteprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome2_Internalname, "Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome2_Internalname, AV80MunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV80MunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome2_Visible, edtavMunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo2_Internalname, "Banco Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103BancoCodigo2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV103BancoCodigo2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV103BancoCodigo2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo2_Visible, edtavBancocodigo2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome2_Internalname, "Responsavel Nacionalidade Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome2_Internalname, AV104ResponsavelNacionalidadeNome2, StringUtil.RTrim( context.localUtil.Format( AV104ResponsavelNacionalidadeNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome2_Visible, edtavResponsavelnacionalidadenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome2_Internalname, "Responsavel Profissao Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome2_Internalname, AV105ResponsavelProfissaoNome2, StringUtil.RTrim( context.localUtil.Format( AV105ResponsavelProfissaoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome2_Visible, edtavResponsavelprofissaonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome2_Internalname, "Responsavel Municipio Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome2_Internalname, AV106ResponsavelMunicipioNome2, StringUtil.RTrim( context.localUtil.Format( AV106ResponsavelMunicipioNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome2_Visible, edtavResponsavelmunicipionome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_94_3T2e( true) ;
         }
         else
         {
            wb_table2_94_3T2e( false) ;
         }
      }

      protected void wb_table1_45_3T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_188_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ClienteWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento1_Internalname, "Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento1_Internalname, AV20ClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV20ClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento1_Visible, edtavClientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao1_Internalname, "Tipo Cliente Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao1_Internalname, AV68TipoClienteDescricao1, StringUtil.RTrim( context.localUtil.Format( AV68TipoClienteDescricao1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao1_Visible, edtavTipoclientedescricao1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteconveniodescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteconveniodescricao1_Internalname, "Cliente Convenio Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteconveniodescricao1_Internalname, AV93ClienteConvenioDescricao1, StringUtil.RTrim( context.localUtil.Format( AV93ClienteConvenioDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteconveniodescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteconveniodescricao1_Visible, edtavClienteconveniodescricao1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientenacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenacionalidadenome1_Internalname, "Cliente Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidadenome1_Internalname, AV94ClienteNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV94ClienteNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidadenome1_Visible, edtavClientenacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clienteprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienteprofissaonome1_Internalname, "Cliente Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissaonome1_Internalname, AV95ClienteProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV95ClienteProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissaonome1_Visible, edtavClienteprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_municipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome1_Internalname, "Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome1_Internalname, AV79MunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV79MunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome1_Visible, edtavMunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bancocodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBancocodigo1_Internalname, "Banco Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancocodigo1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96BancoCodigo1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavBancocodigo1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV96BancoCodigo1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV96BancoCodigo1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancocodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancocodigo1_Visible, edtavBancocodigo1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelnacionalidadenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnacionalidadenome1_Internalname, "Responsavel Nacionalidade Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidadenome1_Internalname, AV97ResponsavelNacionalidadeNome1, StringUtil.RTrim( context.localUtil.Format( AV97ResponsavelNacionalidadeNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidadenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidadenome1_Visible, edtavResponsavelnacionalidadenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelprofissaonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelprofissaonome1_Internalname, "Responsavel Profissao Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissaonome1_Internalname, AV98ResponsavelProfissaoNome1, StringUtil.RTrim( context.localUtil.Format( AV98ResponsavelProfissaoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissaonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissaonome1_Visible, edtavResponsavelprofissaonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_responsavelmunicipionome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome1_Internalname, "Responsavel Municipio Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_188_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome1_Internalname, AV99ResponsavelMunicipioNome1, StringUtil.RTrim( context.localUtil.Format( AV99ResponsavelMunicipioNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipionome1_Visible, edtavResponsavelmunicipionome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_3T2e( true) ;
         }
         else
         {
            wb_table1_45_3T2e( false) ;
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019243845", true, true);
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
         context.AddJavascriptSource("clienteww.js", "?202561019243846", false, true);
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

      protected void SubsflControlProps_1882( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_188_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_188_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_188_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_188_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_188_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_188_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_188_idx;
         edtClienteCelular_F_Internalname = "CLIENTECELULAR_F_"+sGXsfl_188_idx;
         edtClienteTelefone_F_Internalname = "CLIENTETELEFONE_F_"+sGXsfl_188_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_188_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_188_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_188_idx;
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT_"+sGXsfl_188_idx;
         edtClienteLogUser_Internalname = "CLIENTELOGUSER_"+sGXsfl_188_idx;
         edtSecUserId_F_Internalname = "SECUSERID_F_"+sGXsfl_188_idx;
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL_"+sGXsfl_188_idx;
      }

      protected void SubsflControlProps_fel_1882( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_188_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_188_fel_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_188_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_188_fel_idx;
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA_"+sGXsfl_188_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_188_fel_idx;
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA_"+sGXsfl_188_fel_idx;
         edtClienteCelular_F_Internalname = "CLIENTECELULAR_F_"+sGXsfl_188_fel_idx;
         edtClienteTelefone_F_Internalname = "CLIENTETELEFONE_F_"+sGXsfl_188_fel_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_188_fel_idx;
         cmbClienteStatus_Internalname = "CLIENTESTATUS_"+sGXsfl_188_fel_idx;
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT_"+sGXsfl_188_fel_idx;
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT_"+sGXsfl_188_fel_idx;
         edtClienteLogUser_Internalname = "CLIENTELOGUSER_"+sGXsfl_188_fel_idx;
         edtSecUserId_F_Internalname = "SECUSERID_F_"+sGXsfl_188_fel_idx;
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL_"+sGXsfl_188_fel_idx;
      }

      protected void sendrow_1882( )
      {
         sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
         SubsflControlProps_1882( ) ;
         WB3T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_188_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_188_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_188_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'" + sGXsfl_188_idx + "',188)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_188_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV114GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV114GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_188_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ActionGroupGrouped ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_188_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteDescricao_Internalname,(string)A193TipoClienteDescricao,StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNomeFantasia_Internalname,(string)A171ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteNomeFantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteTipoPessoa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_188_idx;
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
            AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", (string)(cmbClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_188_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCelular_F_Internalname,(string)A206ClienteCelular_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCelular_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTelefone_F_Internalname,(string)A205ClienteTelefone_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTelefone_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTESTATUS_" + sGXsfl_188_idx;
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
            AssignProp("", false, cmbClienteStatus_Internalname, "Values", (string)(cmbClienteStatus.ToJavascriptSource()), !bGXsfl_188_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCreatedAt_Internalname,context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A175ClienteCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteUpdatedAt_Internalname,context.localUtil.TToC( A176ClienteUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A176ClienteUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteLogUser_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A177ClienteLogUser), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A177ClienteLogUser), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteLogUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A608SecUserId_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A608SecUserId_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)188,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "TIPOCLIENTEPORTAL_" + sGXsfl_188_idx;
            cmbTipoClientePortal.Name = GXCCtl;
            cmbTipoClientePortal.WebTags = "";
            cmbTipoClientePortal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
            cmbTipoClientePortal.addItem(StringUtil.BoolToStr( false), "Não", 0);
            if ( cmbTipoClientePortal.ItemCount > 0 )
            {
               A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
               n207TipoClientePortal = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTipoClientePortal,(string)cmbTipoClientePortal_Internalname,StringUtil.BoolToStr( A207TipoClientePortal),(short)1,(string)cmbTipoClientePortal_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTipoClientePortal.CurrentValue = StringUtil.BoolToStr( A207TipoClientePortal);
            AssignProp("", false, cmbTipoClientePortal_Internalname, "Values", (string)(cmbTipoClientePortal.ToJavascriptSource()), !bGXsfl_188_Refreshing);
            send_integrity_lvl_hashes3T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_188_idx = ((subGrid_Islastpage==1)&&(nGXsfl_188_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_188_idx+1);
            sGXsfl_188_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_188_idx), 4, 0), 4, "0");
            SubsflControlProps_1882( ) ;
         }
         /* End function sendrow_1882 */
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
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
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
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
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
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_188_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV114GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV114GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV114GridActionGroup1), 4, 0));
         }
         GXCCtl = "CLIENTETIPOPESSOA_" + sGXsfl_188_idx;
         cmbClienteTipoPessoa.Name = GXCCtl;
         cmbClienteTipoPessoa.WebTags = "";
         cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
         }
         GXCCtl = "CLIENTESTATUS_" + sGXsfl_188_idx;
         cmbClienteStatus.Name = GXCCtl;
         cmbClienteStatus.WebTags = "";
         cmbClienteStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbClienteStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbClienteStatus.ItemCount > 0 )
         {
            A174ClienteStatus = StringUtil.StrToBool( cmbClienteStatus.getValidValue(StringUtil.BoolToStr( A174ClienteStatus)));
            n174ClienteStatus = false;
         }
         GXCCtl = "TIPOCLIENTEPORTAL_" + sGXsfl_188_idx;
         cmbTipoClientePortal.Name = GXCCtl;
         cmbTipoClientePortal.WebTags = "";
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbTipoClientePortal.ItemCount > 0 )
         {
            A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
            n207TipoClientePortal = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl188( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"188\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionGroupGrouped ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Razão social / nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo pessoa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Celular") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "User Id_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Acesso ao portal clinica") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193TipoClienteDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A171ClienteNomeFantasia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A169ClienteDocumento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A172ClienteTipoPessoa));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A206ClienteCelular_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A205ClienteTelefone_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A608SecUserId_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A207TipoClientePortal)));
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
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA";
         edtClienteCelular_F_Internalname = "CLIENTECELULAR_F";
         edtClienteTelefone_F_Internalname = "CLIENTETELEFONE_F";
         edtTipoClienteId_Internalname = "TIPOCLIENTEID";
         cmbClienteStatus_Internalname = "CLIENTESTATUS";
         edtClienteCreatedAt_Internalname = "CLIENTECREATEDAT";
         edtClienteUpdatedAt_Internalname = "CLIENTEUPDATEDAT";
         edtClienteLogUser_Internalname = "CLIENTELOGUSER";
         edtSecUserId_F_Internalname = "SECUSERID_F";
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL";
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
         cmbTipoClientePortal_Jsonclick = "";
         edtSecUserId_F_Jsonclick = "";
         edtClienteLogUser_Jsonclick = "";
         edtClienteUpdatedAt_Jsonclick = "";
         edtClienteCreatedAt_Jsonclick = "";
         cmbClienteStatus_Jsonclick = "";
         cmbClienteStatus_Columnclass = "WWColumn";
         edtTipoClienteId_Jsonclick = "";
         edtClienteTelefone_F_Jsonclick = "";
         edtClienteCelular_F_Jsonclick = "";
         cmbClienteTipoPessoa_Jsonclick = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteNomeFantasia_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtTipoClienteDescricao_Jsonclick = "";
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
         cmbClienteStatus_Columnheaderclass = "";
         cmbTipoClientePortal.Enabled = 0;
         edtSecUserId_F_Enabled = 0;
         edtClienteLogUser_Enabled = 0;
         edtClienteUpdatedAt_Enabled = 0;
         edtClienteCreatedAt_Enabled = 0;
         cmbClienteStatus.Enabled = 0;
         edtTipoClienteId_Enabled = 0;
         edtClienteTelefone_F_Enabled = 0;
         edtClienteCelular_F_Enabled = 0;
         cmbClienteTipoPessoa.Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteNomeFantasia_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
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
         Ddo_grid_Datalistproc = "ClienteWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||FISICA:Física,JURIDICA:Jurídica|1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Allowmultipleselection = "|||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character||";
         Ddo_grid_Includefilter = "T|T|T||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5";
         Ddo_grid_Columnids = "2:TipoClienteDescricao|3:ClienteRazaoSocial|5:ClienteDocumento|6:ClienteTipoPessoa|10:ClienteStatus";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV43TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E273T2","iparms":[{"av":"cmbTipoClientePortal"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"cmbClienteTipoPessoa"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV114GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"cmbClienteStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E203T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E153T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E213T2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E223T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E163T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E233T2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E173T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E243T2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV43TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV43TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbClienteStatus"},{"av":"AV34ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E283T2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV114GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV114GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E183T2","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E193T2","iparms":[{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV43TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV68TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"AV93ClienteConvenioDescricao1","fld":"vCLIENTECONVENIODESCRICAO1","type":"svchar"},{"av":"AV94ClienteNacionalidadeNome1","fld":"vCLIENTENACIONALIDADENOME1","type":"svchar"},{"av":"AV95ClienteProfissaoNome1","fld":"vCLIENTEPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV79MunicipioNome1","fld":"vMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"AV96BancoCodigo1","fld":"vBANCOCODIGO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV97ResponsavelNacionalidadeNome1","fld":"vRESPONSAVELNACIONALIDADENOME1","type":"svchar"},{"av":"AV98ResponsavelProfissaoNome1","fld":"vRESPONSAVELPROFISSAONOME1","pic":"@!","type":"svchar"},{"av":"AV99ResponsavelMunicipioNome1","fld":"vRESPONSAVELMUNICIPIONOME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV70TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV100ClienteConvenioDescricao2","fld":"vCLIENTECONVENIODESCRICAO2","type":"svchar"},{"av":"AV101ClienteNacionalidadeNome2","fld":"vCLIENTENACIONALIDADENOME2","type":"svchar"},{"av":"AV102ClienteProfissaoNome2","fld":"vCLIENTEPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV80MunicipioNome2","fld":"vMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"AV103BancoCodigo2","fld":"vBANCOCODIGO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104ResponsavelNacionalidadeNome2","fld":"vRESPONSAVELNACIONALIDADENOME2","type":"svchar"},{"av":"AV105ResponsavelProfissaoNome2","fld":"vRESPONSAVELPROFISSAONOME2","pic":"@!","type":"svchar"},{"av":"AV106ResponsavelMunicipioNome2","fld":"vRESPONSAVELMUNICIPIONOME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV72TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV107ClienteConvenioDescricao3","fld":"vCLIENTECONVENIODESCRICAO3","type":"svchar"},{"av":"AV108ClienteNacionalidadeNome3","fld":"vCLIENTENACIONALIDADENOME3","type":"svchar"},{"av":"AV109ClienteProfissaoNome3","fld":"vCLIENTEPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV81MunicipioNome3","fld":"vMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV110BancoCodigo3","fld":"vBANCOCODIGO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV111ResponsavelNacionalidadeNome3","fld":"vRESPONSAVELNACIONALIDADENOME3","type":"svchar"},{"av":"AV112ResponsavelProfissaoNome3","fld":"vRESPONSAVELPROFISSAONOME3","pic":"@!","type":"svchar"},{"av":"AV113ResponsavelMunicipioNome3","fld":"vRESPONSAVELMUNICIPIONOME3","pic":"@!","type":"svchar"},{"av":"AV36ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV115Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV77TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV78TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV42TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV44TFClienteTipoPessoa_Sels","fld":"vTFCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV45TFClienteStatus_Sel","fld":"vTFCLIENTESTATUS_SEL","pic":"9","type":"int"},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV43TFClienteTipoPessoa_SelsJson","fld":"vTFCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavClienteconveniodescricao1_Visible","ctrl":"vCLIENTECONVENIODESCRICAO1","prop":"Visible"},{"av":"edtavClientenacionalidadenome1_Visible","ctrl":"vCLIENTENACIONALIDADENOME1","prop":"Visible"},{"av":"edtavClienteprofissaonome1_Visible","ctrl":"vCLIENTEPROFISSAONOME1","prop":"Visible"},{"av":"edtavMunicipionome1_Visible","ctrl":"vMUNICIPIONOME1","prop":"Visible"},{"av":"edtavBancocodigo1_Visible","ctrl":"vBANCOCODIGO1","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome1_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME1","prop":"Visible"},{"av":"edtavResponsavelprofissaonome1_Visible","ctrl":"vRESPONSAVELPROFISSAONOME1","prop":"Visible"},{"av":"edtavResponsavelmunicipionome1_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME1","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavClienteconveniodescricao2_Visible","ctrl":"vCLIENTECONVENIODESCRICAO2","prop":"Visible"},{"av":"edtavClientenacionalidadenome2_Visible","ctrl":"vCLIENTENACIONALIDADENOME2","prop":"Visible"},{"av":"edtavClienteprofissaonome2_Visible","ctrl":"vCLIENTEPROFISSAONOME2","prop":"Visible"},{"av":"edtavMunicipionome2_Visible","ctrl":"vMUNICIPIONOME2","prop":"Visible"},{"av":"edtavBancocodigo2_Visible","ctrl":"vBANCOCODIGO2","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome2_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME2","prop":"Visible"},{"av":"edtavResponsavelprofissaonome2_Visible","ctrl":"vRESPONSAVELPROFISSAONOME2","prop":"Visible"},{"av":"edtavResponsavelmunicipionome2_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME2","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavClienteconveniodescricao3_Visible","ctrl":"vCLIENTECONVENIODESCRICAO3","prop":"Visible"},{"av":"edtavClientenacionalidadenome3_Visible","ctrl":"vCLIENTENACIONALIDADENOME3","prop":"Visible"},{"av":"edtavClienteprofissaonome3_Visible","ctrl":"vCLIENTEPROFISSAONOME3","prop":"Visible"},{"av":"edtavMunicipionome3_Visible","ctrl":"vMUNICIPIONOME3","prop":"Visible"},{"av":"edtavBancocodigo3_Visible","ctrl":"vBANCOCODIGO3","prop":"Visible"},{"av":"edtavResponsavelnacionalidadenome3_Visible","ctrl":"vRESPONSAVELNACIONALIDADENOME3","prop":"Visible"},{"av":"edtavResponsavelprofissaonome3_Visible","ctrl":"vRESPONSAVELPROFISSAONOME3","prop":"Visible"},{"av":"edtavResponsavelmunicipionome3_Visible","ctrl":"vRESPONSAVELMUNICIPIONOME3","prop":"Visible"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTEID","""{"handler":"Valid_Tipoclienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Tipoclienteportal","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20ClienteDocumento1 = "";
         AV68TipoClienteDescricao1 = "";
         AV93ClienteConvenioDescricao1 = "";
         AV94ClienteNacionalidadeNome1 = "";
         AV95ClienteProfissaoNome1 = "";
         AV79MunicipioNome1 = "";
         AV97ResponsavelNacionalidadeNome1 = "";
         AV98ResponsavelProfissaoNome1 = "";
         AV99ResponsavelMunicipioNome1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ClienteDocumento2 = "";
         AV70TipoClienteDescricao2 = "";
         AV100ClienteConvenioDescricao2 = "";
         AV101ClienteNacionalidadeNome2 = "";
         AV102ClienteProfissaoNome2 = "";
         AV80MunicipioNome2 = "";
         AV104ResponsavelNacionalidadeNome2 = "";
         AV105ResponsavelProfissaoNome2 = "";
         AV106ResponsavelMunicipioNome2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ClienteDocumento3 = "";
         AV72TipoClienteDescricao3 = "";
         AV107ClienteConvenioDescricao3 = "";
         AV108ClienteNacionalidadeNome3 = "";
         AV109ClienteProfissaoNome3 = "";
         AV81MunicipioNome3 = "";
         AV111ResponsavelNacionalidadeNome3 = "";
         AV112ResponsavelProfissaoNome3 = "";
         AV113ResponsavelMunicipioNome3 = "";
         AV115Pgmname = "";
         AV77TFTipoClienteDescricao = "";
         AV78TFTipoClienteDescricao_Sel = "";
         AV37TFClienteRazaoSocial = "";
         AV38TFClienteRazaoSocial_Sel = "";
         AV41TFClienteDocumento = "";
         AV42TFClienteDocumento_Sel = "";
         AV44TFClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV34ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60GridAppliedFilters = "";
         AV56DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV43TFClienteTipoPessoa_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         A193TipoClienteDescricao = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         A169ClienteDocumento = "";
         A172ClienteTipoPessoa = "";
         A206ClienteCelular_F = "";
         A205ClienteTelefone_F = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         AV161Clientewwds_46_tfclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV116Clientewwds_1_filterfulltext = "";
         lV119Clientewwds_4_clientedocumento1 = "";
         lV120Clientewwds_5_tipoclientedescricao1 = "";
         lV121Clientewwds_6_clienteconveniodescricao1 = "";
         lV122Clientewwds_7_clientenacionalidadenome1 = "";
         lV123Clientewwds_8_clienteprofissaonome1 = "";
         lV124Clientewwds_9_municipionome1 = "";
         lV126Clientewwds_11_responsavelnacionalidadenome1 = "";
         lV127Clientewwds_12_responsavelprofissaonome1 = "";
         lV128Clientewwds_13_responsavelmunicipionome1 = "";
         lV132Clientewwds_17_clientedocumento2 = "";
         lV133Clientewwds_18_tipoclientedescricao2 = "";
         lV134Clientewwds_19_clienteconveniodescricao2 = "";
         lV135Clientewwds_20_clientenacionalidadenome2 = "";
         lV136Clientewwds_21_clienteprofissaonome2 = "";
         lV137Clientewwds_22_municipionome2 = "";
         lV139Clientewwds_24_responsavelnacionalidadenome2 = "";
         lV140Clientewwds_25_responsavelprofissaonome2 = "";
         lV141Clientewwds_26_responsavelmunicipionome2 = "";
         lV145Clientewwds_30_clientedocumento3 = "";
         lV146Clientewwds_31_tipoclientedescricao3 = "";
         lV147Clientewwds_32_clienteconveniodescricao3 = "";
         lV148Clientewwds_33_clientenacionalidadenome3 = "";
         lV149Clientewwds_34_clienteprofissaonome3 = "";
         lV150Clientewwds_35_municipionome3 = "";
         lV152Clientewwds_37_responsavelnacionalidadenome3 = "";
         lV153Clientewwds_38_responsavelprofissaonome3 = "";
         lV154Clientewwds_39_responsavelmunicipionome3 = "";
         lV155Clientewwds_40_tftipoclientedescricao = "";
         lV157Clientewwds_42_tfclienterazaosocial = "";
         lV159Clientewwds_44_tfclientedocumento = "";
         AV116Clientewwds_1_filterfulltext = "";
         AV117Clientewwds_2_dynamicfiltersselector1 = "";
         AV119Clientewwds_4_clientedocumento1 = "";
         AV120Clientewwds_5_tipoclientedescricao1 = "";
         AV121Clientewwds_6_clienteconveniodescricao1 = "";
         AV122Clientewwds_7_clientenacionalidadenome1 = "";
         AV123Clientewwds_8_clienteprofissaonome1 = "";
         AV124Clientewwds_9_municipionome1 = "";
         AV126Clientewwds_11_responsavelnacionalidadenome1 = "";
         AV127Clientewwds_12_responsavelprofissaonome1 = "";
         AV128Clientewwds_13_responsavelmunicipionome1 = "";
         AV130Clientewwds_15_dynamicfiltersselector2 = "";
         AV132Clientewwds_17_clientedocumento2 = "";
         AV133Clientewwds_18_tipoclientedescricao2 = "";
         AV134Clientewwds_19_clienteconveniodescricao2 = "";
         AV135Clientewwds_20_clientenacionalidadenome2 = "";
         AV136Clientewwds_21_clienteprofissaonome2 = "";
         AV137Clientewwds_22_municipionome2 = "";
         AV139Clientewwds_24_responsavelnacionalidadenome2 = "";
         AV140Clientewwds_25_responsavelprofissaonome2 = "";
         AV141Clientewwds_26_responsavelmunicipionome2 = "";
         AV143Clientewwds_28_dynamicfiltersselector3 = "";
         AV145Clientewwds_30_clientedocumento3 = "";
         AV146Clientewwds_31_tipoclientedescricao3 = "";
         AV147Clientewwds_32_clienteconveniodescricao3 = "";
         AV148Clientewwds_33_clientenacionalidadenome3 = "";
         AV149Clientewwds_34_clienteprofissaonome3 = "";
         AV150Clientewwds_35_municipionome3 = "";
         AV152Clientewwds_37_responsavelnacionalidadenome3 = "";
         AV153Clientewwds_38_responsavelprofissaonome3 = "";
         AV154Clientewwds_39_responsavelmunicipionome3 = "";
         AV156Clientewwds_41_tftipoclientedescricao_sel = "";
         AV155Clientewwds_40_tftipoclientedescricao = "";
         AV158Clientewwds_43_tfclienterazaosocial_sel = "";
         AV157Clientewwds_42_tfclienterazaosocial = "";
         AV160Clientewwds_45_tfclientedocumento_sel = "";
         AV159Clientewwds_44_tfclientedocumento = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         H003T3_A186MunicipioCodigo = new string[] {""} ;
         H003T3_n186MunicipioCodigo = new bool[] {false} ;
         H003T3_A444ResponsavelMunicipio = new string[] {""} ;
         H003T3_n444ResponsavelMunicipio = new bool[] {false} ;
         H003T3_A402BancoId = new int[1] ;
         H003T3_n402BancoId = new bool[] {false} ;
         H003T3_A437ResponsavelNacionalidade = new int[1] ;
         H003T3_n437ResponsavelNacionalidade = new bool[] {false} ;
         H003T3_A484ClienteNacionalidade = new int[1] ;
         H003T3_n484ClienteNacionalidade = new bool[] {false} ;
         H003T3_A442ResponsavelProfissao = new int[1] ;
         H003T3_n442ResponsavelProfissao = new bool[] {false} ;
         H003T3_A487ClienteProfissao = new int[1] ;
         H003T3_n487ClienteProfissao = new bool[] {false} ;
         H003T3_A489ClienteConvenio = new int[1] ;
         H003T3_n489ClienteConvenio = new bool[] {false} ;
         H003T3_A445ResponsavelMunicipioNome = new string[] {""} ;
         H003T3_n445ResponsavelMunicipioNome = new bool[] {false} ;
         H003T3_A443ResponsavelProfissaoNome = new string[] {""} ;
         H003T3_n443ResponsavelProfissaoNome = new bool[] {false} ;
         H003T3_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         H003T3_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         H003T3_A404BancoCodigo = new int[1] ;
         H003T3_n404BancoCodigo = new bool[] {false} ;
         H003T3_A187MunicipioNome = new string[] {""} ;
         H003T3_n187MunicipioNome = new bool[] {false} ;
         H003T3_A488ClienteProfissaoNome = new string[] {""} ;
         H003T3_n488ClienteProfissaoNome = new bool[] {false} ;
         H003T3_A485ClienteNacionalidadeNome = new string[] {""} ;
         H003T3_n485ClienteNacionalidadeNome = new bool[] {false} ;
         H003T3_A490ClienteConvenioDescricao = new string[] {""} ;
         H003T3_n490ClienteConvenioDescricao = new bool[] {false} ;
         H003T3_A207TipoClientePortal = new bool[] {false} ;
         H003T3_n207TipoClientePortal = new bool[] {false} ;
         H003T3_A177ClienteLogUser = new short[1] ;
         H003T3_n177ClienteLogUser = new bool[] {false} ;
         H003T3_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H003T3_n176ClienteUpdatedAt = new bool[] {false} ;
         H003T3_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H003T3_n175ClienteCreatedAt = new bool[] {false} ;
         H003T3_A174ClienteStatus = new bool[] {false} ;
         H003T3_n174ClienteStatus = new bool[] {false} ;
         H003T3_A192TipoClienteId = new short[1] ;
         H003T3_n192TipoClienteId = new bool[] {false} ;
         H003T3_A172ClienteTipoPessoa = new string[] {""} ;
         H003T3_n172ClienteTipoPessoa = new bool[] {false} ;
         H003T3_A169ClienteDocumento = new string[] {""} ;
         H003T3_n169ClienteDocumento = new bool[] {false} ;
         H003T3_A171ClienteNomeFantasia = new string[] {""} ;
         H003T3_n171ClienteNomeFantasia = new bool[] {false} ;
         H003T3_A170ClienteRazaoSocial = new string[] {""} ;
         H003T3_n170ClienteRazaoSocial = new bool[] {false} ;
         H003T3_A193TipoClienteDescricao = new string[] {""} ;
         H003T3_n193TipoClienteDescricao = new bool[] {false} ;
         H003T3_A168ClienteId = new int[1] ;
         H003T3_A608SecUserId_F = new short[1] ;
         H003T3_n608SecUserId_F = new bool[] {false} ;
         H003T3_A200ContatoNumero = new long[1] ;
         H003T3_n200ContatoNumero = new bool[] {false} ;
         H003T3_A198ContatoDDD = new short[1] ;
         H003T3_n198ContatoDDD = new bool[] {false} ;
         H003T3_A202ContatoTelefoneNumero = new long[1] ;
         H003T3_n202ContatoTelefoneNumero = new bool[] {false} ;
         H003T3_A203ContatoTelefoneDDD = new short[1] ;
         H003T3_n203ContatoTelefoneDDD = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         H003T5_AGRID_nRecordCount = new long[1] ;
         AV9HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV35ManageFiltersXml = "";
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV33Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV67AuxText = "";
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienteww__default(),
            new Object[][] {
                new Object[] {
               H003T3_A186MunicipioCodigo, H003T3_n186MunicipioCodigo, H003T3_A444ResponsavelMunicipio, H003T3_n444ResponsavelMunicipio, H003T3_A402BancoId, H003T3_n402BancoId, H003T3_A437ResponsavelNacionalidade, H003T3_n437ResponsavelNacionalidade, H003T3_A484ClienteNacionalidade, H003T3_n484ClienteNacionalidade,
               H003T3_A442ResponsavelProfissao, H003T3_n442ResponsavelProfissao, H003T3_A487ClienteProfissao, H003T3_n487ClienteProfissao, H003T3_A489ClienteConvenio, H003T3_n489ClienteConvenio, H003T3_A445ResponsavelMunicipioNome, H003T3_n445ResponsavelMunicipioNome, H003T3_A443ResponsavelProfissaoNome, H003T3_n443ResponsavelProfissaoNome,
               H003T3_A438ResponsavelNacionalidadeNome, H003T3_n438ResponsavelNacionalidadeNome, H003T3_A404BancoCodigo, H003T3_n404BancoCodigo, H003T3_A187MunicipioNome, H003T3_n187MunicipioNome, H003T3_A488ClienteProfissaoNome, H003T3_n488ClienteProfissaoNome, H003T3_A485ClienteNacionalidadeNome, H003T3_n485ClienteNacionalidadeNome,
               H003T3_A490ClienteConvenioDescricao, H003T3_n490ClienteConvenioDescricao, H003T3_A207TipoClientePortal, H003T3_n207TipoClientePortal, H003T3_A177ClienteLogUser, H003T3_n177ClienteLogUser, H003T3_A176ClienteUpdatedAt, H003T3_n176ClienteUpdatedAt, H003T3_A175ClienteCreatedAt, H003T3_n175ClienteCreatedAt,
               H003T3_A174ClienteStatus, H003T3_n174ClienteStatus, H003T3_A192TipoClienteId, H003T3_n192TipoClienteId, H003T3_A172ClienteTipoPessoa, H003T3_n172ClienteTipoPessoa, H003T3_A169ClienteDocumento, H003T3_n169ClienteDocumento, H003T3_A171ClienteNomeFantasia, H003T3_n171ClienteNomeFantasia,
               H003T3_A170ClienteRazaoSocial, H003T3_n170ClienteRazaoSocial, H003T3_A193TipoClienteDescricao, H003T3_n193TipoClienteDescricao, H003T3_A168ClienteId, H003T3_A608SecUserId_F, H003T3_n608SecUserId_F, H003T3_A200ContatoNumero, H003T3_n200ContatoNumero, H003T3_A198ContatoDDD,
               H003T3_n198ContatoDDD, H003T3_A202ContatoTelefoneNumero, H003T3_n202ContatoTelefoneNumero, H003T3_A203ContatoTelefoneDDD, H003T3_n203ContatoTelefoneDDD
               }
               , new Object[] {
               H003T5_AGRID_nRecordCount
               }
            }
         );
         AV115Pgmname = "ClienteWW";
         /* GeneXus formulas. */
         AV115Pgmname = "ClienteWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV36ManageFiltersExecutionStep ;
      private short AV45TFClienteStatus_Sel ;
      private short gxajaxcallmode ;
      private short A198ContatoDDD ;
      private short A203ContatoTelefoneDDD ;
      private short wbEnd ;
      private short wbStart ;
      private short AV114GridActionGroup1 ;
      private short A192TipoClienteId ;
      private short A177ClienteLogUser ;
      private short A608SecUserId_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV118Clientewwds_3_dynamicfiltersoperator1 ;
      private short AV131Clientewwds_16_dynamicfiltersoperator2 ;
      private short AV144Clientewwds_29_dynamicfiltersoperator3 ;
      private short AV162Clientewwds_47_tfclientestatus_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_188 ;
      private int nGXsfl_188_idx=1 ;
      private int AV96BancoCodigo1 ;
      private int AV103BancoCodigo2 ;
      private int AV110BancoCodigo3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV161Clientewwds_46_tfclientetipopessoa_sels_Count ;
      private int AV125Clientewwds_10_bancocodigo1 ;
      private int AV138Clientewwds_23_bancocodigo2 ;
      private int AV151Clientewwds_36_bancocodigo3 ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int edtClienteId_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteCelular_F_Enabled ;
      private int edtClienteTelefone_F_Enabled ;
      private int edtTipoClienteId_Enabled ;
      private int edtClienteCreatedAt_Enabled ;
      private int edtClienteUpdatedAt_Enabled ;
      private int edtClienteLogUser_Enabled ;
      private int edtSecUserId_F_Enabled ;
      private int AV57PageToGo ;
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
      private int AV163GXV1 ;
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
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_188_idx="0001" ;
      private string AV115Pgmname ;
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
      private string cmbavGridactiongroup1_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtTipoClienteDescricao_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteNomeFantasia_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string cmbClienteTipoPessoa_Internalname ;
      private string edtClienteCelular_F_Internalname ;
      private string edtClienteTelefone_F_Internalname ;
      private string edtTipoClienteId_Internalname ;
      private string cmbClienteStatus_Internalname ;
      private string edtClienteCreatedAt_Internalname ;
      private string edtClienteUpdatedAt_Internalname ;
      private string edtClienteLogUser_Internalname ;
      private string edtSecUserId_F_Internalname ;
      private string cmbTipoClientePortal_Internalname ;
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
      private string cmbClienteStatus_Columnheaderclass ;
      private string cmbClienteStatus_Columnclass ;
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
      private string sGXsfl_188_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtClienteId_Jsonclick ;
      private string edtTipoClienteDescricao_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string cmbClienteTipoPessoa_Jsonclick ;
      private string edtClienteCelular_F_Jsonclick ;
      private string edtClienteTelefone_F_Jsonclick ;
      private string edtTipoClienteId_Jsonclick ;
      private string cmbClienteStatus_Jsonclick ;
      private string edtClienteCreatedAt_Jsonclick ;
      private string edtClienteUpdatedAt_Jsonclick ;
      private string edtClienteLogUser_Jsonclick ;
      private string edtSecUserId_F_Jsonclick ;
      private string cmbTipoClientePortal_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A175ClienteCreatedAt ;
      private DateTime A176ClienteUpdatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
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
      private bool n193TipoClienteDescricao ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n169ClienteDocumento ;
      private bool n172ClienteTipoPessoa ;
      private bool n192TipoClienteId ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool n175ClienteCreatedAt ;
      private bool n176ClienteUpdatedAt ;
      private bool n177ClienteLogUser ;
      private bool n608SecUserId_F ;
      private bool A207TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private bool bGXsfl_188_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV129Clientewwds_14_dynamicfiltersenabled2 ;
      private bool AV142Clientewwds_27_dynamicfiltersenabled3 ;
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
      private bool n200ContatoNumero ;
      private bool n198ContatoDDD ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV43TFClienteTipoPessoa_SelsJson ;
      private string AV35ManageFiltersXml ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20ClienteDocumento1 ;
      private string AV68TipoClienteDescricao1 ;
      private string AV93ClienteConvenioDescricao1 ;
      private string AV94ClienteNacionalidadeNome1 ;
      private string AV95ClienteProfissaoNome1 ;
      private string AV79MunicipioNome1 ;
      private string AV97ResponsavelNacionalidadeNome1 ;
      private string AV98ResponsavelProfissaoNome1 ;
      private string AV99ResponsavelMunicipioNome1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24ClienteDocumento2 ;
      private string AV70TipoClienteDescricao2 ;
      private string AV100ClienteConvenioDescricao2 ;
      private string AV101ClienteNacionalidadeNome2 ;
      private string AV102ClienteProfissaoNome2 ;
      private string AV80MunicipioNome2 ;
      private string AV104ResponsavelNacionalidadeNome2 ;
      private string AV105ResponsavelProfissaoNome2 ;
      private string AV106ResponsavelMunicipioNome2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28ClienteDocumento3 ;
      private string AV72TipoClienteDescricao3 ;
      private string AV107ClienteConvenioDescricao3 ;
      private string AV108ClienteNacionalidadeNome3 ;
      private string AV109ClienteProfissaoNome3 ;
      private string AV81MunicipioNome3 ;
      private string AV111ResponsavelNacionalidadeNome3 ;
      private string AV112ResponsavelProfissaoNome3 ;
      private string AV113ResponsavelMunicipioNome3 ;
      private string AV77TFTipoClienteDescricao ;
      private string AV78TFTipoClienteDescricao_Sel ;
      private string AV37TFClienteRazaoSocial ;
      private string AV38TFClienteRazaoSocial_Sel ;
      private string AV41TFClienteDocumento ;
      private string AV42TFClienteDocumento_Sel ;
      private string AV60GridAppliedFilters ;
      private string A193TipoClienteDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A169ClienteDocumento ;
      private string A172ClienteTipoPessoa ;
      private string A206ClienteCelular_F ;
      private string A205ClienteTelefone_F ;
      private string lV116Clientewwds_1_filterfulltext ;
      private string lV119Clientewwds_4_clientedocumento1 ;
      private string lV120Clientewwds_5_tipoclientedescricao1 ;
      private string lV121Clientewwds_6_clienteconveniodescricao1 ;
      private string lV122Clientewwds_7_clientenacionalidadenome1 ;
      private string lV123Clientewwds_8_clienteprofissaonome1 ;
      private string lV124Clientewwds_9_municipionome1 ;
      private string lV126Clientewwds_11_responsavelnacionalidadenome1 ;
      private string lV127Clientewwds_12_responsavelprofissaonome1 ;
      private string lV128Clientewwds_13_responsavelmunicipionome1 ;
      private string lV132Clientewwds_17_clientedocumento2 ;
      private string lV133Clientewwds_18_tipoclientedescricao2 ;
      private string lV134Clientewwds_19_clienteconveniodescricao2 ;
      private string lV135Clientewwds_20_clientenacionalidadenome2 ;
      private string lV136Clientewwds_21_clienteprofissaonome2 ;
      private string lV137Clientewwds_22_municipionome2 ;
      private string lV139Clientewwds_24_responsavelnacionalidadenome2 ;
      private string lV140Clientewwds_25_responsavelprofissaonome2 ;
      private string lV141Clientewwds_26_responsavelmunicipionome2 ;
      private string lV145Clientewwds_30_clientedocumento3 ;
      private string lV146Clientewwds_31_tipoclientedescricao3 ;
      private string lV147Clientewwds_32_clienteconveniodescricao3 ;
      private string lV148Clientewwds_33_clientenacionalidadenome3 ;
      private string lV149Clientewwds_34_clienteprofissaonome3 ;
      private string lV150Clientewwds_35_municipionome3 ;
      private string lV152Clientewwds_37_responsavelnacionalidadenome3 ;
      private string lV153Clientewwds_38_responsavelprofissaonome3 ;
      private string lV154Clientewwds_39_responsavelmunicipionome3 ;
      private string lV155Clientewwds_40_tftipoclientedescricao ;
      private string lV157Clientewwds_42_tfclienterazaosocial ;
      private string lV159Clientewwds_44_tfclientedocumento ;
      private string AV116Clientewwds_1_filterfulltext ;
      private string AV117Clientewwds_2_dynamicfiltersselector1 ;
      private string AV119Clientewwds_4_clientedocumento1 ;
      private string AV120Clientewwds_5_tipoclientedescricao1 ;
      private string AV121Clientewwds_6_clienteconveniodescricao1 ;
      private string AV122Clientewwds_7_clientenacionalidadenome1 ;
      private string AV123Clientewwds_8_clienteprofissaonome1 ;
      private string AV124Clientewwds_9_municipionome1 ;
      private string AV126Clientewwds_11_responsavelnacionalidadenome1 ;
      private string AV127Clientewwds_12_responsavelprofissaonome1 ;
      private string AV128Clientewwds_13_responsavelmunicipionome1 ;
      private string AV130Clientewwds_15_dynamicfiltersselector2 ;
      private string AV132Clientewwds_17_clientedocumento2 ;
      private string AV133Clientewwds_18_tipoclientedescricao2 ;
      private string AV134Clientewwds_19_clienteconveniodescricao2 ;
      private string AV135Clientewwds_20_clientenacionalidadenome2 ;
      private string AV136Clientewwds_21_clienteprofissaonome2 ;
      private string AV137Clientewwds_22_municipionome2 ;
      private string AV139Clientewwds_24_responsavelnacionalidadenome2 ;
      private string AV140Clientewwds_25_responsavelprofissaonome2 ;
      private string AV141Clientewwds_26_responsavelmunicipionome2 ;
      private string AV143Clientewwds_28_dynamicfiltersselector3 ;
      private string AV145Clientewwds_30_clientedocumento3 ;
      private string AV146Clientewwds_31_tipoclientedescricao3 ;
      private string AV147Clientewwds_32_clienteconveniodescricao3 ;
      private string AV148Clientewwds_33_clientenacionalidadenome3 ;
      private string AV149Clientewwds_34_clienteprofissaonome3 ;
      private string AV150Clientewwds_35_municipionome3 ;
      private string AV152Clientewwds_37_responsavelnacionalidadenome3 ;
      private string AV153Clientewwds_38_responsavelprofissaonome3 ;
      private string AV154Clientewwds_39_responsavelmunicipionome3 ;
      private string AV156Clientewwds_41_tftipoclientedescricao_sel ;
      private string AV155Clientewwds_40_tftipoclientedescricao ;
      private string AV158Clientewwds_43_tfclienterazaosocial_sel ;
      private string AV157Clientewwds_42_tfclienterazaosocial ;
      private string AV160Clientewwds_45_tfclientedocumento_sel ;
      private string AV159Clientewwds_44_tfclientedocumento ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private string AV67AuxText ;
      private IGxSession AV33Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV9HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbClienteTipoPessoa ;
      private GXCombobox cmbClienteStatus ;
      private GXCombobox cmbTipoClientePortal ;
      private GxSimpleCollection<string> AV44TFClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV34ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV56DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV161Clientewwds_46_tfclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H003T3_A186MunicipioCodigo ;
      private bool[] H003T3_n186MunicipioCodigo ;
      private string[] H003T3_A444ResponsavelMunicipio ;
      private bool[] H003T3_n444ResponsavelMunicipio ;
      private int[] H003T3_A402BancoId ;
      private bool[] H003T3_n402BancoId ;
      private int[] H003T3_A437ResponsavelNacionalidade ;
      private bool[] H003T3_n437ResponsavelNacionalidade ;
      private int[] H003T3_A484ClienteNacionalidade ;
      private bool[] H003T3_n484ClienteNacionalidade ;
      private int[] H003T3_A442ResponsavelProfissao ;
      private bool[] H003T3_n442ResponsavelProfissao ;
      private int[] H003T3_A487ClienteProfissao ;
      private bool[] H003T3_n487ClienteProfissao ;
      private int[] H003T3_A489ClienteConvenio ;
      private bool[] H003T3_n489ClienteConvenio ;
      private string[] H003T3_A445ResponsavelMunicipioNome ;
      private bool[] H003T3_n445ResponsavelMunicipioNome ;
      private string[] H003T3_A443ResponsavelProfissaoNome ;
      private bool[] H003T3_n443ResponsavelProfissaoNome ;
      private string[] H003T3_A438ResponsavelNacionalidadeNome ;
      private bool[] H003T3_n438ResponsavelNacionalidadeNome ;
      private int[] H003T3_A404BancoCodigo ;
      private bool[] H003T3_n404BancoCodigo ;
      private string[] H003T3_A187MunicipioNome ;
      private bool[] H003T3_n187MunicipioNome ;
      private string[] H003T3_A488ClienteProfissaoNome ;
      private bool[] H003T3_n488ClienteProfissaoNome ;
      private string[] H003T3_A485ClienteNacionalidadeNome ;
      private bool[] H003T3_n485ClienteNacionalidadeNome ;
      private string[] H003T3_A490ClienteConvenioDescricao ;
      private bool[] H003T3_n490ClienteConvenioDescricao ;
      private bool[] H003T3_A207TipoClientePortal ;
      private bool[] H003T3_n207TipoClientePortal ;
      private short[] H003T3_A177ClienteLogUser ;
      private bool[] H003T3_n177ClienteLogUser ;
      private DateTime[] H003T3_A176ClienteUpdatedAt ;
      private bool[] H003T3_n176ClienteUpdatedAt ;
      private DateTime[] H003T3_A175ClienteCreatedAt ;
      private bool[] H003T3_n175ClienteCreatedAt ;
      private bool[] H003T3_A174ClienteStatus ;
      private bool[] H003T3_n174ClienteStatus ;
      private short[] H003T3_A192TipoClienteId ;
      private bool[] H003T3_n192TipoClienteId ;
      private string[] H003T3_A172ClienteTipoPessoa ;
      private bool[] H003T3_n172ClienteTipoPessoa ;
      private string[] H003T3_A169ClienteDocumento ;
      private bool[] H003T3_n169ClienteDocumento ;
      private string[] H003T3_A171ClienteNomeFantasia ;
      private bool[] H003T3_n171ClienteNomeFantasia ;
      private string[] H003T3_A170ClienteRazaoSocial ;
      private bool[] H003T3_n170ClienteRazaoSocial ;
      private string[] H003T3_A193TipoClienteDescricao ;
      private bool[] H003T3_n193TipoClienteDescricao ;
      private int[] H003T3_A168ClienteId ;
      private short[] H003T3_A608SecUserId_F ;
      private bool[] H003T3_n608SecUserId_F ;
      private long[] H003T3_A200ContatoNumero ;
      private bool[] H003T3_n200ContatoNumero ;
      private short[] H003T3_A198ContatoDDD ;
      private bool[] H003T3_n198ContatoDDD ;
      private long[] H003T3_A202ContatoTelefoneNumero ;
      private bool[] H003T3_n202ContatoTelefoneNumero ;
      private short[] H003T3_A203ContatoTelefoneDDD ;
      private bool[] H003T3_n203ContatoTelefoneDDD ;
      private long[] H003T5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV14GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clienteww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003T3( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV161Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV116Clientewwds_1_filterfulltext ,
                                             string AV117Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV118Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV119Clientewwds_4_clientedocumento1 ,
                                             string AV120Clientewwds_5_tipoclientedescricao1 ,
                                             string AV121Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV122Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV123Clientewwds_8_clienteprofissaonome1 ,
                                             string AV124Clientewwds_9_municipionome1 ,
                                             int AV125Clientewwds_10_bancocodigo1 ,
                                             string AV126Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV127Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV128Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV129Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV130Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV131Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV132Clientewwds_17_clientedocumento2 ,
                                             string AV133Clientewwds_18_tipoclientedescricao2 ,
                                             string AV134Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV135Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV136Clientewwds_21_clienteprofissaonome2 ,
                                             string AV137Clientewwds_22_municipionome2 ,
                                             int AV138Clientewwds_23_bancocodigo2 ,
                                             string AV139Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV140Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV141Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV142Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV143Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV144Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV145Clientewwds_30_clientedocumento3 ,
                                             string AV146Clientewwds_31_tipoclientedescricao3 ,
                                             string AV147Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV148Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV149Clientewwds_34_clienteprofissaonome3 ,
                                             string AV150Clientewwds_35_municipionome3 ,
                                             int AV151Clientewwds_36_bancocodigo3 ,
                                             string AV152Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV153Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV154Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV156Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV155Clientewwds_40_tftipoclientedescricao ,
                                             string AV158Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV157Clientewwds_42_tfclienterazaosocial ,
                                             string AV160Clientewwds_45_tfclientedocumento_sel ,
                                             string AV159Clientewwds_44_tfclientedocumento ,
                                             int AV161Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV162Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[79];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClientePortal, T1.ClienteLogUser, T1.ClienteUpdatedAt, T1.ClienteCreatedAt, T1.ClienteStatus, T1.TipoClienteId, T1.ClienteTipoPessoa, T1.ClienteDocumento, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T10.TipoClienteDescricao, T1.ClienteId, COALESCE( T11.SecUserId_F, 0) AS SecUserId_F, T1.ContatoNumero, T1.ContatoDDD, T1.ContatoTelefoneNumero, T1.ContatoTelefoneDDD";
         sFromString = " FROM ((((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId) LEFT JOIN LATERAL (SELECT MIN(T12.SecUserId) AS SecUserId_F, T12.SecUserOwnerId FROM SecUser T12,  Cliente T13 WHERE (T1.ClienteId = T12.SecUserOwnerId) AND (T12.SecUserOwnerId = T13.ClienteId) GROUP BY T12.SecUserOwnerId ) T11 ON T11.SecUserOwnerId = T1.ClienteId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T10.TipoClienteDescricao) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV119Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV119Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV120Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV120Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV121Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV121Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV122Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV122Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV123Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV123Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV124Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV124Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV126Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV126Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV127Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV127Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV128Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV128Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV132Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV132Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV133Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV133Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV134Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV134Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV135Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV135Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV136Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV136Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV137Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV137Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV139Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV139Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV140Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV140Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV141Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV141Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV145Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV145Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV146Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[51] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV146Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[52] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV147Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[53] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV147Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV148Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[55] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV148Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[56] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV149Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[57] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV149Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[58] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV150Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int7[59] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV150Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int7[60] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[61] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[62] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int7[63] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV152Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV152Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV153Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV153Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV154Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV154Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV155Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int7[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV156Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao = ( :AV156Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int7[71] = 1;
         }
         if ( StringUtil.StrCmp(AV156Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T10.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV157Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int7[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV158Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV158Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[73] = 1;
         }
         if ( StringUtil.StrCmp(AV158Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV159Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int7[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV160Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV160Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int7[75] = 1;
         }
         if ( StringUtil.StrCmp(AV160Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV161Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV161Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV162Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV162Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T10.TipoClienteDescricao, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T10.TipoClienteDescricao DESC, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteRazaoSocial, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteRazaoSocial DESC, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteTipoPessoa, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteTipoPessoa DESC, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ClienteStatus, T1.ClienteId";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ClienteStatus DESC, T1.ClienteId";
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

      protected Object[] conditional_H003T5( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV161Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV116Clientewwds_1_filterfulltext ,
                                             string AV117Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV118Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV119Clientewwds_4_clientedocumento1 ,
                                             string AV120Clientewwds_5_tipoclientedescricao1 ,
                                             string AV121Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV122Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV123Clientewwds_8_clienteprofissaonome1 ,
                                             string AV124Clientewwds_9_municipionome1 ,
                                             int AV125Clientewwds_10_bancocodigo1 ,
                                             string AV126Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV127Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV128Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV129Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV130Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV131Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV132Clientewwds_17_clientedocumento2 ,
                                             string AV133Clientewwds_18_tipoclientedescricao2 ,
                                             string AV134Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV135Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV136Clientewwds_21_clienteprofissaonome2 ,
                                             string AV137Clientewwds_22_municipionome2 ,
                                             int AV138Clientewwds_23_bancocodigo2 ,
                                             string AV139Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV140Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV141Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV142Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV143Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV144Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV145Clientewwds_30_clientedocumento3 ,
                                             string AV146Clientewwds_31_tipoclientedescricao3 ,
                                             string AV147Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV148Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV149Clientewwds_34_clienteprofissaonome3 ,
                                             string AV150Clientewwds_35_municipionome3 ,
                                             int AV151Clientewwds_36_bancocodigo3 ,
                                             string AV152Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV153Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV154Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV156Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV155Clientewwds_40_tftipoclientedescricao ,
                                             string AV158Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV157Clientewwds_42_tfclienterazaosocial ,
                                             string AV160Clientewwds_45_tfclientedocumento_sel ,
                                             string AV159Clientewwds_44_tfclientedocumento ,
                                             int AV161Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV162Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[76];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((((((((((Cliente T1 LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN LATERAL (SELECT MIN(T12.SecUserId) AS SecUserId_F, T12.SecUserOwnerId FROM SecUser T12,  Cliente T13 WHERE (T1.ClienteId = T12.SecUserOwnerId) AND (T12.SecUserOwnerId = T13.ClienteId) GROUP BY T12.SecUserOwnerId ) T11 ON T11.SecUserOwnerId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.TipoClienteDescricao) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV116Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV116Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV119Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV119Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV120Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV120Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV121Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV121Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV122Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV122Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV123Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV123Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV124Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV124Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV125Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV125Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV126Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV126Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV127Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV127Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV128Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV117Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV118Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV128Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV132Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV132Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV133Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV133Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV134Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV134Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV135Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV135Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV136Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int9[36] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV136Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int9[37] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV137Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int9[38] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV137Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int9[39] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[40] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[41] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV138Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV138Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int9[42] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV139Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int9[43] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV139Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int9[44] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV140Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int9[45] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV140Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int9[46] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV141Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int9[47] = 1;
         }
         if ( AV129Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV130Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV131Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV141Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int9[48] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV145Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int9[49] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV145Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int9[50] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV146Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int9[51] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV146Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int9[52] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV147Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int9[53] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV147Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int9[54] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV148Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int9[55] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV148Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int9[56] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV149Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int9[57] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV149Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int9[58] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV150Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int9[59] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV150Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int9[60] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[61] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[62] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV151Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int9[63] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV152Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int9[64] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV152Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int9[65] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV153Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int9[66] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV153Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int9[67] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV154Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int9[68] = 1;
         }
         if ( AV142Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV143Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV144Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV154Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int9[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV155Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int9[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV156Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV156Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int9[71] = 1;
         }
         if ( StringUtil.StrCmp(AV156Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV157Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int9[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV158Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV158Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int9[73] = 1;
         }
         if ( StringUtil.StrCmp(AV158Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV159Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int9[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV160Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV160Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int9[75] = 1;
         }
         if ( StringUtil.StrCmp(AV160Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV161Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV161Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV162Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV162Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
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
                     return conditional_H003T3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (short)dynConstraints[61] , (bool)dynConstraints[62] );
               case 1 :
                     return conditional_H003T5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (short)dynConstraints[61] , (bool)dynConstraints[62] );
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
          Object[] prmH003T3;
          prmH003T3 = new Object[] {
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV119Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV119Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV120Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV120Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV121Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV121Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV122Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV122Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV123Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV123Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV124Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV124Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV126Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV126Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV127Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV127Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV128Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV128Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV132Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV132Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV133Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV134Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV134Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV135Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV135Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV136Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV136Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV137Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV137Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV139Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV139Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV140Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV140Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV141Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV141Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV145Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV146Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV147Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV147Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV148Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV148Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV149Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV149Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV150Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV150Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV152Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV152Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV153Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV153Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV154Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV154Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV155Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV156Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV157Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV158Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV159Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV160Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003T5;
          prmH003T5 = new Object[] {
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV119Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV119Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV120Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV120Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV121Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV121Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV122Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV122Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV123Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV123Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV124Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV124Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV125Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV126Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV126Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV127Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV127Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV128Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV128Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV132Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV132Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV133Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV134Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV134Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV135Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV135Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV136Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV136Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV137Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV137Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV138Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV139Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV139Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV140Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV140Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV141Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV141Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV145Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV145Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV146Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV146Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV147Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV147Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV148Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV148Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV149Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV149Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV150Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV150Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV151Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV152Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV152Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV153Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV153Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV154Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV154Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV155Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV156Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV157Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV158Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV159Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV160Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T5,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[32])[0] = rslt.getBool(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((short[]) buf[34])[0] = rslt.getShort(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((short[]) buf[42])[0] = rslt.getShort(22);
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
                ((long[]) buf[57])[0] = rslt.getLong(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((long[]) buf[61])[0] = rslt.getLong(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((short[]) buf[63])[0] = rslt.getShort(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
